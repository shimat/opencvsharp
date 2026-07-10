using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class BEBLIDTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var beblid = BEBLID.Create(6.25f);
        beblid.Dispose();
    }

    [Fact]
    public void Compute()
    {
        using var color = LoadImage("lenna.png", ImreadModes.Color);
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var beblid = BEBLID.Create(6.25f);
        using var orb = ORB.Create();

        var keypoints = orb.Detect(gray);
        beblid.Compute(color, ref keypoints, descriptors);

        Assert.False(descriptors.Empty());
    }

    [Fact]
    public void ScaleFactor()
    {
        using var alg = BEBLID.Create(6.25f);

        Assert.Equal(6.25f, alg.ScaleFactor, 3);

        alg.ScaleFactor = 1.0f;
        Assert.Equal(1.0f, alg.ScaleFactor, 3);
    }
}
