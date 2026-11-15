using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_create(
        IntPtr detector, IntPtr matcher, in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        in VisualOdometryParams parameters, out IntPtr odometry);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_delete(IntPtr odometry);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_getDefaultParams(out VisualOdometryParams parameters);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_processFrame(OpenCvSafeHandle odometry, in InputArrayProxy image, out int emitted);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_reset(OpenCvSafeHandle odometry);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_getState(OpenCvSafeHandle odometry, out VisualOdometryState state);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_getLastPose(OpenCvSafeHandle odometry, in OutputArrayProxy pose);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_getNumKeyframes(OpenCvSafeHandle odometry, out int count);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_getNumMapPoints(OpenCvSafeHandle odometry, out int count);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_getTrajectory(OpenCvSafeHandle odometry, OpenCvSafeHandle poses);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_getParams(OpenCvSafeHandle odometry, out VisualOdometryParams parameters);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_VisualOdometry_setParams(OpenCvSafeHandle odometry, in VisualOdometryParams parameters);
}
