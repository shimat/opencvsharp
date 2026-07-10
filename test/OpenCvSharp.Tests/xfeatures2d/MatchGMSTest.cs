using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class MatchGMSTest : TestBase
{
    [Fact]
    public void MatchGMS()
    {
        using var img1 = LoadImage("tsukuba_left.png", ImreadModes.Grayscale);
        using var img2 = LoadImage("tsukuba_right.png", ImreadModes.Grayscale);
        using var orb = ORB.Create(10000);
        using var descriptor1 = new Mat();
        using var descriptor2 = new Mat();
        orb.DetectAndCompute(img1, default, out var keypoints1, descriptor1);
        orb.DetectAndCompute(img2, default, out var keypoints2, descriptor2);

        using var matcher = new BFMatcher(NormTypes.Hamming);
        var matches = matcher.Match(descriptor1, descriptor2);

        var gmsMatches = Cv2.MatchGMS(img1.Size(), img2.Size(), keypoints1, keypoints2, matches);

        Assert.NotNull(gmsMatches);
    }
}
