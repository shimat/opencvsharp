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
    internal static partial ExceptionStatus imgproc_drawFrameAxes(
        in InputOutputArrayProxy image, in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        in InputArrayProxy rvec, in InputArrayProxy tvec, float length, int thickness);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_undistort(
        in InputArrayProxy src, in OutputArrayProxy dst,
        in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs, in InputArrayProxy newCameraMatrix);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_initUndistortRectifyMap(
        in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        in InputArrayProxy R, in InputArrayProxy newCameraMatrix,
        Size size, MatType m1type, in OutputArrayProxy map1, in OutputArrayProxy map2);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_initWideAngleProjMap(
        in InputArrayProxy cameraMatrix, in InputArrayProxy distCoeffs,
        Size imageSize, int destImageWidth,
        MatType m1type, in OutputArrayProxy map1, in OutputArrayProxy map2,
        int projType, double alpha, out float returnValue);
}
