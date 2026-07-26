# InputArray, OutputArray, and In-place Processing

OpenCV uses `InputArray`, `OutputArray`, and `InputOutputArray` to accept several matrix-like types through one C++ signature. OpenCvSharp mirrors those roles, but normal application code should usually pass a `Mat` directly and let the implicit conversion create the required proxy.

## Read the parameter roles

The wrapper type describes how the native function uses the argument:

| OpenCvSharp parameter | Meaning | Common arguments |
|---|---|---|
| `InputArray` | Read-only input | `Mat`, `UMat`, `MatExpr`, `Scalar`, `double`, or a supported `Vec` |
| `OutputArray` | Output that OpenCV may allocate or reallocate | `Mat` or `UMat` |
| `InputOutputArray` | Existing content may be read and then modified | `Mat` or `UMat` |

These are API roles, not alternative image containers. The pixels still belong to the `Mat` or `UMat` passed by the caller.

## Pass Mat directly

Although the signature of `Cv2.GaussianBlur` accepts `InputArray` and `OutputArray`, no explicit wrapper is needed:

```csharp
using OpenCvSharp;

using var source = Cv2.ImRead("input.jpg", ImreadModes.Color);
if (source.Empty())
{
    throw new InvalidOperationException("Could not read input.jpg.");
}

using var blurred = new Mat();
Cv2.GaussianBlur(
    source,
    blurred,
    new Size(5, 5),
    sigmaX: 1.2);
```

The current OpenCvSharp5 implementation converts `Mat` and `UMat` to stack-only proxy values without allocating a managed or native wrapper object. The proxy keeps the source object reachable for the duration of the native call. It does not own or dispose the source.

Explicit creation is mainly useful when writing a helper whose own signature preserves the OpenCV parameter roles:

```csharp
static void Blur(InputArray source, OutputArray destination)
{
    Cv2.GaussianBlur(
        source,
        destination,
        new Size(5, 5),
        sigmaX: 1.2);
}
```

`InputArray`, `OutputArray`, and `InputOutputArray` are `ref struct` types in OpenCvSharp5. They cannot be boxed, stored in ordinary class fields, captured by lambdas, or kept across an `await` or `yield` boundary. Pass them through short synchronous call chains instead of treating them as long-lived objects.

An optional `InputArray` whose value is `default` represents OpenCV's `noArray()`. Callers normally omit optional masks rather than constructing this value explicitly.

`InputArray.Create<T>` is not the same allocation-free path as passing an existing `Mat`. For an array, it creates a native `Mat` header over the managed storage without copying the elements and pins the array. For an `IEnumerable<T>`, it first materializes a new array and then creates the pinned matrix header.

The returned `InputArray` is a non-disposable `ref struct`. It keeps the temporary `Mat` reachable through the native call, but the caller cannot deterministically dispose that hidden matrix afterward, so its native header and array pin may remain until finalization. Prefer a dedicated `ReadOnlySpan<T>`, array, or collection overload when the OpenCvSharp method provides one, and avoid `InputArray.Create<T>` in a hot loop.

When repeated calls require an `InputArray`, own and reuse the hosting `Mat` explicitly:

```csharp
double[] values = [1.0, 2.0, 3.0, 4.0];
using var valuesMat = Mat.FromPixelData(
    rows: values.Length,
    cols: 1,
    type: MatType.CV_64FC1,
    data: values);

for (var iteration = 0; iteration < 100; iteration++)
{
    Scalar mean = Cv2.Mean(valuesMat);
    Console.WriteLine(mean.Val0);
}
```

`valuesMat` keeps `values` pinned until the matrix is disposed, and edits to either view are visible through the other.

## Understand output allocation

An empty destination `Mat` is idiomatic:

```csharp
using var grayscale = new Mat();
Cv2.CvtColor(
    source,
    grayscale,
    ColorConversionCodes.BGR2GRAY);
```

The native function creates the destination storage with the required size and type. If a destination already has compatible storage, many OpenCV functions reuse it; otherwise they reallocate it. The exact output contract belongs to the native function and is documented in the official OpenCV reference.

Reusing a destination is useful in a loop:

```csharp
using var capture = new VideoCapture("input.mp4");
using var frame = new Mat();
using var grayscale = new Mat();

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

    // Consume grayscale before the next iteration.
}
```

Do not keep a `Span<T>`, data pointer, or assumption about the destination buffer across a call that may reallocate that `Mat`.

## InputOutputArray is one read/write argument

`InputOutputArray` means that one argument carries data into the function and may be changed by it. Drawing functions are a simple example:

```csharp
using var canvas = new Mat(
    rows: 480,
    cols: 640,
    type: MatType.CV_8UC3,
    s: Scalar.Black);

Cv2.Line(
    canvas,
    new Point(20, 20),
    new Point(620, 460),
    Scalar.LimeGreen,
    thickness: 3);
```

Other examples include calibration parameters initialized with a prior estimate, masks updated by segmentation functions, and matrices filled with random values. Read the individual method documentation to determine whether the incoming contents are required or only the existing allocation is reused.

`InputOutputArray` is different from passing the same `Mat` as separate `src` and `dst` arguments. The former is part of the function signature. The latter creates aliasing between two parameters and is valid only when the native operation explicitly supports in-place execution.

## Use in-place processing only when documented

OpenCvSharp passes the same native `cv::Mat` when the same managed `Mat` is supplied as both input and output. OpenCvSharp does not add a temporary buffer to make unsupported aliasing safe.

OpenCV documents Gaussian filtering as supporting in-place operation:

```csharp
Cv2.GaussianBlur(
    source,
    source,
    new Size(5, 5),
    sigmaX: 1.2);
```

By contrast, geometric warp functions document that they cannot operate in-place. Use a separate destination:

```csharp
using var transform = Cv2.GetRotationMatrix2D(
    new Point2f(source.Width / 2f, source.Height / 2f),
    angle: 10,
    scale: 1);

using var rotated = new Mat();
Cv2.WarpAffine(
    source,
    rotated,
    transform,
    source.Size());
```

Use the following rule:

1. Check the native OpenCV reference for the exact function.
2. Use the same `Mat` only when the documentation explicitly permits in-place operation or defines the argument as input/output.
3. Prefer a separate destination when the output size, depth, or channel count changes.
4. Avoid partially overlapping source and destination regions unless the function explicitly supports that layout.

In-place processing can reduce one destination allocation, but it can also destroy data needed by later stages and make ownership harder to understand. Measure before using it as a general optimization.

## MatExpr inputs are different

Passing a `Mat` or `UMat` through an input proxy is allocation-free. Passing a `MatExpr` requires materializing the deferred expression before the native call:

```csharp
MatExpr expression = source * 0.5 + Scalar.All(20);

using var result = new Mat();
Cv2.Max(expression, 0, result);
```

Materialize an expression once with `ToMat()` when several later operations need the same result. Reusing the expression itself may evaluate it again.

## Common mistakes

- Do not call `Dispose` on a source `Mat` while a native operation is using it.
- Do not store an array proxy for later work; store the owning `Mat` instead.
- Do not assume that every function with separate input and output parameters supports the same object for both.
- Do not retain spans or pointers when the associated `Mat` may be disposed or reallocated.
- Do not assume a preallocated output forces OpenCV to keep its current size or type.

## Related guides

- [Mat Basics](mat-basics.md)
- [Copies, Native Memory, and Performance](memory-copy-and-performance.md)
- [Resource Management](resource-management.md)

## Official OpenCV references

- [Operations on arrays](https://docs.opencv.org/5.0/main_modules/core_array.html)
- [Image filtering](https://docs.opencv.org/5.0/main_modules/imgproc_filter.html)
- [Geometric image transformations](https://docs.opencv.org/5.0/main_modules/imgproc_transform.html)

## Related OpenCvSharp API

- [InputArray](xref:OpenCvSharp.InputArray)
- [OutputArray](xref:OpenCvSharp.OutputArray)
- [InputOutputArray](xref:OpenCvSharp.InputOutputArray)
- [Mat](xref:OpenCvSharp.Mat)
- [MatExpr](xref:OpenCvSharp.MatExpr)
