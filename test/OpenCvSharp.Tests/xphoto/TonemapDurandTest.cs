using OpenCvSharp.XPhoto;
using Xunit;

namespace OpenCvSharp.Tests.XPhoto;

public class TonemapDurandTest : TestBase
{
    [Fact]
    public void Process()
    {
        using var src = LoadImage("lenna.png");
        using var dst = new Mat();
        using var tonemap = TonemapDurand.Create();

        // 8UC3 -> 32FC3
        using var src32f = new Mat();
        src.ConvertTo(src32f, MatType.CV_32FC3);

        tonemap.Process(src32f, dst);

        ShowImagesWhenDebugMode(dst);
    }

    [Fact]
    public void Properties()
    {
        using var tonemap = TonemapDurand.Create(1.2f, 3.0f, 1.5f, 2.2f, 1.3f);
        Assert.Equal(3.0f, tonemap.Contrast, 1e-3);
        Assert.Equal(1.5f, tonemap.Saturation, 1e-3);
            
        // TODO OpenCV bug https://github.com/opencv/opencv_contrib/pull/2398
        //Assert.Equal(2.2f, tonemap.SigmaSpace, 3);
        //Assert.Equal(1.3f, tonemap.SigmaColor, 3);
            
        tonemap.Contrast = 3.5f;
        tonemap.Saturation = 2.0f;
        tonemap.SigmaSpace = 2.5f;
        tonemap.SigmaColor = 2.5f;
        Assert.Equal(3.5f, tonemap.Contrast, 1e-3);
        Assert.Equal(2.0f, tonemap.Saturation, 1e-3);
        //Assert.Equal(2.5f, tonemap.SigmaSpace, 3);
        //Assert.Equal(2.5f, tonemap.SigmaColor, 3);
    }
}
