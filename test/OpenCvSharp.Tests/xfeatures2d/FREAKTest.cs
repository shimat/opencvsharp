using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class FREAKTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var freak = FREAK.Create();
        freak.Dispose();
    }

    [Fact]
    public void Compute()
    {
        using var color = LoadImage("lenna.png", ImreadModes.Color);
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var freak = FREAK.Create();
        using var surf = SURF.Create(500);

        var keypoints = surf.Detect(gray);
        freak.Compute(color, ref keypoints, descriptors);

        Assert.False(descriptors.Empty());
    }

    [Fact]
    public void Properties()
    {
        using var alg = FREAK.Create();

        alg.OrientationNormalized = false;
        Assert.False(alg.OrientationNormalized);

        alg.ScaleNormalized = false;
        Assert.False(alg.ScaleNormalized);

        alg.PatternScale = 10.0;
        Assert.Equal(10.0, alg.PatternScale, 6);

        alg.NOctaves = 2;
        Assert.Equal(2, alg.NOctaves);
    }
}
