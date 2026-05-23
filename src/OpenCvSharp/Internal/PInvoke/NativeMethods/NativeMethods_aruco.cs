using System.Runtime.InteropServices;
using OpenCvSharp.Aruco;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_drawDetectedMarkers(
        IntPtr image,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2,
        [MarshalAs(UnmanagedType.LPArray)] int[] ids, int idxLength, Scalar borderColor);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_drawDetectedMarkers(
        IntPtr image, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2, IntPtr ids, int idxLength, Scalar borderColor);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_getPredefinedDictionary(int name, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_readDictionary(string dictionaryFile, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_drawDetectedDiamonds(
        IntPtr image,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2,
        IntPtr ids, Scalar borderColor);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_drawDetectedCornersCharuco(
        IntPtr image,
        IntPtr corners, IntPtr ids, Scalar cornerColor);

    #region ArucoDetector

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_ArucoDetector_create(
        IntPtr dictionary, ref DetectorParameters detectorParams, ref RefineParameters refineParams, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_ArucoDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_ArucoDetector_detectMarkers(
        IntPtr detector, IntPtr image, IntPtr corners, IntPtr ids, IntPtr rejectedImgPoints);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_ArucoDetector_refineDetectedMarkers(
        IntPtr detector, IntPtr image, IntPtr board,
        IntPtr detectedCorners, IntPtr detectedIds, IntPtr rejectedCorners,
        IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr recoveredIdxs);

    #endregion

    #region CharucoBoard

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoBoard_create(
        int squaresX, int squaresY, float squareLength, float markerLength, IntPtr dictionary, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoBoard_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoBoard_getChessboardSize(IntPtr ptr, out Size returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoBoard_getSquareLength(IntPtr ptr, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoBoard_getMarkerLength(IntPtr ptr, out float returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoBoard_setLegacyPattern(IntPtr ptr, int value);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoBoard_getLegacyPattern(IntPtr ptr, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoBoard_generateImage(
        IntPtr ptr, Size outSize, IntPtr img, int marginSize, int borderBits);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoBoard_checkCharucoCornersCollinear(
        IntPtr ptr, IntPtr charucoIds, out int returnValue);

    #endregion

    #region CharucoDetector

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoDetector_create(
        IntPtr board, IntPtr cameraMatrix, IntPtr distCoeffs,
        int minMarkers,
        [MarshalAs(UnmanagedType.U1)] bool tryRefineMarkers,
        [MarshalAs(UnmanagedType.U1)] bool checkMarkers,
        ref DetectorParameters detectorParams, ref RefineParameters refineParams,
        out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoDetector_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoDetector_detectBoard(
        IntPtr detector, IntPtr image,
        IntPtr charucoCorners, IntPtr charucoIds,
        IntPtr markerCorners, IntPtr markerIds);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_CharucoDetector_detectDiamonds(
        IntPtr detector, IntPtr image,
        IntPtr diamondCorners, IntPtr diamondIds,
        IntPtr markerCorners, IntPtr markerIds);

    #endregion

    #region Dictionary

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_delete(IntPtr ptr);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_setMarkerSize(IntPtr obj, int value);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_setMaxCorrectionBits(IntPtr obj, int value);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getBytesList(IntPtr obj, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getMarkerSize(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getMaxCorrectionBits(IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_identify(
        IntPtr obj,
        IntPtr onlyBits,
        out int idx,
        out int rotation,
        double maxCorrectionRate,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getDistanceToId(
        IntPtr obj,
        IntPtr bits,
        int id,
        int allRotations,
        out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_generateImageMarker(
        IntPtr obj,
        int id,
        int sidePixels,
        IntPtr img,
        int borderBits);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getByteListFromBits(
        IntPtr bits,
        IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getBitsFromByteList(
        IntPtr byteList,
        int markerSize,
        IntPtr returnValue);

    #endregion
}
