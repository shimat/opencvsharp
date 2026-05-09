using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OpenCvSharp.Cuda;

namespace OpenCvSharp.Tests.Cuda;

public class CudaStreamTest : CudaTestBase
{
    [Fact]
    public void WrapStream_Test()
    {
        VerifyCudaSupport();

        // 1. Create an original OpenCV Stream
        using var originalStream = new OpenCvSharp.Cuda.Stream();

        // 2. Get the raw cudaStream_t handle (IntPtr)
        // Note: This requires that you have wrapped cv::cuda::StreamAccessor::getStream
        IntPtr rawHandle = originalStream.Handle;

        Assert.NotEqual(IntPtr.Zero, rawHandle);

        // 3. Act: Wrap the raw handle in a NEW OpenCV Stream object
        using var wrappedStream = Cv2.Cuda.WrapStream(rawHandle);

        // 4. Assert
        Assert.NotNull(wrappedStream);
        Assert.NotEqual(IntPtr.Zero, wrappedStream.CvPtr);

        // Verify they both point to the same underlying CUDA handle
        Assert.Equal(originalStream.Handle, wrappedStream.Handle);

        // 5. Verify usage: Perform an async operation
        using var gpuSrc = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(100));
        using var gpuDst = new GpuMat();

        // Should execute on the wrapped stream without error
        Cv2.Cuda.BitwiseNot(gpuSrc, gpuDst, null, wrappedStream);
        wrappedStream.WaitForCompletion();

        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);
        byte expected = (byte)(255 - 100);
        Assert.Equal(expected, cpuDst.At<byte>(0, 0));
    }

    [Fact]
    public void StreamExpansionTest()
    {
        VerifyCudaSupport();

        // 1. Test Constructor with flags (1 = Non-Blocking)
        using var streamA = new OpenCvSharp.Cuda.Stream();
        using var streamB = new OpenCvSharp.Cuda.Stream();
        Assert.True(streamA.IsNotNull);

        // 2. Test Handle accessor
        IntPtr rawHandle = streamA.Handle;
        Assert.NotEqual(IntPtr.Zero, rawHandle);

        // 3. Test WaitEvent Cross-Stream Synchronization
        using var ev = new OpenCvSharp.Cuda.Event();

        // Have Stream A do a dummy task, then drop a marker (Record Event)
        using var gpuSrc = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(255));
        using var gpuDst = new GpuMat();

        Cv2.Cuda.BitwiseNot(gpuSrc, gpuDst, null, streamA);
        ev.Record(streamA); // Drops event marker exactly here in Stream A's queue

        // Tell Stream B to wait until the GPU reaches the marker in Stream A
        var exception = Record.Exception(() => streamB.WaitEvent(ev));
        Assert.Null(exception); // Proves the binding executes safely

        // Wait for the whole GPU pipeline to finish safely
        streamA.WaitForCompletion();
        streamB.WaitForCompletion();
    }
}
