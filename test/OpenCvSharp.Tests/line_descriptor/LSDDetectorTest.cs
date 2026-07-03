#pragma warning disable CA5394 // Do not use insecure randomness

using System.Diagnostics;
using OpenCvSharp.LineDescriptor;
using Xunit;

namespace OpenCvSharp.Tests.LineDescriptor;

// ReSharper disable once InconsistentNaming
public class LSDDetectorTest : TestBase
{
    [Fact]
    public void New()
    {
        using var lsd = new LSDDetector();
        GC.KeepAlive(lsd);
    }

    [Fact]
    public void NewWithParam()
    {
        var lsdParam = new LSDParam();
        using var lsd = new LSDDetector(lsdParam);
        GC.KeepAlive(lsd);
    }

    [Fact]
    public void Detect()
    {
        using var src = LoadImage("building.jpg");
        using var gray = new Mat();
        Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

        using var lsd = new LSDDetector();
        var keyLines = lsd.Detect(gray, 2, 1);
        Assert.NotEmpty(keyLines);

        foreach (var kl in keyLines)
        {
            Assert.True(kl.LineLength > 0);
            Assert.True(kl.NumOfPixels > 0);
        }

        if (Debugger.IsAttached)
        {
            var random = new Random();

            foreach (var kl in keyLines)
            {
                var color = new Scalar(random.Next(256), random.Next(256), random.Next(256));
                Cv2.Line(src, (Point)kl.StartPoint, (Point)kl.EndPoint, color, 3);
            }

            Window.ShowImages(src);
        }
    }

    [Fact]
    public void DetectMultipleImages()
    {
        using var src1 = LoadImage("building.jpg");
        using var src2 = LoadImage("lenna.png");
        using var gray1 = new Mat();
        using var gray2 = new Mat();
        Cv2.CvtColor(src1, gray1, ColorConversionCodes.BGR2GRAY);
        Cv2.CvtColor(src2, gray2, ColorConversionCodes.BGR2GRAY);

        using var lsd = new LSDDetector();
        var keyLines = lsd.Detect([gray1, gray2], 2, 1);

        Assert.Equal(2, keyLines.Length);
        Assert.NotEmpty(keyLines[0]);
        Assert.NotEmpty(keyLines[1]);
    }

    [Fact]
    public void DetectMultipleImagesWithMoreMasksThanImages()
    {
        using var src1 = LoadImage("building.jpg");
        using var gray1 = new Mat();
        Cv2.CvtColor(src1, gray1, ColorConversionCodes.BGR2GRAY);
        using var mask1 = new Mat(gray1.Size(), MatType.CV_8UC1, Scalar.All(255));
        using var mask2 = new Mat(gray1.Size(), MatType.CV_8UC1, Scalar.All(255));

        using var lsd = new LSDDetector();
        // More masks than images: the native wrapper must not write past the
        // pre-sized (images.Length) masks vector.
        var keyLines = lsd.Detect([gray1], 2, 1, [mask1, mask2]);

        Assert.Single(keyLines);
    }
}
