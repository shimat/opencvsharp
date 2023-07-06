using System;
using System.Diagnostics;
using System.IO;
using OpenCvSharp.Aruco;
using Xunit;

namespace OpenCvSharp.Tests.Aruco;

// ReSharper disable once InconsistentNaming
public class ArucoTest : TestBase
{
    [Fact]
    public void CreateDetectorParameters()
    {
        var param = new DetectorParameters();
        Assert.Equal(3, param.AdaptiveThreshWinSizeMin);
        Assert.Equal(23, param.AdaptiveThreshWinSizeMax);
        Assert.Equal(10, param.AdaptiveThreshWinSizeStep);
        Assert.Equal(7, param.AdaptiveThreshConstant);
        Assert.Equal(0.03, param.MinMarkerPerimeterRate, 3);
        Assert.Equal(4, param.MaxMarkerPerimeterRate, 3);
        Assert.Equal(0.03, param.PolygonalApproxAccuracyRate, 3);
        Assert.Equal(0.05, param.MinCornerDistanceRate, 3);
        Assert.Equal(3, param.MinDistanceToBorder);
        Assert.Equal(0.05, param.MinMarkerDistanceRate, 3);
        Assert.Equal(CornerRefineMethod.None, param.CornerRefinementMethod);
        Assert.Equal(5, param.CornerRefinementWinSize);
        Assert.Equal(30, param.CornerRefinementMaxIterations);
        Assert.Equal(0.1, param.CornerRefinementMinAccuracy, 3);
        Assert.Equal(1, param.MarkerBorderBits);
        Assert.Equal(4, param.PerspectiveRemovePixelPerCell);
        Assert.Equal(0.13, param.PerspectiveRemoveIgnoredMarginPerCell, 3);
        Assert.Equal(0.35, param.MaxErroneousBitsInBorderRate, 3);
        Assert.Equal(5.0, param.MinOtsuStdDev, 3);
        Assert.Equal(0.6, param.ErrorCorrectionRate, 3);
        Assert.Equal(0f, param.AprilTagQuadDecimate, 1e-3);
        Assert.Equal(0f, param.AprilTagQuadSigma, 1e-3);
        Assert.Equal(5, param.AprilTagMinClusterPixels);
        Assert.Equal(10, param.AprilTagMaxNmaxima);
        Assert.Equal(0.175f, param.AprilTagCriticalRad, 1e-3);
        Assert.Equal(10f, param.AprilTagMaxLineFitMse, 1e-3);
        Assert.Equal(0, param.AprilTagDeglitch);
        Assert.Equal(5, param.AprilTagMinWhiteBlackDiff);
        Assert.False(param.DetectInvertedMarker);
        Assert.False(param.UseAruco3Detection);
        Assert.Equal(32, param.MinSideLengthCanonicalImg);
        Assert.Equal(0, param.MinMarkerLengthRatioOriginalImg);
    }
    
    [Fact]
    public void GetPredefinedDictionary()
    {
#pragma warning disable CS8605
        foreach (PredefinedDictionaryName val in Enum.GetValues(typeof(PredefinedDictionaryName)))
#pragma warning restore CS8605
        {
            var dict = CvAruco.GetPredefinedDictionary(val);
            dict.Dispose();
        }
    }

    [Fact]
    public void ReadDictionaryFromFile()
    {
        var dictionaryFile = Path.Combine("_data", "aruco", "Dict6X6_1000.yaml");
        var toCompareWith = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_1000);
        var dict = CvAruco.ReadDictionary(dictionaryFile);

        Assert.Equal(toCompareWith.BytesList.Rows, dict.BytesList.Rows);
        Assert.Equal(toCompareWith.BytesList.Cols, dict.BytesList.Cols);
        Assert.Equal(toCompareWith.MarkerSize, dict.MarkerSize);
        Assert.Equal(toCompareWith.MaxCorrectionBits, dict.MaxCorrectionBits);

        var dictData = dict.BytesList.ToBytes();
        var refData = toCompareWith.BytesList.ToBytes();

        for (int idx = 0; idx < dictData.Length; idx++)
            Assert.Equal(refData[idx], dictData[idx]);
        
        toCompareWith.Dispose();
        dict.Dispose();
    }

    [Fact]
    public void DetectMarkers()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);

        var param = new DetectorParameters();
        CvAruco.DetectMarkers(image, dict, out _, out _, param, out _);
    }

    [Fact]
    public void DictionaryProperties()
    {
        var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);
        Assert.Equal(250, dict.BytesList.Rows);
        Assert.Equal(5, dict.BytesList.Cols); // (6*6 + 7)/8
        Assert.Equal(6, dict.MarkerSize);
        Assert.Equal(5, dict.MaxCorrectionBits);

        dict.MarkerSize = 4;
        dict.MaxCorrectionBits = 50;
        Assert.Equal(4, dict.MarkerSize);
        Assert.Equal(50, dict.MaxCorrectionBits);
    }
    
    [Fact]
    public void DrawDetectedMarker()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var outputImage = image.CvtColor(ColorConversionCodes.GRAY2RGB);
        using var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);
        var param = new DetectorParameters();
        CvAruco.DetectMarkers(image, dict, out var corners, out var ids, param, out var rejectedImgPoints);

        CvAruco.DrawDetectedMarkers(outputImage, corners, ids, new Scalar(255, 0, 0));
        CvAruco.DrawDetectedMarkers(outputImage, rejectedImgPoints, null, new Scalar(0, 0, 255));

        if (Debugger.IsAttached)
        {
            // If you want to save markers image, you must change the following values.
            const string path = "C:\\detected_markers_6x6_250.png";
            Cv2.ImWrite(path, outputImage);
            Process.Start(path);
        }
    }

    [Fact]
    public void EstimatePoseSingleMarkers()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);
        var param = new DetectorParameters();
        CvAruco.DetectMarkers(image, dict, out var corners, out _, param, out _);

        using var cameraMatrix = Mat.Eye(3, 3, MatType.CV_64FC1);
        using var distCoeffs = Mat.Zeros(4, 1, MatType.CV_64FC1);
        using var rvec = new Mat();
        using var tvec = new Mat();
        using var objPoints = new Mat();
        CvAruco.EstimatePoseSingleMarkers(corners, 6, cameraMatrix, distCoeffs, rvec, tvec, objPoints);

        Assert.Equal(20, rvec.Total());
        Assert.Equal(20, tvec.Total());
        Assert.Equal(4, objPoints.Total());
    }
}
