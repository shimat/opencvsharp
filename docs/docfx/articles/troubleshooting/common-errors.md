# Common Errors and Diagnostics

Most OpenCvSharp failures fall into one of four groups: an input image is empty, a `Mat` has the wrong size or type, a native component is unavailable, or an object was used with the wrong ownership or lifetime.

## Start with the complete exception

An `OpenCVException` contains the native status, function name, message, source file, and source line:

```csharp
static void RunWithOpenCvDiagnostics(Action operation)
{
    try
    {
        operation();
    }
    catch (OpenCVException ex)
    {
        Console.Error.WriteLine(
            $"{ex.Status} in {ex.FuncName}: {ex.ErrMsg} " +
            $"({ex.FileName}:{ex.Line})");
        throw;
    }
}
```

An OpenCV assertion such as `(-215:Assertion failed)` normally means that a documented precondition was violated. Read the named native function's official OpenCV reference and compare its accepted depth, channels, dimensions, and empty-input behavior with the actual `Mat`.

## Check every decoded or captured image

Image decoding can return an empty `Mat` without throwing:

```csharp
using var image = Cv2.ImRead(fileName, ImreadModes.Color);
if (image.Empty())
{
    throw new IOException(
        $"Could not decode image: {fileName}");
}
```

For video, check both the Boolean return value and the frame:

```csharp
using var frame = new Mat();
if (!capture.Read(frame) || frame.Empty())
{
    throw new IOException("Could not read a frame.");
}
```

Common causes include an incorrect working directory, a missing file, unsupported encoded data, the end of a stream, or an unavailable backend.

## Print the Mat contract

Before the failing call, record the properties that OpenCV uses for validation:

```csharp
static void PrintMat(string name, Mat mat)
{
    Console.WriteLine(
        $"{name}: {mat.Width}x{mat.Height}, " +
        $"type={mat.Type()}, depth={mat.Depth()}, " +
        $"channels={mat.Channels()}, empty={mat.Empty()}, " +
        $"continuous={mat.IsContinuous()}");
}
```

Typical mismatches include:

- Passing BGR input to an operation that requires grayscale.
- Passing floating-point input where only 8-bit input is supported.
- Combining images with different sizes or types.
- Passing a three-channel image where a single-channel mask is required.
- Using the source size where a destination or kernel size is expected.

Convert explicitly with `Cv2.CvtColor` or `Mat.ConvertTo` rather than changing metadata or assuming an implicit conversion.

## Treat masks as single-channel selectors

A conventional mask has the same width and height as the source and type `CV_8UC1`. Its non-zero pixels select source pixels.

If an operation reports a mask assertion, print both contracts:

```csharp
PrintMat("source", source);
PrintMat("mask", mask);
```

Do not pass a BGR visualization of a mask back into an operation that expects the original single-channel mask.

## Distinguish native loading failures

`DllNotFoundException` means the .NET runtime could not locate `OpenCvSharpExtern` or one of its native dependencies. `BadImageFormatException` commonly indicates an architecture mismatch, such as loading an x64 native library from an ARM64 process.

Check:

1. The managed and runtime packages belong to the same OpenCvSharp major version.
2. The runtime identifier matches the process architecture and operating system.
3. The native package is present in the application's `runtimes/{rid}/native/` output.
4. Required system libraries are installed.
5. A single-file, container, or plugin deployment did not remove or relocate native assets.

Continue with [Native Library Loading](native-library-loading.md) for platform-specific diagnosis.

## Inspect the native OpenCV build

Print the OpenCV version and build configuration when a codec, GUI, or optional module behaves differently across machines:

```csharp
Console.WriteLine(Cv2.GetVersionString());
Console.WriteLine(Cv2.GetBuildInformation());
```

The build information reports enabled modules and dependencies such as image codecs, video backends, GUI support, and parallel runtimes.

For an opened video source or writer, record its selected backend:

```csharp
Console.WriteLine($"Capture backend: {capture.GetBackendName()}");
Console.WriteLine($"Writer backend: {writer.GetBackendName()}");
```

Codec and camera behavior can vary by backend even when the same managed code is used.

## Diagnose color problems

OpenCV image decoding normally produces BGR channel order. Many UI, web, and plotting systems expect RGB or BGRA.

Symptoms include:

- Red and blue appear swapped.
- An image is transparent or has an unexpected alpha channel.
- A grayscale image is treated as color.

Use an explicit conversion at the integration boundary:

```csharp
using var rgb = new Mat();
Cv2.CvtColor(bgr, rgb, ColorConversionCodes.BGR2RGB);
```

OpenCvSharp UI extension converters handle their documented framework formats. Do not apply an extra red-blue swap unless the destination actually expects it.

## Diagnose memory growth

OpenCvSharp objects can own native memory that the .NET garbage collector does not measure accurately.

Check for:

- A new `Mat` created on every loop iteration without `using` or `Dispose`.
- Captured frames stored in an unbounded collection.
- A region of interest keeping a large parent buffer alive.
- Replaced `VideoCapture`, `VideoWriter`, `Net`, or algorithm objects that were never disposed.
- A method returning a `Mat` without a clear ownership contract.

Reuse destinations inside stable loops and follow [Resource Management](../guides/resource-management.md).

## Diagnose display failures

`Cv2.ImShow` requires a HighGUI backend and a graphical environment. It does not work with a headless runtime package and may fail in a container, service, SSH session, or CI runner without a display server.

For desktop applications, convert the `Mat` to a framework-native bitmap as described in [Display Images in .NET Applications](../guides/displaying-images-dotnet.md). For services and tests, encode or save the result instead of opening a window.

## Minimal reproduction checklist

When asking for help, reduce the failure to:

- The smallest input that still fails.
- A complete runnable C# example.
- OpenCvSharp package names and versions.
- Operating system and process architecture.
- The full exception, including inner exceptions.
- `Cv2.GetVersionString()` and the relevant portion of `Cv2.GetBuildInformation()`.
- The printed size, type, depth, and channel count of every input `Mat`.

Avoid posting only the final assertion line; the function name and input contracts usually contain the actual explanation.

## Official OpenCV references

- [OpenCV configuration options](https://docs.opencv.org/5.0/tutorials/introduction/config_reference/config_reference.html)
- [OpenCV environment variables](https://docs.opencv.org/5.0/tutorials/introduction/env_reference/env_reference.html)
- [OpenCV 5 documentation](https://docs.opencv.org/5.0/index.html)

## Related OpenCvSharp API

- [OpenCVException](xref:OpenCvSharp.OpenCVException)
- [Mat](xref:OpenCvSharp.Mat)
- [Cv2](xref:OpenCvSharp.Cv2)
- [VideoCapture](xref:OpenCvSharp.VideoCapture)
- [VideoWriter](xref:OpenCvSharp.VideoWriter)
