using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.imgproc;

public class CudaCornersDetectorTest : CudaTestBase
{
    [Fact]
    public void GoodFeaturesToTrack_DetectTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a black image with a white square
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        // Square from (30,30) to (70,70) -> 4 corners
        Cv2.Rectangle(cpuSrc, new Rect(30, 30, 40, 40), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuCorners = new GpuMat();

        // 2. Act
        using var detector = OpenCvSharp.Cuda.CornersDetector.Create(
      MatType.CV_8UC1,
      maxCorners: 100,
      qualityLevel: 0.01,
      minDistance: 1,
      blockSize: 3
  );

        detector.Detect(gpuSrc, gpuCorners);

        // Important: check BEFORE download
        Assert.False(gpuCorners.Empty());

        using var cpuCorners = new Mat();
        gpuCorners.Download(cpuCorners);

        Assert.Equal(MatType.CV_32FC2, cpuCorners.Type());

        // Count check
        int count = cpuCorners.Rows * cpuCorners.Cols;
        Assert.True(count >= 4);

        // Find top-left
        bool foundTopLeft = false;

        for (int r = 0; r < cpuCorners.Rows; r++)
        {
            for (int c = 0; c < cpuCorners.Cols; c++)
            {
                Vec2f pt = cpuCorners.At<Vec2f>(r, c);

                if (Math.Abs(pt.Item0 - 30) < 3 &&
                    Math.Abs(pt.Item1 - 30) < 3)
                {
                    foundTopLeft = true;
                }
            }
        }

        Assert.True(foundTopLeft, "Could not find the top-left corner.");
    }

}
