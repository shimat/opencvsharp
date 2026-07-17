using Xunit;

namespace OpenCvSharp.Tests.Stitching;

public class PyRotationWarperTest : TestBase
{
    [Theory]
    [InlineData("plane")]
    [InlineData("cylindrical")]
    [InlineData("spherical")]
    [InlineData("fisheye")]
    [InlineData("stereographic")]
    [InlineData("mercator")]
    [InlineData("transverseMercator")]
    public void WarpImage(string type)
    {
        using var warper = new PyRotationWarper(type, 300f);
        using var src = new Mat(new Size(64, 64), MatType.CV_8UC3, Scalar.All(128));
        using var k = Mat.Eye(3, 3, MatType.CV_32F).ToMat();
        using var r = Mat.Eye(3, 3, MatType.CV_32F).ToMat();
        using var dst = new Mat();

        var corner = warper.Warp(src, k, r, InterpolationFlags.Linear, BorderTypes.Reflect, dst);
        Assert.False(dst.Empty());
        _ = corner;

        var roi = warper.WarpRoi(src.Size(), k, r);
        Assert.True(roi.Width > 0 && roi.Height > 0);
    }

    [Fact]
    public void WarpPointRoundTrip()
    {
        using var warper = new PyRotationWarper("plane", 300f);
        using var k = Mat.Eye(3, 3, MatType.CV_32F).ToMat();
        using var r = Mat.Eye(3, 3, MatType.CV_32F).ToMat();

        var projected = warper.WarpPoint(new Point2f(10, 10), k, r);
        var back = warper.WarpPointBackward(projected, k, r);
        Assert.InRange(back.X, 5, 15);
        Assert.InRange(back.Y, 5, 15);
    }

    [Theory]
    [InlineData(typeof(PlaneWarper))]
    [InlineData(typeof(AffineWarper))]
    [InlineData(typeof(CylindricalWarper))]
    [InlineData(typeof(SphericalWarper))]
    [InlineData(typeof(FisheyeWarper))]
    [InlineData(typeof(StereographicWarper))]
    [InlineData(typeof(MercatorWarper))]
    [InlineData(typeof(TransverseMercatorWarper))]
    public void ConstructWarperCreator(Type type)
    {
        using var creator = (WarperCreator)Activator.CreateInstance(type)!;
        Assert.NotNull(creator);
    }

    [Fact]
    public void ConstructCompressedAndPaniniWarperCreators()
    {
        using var w1 = new CompressedRectilinearWarper();
        using var w2 = new CompressedRectilinearPortraitWarper();
        using var w3 = new PaniniWarper();
        using var w4 = new PaniniPortraitWarper();
        Assert.NotNull(w1);
        Assert.NotNull(w2);
        Assert.NotNull(w3);
        Assert.NotNull(w4);
    }
}
