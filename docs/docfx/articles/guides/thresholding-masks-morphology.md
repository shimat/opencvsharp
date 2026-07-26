# Thresholding, Masks, and Morphology

Binary masks select pixels for later processing. In OpenCvSharp, a conventional mask is a single-channel `CV_8UC1` `Mat`: zero excludes a pixel and any non-zero value includes it.

## Create a binary image with a fixed threshold

Convert color input to grayscale before applying a simple threshold:

```csharp
using var source = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (source.Empty())
{
    throw new IOException("Could not read input.jpg.");
}

using var grayscale = new Mat();
using var binary = new Mat();

Cv2.CvtColor(source, grayscale, ColorConversionCodes.BGR2GRAY);
Cv2.Threshold(
    grayscale,
    binary,
    thresh: 128,
    maxval: 255,
    ThresholdTypes.Binary);
```

Pixels greater than the threshold become 255 and the remaining pixels become zero. Use `ThresholdTypes.BinaryInv` when dark objects should become foreground.

## Select the threshold automatically

Otsu thresholding calculates a global threshold from the input histogram:

```csharp
using var binary = new Mat();
double selectedThreshold = Cv2.Threshold(
    grayscale,
    binary,
    thresh: 0,
    maxval: 255,
    ThresholdTypes.Binary | ThresholdTypes.Otsu);

Console.WriteLine($"Selected threshold: {selectedThreshold}");
```

`Cv2.Threshold` returns the selected scalar threshold and writes the binary image to the destination `Mat`. This differs from Python, where both values are normally returned as a tuple.

## Handle uneven lighting

Adaptive thresholding calculates a local value for each neighborhood:

```csharp
using var adaptive = new Mat();
Cv2.AdaptiveThreshold(
    grayscale,
    adaptive,
    maxValue: 255,
    AdaptiveThresholdTypes.GaussianC,
    ThresholdTypes.Binary,
    blockSize: 21,
    c: 5);
```

`blockSize` must be an odd value greater than one. Larger neighborhoods follow slower illumination changes; `c` shifts the local threshold.

## Select a color range

Convert BGR input to a color space suited to the selection, then use `Cv2.InRange`. This example creates a mask for a green hue range:

```csharp
using var hsv = new Mat();
using var greenMask = new Mat();

Cv2.CvtColor(source, hsv, ColorConversionCodes.BGR2HSV);
Cv2.InRange(
    hsv,
    new Scalar(35, 50, 50),
    new Scalar(85, 255, 255),
    greenMask);
```

For 8-bit HSV images, OpenCV represents hue in the range 0 through 179. Hue ranges that cross red's wraparound point require two `InRange` calls followed by `Cv2.BitwiseOr`.

## Remove small mask defects

Morphological opening removes small foreground regions. Closing fills small holes and gaps:

```csharp
using Mat kernel = Cv2.GetStructuringElement(
    MorphShapes.Ellipse,
    new Size(5, 5));
using var opened = new Mat();
using var cleaned = new Mat();

Cv2.MorphologyEx(
    greenMask,
    opened,
    MorphTypes.Open,
    kernel);
Cv2.MorphologyEx(
    opened,
    cleaned,
    MorphTypes.Close,
    kernel);
```

Kernel shape and size should reflect the image scale. A large kernel can erase narrow objects or merge nearby regions.

## Apply a mask

Pass the mask to `Mat.CopyTo` to copy only selected pixels:

```csharp
using var selected = new Mat();
source.CopyTo(selected, cleaned);
```

The source and mask must have the same width and height. The mask remains single-channel even when the source has three or four channels.

## Choose the right operation

- Use a fixed threshold when lighting and foreground intensity are controlled.
- Use Otsu or Triangle thresholding when a global histogram separates foreground and background.
- Use adaptive thresholding when illumination varies across the image.
- Use `InRange` when selection depends on an interval or color range.
- Use morphology to refine a mask after thresholding, not as a substitute for a meaningful segmentation rule.

## From C++ or Python

`cv::threshold`, `cv::adaptiveThreshold`, `cv::inRange`, and `cv::morphologyEx` map to the corresponding PascalCase methods on `Cv2`. Python examples often combine masks through NumPy operators; use `Cv2.BitwiseAnd`, `Cv2.BitwiseOr`, and `Cv2.BitwiseNot` when the operands are OpenCvSharp `Mat` objects.

## Official OpenCV references

- [Miscellaneous image transformations](https://docs.opencv.org/5.0/main_modules/imgproc_misc.html)
- [Image filtering and morphology](https://docs.opencv.org/5.0/main_modules/imgproc_filter.html)
- [OpenCV image processing tutorials](https://docs.opencv.org/5.0/tutorials/imgproc/imgproc.html)

## Related OpenCvSharp API

- [Cv2](xref:OpenCvSharp.Cv2)
- [ThresholdTypes](xref:OpenCvSharp.ThresholdTypes)
- [AdaptiveThresholdTypes](xref:OpenCvSharp.AdaptiveThresholdTypes)
- [MorphTypes](xref:OpenCvSharp.MorphTypes)
- [MorphShapes](xref:OpenCvSharp.MorphShapes)
