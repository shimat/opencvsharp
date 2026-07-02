using Xunit;

namespace OpenCvSharp.Tests.Calib3D;

// Coverage for the Cv2.FishEye.* ArrayProxy-migrated methods that were not
// otherwise exercised (issue #1976 follow-up: every migrated method needs >=1 test).
public class FishEyeTest : TestBase
{
    private static readonly double[] CameraMatrixValues =
    {
        300, 0, 160,
        0, 300, 120,
        0, 0, 1
    };

    private static readonly double[] DistCoeffsValues = { 0.1, 0.01, 0.0, 0.0 };

    private static Mat CameraMatrix() => Mat.FromPixelData(3, 3, MatType.CV_64FC1, CameraMatrixValues);

    private static Mat DistCoeffs() => Mat.FromPixelData(4, 1, MatType.CV_64FC1, DistCoeffsValues);

    [Fact]
    public void UndistortPoints()
    {
        var pts = new[] { new Point2f(150, 110), new Point2f(170, 130), new Point2f(160, 120) };
        using var distorted = Mat.FromPixelData(pts.Length, 1, MatType.CV_32FC2, pts);
        using var undistorted = new Mat();
        using var k = CameraMatrix();
        using var d = DistCoeffs();

        Cv2.FishEye.UndistortPoints(distorted, undistorted, k, d);

        Assert.Equal(pts.Length, (int) undistorted.Total());
        Assert.False(undistorted.Empty());
    }

    [Fact]
    public void InitUndistortRectifyMap()
    {
        using var k = CameraMatrix();
        using var d = DistCoeffs();
        using var r = Mat.EyeMat(3, 3, MatType.CV_64FC1);
        using var p = CameraMatrix();
        var size = new Size(320, 240);

        using var map1 = new Mat();
        using var map2 = new Mat();
        Cv2.FishEye.InitUndistortRectifyMap(k, d, r, p, size, (int) MatType.CV_32FC1, map1, map2);

        Assert.Equal(size, map1.Size());
        Assert.Equal(size, map2.Size());
        Assert.False(map1.Empty());
        Assert.False(map2.Empty());
    }

    [Fact]
    public void UndistortImage()
    {
        using var distorted = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var undistorted = new Mat();
        using var k = CameraMatrix();
        using var d = DistCoeffs();

        Cv2.FishEye.UndistortImage(distorted, undistorted, k, d);

        Assert.False(undistorted.Empty());
        Assert.Equal(distorted.Size(), undistorted.Size());
    }

    [Fact]
    public void EstimateNewCameraMatrixForUndistortRectify()
    {
        using var k = CameraMatrix();
        using var d = DistCoeffs();
        using var r = Mat.EyeMat(3, 3, MatType.CV_64FC1);
        using var p = new Mat();
        var imageSize = new Size(320, 240);

        Cv2.FishEye.EstimateNewCameraMatrixForUndistortRectify(k, d, imageSize, r, p);

        Assert.Equal(3, p.Rows);
        Assert.Equal(3, p.Cols);
        Assert.False(p.Empty());
    }

    [Fact]
    public void StereoRectify()
    {
        using var k1 = CameraMatrix();
        using var d1 = DistCoeffs();
        using var k2 = CameraMatrix();
        using var d2 = DistCoeffs();
        using var r = Mat.EyeMat(3, 3, MatType.CV_64FC1);
        using var tvec = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new[] { -0.1, 0.0, 0.0 });

        using var r1 = new Mat();
        using var r2 = new Mat();
        using var p1 = new Mat();
        using var p2 = new Mat();
        using var q = new Mat();

        Cv2.FishEye.StereoRectify(
            k1, d1, k2, d2, new Size(320, 240), r, tvec,
            r1, r2, p1, p2, q, FishEyeCalibrationFlags.None);

        Assert.Equal(3, r1.Rows);
        Assert.Equal(3, r1.Cols);
        Assert.Equal(3, r2.Rows);
        Assert.Equal(3, r2.Cols);
        Assert.Equal(4, q.Rows);
        Assert.Equal(4, q.Cols);
        Assert.False(p1.Empty());
        Assert.False(p2.Empty());
    }
}
