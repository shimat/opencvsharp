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
    public void CalibrationMatrixValues()
    {
        using var cameraMatrix = Mat.FromArray(CameraMatrix);

        Cv2.CalibrationMatrixValues(cameraMatrix, new Size(640, 480), 36, 24,
            out var fovx, out var fovy, out var focalLength, out _, out var aspectRatio);

        Assert.True(fovx > 0);
        Assert.True(fovy > 0);
        Assert.True(focalLength > 0);
        Assert.Equal(1.0, aspectRatio, 3); // fx == fy above
    }

    [Fact]
    public void ComposeRT()
    {
        // Two pure translations (no rotation) compose by simply adding the translations.
        using var rvec1 = Mat.ZerosMat(3, 1, MatType.CV_64FC1);
        using var tvec1 = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new[] { 1.0, 0.0, 0.0 });
        using var rvec2 = Mat.ZerosMat(3, 1, MatType.CV_64FC1);
        using var tvec2 = Mat.FromPixelData(3, 1, MatType.CV_64FC1, new[] { 0.0, 1.0, 0.0 });
        using var rvec3 = new Mat();
        using var tvec3 = new Mat();

        Cv2.ComposeRT(rvec1, tvec1, rvec2, tvec2, rvec3, tvec3);

        Assert.Equal(0.0, rvec3.Get<double>(0), 6);
        Assert.Equal(0.0, rvec3.Get<double>(1), 6);
        Assert.Equal(0.0, rvec3.Get<double>(2), 6);
        Assert.Equal(1.0, tvec3.Get<double>(0), 6);
        Assert.Equal(1.0, tvec3.Get<double>(1), 6);
        Assert.Equal(0.0, tvec3.Get<double>(2), 6);
    }

    [Fact]
    public void ComputeCorrespondEpilines()
    {
        var pts1 = new[] { new Point2f(100, 100), new Point2f(200, 150) };
        using var points = Mat.FromPixelData(pts1.Length, 1, MatType.CV_32FC2, pts1);
        using var f = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
        {
            0, 0, 0,
            0, 0, -1,
            0, 1, 0
        });
        using var lines = new Mat();

        Cv2.ComputeCorrespondEpilines(points, 1, f, lines);

        Assert.Equal(pts1.Length, (int) lines.Total());
        Assert.Equal(3, lines.Channels());
    }

    [Fact]
    public void ConvertPointsToHomogeneousAndBack()
    {
        var pts = new[] { new Point2f(1, 2), new Point2f(3, 4) };
        using var src = Mat.FromPixelData(pts.Length, 1, MatType.CV_32FC2, pts);
        using var homogeneous = new Mat();
        Cv2.ConvertPointsToHomogeneous(src, homogeneous);

        Assert.Equal(pts.Length, (int) homogeneous.Total());
        Assert.Equal(3, homogeneous.Channels());

        using var backToNormal = new Mat();
        Cv2.ConvertPointsFromHomogeneous(homogeneous, backToNormal);

        Assert.Equal(pts.Length, (int) backToNormal.Total());
        Assert.Equal(2, backToNormal.Channels());
    }

    [Fact]
    public void ConvertPointsHomogeneous()
    {
        // cv::convertPointsHomogeneous always asserts `_dst.fixedType()` internally (it needs a
        // concretely-typed destination to pick a conversion direction), but every OpenCvSharp
        // OutputArray backed by a plain Mat constructs a native _OutputArray without the
        // FIXED_TYPE flag - a pre-existing binding limitation, not something introduced by the
        // ArrayProxy migration. Reaching native and getting this specific, well-known exception
        // still proves the ArrayProxy wiring is correct.
        var pts = new[] { new Point2f(1, 2), new Point2f(3, 4) };
        using var src = Mat.FromPixelData(pts.Length, 1, MatType.CV_32FC2, pts);
        using var dst = new Mat();

        var ex = Assert.Throws<OpenCVException>(() => Cv2.ConvertPointsHomogeneous(src, dst));
        Assert.Contains("fixedType", ex.Message, StringComparison.Ordinal);
    }

    [Fact]
    public void CorrectMatches()
    {
        using var f = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
        {
            0, 0, 0,
            0, 0, -1,
            0, 1, 0
        });
        var pts1 = new[] { new Point2f(100, 100) };
        var pts2 = new[] { new Point2f(100, 105) };
        using var points1 = Mat.FromPixelData(pts1.Length, 1, MatType.CV_32FC2, pts1);
        using var points2 = Mat.FromPixelData(pts2.Length, 1, MatType.CV_32FC2, pts2);
        using var newPoints1 = new Mat();
        using var newPoints2 = new Mat();

        Cv2.CorrectMatches(f, points1, points2, newPoints1, newPoints2);

        Assert.Equal(pts1.Length, (int) newPoints1.Total());
        Assert.Equal(pts2.Length, (int) newPoints2.Total());
    }

    [Fact]
    public void DecomposeHomographyMat()
    {
        var points1 = new Point2f[] { new(10, 20), new(20, 30), new(30, 40), new(40, 50), new(50, 60) };
        var points2 = new Point2f[] { new(11, 22), new(22, 33), new(33, 44), new(44, 55), new(55, 66) };
        using var m1 = Mat.FromArray(points1);
        using var m2 = Mat.FromArray(points2);
        using var homography = Cv2.FindHomography(m1, m2);
        using var k = Mat.EyeMat(3, 3, MatType.CV_64FC1);

        var count = Cv2.DecomposeHomographyMat(homography, k, out var rotations, out var translations, out var normals);

        Assert.True(count > 0);
        Assert.NotEmpty(rotations);
        Assert.Equal(rotations.Length, translations.Length);
        Assert.Equal(rotations.Length, normals.Length);
        Assert.Equal(3, rotations[0].Rows);
        Assert.Equal(3, rotations[0].Cols);
    }

    [Fact]
    public void DecomposeProjectionMatrix()
    {
        using var projMatrix = Mat.FromPixelData(3, 4, MatType.CV_64FC1, new double[]
        {
            800, 0, 320, 0,
            0, 800, 240, 0,
            0, 0, 1, 0
        });
        using var cameraMatrix = new Mat();
        using var rotMatrix = new Mat();
        using var transVect = new Mat();

        Cv2.DecomposeProjectionMatrix(projMatrix, cameraMatrix, rotMatrix, transVect);

        Assert.Equal(3, cameraMatrix.Rows);
        Assert.Equal(3, cameraMatrix.Cols);
        Assert.Equal(3, rotMatrix.Rows);
        Assert.Equal(3, rotMatrix.Cols);
        Assert.Equal(4, (int) transVect.Total());
        Assert.True(Math.Abs(Cv2.Determinant(rotMatrix) - 1.0) < 1e-6);
    }

    [Fact]
    public void EstimateAffine2D()
    {
        var tx = 5.0;
        var ty = -3.0;
        var from = new Point2f[20];
        var to = new Point2f[20];
        var rng = new Random(11);
        for (var i = 0; i < from.Length; i++)
        {
            from[i] = new Point2f((float) rng.NextDouble() * 100, (float) rng.NextDouble() * 100);
            to[i] = new Point2f((float) (from[i].X * 1.1 + tx), (float) (from[i].Y * 0.9 + ty));
        }

        using var fromMat = Mat.FromPixelData(from.Length, 1, MatType.CV_32FC2, from);
        using var toMat = Mat.FromPixelData(to.Length, 1, MatType.CV_32FC2, to);

        using var affine = Cv2.EstimateAffine2D(fromMat, toMat);

        Assert.NotNull(affine);
        Assert.Equal(2, affine.Rows);
        Assert.Equal(3, affine.Cols);
    }

    [Fact]
    public void EstimateAffinePartial2D()
    {
        var tx = 5.0;
        var ty = -3.0;
        var from = new Point2f[20];
        var to = new Point2f[20];
        var rng = new Random(13);
        for (var i = 0; i < from.Length; i++)
        {
            from[i] = new Point2f((float) rng.NextDouble() * 100, (float) rng.NextDouble() * 100);
            to[i] = new Point2f((float) (from[i].X + tx), (float) (from[i].Y + ty));
        }

        using var fromMat = Mat.FromPixelData(from.Length, 1, MatType.CV_32FC2, from);
        using var toMat = Mat.FromPixelData(to.Length, 1, MatType.CV_32FC2, to);

        using var affine = Cv2.EstimateAffinePartial2D(fromMat, toMat);

        Assert.NotNull(affine);
        Assert.Equal(2, affine.Rows);
        Assert.Equal(3, affine.Cols);
        Assert.True(Math.Abs(affine.Get<double>(0, 2) - tx) < 1e-2);
        Assert.True(Math.Abs(affine.Get<double>(1, 2) - ty) < 1e-2);
    }

    [Fact]
    public void EstimateAffine3D()
    {
        var t = new[] { 1.0, 2.0, 3.0 };
        var src = new float[]
        {
            0, 0, 0,
            10, 0, 0,
            0, 10, 0,
            0, 0, 10
        };
        var dst = new float[src.Length];
        for (var i = 0; i < src.Length; i++)
            dst[i] = (float) (src[i] + t[i % 3]);

        using var srcMat = Mat.FromPixelData(4, 1, MatType.CV_32FC3, src);
        using var dstMat = Mat.FromPixelData(4, 1, MatType.CV_32FC3, dst);
        using var outVal = new Mat();
        using var inliers = new Mat();

        var ret = Cv2.EstimateAffine3D(srcMat, dstMat, outVal, inliers);

        Assert.Equal(1, ret);
        Assert.Equal(3, outVal.Rows);
        Assert.Equal(4, outVal.Cols);
        Assert.True(Math.Abs(outVal.Get<double>(0, 3) - t[0]) < 1e-2);
        Assert.True(Math.Abs(outVal.Get<double>(1, 3) - t[1]) < 1e-2);
        Assert.True(Math.Abs(outVal.Get<double>(2, 3) - t[2]) < 1e-2);
    }

    [Fact]
    public void FilterHomographyDecompByVisibleRefpoints()
    {
        var points1 = new Point2f[] { new(10, 20), new(20, 30), new(30, 40), new(40, 50), new(50, 60) };
        var points2 = new Point2f[] { new(11, 22), new(22, 33), new(33, 44), new(44, 55), new(55, 66) };
        using var m1 = Mat.FromArray(points1);
        using var m2 = Mat.FromArray(points2);
        using var homography = Cv2.FindHomography(m1, m2);
        using var k = Mat.EyeMat(3, 3, MatType.CV_64FC1);

        var count = Cv2.DecomposeHomographyMat(homography, k, out var rotations, out _, out var normals);
        Assert.True(count > 0);

        using var possibleSolutions = new Mat();
        // Smoke test for the ArrayProxy wiring: any valid decomposition set must run without throwing.
        Cv2.FilterHomographyDecompByVisibleRefpoints(rotations, normals, m1, m2, possibleSolutions);

        Assert.Equal(MatType.CV_32SC1, possibleSolutions.Type());

        foreach (var m in rotations) m.Dispose();
        foreach (var m in normals) m.Dispose();
    }

    [Fact]
    public void GetDefaultNewCameraMatrix()
    {
        using var cameraMatrix = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
        {
            800, 0, 300,
            0, 800, 200,
            0, 0, 1
        });

        using var result = Cv2.GetDefaultNewCameraMatrix(cameraMatrix, new Size(640, 480), centerPrincipalPoint: true);

        Assert.Equal(3, result.Rows);
        Assert.Equal(3, result.Cols);
        // OpenCV centers on (size-1)/2 in pixel coordinates, not size/2.
        Assert.Equal(319.5, result.Get<double>(0, 2), 3);
        Assert.Equal(239.5, result.Get<double>(1, 2), 3);
    }

    [Fact]
    public void GetOptimalNewCameraMatrix()
    {
        using var cameraMatrix = Mat.FromArray(CameraMatrix);
        using var distCoeffs = Mat.ZerosMat(4, 1, MatType.CV_64FC1);

        using var result = Cv2.GetOptimalNewCameraMatrix(
            cameraMatrix, distCoeffs, new Size(640, 480), 1.0, new Size(640, 480), out var validPixROI);

        Assert.Equal(3, result.Rows);
        Assert.Equal(3, result.Cols);
        Assert.False(result.Empty());
        Assert.True(validPixROI.Width >= 0);
        Assert.True(validPixROI.Height >= 0);
    }

    [Fact]
    public void MatMulDeriv()
    {
        using var a = Mat.FromPixelData(2, 2, MatType.CV_64FC1, new double[] { 1, 2, 3, 4 });
        using var b = Mat.FromPixelData(2, 2, MatType.CV_64FC1, new double[] { 5, 6, 7, 8 });
        using var dABdA = new Mat();
        using var dABdB = new Mat();

        Cv2.MatMulDeriv(a, b, dABdA, dABdB);

        Assert.Equal(4, dABdA.Rows);
        Assert.Equal(4, dABdA.Cols);
        Assert.Equal(4, dABdB.Rows);
        Assert.Equal(4, dABdB.Cols);
    }

    [Fact]
    public void RQDecomp3x3()
    {
        using var src = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
        {
            800, 1, 320,
            0, 800, 240,
            0, 0, 1
        });
        using var mtxR = new Mat();
        using var mtxQ = new Mat();

        Cv2.RQDecomp3x3(src, mtxR, mtxQ);

        Assert.Equal(3, mtxR.Rows);
        Assert.Equal(3, mtxR.Cols);
        Assert.Equal(3, mtxQ.Rows);
        Assert.Equal(3, mtxQ.Cols);
        // R*Q must reconstruct the original matrix.
        using var reconstructed = (mtxR * mtxQ).ToMat();
        for (var r = 0; r < 3; r++)
        for (var c = 0; c < 3; c++)
            Assert.Equal(src.Get<double>(r, c), reconstructed.Get<double>(r, c), 3);
    }

    [Fact]
    public void SampsonDistance()
    {
        using var pt1 = Mat.FromPixelData(1, 1, MatType.CV_64FC3, new[] { 1.0, 1.0, 1.0 });
        using var pt2 = Mat.FromPixelData(1, 1, MatType.CV_64FC3, new[] { 1.0, 1.0, 1.0 });
        using var f = Mat.FromPixelData(3, 3, MatType.CV_64FC1, new double[]
        {
            0, 0, 0,
            0, 0, -1,
            0, 1, 0
        });

        var distance = Cv2.SampsonDistance(pt1, pt2, f);

        Assert.False(double.IsNaN(distance));
        Assert.False(double.IsInfinity(distance));
    }

    [Fact]
    public void SolvePnPRansac()
    {
        var objPts = ObjectPoints;
        Cv2.ProjectPoints(objPts, new double[] { 0, 0, 0 }, new double[] { 0, 0, -5 },
            CameraMatrix, new double[5], out var imgPts, out _);

        using var objPtsMat = Mat.FromPixelData(objPts.Length, 1, MatType.CV_32FC3, objPts);
        using var imgPtsMat = Mat.FromPixelData(imgPts.Length, 1, MatType.CV_32FC2, imgPts);
        using var cameraMatrixMat = Mat.FromArray(CameraMatrix);
        using var distMat = Mat.ZerosMat(5, 1, MatType.CV_64FC1);
        using var rvec = new Mat();
        using var tvec = new Mat();

        Cv2.SolvePnPRansac(objPtsMat, imgPtsMat, cameraMatrixMat, distMat, rvec, tvec);

        Assert.Equal(3, (int) rvec.Total());
        Assert.Equal(3, (int) tvec.Total());
    }

    [Fact]
    public void TriangulatePoints()
    {
        // Two cameras with the same intrinsics (identity K), the second shifted by -1 along X.
        using var projMatr1 = Mat.FromPixelData(3, 4, MatType.CV_64FC1, new double[]
        {
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0
        });
        using var projMatr2 = Mat.FromPixelData(3, 4, MatType.CV_64FC1, new double[]
        {
            1, 0, 0, -1,
            0, 1, 0, 0,
            0, 0, 1, 0
        });

        // 3D point (0, 0, 5) projects to (0, 0) in camera 1 and (-1/5, 0) in camera 2.
        var pts1 = new[] { new Point2d(0, 0) };
        var pts2 = new[] { new Point2d(-0.2, 0) };
        using var projPoints1 = Mat.FromPixelData(pts1.Length, 1, MatType.CV_64FC2, pts1);
        using var projPoints2 = Mat.FromPixelData(pts2.Length, 1, MatType.CV_64FC2, pts2);
        using var points4D = new Mat();

        Cv2.TriangulatePoints(projMatr1, projMatr2, projPoints1, projPoints2, points4D);

        Assert.Equal(4, points4D.Rows);
        Assert.Equal(1, points4D.Cols);
        var w = points4D.Get<double>(3, 0);
        Assert.True(Math.Abs(w) > 1e-9);
        Assert.True(Math.Abs(points4D.Get<double>(2, 0) / w - 5.0) < 1e-2);
    }

    [Fact]
    public void UndistortPoints()
    {
        using var cameraMatrix = Mat.FromArray(CameraMatrix);
        using var distCoeffs = Mat.ZerosMat(4, 1, MatType.CV_64FC1);
        // The principal point maps to the normalized origin when distortion is zero.
        var pts = new[] { new Point2f(320, 240) };
        using var src = Mat.FromPixelData(pts.Length, 1, MatType.CV_32FC2, pts);
        using var dst = new Mat();

        Cv2.UndistortPoints(src, dst, cameraMatrix, distCoeffs);

        Assert.Equal(pts.Length, (int) dst.Total());
        Assert.True(Math.Abs(dst.Get<Point2f>(0).X) < 1e-3);
        Assert.True(Math.Abs(dst.Get<Point2f>(0).Y) < 1e-3);
    }

    [Fact]
    public void UndistortPointsIter()
    {
        using var cameraMatrix = Mat.FromArray(CameraMatrix);
        using var distCoeffs = Mat.ZerosMat(4, 1, MatType.CV_64FC1);
        var pts = new[] { new Point2f(320, 240) };
        using var src = Mat.FromPixelData(pts.Length, 1, MatType.CV_32FC2, pts);
        using var dst = new Mat();

        Cv2.UndistortPointsIter(src, dst, cameraMatrix, distCoeffs,
            termCriteria: new TermCriteria(CriteriaTypes.Count | CriteriaTypes.Eps, 10, 1e-6));

        Assert.Equal(pts.Length, (int) dst.Total());
        Assert.True(Math.Abs(dst.Get<Point2f>(0).X) < 1e-3);
        Assert.True(Math.Abs(dst.Get<Point2f>(0).Y) < 1e-3);
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
