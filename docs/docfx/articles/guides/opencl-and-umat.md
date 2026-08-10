# OpenCL Acceleration with UMat

OpenCvSharp can use OpenCV's Transparent API (T-API) through `UMat`. When OpenCL is available and an operation has an OpenCL implementation, passing `UMat` inputs and outputs allows OpenCV to select that implementation without changing the `Cv2` method being called.

OpenCL acceleration is not the same as CUDA support. OpenCvSharp does not expose OpenCV's CUDA modules, and `UMat` uses OpenCL rather than CUDA.

## Treat acceleration as an execution choice, not a guarantee

Using `UMat` does not guarantee that an operation runs on a GPU or that it is faster than `Mat`:

- The operating system must provide a working OpenCL runtime and device driver.
- OpenCV must have an OpenCL implementation for the operation, image type, and parameters.
- OpenCV may reject an OpenCL path through its runtime performance checks and fall back to the CPU.
- Kernel compilation, host-device transfers, and synchronization can outweigh the benefit for small images or short pipelines.
- Performance varies by operation, device, and driver. An optimization that performs well on one vendor's device may behave differently on another.

Measure the complete production-shaped pipeline instead of assuming that replacing `Mat` with `UMat` will improve it.

## Check availability and the current state

Use `Cv2.Ocl` to inspect and control OpenCL use:

```csharp
Console.WriteLine($"OpenCL available: {Cv2.Ocl.HaveOpenCL()}");
Console.WriteLine($"OpenCL enabled:   {Cv2.Ocl.UseOpenCL()}");

Cv2.Ocl.SetUseOpenCL(true);
Console.WriteLine($"OpenCL enabled:   {Cv2.Ocl.UseOpenCL()}");
```

These methods answer different questions:

- `HaveOpenCL()` reports whether OpenCV can find an OpenCL runtime with at least one platform.
- `UseOpenCL()` reports whether OpenCL is currently enabled for the calling thread.
- `SetUseOpenCL(bool)` enables or disables OpenCL use for the calling thread.

An available and enabled runtime still does not prove that a particular operation used OpenCL. OpenCV can fall back to another implementation for that call.

## Inspect platforms and devices

`GetPlatformsInfo()` returns read-only snapshots of the OpenCL platforms and devices visible to OpenCV. It returns an empty list when no runtime is available.

```csharp
foreach (var platform in Cv2.Ocl.GetPlatformsInfo())
{
    Console.WriteLine(
        $"Platform: {platform.Name} ({platform.Vendor}, {platform.Version})");

    foreach (var device in platform.Devices)
    {
        Console.WriteLine($"  Device: {device.Name}");
        Console.WriteLine($"  Type:   {device.Type}");
        Console.WriteLine($"  OpenCL: {device.OpenCLVersion}");
        Console.WriteLine($"  Driver: {device.DriverVersion}");
        Console.WriteLine($"  Memory: {device.GlobalMemorySize} bytes");
    }
}
```

The returned objects contain diagnostic information. They do not expose or own native OpenCL platform, device, context, or queue handles, and they cannot be used to select a device.

## Keep a pipeline in UMat

OpenCL is most useful when several supported operations can run while the data remains in `UMat` storage:

```csharp
using var source = new UMat(1080, 1920, MatType.CV_8UC3);
using var blurred = new UMat();
using var hsv = new UMat();

Cv2.GaussianBlur(source, blurred, new Size(5, 5), 0);
Cv2.CvtColor(blurred, hsv, ColorConversionCodes.BGR2HSV);
```

Converting between `Mat` and `UMat`, accessing pixels on the CPU, or calling `UMat.GetMat()` can introduce synchronization and host-device transfers. Frequent transitions can cost more than the accelerated operations save.

Use `GetMat(AccessFlag.READ)` when the CPU genuinely needs the result, not merely to make an asynchronous benchmark wait.

## Benchmark queued work correctly

OpenCL commands may be queued asynchronously. Measuring only the calls that enqueue work can produce unrealistically short results. Warm up the operation to exclude one-time kernel compilation, then call `Finish()` at the measurement boundaries:

```csharp
static TimeSpan MeasureOpenCL(Action operation, int iterations)
{
    operation();
    Cv2.Ocl.Finish(); // Complete warm-up and kernel compilation.

    var stopwatch = Stopwatch.StartNew();
    for (var i = 0; i < iterations; i++)
    {
        operation();
    }

    Cv2.Ocl.Finish(); // Include completion of all queued operations.
    stopwatch.Stop();
    return stopwatch.Elapsed;
}
```

Run the operation and `Finish()` on the same thread because OpenCL enablement and the default execution context are thread-specific.

Do not call `Finish()` after every operation in a normal pipeline. It blocks the calling thread and prevents OpenCV from overlapping or batching queued work. It is primarily useful for benchmarks and genuine synchronization boundaries.

Compare equivalent `Mat` and `UMat` pipelines with the same source data, output consumption, dimensions, types, warm-up, and build configuration. Use Release builds, and report both latency and throughput.

## Interpret OpenCL build information

`Cv2.GetBuildInformation()` reports whether OpenCV was built with OpenCL support. An include path containing a version such as `opencl/1.2` identifies the OpenCL headers used to compile OpenCV; it does not cap the version reported by the installed runtime or device.

OpenCV loads the OpenCL runtime at execution time. A device can therefore report OpenCL 3.0 through `GetPlatformsInfo()` even when the build information mentions 1.2 headers. Rebuilding OpenCvSharp with newer headers is not, by itself, expected to make an image-processing operation faster.

## Diagnose unexpected performance

When reporting an OpenCL performance problem, include:

- OpenCvSharp managed and runtime package versions.
- Operating system and architecture.
- Release or Debug build configuration.
- `HaveOpenCL()` and `UseOpenCL()` results.
- Platform, device, OpenCL, and driver values from `GetPlatformsInfo()`.
- The OpenCL section of `Cv2.GetBuildInformation()`.
- Equivalent, warmed-up `Mat` and synchronized `UMat` measurements.
- Image dimensions, `MatType`, parameters, and iteration count.

OpenCvSharp forwards operations such as `Cv2.GaussianBlur` to OpenCV. Device-specific OpenCL kernels, performance guards, and CPU fallbacks are implemented by upstream OpenCV. Once synchronization and transfer costs have been accounted for, an operation-specific regression will usually need to be reproduced and investigated upstream.

## Related guides

- [Copies, Native Memory, and Performance](memory-copy-and-performance.md)
- [InputArray, OutputArray, and In-place Processing](input-output-arrays-and-in-place.md)
- [Resource Management](resource-management.md)

## Official OpenCV reference

- [OpenCV configuration options: OpenCL support](https://docs.opencv.org/5.0/tutorials/introduction/config_reference/config_reference.html#opencl-support)

## Related OpenCvSharp API

- [UMat](xref:OpenCvSharp.UMat)
- [Cv2.Ocl](xref:OpenCvSharp.Cv2.Ocl)
- [OclPlatformInfo](xref:OpenCvSharp.OclPlatformInfo)
- [OclDeviceInfo](xref:OpenCvSharp.OclDeviceInfo)
