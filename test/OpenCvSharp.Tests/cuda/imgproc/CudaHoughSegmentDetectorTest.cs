using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.imgproc;

public class CudaHoughSegmentDetectorTest : CudaTestBase
{
    [Fact]
    public void HoughSegments_DetectTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 100x100 black image and draw a white diagonal segment
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));
        Point p1 = new Point(10, 10);
        Point p2 = new Point(80, 80);
        Cv2.Line(cpuSrc, p1, p2, new Scalar(255), 3);

        using var cpuEdges = new Mat();
        Cv2.Canny(cpuSrc, cpuEdges, 50, 150);



        using var gpuSrc = new GpuMat();
        gpuSrc.Upload(cpuEdges);
        using var gpuLines = new GpuMat();

        // Create detector: rho=1, theta=1 deg, minLength=30, maxGap=10
        float theta = (float)Math.PI / 180.0f;
        using var detector = OpenCvSharp.Cuda.HoughSegmentDetector.Create(
       rho: 1.0f,
       theta: theta,
       minLineLength: 10,
       maxLineGap: 50
   );

        // 2. Act
        detector.Detect(gpuSrc, gpuLines);

        // 3. Download and Assert
        using var cpuLines = new Mat();
        gpuLines.Download(cpuLines);

        Assert.False(cpuLines.Empty());

        // Output for Segment Detector is a matrix of CV_32SC4 (x1, y1, x2, y2)
        Assert.Equal(MatType.CV_32SC4, cpuLines.Type());

        var linesIndexer = cpuLines.GetGenericIndexer<Vec4i>();
        bool foundDiagonal = false;

        int total = cpuLines.Rows * cpuLines.Cols;
        for (int r = 0; r < cpuLines.Rows; r++)
        {
            for (int c = 0; c < cpuLines.Cols; c++)
            {
                Vec4i s = cpuLines.At<Vec4i>(r, c);

                float dx = s.Item2 - s.Item0;
                float dy = s.Item3 - s.Item1;

                // slope ≈ 1
                if (Math.Abs(Math.Abs(dx) - Math.Abs(dy)) < 5)
                {
                    // length large enough
                    float length = (float)Math.Sqrt(dx * dx + dy * dy);

                    if (length > 50)
                    {
                        foundDiagonal = true;
                        break;
                    }
                }
            }
        }

        Assert.True(foundDiagonal, "No sufficiently long diagonal segment detected.");
    }

    [Fact]
    public void HoughSegmentDetector_PropertiesTest()
    {
        VerifyCudaSupport();

        // 1. Arrange
        float theta = (float)Math.PI / 180.0f;
        using var detector = OpenCvSharp.Cuda.HoughSegmentDetector.Create(1.0f, theta, minLineLength: 50, maxLineGap: 10, maxLines: 500);

        // 2. Assert Initial
        Assert.Equal(1.0f, detector.Rho);
        Assert.Equal(theta, detector.Theta);
        Assert.Equal(50, detector.MinLineLength);
        Assert.Equal(10, detector.MaxLineGap);
        Assert.Equal(500, detector.MaxLines);

        // 3. Act: Modify
        detector.MinLineLength = 100;
        detector.MaxLineGap = 5;
        detector.MaxLines = 1000;

        // 4. Assert Modified
        Assert.Equal(100, detector.MinLineLength);
        Assert.Equal(5, detector.MaxLineGap);
        Assert.Equal(1000, detector.MaxLines);
    }
}
