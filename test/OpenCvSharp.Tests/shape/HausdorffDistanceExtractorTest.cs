using Xunit;

namespace OpenCvSharp.Tests.Shape;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class HausdorffDistanceExtractorTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var extractor = HausdorffDistanceExtractor.Create();
        Assert.NotNull(extractor);
    }

    [Fact]
    public void CreateWithCustomParameters()
    {
        using var extractor = HausdorffDistanceExtractor.Create(
            distanceFlag: DistanceTypes.L1, rankProp: 0.8f);
        Assert.Equal(DistanceTypes.L1, extractor.DistanceFlag);
        Assert.Equal(0.8f, extractor.RankProportion, precision: 5);
    }

    [Fact]
    public void DistanceFlagRoundTrip()
    {
        using var extractor = HausdorffDistanceExtractor.Create();
        extractor.DistanceFlag = DistanceTypes.L1;
        Assert.Equal(DistanceTypes.L1, extractor.DistanceFlag);

        extractor.DistanceFlag = DistanceTypes.L2;
        Assert.Equal(DistanceTypes.L2, extractor.DistanceFlag);
    }

    [Fact]
    public void RankProportionRoundTrip()
    {
        using var extractor = HausdorffDistanceExtractor.Create();
        extractor.RankProportion = 0.9f;
        Assert.Equal(0.9f, extractor.RankProportion, precision: 5);

        extractor.RankProportion = 0.1f;
        Assert.Equal(0.1f, extractor.RankProportion, precision: 5);
    }

    [Fact]
    public void ComputeDistance_IdenticalContours()
    {
        using var extractor = HausdorffDistanceExtractor.Create();

        var pts = new[] { new Point2f(0, 0), new Point2f(10, 0), new Point2f(10, 10), new Point2f(0, 10) };
        using var contour = Mat.FromArray(pts);

        float dist = extractor.ComputeDistance(contour, contour);
        Assert.Equal(0f, dist, precision: 5);
    }

    [Fact]
    public void ComputeDistance_DifferentContours()
    {
        using var extractor = HausdorffDistanceExtractor.Create();

        var pts1 = new[] { new Point2f(0, 0), new Point2f(10, 0), new Point2f(10, 10), new Point2f(0, 10) };
        var pts2 = new[] { new Point2f(20, 20), new Point2f(30, 20), new Point2f(30, 30), new Point2f(20, 30) };

        using var contour1 = Mat.FromArray(pts1);
        using var contour2 = Mat.FromArray(pts2);

        float dist = extractor.ComputeDistance(contour1, contour2);
        Assert.True(dist > 0, $"Expected positive distance between non-overlapping shapes, got {dist}");
    }

    [Fact]
    public void ComputeDistance_IsNonNegative()
    {
        using var extractor = HausdorffDistanceExtractor.Create();

        var pts1 = new[] { new Point2f(0, 0), new Point2f(5, 0), new Point2f(5, 5), new Point2f(0, 5) };
        var pts2 = new[] { new Point2f(1, 1), new Point2f(6, 1), new Point2f(6, 6), new Point2f(1, 6) };

        using var c1 = Mat.FromArray(pts1);
        using var c2 = Mat.FromArray(pts2);

        float dist = extractor.ComputeDistance(c1, c2);
        Assert.True(dist >= 0);
    }
}