using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.imgproc;

public class CudaCornernessCriteriaTest : CudaTestBase
{
    [Fact]
    public void HarrisCorner_ComputeTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 black image with a 40x40 white square
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(cpuSrc, new Rect(30, 30, 40, 40), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act
        using var harris = OpenCvSharp.Cuda.CornernessCriteria.CreateHarrisCorner(MatType.CV_8UC1, blockSize: 3, ksize: 3, k: 0.04);
        harris.Compute(gpuSrc, gpuDst);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_32FC1, cpuDst.Type()); // Response map is always float

        // Check corner response at (30, 30). It should be a large positive value.
        float cornerResponse = cpuDst.At<float>(30, 30);
        Assert.True(cornerResponse > 0);

        // Check response in the middle of the square (flat area). It should be near 0.
        float flatResponse = cpuDst.At<byte>(50, 50);
        Assert.InRange(flatResponse, -0.1f, 0.1f);
    }

    [Fact]
    public void MinEigenVal_ComputeTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: 100x100 black image with a 40x40 white square
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Cv2.Rectangle(cpuSrc, new Rect(30, 30, 40, 40), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act
        using var criteria = OpenCvSharp.Cuda.CornernessCriteria.CreateMinEigenValCorner(
            MatType.CV_8UC1,
            blockSize: 3,
            ksize: 3);

        criteria.Compute(gpuSrc, gpuDst);

        // 3. Download and Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        Assert.Equal(MatType.CV_32FC1, cpuDst.Type());

        // A corner of the square (30, 30) should have a high positive eigenvalue score
        float cornerScore = cpuDst.At<float>(30, 30);
        Assert.True(cornerScore > 0, $"Expected positive score at corner, but got {cornerScore}");

        // A pixel in the middle of a flat white area should have a score near 0
        float flatScore = cpuDst.At<float>(50, 50);
        Assert.InRange(flatScore, -0.1f, 0.1f);
    }
}
