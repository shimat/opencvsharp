using OpenCvSharp.Segmentation;
using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

// ReSharper disable once InconsistentNaming
public class IntelligentScissorsMBTest : TestBase
{
    [Fact]
    public void NewAndDispose()
    {
        using var tool = new IntelligentScissorsMB();
        GC.KeepAlive(tool);
    }

    /// <summary>
    /// https://github.com/opencv/opencv/blob/68d15fc62edad980f1ffa15ee478438335f39cc3/samples/cpp/tutorial_code/snippets/imgproc_segmentation.cpp
    /// </summary>
    [Fact]
    public void Run()
    {
        using var image = new Mat(new Size(1920, 1080), MatType.CV_8UC3, Scalar.All(128));

        using var tool = new IntelligentScissorsMB();
        tool.SetEdgeFeatureCannyParameters(16, 100)  // using Canny() as edge feature extractor
            .SetGradientMagnitudeMaxLimit(200);

        // calculate image features
        tool.ApplyImage(image);

        // calculate map for specified source point
        var sourcePoint = new Point(200, 100);
        tool.BuildMap(sourcePoint);

        // fast fetching of contours
        // for specified target point and the pre-calculated map (stored internally)
        var targetPoint = new Point(400, 300);
        using var ptsMat = new Mat<Point>();
        tool.GetContour(targetPoint, ptsMat);

        var pts = ptsMat.ToArray();
        Assert.Equal(201, pts.Length);
    }

    [Fact]
    public void ApplyImageFeatures()
    {
        var size = new Size(300, 200);
        using var nonEdge = Mat.ZerosMat(size, MatType.CV_8UC1);
        using var gradientDirection = new Mat(size, MatType.CV_32FC2, Scalar.All(0));
        using var gradientMagnitude = new Mat(size, MatType.CV_32FC1, Scalar.All(1));

        using var tool = new IntelligentScissorsMB();
        var ret = tool.ApplyImageFeatures(nonEdge, gradientDirection, gradientMagnitude);
        Assert.True(ReferenceEquals(tool, ret));

        var sourcePoint = new Point(50, 50);
        tool.BuildMap(sourcePoint);

        var targetPoint = new Point(150, 100);
        using var ptsMat = new Mat<Point>();
        tool.GetContour(targetPoint, ptsMat);

        // Chebyshev distance between source and target, plus the source point itself.
        Assert.Equal(101, ptsMat.ToArray().Length);
    }
}
