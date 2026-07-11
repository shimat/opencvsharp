using Xunit;

namespace OpenCvSharp.Tests.BgSegm;

public class SyntheticSequenceGeneratorTest : TestBase
{
    [Fact]
    public void GetNextFrame()
    {
        using var background = LoadImage("lenna.png");
        using var obj = LoadImage("mandrill.png");
        using var gen = new SyntheticSequenceGenerator(background, obj, 2.0, 20.0, 0.5, 5.0);
        using var frame = new Mat();
        using var gtMask = new Mat();

        gen.GetNextFrame(frame, gtMask);

        Assert.False(frame.Empty());
        Assert.False(gtMask.Empty());
    }
}
