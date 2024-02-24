using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    // TODO
    /*
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void calib3d_fisheye_projectPoints1(
        IntPtr objectPoints, IntPtr imagePoints, IntPtr affine,
        IntPtr K, IntPtr D, double alpha, IntPtr jacobian);*/

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib3d_fisheye_projectPoints2(
        IntPtr objectPoints, IntPtr imagePoints, IntPtr rvec, IntPtr tvec,
        IntPtr K, IntPtr D, double alpha, IntPtr jacobian);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib3d_fisheye_distortPoints(
        IntPtr undistorted, IntPtr distorted, IntPtr K, IntPtr D, double alpha);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib3d_fisheye_undistortPoints(
        IntPtr distorted, IntPtr undistorted,
        IntPtr K, IntPtr D, IntPtr R, IntPtr P);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib3d_fisheye_initUndistortRectifyMap(
        IntPtr K, IntPtr D, IntPtr R, IntPtr P,
        Size size, int m1type, IntPtr map1, IntPtr map2);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib3d_fisheye_undistortImage(
        IntPtr distorted, IntPtr undistorted,
        IntPtr K, IntPtr D, IntPtr Knew, Size newSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib3d_fisheye_estimateNewCameraMatrixForUndistortRectify(
        IntPtr K, IntPtr D, Size image_size, IntPtr R,
        IntPtr P, double balance, Size newSize, double fov_scale);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib3d_fisheye_calibrate(
        IntPtr objectPoints, IntPtr imagePoints, 
        Size imageSize,
        IntPtr K,
        IntPtr D,
        IntPtr rvecs,
        IntPtr tvecs,
        int flags,
        TermCriteria criteria,
        out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib3d_fisheye_stereoRectify(
        IntPtr K1, IntPtr D1, IntPtr K2, IntPtr D2, Size imageSize, IntPtr R, IntPtr tvec,
        IntPtr R1, IntPtr R2, IntPtr P1, IntPtr P2, IntPtr Q, int flags, Size newImageSize,
        double balance, double fov_scale);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus calib3d_fisheye_stereoCalibrate(
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
