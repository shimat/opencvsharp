using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.stereo;

public class CudaStereoBeliefPropagationTest : CudaTestBase
{
    [Fact]
    public void StereoBeliefPropagation_ComputeTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a synthetic stereo pair
        // Left image: black with a white square at (40, 40)
        using var leftCpu = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(leftCpu, new Rect(40, 40, 20, 20), new Scalar(255), -1);

        // Right image: black with the white square shifted to (35, 40) -> 5px disparity
        using var rightCpu = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(rightCpu, new Rect(35, 40, 20, 20), new Scalar(255), -1);

        using var leftGpu = new GpuMat(); leftGpu.Upload(leftCpu);
        using var rightGpu = new GpuMat(); rightGpu.Upload(rightCpu);
        using var disparityGpu = new GpuMat();

        // 2. Act: Create and compute
        using var stereo = OpenCvSharp.Cuda.StereoBeliefPropagation.Create(ndisp: 64, iters: 5, levels: 5);

        // .Compute is inherited from StereoMatcher
        stereo.Compute(leftGpu, rightGpu, disparityGpu);

        // 3. Assert
        using var disparityCpu = new Mat();
        disparityGpu.Download(disparityCpu);

        Assert.False(disparityCpu.Empty());

        // Belief Propagation typically outputs CV_16S or CV_32F disparity
        // Check a pixel inside the square area
        float dispValue = disparityCpu.At<float>(50, 50);
        Assert.True(dispValue > 0, "Disparity should be detected for the shifted square.");
    }

    [Fact]
    public void StereoBP_PropertiesAndHeuristicTest()
    {
        VerifyCudaSupport();

        // 1. Test Static Heuristic
        OpenCvSharp.Cuda.StereoBeliefPropagation.EstimateRecommendedParams(640, 480, out int ndisp, out int iters, out int levels);
        Assert.True(ndisp > 0);
        Assert.True(iters > 0);
        Assert.True(levels > 0);

        // 2. Create and Test Properties
        using var stereo = OpenCvSharp.Cuda.StereoBeliefPropagation.Create(ndisp, iters, levels);

        stereo.DataWeight = 0.08f;
        Assert.Equal(0.08f, stereo.DataWeight);

        stereo.MaxDiscTerm = 2.0;
        Assert.Equal(2.0, stereo.MaxDiscTerm);

        // Default msgType is CV_32F
        Assert.Equal(MatType.CV_32F, stereo.MsgType);
    }
}
