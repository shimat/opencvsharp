using Xunit;

namespace OpenCvSharp.Tests.BgSegm;

// ReSharper disable InconsistentNaming
public class BackgroundSubtractorMOGTest : TestBase
{
    [Fact]
    public void CheckProperties()
    {
        using var mog = BackgroundSubtractorMOG.Create();

        mog.History = 100;
        Assert.Equal(100, mog.History);

        mog.NMixtures = 3;
        Assert.Equal(3, mog.NMixtures);

        mog.BackgroundRatio = 0.5;
        Assert.Equal(0.5, mog.BackgroundRatio);

        mog.NoiseSigma = 10;
        Assert.Equal(10, mog.NoiseSigma);
    }

    [Fact]
    public void Apply()
    {
        using var mog = BackgroundSubtractorMOG.Create();
        using var src = LoadImage("lenna.png");
        using var dst = new Mat();

        mog.Apply(src, dst);

        Assert.False(dst.Empty());
    }
}
