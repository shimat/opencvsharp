using Xunit;

namespace OpenCvSharp.Tests.Calib3D;

// Tests for the OpenCV 5 geometry/calib functions added to OpenCvSharp:
// SolvePnPRefineLM/VVS, DecomposeEssentialMat, EstimateTranslation2D/3D and the
// fisheye DistortPoints overload with a separate undistorted-camera matrix.
public class GeometryFunctionsTest : TestBase
{
    private static readonly double[,] CameraMatrix =
    {
        { 800, 0, 320 },
        { 0, 800, 240 },
        { 0, 0, 1 }
    };

    private static Point3f[] ObjectPoints => new[]
    {
        new Point3f(0, 0, 0), new Point3f(1, 0, 0), new Point3f(0, 1, 0), new Point3f(1, 1, 0),
        new Point3f(0, 0, 1), new Point3f(1, 0, 1), new Point3f(0, 1, 1), new Point3f(1, 1, 1)
    };

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void SolvePnPRefine(bool useVvs)
    {
        var rvecTrue = new[] { 0.1, -0.05, 0.02 };
        var tvecTrue = new[] { 0.1, 0.2, -8.0 };
        var dist = new double[5];
        var objPts = ObjectPoints;

        Cv2.ProjectPoints(objPts, rvecTrue, tvecTrue, CameraMatrix, dist, out var imgPts, out _);

        using var objMat = Mat.FromPixelData(objPts.Length, 1, MatType.CV_32FC3, objPts);
        using var imgMat = Mat.FromPixelData(imgPts.Length, 1, MatType.CV_32FC2, imgPts);
        using var camMat = Mat.FromPixelData(3, 3, MatType.CV_64FC1, CameraMatrix);
        using var distMat = Mat.FromPixelData(5, 1, MatType.CV_64FC1, dist);
        using var rvecMat = Mat.FromPixelData(3, 1, MatType.CV_64FC1, (double[])rvecTrue.Clone());
        using var tvecMat = Mat.FromPixelData(3, 1, MatType.CV_64FC1, (double[])tvecTrue.Clone());

        // Starting from the exact solution, the refinement must keep the pose near the truth.
        if (useVvs)
            Cv2.SolvePnPRefineVVS(objMat, imgMat, camMat, distMat, rvecMat, tvecMat);
        else
            Cv2.SolvePnPRefineLM(objMat, imgMat, camMat, distMat, rvecMat, tvecMat);

        for (var i = 0; i < 3; i++)
        {
            Assert.True(Math.Abs(rvecMat.Get<double>(i) - rvecTrue[i]) < 1e-3, $"rvec[{i}]");
            Assert.True(Math.Abs(tvecMat.Get<double>(i) - tvecTrue[i]) < 1e-3, $"tvec[{i}]");
        }
    }

    [Fact]
    public void DecomposeEssentialMat()
    {
        // E = [t]_x * R, with R = I and t = (0, 0, 1)  =>  E = [[0,-1,0],[1,0,0],[0,0,0]]
        using var e = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
        {
            0, -1, 0,
            1, 0, 0,
            0, 0, 0
        });
        using var r1 = new Mat();
        using var r2 = new Mat();
        using var t = new Mat();

        Cv2.DecomposeEssentialMat(e, r1, r2, t);

        Assert.Equal(3, r1.Rows);
        Assert.Equal(3, r1.Cols);
        Assert.Equal(3, r2.Rows);
        Assert.Equal(3, r2.Cols);
        Assert.Equal(3, (int)t.Total());

        // Both candidate rotations must be proper rotation matrices.
        Assert.True(Math.Abs(Cv2.Determinant(r1) - 1.0) < 1e-6);
        Assert.True(Math.Abs(Cv2.Determinant(r2) - 1.0) < 1e-6);

        // The translation is recovered up to scale (unit norm) along z.
        using var tD = new Mat();
        t.ConvertTo(tD, MatType.CV_64F);
        var norm = Math.Sqrt(
            (tD.Get<double>(0) * tD.Get<double>(0)) +
            (tD.Get<double>(1) * tD.Get<double>(1)) +
            (tD.Get<double>(2) * tD.Get<double>(2)));
        Assert.True(Math.Abs(norm - 1.0) < 1e-6);
        Assert.True(Math.Abs(tD.Get<double>(2)) > 0.99);
    }

    [Fact]
    public void EstimateTranslation3D()
    {
        var t = new[] { 1.0, 2.0, 3.0 };

        // Use exactly the minimal sample size (4 points) so the estimator solves directly
        // instead of going through random RANSAC sampling (deterministic result).
        var src = new float[]
        {
            0, 0, 0,
            10, 0, 0,
            0, 10, 0,
            0, 0, 10
        };
        var dst = new float[src.Length];
        for (var i = 0; i < src.Length; i++)
            dst[i] = (float)(src[i] + t[i % 3]);

        using var srcMat = Mat.FromPixelData(4, 1, MatType.CV_32FC3, src);
        using var dstMat = Mat.FromPixelData(4, 1, MatType.CV_32FC3, dst);
        using var outMat = new Mat();
        using var inliers = new Mat();

        var found = Cv2.EstimateTranslation3D(srcMat, dstMat, outMat, inliers);
        Assert.True(found);

        using var outD = new Mat();
        outMat.ConvertTo(outD, MatType.CV_64F);
        outD.GetArray(out double[] outVals);
        Assert.Equal(3, outVals.Length);
        Assert.True(Math.Abs(outVals[0] - t[0]) < 1e-2);
        Assert.True(Math.Abs(outVals[1] - t[1]) < 1e-2);
        Assert.True(Math.Abs(outVals[2] - t[2]) < 1e-2);
    }

    [Fact]
    public void EstimateTranslation2D()
    {
        var tx = 5.0;
        var ty = -3.0;
        var from = new Point2f[20];
        var to = new Point2f[20];
        var rng = new Random(7);
        for (var i = 0; i < from.Length; i++)
        {
            from[i] = new Point2f((float)rng.NextDouble() * 100, (float)rng.NextDouble() * 100);
            to[i] = new Point2f((float)(from[i].X + tx), (float)(from[i].Y + ty));
        }

        using var fromMat = Mat.FromPixelData(from.Length, 1, MatType.CV_32FC2, from);
        using var toMat = Mat.FromPixelData(to.Length, 1, MatType.CV_32FC2, to);

        var result = Cv2.EstimateTranslation2D(fromMat, toMat);
        Assert.True(Math.Abs(result.Item0 - tx) < 1e-2);
        Assert.True(Math.Abs(result.Item1 - ty) < 1e-2);
    }

    [Fact]
    public void FishEyeDistortPointsWithUndistortedMatrix()
    {
        var pts = new[] { new Point2f(0.1f, 0.05f), new Point2f(-0.2f, 0.15f), new Point2f(0.0f, 0.0f) };
        using var undistorted = Mat.FromPixelData(pts.Length, 1, MatType.CV_32FC2, pts);
        using var distorted = new Mat();
        using var k = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
        {
            300, 0, 160,
            0, 300, 120,
            0, 0, 1
        });
        using var kUndistorted = k.Clone();
        using var d = Mat.FromPixelData(4, 1, MatType.CV_64FC1, new[] { 0.1, 0.01, 0.0, 0.0 });

        Cv2.FishEye.DistortPoints(undistorted, distorted, kUndistorted, k, d);

        Assert.Equal(pts.Length, (int)distorted.Total());
    }
}
