using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

public class HarrisLaplaceFeatureDetectorTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var detector = HarrisLaplaceFeatureDetector.Create();
        detector.Dispose();
    }

    [Fact]
    public void Detect()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var detector = HarrisLaplaceFeatureDetector.Create();

        var keypoints = detector.Detect(gray);

        Assert.NotEmpty(keypoints);
    }

    [Fact]
    public void Properties()
    {
        using var alg = HarrisLaplaceFeatureDetector.Create();

        alg.NumOctaves = 4;
        Assert.Equal(4, alg.NumOctaves);

        alg.CornThresh = 0.02f;
        Assert.Equal(0.02f, alg.CornThresh, 3);

        alg.DOGThresh = 0.02f;
        Assert.Equal(0.02f, alg.DOGThresh, 3);

        alg.MaxCorners = 2000;
        Assert.Equal(2000, alg.MaxCorners);

        alg.NumLayers = 2;
        Assert.Equal(2, alg.NumLayers);
    }
}
