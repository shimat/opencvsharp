using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using OpenCvSharp.Aruco;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_detectMarkers(
        IntPtr image, IntPtr dictionary, IntPtr corners, IntPtr ids, ref DetectorParameters detectParameters, IntPtr outrejectedImgPoints);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_drawDetectedMarkers(
        IntPtr image, 
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2, 
        [MarshalAs(UnmanagedType.LPArray)] int[] ids, int idxLength, Scalar borderColor);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_drawDetectedMarkers(
        IntPtr image, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2, IntPtr ids, int idxLength, Scalar borderColor);
    
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_estimatePoseSingleMarkers(
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornersLength1, 
        int[] cornersLengths2, float markerLength, 
        IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr rvecs, IntPtr tvecs, IntPtr objPoints);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_getPredefinedDictionary(int name, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_readDictionary(string dictionaryFile, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_detectCharucoDiamond(
        IntPtr image, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] markerCorners, int markerCornersSize1, int[] markerCornersSize2,
        IntPtr markerIds, float squareMarkerLengthRate,
        IntPtr diamondCorners, IntPtr diamondIds, IntPtr cameraMatrix, IntPtr distCoeffs);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_drawDetectedDiamonds(
        IntPtr image,
        [MarshalAs(UnmanagedType.LPArray)] IntPtr[] corners, int cornerSize1, int[] contoursSize2,
        IntPtr ids, Scalar borderColor);

    #region Dictionary

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_delete(IntPtr ptr);
    
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_setMarkerSize(IntPtr obj, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_setMaxCorrectionBits(IntPtr obj, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getBytesList(IntPtr obj, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getMarkerSize(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getMaxCorrectionBits(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_identify(
        IntPtr obj,
        IntPtr onlyBits,
        out int idx,
        out int rotation,
        double maxCorrectionRate,
        out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getDistanceToId(
        IntPtr obj,
        IntPtr bits,
        int id,
        int allRotations,
        out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_generateImageMarker(
        IntPtr obj,
        int id,
        int sidePixels,
        IntPtr img,
        int borderBits);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getByteListFromBits(
        IntPtr bits,
        IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus aruco_Dictionary_getBitsFromByteList(
        IntPtr byteList,
        int markerSize,
        IntPtr returnValue);

    #endregion
}
