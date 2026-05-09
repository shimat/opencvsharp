using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class GpuDataTest : CudaTestBase
{
    [Fact]
    public void GpuData_Allocation_Test()
    {
        VerifyCudaSupport();

        // 1. Act: Allocate 1KB of raw VRAM
        ulong size = 1024 ;
        using var gpuData = new GpuData(size);

        // 2. Assert
        Assert.NotEqual(IntPtr.Zero, gpuData.CvPtr);
        Assert.NotEqual(IntPtr.Zero, gpuData.Data);
        Assert.Equal(size, gpuData.Size);
    }
}
