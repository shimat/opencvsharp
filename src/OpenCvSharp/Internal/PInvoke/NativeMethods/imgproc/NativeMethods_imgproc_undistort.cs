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
    public static partial ExceptionStatus imgproc_drawFrameAxes(
        IntPtr image, IntPtr cameraMatrix, IntPtr distCoeffs,
        IntPtr rvec, IntPtr tvec, float length, int thickness);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_undistort(
        IntPtr src, IntPtr dst,
        IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr newCameraMatrix);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_initUndistortRectifyMap(
        IntPtr cameraMatrix, IntPtr distCoeffs,
        IntPtr R, IntPtr newCameraMatrix,
        Size size, MatType m1type, IntPtr map1, IntPtr map2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_initWideAngleProjMap(
        IntPtr cameraMatrix, IntPtr distCoeffs,
        Size imageSize, int destImageWidth,
        MatType m1type, IntPtr map1, IntPtr map2,
        int projType, double alpha, out float returnValue);
}
