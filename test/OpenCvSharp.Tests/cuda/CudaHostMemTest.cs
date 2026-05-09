using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaHostMemTest : CudaTestBase
{
    [Fact]
    public void HostMem_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create Page-Locked HostMem for general testing
        using var hostMemPageLocked = new HostMem(10, 10, MatType.CV_8UC1, HostMemAllocType.PageLocked);

        // 2. Act & Assert Properties
        Assert.False(hostMemPageLocked.Empty());
        Assert.Equal(10, hostMemPageLocked.Size().Width);
        Assert.Equal(MatType.CV_8UC1, hostMemPageLocked.Type());

        // 3. Act: Create a CPU Mat Header 
        using var cpuView = hostMemPageLocked.CreateMatHeader();
        cpuView.SetTo(new Scalar(255));
        Assert.Equal(255, cpuView.At<byte>(0, 0));

        // 4. Test Zero-Copy / Shared memory (if supported by hardware)
        try
        {
            // Must use 'Shared' to allow mapping directly to a GpuMat header
            using var hostMemShared = new HostMem(10, 10, MatType.CV_8UC1, HostMemAllocType.Shared);

            using var cpuViewShared = hostMemShared.CreateMatHeader();
            cpuViewShared.SetTo(new Scalar(255));

            // Create GPU Mat Header (This will map the CPU memory directly into the GPU address space)
            using var gpuView = hostMemShared.CreateGpuMatHeader();

            Assert.False(gpuView.Empty());

            // 5. Verify the value written via CPU is visible to GPU operations
            using var gpuDst = new GpuMat();
            Cv2.Cuda.BitwiseNot(gpuView, gpuDst); // Not 255 = 0

            using var resultCpu = new Mat();
            gpuDst.Download(resultCpu);

            Assert.Equal(0, resultCpu.At<byte>(0, 0));
        }
        catch (OpenCVException ex) when (ex.Message.Contains("alloc_type == SHARED"))
        {
            // If the hardware/driver doesn't fully support Shared memory mapping,
            // OpenCV falls back and this assertion fails. This is an expected environmental limitation.
            Assert.Skip("Hardware does not support Shared memory mapping to GpuMat headers.");
        }
    }
}
