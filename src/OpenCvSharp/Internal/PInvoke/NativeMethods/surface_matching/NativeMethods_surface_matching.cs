using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401
#pragma warning disable IDE1006

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus surface_matching_ICP_new1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus surface_matching_ICP_new2(
        int iterations,
        float tolerance,
        float rejectionScale,
        int numberOfLevels,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus surface_matching_ICP_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus surface_matching_ICP_registerModelToScene(
        OpenCvSafeHandle obj,
        in InputArrayProxy sourcePointCloud,
        in InputArrayProxy destinationPointCloud,
        out double residual,
        out IntPtr pose,
        out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus surface_matching_computeNormalsPC3d(
        in InputArrayProxy pointCloud,
        in OutputArrayProxy pointCloudWithNormals,
        int numberOfNeighbors,
        int flipViewpoint,
        Vec3f viewpoint,
        out int returnValue);
}
