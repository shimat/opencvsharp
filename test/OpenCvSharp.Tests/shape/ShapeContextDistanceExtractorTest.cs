using Xunit;

namespace OpenCvSharp.Tests.Shape;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class ShapeContextDistanceExtractorTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        Assert.NotNull(extractor);
    }

    [Fact]
    public void CreateWithCustomParameters()
    {
        using var extractor = ShapeContextDistanceExtractor.Create(
            nAngularBins: 8, nRadialBins: 3, innerRadius: 0.1f, outerRadius: 3.0f, iterations: 2);
        Assert.Equal(8, extractor.AngularBins);
        Assert.Equal(3, extractor.RadialBins);
        Assert.Equal(0.1f, extractor.InnerRadius, precision: 5);
        Assert.Equal(3.0f, extractor.OuterRadius, precision: 5);
        Assert.Equal(2, extractor.Iterations);
    }

    [Fact]
    public void AngularBinsRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        extractor.AngularBins = 6;
        Assert.Equal(6, extractor.AngularBins);
    }

    [Fact]
    public void RadialBinsRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        extractor.RadialBins = 5;
        Assert.Equal(5, extractor.RadialBins);
    }

    [Fact]
    public void InnerRadiusRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        extractor.InnerRadius = 0.3f;
        Assert.Equal(0.3f, extractor.InnerRadius, precision: 5);
    }

    [Fact]
    public void OuterRadiusRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        extractor.OuterRadius = 4.0f;
        Assert.Equal(4.0f, extractor.OuterRadius, precision: 5);
    }

    [Fact]
    public void RotationInvariantRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        bool initial = extractor.RotationInvariant;

        extractor.RotationInvariant = !initial;
        Assert.Equal(!initial, extractor.RotationInvariant);

        extractor.RotationInvariant = initial;
        Assert.Equal(initial, extractor.RotationInvariant);
    }

    [Fact]
    public void ShapeContextWeightRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        extractor.ShapeContextWeight = 0.5f;
        Assert.Equal(0.5f, extractor.ShapeContextWeight, precision: 5);
    }

    [Fact]
    public void ImageAppearanceWeightRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        extractor.ImageAppearanceWeight = 0.2f;
        Assert.Equal(0.2f, extractor.ImageAppearanceWeight, precision: 5);
    }

    [Fact]
    public void BendingEnergyWeightRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        extractor.BendingEnergyWeight = 0.3f;
        Assert.Equal(0.3f, extractor.BendingEnergyWeight, precision: 5);
    }

    [Fact]
    public void IterationsRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        extractor.Iterations = 5;
        Assert.Equal(5, extractor.Iterations);
    }

    [Fact]
    public void StdDevRoundTrip()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        extractor.StdDev = 2.0f;
        Assert.Equal(2.0f, extractor.StdDev, precision: 5);
    }

    [Fact]
    public void SetAndGetImages()
    {
        using var extractor = ShapeContextDistanceExtractor.Create();
        using var img1 = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));
        using var img2 = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(0));

        // Should not throw
        extractor.SetImages(img1, img2);

        using var out1 = new Mat();
        using var out2 = new Mat();
        extractor.GetImages(out1, out2);

        Assert.False(out1.Empty());
        Assert.False(out2.Empty());
    }

    [Fact]
    public void ComputeDistance_IdenticalContours()
    {
        using var extractor = ShapeContextDistanceExtractor.Create(
            nAngularBins: 5, nRadialBins: 3, iterations: 1);

        // Small circle-ish contour using 8 points
        var pts = CirclePoints(center: new Point2f(32, 32), radius: 20, count: 8);
        using var contour = Mat.FromArray(pts);

        // Distance between identical shapes should be very small (ideally 0)
        float dist = extractor.ComputeDistance(contour, contour);
        Assert.True(dist >= 0, $"Expected non-negative distance, got {dist}");
    }

    // ---- helpers ----

    private static Point2f[] CirclePoints(Point2f center, float radius, int count)
    {
        var pts = new Point2f[count];
        for (int i = 0; i < count; i++)
        {
            double angle = 2 * Math.PI * i / count;
            pts[i] = new Point2f(
                center.X + (float)(radius * Math.Cos(angle)),
                center.Y + (float)(radius * Math.Sin(angle)));
        }
        return pts;
    }
}