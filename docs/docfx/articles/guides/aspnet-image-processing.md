# ASP.NET Core Image Uploads and Streams

An uploaded PNG or JPEG is compressed file data, while an OpenCvSharp `Mat` contains decoded pixels. A typical ASP.NET Core request therefore crosses two explicit conversion boundaries:

1. Read and limit the uploaded bytes.
2. Decode the bytes with `Cv2.ImDecode`.
3. Process caller-owned `Mat` objects.
4. Encode the result with `Cv2.ImEncode`.
5. Return the encoded managed byte array.

OpenCV does not decode an arbitrary .NET `Stream` incrementally. Even when ASP.NET Core receives the request as a stream, the encoded image must be collected into a contiguous buffer before calling `ImDecode`.

## Process an IFormFile in a controller

The following controller accepts one buffered multipart upload, converts it to grayscale, and returns a PNG:

```csharp
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenCvSharp;

namespace ImageApi.Controllers;

[ApiController]
[Route("images")]
public sealed class ImagesController : ControllerBase
{
    private const long MaxFileBytes = 10 * 1024 * 1024;
    private const long MaxRequestBytes = 11 * 1024 * 1024;
    private const long MaxDecodedPixels = 40_000_000;

    [HttpPost("grayscale")]
    [RequestSizeLimit(MaxRequestBytes)]
    public async Task<IActionResult> Grayscale(
        IFormFile file,
        CancellationToken cancellationToken)
    {
        if (file.Length is <= 0 or > MaxFileBytes)
        {
            return BadRequest("Upload one non-empty image up to 10 MiB.");
        }

        using var encoded = new MemoryStream(
            capacity: checked((int)file.Length));
        await file.CopyToAsync(encoded, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            using var source = Cv2.ImDecode(
                encoded.GetBuffer().AsSpan(
                    start: 0,
                    length: checked((int)encoded.Length)),
                ImreadModes.Color);

            if (source.Empty())
            {
                return BadRequest("The upload is not a supported image.");
            }

            if (source.Total() > MaxDecodedPixels)
            {
                return BadRequest("The decoded image is too large.");
            }

            cancellationToken.ThrowIfCancellationRequested();

            using var grayscale = new Mat();
            Cv2.CvtColor(
                source,
                grayscale,
                ColorConversionCodes.BGR2GRAY);

            if (!Cv2.ImEncode(".png", grayscale, out byte[] png))
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Could not encode the result.");
            }

            return File(png, "image/png");
        }
        catch (OpenCVException)
        {
            return BadRequest("The upload could not be decoded.");
        }
    }
}
```

`IFormFile` is already buffered by ASP.NET Core, potentially in memory or a temporary file. Copying it into a `MemoryStream` creates a contiguous buffer for `ImDecode`. `GetBuffer()` avoids the additional array copy that `ToArray()` would make.

The request limit is slightly larger than the file limit because a multipart request also contains boundaries and headers. Hosting layers such as IIS or a reverse proxy may impose their own limits.

Do not trust `IFormFile.FileName` or `ContentType` to select a decoder or response type. Decode the content, choose the output format on the server, and return the media type that matches that encoder.

## Decode an arbitrary Stream with a byte limit

For `HttpRequest.Body`, blob storage, or another stream source, enforce a byte limit while buffering. This helper returns a caller-owned `Mat`:

```csharp
using OpenCvSharp;

static async Task<Mat> DecodeImageAsync(
    Stream source,
    int maxEncodedBytes,
    ImreadModes mode,
    CancellationToken cancellationToken)
{
    ArgumentNullException.ThrowIfNull(source);
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxEncodedBytes);

    using var encoded = new MemoryStream(
        capacity: Math.Min(maxEncodedBytes, 64 * 1024));
    byte[] chunk = new byte[64 * 1024];

    while (true)
    {
        int remaining = maxEncodedBytes - checked((int)encoded.Length);
        int readSize = remaining >= chunk.Length
            ? chunk.Length
            : remaining + 1;
        int read = await source.ReadAsync(
            chunk.AsMemory(0, readSize),
            cancellationToken);

        if (read == 0)
        {
            break;
        }

        if (read > remaining)
        {
            throw new InvalidDataException(
                "The encoded image exceeds the configured limit.");
        }

        await encoded.WriteAsync(
            chunk.AsMemory(0, read),
            cancellationToken);
    }

    if (encoded.Length == 0)
    {
        throw new InvalidDataException("The encoded image is empty.");
    }

    cancellationToken.ThrowIfCancellationRequested();

    Mat image = Cv2.ImDecode(
        encoded.GetBuffer().AsSpan(
            start: 0,
            length: checked((int)encoded.Length)),
        mode);

    if (!image.Empty())
    {
        return image;
    }

    image.Dispose();
    throw new InvalidDataException(
        "The stream does not contain a supported image.");
}
```

The caller owns the returned matrix:

```csharp
using Mat image = await DecodeImageAsync(
    Request.Body,
    maxEncodedBytes: 10 * 1024 * 1024,
    ImreadModes.Color,
    HttpContext.RequestAborted);
```

This helper applies an application limit even when the stream does not report a length. Configure the server or endpoint request-body limit as the first line of defense so the application does not need to receive an oversized body before rejecting it.

For very frequent requests, an `ArrayPool<byte>` or a recyclable stream can reduce managed buffer allocation. Return pooled storage only after `ImDecode` completes because the decoder reads the buffer synchronously during the call.

## Validate encoded and decoded sizes

An encoded file can expand to a much larger pixel buffer. Validate at multiple layers:

- Request-body size at Kestrel, IIS, or the reverse proxy.
- Multipart and per-file size before copying an `IFormFile`.
- A byte limit while reading an arbitrary stream.
- `Empty()`, dimensions, channel count, and decoded pixel count after `ImDecode`.
- Application-specific limits before expensive processing or encoding.

Checking decoded dimensions happens after the decoder has allocated the image. If hostile image formats or decompression bombs are in scope, use an image-header parser with strict dimension limits, isolate decoding in a constrained worker, or apply operating-system memory limits. A post-decode check alone cannot prevent the decoder's initial allocation.

## Manage cancellation and CPU work

`CopyToAsync` and `ReadAsync` observe a `CancellationToken`. Most `Cv2` calls are synchronous native operations and cannot be interrupted by an ASP.NET Core cancellation token after they start.

Check cancellation before expensive stages and avoid starting new work after `HttpContext.RequestAborted` is signaled. For long-running or untrusted workloads, move processing to a bounded queue or worker process that has an explicit timeout and resource limits.

Wrapping every `Cv2` call in `Task.Run` does not reduce its CPU or memory cost. Under load it can add ThreadPool contention. Use bounded concurrency, and benchmark it together with OpenCV's own native thread usage. `Cv2.SetNumThreads` changes process-wide OpenCV behavior, so configure it once only when measurements justify doing so.

Each request should own its mutable matrices. Do not share a writable `Mat` between concurrent requests without external synchronization and a clear ownership model.

## Return encoded data, not a Mat

`Mat` is a native resource and is not an HTTP response representation. Encode it before leaving the request scope:

```csharp
if (!Cv2.ImEncode(".jpg", result, out byte[] jpeg, [
    new ImageEncodingParam(
        ImwriteFlags.JpegQuality,
        90),
]))
{
    throw new InvalidOperationException(
        "Could not encode the JPEG response.");
}

return Results.File(jpeg, "image/jpeg");
```

The returned `byte[]` is managed and remains valid after the source and result matrices are disposed. Encoding necessarily creates a compressed output buffer; it is not a zero-copy view of the `Mat`.

## Deploy without a desktop GUI

ASP.NET Core services normally do not use `Cv2.ImShow`, WPF, or another desktop UI. Choose the headless runtime package when the service needs the full non-GUI OpenCV module set, or the slim package only when its reduced modules are sufficient.

Native runtime assets must match the deployment runtime identifier and architecture. Containers may also require native dependencies for the selected image codecs. Log `Cv2.GetVersionString()` and `Cv2.GetBuildInformation()` when production codec behavior differs from development.

## Related guides

- [Image Encoding and Conversion](image-conversion.md)
- [Copies, Native Memory, and Performance](memory-copy-and-performance.md)
- [Common Errors and Diagnostics](../troubleshooting/common-errors.md)
- [Native Library Loading](../troubleshooting/native-library-loading.md)

## Official references

- [OpenCV image file reading and writing](https://docs.opencv.org/5.0/main_modules/imgcodecs.html)
- [Upload files in ASP.NET Core](https://learn.microsoft.com/aspnet/core/mvc/models/file-uploads)
- [Configure Kestrel server limits](https://learn.microsoft.com/aspnet/core/fundamentals/servers/kestrel/options)

## Related OpenCvSharp API

- [Cv2](xref:OpenCvSharp.Cv2)
- [Mat](xref:OpenCvSharp.Mat)
- [ImreadModes](xref:OpenCvSharp.ImreadModes)
- [ImageEncodingParam](xref:OpenCvSharp.ImageEncodingParam)
