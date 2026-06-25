using Xunit;

namespace OpenCvSharp.Tests.Calib3D;

// Tests for the OpenCV 5 multi-view calibration functions: RegisterCameras and CalibrateMultiview.
// A synthetic 2-camera rig is used. The relative pose between the cameras is identity rotation and a
// pure X translation, so camera 1's view of the board is just camera 0's view with the translation
// applied (because R10 == I): cam1 board pose = (rvec, tvec + (-baseline, 0, 0)).
public class MultiviewCalibrationTest : TestBase
{
    private const double Baseline = 1.0;

    private static readonly double[,] CameraMatrix =
    {
        { 800, 0, 320 },
        { 0, 800, 240 },
        { 0, 0, 1 }
    };

    private static Point3f[] BoardPoints()
    {
        var points = new List<Point3f>();
        for (var y = 0; y < 5; y++)
            for (var x = 0; x < 7; x++)
                points.Add(new Point3f(x, y, 0));
        return points.ToArray();
    }

    private static (double[] rvec, double[] tvec)[] Frames() => new[]
    {
        (new[] { 0.0, 0.0, 0.0 }, new[] { -3.0, -2.0, 12.0 }),
        (new[] { 0.1, 0.0, 0.0 }, new[] { -3.0, -2.0, 13.0 }),
        (new[] { 0.0, 0.1, 0.0 }, new[] { -2.5, -2.0, 12.0 }),
        (new[] { -0.1, 0.05, 0.0 }, new[] { -3.0, -1.5, 14.0 }),
        (new[] { 0.05, -0.1, 0.02 }, new[] { -3.5, -2.0, 12.0 }),
        (new[] { 0.0, 0.0, 0.1 }, new[] { -3.0, -2.5, 13.0 }),
    };

    private static Mat ToMatNx3(Point3f[] points)
    {
        var data = new float[points.Length * 3];
        for (var i = 0; i < points.Length; i++)
        {
            data[(i * 3) + 0] = points[i].X;
            data[(i * 3) + 1] = points[i].Y;
            data[(i * 3) + 2] = points[i].Z;
        }
        return Mat.FromPixelData(points.Length, 3, MatType.CV_32FC1, data);
    }

    private static Mat ToMatNx2(Point2f[] points)
    {
        var data = new float[points.Length * 2];
        for (var i = 0; i < points.Length; i++)
        {
            data[(i * 2) + 0] = points[i].X;
            data[(i * 2) + 1] = points[i].Y;
        }
        return Mat.FromPixelData(points.Length, 2, MatType.CV_32FC1, data);
    }

    private static (List<Mat> obj, List<Mat> cam0, List<Mat> cam1) BuildScene()
    {
        var board = BoardPoints();
        var dist = new double[5];
        var objMats = new List<Mat>();
        var cam0 = new List<Mat>();
        var cam1 = new List<Mat>();

        foreach (var (rvec, tvec) in Frames())
        {
            Cv2.ProjectPoints(board, rvec, tvec, CameraMatrix, dist, out var img0, out _);
            var tvec1 = new[] { tvec[0] - Baseline, tvec[1], tvec[2] };
            Cv2.ProjectPoints(board, rvec, tvec1, CameraMatrix, dist, out var img1, out _);

            objMats.Add(ToMatNx3(board));
            cam0.Add(ToMatNx2(img0));
            cam1.Add(ToMatNx2(img1));
        }
        return (objMats, cam0, cam1);
    }

    private static void DisposeAll(params IEnumerable<Mat>[] groups)
    {
        foreach (var g in groups)
            foreach (var m in g)
                m.Dispose();
    }

    [Fact]
    public void RegisterCameras()
    {
        var (obj, cam0, cam1) = BuildScene();
        using var k1 = Mat.FromPixelData(3, 3, MatType.CV_64FC1, CameraMatrix);
        using var k2 = Mat.FromPixelData(3, 3, MatType.CV_64FC1, CameraMatrix);
        using var d1 = Mat.Zeros(1, 5, MatType.CV_64FC1).ToMat();
        using var d2 = Mat.Zeros(1, 5, MatType.CV_64FC1).ToMat();
        using var r = new Mat();
        using var t = new Mat();
        using var e = new Mat();
        using var f = new Mat();
        using var perViewErrors = new Mat();
        try
        {
            var rms = Cv2.RegisterCameras(
                obj, obj, cam0, cam1,
                k1, d1, CameraModel.Pinhole, k2, d2, CameraModel.Pinhole,
                r, t, e, f, perViewErrors);

            Assert.True(rms >= 0 && rms < 1.0, $"rms={rms}");
            // Recovered translation should point along -X with unit-ish magnitude (up to scale/sign).
            using var tD = new Mat();
            t.ConvertTo(tD, MatType.CV_64F);
            tD.GetArray(out double[] tv);
            Assert.Equal(3, tv.Length);
            Assert.True(Math.Abs(tv[0]) > Math.Abs(tv[1]) && Math.Abs(tv[0]) > Math.Abs(tv[2]), $"t=({tv[0]},{tv[1]},{tv[2]})");
        }
        finally
        {
            DisposeAll(obj, cam0, cam1);
        }
    }

    [Fact]
    public void CalibrateMultiview()
    {
        var (obj, cam0, cam1) = BuildScene();
        var numFrames = obj.Count;

        using var detectionMask = new Mat(2, numFrames, MatType.CV_8UC1, Scalar.All(1));
        using var models = new Mat(2, 1, MatType.CV_8UC1, Scalar.All((double)CameraModel.Pinhole));
        var imagePoints = new IReadOnlyList<Mat>[] { cam0, cam1 };
        var imageSize = new[] { new Size(640, 480), new Size(640, 480) };

        try
        {
            var rms = Cv2.CalibrateMultiview(
                obj, imagePoints, imageSize, detectionMask, models,
                out var ks, out var distortions, out var rs, out var ts);

            Assert.True(rms >= 0, $"rms={rms}");
            Assert.Equal(2, ks.Length);
            Assert.Equal(2, distortions.Length);
            Assert.Equal(2, rs.Length);
            Assert.Equal(2, ts.Length);

            foreach (var m in ks.Concat(distortions).Concat(rs).Concat(ts))
                m.Dispose();
        }
        finally
        {
            DisposeAll(obj, cam0, cam1);
        }
    }
}
