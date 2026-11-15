using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_removeStatisticalOutliers(
        in InputArrayProxy inputCloud, in OutputArrayProxy outputCloud, int meanK, double stddevMulThresh,
        in OutputArrayProxy keptIndices);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_removeRadiusOutliers(
        in InputArrayProxy inputCloud, in OutputArrayProxy outputCloud, double radius, int minNeighbors,
        in OutputArrayProxy keptIndices);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_orientNormals(
        in InputArrayProxy inputCloud, in InputOutputArrayProxy normals, Point3f viewpoint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_orientNormalsConsistent(
        in InputArrayProxy inputCloud, in InputOutputArrayProxy normals, int k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_estimateMedianSpacing(
        in InputArrayProxy inputCloud, out float result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_createMeshBPA(
        in InputArrayProxy inputCloud, in InputArrayProxy normals, in OutputArrayProxy vertices,
        in OutputArrayProxy triangles, in InputArrayProxy radii);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_boundingBox3D(
        in InputArrayProxy inputCloud, in OutputArrayProxy minBound, in OutputArrayProxy maxBound);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_orientedBoundingBox3D(
        in InputArrayProxy inputCloud, in OutputArrayProxy center, in OutputArrayProxy axes,
        in OutputArrayProxy halfExtents);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_approxEnclosingSphere3D(
        in InputArrayProxy inputCloud, in OutputArrayProxy center, out double result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_decodeGaussianSplats(
        in InputArrayProxy attributes, in OutputArrayProxy splats);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_decodeGaussianSplatsPacked(
        in InputArrayProxy buffer, in OutputArrayProxy splats);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_getGaussianSplatPlyPropNames(IntPtr names);

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_loadGaussianSplats"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus ptcloud_loadGaussianSplats_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string filename, in OutputArrayProxy splats, IntPtr properties);

    [LibraryImport(DllExtern, EntryPoint = "ptcloud_loadGaussianSplats"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus ptcloud_loadGaussianSplats_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string filename, in OutputArrayProxy splats, IntPtr properties);

    internal static ExceptionStatus ptcloud_loadGaussianSplats(string filename, in OutputArrayProxy splats, IntPtr properties)
        => IsWindows()
            ? ptcloud_loadGaussianSplats_Windows(filename, splats, properties)
            : ptcloud_loadGaussianSplats_NotWindows(filename, splats, properties);
}
