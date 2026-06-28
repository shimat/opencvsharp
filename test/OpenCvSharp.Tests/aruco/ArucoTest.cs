using System.Diagnostics;
using OpenCvSharp.Aruco;
using Xunit;

namespace OpenCvSharp.Tests.Aruco;

// ReSharper disable once InconsistentNaming
public class ArucoTest : TestBase
{
    // ==================== DetectorParameters ====================

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
        Assert.Equal(0.21f, param.MinGroupDistance, 1e-3f);
        Assert.Equal(CornerRefineMethod.None, param.CornerRefinementMethod);
        Assert.Equal(5, param.CornerRefinementWinSize);
        Assert.Equal(0.3f, param.RelativeCornerRefinmentWinSize, 1e-3f);
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

    // ==================== RefineParameters ====================

    [Fact]
    public void CreateRefineParametersDefaults()
    {
        var param = new RefineParameters();
        Assert.Equal(10f, param.MinRepDistance, 1e-3f);
        Assert.Equal(3f, param.ErrorCorrectionRate, 1e-3f);
        Assert.True(param.CheckAllOrders);
    }

    [Fact]
    public void CreateRefineParametersCustom()
    {
        var param = new RefineParameters(5f, 2f, false);
        Assert.Equal(5f, param.MinRepDistance, 1e-3f);
        Assert.Equal(2f, param.ErrorCorrectionRate, 1e-3f);
        Assert.False(param.CheckAllOrders);
    }

    // ==================== Dictionary ====================

    [Fact]
    public void GetPredefinedDictionary()
    {
#if NET48
        var enumValues = Enum.GetValues(typeof(PredefinedDictionaryType));
#else
        var enumValues = Enum.GetValues<PredefinedDictionaryType>();
#endif
#pragma warning disable CS8605
        foreach (PredefinedDictionaryType val in enumValues)
#pragma warning restore CS8605
        {
            var dict = Cv2.Aruco.GetPredefinedDictionary(val);
            dict.Dispose();
        }
    }

    [Fact]
    public void ReadDictionaryFromFile()
    {
        var dictionaryFile = Path.Combine("_data", "aruco", "Dict6X6_1000.yaml");
        var toCompareWith = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_1000);
        var dict = Cv2.Aruco.ReadDictionary(dictionaryFile);

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
    public void DictionaryProperties()
    {
        var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        Assert.Equal(250, dict.BytesList.Rows);
        Assert.Equal(5, dict.BytesList.Cols); // (6*6 + 7)/8
        Assert.Equal(6, dict.MarkerSize);
        Assert.Equal(5, dict.MaxCorrectionBits);

        dict.MarkerSize = 4;
        dict.MaxCorrectionBits = 50;
        Assert.Equal(4, dict.MarkerSize);
        Assert.Equal(50, dict.MaxCorrectionBits);
    }

    // ==================== ArucoDetector ====================

    [Fact]
    public void ArucoDetector_CreateDefault()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector(dict);
        Assert.NotNull(detector);
    }

    [Fact]
    public void ArucoDetector_CreateWithCustomParams()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        var dp = new DetectorParameters { CornerRefinementMethod = CornerRefineMethod.Subpix };
        var rp = new RefineParameters(5f, 2f, false);
        using var detector = new ArucoDetector(dict, dp, rp);
        Assert.NotNull(detector);
    }

    [Fact]
    public void ArucoDetector_DetectMarkers()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector(dict);

        detector.DetectMarkers(image, out var corners, out var ids, out var rejectedImgPoints);

        Assert.NotNull(corners);
        Assert.NotNull(ids);
        Assert.NotNull(rejectedImgPoints);
        Assert.True(ids.Length > 0, "Expected at least one marker to be detected");
        Assert.Equal(ids.Length, corners.Length);
        foreach (var markerCorners in corners)
            Assert.Equal(4, markerCorners.Length);
    }

    [Fact]
    public void ArucoDetector_DetectMarkersWithCustomParams()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        var dp = new DetectorParameters { CornerRefinementMethod = CornerRefineMethod.Subpix };
        using var detector = new ArucoDetector(dict, dp, new RefineParameters());

        detector.DetectMarkers(image, out var corners, out var ids, out _);

        Assert.True(ids.Length > 0);
        Assert.Equal(ids.Length, corners.Length);
    }

    [Fact]
    public void ArucoDetector_Dispose()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        var detector = new ArucoDetector(dict);
        detector.Dispose();
        Assert.True(detector.IsDisposed);
    }

    // ==================== DrawDetected* ====================

    [Fact]
    public void DrawDetectedMarker()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var outputImage = image.CvtColor(ColorConversionCodes.GRAY2RGB);
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector(dict);
        detector.DetectMarkers(image, out var corners, out var ids, out var rejectedImgPoints);

        Cv2.Aruco.DrawDetectedMarkers(outputImage, corners, ids, new Scalar(255, 0, 0));
        // ids=null path
        Cv2.Aruco.DrawDetectedMarkers(outputImage, rejectedImgPoints, null, new Scalar(0, 0, 255));

        if (Debugger.IsAttached)
        {
            const string path = "C:\\detected_markers_6x6_250.png";
            Cv2.ImWrite(path, outputImage);
            Process.Start(path);
        }
    }

    // ==================== CharucoBoard ====================

    [Fact]
    public void CharucoBoard_Create()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        Assert.NotNull(board);
    }

    [Fact]
    public void CharucoBoard_Properties()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);

        Assert.Equal(new Size(5, 7), board.ChessboardSize);
        Assert.Equal(0.04f, board.SquareLength, 1e-5f);
        Assert.Equal(0.02f, board.MarkerLength, 1e-5f);
    }

    [Fact]
    public void CharucoBoard_LegacyPattern()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);

        Assert.False(board.LegacyPattern);
        board.LegacyPattern = true;
        Assert.True(board.LegacyPattern);
        board.LegacyPattern = false;
        Assert.False(board.LegacyPattern);
    }

    [Fact]
    public void CharucoBoard_GenerateImage()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var img = new Mat();

        board.GenerateImage(new Size(500, 700), img);

        Assert.False(img.Empty());
        Assert.Equal(700, img.Rows);
        Assert.Equal(500, img.Cols);
    }

    [Fact]
    public void CharucoBoard_CheckCharucoCornersCollinear_Collinear()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);

        // IDs on the same row are collinear
        var collinearIds = new[] { 0, 1, 2, 3 };
        using var idsMat = Mat.FromArray(collinearIds);
        Assert.True(board.CheckCharucoCornersCollinear(idsMat));
    }

    [Fact]
    public void CharucoBoard_Dispose()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        board.Dispose();
        Assert.True(board.IsDisposed);
    }

    // ==================== CharucoDetector ====================

    [Fact]
    public void CharucoDetector_Create()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var detector = new CharucoDetector(board);
        Assert.NotNull(detector);
    }

    [Fact]
    public void CharucoDetector_CreateWithAllParams()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        var dp = new DetectorParameters();
        var rp = new RefineParameters();
        using var detector = new CharucoDetector(board, null, null, 2, false, true, dp, rp);
        Assert.NotNull(detector);
    }

    [Fact]
    public void CharucoDetector_DetectBoard()
    {
        // Generate a synthetic charuco board image and detect from it
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var boardImage = new Mat();
        board.GenerateImage(new Size(600, 800), boardImage, 10, 1);

        using var detector = new CharucoDetector(board);
        detector.DetectBoard(boardImage, out var charucoCorners, out var charucoIds,
            out var markerCorners, out var markerIds);

        Assert.NotNull(charucoCorners);
        Assert.NotNull(charucoIds);
        Assert.NotNull(markerCorners);
        Assert.NotNull(markerIds);
        Assert.True(charucoIds.Length > 0, "Expected at least one charuco corner detected");
        Assert.Equal(charucoCorners.Length, charucoIds.Length);
        Assert.Equal(markerCorners.Length, markerIds.Length);
    }

    [Fact]
    public void CharucoDetector_DetectBoard_EmptyImage()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var emptyImage = Mat.Zeros(300, 300, MatType.CV_8UC1);

        using var detector = new CharucoDetector(board);
        detector.DetectBoard(emptyImage, out var charucoCorners, out var charucoIds,
            out var markerCorners, out var markerIds);

        // No markers or corners should be detected in a blank image
        Assert.Empty(charucoIds);
        Assert.Empty(markerIds);
    }

    [Fact]
    public void CharucoDetector_Dispose()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        var detector = new CharucoDetector(board);
        detector.Dispose();
        Assert.True(detector.IsDisposed);
    }

    // ==================== DrawDetectedCornersCharuco / DrawDetectedDiamonds ====================

    [Fact]
    public void DrawDetectedCornersCharuco()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var boardImage = new Mat();
        board.GenerateImage(new Size(600, 800), boardImage, 10, 1);
        using var outputImage = boardImage.CvtColor(ColorConversionCodes.GRAY2RGB);

        using var detector = new CharucoDetector(board);
        detector.DetectBoard(boardImage, out var charucoCorners, out var charucoIds, out _, out _);

        // With ids
        Cv2.Aruco.DrawDetectedCornersCharuco(outputImage, charucoCorners, charucoIds, new Scalar(0, 255, 0));
        // Without ids (null path)
        Cv2.Aruco.DrawDetectedCornersCharuco(outputImage, charucoCorners, null);
    }
}
