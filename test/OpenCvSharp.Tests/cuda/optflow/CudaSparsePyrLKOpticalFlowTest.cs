using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.optflow;

public class CudaSparsePyrLKOpticalFlowTest : CudaTestBase
{
    [Fact]
    public void SparsePyrLK_PropertiesAndCalcTest()
    {
        VerifyCudaSupport();

        try
        {
            // 1. Arrange
            using var lk = OpenCvSharp.Cuda.SparsePyrLKOpticalFlow.Create();
            lk.MaxLevel = 5;
            lk.NumIters = 25;
            lk.WinSize = new Size(15, 15);

            Assert.Equal(5, lk.MaxLevel);
            Assert.Equal(25, lk.NumIters);
            Assert.Equal(new Size(15, 15), lk.WinSize);

            // 2. Prepare test data
            using var cpu1 = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(cpu1, new Rect(40, 40, 20, 20), new Scalar(255), -1);

            using var cpu2 = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
            Cv2.Rectangle(cpu2, new Rect(45, 42, 20, 20), new Scalar(255), -1); // Moved +5, +2

            using var gpu1 = new GpuMat(); gpu1.Upload(cpu1);
            using var gpu2 = new GpuMat(); gpu2.Upload(cpu2);

            // Define a point to track: The top-left CORNER of the square (40, 40).
            // KLT requires strong gradients (corners) to track successfully.
            float[] pointData = { 40.0f, 40.0f };
            using var cpuPts = Mat.FromPixelData(1, 1, MatType.CV_32FC2, pointData);

            using var gpuPtsPrev = new GpuMat(); gpuPtsPrev.Upload(cpuPts);
            using var gpuPtsNext = new GpuMat();
            using var gpuStatus = new GpuMat();

            // 3. Act
            lk.Calc(gpu1, gpu2, gpuPtsPrev, gpuPtsNext, gpuStatus);

            // 4. Assert
            using var cpuPtsNext = new Mat();
            gpuPtsNext.Download(cpuPtsNext);
            using var cpuStatus = new Mat();
            gpuStatus.Download(cpuStatus);

            // Status should be 1 (successfully tracked)
            Assert.Equal(1, cpuStatus.At<byte>(0));

            Point2f moved = cpuPtsNext.At<Point2f>(0);

            // Original corner (40, 40) + motion (5, 2) = (45, 42)
            Assert.InRange(moved.X, 44.5f, 45.5f);
            Assert.InRange(moved.Y, 41.5f, 42.5f);
        }
        catch (OpenCVException ex) when (ex.Message.Contains("disabled") || ex.Message.Contains("Not Implemented"))
        {
            Assert.Skip(ex.Message);
        }
    }
}
