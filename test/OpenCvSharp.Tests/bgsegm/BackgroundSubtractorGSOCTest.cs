using Xunit;

namespace OpenCvSharp.Tests.BgSegm;

// ReSharper disable InconsistentNaming
public class BackgroundSubtractorGSOCTest : TestBase
{
    [Fact]
    public void Apply()
    {
        using var gsoc = BackgroundSubtractorGSOC.Create();
        using var src = LoadImage("lenna.png");
        using var dst = new Mat();

        gsoc.Apply(src, dst);

        Assert.False(dst.Empty());
    }
}
