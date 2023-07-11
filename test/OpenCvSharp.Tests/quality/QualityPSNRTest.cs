using OpenCvSharp.Quality;
using Xunit;

#pragma warning disable 162

namespace OpenCvSharp.Tests.Quality;

// ReSharper disable once InconsistentNaming
public class QualityPSNRTest : TestBase
{
    [Fact]
    public void Compute()
    {
        using (var refImage = LoadImage("lenna.png"))
        using (var targetImage = new Mat())
        using (var psnr = QualityPSNR.Create(refImage))
        {
            Cv2.GaussianBlur(refImage, targetImage, new Size(5, 5), 15);

            var value = psnr.Compute(targetImage);
            Assert.Equal(28.893586, value[0], 6);
            Assert.Equal(28.26987, value[1], 6);
            Assert.Equal(31.088282, value[2], 6);
        }
    }

    [Fact]
    public void StaticCompute()
    {
        using (var refImage = LoadImage("lenna.png"))
        using (var targetImage = new Mat())
        {
            Cv2.GaussianBlur(refImage, targetImage, new Size(5, 5), 15);

            var value = QualityPSNR.Compute(refImage, targetImage, null);
            Assert.Equal(28.893586, value[0], 6);
            Assert.Equal(28.26987, value[1], 6);
            Assert.Equal(31.088282, value[2], 6);
        }
    }

    [Fact]
    public void PropertyMaxPixelValue()
    {
        using (var refImage = LoadImage("lenna.png"))
        using (var psnr = QualityPSNR.Create(refImage))
        {
            const double value = 123.456;
            psnr.MaxPixelValue = value;
            Assert.Equal(value, psnr.MaxPixelValue, 6);
        }
    }
}

// ReSharper disable once InconsistentNaming
