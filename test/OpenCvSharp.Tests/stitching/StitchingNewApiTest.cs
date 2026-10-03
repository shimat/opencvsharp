using Xunit;

namespace OpenCvSharp.Tests;

public class StitchingNewApiTest : TestBase
{
    [Fact]
    public void StitchingRegionHelpersReturnExpectedGeometry()
    {
        var corners = new[] { new Point(0, 0), new Point(5, 5) };
        var sizes = new[] { new Size(10, 10), new Size(10, 10) };
        Assert.Equal(new Rect(0, 0, 15, 15), Cv2.Detail.ResultRoi(corners, sizes));
        Assert.Equal(new Rect(5, 5, 5, 5), Cv2.Detail.ResultRoiIntersection(corners, sizes));
        Assert.Equal(new Point(0, 0), Cv2.Detail.ResultTl(corners));
        Assert.True(Cv2.Detail.OverlapRoi(corners[0], corners[1], sizes[0], sizes[1], out var overlap));
        Assert.Equal(new Rect(5, 5, 5, 5), overlap);
        var subset = Cv2.Detail.SelectRandomSubset(3, 10);
        Assert.Equal(3, subset.Distinct().Count());
        Assert.All(subset, index => Assert.InRange(index, 0, 9));

        using var image0 = new UMat(10, 10, MatType.CV_8UC1);
        using var image1 = new UMat(10, 10, MatType.CV_8UC1);
        Assert.Equal(new Rect(0, 0, 15, 15), Cv2.Detail.ResultRoi(corners, new[] { image0, image1 }));
    }

    [Fact]
    public void FocalEstimationAcceptsHomography()
    {
        using var homography = Mat.EyeMat(3, 3, MatType.CV_64FC1);
        Cv2.Detail.FocalsFromHomography(homography, out _, out _, out _, out _);
    }
}
