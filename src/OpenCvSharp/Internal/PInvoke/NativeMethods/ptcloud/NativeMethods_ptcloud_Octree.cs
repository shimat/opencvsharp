using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_createWithDepthSize(
        int maxDepth, double size, Point3f origin, int withColors, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_createWithDepthCloud(
        int maxDepth, in InputArrayProxy cloud, in InputArrayProxy colors, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_createWithResolutionSize(
        double resolution, double size, Point3f origin, int withColors, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_createWithResolutionCloud(
        double resolution, in InputArrayProxy cloud, in InputArrayProxy colors, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Ptr_Octree_delete(IntPtr obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Ptr_Octree_get(IntPtr obj, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_insertPoint(OpenCvSafeHandle obj,
        Point3f point, Point3f color, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_isPointInBound(OpenCvSafeHandle obj,
        Point3f point, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_empty(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_clear(OpenCvSafeHandle obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_deletePoint(OpenCvSafeHandle obj,
        Point3f point, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_getPointCloud(OpenCvSafeHandle obj,
        in OutputArrayProxy cloud, in OutputArrayProxy colors);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_radiusSearch(OpenCvSafeHandle obj,
        Point3f query, float radius, in OutputArrayProxy points,
        in OutputArrayProxy squareDists, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_radiusSearchColor(OpenCvSafeHandle obj,
        Point3f query, float radius, in OutputArrayProxy points,
        in OutputArrayProxy colors, in OutputArrayProxy squareDists, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_knnSearch(OpenCvSafeHandle obj,
        Point3f query, int k, in OutputArrayProxy points, in OutputArrayProxy squareDists);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Octree_knnSearchColor(OpenCvSafeHandle obj,
        Point3f query, int k, in OutputArrayProxy points,
        in OutputArrayProxy colors, in OutputArrayProxy squareDists);
}
