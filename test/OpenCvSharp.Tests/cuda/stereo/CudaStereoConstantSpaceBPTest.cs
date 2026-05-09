using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.stereo;

public class CudaStereoConstantSpaceBPTest : CudaTestBase
{
    [Fact]
    public void StereoConstantSpaceBP_ComputeTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create synthetic stereo pair
        // Left image: black with a white square
        using var leftCpu = new Mat(128, 128, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(leftCpu, new Rect(60, 60, 30, 30), new Scalar(255), -1);

        // Right image: shifted white square (disparity of 8 pixels)
        using var rightCpu = new Mat(128, 128, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(rightCpu, new Rect(52, 60, 30, 30), new Scalar(255), -1);

        using var leftGpu = new GpuMat(); leftGpu.Upload(leftCpu);
        using var rightGpu = new GpuMat(); rightGpu.Upload(rightCpu);
        using var disparityGpu = new GpuMat();

        // 2. Act
        using var stereo = OpenCvSharp.Cuda.StereoConstantSpaceBP.Create(ndisp: 128, iters: 8, levels: 4, nrPlane: 4);

        // Compute is inherited from StereoMatcher
        stereo.Compute(leftGpu, rightGpu, disparityGpu);

        // 3. Assert
        using var disparityCpu = new Mat();
        disparityGpu.Download(disparityCpu);

        Assert.False(disparityCpu.Empty());

        // Check pixel in the center of the square
        // CSBP typically outputs CV_16S or CV_32F disparity
        float dispValue = disparityCpu.At<float>(75, 75);

        // We expect a disparity value greater than 0
        Assert.True(dispValue > 0, $"Disparity should be positive, but was {dispValue}");
    }

    [Fact]
    public void StereoCSBP_PropertiesAndHeuristicTest()
    {
        VerifyCudaSupport();

        // 1. Test Static Heuristic
        OpenCvSharp. Cuda.StereoConstantSpaceBP.EstimateRecommendedParams(640, 480,
            out int ndisp, out int iters, out int levels, out int nrPlane);

        Assert.True(ndisp > 0);
        Assert.True(nrPlane > 0);

        // 2. Create instance
        using var stereo = OpenCvSharp.Cuda.StereoConstantSpaceBP.Create(ndisp, iters, levels, nrPlane);

        // 3. Test CSBP unique properties
        stereo.NrPlane = 8;
        Assert.Equal(8, stereo.NrPlane);

        stereo.UseLocalInitDataCost = true;
        Assert.True(stereo.UseLocalInitDataCost);
    }
}
