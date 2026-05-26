using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

public class LineSegmentDetectorTest : TestBase
{
    [Fact]
    public void CreateAndDetect()
    {
        using var image = new Mat(500, 500, MatType.CV_8UC1, Scalar.All(255));
        Cv2.Line(image, new Point(50, 50), new Point(450, 50), new Scalar(0, 0, 0), 2);

        using var lsd = LineSegmentDetector.Create();
        Assert.NotEqual(IntPtr.Zero, lsd.RawPtr);

        lsd.Detect(image, out var lines, out _, out _, out _);
        Assert.NotEmpty(lines);
    }

    [Fact]
    public void DetectOutputArray()
    {
        using var image = new Mat(500, 500, MatType.CV_8UC1, Scalar.All(255));
        Cv2.Line(image, new Point(50, 50), new Point(450, 50), new Scalar(0, 0, 0), 2);

        using var lsd = LineSegmentDetector.Create();
        using var lines = new Mat();
        lsd.Detect(image, lines);
        Assert.False(lines.Empty());
    }
}
