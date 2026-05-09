using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.stereo;

public class CudaDisparityBilateralFilterTest : CudaTestBase
{
    [Fact]
    public void CudaDisparityBilateralFilter()
    {
        VerifyCudaSupport();

        // Arrange: 
        // Disparity Map: 100x100 grayscale with a noisy patch
        using var cpuDisp = new Mat(100, 100, MatType.CV_8UC1, new Scalar(30));
        Cv2.Rectangle(cpuDisp, new Rect(40, 40, 20, 20), new Scalar(35), -1); // Subtle difference

        // Reference Image: Solid color
        using var cpuImg = new Mat(100, 100, MatType.CV_8UC3, new Scalar(100, 50, 200));

        using var gpuDisp = new GpuMat(); gpuDisp.Upload(cpuDisp);
        using var gpuImg = new GpuMat(); gpuImg.Upload(cpuImg);
        using var gpuDst = new GpuMat();

        // Create Filter
        using var filter = OpenCvSharp.Cuda.DisparityBilateralFilter.Create(ndisp: 64, radius: 3, iters: 1);

        // Act
        filter.Apply(gpuDisp, gpuImg, gpuDst);

        // Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(cpuDisp.Size(), cpuDst.Size());
        Assert.Equal(cpuDisp.Type(), cpuDst.Type());
    }

    [Fact]
    public void DisparityBilateralFilter_PropertiesTest()
    {
        VerifyCudaSupport();

        // 1. Create filter
        using var filter = OpenCvSharp.Cuda.DisparityBilateralFilter.Create(ndisp: 64, radius: 3, iters: 1);

        // 2. Test initial and modified values
        Assert.Equal(64, filter.NumDisparities);
        Assert.Equal(1, filter.NumIters);

        filter.NumDisparities = 128;
        filter.NumIters = 5;
        filter.EdgeThreshold = 2.5f;
        filter.MaxDiscThreshold = 1.2f;

        Assert.Equal(128, filter.NumDisparities);
        Assert.Equal(5, filter.NumIters);
        Assert.Equal(2.5f, filter.EdgeThreshold);
        Assert.Equal(1.2f, filter.MaxDiscThreshold);
    }

    [Fact]
    public void DisparityBilateralFilter_ExtendedPropertiesTest()
    {
        VerifyCudaSupport();

        // 1. Create filter with radius 3
        using var filter = OpenCvSharp. Cuda.DisparityBilateralFilter.Create(ndisp: 64, radius: 3, iters: 1);

        // 2. Test initial values
        Assert.Equal(3, filter.Radius);

        // 3. Modify and verify
        filter.Radius = 7;
        filter.SigmaRange = 15.5f;

        Assert.Equal(7, filter.Radius);
        Assert.Equal(15.5f, filter.SigmaRange);
    }
}
