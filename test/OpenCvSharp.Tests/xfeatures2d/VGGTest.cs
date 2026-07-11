using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class VGGTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var vgg = VGG.Create();
        vgg.Dispose();
    }

    [Fact]
    public void Compute()
    {
        using var color = LoadImage("lenna.png", ImreadModes.Color);
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var vgg = VGG.Create();
        using var orb = ORB.Create();

        var keypoints = orb.Detect(gray);
        vgg.Compute(color, ref keypoints, descriptors);

        Assert.False(descriptors.Empty());
    }

    [Fact]
    public void Properties()
    {
        using var alg = VGG.Create();

        alg.Sigma = 1.0f;
        Assert.Equal(1.0f, alg.Sigma, 3);

        alg.UseNormalizeImage = false;
        Assert.False(alg.UseNormalizeImage);

        alg.UseScaleOrientation = false;
        Assert.False(alg.UseScaleOrientation);

        alg.ScaleFactor = 5.0f;
        Assert.Equal(5.0f, alg.ScaleFactor, 3);

        alg.UseNormalizeDescriptor = true;
        Assert.True(alg.UseNormalizeDescriptor);
    }
}
