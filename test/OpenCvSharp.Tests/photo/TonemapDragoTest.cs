using Xunit;

namespace OpenCvSharp.Tests.Photo;

public class TonemapDragoTest : TestBase
{
    [Fact]
    public void Process()
    {
        using var src = Image("lenna.png");
        using var dst = new Mat();
        using var tonemap = TonemapDrago.Create();

        // 8UC3 -> 32FC3
        using var src32f = new Mat();
        src.ConvertTo(src32f, MatType.CV_32FC3);

        tonemap.Process(src32f, dst);

        ShowImagesWhenDebugMode(dst);
    }

    [Fact]
    public void Properties()
    {
        using var tonemap = TonemapDrago.Create(2.2f, 1.5f, 0.95f);
        Assert.Equal(1.5f, tonemap.Saturation, 1e-3);
        Assert.Equal(0.95f, tonemap.Bias, 1e-3);

        tonemap.Saturation = 5.8f;
        tonemap.Bias = 0.5f;
        Assert.Equal(5.8f, tonemap.Saturation, 1e-3);
        Assert.Equal(0.5f, tonemap.Bias, 1e-3);
    }
}
