using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_projectPoints2(
        in InputArrayProxy objectPoints, in OutputArrayProxy imagePoints, in InputArrayProxy rvec, in InputArrayProxy tvec,
        in InputArrayProxy K, in InputArrayProxy D, double alpha, in OutputArrayProxy jacobian);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_distortPoints(
        in InputArrayProxy undistorted, in OutputArrayProxy distorted, in InputArrayProxy K, in InputArrayProxy D, double alpha);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_distortPoints2(
        in InputArrayProxy undistorted, in OutputArrayProxy distorted, in InputArrayProxy Kundistorted, in InputArrayProxy K, in InputArrayProxy D, double alpha);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_undistortPoints(
        in InputArrayProxy distorted, in OutputArrayProxy undistorted,
        in InputArrayProxy K, in InputArrayProxy D, in InputArrayProxy R, in InputArrayProxy P);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_initUndistortRectifyMap(
        in InputArrayProxy K, in InputArrayProxy D, in InputArrayProxy R, in InputArrayProxy P,
        Size size, int m1type, in OutputArrayProxy map1, in OutputArrayProxy map2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_undistortImage(
        in InputArrayProxy distorted, in OutputArrayProxy undistorted,
        in InputArrayProxy K, in InputArrayProxy D, in InputArrayProxy Knew, Size newSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_estimateNewCameraMatrixForUndistortRectify(
        in InputArrayProxy K, in InputArrayProxy D, Size image_size, in InputArrayProxy R,
        in OutputArrayProxy P, double balance, Size newSize, double fov_scale);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_calibrate(
        IntPtr objectPoints, IntPtr imagePoints, 
        Size imageSize,
        in InputOutputArrayProxy K,
        in InputOutputArrayProxy D,
        IntPtr rvecs,
        IntPtr tvecs,
        int flags,
        TermCriteria criteria,
        out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_stereoRectify(
        in InputArrayProxy K1, in InputArrayProxy D1, in InputArrayProxy K2, in InputArrayProxy D2, Size imageSize, in InputArrayProxy R, in InputArrayProxy tvec,
        in OutputArrayProxy R1, in OutputArrayProxy R2, in OutputArrayProxy P1, in OutputArrayProxy P2, in OutputArrayProxy Q, int flags, Size newImageSize,
        double balance, double fov_scale);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus calib_fisheye_stereoCalibrate(
        IntPtr objectPoints,
        IntPtr imagePoints1, 
        IntPtr imagePoints2, 
        in InputOutputArrayProxy K1,
        in InputOutputArrayProxy D1,
        in InputOutputArrayProxy K2,
        in InputOutputArrayProxy D2,
        Size imageSize,
        in OutputArrayProxy R,
        in OutputArrayProxy T,
        int flags,
        TermCriteria criteria,
        out double returnValue);
}
