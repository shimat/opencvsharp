using Xunit;

namespace OpenCvSharp.Tests.Photo;

public class TonemapReinhardTest : TestBase
{
    [Fact]
    public void Process()
    {
        using var src = LoadImage("lenna.png");
        using var dst = new Mat();
        using var tonemap = TonemapReinhard.Create();

        // 8UC3 -> 32FC3
        using var src32f = new Mat();
        src.ConvertTo(src32f, MatType.CV_32FC3);

        tonemap.Process(src32f, dst);

        ShowImagesWhenDebugMode(dst);
    }

    [Fact]
    public void Properties()
    {
        using var tonemap = TonemapReinhard.Create(2.2f, 1.1f, 0.8f, 0.7f);
        Assert.Equal(1.1f, tonemap.Intensity, 1e-3);
        Assert.Equal(0.8f, tonemap.LightAdaptation, 1e-3);
        Assert.Equal(0.7f, tonemap.ColorAdaptation, 1e-3);

        tonemap.Intensity = 1.8f;
        tonemap.LightAdaptation = 0.5f;
        tonemap.ColorAdaptation = 0.4f;
        Assert.Equal(1.8f, tonemap.Intensity, 1e-3);
        Assert.Equal(0.5f, tonemap.LightAdaptation, 1e-3);
        Assert.Equal(0.4f, tonemap.ColorAdaptation, 1e-3);
    }
}
