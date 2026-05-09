using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaGpuMatTest : CudaTestBase
{
    [Fact]
    public void GpuMat_CudaPtr_Test()
    {
        VerifyCudaSupport();

        // Arrange
        using var gpuMat = new GpuMat(10, 10, MatType.CV_8UC1);

        // Act
        IntPtr ptr = gpuMat.CudaPtr;

        // Assert
        // CudaPtr should point to the same address as Data
        Assert.Equal(gpuMat.Data, ptr);
        Assert.NotEqual(IntPtr.Zero, ptr);
    }

    [Fact]
    public void GpuMat_UpdateContinuity_Test()
    {
        VerifyCudaSupport();

        using var gpuMat = new GpuMat(10, 10, MatType.CV_8UC1);

        // Act & Assert (Should not throw)
        var exception = Record.Exception(() => gpuMat.UpdateContinuityFlag());
        Assert.Null(exception);
    }

    [Fact]
    public void GpuMat_StaticAllocator_Test()
    {
        VerifyCudaSupport();

        // Act
        IntPtr def = GpuMat.DefaultAllocator();
        IntPtr std = GpuMat.GetStdAllocator();

        // Assert
        Assert.NotEqual(IntPtr.Zero, def);
        Assert.NotEqual(IntPtr.Zero, std);
    }

    [Fact]
    public void GpuMat_OutputArray_Overload_Test()
    {
        VerifyCudaSupport();

        using var src = new GpuMat(10, 10, MatType.CV_8UC1, new Scalar(100));
        using var dst = new GpuMat();

        // Act: Using the new OutputArray overload
        src.CopyTo(((OpenCvSharp.Cuda.OutputArray)dst));

        // Assert
        Assert.False(dst.Empty());
        Assert.Equal(10, dst.Rows);
    }
}
