using OpenCvSharp.XFeatures2D;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class TEBLIDTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        var teblid = TEBLID.Create(6.25f);
        teblid.Dispose();
    }

    [Fact]
    public void Compute()
    {
        using var color = LoadImage("lenna.png", ImreadModes.Color);
        using var gray = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var descriptors = new Mat();
        using var teblid = TEBLID.Create(6.25f);
        using var orb = ORB.Create();

        var keypoints = orb.Detect(gray);
        teblid.Compute(color, ref keypoints, descriptors);

        Assert.False(descriptors.Empty());
    }
}
