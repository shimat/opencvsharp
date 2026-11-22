using Xunit;

namespace OpenCvSharp.Tests.Photo;

public class TonemapTest : TestBase
{
    [Fact]
    public void Process()
    {
        using var src = LoadImage("lenna.png");
        using var dst = new Mat();
        using var tonemap = Tonemap.Create(2.2f);

        // 8UC3 -> 32FC3
        using var src32f = new Mat();
        src.ConvertTo(src32f, MatType.CV_32FC3);

        ExplainExpectedNativeWarning("Tonemap normalizes multi-channel input through MatExpr, which can emit OpenCV's once-per-process semantics warning.");
        tonemap.Process(src32f, dst);
        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(MatType.CV_32FC3, dst.Type());
        Assert.True(Cv2.CheckRange(dst));

        ShowImagesWhenDebugMode(dst);
    }

    [Fact]
    public void Properties()
    {
        using var tonemap = Tonemap.Create(2.2f);
        Assert.Equal(2.2f, tonemap.Gamma, 1e-3);

        tonemap.Gamma = 0.5f;
        Assert.Equal(0.5f, tonemap.Gamma, 1e-3);
    }
}
