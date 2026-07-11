using Xunit;

namespace OpenCvSharp.Tests.BgSegm;

// ReSharper disable InconsistentNaming
public class BackgroundSubtractorLSBPDescTest : TestBase
{
    private static Point[] CreateSamplePoints(int radius)
    {
        var points = new Point[32];
        for (var i = 0; i < points.Length; i++)
        {
            var phi = i * (2 * Math.PI / points.Length);
            points[i] = new Point((int)(radius * Math.Cos(phi)), (int)(radius * Math.Sin(phi)));
        }
        return points;
    }

    [Fact]
    public void CalcLocalSVDValues()
    {
        using var src = LoadImage("lenna.png");
        using var svd = new Mat();

        BackgroundSubtractorLSBPDesc.CalcLocalSVDValues(svd, src);

        Assert.False(svd.Empty());
    }

    [Fact]
    public void ComputeFromLocalSVDValues()
    {
        using var src = LoadImage("lenna.png");
        using var svd = new Mat();
        BackgroundSubtractorLSBPDesc.CalcLocalSVDValues(svd, src);

        using var desc = new Mat();
        BackgroundSubtractorLSBPDesc.ComputeFromLocalSVDValues(desc, svd, CreateSamplePoints(16));

        Assert.False(desc.Empty());
    }

    [Fact]
    public void Compute()
    {
        using var src = LoadImage("lenna.png");
        using var desc = new Mat();

        BackgroundSubtractorLSBPDesc.Compute(desc, src, CreateSamplePoints(16));

        Assert.False(desc.Empty());
    }
}
