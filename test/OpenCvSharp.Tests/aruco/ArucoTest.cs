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

    [Fact]
    public void Dictionary_GenerateImageMarker()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var img = new Mat();

        dict.GenerateImageMarker(0, 120, img, 1);

        Assert.False(img.Empty());
        Assert.Equal(120, img.Rows);
        Assert.Equal(120, img.Cols);
    }

    [Fact]
    public void Dictionary_GetDistanceToId()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        var markerSize = dict.MarkerSize; // 6

        // Render marker 0 at one pixel per cell (markerSize + 2*borderBits cells),
        // crop the 1px border away, and normalize 0/255 -> 0/1 to recover the bit matrix.
        using var marker = new Mat();
        dict.GenerateImageMarker(0, markerSize + 2, marker, 1);
        using var cropped = new Mat(marker, new Rect(1, 1, markerSize, markerSize));
        using var bits = new Mat();
        Cv2.Threshold(cropped, bits, 127, 1, ThresholdTypes.Binary);

        // The exact bits of marker 0 are at distance 0 from id 0 ...
        Assert.Equal(0, dict.GetDistanceToId(bits, 0));
        // ... and at a positive Hamming distance from a different id.
        Assert.True(dict.GetDistanceToId(bits, 1) > 0);
    }

    [Fact]
    public void Dictionary_DefaultConstructor()
    {
        using var dict = new Dictionary();
        Assert.Equal(0, dict.MarkerSize);
    }

    [Fact]
    public void Dictionary_ConstructorFromBytesList()
    {
        using var source = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var dict = new Dictionary(source.BytesList, source.MarkerSize, source.MaxCorrectionBits);

        Assert.Equal(source.MarkerSize, dict.MarkerSize);
        Assert.Equal(source.MaxCorrectionBits, dict.MaxCorrectionBits);
        Assert.Equal(source.BytesList.Rows, dict.BytesList.Rows);
    }

    [Fact]
    public void Dictionary_ReadWriteDictionary()
    {
        using var source = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        var fileName = Path.Combine(Path.GetTempPath(), "dictionary_readwrite_test.yml");

        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
        {
            source.WriteDictionary(fs);
        }

        using var fs2 = new FileStorage(fileName, FileStorage.Modes.Read);
        var root = fs2.Root();
        Assert.NotNull(root);

        using var dict = new Dictionary();
        var result = dict.ReadDictionary(root);

        Assert.True(result);
        Assert.Equal(source.MarkerSize, dict.MarkerSize);
        Assert.Equal(source.MaxCorrectionBits, dict.MaxCorrectionBits);
    }

    [Fact]
    public void Dictionary_IdentifyWithThreshold()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        var markerSize = dict.MarkerSize;

        using var marker = new Mat();
        dict.GenerateImageMarker(0, markerSize + 2, marker, 1);
        using var cropped = new Mat(marker, new Rect(1, 1, markerSize, markerSize));
        using var ratio = new Mat();
        cropped.ConvertTo(ratio, MatType.CV_32FC1, 1.0 / 255.0);

        var found = dict.Identify(ratio, out var idx, out var rotation, 0.6, 0.49f);

        Assert.True(found);
        Assert.Equal(0, idx);
        Assert.Equal(0, rotation);
    }

    [Fact]
    public void Dictionary_GetMarkerBits()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);

        using var bits = dict.GetMarkerBits(0);

        Assert.False(bits.Empty());
        Assert.Equal(dict.MarkerSize, bits.Rows);
        Assert.Equal(dict.MarkerSize, bits.Cols);
    }

    [Fact]
    public void Dictionary_GetBitsFromByteListWithRotation()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var byteList = dict.BytesList.Row(0);

        using var bits0 = Dictionary.GetBitsFromByteList(byteList, dict.MarkerSize);
        using var bits1 = Dictionary.GetBitsFromByteList(byteList, dict.MarkerSize, 1);

        Assert.Equal(dict.MarkerSize, bits0.Rows);
        Assert.Equal(dict.MarkerSize, bits1.Rows);
    }

    [Fact]
    public void Dictionary_ExtendDictionary()
    {
        using var dict = Cv2.Aruco.ExtendDictionary(20, 4);
        Assert.Equal(4, dict.MarkerSize);
        Assert.Equal(20, dict.BytesList.Rows);
    }

    [Fact]
    public void Dictionary_ExtendDictionaryWithBase()
    {
        using var baseDict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var dict = Cv2.Aruco.ExtendDictionary(60, 4, baseDict);
        Assert.Equal(4, dict.MarkerSize);
        Assert.Equal(60, dict.BytesList.Rows);
    }

    [Fact]
    public void GetPredefinedDictionary_IntOverload()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary((int)PredefinedDictionaryType.Dict6X6_250);
        Assert.Equal(6, dict.MarkerSize);
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

    [Fact]
    public void ArucoDetector_CreateMultiDict()
    {
        using var dict1 = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var dict2 = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector([dict1, dict2], new DetectorParameters(), new RefineParameters());

        var dictionaries = detector.GetDictionaries();
        Assert.Equal(2, dictionaries.Length);
        foreach (var d in dictionaries)
            d.Dispose();
    }

    [Fact]
    public void ArucoDetector_DetectMarkersWithConfidence()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector(dict);

        detector.DetectMarkersWithConfidence(image, out var corners, out var ids, out var confidence, out _);

        Assert.True(ids.Length > 0);
        Assert.Equal(ids.Length, corners.Length);
        Assert.Equal(ids.Length, confidence.Length);
        foreach (var c in confidence)
            Assert.InRange(c, 0.0f, 1.0f);
    }

    [Fact]
    public void ArucoDetector_DetectMarkersMultiDict()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector([dict], new DetectorParameters(), new RefineParameters());

        detector.DetectMarkersMultiDict(image, out var corners, out var ids, out _, out var dictIndices);

        Assert.True(ids.Length > 0);
        Assert.Equal(ids.Length, corners.Length);
        Assert.Equal(ids.Length, dictIndices.Length);
        Assert.All(dictIndices, i => Assert.Equal(0, i));
    }

    [Fact]
    public void ArucoDetector_RefineDetectedMarkers()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector(dict);
        detector.DetectMarkers(image, out var corners, out var ids, out var rejectedImgPoints);

        using var board = new GridBoard(new Size(1, 1), 0.04f, 0.01f, dict, [ids[0]]);
        var singleCorners = new[] { corners[0] };
        var singleIds = new[] { ids[0] };

        detector.RefineDetectedMarkers(
            image, board, singleCorners, singleIds, rejectedImgPoints,
            out var newDetectedCorners, out var newDetectedIds, out var newRejectedCorners, out var recoveredIdxs);

        Assert.Single(newDetectedIds);
        Assert.Equal(newDetectedIds.Length, newDetectedCorners.Length);
        Assert.NotNull(newRejectedCorners);
        Assert.NotNull(recoveredIdxs);
    }

    [Fact]
    public void ArucoDetector_RefineDetectedMarkers_AcceptsCharucoBoard()
    {
        // CharucoBoard derives from Board, so it must be usable wherever a Board is expected.
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector(dict);
        detector.DetectMarkers(image, out var corners, out var ids, out var rejectedImgPoints);

        using CharucoBoard board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);

        detector.RefineDetectedMarkers(
            image, board, corners, ids, rejectedImgPoints,
            out var newDetectedCorners, out var newDetectedIds, out var newRejectedCorners, out var recoveredIdxs);

        Assert.NotNull(newDetectedCorners);
        Assert.NotNull(newDetectedIds);
        Assert.NotNull(newRejectedCorners);
        Assert.NotNull(recoveredIdxs);
    }

    [Fact]
    public void ArucoDetector_GetSetDictionary()
    {
        using var dict1 = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var dict2 = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector(dict1);

        using (var readBack = detector.GetDictionary())
        {
            Assert.Equal(4, readBack.MarkerSize);
        }

        detector.SetDictionary(dict2);
        using var readBack2 = detector.GetDictionary();
        Assert.Equal(6, readBack2.MarkerSize);
    }

    [Fact]
    public void ArucoDetector_SetDictionaries()
    {
        using var dict1 = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var dict2 = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict6X6_250);
        using var detector = new ArucoDetector(dict1);

        detector.SetDictionaries([dict1, dict2]);

        var dictionaries = detector.GetDictionaries();
        Assert.Equal(2, dictionaries.Length);
        foreach (var d in dictionaries)
            d.Dispose();
    }

    [Fact]
    public void ArucoDetector_GetSetDetectorParameters()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var detector = new ArucoDetector(dict);

        var dp = detector.GetDetectorParameters();
        Assert.Equal(3, dp.AdaptiveThreshWinSizeMin);

        dp.AdaptiveThreshWinSizeMin = 5;
        detector.SetDetectorParameters(dp);

        var dp2 = detector.GetDetectorParameters();
        Assert.Equal(5, dp2.AdaptiveThreshWinSizeMin);
    }

    [Fact]
    public void ArucoDetector_GetSetRefineParameters()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var detector = new ArucoDetector(dict);

        var rp = detector.GetRefineParameters();
        Assert.Equal(10f, rp.MinRepDistance, 1e-3f);

        rp.MinRepDistance = 7f;
        detector.SetRefineParameters(rp);

        var rp2 = detector.GetRefineParameters();
        Assert.Equal(7f, rp2.MinRepDistance, 1e-3f);
    }

    [Fact]
    public void ArucoDetector_WriteRead()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var detector = new ArucoDetector(dict);

        var fileName = Path.Combine(Path.GetTempPath(), "aruco_detector_test.yml");
        using (var fs = new FileStorage(fileName, FileStorage.Modes.Write))
        {
            detector.Write(fs);
        }

        using var fs2 = new FileStorage(fileName, FileStorage.Modes.Read);
        var root = fs2.Root();
        Assert.NotNull(root);
        detector.Read(root);
    }

    // ==================== DrawDetected* ====================

    [Fact]
    public void DrawDetectedMarker()
    {
        using var image = LoadImage("markers_6x6_250.png", ImreadModes.Grayscale);
        using var outputImage = new Mat();
        Cv2.CvtColor(image, outputImage, ColorConversionCodes.GRAY2RGB);
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

    [Fact]
    public void CharucoBoard_CreateWithIds()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        // A 5x7 CharucoBoard requires exactly 17 markers (one per white square).
        var ids = Enumerable.Range(10, 17).ToArray();
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict, ids);

        Assert.Equal(ids, board.GetIds());
    }

    [Fact]
    public void CharucoBoard_GetChessboardCorners()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);

        var corners = board.GetChessboardCorners();

        // A 5x7 chessboard has (5-1)*(7-1) = 24 inner corners
        Assert.Equal(24, corners.Length);
    }

    [Fact]
    public void CharucoBoard_GetNearestMarkerIdxAndCorners()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);

        var idx = board.GetNearestMarkerIdx();
        var corners = board.GetNearestMarkerCorners();

        Assert.Equal(board.GetChessboardCorners().Length, idx.Length);
        Assert.Equal(idx.Length, corners.Length);
    }

    [Fact]
    public void CharucoBoard_InheritedBoardMembers()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);

        using var readDictionary = board.GetDictionary();
        Assert.False(readDictionary.IsDisposed);

        var ids = board.GetIds();
        Assert.True(ids.Length > 0);

        var objPoints = board.GetObjPoints();
        Assert.Equal(ids.Length, objPoints.Length);

        var corner = board.GetRightBottomCorner();
        Assert.True(corner.X > 0);
        Assert.True(corner.Y > 0);
    }

    [Fact]
    public void CharucoBoard_MatchImagePoints()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        var chessboardCorners = board.GetChessboardCorners();

        var detectedCorners = new[] { new Point2f(chessboardCorners[0].X, chessboardCorners[0].Y) };
        using var detectedIds = Mat.FromArray(new[] { 0 });
        using var objPoints = new Mat();
        using var imgPoints = new Mat();

        board.MatchImagePoints(detectedCorners, detectedIds, objPoints, imgPoints);

        Assert.False(objPoints.Empty());
        Assert.False(imgPoints.Empty());
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
        using var detector = new CharucoDetector(board, default, default, 2, false, true, dp, rp);
        Assert.NotNull(detector);
    }

    [Fact]
    public void CharucoDetector_CreateWithCameraMatrix()
    {
        // Exercises the cameraMatrix/distCoeffs getMat() path in the native create.
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var cameraMatrix = Mat.Eye(3, 3, MatType.CV_64FC1).ToMat();
        using var distCoeffs = Mat.Zeros(1, 5, MatType.CV_64FC1).ToMat();

        using var detector = new CharucoDetector(board, cameraMatrix, distCoeffs);
        Assert.NotNull(detector);
    }

    [Fact]
    public void CharucoDetector_DetectDiamonds()
    {
        // Smoke test: a blank image detects no diamonds but must return valid (empty) arrays.
        // Diamond detection requires the detector's board to be a 3x3 ChArUco board.
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(3, 3, 0.04f, 0.02f, dict);
        using var image = Mat.ZerosMat(300, 300, MatType.CV_8UC1);

        using var detector = new CharucoDetector(board);
        detector.DetectDiamonds(image, out var diamondCorners, out var diamondIds,
            out var markerCorners, out var markerIds);

        Assert.NotNull(diamondCorners);
        Assert.NotNull(diamondIds);
        Assert.NotNull(markerCorners);
        Assert.NotNull(markerIds);
        Assert.Empty(diamondIds);
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
        using var emptyImage = Mat.ZerosMat(300, 300, MatType.CV_8UC1);

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

    [Fact]
    public void CharucoDetector_GetSetBoard()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var detector = new CharucoDetector(board);

        using var readBack = detector.GetBoard();
        Assert.Equal(board.ChessboardSize, readBack.ChessboardSize);

        using var board2 = new CharucoBoard(3, 3, 0.05f, 0.03f, dict);
        detector.SetBoard(board2);
        using var readBack2 = detector.GetBoard();
        Assert.Equal(board2.ChessboardSize, readBack2.ChessboardSize);
    }

    [Fact]
    public void CharucoDetector_GetSetCharucoParameters()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var detector = new CharucoDetector(board);

        using var cp = detector.GetCharucoParameters();
        Assert.Equal(2, cp.MinMarkers);
        Assert.False(cp.TryRefineMarkers);
        Assert.True(cp.CheckMarkers);

        cp.MinMarkers = 3;
        cp.CheckMarkers = false;
        detector.SetCharucoParameters(cp);

        using var cp2 = detector.GetCharucoParameters();
        Assert.Equal(3, cp2.MinMarkers);
        Assert.False(cp2.CheckMarkers);
    }

    [Fact]
    public void CharucoDetector_SetCharucoParameters_RejectsInconsistentCameraMatrix()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var detector = new CharucoDetector(board);

        using var cp = new CharucoParameters
        {
            CameraMatrix = Mat.Eye(3, 3, MatType.CV_64FC1).ToMat(),
        };

        Assert.Throws<ArgumentException>(() => detector.SetCharucoParameters(cp));
    }

    [Fact]
    public void CharucoDetector_GetSetDetectorParameters()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var detector = new CharucoDetector(board);

        var dp = detector.GetDetectorParameters();
        Assert.Equal(3, dp.AdaptiveThreshWinSizeMin);

        dp.AdaptiveThreshWinSizeMin = 5;
        detector.SetDetectorParameters(dp);

        var dp2 = detector.GetDetectorParameters();
        Assert.Equal(5, dp2.AdaptiveThreshWinSizeMin);
    }

    [Fact]
    public void CharucoDetector_GetSetRefineParameters()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var detector = new CharucoDetector(board);

        var rp = detector.GetRefineParameters();
        Assert.Equal(10f, rp.MinRepDistance, 1e-3f);

        rp.MinRepDistance = 7f;
        detector.SetRefineParameters(rp);

        var rp2 = detector.GetRefineParameters();
        Assert.Equal(7f, rp2.MinRepDistance, 1e-3f);
    }

    // ==================== DrawDetectedCornersCharuco / DrawDetectedDiamonds ====================

    [Fact]
    public void DrawDetectedCornersCharuco()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new CharucoBoard(5, 7, 0.04f, 0.02f, dict);
        using var boardImage = new Mat();
        board.GenerateImage(new Size(600, 800), boardImage, 10, 1);
        using var outputImage = new Mat();
        Cv2.CvtColor(boardImage, outputImage, ColorConversionCodes.GRAY2RGB);

        using var detector = new CharucoDetector(board);
        detector.DetectBoard(boardImage, out var charucoCorners, out var charucoIds, out _, out _);

        // With ids
        Cv2.Aruco.DrawDetectedCornersCharuco(outputImage, charucoCorners, charucoIds, new Scalar(0, 255, 0));
        // Without ids (null path)
        Cv2.Aruco.DrawDetectedCornersCharuco(outputImage, charucoCorners, null);
    }

    [Fact]
    public void DrawDetectedDiamonds()
    {
        using var image = Mat.ZerosMat(200, 200, MatType.CV_8UC3);

        // Synthetic diamond so the drawing path is exercised regardless of detection.
        var diamondCorners = new[]
        {
            new[]
            {
                new Point2f(20, 20), new Point2f(80, 20),
                new Point2f(80, 80), new Point2f(20, 80),
            },
        };
        var diamondIds = new[] { new Vec4i(0, 1, 2, 3) };

        // With ids
        Cv2.Aruco.DrawDetectedDiamonds(image, diamondCorners, diamondIds, new Scalar(0, 0, 255));
        // Without ids (null path)
        Cv2.Aruco.DrawDetectedDiamonds(image, diamondCorners, null);
    }

    // ==================== Board / GridBoard ====================

    private static Point3f[][] CreateObjPoints(int count)
    {
        // Corner order matches Board's documented convention (and what generateImage() assumes):
        // [0] left-top (min x, min y), [1] right-top (max x, min y),
        // [2] right-bottom (max x, max y), [3] left-bottom (min x, max y).
        var cols = (int)Math.Ceiling(Math.Sqrt(count));
        var result = new Point3f[count][];
        for (var i = 0; i < count; i++)
        {
            var x = (i % cols) * 2.0f;
            var y = (i / cols) * 2.0f;
            result[i] =
            [
                new Point3f(x, y, 0),
                new Point3f(x + 1, y, 0),
                new Point3f(x + 1, y + 1, 0),
                new Point3f(x, y + 1, 0),
            ];
        }
        return result;
    }

    [Fact]
    public void Board_CreateAndReadBack()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        var objPoints = CreateObjPoints(3);
        var ids = new[] { 0, 1, 2 };

        using var board = new Board(objPoints, dict, ids);

        Assert.Equal(ids, board.GetIds());
        var readObjPoints = board.GetObjPoints();
        Assert.Equal(3, readObjPoints.Length);
        foreach (var marker in readObjPoints)
            Assert.Equal(4, marker.Length);

        using var readDictionary = board.GetDictionary();
        Assert.False(readDictionary.IsDisposed);
    }

    [Fact]
    public void Board_Create_RejectsMarkerWithoutExactly4Corners()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        var badObjPoints = new[]
        {
            new[] { new Point3f(0, 0, 0), new Point3f(1, 0, 0), new Point3f(1, 1, 0) },
        };

        Assert.Throws<ArgumentException>(() => new Board(badObjPoints, dict, [0]));
    }

    [Fact]
    public void Board_GenerateImage()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new Board(CreateObjPoints(4), dict, [0, 1, 2, 3]);
        using var img = new Mat();

        board.GenerateImage(new Size(400, 400), img, marginSize: 10);

        Assert.False(img.Empty());
    }

    [Fact]
    public void Board_MatchImagePoints()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new Board(CreateObjPoints(1), dict, [0]);

        var detectedCorners = new[]
        {
            new[] { new Point2f(0, 0), new Point2f(1, 0), new Point2f(1, 1), new Point2f(0, 1) },
        };
        using var detectedIds = Mat.FromArray(new[] { 0 });
        using var objPoints = new Mat();
        using var imgPoints = new Mat();

        board.MatchImagePoints(detectedCorners, detectedIds, objPoints, imgPoints);

        Assert.False(objPoints.Empty());
        Assert.False(imgPoints.Empty());
    }

    [Fact]
    public void GridBoard_CreateAndProperties()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new GridBoard(new Size(3, 2), 0.04f, 0.01f, dict);

        Assert.Equal(new Size(3, 2), board.GetGridSize());
        Assert.Equal(0.04f, board.GetMarkerLength(), 1e-5f);
        Assert.Equal(0.01f, board.GetMarkerSeparation(), 1e-5f);
        Assert.Equal(6, board.GetIds().Length);
    }

    [Fact]
    public void GridBoard_CreateWithCustomIds()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        var ids = new[] { 5, 6, 7, 8 };
        using var board = new GridBoard(new Size(2, 2), 0.04f, 0.01f, dict, ids);

        Assert.Equal(ids, board.GetIds());
    }

    [Fact]
    public void GridBoard_GenerateImage()
    {
        using var dict = Cv2.Aruco.GetPredefinedDictionary(PredefinedDictionaryType.Dict4X4_50);
        using var board = new GridBoard(new Size(3, 2), 0.04f, 0.01f, dict);
        using var img = new Mat();

        board.GenerateImage(new Size(400, 300), img);

        Assert.False(img.Empty());
    }
}
