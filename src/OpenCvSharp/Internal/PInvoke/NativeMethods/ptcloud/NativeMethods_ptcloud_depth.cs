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
    public static partial ExceptionStatus ptcloud_registerDepth(
        IntPtr unregisteredCameraMatrix, IntPtr registeredCameraMatrix, IntPtr registeredDistCoeffs,
        IntPtr rt, IntPtr unregisteredDepth, Size outputImagePlaneSize,
        IntPtr registeredDepth, int depthDilation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_depthTo3dSparse(IntPtr depth, IntPtr inK, IntPtr inPoints, IntPtr points3d);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_depthTo3d(IntPtr depth, IntPtr k, IntPtr points3d, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_rescaleDepth(IntPtr src, int type, IntPtr dst, double depthFactor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_warpFrame(
        IntPtr depth, IntPtr image, IntPtr mask, IntPtr rt, IntPtr cameraMatrix,
        IntPtr warpedDepth, IntPtr warpedImage, IntPtr warpedMask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_findPlanes(
        IntPtr points3d, IntPtr normals, IntPtr mask, IntPtr planeCoefficients,
        int blockSize, int minSize, double threshold,
        double sensorErrorA, double sensorErrorB, double sensorErrorC, int method);
}
