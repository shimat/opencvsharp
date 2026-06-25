using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

// Tests for the OpenCV 5 AlgorithmHint parameter added to warpAffine / warpPerspective /
// remap / GaussianBlur / cvtColor / cvtColorTwoPlane.
public class AlgorithmHintTest : TestBase
{
    [Theory]
    [InlineData(AlgorithmHint.Default)]
    [InlineData(AlgorithmHint.Accurate)]
    [InlineData(AlgorithmHint.Approx)]
    public void GaussianBlurWithHint(AlgorithmHint hint)
    {
        using var src = new Mat(20, 20, MatType.CV_8UC1, Scalar.All(128));
        using var dst = new Mat();
        Cv2.GaussianBlur(src, dst, new Size(3, 3), 0, 0, BorderTypes.Default, hint);
        Assert.Equal(src.Size(), dst.Size());
    }

    [Theory]
    [InlineData(AlgorithmHint.Default)]
    [InlineData(AlgorithmHint.Accurate)]
    public void CvtColorWithHint(AlgorithmHint hint)
    {
        using var src = new Mat(16, 16, MatType.CV_8UC3, new Scalar(10, 20, 30));
        using var dst = new Mat();
        Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY, 0, hint);
        Assert.Equal(1, dst.Channels());
        Assert.Equal(src.Size(), dst.Size());
    }

    [Fact]
    public void WarpAffineWithHint()
    {
        using var src = new Mat(16, 16, MatType.CV_8UC1, Scalar.All(200));
        using var m = Mat.FromPixelData(2, 3, MatType.CV_64FC1, new double[] { 1, 0, 2, 0, 1, 3 });
        using var dst = new Mat();
        Cv2.WarpAffine(src, dst, m, new Size(16, 16),
            InterpolationFlags.Linear, BorderTypes.Constant, null, AlgorithmHint.Accurate);
        Assert.Equal(new Size(16, 16), dst.Size());
    }

    [Fact]
    public void WarpPerspectiveWithHint()
    {
        using var src = new Mat(16, 16, MatType.CV_8UC1, Scalar.All(200));
        using var m = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 });
        using var dst = new Mat();
        Cv2.WarpPerspective(src, dst, m, new Size(16, 16),
            InterpolationFlags.Linear, BorderTypes.Constant, null, AlgorithmHint.Accurate);
        Assert.Equal(new Size(16, 16), dst.Size());
    }

    [Fact]
    public void RemapWithHint()
    {
        using var src = new Mat(8, 8, MatType.CV_8UC1, Scalar.All(100));
        using var mapX = new Mat(8, 8, MatType.CV_32FC1);
        using var mapY = new Mat(8, 8, MatType.CV_32FC1);
        for (var y = 0; y < 8; y++)
        {
            for (var x = 0; x < 8; x++)
            {
                mapX.Set(y, x, (float)x);
                mapY.Set(y, x, (float)y);
            }
        }

        using var dst = new Mat();
        Cv2.Remap(src, dst, mapX, mapY,
            InterpolationFlags.Linear, BorderTypes.Constant, null, AlgorithmHint.Accurate);

        // Identity remap -> output equals input.
        Assert.Equal(src.Size(), dst.Size());
        Assert.Equal(100, dst.At<byte>(4, 4));
    }
}
