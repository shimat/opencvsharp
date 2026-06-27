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
    public static partial ExceptionStatus aruco_drawDetectedMarkers(
        IntPtr image,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2,
        [MarshalAs(UnmanagedType.LPArray)] int[] ids, int idxLength, Scalar borderColor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_drawDetectedMarkers(
        IntPtr image, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2, IntPtr ids, int idxLength, Scalar borderColor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_getPredefinedDictionary(int name, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_readDictionary([MarshalAs(UnmanagedType.LPStr)] string dictionaryFile, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_drawDetectedDiamonds(
        IntPtr image,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2,
        IntPtr ids, Scalar borderColor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_drawDetectedCornersCharuco(
        IntPtr image,
        IntPtr corners, IntPtr ids, Scalar cornerColor);

    #region ArucoDetector

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_create(
        IntPtr dictionary, ref DetectorParameters detectorParams, ref RefineParameters refineParams, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_detectMarkers(
        OpenCvSafeHandle detector, IntPtr image, IntPtr corners, IntPtr ids, IntPtr rejectedImgPoints);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_ArucoDetector_refineDetectedMarkers(
        OpenCvSafeHandle detector, IntPtr image, IntPtr board,
        IntPtr detectedCorners, IntPtr detectedIds, IntPtr rejectedCorners,
        IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr recoveredIdxs);

    #endregion

    #region CharucoBoard

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_create(
        int squaresX, int squaresY, float squareLength, float markerLength, IntPtr dictionary, out IntPtr returnValue);

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
    public static partial ExceptionStatus aruco_CharucoBoard_generateImage(
        OpenCvSafeHandle ptr, Size outSize, IntPtr img, int marginSize, int borderBits);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoBoard_checkCharucoCornersCollinear(
        OpenCvSafeHandle ptr, IntPtr charucoIds, out int returnValue);

    #endregion

    #region CharucoDetector

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_create(
        IntPtr board, IntPtr cameraMatrix, IntPtr distCoeffs,
        int minMarkers,
        [MarshalAs(UnmanagedType.U1)] bool tryRefineMarkers,
        [MarshalAs(UnmanagedType.U1)] bool checkMarkers,
        ref DetectorParameters detectorParams, ref RefineParameters refineParams,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_detectBoard(
        OpenCvSafeHandle detector, IntPtr image,
        IntPtr charucoCorners, IntPtr charucoIds,
        IntPtr markerCorners, IntPtr markerIds);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_CharucoDetector_detectDiamonds(
        OpenCvSafeHandle detector, IntPtr image,
        IntPtr diamondCorners, IntPtr diamondIds,
        IntPtr markerCorners, IntPtr markerIds);

    #endregion

    #region Dictionary

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_delete(IntPtr ptr);

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
    public static partial ExceptionStatus aruco_Dictionary_getDistanceToId(
        OpenCvSafeHandle obj,
        IntPtr bits,
        int id,
        int allRotations,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_generateImageMarker(
        OpenCvSafeHandle obj,
        int id,
        int sidePixels,
        IntPtr img,
        int borderBits);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_getByteListFromBits(
        IntPtr bits,
        IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus aruco_Dictionary_getBitsFromByteList(
        IntPtr byteList,
        int markerSize,
        IntPtr returnValue);

    #endregion
}
