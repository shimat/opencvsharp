using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.stereo;

public class CudaStereoSGMTest : CudaTestBase
{
    [Fact]
    public void StereoSGM_ComputeTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create synthetic stereo pair (128x128)
        using var leftCpu = new Mat(128, 128, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(leftCpu, new Rect(60, 60, 30, 30), new Scalar(255), -1);

        // Shift square by 10 pixels to the left in the right image
        using var rightCpu = new Mat(128, 128, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(rightCpu, new Rect(50, 60, 30, 30), new Scalar(255), -1);

        using var leftGpu = new GpuMat(); leftGpu.Upload(leftCpu);
        using var rightGpu = new GpuMat(); rightGpu.Upload(rightCpu);
        using var disparityGpu = new GpuMat();

        // 2. Act
        // numDisparities must be divisible by 16
        using var sgm = OpenCvSharp.Cuda.StereoSGM.Create(minDisparity: 0, numDisparities: 64);
        sgm.Compute(leftGpu, rightGpu, disparityGpu);

        // 3. Assert
        using var disparityCpu = new Mat();
        disparityGpu.Download(disparityCpu);

        Assert.False(disparityCpu.Empty(), "Disparity map should not be empty.");

        // SGM output is usually CV_16S (signed short) or CV_8U 
        // depending on implementation, but typically CV_16S.
        // Check a pixel in the center of the object.
        short val = disparityCpu.At<short>(75, 75);
        Assert.True(val > 0, $"Expected positive disparity, but got {val}");
    }
}
