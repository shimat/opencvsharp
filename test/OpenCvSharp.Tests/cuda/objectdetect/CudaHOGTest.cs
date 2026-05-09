using System;
using Xunit;
using OpenCvSharp;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;

namespace OpenCvSharp.Tests.Cuda.objdetect;

public class CudaHOGTest : CudaTestBase
{
    [Fact]
    public void HOG_ComputeTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Simple 64x128 image (default HOG window size)
        using var cpuSrc = new Mat(128, 64, MatType.CV_8UC1, new Scalar(100));
        Cv2.Rectangle(cpuSrc, new Rect(10, 10, 20, 40), new Scalar(200), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuDst = new GpuMat();

        // 2. Act
        using var hog = OpenCvSharp.Cuda.HOG.Create();
        hog.Compute(gpuSrc, gpuDst);

        // 3. Assert
        using var cpuDst = new Mat();
        gpuDst.Download(cpuDst);

        Assert.False(cpuDst.Empty());
        // HOG Compute returns a dense feature map of type CV_32FC1 or CV_32FC4 depending on blocks
        Assert.True(cpuDst.Cols > 0 && cpuDst.Rows > 0);
    }


    [Fact]
    public void HOG_Properties_And_SVM_Test()
    {
        VerifyCudaSupport();

        // 1. Create HOG instance
        using var hog = OpenCvSharp.Cuda.HOG.Create();

        // 2. Test Setters/Getters
        hog.GroupThreshold = 2;
        Assert.Equal(2, hog.GroupThreshold);

        hog.HitThreshold = 0.5;
        Assert.Equal(0.5, hog.HitThreshold);

        hog.GammaCorrection = true;
        Assert.True(hog.GammaCorrection);

        // 3. Verify Read-Only memory properties
        Assert.True(hog.DescriptorSize > 0);
        Assert.True(hog.BlockHistogramSize > 0);

        // 4. Test People Detector loading
        // Grab the pre-trained vector from OpenCV
        using var detector = hog.GetDefaultPeopleDetector();
        Assert.False(detector.Empty());

        // Assign it back to the HOG instance to verify SetSVMDetector works
        var exception = Record.Exception(() => hog.SetSVMDetector(detector));
        Assert.Null(exception);
    }

    [Fact]
    public void HOG_DescriptorFormat_Test()
    {
        VerifyCudaSupport();

        using var hog = OpenCvSharp.Cuda.HOG.Create();

        // Default is usually ColByCol (0)
        Assert.Equal(HOGDescriptorFormat.ColByCol, hog.DescriptorFormat);

        // Change to RowByRow
        hog.DescriptorFormat = HOGDescriptorFormat.RowByRow;
        Assert.Equal(HOGDescriptorFormat.RowByRow, hog.DescriptorFormat);
    }
}
