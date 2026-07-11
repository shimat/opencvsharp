using Xunit;

namespace OpenCvSharp.Tests.BgSegm;

// ReSharper disable InconsistentNaming
public class BackgroundSubtractorLSBPTest : TestBase
{
    [Fact]
    public void Apply()
    {
        using var lsbp = BackgroundSubtractorLSBP.Create();
        using var src = LoadImage("lenna.png");
        using var dst = new Mat();

        lsbp.Apply(src, dst);

        Assert.False(dst.Empty());
    }
}
