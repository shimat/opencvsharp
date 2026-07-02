using System.Diagnostics;
using Xunit;

namespace OpenCvSharp.Tests.Photo;

public class PhotoTest
{
    [Fact]
    public void Inpaint()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var dst = new Mat();
        using var mask = new Mat(src.Size(), MatType.CV_8UC1, Scalar.All(0));

        Cv2.Rectangle(mask, new Rect(65, 15, 130, 30), Scalar.All(255), -1);

        Cv2.Inpaint(src, mask, dst, 2, InpaintTypes.Telea);

        if (Debugger.IsAttached)
            Window.ShowImages(src, mask, dst);
    }

    [Fact]
    public void FastNlMeansDenoising()
    {
        using var src = new Mat("_data/image/multipage_p1.tif", ImreadModes.Grayscale);
        using var dst = new Mat();

        Cv2.FastNlMeansDenoising(src, dst, 3, 3, 7);

        if (Debugger.IsAttached)
            Window.ShowImages(src, dst);
    }

    [Fact]
    public void FastNlMeansDenoisingMulti()
    {
        using var src1 = new Mat("_data/image/tsukuba_left.png", ImreadModes.Grayscale);
        using var src2 = new Mat("_data/image/tsukuba_right.png", ImreadModes.Grayscale);
        using var src3 = new Mat("_data/image/tsukuba_right.png", ImreadModes.Grayscale);
        using var dst = new Mat();

        Cv2.FastNlMeansDenoisingMulti([src1, src2, src3], dst, 1, 3, 3, 3, 7);

        if (Debugger.IsAttached)
            Window.ShowImages(src1, src2, dst);
    }

    // --- ArrayProxy migration coverage (issue #1976): one test per migrated Cv2 method ---

    [Fact]
    public void FastNlMeansDenoisingColored()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.FastNlMeansDenoisingColored(src, dst, 3, 3, 7, 21);

        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(src.Type(), dst.Type());
    }

    [Fact]
    public void FastNlMeansDenoisingColoredMulti()
    {
        using var src1 = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var src2 = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var src3 = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.FastNlMeansDenoisingColoredMulti([src1, src2, src3], dst, 1, 3, 3, 3, 7, 21);

        Assert.Equal(src1.Size(), dst.Size());
    }

    [Fact]
    public void Decolor()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var grayscale = new Mat();
        using var colorBoost = new Mat();
        Cv2.Decolor(src, grayscale, colorBoost);

        Assert.Equal(src.Size(), grayscale.Size());
        Assert.Equal(MatType.CV_8UC1, grayscale.Type());
        Assert.Equal(src.Size(), colorBoost.Size());
    }

    [Fact]
    public void SeamlessClone()
    {
        using var dst = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var src = new Mat(new Size(100, 100), MatType.CV_8UC3, new Scalar(0, 255, 0));
        using var mask = new Mat(src.Size(), MatType.CV_8UC1, Scalar.All(255));
        using var blend = new Mat();
        Cv2.SeamlessClone(src, dst, mask, new Point(dst.Width / 2, dst.Height / 2), blend, SeamlessCloneFlags.NormalClone);

        Assert.Equal(dst.Size(), blend.Size());
    }

    [Fact]
    public void ColorChange()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var mask = new Mat(src.Size(), MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(mask, new Rect(50, 50, 200, 200), Scalar.All(255), -1);
        using var dst = new Mat();
        Cv2.ColorChange(src, mask, dst, 1.5f, 0.5f, 1.0f);

        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void IlluminationChange()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var mask = new Mat(src.Size(), MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(mask, new Rect(50, 50, 200, 200), Scalar.All(255), -1);
        using var dst = new Mat();
        Cv2.IlluminationChange(src, mask, dst, 0.2f, 0.4f);

        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void TextureFlattening()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var mask = new Mat(src.Size(), MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(mask, new Rect(50, 50, 200, 200), Scalar.All(255), -1);
        using var dst = new Mat();
        Cv2.TextureFlattening(src, mask, dst, 30, 45, 3);

        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void EdgePreservingFilter()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.EdgePreservingFilter(src, dst, EdgePreservingMethods.RecursFilter, 60, 0.4f);

        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void DetailEnhance()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.DetailEnhance(src, dst, 10, 0.15f);

        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void PencilSketch()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var dst1 = new Mat();
        using var dst2 = new Mat();
        Cv2.PencilSketch(src, dst1, dst2, 60, 0.07f, 0.02f);

        Assert.Equal(src.Size(), dst1.Size());
        Assert.Equal(MatType.CV_8UC1, dst1.Type());
        Assert.Equal(src.Size(), dst2.Size());
    }

    [Fact]
    public void Stylization()
    {
        using var src = new Mat("_data/image/mandrill.png", ImreadModes.Color);
        using var dst = new Mat();
        Cv2.Stylization(src, dst, 60, 0.45f);

        Assert.Equal(src.Size(), dst.Size());
    }
}
