using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_projectPoints2(
        IntPtr objectPoints, IntPtr imagePoints, IntPtr rvec, IntPtr tvec,
        IntPtr K, IntPtr D, double alpha, IntPtr jacobian);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_distortPoints(
        IntPtr undistorted, IntPtr distorted, IntPtr K, IntPtr D, double alpha);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_distortPoints2(
        IntPtr undistorted, IntPtr distorted, IntPtr Kundistorted, IntPtr K, IntPtr D, double alpha);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_undistortPoints(
        IntPtr distorted, IntPtr undistorted,
        IntPtr K, IntPtr D, IntPtr R, IntPtr P);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_initUndistortRectifyMap(
        IntPtr K, IntPtr D, IntPtr R, IntPtr P,
        Size size, int m1type, IntPtr map1, IntPtr map2);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_undistortImage(
        IntPtr distorted, IntPtr undistorted,
        IntPtr K, IntPtr D, IntPtr Knew, Size newSize);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_estimateNewCameraMatrixForUndistortRectify(
        IntPtr K, IntPtr D, Size image_size, IntPtr R,
        IntPtr P, double balance, Size newSize, double fov_scale);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_calibrate(
        IntPtr objectPoints, IntPtr imagePoints, 
        Size imageSize,
        IntPtr K,
        IntPtr D,
        IntPtr rvecs,
        IntPtr tvecs,
        int flags,
        TermCriteria criteria,
        out double returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_stereoRectify(
        IntPtr K1, IntPtr D1, IntPtr K2, IntPtr D2, Size imageSize, IntPtr R, IntPtr tvec,
        IntPtr R1, IntPtr R2, IntPtr P1, IntPtr P2, IntPtr Q, int flags, Size newImageSize,
        double balance, double fov_scale);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus calib_fisheye_stereoCalibrate(
        IntPtr objectPoints,
        IntPtr imagePoints1, 
        IntPtr imagePoints2, 
        IntPtr K1,
        IntPtr D1,
        IntPtr K2,
        IntPtr D2,
        Size imageSize,
        IntPtr R,
        IntPtr T,
        int flags,
        TermCriteria criteria,
        out double returnValue);
}
