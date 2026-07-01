using Xunit;

namespace OpenCvSharp.Tests.ImgProc;

// Coverage for the Cv2.Undistort/DrawFrameAxes/InitUndistortRectifyMap/InitWideAngleProjMap
// ArrayProxy-migrated methods that were not otherwise exercised (issue #1976 follow-up:
// every migrated method needs >=1 test).
public class UndistortTest : TestBase
{
    private static Mat CameraMatrix() => Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
    {
        300, 0, 160,
        0, 300, 120,
        0, 0, 1
    });

    private static Mat DistCoeffs() => Mat.FromPixelData(5, 1, MatType.CV_64FC1, new[] { 0.1, 0.01, 0.0, 0.0, 0.0 });

    [Fact]
    public void Undistort()
    {
        using var src = LoadImage("lenna.png", ImreadModes.Grayscale);
        using var dst = new Mat();
        using var k = CameraMatrix();
        using var d = DistCoeffs();

        Cv2.Undistort(src, dst, k, d);

        Assert.Equal(src.Size(), dst.Size());
        Assert.False(dst.Empty());
    }

    [Fact]
    public void InitUndistortRectifyMap()
    {
        using var k = CameraMatrix();
        using var d = DistCoeffs();
        using var r = Mat.EyeMat(3, 3, MatType.CV_64FC1);
        using var newK = CameraMatrix();
        var size = new Size(320, 240);

        using var map1 = new Mat();
        using var map2 = new Mat();
        Cv2.InitUndistortRectifyMap(k, d, r, newK, size, MatType.CV_32FC1, map1, map2);

        Assert.Equal(size, map1.Size());
        Assert.Equal(size, map2.Size());
        Assert.False(map1.Empty());
        Assert.False(map2.Empty());
    }

    [Fact]
    public void InitWideAngleProjMap()
    {
        using var k = CameraMatrix();
        using var d = DistCoeffs();
        using var map1 = new Mat();
        using var map2 = new Mat();

        var scale = Cv2.InitWideAngleProjMap(
            k, d, new Size(320, 240), 640, MatType.CV_32FC1, map1, map2, ProjectionType.SphericalEqRect);

        Assert.False(float.IsNaN(scale));
        Assert.False(map1.Empty());
        Assert.False(map2.Empty());
    }

    [Fact]
    public void DrawFrameAxes()
    {
        using var image = Mat.ZerosMat(240, 320, MatType.CV_8UC3);
        using var k = CameraMatrix();
        using var d = DistCoeffs();
        using var rvec = Mat.ZerosMat(3, 1, MatType.CV_64FC1);
        using var tvec = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new[] { 0.0, 0.0, 1.0 });

        Cv2.DrawFrameAxes(image, k, d, rvec, tvec, 1.0f);

        // Drawing the axes must have painted some non-zero (colored) pixels onto the black image.
        Assert.True(Cv2.CountNonZero(image.Reshape(1)) > 0);
    }
}
