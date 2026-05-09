using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.imgproc;

public class CudaHoughCirclesDetectorTest : CudaTestBase
{
    [Fact]
    public void HoughCircles_DetectTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 200x200 black image and draw a white circle
        // Circle center: (100, 100), Radius: 50
        using var cpuSrc = new Mat(200, 200, MatType.CV_8UC1, new Scalar(0));
        Cv2.Circle(cpuSrc, new Point(100, 100), 50, new Scalar(255), 2);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuCircles = new GpuMat();

        // Create detector
        // dp: 1, minDist: 50, cannyThreshold: 100, votesThreshold: 30, minRadius: 10, maxRadius: 100
        using var detector = OpenCvSharp.Cuda.HoughCirclesDetector.Create(1.0f, 50.0f, 100, 30, 10, 100);

        // 2. Act
        detector.Detect(gpuSrc, gpuCircles);

        // 3. Download and Assert
        using var cpuCircles = new Mat();
        gpuCircles.Download(cpuCircles);

        Assert.False(cpuCircles.Empty());

        // Output for CUDA HoughCircles is a 1-row (or 1-col) matrix of CV_32FC3 (x, y, radius)
        Assert.Equal(MatType.CV_32FC3, cpuCircles.Type());

        // Get the first detected circle
        var circlesIndexer = cpuCircles.GetGenericIndexer<Vec3f>();
        Vec3f circle = circlesIndexer[0];

        // Validate that it found our circle approximately at (100, 100) with radius 50
        AssertAround(circle.Item0, 100f, 0.1); // X
        AssertAround(circle.Item1, 100f, 0.1); // Y
        AssertAround(circle.Item2, 50f, 0.2);  // Radius
    }

    [Fact]
    public void HoughCirclesDetector_PropertiesTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create detector with specific initial values
        using var detector = OpenCvSharp.Cuda.HoughCirclesDetector.Create(1.5f, 50.0f, 100, 30, 10, 100, 2000);

        // 2. Assert Initial
        Assert.Equal(1.5f, detector.Dp);
        Assert.Equal(50.0f, detector.MinDist);
        Assert.Equal(100, detector.CannyThreshold);
        Assert.Equal(30, detector.VotesThreshold);
        Assert.Equal(10, detector.MinRadius);
        Assert.Equal(100, detector.MaxRadius);
        Assert.Equal(2000, detector.MaxCircles);

        // 3. Act: Modify Properties
        detector.MinRadius = 20;
        detector.MaxRadius = 150;
        detector.CannyThreshold = 150;

        // 4. Assert Modified
        Assert.Equal(20, detector.MinRadius);
        Assert.Equal(150, detector.MaxRadius);
        Assert.Equal(150, detector.CannyThreshold);
    }
}
