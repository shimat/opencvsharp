using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Aruco;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_drawDetectedMarkers(
        in InputOutputArrayProxy image,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2,
        [MarshalAs(UnmanagedType.LPArray)] int[] ids, int idxLength, Scalar borderColor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_drawDetectedMarkers(
        in InputOutputArrayProxy image, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2, IntPtr ids, int idxLength, Scalar borderColor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_getPredefinedDictionary(int name, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_readDictionary([MarshalAs(UnmanagedType.LPStr)] string dictionaryFile, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_extendDictionary(
        int nMarkers, int markerSize, IntPtr baseDictionary, int randomSeed, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_drawDetectedDiamonds(
        in InputOutputArrayProxy image,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2,
        IntPtr ids, Scalar borderColor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_drawDetectedCornersCharuco(
        in InputOutputArrayProxy image,
        IntPtr corners, IntPtr ids, Scalar cornerColor);

    #region ArucoDetector

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_create(
        IntPtr dictionary, ref DetectorParameters detectorParams, ref RefineParameters refineParams, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_ArucoDetector_detectMarkers(
        OpenCvSafeHandle detector, in InputArrayProxy image, IntPtr corners, IntPtr ids, IntPtr rejectedImgPoints);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_ArucoDetector_refineDetectedMarkers(
        OpenCvSafeHandle detector, in InputArrayProxy image, IntPtr board,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] detectedCorners, int detectedCornersSize1, int[] detectedCornersSize2,
        [MarshalAs(UnmanagedType.LPArray)] int[] detectedIds, int detectedIdsSize,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] rejectedCorners, int rejectedCornersSize1, int[] rejectedCornersSize2,
        in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        IntPtr outDetectedCorners, IntPtr outDetectedIds, IntPtr outRejectedCorners, IntPtr recoveredIdxs);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_create_MultiDict(
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] dictionaries, int dictionariesSize,
        ref DetectorParameters detectorParams, ref RefineParameters refineParams, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_ArucoDetector_detectMarkersWithConfidence(
        OpenCvSafeHandle detector, in InputArrayProxy image, IntPtr corners, IntPtr ids,
        IntPtr markersConfidence, IntPtr rejectedImgPoints);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_ArucoDetector_detectMarkersMultiDict(
        OpenCvSafeHandle detector, in InputArrayProxy image, IntPtr corners, IntPtr ids,
        IntPtr rejectedImgPoints, IntPtr dictIndices);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_getDictionary(OpenCvSafeHandle detector, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_setDictionary(OpenCvSafeHandle detector, IntPtr dictionary);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_getDictionariesSize(OpenCvSafeHandle detector, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_getDictionaries(
        OpenCvSafeHandle detector, [Out] IntPtr[] outArray, int arraySize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_setDictionaries(
        OpenCvSafeHandle detector, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] dictionaries, int dictionariesSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_getDetectorParameters(OpenCvSafeHandle detector, out DetectorParameters returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_setDetectorParameters(OpenCvSafeHandle detector, ref DetectorParameters detectorParameters);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_getRefineParameters(OpenCvSafeHandle detector, out RefineParameters returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_setRefineParameters(OpenCvSafeHandle detector, ref RefineParameters refineParameters);

    #endregion

    #region CharucoBoard

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_create(
        int squaresX, int squaresY, float squareLength, float markerLength, IntPtr dictionary, IntPtr ids, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_getChessboardSize(OpenCvSafeHandle ptr, out Size returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_getSquareLength(OpenCvSafeHandle ptr, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_getMarkerLength(OpenCvSafeHandle ptr, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_setLegacyPattern(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_getLegacyPattern(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_CharucoBoard_generateImage(
        OpenCvSafeHandle ptr, Size outSize, in OutputArrayProxy img, int marginSize, int borderBits);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_CharucoBoard_checkCharucoCornersCollinear(
        OpenCvSafeHandle ptr, in InputArrayProxy charucoIds, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_getChessboardCorners(OpenCvSafeHandle ptr, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_getNearestMarkerIdx(OpenCvSafeHandle ptr, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_getNearestMarkerCorners(OpenCvSafeHandle ptr, IntPtr returnValue);

    #endregion

    #region CharucoDetector

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_CharucoDetector_create(
        IntPtr board, in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        int minMarkers,
        [MarshalAs(UnmanagedType.U1)] bool tryRefineMarkers,
        [MarshalAs(UnmanagedType.U1)] bool checkMarkers,
        ref DetectorParameters detectorParams, ref RefineParameters refineParams,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_CharucoDetector_detectBoard(
        OpenCvSafeHandle detector, in InputArrayProxy image,
        IntPtr charucoCorners, IntPtr charucoIds,
        IntPtr markerCorners, IntPtr markerIds);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_CharucoDetector_detectDiamonds(
        OpenCvSafeHandle detector, in InputArrayProxy image,
        IntPtr diamondCorners, IntPtr diamondIds,
        IntPtr markerCorners, IntPtr markerIds);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_getBoard(OpenCvSafeHandle detector, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_setBoard(OpenCvSafeHandle detector, IntPtr board);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_getCharucoParameters(
        OpenCvSafeHandle detector,
        out IntPtr cameraMatrix, out IntPtr distCoeffs, out int minMarkers, out int tryRefineMarkers, out int checkMarkers);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_CharucoDetector_setCharucoParameters(
        OpenCvSafeHandle detector,
        in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        int minMarkers, int tryRefineMarkers, int checkMarkers);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_getDetectorParameters(OpenCvSafeHandle detector, out DetectorParameters returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_setDetectorParameters(OpenCvSafeHandle detector, ref DetectorParameters detectorParameters);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_getRefineParameters(OpenCvSafeHandle detector, out RefineParameters returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_setRefineParameters(OpenCvSafeHandle detector, ref RefineParameters refineParameters);

    #endregion

    #region Dictionary

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_new_default(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_new(IntPtr bytesList, int markerSize, int maxCorrectionBits, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_readDictionary(OpenCvSafeHandle obj, IntPtr fn, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_writeDictionary(
        OpenCvSafeHandle obj, IntPtr fs, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_setMarkerSize(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_setMaxCorrectionBits(OpenCvSafeHandle obj, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_getBytesList(OpenCvSafeHandle obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_getMarkerSize(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_getMaxCorrectionBits(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_identify(
        OpenCvSafeHandle obj,
        IntPtr onlyBits,
        out int idx,
        out int rotation,
        double maxCorrectionRate,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_identify_withThreshold(
        OpenCvSafeHandle obj,
        IntPtr onlyCellPixelRatio,
        out int idx,
        out int rotation,
        double maxCorrectionRate,
        float validBitIdThreshold,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_Dictionary_getDistanceToId(
        OpenCvSafeHandle obj,
        in InputArrayProxy bits,
        int id,
        int allRotations,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_Dictionary_generateImageMarker(
        OpenCvSafeHandle obj,
        int id,
        int sidePixels,
        in OutputArrayProxy img,
        int borderBits);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_getByteListFromBits(
        IntPtr bits,
        IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_getBitsFromByteList(
        IntPtr byteList,
        int markerSize,
        int rotationId,
        IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_getMarkerBits(
        OpenCvSafeHandle obj,
        int markerId,
        int rotationId,
        IntPtr returnValue);

    #endregion

    #region Board

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_Board_create(
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] objPoints, int objPointsSize1, int[] objPointsSize2,
        IntPtr dictionary, IntPtr ids, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Board_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Board_getDictionary(OpenCvSafeHandle ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Board_getObjPoints(OpenCvSafeHandle ptr, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Board_getIds(OpenCvSafeHandle ptr, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Board_getRightBottomCorner(OpenCvSafeHandle ptr, out Point3f returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_Board_matchImagePoints(
        OpenCvSafeHandle ptr,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] detectedCorners, int detectedCornersSize1, int[] detectedCornersSize2,
        in InputArrayProxy detectedIds, in OutputArrayProxy objPoints, in OutputArrayProxy imgPoints);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_Board_matchImagePoints_flat(
        OpenCvSafeHandle ptr, IntPtr detectedCorners,
        in InputArrayProxy detectedIds, in OutputArrayProxy objPoints, in OutputArrayProxy imgPoints);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus aruco_Board_generateImage(
        OpenCvSafeHandle ptr, Size outSize, in OutputArrayProxy img, int marginSize, int borderBits);

    #endregion

    #region GridBoard

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_GridBoard_create(
        Size size, float markerLength, float markerSeparation, IntPtr dictionary, IntPtr ids, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_GridBoard_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_GridBoard_getGridSize(OpenCvSafeHandle ptr, out Size returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_GridBoard_getMarkerLength(OpenCvSafeHandle ptr, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_GridBoard_getMarkerSeparation(OpenCvSafeHandle ptr, out float returnValue);

    #endregion
}
