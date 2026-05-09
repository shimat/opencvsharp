using System;
using Xunit;
using OpenCvSharp;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;

namespace OpenCvSharp.Tests.Cuda.imgproc;

public class CudaCannyEdgeDetectorTest : CudaTestBase
{
    [Fact]
    public void CreateCannyEdgeDetector()
    {
        VerifyCudaSupport();

        // 1. Arrange
        // Create a 100x100 completely black image
        using var cpuSrc = new Mat(100, 100, MatType.CV_8UC1, new Scalar(0));

        // Make the left half completely white.
        // This creates a perfectly sharp vertical edge at column 50.
        Cv2.Rectangle(cpuSrc, new Rect(0, 0, 50, 100), new Scalar(255), -1);

        using var gpuSrc = new GpuMat(); gpuSrc.Upload(cpuSrc);
        using var gpuEdges = new GpuMat();

        // Create Canny detector with standard thresholds
        using var canny = OpenCvSharp.Cuda.CannyEdgeDetector.Create(lowThresh: 50.0, highThresh: 100.0);

        // 2. Act
        canny.Detect(gpuSrc, gpuEdges);

        // 3. Download and Assert
        using var cpuEdges = new Mat();
        gpuEdges.Download(cpuEdges);

        Assert.False(cpuEdges.Empty());
        Assert.Equal(MatType.CV_8UC1, cpuEdges.Type());

        // A pixel far away from the edge should be 0 (No Edge)
        Assert.Equal(0, cpuEdges.At<byte>(50, 10));
        Assert.Equal(0, cpuEdges.At<byte>(50, 90));

        int edgeCount = 0;

        for (int y = 0; y < 100; y++)
        {
            for (int x = 48; x <= 52; x++)
            {
                if (cpuEdges.At<byte>(y, x) > 0)
                    edgeCount++;
            }
        }

        Assert.True(edgeCount > 50, "Expected a continuous vertical edge");
    }

    [Fact]
    public void CannyEdgeDetector_PropertiesTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create the detector with initial values
        using var canny = OpenCvSharp.Cuda.CannyEdgeDetector.Create(lowThresh: 50.0, highThresh: 100.0, appertureSize: 3, l2Gradient: false);

        // 2. Assert initial values
        Assert.Equal(50.0, canny.LowThreshold);
        Assert.Equal(100.0, canny.HighThreshold);
        Assert.Equal(3, canny.AppertureSize);
        Assert.False(canny.L2Gradient);

        // 3. Act: Modify the properties
        canny.LowThreshold = 30.0;
        canny.HighThreshold = 120.0;
        canny.AppertureSize = 5; // Must be 3, 5, or 7
        canny.L2Gradient = true;

        // 4. Assert modified values
        Assert.Equal(30.0, canny.LowThreshold);
        Assert.Equal(120.0, canny.HighThreshold);
        Assert.Equal(5, canny.AppertureSize);
        Assert.True(canny.L2Gradient);
    }
}
