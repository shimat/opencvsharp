# Copies, Native Memory, and Performance

OpenCvSharp combines C# object references with OpenCV's reference-counted native matrices. Understanding which operation aliases an object, shares pixel storage, or performs a deep copy is more important than applying isolated micro-optimizations.

## Distinguish assignment, views, and copies

These operations have different ownership:

| C# operation | Managed object | Pixel storage |
|---|---|---|
| `Mat alias = source;` | Same `Mat` object | Same storage |
| `new Mat(source, roi)` | New `Mat` header | Shared storage |
| `source.Clone()` | New `Mat` | Independent copied storage |
| `source.CopyTo(destination)` | Existing destination object | Independent storage, reused when compatible |

A C# assignment does not copy a native `cv::Mat` header:

```csharp
Mat alias = source;
```

`alias` and `source` are two managed references to the same disposable object. Disposing either reference disposes that object, so do not use assignment to express independent ownership.

## Regions of interest share pixels

A region of interest creates a separate native matrix header that views the source storage:

```csharp
using var region = new Mat(
    source,
    new Rect(X: 20, Y: 30, Width: 200, Height: 120));

region.SetTo(Scalar.Black);
```

The change is visible in `source`. The region keeps the underlying reference-counted OpenCV allocation alive, but both managed headers must still be disposed.

Create an independent result when the pixels must outlive or diverge from the source:

```csharp
using var copy = region.Clone();
```

`Clone()` always performs a deep copy. `Clone(roi)` is a convenient way to create an independent crop.

## Use CopyTo when the destination should be reused

`CopyTo` performs a deep copy but writes through an existing destination object:

```csharp
using var destination = new Mat();

source.CopyTo(destination);
```

If `destination` already has the required size and type, OpenCV can reuse its allocation. If not, OpenCV reallocates it. This makes `CopyTo` appropriate when a long-lived component owns the destination:

```csharp
static void CopyFrames(
    IEnumerable<Mat> frames,
    Action<Mat> consume)
{
    using var snapshot = new Mat();

    foreach (Mat frame in frames)
    {
        frame.CopyTo(snapshot);
        consume(snapshot);
    }
}
```

Do not retain `snapshot` outside the loop unless the consumer finishes before the next copy. Use `Clone()` when each iteration needs an independently owned image.

## Dispose native owners deterministically

The pixel buffer of a normal `Mat` is native memory. The .NET garbage collector tracks the small managed wrapper but does not accurately account for the native allocation behind it.

Prefer lexical ownership:

```csharp
using var source = Cv2.ImRead("input.jpg", ImreadModes.Color);
using var grayscale = new Mat();
using var edges = new Mat();

Cv2.CvtColor(
    source,
    grayscale,
    ColorConversionCodes.BGR2GRAY);
Cv2.Canny(grayscale, edges, 80, 160);
```

Dispose temporary matrices inside long-running loops rather than waiting for finalization. Do not call `GC.Collect()` as a resource-management strategy.

Returning a `Mat` transfers disposal responsibility to the caller:

```csharp
static Mat CreateThumbnail(Mat source)
{
    var thumbnail = new Mat();
    Cv2.Resize(
        source,
        thumbnail,
        new Size(320, 180),
        interpolation: InterpolationFlags.Area);
    return thumbnail;
}

using var thumbnail = CreateThumbnail(source);
```

## Reuse outputs in hot loops

Most OpenCV functions create or resize an `OutputArray` as needed. Keep destination `Mat` objects outside a loop when the output contract is stable:

```csharp
using var capture = new VideoCapture("input.mp4");
using var frame = new Mat();
using var grayscale = new Mat();
using var edges = new Mat();

while (capture.Read(frame))
{
    if (frame.Empty())
    {
        break;
    }

    Cv2.CvtColor(
        frame,
        grayscale,
        ColorConversionCodes.BGR2GRAY);
    Cv2.Canny(grayscale, edges, 80, 160);

    Process(edges);
}
```

This reuses managed wrappers and normally reuses native buffers while the dimensions and types remain unchanged. It is still correct when a new frame size forces reallocation.

Reuse is not equivalent to retaining every frame. Clone only frames that must remain stable after the next iteration.

## Wrap managed pixel memory carefully

`Mat.FromPixelData` can create a matrix header without copying an existing managed array:

```csharp
const int width = 640;
const int height = 480;

byte[] pixels = new byte[width * height * 3];

using var image = Mat.FromPixelData(
    rows: height,
    cols: width,
    type: MatType.CV_8UC3,
    data: pixels);
```

The array overload pins the managed array while the `Mat` is alive. Changes are shared in both directions. Dispose the `Mat` promptly so the array is unpinned; long-lived pinned arrays make the managed heap harder to compact.

The `IntPtr` overload does not own the pointed-to allocation. The caller must keep the memory valid for every native access and release it separately.

Treat a zero-copy matrix as a view over external storage. If it is passed as an output to a function that changes the size or type, OpenCV may replace its backing allocation, after which it no longer represents the original array or pointer. Use `Clone()` when OpenCV should own independent storage.

## Respect stride and continuity

Rows may contain padding, and a region of interest is not necessarily continuous. Do not calculate every row as `DataPointer + row * width * elementSize` unless continuity is guaranteed.

Use `AsRows<T>()` for fast row-by-row access:

```csharp
if (image.Type() != MatType.CV_8UC3)
{
    throw new ArgumentException("Expected CV_8UC3.", nameof(image));
}

var rows = image.AsRows<Vec3b>();
for (var y = 0; y < rows.Count; y++)
{
    Span<Vec3b> row = rows[y];
    for (var x = 0; x < row.Length; x++)
    {
        Vec3b pixel = row[x];
        row[x] = new Vec3b(pixel.Item2, pixel.Item1, pixel.Item0);
    }
}
```

`AsRows<T>()` captures the data pointer, stride, and dimensions. Do not dispose or reallocate the `Mat` while the accessor or one of its spans is in use. `AsSpan<T>()` returns an empty span for a non-continuous matrix.

Prefer an existing `Cv2` operation over a managed pixel loop when OpenCV already provides the transformation. The native implementation can use vectorization, parallelism, and optimized libraries that a per-pixel P/Invoke or general managed loop cannot match.

## Account for hidden copies

Common copy boundaries include:

- `Clone()` and `CopyTo`.
- Encoding a `Mat` to PNG or JPEG.
- Decoding PNG or JPEG bytes to a `Mat`.
- Converting to UI-framework bitmap types.
- Materializing a `MatExpr`.
- Calling `ToArray()` or similar APIs that return managed data.

Removing one copy is useful only if it is meaningful relative to decoding, inference, filtering, encoding, network I/O, and UI presentation. Measure the complete pipeline with representative image sizes.

## Benchmark native work correctly

When using BenchmarkDotNet or another harness:

1. Load or generate source images outside the measured operation.
2. Reuse destinations in one benchmark and allocate them in a separate benchmark.
3. Dispose every native object created by an iteration.
4. Consume or validate output so the benchmark represents real work.
5. Test the same size, type, channels, backend, and thread configuration used in production.
6. Report throughput and peak working set as well as managed allocations.

Managed allocation counters do not include most `Mat` pixel storage. Use process memory, native profilers, or a controlled working-set test when native memory is the concern.

## Choose an ownership operation

| Requirement | Preferred operation |
|---|---|
| Another name for the same managed object | C# assignment |
| Temporary rectangular view | ROI constructor |
| Independent image owned by the caller | `Clone()` |
| Copy into a component-owned reusable buffer | `CopyTo()` |
| View a managed array without copying | `Mat.FromPixelData(Array)` with a short `using` scope |
| Process many same-shaped frames | Reuse destination `Mat` objects |

## Related guides

- [Mat Basics](mat-basics.md)
- [Pixel Access](pixel-access.md)
- [InputArray, OutputArray, and In-place Processing](input-output-arrays-and-in-place.md)
- [Resource Management](resource-management.md)

## Official OpenCV references

- [Mat: the basic image container](https://docs.opencv.org/5.0/tutorials/core/mat_the_basic_image_container/mat_the_basic_image_container.html)
- [OpenCV core functionality](https://docs.opencv.org/5.0/main_modules/core.html)

## Related OpenCvSharp API

- [Mat](xref:OpenCvSharp.Mat)
- [MatExpr](xref:OpenCvSharp.MatExpr)
- [Cv2](xref:OpenCvSharp.Cv2)
