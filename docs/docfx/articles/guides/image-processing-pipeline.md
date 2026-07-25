# Build an Image Processing Pipeline

Most classical computer vision programs follow a pipeline: load an image, normalize it into the representation an algorithm expects, isolate interesting pixels, extract objects, and produce a result. This example detects sufficiently large bright regions and draws their contours.

## Complete example

```csharp
using OpenCvSharp;

using var source = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (source.Empty())
{
    throw new FileNotFoundException("Could not decode input.jpg.");
}

using var grayscale = new Mat();
Cv2.CvtColor(source, grayscale, ColorConversionCodes.BGR2GRAY);

using var blurred = new Mat();
Cv2.GaussianBlur(grayscale, blurred, new Size(5, 5), sigmaX: 0);

using var binary = new Mat();
Cv2.Threshold(
    blurred,
    binary,
    thresh: 0,
    maxval: 255,
    type: ThresholdTypes.Binary | ThresholdTypes.Otsu);

using var kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(3, 3));
using var cleaned = new Mat();
Cv2.MorphologyEx(binary, cleaned, MorphTypes.Open, kernel);

Cv2.FindContours(
    cleaned,
    out Point[][] contours,
    out _,
    RetrievalModes.External,
    ContourApproximationModes.ApproxSimple);

Point[][] significantContours = contours
    .Where(contour => Cv2.ContourArea(contour) >= 100)
    .ToArray();

using var annotated = source.Clone();
Cv2.DrawContours(
    annotated,
    significantContours,
    contourIdx: -1,
    color: Scalar.Red,
    thickness: 2);

Cv2.ImWrite("result.png", annotated);
```

## What each stage does

### Normalize the input

`CvtColor` produces a single-channel image because thresholding intensity is easier to reason about than thresholding three BGR channels independently. Choose the color conversion that matches the meaning of the input; `BGR2GRAY` is only one possibility.

### Reduce noise

`GaussianBlur` suppresses small intensity variations before thresholding. Kernel size and sigma affect how much detail is removed. Avoid copying a kernel size from an example without checking it against the size of objects in the real images.

### Create a binary mask

The combination of `Binary` and `Otsu` asks OpenCV to estimate one global threshold from the image histogram. It is a good baseline for images with two well-separated intensity groups. Uneven illumination may require `AdaptiveThreshold`, illumination correction, or a different segmentation method.

### Clean the mask

Morphological opening removes small foreground spots. Closing instead fills small holes and gaps. The structuring-element shape and size encode what counts as "small," so they should be treated as model parameters rather than universal constants.

### Extract and filter objects

`FindContours` returns arrays of points around connected shapes. `RetrievalModes.External` ignores nested contours, which is appropriate when only outer boundaries matter. Filter by area, geometry, or domain-specific measurements before drawing or analyzing the result.

## Debug a pipeline stage by stage

Save intermediate images while tuning a pipeline:

```csharp
Cv2.ImWrite("debug-01-grayscale.png", grayscale);
Cv2.ImWrite("debug-02-binary.png", binary);
Cv2.ImWrite("debug-03-cleaned.png", cleaned);
```

When a final result is wrong, intermediate images show which stage first lost the desired information. This is usually more useful than tuning several parameters at once.

## Related guides

- [Mat Basics](mat-basics.md)
- [Pixel Access](pixel-access.md)
- [Resource Management](resource-management.md)

## Related API

- [Cv2.CvtColor](xref:OpenCvSharp.Cv2.CvtColor*)
- [Cv2.Threshold](xref:OpenCvSharp.Cv2.Threshold*)
- [Cv2.MorphologyEx](xref:OpenCvSharp.Cv2.MorphologyEx*)
- [Cv2.FindContours](xref:OpenCvSharp.Cv2.FindContours*)
