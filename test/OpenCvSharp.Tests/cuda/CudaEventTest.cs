using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaEventTest : CudaTestBase
{
    [Fact]
    public void Event_Timing_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange
        using var start = new OpenCvSharp.Cuda.Event();
        using var end = new OpenCvSharp.Cuda.Event();
        using var stream = new OpenCvSharp.Cuda.Stream();

        using var gpuSrc = new GpuMat(2000, 2000, MatType.CV_32FC1, new Scalar(1.0));
        using var gpuDst = new GpuMat();

        // 2. Act
        start.Record(stream);

        // Do some heavy lifting on the GPU
        Cv2.Cuda.Exp(gpuSrc, gpuDst, stream);
        Cv2.Cuda.Log(gpuDst, gpuDst, stream);

        end.Record(stream);

        // Wait for the end event to be reached
        end.WaitForCompletion();

        // 3. Assert
        float ms = OpenCvSharp.Cuda.Event.ElapsedTime(start, end);

        // Time should be a positive number of milliseconds
        Assert.True(ms > 0);
        Console.WriteLine($"GPU Execution took: {ms} ms");
    }

    [Fact]
    public void Event_Accessor_Test()
    {
        VerifyCudaSupport();

        // 1. Create a standard OpenCV Event
        using var originalEvent = new OpenCvSharp.Cuda.Event();

        // 2. Extract the raw hardware handle
        IntPtr rawHandle = originalEvent.Handle;
        Assert.NotEqual(IntPtr.Zero, rawHandle);

        // 3. Wrap it back into a new object
        using var wrappedEvent = OpenCvSharp.Cuda.Event.WrapEvent(rawHandle);

        // 4. Assert
        Assert.NotNull(wrappedEvent);
        Assert.Equal(originalEvent.Handle, wrappedEvent.Handle);

        // 5. Verify usage (Record in a stream)
        using var stream = new OpenCvSharp.Cuda.Stream();
        var exception = Record.Exception(() => wrappedEvent.Record(stream));
        Assert.Null(exception);
    }
}
