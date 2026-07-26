# Mat Basics

`Mat` is the central data container in OpenCV. It can represent an image, a numeric matrix, or a multidimensional tensor. Understanding its type, ownership, and copy behavior prevents many subtle bugs.

## Inspect a matrix

Always check that file loading succeeded before processing an image:

```csharp
using var image = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (image.Empty())
{
    throw new FileNotFoundException("Could not decode input.jpg.");
}

Console.WriteLine($"Size: {image.Width} x {image.Height}");
Console.WriteLine($"Type: {image.Type()}");
Console.WriteLine($"Depth: {image.Depth()}");
Console.WriteLine($"Channels: {image.Channels()}");
```

`ImRead` does not throw merely because a file is missing or cannot be decoded. It returns an empty `Mat`.

## Understand MatType

A `MatType` combines element depth and channel count. For example, `CV_8UC3` means:

- `8U`: each channel is an unsigned 8-bit integer.
- `C3`: each element contains three channels.

A normal color image loaded with `ImreadModes.Color` is usually `CV_8UC3`, with channels in BGR order. A grayscale image is usually `CV_8UC1`. Algorithms may require a specific depth or channel count, so inspect the input and perform an explicit conversion when necessary.

## Create a matrix

The following creates a 640 by 480 black BGR image and draws a filled blue rectangle:

```csharp
using var canvas = new Mat(
    rows: 480,
    cols: 640,
    type: MatType.CV_8UC3,
    s: Scalar.Black);

Cv2.Rectangle(
    canvas,
    new Rect(40, 30, 200, 120),
    Scalar.Blue,
    thickness: -1);
```

The first dimension is rows (height) and the second is columns (width).

## Regions of interest share data

A region of interest is a lightweight view over the original matrix:

```csharp
using var image = Cv2.ImRead("input.jpg", ImreadModes.Color);
using var region = image.SubMat(new Rect(X: 20, Y: 30, Width: 100, Height: 80));

region.SetTo(Scalar.Black);
```

Changing `region` also changes the corresponding pixels in `image`. Keep the parent matrix alive for at least as long as the region.

Use `Clone` when an independent copy is required:

```csharp
using var copy = image.Clone(new Rect(X: 20, Y: 30, Width: 100, Height: 80));
copy.SetTo(Scalar.Black);
```

Changing `copy` does not affect `image`.

## Convert depth and color separately

`ConvertTo` changes the element depth and optionally applies a scale and offset, but it does not perform color conversion:

```csharp
using var source8Bit = Cv2.ImRead("input.png", ImreadModes.Grayscale);
using var normalized = new Mat();

source8Bit.ConvertTo(normalized, MatType.CV_32FC1, alpha: 1.0 / 255.0);
```

Use `CvtColor` to change the color representation or channel count:

```csharp
using var color = Cv2.ImRead("input.jpg", ImreadModes.Color);
using var grayscale = new Mat();

Cv2.CvtColor(color, grayscale, ColorConversionCodes.BGR2GRAY);
```

## Wrap existing pixel data

`Mat.FromPixelData` creates a matrix header over an existing managed array without copying it:

```csharp
byte[] pixels =
[
    0, 64,
    128, 255,
];

using var image = Mat.FromPixelData(
    rows: 2,
    cols: 2,
    type: MatType.CV_8UC1,
    data: pixels);

Cv2.BitwiseNot(image, image);
```

The array is pinned while the `Mat` is alive, and changes are shared in both directions. Call `Clone` if OpenCV needs to own an independent copy. When using the `IntPtr` overload, the caller is responsible for keeping the underlying unmanaged memory valid and eventually releasing it.

## Related guides

- [Pixel Access](pixel-access.md)
- [InputArray, OutputArray, and In-place Processing](input-output-arrays-and-in-place.md)
- [Copies, Native Memory, and Performance](memory-copy-and-performance.md)
- [Resource Management](resource-management.md)
- [Image Encoding and Conversion](image-conversion.md)

## Official OpenCV references

- [Mat: the basic image container](https://docs.opencv.org/5.0/tutorials/core/mat_the_basic_image_container/mat_the_basic_image_container.html)
- [OpenCV core functionality](https://docs.opencv.org/5.0/main_modules/core.html)

## Related API

- [Mat](xref:OpenCvSharp.Mat)
- [MatType](xref:OpenCvSharp.MatType)
- [Cv2](xref:OpenCvSharp.Cv2)
