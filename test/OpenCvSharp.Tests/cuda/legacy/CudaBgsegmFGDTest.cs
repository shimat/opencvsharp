using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.legacy;

public class CudaBgsegmFGDTEst : CudaTestBase
{
    [Fact]
    public void BackgroundSubtractorFGD()
    {
        VerifyCudaSupport();

        try
        {
            using var fgd = OpenCvSharp.Cuda.BackgroundSubtractorFGD.Create();

            // FGD REQUIRES 3-channel images (BGR). It will crash if given 1-channel grayscale.
            using var cpuFrame = new Mat(100, 100, MatType.CV_8UC3, new Scalar(0, 0, 0));
            using var gpuFrame = new GpuMat();
            using var gpuFgMask = new GpuMat();

            // Frame 1: Train background
            gpuFrame.Upload(cpuFrame);
            fgd.Apply(gpuFrame, gpuFgMask, learningRate: 1.0);

            // Frame 2: Introduce foreground (A white square)
            Cv2.Rectangle(cpuFrame, new Rect(40, 40, 20, 20), new Scalar(255, 255, 255), -1);
            gpuFrame.Upload(cpuFrame);
            fgd.Apply(gpuFrame, gpuFgMask, learningRate: 0.0);

            // Assert
            using var cpuFgMask = new Mat();
            gpuFgMask.Download(cpuFgMask);

            Assert.False(cpuFgMask.Empty());
            // The output mask is always a 1-channel binary image (CV_8UC1)
            Assert.Equal(MatType.CV_8UC1, cpuFgMask.Type());

            // Background should be black (0)
            Assert.Equal(0, cpuFgMask.At<byte>(10, 10));
            // Foreground should be white (255)
            Assert.Equal(255, cpuFgMask.At<byte>(50, 50));
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            // Graceful exit if cudabgsegm is not compiled into the OpenCV binaries.
            Assert.Skip("The called functionality is disabled for current build or platform");
        }
    }

    [Fact]
    public void FGD_CustomParamsTest()
    {
        VerifyCudaSupport();

        try
        {
            // 1. Arrange: Define custom params
            var myParams = FGDParams.GetDefault();
            myParams.MinArea = 1f;

            // 2. Act
            using var fgd = OpenCvSharp.Cuda.BackgroundSubtractorFGD.Create(myParams);

            // FGD REQUIRES 3-channel images (BGR). It will crash if given 1-channel grayscale.
            using var cpuFrame = new Mat(100, 100, MatType.CV_8UC3, new Scalar(0, 0, 0));
            using var gpuFrame = new GpuMat();
            using var gpuFgMask = new GpuMat();

            // Frame 1: Train background
            for (int i = 0; i < 10; i++)
            {
                gpuFrame.Upload(cpuFrame);
                fgd.Apply(gpuFrame, gpuFgMask, learningRate: 1.0);
            }

            // Frame 2: Introduce foreground (A white square)
            Cv2.Rectangle(cpuFrame,  new Rect(40, 40, 20, 20), Scalar.White,  -1);

            gpuFrame.Upload(cpuFrame);

            fgd.Apply(gpuFrame, gpuFgMask, learningRate: 0.0);

            // Assert
            using var cpuFgMask = new Mat();
            gpuFgMask.Download(cpuFgMask);

            Assert.False(cpuFgMask.Empty());
            // The output mask is always a 1-channel binary image (CV_8UC1)
            Assert.Equal(MatType.CV_8UC1, cpuFgMask.Type());

            // Background should be black (0)
            Assert.Equal(0, cpuFgMask.At<byte>(10, 10));
            // Foreground should be white (255)
            Assert.True(cpuFgMask.At<byte>(50, 50) > 0);
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            // Graceful exit if cudabgsegm is not compiled into the OpenCV binaries.
            Assert.Skip("The called functionality is disabled for current build or platform");
        }
    }

    [Fact]
    public void GetForegroundRegions_Test()
    {
        VerifyCudaSupport();

        try
        {
            using var fgd = OpenCvSharp.Cuda.BackgroundSubtractorFGD.Create();

            // FGD REQUIRES 3-channel images (BGR).
            using var cpuFrame1 = new Mat(100, 100, MatType.CV_8UC3, new Scalar(0, 0, 0));
            using var cpuFrame2 = new Mat(100, 100, MatType.CV_8UC3, new Scalar(0, 0, 0));

            // Draw a square on Frame 2 to trigger a foreground detection
            Cv2.Rectangle(cpuFrame2, new Rect(30, 30, 40, 40), new Scalar(255, 255, 255), -1);

            using var gpuFrame = new GpuMat();
            using var gpuFgMask = new GpuMat();

            // Act: Train Background
            gpuFrame.Upload(cpuFrame1);
            fgd.Apply(gpuFrame, gpuFgMask, learningRate: 1.0);

            // Act: Detect Foreground
            gpuFrame.Upload(cpuFrame2);
            fgd.Apply(gpuFrame, gpuFgMask, learningRate: 0.0);

            // Act: Extract Regions
            Mat[] regions = fgd.GetForegroundRegions();

            // Assert
            Assert.NotNull(regions);
            // Depending on the internal FGD heuristic, there should be at least 1 region detected
            Assert.True(regions.Length > 0, "Expected to find at least one foreground region.");

            // Cleanup regions
            foreach (var region in regions)
            {
                Assert.False(region.Empty());
                region.Dispose();
            }
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            Assert.Skip("CUDA functionality not available");
        }
    }
}
