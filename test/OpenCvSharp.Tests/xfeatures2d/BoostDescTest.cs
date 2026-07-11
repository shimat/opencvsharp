using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

public class BoostDescTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var boostDesc = BoostDesc.Create();
        boostDesc.Dispose();
    }

    [Fact]
    public void Compute()
    {
        using var color = LoadImage("lenna.png", ImreadModes.Color);
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var boostDesc = BoostDesc.Create();
        using var orb = ORB.Create();

        var keypoints = orb.Detect(gray);
        boostDesc.Compute(color, ref keypoints, descriptors);

        Assert.False(descriptors.Empty());
    }

    [Fact]
    public void Properties()
    {
        using var alg = BoostDesc.Create();

        alg.UseScaleOrientation = false;
        Assert.False(alg.UseScaleOrientation);

        alg.ScaleFactor = 1.0f;
        Assert.Equal(1.0f, alg.ScaleFactor, 3);
    }
}
