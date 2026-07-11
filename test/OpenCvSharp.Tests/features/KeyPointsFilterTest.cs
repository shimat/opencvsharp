using Xunit;

namespace OpenCvSharp.Tests.Features;

public class KeyPointsFilterTest : TestBase
{
    [Fact]
    public void RunByPixelsMask2VectorPoint()
    {
        var keypoints = new[]
        {
            new KeyPoint(5, 5, 1),
            new KeyPoint(50, 50, 1),
        };
        var removeFrom = new[]
        {
            new[] { new Point(5, 5), new Point(6, 6) },
            new[] { new Point(50, 50) },
        };
        using var mask = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(0));
        mask.Set(5, 5, (byte)255);

        var (resultKeypoints, resultRemoveFrom) = KeyPointsFilter.RunByPixelsMask2VectorPoint(keypoints, removeFrom, mask);

        Assert.Single(resultKeypoints);
        Assert.Equal(5, resultKeypoints[0].Pt.X, 3);
        Assert.Single(resultRemoveFrom);
    }

    [Fact]
    public void RunByPixelsMaskWithNullMatThrowsArgumentNullException()
    {
        var keypoints = new[] { new KeyPoint(5, 5, 1) };
        Mat? mask = null;

        // InputArray's implicit operator from Mat (OpenCvSharp/Modules/core/InputArray.cs) calls
        // ArgumentNullException.ThrowIfNull(mat) before RunByPixelsMask's body ever runs, so a null
        // Mat is still rejected with a clear exception despite the mask parameter accepting InputArray.
        Assert.Throws<ArgumentNullException>(() => KeyPointsFilter.RunByPixelsMask(keypoints, mask!));
    }
}
