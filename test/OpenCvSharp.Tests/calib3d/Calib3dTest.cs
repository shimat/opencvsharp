using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Xunit;

// ReSharper disable UnusedVariable
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable JoinDeclarationAndInitializer

namespace OpenCvSharp.Tests.Calib3D;

public class Calib3DTest(ITestOutputHelper output) : TestBase
{
    [Fact]
    public void Rodrigues()
    {
        const double angle = 45;
        var cos = Math.Cos(angle * Math.PI / 180);
        var sin = Math.Sin(angle * Math.PI / 180);
        var matrix = new double[3, 3]
        {
            {cos, -sin, 0},
            {sin, cos, 0},
            {0, 0, 1}
        };

        Cv2.Rodrigues(matrix, out var vector, out var jacobian);

        Assert.NotNull(vector);
        Assert.Equal(3, vector.Length);
        Assert.Equal(0, vector[0], 3);
        Assert.Equal(0, vector[1], 3);
        Assert.Equal(0.785, vector[2], 3);
        Assert.NotNull(jacobian);
        Assert.Equal(9, jacobian.GetLength(0));
        Assert.Equal(3, jacobian.GetLength(1));

        Cv2.Rodrigues(vector, out var matrix2, out var jacobian2);

        Assert.NotNull(matrix2);
        Assert.NotNull(jacobian2);
        Assert.Equal(3, matrix2.GetLength(0));
        Assert.Equal(3, matrix2.GetLength(1));
        for (var i = 0; i < matrix2.GetLength(0); i++)
        for (var j = 0; j < matrix2.GetLength(1); j++)
            Assert.Equal(matrix[i, j], matrix2[i, j], 3);
    }

    [Fact]
    public void CheckChessboard()
    {
        var patternSize = new Size(10, 7);

        using var image1 = LoadImage("calibration/00.jpg", ImreadModes.Grayscale);
        using var image2 = LoadImage("lenna.png", ImreadModes.Grayscale);
        Assert.True(Cv2.CheckChessboard(image1, patternSize));
        Assert.False(Cv2.CheckChessboard(image2, patternSize));
    }

    [Fact]
    public void FindChessboardCorners()
    {
        var patternSize = new Size(10, 7);

        using var image = LoadImage("calibration/00.jpg");
        using var corners = new Mat();
        var found = Cv2.FindChessboardCorners(image, patternSize, corners);

        if (Debugger.IsAttached)
        {
            Cv2.DrawChessboardCorners(image, patternSize, corners, found);
            Window.ShowImages(image);
        }

        Assert.True(found);
        Assert.Equal(70, corners.Total());
        Assert.Equal(MatType.CV_32FC2, corners.Type());
    }

    [Fact]
    public void FindChessboardCornersSB()
    {
        var patternSize = new Size(10, 7);

        using var image = LoadImage("calibration/00.jpg");
        using var corners = new Mat();
        var found = Cv2.FindChessboardCornersSB(image, patternSize, corners);

        if (Debugger.IsAttached)
        {
            Cv2.DrawChessboardCorners(image, patternSize, corners, found);
            Window.ShowImages(image);
        }

        // TODO fail on appveyor
        //Assert.True(found);
        if (found)
        {
            Assert.Equal(70, corners.Total());
            Assert.Equal(MatType.CV_32FC2, corners.Type());
        }
        else
        {
            output.WriteLine(@"!!! [FindChessboardCornersSB] chessboard not found");
        }
    }

    [Fact]
    public void CalibrateCameraByArray()
    {
        var patternSize = new Size(10, 7);

        using var image = LoadImage("calibration/00.jpg");
        using var corners = new Mat<Point2f>();
        Cv2.FindChessboardCorners(image, patternSize, corners);

        var objectPoints = Create3DChessboardCorners(patternSize, 1.0f);
        var imagePoints = corners.ToArray();
        var cameraMatrix = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
        var distCoeffs = new double[5];

        var rms = Cv2.CalibrateCamera([objectPoints], [imagePoints], image.Size(), cameraMatrix,
            distCoeffs, out var rotationVectors, out var translationVectors,
            CalibrationFlags.UseIntrinsicGuess | CalibrationFlags.FixK5);

        Assert.Equal(6.16, rms, 2);
        Assert.Contains(distCoeffs, d => Math.Abs(d) > 1e-20);
    }

    [Fact]
    public void CalibrateCameraByMat()
    {
        var patternSize = new Size(10, 7);

        using var image = LoadImage("calibration/00.jpg");
        using var corners = new Mat<Point2f>();
        Cv2.FindChessboardCorners(image, patternSize, corners);

        var objectPointsArray = Create3DChessboardCorners(patternSize, 1.0f).ToArray();
        var imagePointsArray = corners.ToArray();

        using var objectPoints = Mat<Point3f>.FromArray(objectPointsArray);
        using var imagePoints = Mat<Point2f>.FromArray(imagePointsArray);
        using var cameraMatrix = new Mat<double>(Mat.Eye(3, 3, MatType.CV_64FC1));
        using var distCoeffs = new Mat<double>();
        var rms = Cv2.CalibrateCamera([objectPoints], [imagePoints], image.Size(), cameraMatrix,
            distCoeffs, out var rotationVectors, out var translationVectors,
            CalibrationFlags.UseIntrinsicGuess | CalibrationFlags.FixK5);

        var distCoeffValues = distCoeffs.ToArray();
        Assert.Equal(6.16, rms, 2);
        Assert.Contains(distCoeffValues, d => Math.Abs(d) > 1e-20);
    }

    [Fact]
    public void FishEyeCalibrate()
    {
        var patternSize = new Size(10, 7);

        using var image = LoadImage("calibration/00.jpg");
        using var corners = new Mat<Point2f>();
        Cv2.FindChessboardCorners(image, patternSize, corners);

        var objectPointsArray = Create3DChessboardCorners(patternSize, 1.0f).ToArray();
        var imagePointsArray = corners.ToArray();

        using var objectPoints = Mat<Point3f>.FromArray(objectPointsArray);
        using var imagePoints = Mat<Point2f>.FromArray(imagePointsArray);
        using var cameraMatrix = new Mat<double>(Mat.Eye(3, 3, MatType.CV_64FC1));
        using var distCoeffs = new Mat<double>();
        var rms = Cv2.FishEye.Calibrate([objectPoints], [imagePoints], image.Size(), cameraMatrix,
            distCoeffs, out var rotationVectors, out var translationVectors);

        var distCoeffValues = distCoeffs.ToArray();
        //Assert.Equal(109.35, rms, 2);
        Assert.True(rms > 8, $"rms = {rms}");
        Assert.Contains(distCoeffValues, d => Math.Abs(d) > 1e-20);
        Assert.NotEmpty(rotationVectors);
        Assert.NotEmpty(translationVectors);
    }

    /// <summary>
    /// https://stackoverflow.com/questions/25244603/opencvs-projectpoints-function
    /// </summary>
    [Fact]
    [SuppressMessage("ReSharper", "RedundantTypeArgumentsOfMethod")]
    public void ProjectPoints()
    {
        var objectPointsArray = Generate3DPoints().ToArray();
        using var objectPoints = Mat.FromPixelData(objectPointsArray.Length, 1, MatType.CV_64FC3, objectPointsArray);

        using var intrinsicMat = new Mat(3, 3, MatType.CV_64FC1);
        intrinsicMat.Set<double>(0, 0, 1.6415318549788924e+003);
        intrinsicMat.Set<double>(1, 0, 0);
        intrinsicMat.Set<double>(2, 0, 0);
        intrinsicMat.Set<double>(0, 1, 0);
        intrinsicMat.Set<double>(1, 1, 1.7067753507885654e+003);
        intrinsicMat.Set<double>(2, 1, 0);
        intrinsicMat.Set<double>(0, 2, 5.3262822453148601e+002);
        intrinsicMat.Set<double>(1, 2, 3.8095355839052968e+002);
        intrinsicMat.Set<double>(2, 2, 1);

        using var rVec = new Mat(3, 1, MatType.CV_64FC1);
        rVec.Set<double>(0, -3.9277902400761393e-002);
        rVec.Set<double>(1, 3.7803824407602084e-002);
        rVec.Set<double>(2, 2.6445674487856268e-002);

        using var tVec = new Mat(3, 1, MatType.CV_64FC1);
        tVec.Set<double>(0, 2.1158489381208221e+000);
        tVec.Set<double>(1, -7.6847683212704716e+000);
        tVec.Set<double>(2, 2.6169795190294256e+001);

        using var distCoeffs = new Mat(4, 1, MatType.CV_64FC1);
        distCoeffs.Set<double>(0, 0);
        distCoeffs.Set<double>(1, 0);
        distCoeffs.Set<double>(2, 0);
        distCoeffs.Set<double>(3, 0);

        // without jacobian
        using var imagePoints = new Mat();
        Cv2.ProjectPoints(objectPoints, rVec, tVec, intrinsicMat, distCoeffs, imagePoints);

        // with jacobian
        using var jacobian = new Mat();
        Cv2.ProjectPoints(objectPoints, rVec, tVec, intrinsicMat, distCoeffs, imagePoints, jacobian);
    }

    /// <summary>
    /// https://stackoverflow.com/questions/25244603/opencvs-projectpoints-function
    /// </summary>
    [Fact]
    [SuppressMessage("ReSharper", "RedundantTypeArgumentsOfMethod")]
    public void FishEyeProjectPoints()
    {
        var objectPointsArray = Generate3DPoints().ToArray();
        using var objectPoints = Mat.FromPixelData(objectPointsArray.Length, 1, MatType.CV_64FC3, objectPointsArray);

        using var intrisicMat = new Mat(3, 3, MatType.CV_64FC1);
        intrisicMat.Set<double>(0, 0, 1.6415318549788924e+003);
        intrisicMat.Set<double>(1, 0, 0);
        intrisicMat.Set<double>(2, 0, 0);
        intrisicMat.Set<double>(0, 1, 0);
        intrisicMat.Set<double>(1, 1, 1.7067753507885654e+003);
        intrisicMat.Set<double>(2, 1, 0);
        intrisicMat.Set<double>(0, 2, 5.3262822453148601e+002);
        intrisicMat.Set<double>(1, 2, 3.8095355839052968e+002);
        intrisicMat.Set<double>(2, 2, 1);

        using var rVec = new Mat(3, 1, MatType.CV_64FC1);
        rVec.Set<double>(0, -3.9277902400761393e-002);
        rVec.Set<double>(1, 3.7803824407602084e-002);
        rVec.Set<double>(2, 2.6445674487856268e-002);

        using var tVec = new Mat(3, 1, MatType.CV_64FC1);
        tVec.Set<double>(0, 2.1158489381208221e+000);
        tVec.Set<double>(1, -7.6847683212704716e+000);
        tVec.Set<double>(2, 2.6169795190294256e+001);

        using var distCoeffs = new Mat(4, 1, MatType.CV_64FC1);
        distCoeffs.Set<double>(0, 0);
        distCoeffs.Set<double>(1, 0);
        distCoeffs.Set<double>(2, 0);
        distCoeffs.Set<double>(3, 0);

        // without jacobian
        using var imagePoints = new Mat();
        Cv2.FishEye.ProjectPoints(objectPoints, imagePoints, rVec, tVec, intrisicMat, distCoeffs, 0);

        // with jacobian
        using var jacobian = new Mat();
        Cv2.FishEye.ProjectPoints(objectPoints, imagePoints, rVec, tVec, intrisicMat, distCoeffs, 0, jacobian);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void SolvePnPTestByArray(bool useExtrinsicGuess)
    {
        var rvec = new double[] { 3, 0, 0 };
        var tvec = new double[] { 0, 0, -10 };
        var cameraMatrix = new double[,]
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 }
        };
        var dist = new double[] { 0, 0, 0, 0, 0 };

        var objPts = new[]
        {
            new Point3f(0,0,1),
            new Point3f(1,0,1),
            new Point3f(0,1,1),
            new Point3f(1,1,1),
            new Point3f(1,0,2),
            new Point3f(0,1,2)
        };

        Cv2.ProjectPoints(objPts, rvec, tvec, cameraMatrix, dist, out var imgPts, out var jacobian);

        Cv2.SolvePnP(objPts, imgPts, cameraMatrix, dist, ref rvec, ref tvec, useExtrinsicGuess: useExtrinsicGuess);
    }

    [Fact]
    public void SolvePnPTestByMat()
    {
        var rvec = new double[] { 0, 0, 0 };
        var tvec = new double[] { 0, 0, 0 };
        var cameraMatrix = new double[,]
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 }
        };
        var dist = new double[] { 0, 0, 0, 0, 0 };

        var objPts = new[]
        {
            new Point3f(0,0,1),
            new Point3f(1,0,1),
            new Point3f(0,1,1),
            new Point3f(1,1,1),
            new Point3f(1,0,2),
            new Point3f(0,1,2)
        };

        Cv2.ProjectPoints(objPts, rvec, tvec, cameraMatrix, dist, out var imgPts, out var jacobian);

        using var objPtsMat = Mat.FromPixelData(objPts.Length, 1, MatType.CV_32FC3, objPts);
        using var imgPtsMat = Mat.FromPixelData(imgPts.Length, 1, MatType.CV_32FC2, imgPts);
        using var cameraMatrixMat = Mat.Eye(3, 3, MatType.CV_64FC1);
        using var distMat = Mat.Zeros(5, 0, MatType.CV_64FC1);
        using var rvecMat = new Mat();
        using var tvecMat = new Mat();
        Cv2.SolvePnP(objPtsMat, imgPtsMat, cameraMatrixMat, distMat, rvecMat, tvecMat);
    }

    [Fact]
    public void FindFundamentalMat()
    {
        var imgPt1 = new[]
        {
            new Point2d(1017.0883, 848.23529),
            new Point2d(1637, 848.23529),
            new Point2d(1637, 1648.7059),
            new Point2d(1017.0883, 1648.7059),
            new Point2d(2282.2144, 772),
            new Point2d(3034.9644, 772),
            new Point2d(3034.9644, 1744),
            new Point2d(2282.2144, 1744),
        };
        var imgPt2 = new[]
        {
            new Point2d(414.88824, 848.23529),
            new Point2d(1034.8, 848.23529),
            new Point2d(1034.8, 1648.7059),
            new Point2d(414.88824, 1648.7059),
            new Point2d(1550.9714, 772),
            new Point2d(2303.7214, 772),
            new Point2d(2303.7214, 1744),
            new Point2d(1550.9714, 1744),
        };

        using var f = Cv2.FindFundamentalMat(imgPt1, imgPt2, FundamentalMatMethods.Point8);
        Assert.True(f.Empty()); // TODO 
    }

    // https://github.com/shimat/opencvsharp/issues/1069
    [Fact]
    public void RecoverPose()
    {
        var essentialData = new double[,]
        {
            {1.503247056657373e-16, -7.074103796034695e-16, -7.781514175638166e-16},
            {6.720398606232961e-16, -6.189840821530359e-17, -0.7071067811865476},
            {7.781514175638166e-16, 0.7071067811865475, -2.033804841359975e-16}
        };
        using var essential = Mat.FromArray(essentialData);

        var p1Data = new[]
        {
            new Point2d(1017.0883, 848.23529),
            new Point2d(1637, 848.23529),
            new Point2d(1637, 1648.7059),
            new Point2d(1017.0883, 1648.7059),
            new Point2d(2282.2144, 772),
            new Point2d(3034.9644, 772),
            new Point2d(3034.9644, 1744),
            new Point2d(2282.2144, 1744)
        };
        var p2Data = new[]
        {
            new Point2d(414.88824, 848.23529),
            new Point2d(1034.8, 848.23529),
            new Point2d(1034.8, 1648.7059),
            new Point2d(414.88824, 1648.7059),
            new Point2d(1550.9714, 772),
            new Point2d(2303.7214, 772),
            new Point2d(2303.7214, 1744),
            new Point2d(1550.9714, 1744)
        };
        using var p1 = Mat.FromArray(p1Data);
        using var p2 = Mat.FromArray(p2Data);

        var kData = new double[,]
        {
            {3011, 0, 1637},
            {0, 3024, 1204},
            {0, 0, 1}
        };
        using var k = Mat.FromArray(kData);

        using var r = new Mat();
        using var t = new Mat();
        Cv2.RecoverPose(essential, p1, p2, k, r, t);

        Assert.False(r.Empty());
        Assert.False(t.Empty());
    }

    // https://github.com/shimat/opencvsharp/issues/1410
    [Fact]
    public void RecoverPoseWithTriangulatedPoints()
    {
        var points1 = new[,]
        {
            { 0.38813609924847137, 0.02447841812986895 },
            { 0.08423523188782245, 0.10197624851964165 },
            { 0.29981091670244864, 0.10563331155486635 },
            { 0.2692439454334949, 0.11443490334674666 },
            { -0.041948288655290975, -0.05514874152548128 },
            { 0.03992329933832534, 0.007632737039647461 },
            { 0.050901003100829574, 0.05711866453816542 },
            { -0.03948646783477256, 0.025999204793101333 },
            { -0.06209751680095625, 0.04221654108790821 },
            { -0.016555534818875183, 0.06435009173308306 },
            { -0.16903822109902406, -0.07257834381179194 },
            { 0.41642570198356116, 0.12256932045317968 },
            { 0.39861580051504203, 0.16142837173027308 },
            { 0.04655404967444799, -0.010591253965935497 },
            { 0.03556041780480632, -0.006437507577777012 },
            { 0.41248124653016055, 0.02397771978349527 },
            { 0.3801891632514438, 0.026561067331762406 },
            { 0.42808861337304654, 0.029163367387340686 },
            { 0.4318539553218957, 0.03833957070243556 },
            { 0.44248180108275476, 0.04785089487375638 },
            { 0.4262027536470637, 0.050711978734889696 },
            { 0.0874961830532552, 0.1031790076314136 },
            { 0.2700899364672753, 0.11163060447412339 },
            { 0.3582427322108526, 0.11545310747602498 },
            { 0.041542631217902054, -0.02727039291563037 },
            { 0.4303139947145481, 0.03949740376628924 },
            { 0.06001969886286597, 0.046760602502455145 },
            { -0.03946697379884526, 0.021581967008446938 },
            { -0.1642986257578312, -0.06865176910206553 },
            { 0.03938910580334193, -0.07728559157122807 },
            { 0.06254455304488589, -0.03771698379780937 },
            { -0.07909181296840861, -0.03482664261191252 },
            { -0.08020047248432952, -0.04234032884282042 },
        };
        var points2 = new[,]
        {
            { -0.2789943914026892, 0.30720648107100057 },
            { -0.03211411217735307, 0.0552583557497171 },
            { -0.29157998452774253, 0.1485318201443865 },
            { -0.2702940577548254, 0.12072539127028371 },
            { 0.2477206015038991, 0.2415913262853919 },
            { 0.06618681525128994, 0.17127756148205156 },
            { 0.042038487143667536, 0.10712379560384284 },
            { 0.17024542526228917, 0.09981948720558462 },
            { 0.19885502624141976, 0.06308992557874996 },
            { 0.12763100053213033, 0.058938319107061155 },
            { 0.46339803911837213, 0.1987904682083972 },
            { -0.433620692570429, 0.16921885039668041 },
            { -0.46932283702262495, 0.10055432703225901 },
            { 0.07157221583536884, 0.2046623745409314 },
            { 0.08044325517579885, 0.1909797723911897 },
            { -0.30160697877887155, 0.31671400091223556 },
            { -0.2720897728043967, 0.30219843720518874 },
            { -0.3233379323990584, 0.31416448403147024 },
            { -0.3395905678403646, 0.3015414353998168 },
            { -0.36075032186748296, 0.291377190103051 },
            { -0.34930563708219925, 0.2816288831915651 },
            { -0.03776495756263569, 0.054842338028296626 },
            { -0.26713013306303746, 0.1259610178894828 },
            { -0.366032826498244, 0.15698442478244704 },
            { 0.09215684671120347, 0.2314028881588346 },
            { -0.3382650691409414, 0.2996505624675723 },
            { 0.032134959390848615, 0.12605425231232353 },
            { 0.17160473809736793, 0.10638491555956729 },
            { 0.45231703093455844, 0.19440993018522748 },
            { 0.14987665442569326, 0.319307869795434 },
            { 0.06438724162613875, 0.256554254526816 },
            { 0.268219830870227, 0.17746488412848505 },
            { 0.27588351860241883, 0.19031175105448103 },
        };

        using var points1m = Mat<double>.FromArray(points1);
        using var points2m = Mat<double>.FromArray(points2);
        using var K = Mat.Eye(3, 3, MatType.CV_64F);
        using var inliers = new Mat();
        using var E = Cv2.FindEssentialMat(points1m, points2m, K, EssentialMatMethod.LMedS, 0.99, 1.0, inliers);

        using var R = new Mat();
        using var t = new Mat();
        using var triangulatedPoints = new Mat();
        int numInliers = Cv2.RecoverPose(E, points1m, points2m, K, R, t, 50.0, inliers, triangulatedPoints);

        Assert.True(numInliers > 0);
        Assert.False(R.Empty());
        Assert.False(t.Empty());
        Assert.False(triangulatedPoints.Empty());
    }

    [Fact]
    public void FindHomography()
    {
        var points1 = new Point2f[]
        {
            new(10, 20),
            new(20, 30),
            new(30, 40),
            new(40, 50),
            new(50, 60),
        };
        var points2 = new Point2f[]
        {
            new(11, 22),
            new(22, 33),
            new(33, 44),
            new(44, 55),
            new(55, 66),
        };

        using var m1 = Mat.FromArray(points1);
        using var m2 = Mat.FromArray(points2);

        using var dst = Cv2.FindHomography(m1, m2);

        Assert.False(dst.Empty());
        Assert.Equal(3, dst.Rows);
        Assert.Equal(3, dst.Cols);
        Assert.True(dst.GetArray(out double[] dstArray));
        Assert.Equal(9, dstArray.Length);
        Assert.All(dstArray, d =>
        {
            Assert.False(double.IsNaN(d));
            Assert.False(double.IsInfinity(d));
        });
    }

    [Fact]
    public void FindHomographyUsac()
    {
        var points1 = Enumerable.Range(1, 5).Select(i => new Point2f(i * 10, i * 20)).ToArray();
        var points2 = points1.Select(p => new Point2f(p.X + p.X / 10, p.Y + p.Y / 10)).ToArray();

        using var m1 = Mat.FromArray(points1);
        using var m2 = Mat.FromArray(points2);
        using var mask = new Mat();
        var usacParams = new UsacParams();

        using var dst = Cv2.FindHomography(m1, m2, mask, usacParams);

        // TODO
        /*
        Assert.False(dst.Empty());
        Assert.Equal(3, dst.Rows);
        Assert.Equal(3, dst.Cols);
        Assert.True(dst.GetArray(out double[] dstArray));
        Assert.Equal(9, dstArray.Length);
        Assert.All(dstArray, d =>
        {
            Assert.False(double.IsNaN(d));
            Assert.False(double.IsInfinity(d));
        });*/
    }

    [Fact]
    public void StereoCalibrateByInputArray()
    {
        var patternSize = new Size(10, 7);

        using var image = LoadImage("calibration/00.jpg");
        Cv2.FindChessboardCorners(image, patternSize, out var cornerPoints);

        var objectPointsArray = Create3DChessboardCorners(patternSize, 1.0f).ToArray();

        using var opIA = InputArray.Create(objectPointsArray);
        using var ip1IA = InputArray.Create(cornerPoints);
        using var ip2IA = InputArray.Create(cornerPoints);

        using var cameraMatrix1 = new Mat<double>(Mat.Eye(3, 3, MatType.CV_64FC1));
        using var distCoeffs1 = new Mat<double>();
        using var cameraMatrix2 = new Mat<double>(Mat.Eye(3, 3, MatType.CV_64FC1));
        using var distCoeffs2 = new Mat<double>();
        using var R = new Mat();
        using var T = new Mat();
        using var E = new Mat();
        using var F = new Mat();

        var rms = Cv2.StereoCalibrate(
            new[] { opIA }, new[] { ip1IA }, new[] { ip2IA },
            cameraMatrix1, distCoeffs1,
            cameraMatrix2, distCoeffs2,
            image.Size(), R, T, E, F,
            CalibrationFlags.UseIntrinsicGuess);

        Assert.False(double.IsNaN(rms));
        Assert.False(double.IsInfinity(rms));
    }

    [Fact]
    public void StereoCalibrateByMat()
    {
        var patternSize = new Size(10, 7);

        using var image = LoadImage("calibration/00.jpg");
        Cv2.FindChessboardCorners(image, patternSize, out var cornerPoints);

        var objectPointsArray = Create3DChessboardCorners(patternSize, 1.0f).ToArray();

        using var objectPoints = Mat<Point3f>.FromArray(objectPointsArray);
        using var imagePoints = Mat<Point2f>.FromArray(cornerPoints);
        using var cameraMatrix1 = new Mat(Mat.Eye(3, 3, MatType.CV_64FC1));
        using var distCoeffs1 = new Mat();
        using var cameraMatrix2 = new Mat(Mat.Eye(3, 3, MatType.CV_64FC1));
        using var distCoeffs2 = new Mat();
        using var R = new Mat();
        using var T = new Mat();
        using var E = new Mat();
        using var F = new Mat();

        var rms = Cv2.StereoCalibrate(
            new[] { objectPoints }, new[] { imagePoints }, new[] { imagePoints },
            cameraMatrix1, distCoeffs1,
            cameraMatrix2, distCoeffs2,
            image.Size(), R, T, E, F,
            CalibrationFlags.UseIntrinsicGuess);

        Assert.False(double.IsNaN(rms));
        Assert.False(double.IsInfinity(rms));
    }

    private static IEnumerable<Point3f> Create3DChessboardCorners(Size boardSize, float squareSize)
    {
        for (var y = 0; y < boardSize.Height; y++)
        {
            for (var x = 0; x < boardSize.Width; x++)
            {
                yield return new Point3f(x * squareSize, y * squareSize, 0);
            }
        }
    }

    private static IEnumerable<Point3d> Generate3DPoints()
    {
        double x, y, z;

        x = .5; y = .5; z = -.5;
        yield return new Point3d(x, y, z);

        x = .5; y = .5; z = .5;
        yield return new Point3d(x, y, z);

        x = -.5; y = .5; z = .5;
        yield return new Point3d(x, y, z);

        x = -.5; y = .5; z = -.5;
        yield return new Point3d(x, y, z);

        x = .5; y = -.5; z = -.5;
        yield return new Point3d(x, y, z);

        x = -.5; y = -.5; z = -.5;
        yield return new Point3d(x, y, z);

        x = -.5; y = -.5; z = .5;
        yield return new Point3d(x, y, z);
    }
}
