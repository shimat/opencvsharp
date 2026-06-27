using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

// Tests for the OpenCV 5 imgproc additions: INTER_NEAREST_EXACT, the Filter2DParams-based
// filter2D overload, and findContoursLinkRuns.
public class ImgProcMediumTest : TestBase
{
    [Fact]
    public void NearestExactEnumValue()
    {
        Assert.Equal(6, (int)InterpolationFlags.NearestExact);
    }

    [Fact]
    public void ResizeNearestExact()
    {
        using var src = Mat.FromPixelData(2, 2, MatType.CV_8UC1, new byte[] { 0, 255, 255, 0 });
        using var dst = new Mat();
        Cv2.Resize(src, dst, new Size(4, 4), 0, 0, InterpolationFlags.NearestExact);

        Assert.Equal(4, dst.Rows);
        Assert.Equal(4, dst.Cols);
    }

    [Fact]
    public void Filter2DWithParams()
    {
        using var src = new Mat(5, 5, MatType.CV_8UC1, Scalar.All(10));
        using var kernel = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new[] { 1.0f });
        using var dst = new Mat();

        // scale = 2 -> each pixel becomes 10 * 1 * 2 = 20.
        Cv2.Filter2D(src, dst, kernel, new Filter2DParams { Scale = 2.0 });

        Assert.Equal(MatType.CV_8UC1, dst.Type());
        Assert.Equal(20, dst.At<byte>(2, 2));
    }

    [Fact]
    public void Filter2DWithDefaultParams()
    {
        using var src = new Mat(5, 5, MatType.CV_8UC1, Scalar.All(10));
        using var kernel = Mat.FromPixelData(1, 1, MatType.CV_32FC1, new[] { 1.0f });
        using var dst = new Mat();

        Cv2.Filter2D(src, dst, kernel);

        Assert.Equal(10, dst.At<byte>(2, 2));
    }

    [Fact]
    public void FindContoursLinkRunsWithHierarchy()
    {
        using var img = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(img, new Rect(20, 20, 40, 40), Scalar.All(255), -1);

        Cv2.FindContoursLinkRuns(img, out var contours, out var hierarchy);

        Assert.NotEmpty(contours);
        Assert.Equal(contours.Length, hierarchy.Length);
    }

    [Fact]
    public void FindContoursLinkRunsWithoutHierarchy()
    {
        using var img = new Mat(100, 100, MatType.CV_8UC1, Scalar.All(0));
        Cv2.Rectangle(img, new Rect(20, 20, 40, 40), Scalar.All(255), -1);

        Cv2.FindContoursLinkRuns(img, out var contours);

        Assert.NotEmpty(contours);
    }
}
