# Image Encoding and Conversion

An OpenCvSharp `Mat` stores decoded pixel data. A PNG or JPEG `byte[]` stores a compressed image file. UI frameworks such as GDI+ and WPF use their own decoded bitmap types. Choose the conversion that matches the representation needed by the application.

## Encode a Mat to PNG or JPEG

`Cv2.ImEncode` compresses a matrix into an image-file buffer. The extension selects the encoder:

```csharp
using var image = Cv2.ImRead("input.jpg", ImreadModes.Color);

if (!Cv2.ImEncode(".png", image, out byte[] pngBytes))
{
    throw new InvalidOperationException("PNG encoding failed.");
}

await File.WriteAllBytesAsync("copy.png", pngBytes);
```

`Mat.ToBytes` is a convenience wrapper around `Cv2.ImEncode`:

```csharp
byte[] jpegBytes = image.ToBytes(
    ".jpg",
    [new ImageEncodingParam(ImwriteFlags.JpegQuality, 90)]);
```

Encoding allocates a new managed byte array containing a complete compressed image file.

## Decode an image buffer to a Mat

Use `Cv2.ImDecode` when the application already has encoded image bytes:

```csharp
byte[] encoded = await File.ReadAllBytesAsync("input.png");
using Mat image = Cv2.ImDecode(encoded, ImreadModes.Color);

if (image.Empty())
{
    throw new InvalidDataException("Image decoding failed.");
}
```

`Mat.FromImageData` and `Mat.ImDecode` are convenience alternatives that call the same OpenCV decoder.

Do not use `ImDecode` for a raw pixel buffer. Raw pixels require dimensions, channel layout, depth, and row stride; construct a `Mat` with the appropriate `FromPixelData` overload instead.

## Convert between Mat and System.Drawing.Bitmap

GDI+ conversion is Windows-only. Install `OpenCvSharp5.GdipExtensions`, or use the `OpenCvSharp5.Windows` convenience package, and import `OpenCvSharp.GdipExtensions`:

```csharp
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.GdipExtensions;

using var image = Cv2.ImRead("input.jpg", ImreadModes.Color);
using Bitmap bitmap = image.ToBitmap();
using Mat roundTrip = bitmap.ToMat();
```

Dispose both `Bitmap` and `Mat`. The converter supports common 1-, 3-, and 4-channel 8-bit formats. It does not make `System.Drawing.Common` cross-platform.

## WPF

Install `OpenCvSharp5.WpfExtensions` and use the converters in `OpenCvSharp.WpfExtensions`:

- `BitmapSourceConverter.ToBitmapSource` converts a `Mat` to an immutable `BitmapSource`.
- `WriteableBitmapConverter.ToWriteableBitmap` converts a `Mat` to a `WriteableBitmap`.
- `WriteableBitmapConverter.ToMat` converts a `WriteableBitmap` to a `Mat`.

Check pixel format and channel order when exchanging images with a UI framework. OpenCvSharp color matrices normally use BGR or BGRA order, while another API may describe the same bytes with a different format name or expect RGB/RGBA.

## Avoid unnecessary round trips

For file uploads, HTTP responses, and database blobs, encode directly with `Cv2.ImEncode` instead of converting through `Bitmap`. For image processing, keep data in `Mat` form and convert only at the UI boundary.

See [Display Images in .NET Applications](displaying-images-dotnet.md) for WPF, Avalonia, GDI+, UI-thread, and live-frame guidance.

See [ASP.NET Core Image Uploads and Streams](aspnet-image-processing.md) for bounded upload buffering, `IFormFile`, request cancellation, and HTTP responses.

## Official OpenCV references

- [OpenCV image file reading and writing](https://docs.opencv.org/5.0/main_modules/imgcodecs.html)
- [OpenCV color space conversions](https://docs.opencv.org/5.0/main_modules/imgproc_color_conversions.html)

## Related API

- [Cv2.ImEncode](xref:OpenCvSharp.Cv2.ImEncode*)
- [Cv2.ImDecode](xref:OpenCvSharp.Cv2.ImDecode*)
- [Mat](xref:OpenCvSharp.Mat)
