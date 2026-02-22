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

        mask.Rectangle(new Rect(65, 15, 130, 30), Scalar.All(255), -1);

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

        Cv2.FastNlMeansDenoisingMulti(new[] { src1, src2, src3 }, dst, 1, 3, 3, 3, 7);

        if (Debugger.IsAttached)
            Window.ShowImages(src1, src2, dst);
    }
}
