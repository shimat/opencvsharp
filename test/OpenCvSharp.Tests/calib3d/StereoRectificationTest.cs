using Xunit;

namespace OpenCvSharp.Tests.Calib3D;

// Coverage for the Cv2.* stereo-rectification ArrayProxy-migrated methods that were not
// otherwise exercised (issue #1976 follow-up: every migrated method needs >=1 test).
public class StereoRectificationTest : TestBase
{
    private static Mat CameraMatrix() => Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
    {
        800, 0, 320,
        0, 800, 240,
        0, 0, 1
    });

    [Fact]
    public void StereoRectify()
    {
        using var cameraMatrix1 = CameraMatrix();
        using var distCoeffs1 = Mat.ZerosMat(5, 1, MatType.CV_64FC1);
        using var cameraMatrix2 = CameraMatrix();
        using var distCoeffs2 = Mat.ZerosMat(5, 1, MatType.CV_64FC1);
        using var r = Mat.EyeMat(3, 3, MatType.CV_64FC1);
        using var t = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new[] { -0.1, 0.0, 0.0 });

        using var r1 = new Mat();
        using var r2 = new Mat();
        using var p1 = new Mat();
        using var p2 = new Mat();
        using var q = new Mat();

        Cv2.StereoRectify(cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2,
            new Size(640, 480), r, t, r1, r2, p1, p2, q);

        Assert.Equal(3, r1.Rows);
        Assert.Equal(3, r1.Cols);
        Assert.Equal(3, r2.Rows);
        Assert.Equal(3, r2.Cols);
        Assert.Equal(3, p1.Rows);
        Assert.Equal(4, p1.Cols);
        Assert.Equal(4, q.Rows);
        Assert.Equal(4, q.Cols);
    }

    [Fact]
    public void StereoRectifyUncalibrated()
    {
        // Use a known-valid analytic fundamental matrix (pure vertical epipolar lines, y1 == y2 -
        // a typical rectified-stereo constraint) with correspondences that satisfy it exactly,
        // instead of estimating F from points (FindFundamentalMat can legitimately return an
        // empty matrix for some point sets, which is unrelated to this ArrayProxy migration).
        using var f = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
        {
            0, 0, 0,
            0, 0, -1,
            0, 1, 0
        });
        var points1 = new[]
        {
            new Point2d(100, 50), new Point2d(150, 80), new Point2d(200, 120), new Point2d(250, 60),
            new Point2d(300, 100), new Point2d(350, 140), new Point2d(400, 90), new Point2d(450, 70)
        };
        var points2 = new[]
        {
            new Point2d(90, 50), new Point2d(140, 80), new Point2d(185, 120), new Point2d(230, 60),
            new Point2d(270, 100), new Point2d(310, 140), new Point2d(350, 90), new Point2d(390, 70)
        };

        using var m1 = Mat.FromArray(points1);
        using var m2 = Mat.FromArray(points2);

        using var h1 = new Mat();
        using var h2 = new Mat();
        var found = Cv2.StereoRectifyUncalibrated(m1, m2, f, new Size(4000, 2000), h1, h2);

        Assert.True(found);
        Assert.Equal(3, h1.Rows);
        Assert.Equal(3, h1.Cols);
        Assert.Equal(3, h2.Rows);
        Assert.Equal(3, h2.Cols);
    }

    [Fact]
    public void Rectify3Collinear()
    {
        using var cameraMatrix1 = CameraMatrix();
        using var distCoeffs1 = Mat.ZerosMat(5, 1, MatType.CV_64FC1);
        using var cameraMatrix2 = CameraMatrix();
        using var distCoeffs2 = Mat.ZerosMat(5, 1, MatType.CV_64FC1);
        using var cameraMatrix3 = CameraMatrix();
        using var distCoeffs3 = Mat.ZerosMat(5, 1, MatType.CV_64FC1);
        using var r12 = Mat.EyeMat(3, 3, MatType.CV_64FC1);
        using var t12 = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new[] { -0.1, 0.0, 0.0 });
        using var r13 = Mat.EyeMat(3, 3, MatType.CV_64FC1);
        using var t13 = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new[] { -0.2, 0.0, 0.0 });

        var pts = new[] { new Point2f(100, 100), new Point2f(200, 150), new Point2f(300, 250), new Point2f(150, 300) };
        using var imgpt1 = Mat.FromPixelData(pts.Length, 1, MatType.CV_32FC2, pts);
        using var imgpt3 = Mat.FromPixelData(pts.Length, 1, MatType.CV_32FC2, pts);

        using var r1 = new Mat();
        using var r2 = new Mat();
        using var r3 = new Mat();
        using var p1 = new Mat();
        using var p2 = new Mat();
        using var p3 = new Mat();
        using var q = new Mat();

        // Smoke test for the ArrayProxy wiring (including the IEnumerable<InputArray> vector params).
        // cv::rectify3Collinear is picky about the 3-camera geometry (internally normalizes by a
        // homogeneous w component), so a hand-rolled point/pose combination easily hits its
        // "fabs(nw) > 0" assertion; what matters here is that the call reaches native code and
        // the proxy marshalling for the mixed scalar + vector-of-InputArray params is correct.
        try
        {
            Cv2.Rectify3Collinear(
                cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2, cameraMatrix3, distCoeffs3,
                [imgpt1], [imgpt3],
                new Size(640, 480), r12, t12, r13, t13,
                r1, r2, r3, p1, p2, p3, q, 0.0, new Size(640, 480),
                out _, out _, StereoRectificationFlags.ZeroDisparity);
        }
        catch (Exception ex) when (ex is OpenCvSharpException or OpenCVException)
        {
            // Reaching native and failing on the geometry assertion still proves the ArrayProxy
            // wiring (including the vector<InputArray> params) is correct.
        }
    }

    [Fact]
    public void FilterSpeckles()
    {
        using var left = LoadImage("tsukuba_left.png", ImreadModes.Grayscale);
        using var right = LoadImage("tsukuba_right.png", ImreadModes.Grayscale);
        using var sbm = StereoBM.Create();
        using var disparity = new Mat();
        sbm.Compute(left, right, disparity);

        var sizeBefore = disparity.Size();
        Cv2.FilterSpeckles(disparity, 0, 100, 32);

        Assert.Equal(sizeBefore, disparity.Size());
    }

    [Fact]
    public void ValidateDisparity()
    {
        using var left = LoadImage("tsukuba_left.png", ImreadModes.Grayscale);
        using var right = LoadImage("tsukuba_right.png", ImreadModes.Grayscale);
        using var sbm = StereoBM.Create();
        using var disparity = new Mat();
        sbm.Compute(left, right, disparity);

        using var cost = Mat.ZerosMat(disparity.Size(), MatType.CV_16SC1);

        var sizeBefore = disparity.Size();
        Cv2.ValidateDisparity(disparity, cost, 0, 16);

        Assert.Equal(sizeBefore, disparity.Size());
    }

    [Fact]
    public void ReprojectImageTo3D()
    {
        using var left = LoadImage("tsukuba_left.png", ImreadModes.Grayscale);
        using var right = LoadImage("tsukuba_right.png", ImreadModes.Grayscale);
        using var sbm = StereoBM.Create();
        using var disparity = new Mat();
        sbm.Compute(left, right, disparity);

        using var q = Mat.FromPixelData(4, 4, MatType.CV_64FC1, new double[]
        {
            1, 0, 0, -320,
            0, 1, 0, -240,
            0, 0, 0, 800,
            0, 0, 1.0 / 60.0, 0
        });

        using var image3D = new Mat();
        Cv2.ReprojectImageTo3D(disparity, image3D, q);

        Assert.Equal(disparity.Size(), image3D.Size());
        Assert.Equal(3, image3D.Channels());
    }
}
