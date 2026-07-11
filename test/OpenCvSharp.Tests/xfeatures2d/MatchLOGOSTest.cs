using System.Linq;
using Xunit;

namespace OpenCvSharp.Tests.XFeatures2D;

// ReSharper disable once InconsistentNaming
public class MatchLOGOSTest : TestBase
{
    [Fact]
    public void MatchLOGOS()
    {
        // OpenCV's matchLOGOS (opencv_contrib xfeatures2d/src/logos/Point.cpp,
        // Point::nearestNeighboursNaive) reads out of bounds when fewer than
        // NUM1/NUM2 (default 5) other points are available, so use a set large
        // enough to avoid tripping that upstream bug.
        var keypoints1 = Enumerable.Range(0, 10).Select(i => new KeyPoint(i * 10, i * 10, 1)).ToArray();
        var keypoints2 = Enumerable.Range(0, 10).Select(i => new KeyPoint(i * 10 + 1, i * 10 + 1, 1)).ToArray();
        var nn1 = Enumerable.Range(0, 10).ToArray();
        var nn2 = Enumerable.Range(0, 10).ToArray();

        var matches = Cv2.MatchLOGOS(keypoints1, keypoints2, nn1, nn2);

        Assert.NotNull(matches);
    }
}
