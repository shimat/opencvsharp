using System;
using System.Diagnostics;
using OpenCvSharp.Aruco;
using Xunit;

namespace OpenCvSharp.Tests.Aruco;

// ReSharper disable once InconsistentNaming
public class ArucoTest : TestBase
{
    [Fact]
    public void CreateDetectorParameters()
    {
        var param = DetectorParameters.Create();
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
        Assert.Equal(0f, param.AprilTagQuadDecimate, 3);
        Assert.Equal(0f, param.AprilTagQuadSigma, 3);
        Assert.Equal(5, param.AprilTagMinClusterPixels);
        Assert.Equal(10, param.AprilTagMaxNmaxima);
        Assert.Equal(0.175f, param.AprilTagCriticalRad, 3);
        Assert.Equal(10f, param.AprilTagMaxLineFitMse, 3);
        Assert.False(param.AprilTagDeglitch);
        Assert.Equal(5, param.AprilTagMinWhiteBlackDiff);
        Assert.False(param.DetectInvertedMarker);
    }

    [Fact]
    public void DetectorParametersProperties()
    {
        var param = DetectorParameters.Create();

        const int intValue = 100;
        const double doubleValue = 1000d;
        const float floatValue = -5f;

        param.AdaptiveThreshConstant = doubleValue;
        param.CornerRefinementMinAccuracy = doubleValue;
        param.ErrorCorrectionRate = doubleValue;
        param.MaxErroneousBitsInBorderRate = doubleValue;
        param.MaxMarkerPerimeterRate = doubleValue;
        param.MinCornerDistanceRate = doubleValue;
        param.MinMarkerDistanceRate = doubleValue;
        param.MinMarkerPerimeterRate = doubleValue;
        param.MinOtsuStdDev = doubleValue;
        param.PerspectiveRemoveIgnoredMarginPerCell = doubleValue;
        param.PolygonalApproxAccuracyRate = doubleValue;

        param.AdaptiveThreshWinSizeMax = intValue;
        param.AdaptiveThreshWinSizeStep = intValue;
        param.CornerRefinementMaxIterations = intValue;
        param.CornerRefinementWinSize = intValue;
        param.MarkerBorderBits = intValue;
        param.MinDistanceToBorder = intValue;
        param.PerspectiveRemovePixelPerCell = intValue;
        param.AdaptiveThreshWinSizeMin = intValue;

        param.AprilTagQuadDecimate = floatValue;
        param.AprilTagQuadSigma = floatValue;
        param.AprilTagMinClusterPixels = intValue;
        param.AprilTagMaxNmaxima = intValue;
        param.AprilTagCriticalRad = floatValue;
        param.AprilTagMaxLineFitMse = floatValue;
        param.AprilTagDeglitch = true;
        param.AprilTagMinWhiteBlackDiff = intValue;
        param.DetectInvertedMarker = true;

        param.CornerRefinementMethod = CornerRefineMethod.Contour;

        Assert.Equal(doubleValue, param.AdaptiveThreshConstant);
        Assert.Equal(doubleValue, param.CornerRefinementMinAccuracy);
        Assert.Equal(doubleValue, param.ErrorCorrectionRate);
        Assert.Equal(doubleValue, param.MaxErroneousBitsInBorderRate);
        Assert.Equal(doubleValue, param.MaxMarkerPerimeterRate);
        Assert.Equal(doubleValue, param.MinCornerDistanceRate);
        Assert.Equal(doubleValue, param.MinMarkerDistanceRate);
        Assert.Equal(doubleValue, param.MinMarkerPerimeterRate);
        Assert.Equal(doubleValue, param.MinOtsuStdDev);
        Assert.Equal(doubleValue, param.PerspectiveRemoveIgnoredMarginPerCell);
        Assert.Equal(doubleValue, param.PolygonalApproxAccuracyRate);

        Assert.Equal(intValue, param.AdaptiveThreshWinSizeMax);
        Assert.Equal(intValue, param.AdaptiveThreshWinSizeStep);
        Assert.Equal(intValue, param.CornerRefinementMaxIterations);
        Assert.Equal(intValue, param.CornerRefinementWinSize);
        Assert.Equal(intValue, param.MarkerBorderBits);
        Assert.Equal(intValue, param.MinDistanceToBorder);
        Assert.Equal(intValue, param.PerspectiveRemovePixelPerCell);
        Assert.Equal(intValue, param.AdaptiveThreshWinSizeMin);

        Assert.Equal(CornerRefineMethod.Contour, param.CornerRefinementMethod);
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
    public void DetectMarkers()
    {
        using var image = Image("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);

        var param = DetectorParameters.Create();
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
    public void DrawMarker()
    {
        const int markerSidePixels = 128;
        const int columns = 4;
        const int rows = 5;
        const int margin = 20;
            
        const int width = columns * markerSidePixels + margin * (columns + 1);
        const int height = rows * markerSidePixels + margin * (rows + 1);

        var id = 0;
        var roi = new Rect(0, 0, markerSidePixels, markerSidePixels);
        using var outputImage = new Mat(new Size(width, height), MatType.CV_8UC1, Scalar.White);

        for (var y = 0; y < rows; y++)
        {
            roi.Top = y * markerSidePixels + margin * (y + 1);

            for (var x = 0; x < columns; x++)
            {
                roi.Left = x * markerSidePixels + margin * (x + 1);

                using var roiMat = new Mat(outputImage, roi);
                using var markerImage = new Mat();
                using var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);
                CvAruco.DrawMarker(dict, id++, markerSidePixels, markerImage);
                markerImage.CopyTo(roiMat);
            }
        }

        if (Debugger.IsAttached)
        {           
            // If you want to save markers image, you must change the following values.
            const string path = "C:\\markers_6x6_250.png";
            Cv2.ImWrite(path, outputImage);
            Process.Start(path);
        }
    }

    [Fact]
    public void DrawDetectedMarker()
    {
        using var image = Image("markers_6x6_250.png", ImreadModes.Grayscale);
        using var outputImage = image.CvtColor(ColorConversionCodes.GRAY2RGB);
        using var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);
        var param = DetectorParameters.Create();
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
        using var image = Image("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = CvAruco.GetPredefinedDictionary(PredefinedDictionaryName.Dict6X6_250);
        var param = DetectorParameters.Create();
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
