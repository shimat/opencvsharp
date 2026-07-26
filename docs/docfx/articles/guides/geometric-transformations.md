# Geometric Transformations

Geometric transformations change an image's size, orientation, or coordinate system. OpenCvSharp follows the native OpenCV model: a source `Mat`, a destination `Mat`, a transformation definition, and an interpolation or border policy.

## Resize an image

Specify the final dimensions when the output size is known:

```csharp
using var source = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (source.Empty())
{
    throw new InvalidOperationException("Could not read input.jpg.");
}

using var resized = new Mat();
Cv2.Resize(
    source,
    resized,
    new Size(640, 480),
    interpolation: InterpolationFlags.Area);
```

`InterpolationFlags.Area` is normally a good choice when reducing an image. `InterpolationFlags.Linear` is a common default for enlargement, while `InterpolationFlags.Nearest` preserves exact class values in label images and masks.

To preserve the aspect ratio, calculate one dimension:

```csharp
const int targetWidth = 800;
double scale = (double)targetWidth / source.Width;
int targetHeight = (int)Math.Round(source.Height * scale);

using var resized = new Mat();
Cv2.Resize(
    source,
    resized,
    new Size(targetWidth, targetHeight),
    interpolation: InterpolationFlags.Area);
```

## Crop with a region of interest

A region of interest is a lightweight `Mat` header that views the source image data:

```csharp
var roi = new Rect(x: 100, y: 80, width: 320, height: 240);
using Mat view = source.SubMat(roi);
```

The rectangle must remain inside the source image. The view and source share pixel storage, so modifications through `view` affect `source`, and `source` must remain alive while the view is used.

Clone the view when the cropped image must own independent storage or outlive the source:

```csharp
using Mat cropped = view.Clone();
```

## Rotate by a right angle

Use `Cv2.Rotate` for exact 90-degree operations:

```csharp
using var rotated = new Mat();
Cv2.Rotate(source, rotated, RotateFlags.Rotate90Clockwise);
```

This is simpler than constructing an affine matrix and does not interpolate pixels.

## Rotate by an arbitrary angle

Create a 2-by-3 affine transformation matrix and pass it to `Cv2.WarpAffine`:

```csharp
var center = new Point2f(source.Width / 2f, source.Height / 2f);
using Mat rotation = Cv2.GetRotationMatrix2D(center, angle: 15, scale: 1);
using var rotated = new Mat();

Cv2.WarpAffine(
    source,
    rotated,
    rotation,
    source.Size(),
    InterpolationFlags.Linear,
    BorderTypes.Constant,
    new Scalar(0, 0, 0));
```

The destination size is independent of the transformation. Keeping `source.Size()` can clip corners after rotation. Calculate a larger destination and adjust the translation terms in the matrix when the entire rotated image must remain visible.

## Rectify a quadrilateral

A perspective transformation maps four source points to four destination points. The point order must correspond between the two arrays:

```csharp
Point2f[] sourceCorners =
[
    new(120, 80),
    new(920, 110),
    new(880, 680),
    new(150, 650),
];

Point2f[] destinationCorners =
[
    new(0, 0),
    new(799, 0),
    new(799, 599),
    new(0, 599),
];

using Mat transform = Cv2.GetPerspectiveTransform(
    sourceCorners,
    destinationCorners);
using var rectified = new Mat();

Cv2.WarpPerspective(
    source,
    rectified,
    transform,
    new Size(800, 600));
```

Use a consistent order such as top-left, top-right, bottom-right, bottom-left. A crossed or inconsistent order produces a folded or mirrored result.

## Interpolation and border choices

The official OpenCV reference defines the exact interpolation formulas and supported flags. In typical OpenCvSharp applications:

- Use `Area` when shrinking photographs.
- Use `Linear` for general-purpose resizing and warping.
- Use `Cubic` or `Lanczos4` when enlargement quality matters more than speed.
- Use `Nearest` for masks, labels, and other discrete values.
- Use `BorderTypes.Constant` when pixels outside the image should have a known value.
- Use `BorderTypes.Replicate` or `Reflect101` when filters or transforms should extend edge content.

Always pass destination dimensions as `(width, height)` through `Size`. Image indexing and `Mat` construction otherwise commonly use `(rows, columns)`, which correspond to `(height, width)`.

## From C++ or Python

The native functions `cv::resize`, `cv::warpAffine`, and `cv::warpPerspective` map to `Cv2.Resize`, `Cv2.WarpAffine`, and `Cv2.WarpPerspective`. Python commonly returns a new NumPy array, while OpenCvSharp normally receives a destination `Mat` that the caller owns and disposes.

## Official OpenCV references

- [Geometric image transformations](https://docs.opencv.org/5.0/main_modules/imgproc_transform.html)
- [Image processing tutorials](https://docs.opencv.org/5.0/tutorials/imgproc/imgproc.html)

## Related OpenCvSharp API

- [Cv2](xref:OpenCvSharp.Cv2)
- [Mat](xref:OpenCvSharp.Mat)
- [InterpolationFlags](xref:OpenCvSharp.InterpolationFlags)
- [BorderTypes](xref:OpenCvSharp.BorderTypes)
