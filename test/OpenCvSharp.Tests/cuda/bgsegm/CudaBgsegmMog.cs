using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.bgsegm;

public class CudaBgsegmMog : CudaTestBase
{
    [Fact]
    public void BackgroundSubtractorMOG()
    {
        VerifyCudaSupport();

        try
        {
            using var mog = OpenCvSharp.Cuda.BackgroundSubtractorMOG.Create();
            using var cpuFrame = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            using var gpuFrame = new GpuMat();
            using var gpuFgMask = new GpuMat();

            // Frame 1: Train background
            gpuFrame.Upload(cpuFrame);
            mog.Apply(gpuFrame, gpuFgMask, learningRate: 1.0);

            // Frame 2: Introduce foreground
            Cv2.Rectangle(cpuFrame, new Rect(40, 40, 20, 20), new Scalar(255), -1);
            gpuFrame.Upload(cpuFrame);
            mog.Apply(gpuFrame, gpuFgMask, learningRate: 0.0);

            // Assert
            using var cpuFgMask = new Mat();
            gpuFgMask.Download(cpuFgMask);

            Assert.False(cpuFgMask.Empty());
            Assert.Equal(0, cpuFgMask.At<byte>(10, 10)); // Background
            Assert.Equal(255, cpuFgMask.At<byte>(50, 50)); // Foreground
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            Assert.Skip("The called functionality is disabled for current build or platform");
        }
    }

    [Fact]
    public void MOG_PropertiesAndMethodsTest()
    {
        VerifyCudaSupport();

        try
        {
            // 1. Create Subtractor
            using var mog = OpenCvSharp.Cuda.BackgroundSubtractorMOG.Create();

            // 2. Test Setters and Getters
            mog.History = 300;
            Assert.Equal(300, mog.History);

            mog.NMixtures = 6;
            Assert.Equal(6, mog.NMixtures);

            mog.BackgroundRatio = 0.5;
            Assert.Equal(0.5, mog.BackgroundRatio);

            mog.NoiseSigma = 0.1;
            Assert.InRange(mog.NoiseSigma, 0.08, 0.11);

            // 3. Test Apply with Known Foreground Mask
            using var cpuFrame = new Mat(100, 100, MatType.CV_8UC1, new Scalar(100));
            using var gpuFrame = new GpuMat(); gpuFrame.Upload(cpuFrame);

            using var knownFgCpu = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(knownFgCpu, new Rect(10, 10, 20, 20), new Scalar(255), -1);
            using var knownFgGpu = new GpuMat(); knownFgGpu.Upload(knownFgCpu);

            using var gpuFgMask = new GpuMat();

            // Apply
            mog.Apply(gpuFrame, knownFgGpu, gpuFgMask, learningRate: 0.1);
            Assert.False(gpuFgMask.Empty());

            // 4. Test GetBackgroundImage
            using var gpuBgImage = new GpuMat();
            mog.GetBackgroundImage(gpuBgImage);
            Assert.False(gpuBgImage.Empty());
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            Assert.Skip("The called functionality is disabled for current build or platform");
        }
    }
}
