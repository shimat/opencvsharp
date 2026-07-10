using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

public class StarDetectorTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var star = StarDetector.Create();
        star.Dispose();
    }

    [Fact]
    public void Detect()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var star = StarDetector.Create();

        var keypoints = star.Detect(gray);

        Assert.NotEmpty(keypoints);
    }

    [Fact]
    public void Properties()
    {
        using var alg = StarDetector.Create();

        alg.MaxSize = 30;
        Assert.Equal(30, alg.MaxSize);

        alg.ResponseThreshold = 20;
        Assert.Equal(20, alg.ResponseThreshold);

        alg.LineThresholdProjected = 5;
        Assert.Equal(5, alg.LineThresholdProjected);

        alg.LineThresholdBinarized = 4;
        Assert.Equal(4, alg.LineThresholdBinarized);

        alg.SuppressNonmaxSize = 3;
        Assert.Equal(3, alg.SuppressNonmaxSize);
    }
}
