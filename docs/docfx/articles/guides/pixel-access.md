# Pixel Access

OpenCvSharp provides several ways to access matrix elements. Use `Mat.At<T>` for occasional access and `Mat.AsRows<T>` for loops that process many pixels. Prefer an OpenCV operation such as `Cv2.CvtColor`, `Cv2.LUT`, or `Cv2.Transform` when one already expresses the operation because native operations are usually faster than a managed pixel loop.

## Match the element type

The generic type must match the complete element type of the matrix, including its depth and channel count.

| Mat type | C# element type |
|---|---|
| `CV_8UC1` | `byte` |
| `CV_8UC3` | `Vec3b` |
| `CV_8UC4` | `Vec4b` |
| `CV_16SC1` | `short` |
| `CV_32FC1` | `float` |
| `CV_64FC1` | `double` |

OpenCV stores color images in BGR order by default, so `Vec3b.Item0`, `Item1`, and `Item2` represent blue, green, and red respectively.

## Access an occasional pixel

`At<T>` returns a reference, so it can both read and update an element:

```csharp
using var image = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (image.Type() != MatType.CV_8UC3)
{
    throw new InvalidOperationException($"Expected CV_8UC3, but received {image.Type()}.");
}

ref Vec3b pixel = ref image.At<Vec3b>(10, 20);
byte blue = pixel.Item0;
pixel.Item0 = pixel.Item2;
pixel.Item2 = blue;
```

The first coordinate is the row (`y`) and the second coordinate is the column (`x`).

## Process every pixel

`AsRows<T>` captures the matrix data pointer and row stride once. It handles non-contiguous matrices and row padding, so it is suitable for both complete images and regions of interest:

```csharp
using var image = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (image.Type() != MatType.CV_8UC3)
{
    throw new InvalidOperationException($"Expected CV_8UC3, but received {image.Type()}.");
}

var rows = image.AsRows<Vec3b>();
for (int y = 0; y < rows.Count; y++)
{
    Span<Vec3b> row = rows[y];
    for (int x = 0; x < row.Length; x++)
    {
        ref Vec3b pixel = ref row[x];
        byte blue = pixel.Item0;
        pixel.Item0 = pixel.Item2;
        pixel.Item2 = blue;
    }
}
```

This example swaps the blue and red channels. For this particular operation, `Cv2.CvtColor(image, image, ColorConversionCodes.BGR2RGB)` is simpler and normally faster; the loop demonstrates access for operations that cannot be expressed by an existing OpenCV function.

## Access a single row

Use `RowSpan<T>` when only one row is needed:

```csharp
using var grayscale = new Mat(480, 640, MatType.CV_8UC1);
Span<byte> firstRow = grayscale.RowSpan<byte>(0);
firstRow.Fill(0);
```

The span excludes any padding bytes between rows.

## Continuous matrices

`AsSpan<T>` returns a span over the entire matrix only when `Mat.IsContinuous()` is true. It returns an empty span for a non-contiguous matrix. Prefer `AsRows<T>` unless the algorithm specifically requires one flat continuous buffer.

## Obsolete indexers

`GetGenericIndexer<T>` and its indexer class use marshaling for each element and are obsolete. Existing code should move to `At<T>` or `AsRows<T>`. `Mat<T>.GetIndexer()` remains available, but `AsRows<T>` avoids creating a typed wrapper and makes row-stride handling explicit.

## Related API

- [Mat](xref:OpenCvSharp.Mat)
- [MatRowAccessor&lt;T&gt;](xref:OpenCvSharp.MatRowAccessor`1)
- [Vec3b](xref:OpenCvSharp.Vec3b)
