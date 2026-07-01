using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_registerDepth(
        in InputArrayProxy unregisteredCameraMatrix, in InputArrayProxy registeredCameraMatrix, in InputArrayProxy registeredDistCoeffs,
        in InputArrayProxy rt, in InputArrayProxy unregisteredDepth, Size outputImagePlaneSize,
        in OutputArrayProxy registeredDepth, int depthDilation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_depthTo3dSparse(in InputArrayProxy depth, in InputArrayProxy inK, in InputArrayProxy inPoints, in OutputArrayProxy points3d);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_depthTo3d(in InputArrayProxy depth, in InputArrayProxy k, in OutputArrayProxy points3d, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_rescaleDepth(in InputArrayProxy src, int type, in OutputArrayProxy dst, double depthFactor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_warpFrame(
        in InputArrayProxy depth, in InputArrayProxy image, in InputArrayProxy mask, in InputArrayProxy rt, in InputArrayProxy cameraMatrix,
        in OutputArrayProxy warpedDepth, in OutputArrayProxy warpedImage, in OutputArrayProxy warpedMask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_findPlanes(
        in InputArrayProxy points3d, in InputArrayProxy normals, in OutputArrayProxy mask, in OutputArrayProxy planeCoefficients,
        int blockSize, int minSize, double threshold,
        double sensorErrorA, double sensorErrorB, double sensorErrorC, int method);
}
