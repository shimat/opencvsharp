# Contours and Shape Analysis

Contours describe object boundaries in a binary image. They are useful for measuring area, locating bounding boxes, approximating shapes, and drawing annotations.

## Prepare a binary input

`Cv2.FindContours` expects an 8-bit single-channel image where zero is background and non-zero pixels are foreground:

```csharp
using var source = Cv2.ImRead("objects.png", ImreadModes.Color);
if (source.Empty())
{
    throw new IOException("Could not read objects.png.");
}

using var grayscale = new Mat();
using var binary = new Mat();

Cv2.CvtColor(source, grayscale, ColorConversionCodes.BGR2GRAY);
Cv2.Threshold(
    grayscale,
    binary,
    0,
    255,
    ThresholdTypes.Binary | ThresholdTypes.Otsu);
```

If the objects are darker than the background, use `ThresholdTypes.BinaryInv | ThresholdTypes.Otsu`.

## Find external contours

Use `RetrievalModes.External` when only the outer boundary of each foreground object matters:

```csharp
using Mat contourInput = binary.Clone();
Cv2.FindContours(
    contourInput,
    out Point[][] contours,
    out HierarchyIndex[] hierarchy,
    RetrievalModes.External,
    ContourApproximationModes.ApproxSimple);
```

Each element in `contours` is a managed array of image coordinates. `ApproxSimple` compresses straight segments to their endpoints and is appropriate for most measurement and drawing tasks.

The cloned input makes the ownership and reuse of `binary` unambiguous across OpenCV versions and overloads.

## Filter and draw contours

Measure contour area before drawing or performing more expensive analysis:

```csharp
Point[][] significantContours = contours
    .Where(contour => Cv2.ContourArea(contour) >= 500)
    .ToArray();

using Mat annotated = source.Clone();
Cv2.DrawContours(
    annotated,
    significantContours,
    contourIdx: -1,
    color: new Scalar(0, 255, 0),
    thickness: 2);

foreach (Point[] contour in significantContours)
{
    Rect bounds = Cv2.BoundingRect(contour);
    Cv2.Rectangle(
        annotated,
        bounds,
        new Scalar(0, 0, 255),
        thickness: 2);
}
```

`contourIdx: -1` draws every contour in the supplied collection. OpenCV colors are BGR by default, so `(0, 255, 0)` is green and `(0, 0, 255)` is red.

## Understand contour hierarchy

`HierarchyIndex` records four indices for each contour:

- The next contour at the same level.
- The previous contour at the same level.
- The first child contour.
- The parent contour.

Missing relationships use `-1`. `RetrievalModes.External` produces no nested children. Use `RetrievalModes.CComp` for two-level component boundaries or `RetrievalModes.Tree` for the full nesting structure.

## Use connected components for filled regions

Connected-component labeling is often simpler when the goal is to enumerate filled blobs rather than analyze their boundaries:

```csharp
ConnectedComponents components = Cv2.ConnectedComponentsEx(binary);
using Mat annotated = source.Clone();

foreach (ConnectedComponents.Blob blob in components.Blobs.Skip(1))
{
    if (blob.Area < 500)
    {
        continue;
    }

    Cv2.Rectangle(
        annotated,
        blob.Rect,
        new Scalar(255, 0, 0),
        thickness: 2);
}
```

Label zero is the background, so typical applications skip the first blob. Each remaining blob includes its area, centroid, and bounding rectangle.

Choose contours when perimeter geometry and nested boundaries matter. Choose connected components when labels, areas, centroids, and axis-aligned bounds are sufficient.

## Common mistakes

- Passing a three-channel color image to `FindContours`.
- Treating grayscale intensity as a mask without thresholding it first.
- Forgetting that `Point.X` is the column and `Point.Y` is the row.
- Using `RetrievalModes.External` when holes or nested objects are significant.
- Comparing contour area with bounding-box area as if they were equivalent.
- Keeping every noise contour instead of filtering by scale or applying morphology first.

## From C++ or Python

The native `std::vector<std::vector<cv::Point>>` and the Python contour sequence map naturally to `Point[][]` in the common OpenCvSharp overload. Python returns contours and hierarchy together, while OpenCvSharp uses `out` parameters.

## Official OpenCV references

- [Structural analysis and shape descriptors](https://docs.opencv.org/5.0/main_modules/imgproc_shape.html)
- [OpenCV image processing tutorials](https://docs.opencv.org/5.0/tutorials/imgproc/imgproc.html)

## Related OpenCvSharp API

- [Cv2](xref:OpenCvSharp.Cv2)
- [HierarchyIndex](xref:OpenCvSharp.HierarchyIndex)
- [RetrievalModes](xref:OpenCvSharp.RetrievalModes)
- [ContourApproximationModes](xref:OpenCvSharp.ContourApproximationModes)
- [ConnectedComponents](xref:OpenCvSharp.ConnectedComponents)
