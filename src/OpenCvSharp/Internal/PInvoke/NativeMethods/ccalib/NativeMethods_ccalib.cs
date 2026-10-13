using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ccalib_omnidir_projectPoints(
        in InputArrayProxy objectPoints, in OutputArrayProxy imagePoints,
        in InputArrayProxy rvec, in InputArrayProxy tvec,
        in InputArrayProxy K, double xi, in InputArrayProxy D,
        in OutputArrayProxy jacobian);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ccalib_omnidir_undistortPoints(
        in InputArrayProxy distorted, in OutputArrayProxy undistorted,
        in InputArrayProxy K, in InputArrayProxy D,
        in InputArrayProxy xi, in InputArrayProxy R);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ccalib_omnidir_initUndistortRectifyMap(
        in InputArrayProxy K, in InputArrayProxy D, in InputArrayProxy xi,
        in InputArrayProxy R, in InputArrayProxy P, Size size, int m1type,
        in OutputArrayProxy map1, in OutputArrayProxy map2, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ccalib_omnidir_undistortImage(
        in InputArrayProxy distorted, in OutputArrayProxy undistorted,
        in InputArrayProxy K, in InputArrayProxy D, in InputArrayProxy xi,
        int flags, in InputArrayProxy Knew, Size newSize, in InputArrayProxy R);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ccalib_omnidir_calibrate(
        IntPtr objectPoints, IntPtr imagePoints, Size imageSize,
        in InputOutputArrayProxy K, in InputOutputArrayProxy xi, in InputOutputArrayProxy D,
        IntPtr rvecs, IntPtr tvecs, int flags, TermCriteria criteria,
        in OutputArrayProxy indices, out double returnValue);
}
