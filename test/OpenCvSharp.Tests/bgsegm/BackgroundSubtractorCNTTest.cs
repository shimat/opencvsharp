using Xunit;

namespace OpenCvSharp.Tests.BgSegm;

// ReSharper disable InconsistentNaming
public class BackgroundSubtractorCNTTest : TestBase
{
    [Fact]
    public void CheckProperties()
    {
        using var cnt = BackgroundSubtractorCNT.Create();

        cnt.MinPixelStability = 20;
        Assert.Equal(20, cnt.MinPixelStability);

        cnt.MaxPixelStability = 500;
        Assert.Equal(500, cnt.MaxPixelStability);

        cnt.UseHistory = false;
        Assert.False(cnt.UseHistory);

        cnt.IsParallel = false;
        Assert.False(cnt.IsParallel);
    }

    [Fact]
    public void Apply()
    {
        using var cnt = BackgroundSubtractorCNT.Create();
        using var src = LoadImage("lenna.png");
        using var dst = new Mat();

        cnt.Apply(src, dst);

        Assert.False(dst.Empty());
    }
}
