using Xunit;

namespace OpenCvSharp.Tests.Shape;

#pragma warning disable CA1707 // Identifiers should not contain underscores

public class ThinPlateSplineShapeTransformerTest : TestBase
{
    // ----------------------------------------------------------------
    // ThinPlateSplineShapeTransformer
    // ----------------------------------------------------------------

    [Fact]
    public void TPSS_CreateAndDispose()
    {
        using var tps = ThinPlateSplineShapeTransformer.Create();
        Assert.NotNull(tps);
    }

    [Fact]
    public void TPSS_CreateViaStaticMethod()
    {
        using var tps = CvShape.CreateThinPlateSplineShapeTransformer();
        Assert.NotNull(tps);
    }

    [Fact]
    public void TPSS_RegularizationParameterRoundTrip()
    {
        using var tps = ThinPlateSplineShapeTransformer.Create(0);
        Assert.Equal(0.0, tps.RegularizationParameter);

        tps.RegularizationParameter = 0.5;
        Assert.Equal(0.5, tps.RegularizationParameter, precision: 9);
    }

    [Fact]
    public void TPSS_EstimateAndApplyTransformation()
    {
        using var tps = ThinPlateSplineShapeTransformer.Create();

        // Simple square: 4 corresponding point pairs
        var shape1 = new[] { new Point2f(0, 0), new Point2f(1, 0), new Point2f(1, 1), new Point2f(0, 1) };
        var shape2 = new[] { new Point2f(0, 0), new Point2f(1, 0), new Point2f(1, 1), new Point2f(0, 1) };
        var matches = new[] { new DMatch(0, 0, 0), new DMatch(1, 1, 0), new DMatch(2, 2, 0), new DMatch(3, 3, 0) };

        using var src = Mat.FromArray(shape1).Reshape(2, 1);
        using var dst = Mat.FromArray(shape2).Reshape(2, 1);

        tps.EstimateTransformation(src, dst, matches);

        float cost = tps.ApplyTransformation(src);
        Assert.True(cost >= 0);
    }

    [Fact]
    public void TPSS_ApplyTransformationWithOutput()
    {
        using var tps = ThinPlateSplineShapeTransformer.Create();

        var shape1 = new[] { new Point2f(0, 0), new Point2f(2, 0), new Point2f(2, 2), new Point2f(0, 2) };
        var shape2 = new[] { new Point2f(0, 0), new Point2f(2, 0), new Point2f(2, 2), new Point2f(0, 2) };
        var matches = new[] { new DMatch(0, 0, 0), new DMatch(1, 1, 0), new DMatch(2, 2, 0), new DMatch(3, 3, 0) };

        using var src = Mat.FromArray(shape1).Reshape(2, 1);
        using var dst = Mat.FromArray(shape2).Reshape(2, 1);
        tps.EstimateTransformation(src, dst, matches);

        using var output = new Mat();
        float cost = tps.ApplyTransformation(src, output);
        Assert.True(cost >= 0);
        Assert.False(output.Empty());
    }

    [Fact]
    public void TPSS_WarpImage()
    {
        using var tps = ThinPlateSplineShapeTransformer.Create();

        var shape1 = new[] { new Point2f(10, 10), new Point2f(90, 10), new Point2f(90, 90), new Point2f(10, 90) };
        var shape2 = new[] { new Point2f(10, 10), new Point2f(90, 10), new Point2f(90, 90), new Point2f(10, 90) };
        var matches = new[] { new DMatch(0, 0, 0), new DMatch(1, 1, 0), new DMatch(2, 2, 0), new DMatch(3, 3, 0) };

        using var contour1 = Mat.FromArray(shape1).Reshape(2, 1);
        using var contour2 = Mat.FromArray(shape2).Reshape(2, 1);
        tps.EstimateTransformation(contour1, contour2, matches);

        using var inputImage = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(128));
        using var warpedImage = new Mat();
        tps.WarpImage(inputImage, warpedImage);

        Assert.False(warpedImage.Empty());
        Assert.Equal(inputImage.Rows, warpedImage.Rows);
        Assert.Equal(inputImage.Cols, warpedImage.Cols);
    }

    // ----------------------------------------------------------------
    // AffineTransformer
    // ----------------------------------------------------------------

    [Fact]
    public void Affine_CreateAndDispose()
    {
        using var at = AffineTransformer.Create();
        Assert.NotNull(at);
    }

    [Fact]
    public void Affine_CreateViaStaticMethod()
    {
        using var at = CvShape.CreateAffineTransformer();
        Assert.NotNull(at);
    }

    [Fact]
    public void Affine_FullAffineRoundTrip()
    {
        using var at = AffineTransformer.Create(fullAffine: false);
        Assert.False(at.FullAffine);

        at.FullAffine = true;
        Assert.True(at.FullAffine);

        at.FullAffine = false;
        Assert.False(at.FullAffine);
    }

    [Fact]
    public void Affine_EstimateAndApplyTransformation()
    {
        using var at = AffineTransformer.Create();

        var shape1 = new[] { new Point2f(0, 0), new Point2f(1, 0), new Point2f(1, 1), new Point2f(0, 1) };
        var shape2 = new[] { new Point2f(0, 0), new Point2f(1, 0), new Point2f(1, 1), new Point2f(0, 1) };
        var matches = new[] { new DMatch(0, 0, 0), new DMatch(1, 1, 0), new DMatch(2, 2, 0), new DMatch(3, 3, 0) };

        using var src = Mat.FromArray(shape1).Reshape(2, 1);
        using var dst = Mat.FromArray(shape2).Reshape(2, 1);

        at.EstimateTransformation(src, dst, matches);

        float cost = at.ApplyTransformation(src);
        Assert.True(cost >= 0);
    }

    [Fact]
    public void Affine_WarpImage()
    {
        using var at = AffineTransformer.Create();

        var shape1 = new[] { new Point2f(10, 10), new Point2f(90, 10), new Point2f(90, 90), new Point2f(10, 90) };
        var shape2 = new[] { new Point2f(10, 10), new Point2f(90, 10), new Point2f(90, 90), new Point2f(10, 90) };
        var matches = new[] { new DMatch(0, 0, 0), new DMatch(1, 1, 0), new DMatch(2, 2, 0), new DMatch(3, 3, 0) };

        using var contour1 = Mat.FromArray(shape1).Reshape(2, 1);
        using var contour2 = Mat.FromArray(shape2).Reshape(2, 1);
        at.EstimateTransformation(contour1, contour2, matches);

        using var inputImage = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(128));
        using var warpedImage = new Mat();
        at.WarpImage(inputImage, warpedImage);

        Assert.False(warpedImage.Empty());
        Assert.Equal(inputImage.Rows, warpedImage.Rows);
        Assert.Equal(inputImage.Cols, warpedImage.Cols);
    }
}