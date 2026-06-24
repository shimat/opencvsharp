using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

// Tests for the OpenCV 5 built-in TrueType text rendering (FontFace + FontFace-based
// PutText / GetTextSize + PutTextFlags).
public class FontFaceTest : TestBase
{
    [Fact]
    public void CreateDefault()
    {
        using var ff = new FontFace();
        Assert.NotNull(ff.Name);
    }

    [Theory]
    [InlineData("sans")]
    [InlineData("uni")]
    public void CreateEmbedded(string name)
    {
        using var ff = new FontFace(name);
        Assert.False(string.IsNullOrEmpty(ff.Name));
    }

    [Fact]
    public void GetTextSizeReturnsPositive()
    {
        using var ff = new FontFace();
        var rect = Cv2.GetTextSize(new Size(400, 200), "Hello", new Point(0, 100), ff, 32);
        Assert.True(rect.Width > 0, "width should be positive");
        Assert.True(rect.Height > 0, "height should be positive");
    }

    [Fact]
    public void PutTextDrawsPixels()
    {
        using var img = new Mat(200, 400, MatType.CV_8UC1, Scalar.All(0));
        using var ff = new FontFace();

        var next = Cv2.PutText(img, "Hello", new Point(10, 100), Scalar.All(255), ff, 32);

        Assert.True(Cv2.CountNonZero(img) > 0, "text should have drawn some pixels");
        Assert.True(next.X > 10, "cursor should advance to the right");
    }

    [Fact]
    public void PutTextUnicode()
    {
        using var img = new Mat(200, 400, MatType.CV_8UC1, Scalar.All(0));
        using var ff = new FontFace("uni");

        // Greek + cyrillic characters require a Unicode-capable font.
        Cv2.PutText(img, "Δλ Привет", new Point(10, 100), Scalar.All(255), ff, 32);

        Assert.True(Cv2.CountNonZero(img) > 0, "unicode text should have drawn some pixels");
    }

    [Fact]
    public void SetAndGetInstance()
    {
        using var ff = new FontFace();

        // 'wght' axis = CV_FOURCC('w','g','h','t'); value in 16.16 fixed point (700.0).
        var wght = 'w' | ('g' << 8) | ('h' << 16) | ('t' << 24);
        ff.SetInstance(new[] { wght, 700 << 16 });

        // Must reach OpenCV without a P/Invoke failure; the exact contents are font-dependent.
        ff.GetInstance(out var instance);
        Assert.NotNull(instance);
    }
}
