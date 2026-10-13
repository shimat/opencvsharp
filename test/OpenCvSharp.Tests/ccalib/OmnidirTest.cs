using Xunit;

namespace OpenCvSharp.Tests.Ccalib;

public class OmnidirTest : TestBase
{
    [Fact]
    public void ProjectsAndUndistortsCenterPoint()
    {
        using var objectPoints = new Mat(1, 1, MatType.CV_64FC3);
        objectPoints.At<Vec3d>(0, 0) = new Vec3d(0, 0, 1);
        using var imagePoints = new Mat();
        using var rvec = Mat.Zeros(3, 1, MatType.CV_64FC1).ToMat();
        using var tvec = Mat.Zeros(3, 1, MatType.CV_64FC1).ToMat();
        using var k = CreateCameraMatrix();
        using var d = Mat.Zeros(1, 4, MatType.CV_64FC1).ToMat();
        using var xi = new Mat(1, 1, MatType.CV_64FC1, Scalar.All(1));

        Cv2.Omnidir.ProjectPoints(objectPoints, imagePoints, rvec, tvec, k, 1, d);

        var projected = imagePoints.At<Vec2d>(0, 0);
        Assert.Equal(32, projected.Item0, 5);
        Assert.Equal(32, projected.Item1, 5);

        using var undistorted = new Mat();
        using var rotation = Mat.Eye(3, 3, MatType.CV_64FC1).ToMat();
        Cv2.Omnidir.UndistortPoints(imagePoints, undistorted, k, d, xi, rotation);

        var normalized = undistorted.At<Vec2d>(0, 0);
        Assert.Equal(0, normalized.Item0, 5);
        Assert.Equal(0, normalized.Item1, 5);
    }

    [Fact]
    public void BuildsRectificationMapsAndImage()
    {
        using var k = CreateCameraMatrix();
        using var d = Mat.Zeros(1, 4, MatType.CV_64FC1).ToMat();
        using var xi = new Mat(1, 1, MatType.CV_64FC1, Scalar.All(1));
        using var rotation = Mat.Eye(3, 3, MatType.CV_64FC1).ToMat();
        using var map1 = new Mat();
        using var map2 = new Mat();

        Cv2.Omnidir.InitUndistortRectifyMap(k, d, xi, rotation, k,
            new Size(64, 64), MatType.CV_32FC1, map1, map2);

        Assert.Equal(new Size(64, 64), map1.Size());
        Assert.Equal(MatType.CV_32FC1, map1.Type());
        Assert.Equal(MatType.CV_32FC1, map2.Type());

        using var source = new Mat(64, 64, MatType.CV_8UC1, Scalar.All(128));
        using var rectified = new Mat();
        Cv2.Omnidir.UndistortImage(source, rectified, k, d, xi);
        Assert.Equal(source.Size(), rectified.Size());
        Assert.Equal(source.Type(), rectified.Type());
    }

    private static Mat CreateCameraMatrix()
    {
        var k = Mat.Eye(3, 3, MatType.CV_64FC1).ToMat();
        k.Set(0, 0, 100d);
        k.Set(1, 1, 100d);
        k.Set(0, 2, 32d);
        k.Set(1, 2, 32d);
        return k;
    }
}
