using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaCoreTest : CudaTestBase
{

    [Fact]
    public void ConvertFp16Test()
    {
        VerifyCudaSupport();

        // Arrange: 32-bit float (CV_32FC1)
        using var cpuSrc = new Mat(3, 3, MatType.CV_32FC1, new Scalar(3.14f));
        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);

        // Act
        using var gpuDst = new GpuMat();
        
        Cv2.Cuda.ConvertFp16(gpuSrc, gpuDst);
        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());

        Assert.Equal(MatType.CV_16SC1, cpuDst.Type());
        Assert.Equal(3, cpuDst.Rows);
        Assert.Equal(3, cpuDst.Cols);
    }

    [Fact]
    public void EnsureSizeIsEnough_Test()
    {
        VerifyCudaSupport();

        // 1. Start with an empty GpuMat
        using var gpuMat = new GpuMat();
        Assert.True(gpuMat.Empty());

        // 2. Ensure it is 100x100
        Cv2.Cuda.EnsureSizeIsEnough(100, 100, MatType.CV_8UC1, gpuMat);

        Assert.False(gpuMat.Empty());
        Assert.Equal(100, gpuMat.Rows);
        Assert.Equal(100, gpuMat.Cols);
        Assert.Equal(MatType.CV_8UC1, gpuMat.Type());

        // 3. Ensure it is 200x200
        // This will trigger a reallocation
        Cv2.Cuda.EnsureSizeIsEnough(200, 200, MatType.CV_8UC1, gpuMat);

        Assert.Equal(200, gpuMat.Rows);
        Assert.Equal(200, gpuMat.Cols);

        // 4. Call it again with the same 200x200 size
        // This should do nothing (no reallocation) and remain 200x200
        Cv2.Cuda.EnsureSizeIsEnough(200, 200, MatType.CV_8UC1, gpuMat);

        Assert.Equal(200, gpuMat.Rows);
    }

    [Fact]
    public void PageLockedMemory_Test()
    {
        VerifyCudaSupport();

        // 1. Create a large Mat (large enough to benefit from pinning)
        using var cpuMat = new Mat(2000, 2000, MatType.CV_8UC3, new Scalar(0, 255, 0));
        using var gpuMat = new GpuMat();

        // 2. Register the memory as Page-Locked (Pinned)
        Cv2.Cuda.RegisterPageLocked(cpuMat);

        // 3. Perform the upload (this will now use DMA and be faster)
        gpuMat.Upload(cpuMat);

        // 4. Perform a download
        gpuMat.Download(cpuMat);

        // 5. Unregister to return memory to normal OS management
        Cv2.Cuda.UnregisterPageLocked(cpuMat);

        // Assertions
        Assert.False(gpuMat.Empty());
        Assert.Equal(2000, gpuMat.Rows);
        Assert.Equal(255, cpuMat.At<Vec3b>(0, 0).Item1);
    }

    [Fact]
    public void SetBufferPool_SetupTest()
    {
        VerifyCudaSupport();

        // Get current device
        int deviceId = Cv2.Cuda.GetDevice();

        // Act & Assert
        var exception = Record.Exception(() =>
        {
            // Enable the pool
            Cv2.Cuda.SetBufferPoolUsage(true);

            // Configure: 10MB per stack, 5 stacks total
            Cv2.Cuda.SetBufferPoolConfig(deviceId, 10 * 1024 * 1024, 5);
        });

        Assert.Null(exception);

        // Clean up: switch back to default (optional)
        Cv2.Cuda.SetBufferPoolUsage(false);
    }

    [Fact]
    public void CreateGpuMatFromCudaMemory_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a GpuMat and fill it with data to act as "External Memory"
        using var originalGpu = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(123));

        // Get the raw device pointer and the step (row pitch)
        IntPtr rawPtr = originalGpu.Data;
        ulong step = (ulong)originalGpu.Step();

        // 2. Act: Wrap the raw pointer in a NEW GpuMat header
        using var wrappedGpu = Cv2.Cuda.CreateGpuMatFromCudaMemory(
            10, 10, MatType.CV_8UC1, rawPtr, step);

        // 3. Assert
        Assert.False(wrappedGpu.Empty());
        Assert.Equal(10, wrappedGpu.Rows);
        Assert.Equal(originalGpu.Data, wrappedGpu.Data); // They should point to the same memory

        // Verify the data is correct through the wrapper
        using var cpuCheck = new Mat();
        wrappedGpu.Download(cpuCheck);
        Assert.Equal(123, cpuCheck.At<byte>(0, 0));

        // 4. Verify shared memory: Modify original, check wrapper
        originalGpu.SetTo(new Scalar(200));
        wrappedGpu.Download(cpuCheck);
        Assert.Equal(200, cpuCheck.At<byte>(0, 0));
    }
}
