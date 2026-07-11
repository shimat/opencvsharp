using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class TBMRTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var tbmr = TBMR.Create();
        tbmr.Dispose();
    }

    [Fact]
    public void Detect()
    {
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var tbmr = TBMR.Create();

        var keypoints = tbmr.Detect(gray);

        Assert.NotNull(keypoints);
    }

    [Fact]
    public void Properties()
    {
        using var alg = TBMR.Create();

        alg.MinArea = 100;
        Assert.Equal(100, alg.MinArea);

        alg.MaxAreaRelative = 0.02f;
        Assert.Equal(0.02f, alg.MaxAreaRelative, 3);

        alg.ScaleFactor = 1.5f;
        Assert.Equal(1.5f, alg.ScaleFactor, 3);

        alg.NScales = 2;
        Assert.Equal(2, alg.NScales);
    }

    [Fact]
    public void DetectElliptic()
    {
        // TBMR extends AffineFeature2D natively (cv::xfeatures2d::TBMR : AffineFeature2D), so the
        // elliptic-region detect API should be available on the C# type too, not just plain Detect().
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var tbmr = TBMR.Create();

        var keypoints = tbmr.DetectElliptic(gray);

        Assert.NotEmpty(keypoints);
        Assert.All(keypoints, kp => Assert.True(kp.Axes.Width >= 0 && kp.Axes.Height >= 0));
    }
}
