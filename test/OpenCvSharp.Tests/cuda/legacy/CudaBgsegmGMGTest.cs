using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.legacy;

public class CudaBgsegmGMGTest : CudaTestBase
{
    [Fact]
    public void BackgroundSubtractorGMG()
    {
        VerifyCudaSupport();

        try
        {
            // 1. Create GMG with exactly 1 initialization frame so it activates immediately.
            using var gmg = OpenCvSharp.Cuda.BackgroundSubtractorGMG.Create(initializationFrames: 1);

            using var cpuFrame = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            using var gpuFrame = new GpuMat();
            using var gpuFgMask = new GpuMat();

            // 2. FRAME 1: Pure black background (Initialization phase)
            gpuFrame.Upload(cpuFrame);

            // Using our Stream overload (stream = null) 30 because we need to train our model
            for (int i = 0; i < 30; i++)
            {
                gmg.Apply(gpuFrame, gpuFgMask, learningRate: 0.1);
            }

            // 3. FRAME 2: Introduce a moving object (white square)
            Cv2.Rectangle(cpuFrame, new Rect(40, 40, 20, 20), new Scalar(255), -1);
            gpuFrame.Upload(cpuFrame);

            // Apply frame 2 to extract the foreground
            gmg.Apply(gpuFrame, gpuFgMask, learningRate: 0.0);

            // 4. Download and Assert
            using var cpuFgMask = new Mat();
            gpuFgMask.Download(cpuFgMask);

            Assert.False(cpuFgMask.Empty(), "Foreground mask should not be empty.");
            Assert.Equal(MatType.CV_8UC1, cpuFgMask.Type());

            // Assert that the static background pixel is dark (0)
            Assert.Equal(0, cpuFgMask.At<byte>(10, 10));

            // Assert that the moving white square pixel is bright (255)
            Assert.Equal(255, cpuFgMask.At<byte>(50, 50));
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            // Graceful exit: cudabgsegm is an extra module and not always compiled 
            // into all OpenCV distribution binaries.
            Assert.Skip("The called functionality is disabled for current build or platform");
        }
    }

    [Fact]
    public void GMG_PropertiesAndMaskTest()
    {
        VerifyCudaSupport();

        try
        {
            // 1. Create Subtractor
            using var gmg = OpenCvSharp.Cuda.BackgroundSubtractorGMG.Create();

            // 2. Test Setters and Getters
            gmg.NumFrames = 50;
            Assert.Equal(50, gmg.NumFrames);

            gmg.DecisionThreshold = 0.5;
            Assert.Equal(0.5, gmg.DecisionThreshold);

            gmg.UpdateBackgroundModel = false;
            Assert.False(gmg.UpdateBackgroundModel);

            // 3. Test Apply with Known Foreground Mask
            using var cpuFrame = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            using var gpuFrame = new GpuMat(); gpuFrame.Upload(cpuFrame);

            using var knownFgCpu = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(knownFgCpu, new Rect(10, 10, 20, 20), new Scalar(255), -1);
            using var knownFgGpu = new GpuMat(); knownFgGpu.Upload(knownFgCpu);

            using var gpuFgMask = new GpuMat();

            // Apply
            gmg.Apply(gpuFrame, knownFgGpu, gpuFgMask, learningRate: 0.1);

            // Assert
            Assert.False(gpuFgMask.Empty());
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            Assert.Skip("CUDA functionality not available");
        }
    }
}
