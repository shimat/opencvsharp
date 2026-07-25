# Resource Management

Many OpenCvSharp types wrap native OpenCV objects. Dispose objects that implement `IDisposable` as soon as they are no longer needed so that long-running applications do not retain native memory.

## Prefer using declarations

Use a `using` declaration for each `Mat` that owns a result:

```csharp
using var source = Cv2.ImRead("input.jpg", ImreadModes.Color);
using var blurred = new Mat();

Cv2.GaussianBlur(source, blurred, new Size(5, 5), 0);
Cv2.ImWrite("blurred.png", blurred);
```

The variables are disposed automatically at the end of the current scope.

## Dispose temporary results in loops

Objects created inside a loop should normally be disposed during each iteration:

```csharp
foreach (var fileName in fileNames)
{
    using var source = Cv2.ImRead(fileName);
    using var resized = new Mat();

    Cv2.Resize(source, resized, new Size(640, 480));
    Cv2.ImWrite(Path.ChangeExtension(fileName, ".resized.jpg"), resized);
}
```

Waiting for garbage collection is not a substitute for deterministic disposal. The garbage collector tracks managed memory and does not have an accurate view of the native memory held by a `Mat`.

## Mat expressions

OpenCvSharp arithmetic operators build a managed `MatExpr` expression. Intermediate expression nodes do not own native resources. Dispose the input matrices and the materialized result:

```csharp
using var source = Cv2.ImRead("input.jpg", ImreadModes.Grayscale);
using Mat adjusted = 255 - source * 0.8;

Cv2.ImWrite("adjusted.png", adjusted);
```

The intermediate `source * 0.8` expression does not need its own `using` declaration.

## Returning a Mat

Do not dispose a `Mat` before returning it to the caller. Transfer ownership explicitly through the method contract:

```csharp
static Mat LoadGrayscale(string fileName)
{
    using var source = Cv2.ImRead(fileName, ImreadModes.Color);
    var grayscale = new Mat();
    try
    {
        Cv2.CvtColor(source, grayscale, ColorConversionCodes.BGR2GRAY);
        return grayscale;
    }
    catch
    {
        grayscale.Dispose();
        throw;
    }
}

using var image = LoadGrayscale("input.jpg");
```

The caller owns and disposes the returned `Mat`. The method disposes the result itself if an exception occurs before ownership can be transferred to the caller.

## Windows and UI objects

`Window` and other OpenCvSharp wrappers that implement `IDisposable` follow the same rule. Scope them with `using` rather than relying on finalization.

## Related API

- [Mat](xref:OpenCvSharp.Mat)
- [MatExpr](xref:OpenCvSharp.MatExpr)
- [Cv2](xref:OpenCvSharp.Cv2)
