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
    public static partial ExceptionStatus ptcloud_Volume_new(int vtype, IntPtr settings, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Volume_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_integrateFrame(OpenCvSafeHandle obj, IntPtr frame, in InputArrayProxy pose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_integrate(OpenCvSafeHandle obj, in InputArrayProxy depth, in InputArrayProxy pose);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_integrateColor(OpenCvSafeHandle obj, in InputArrayProxy depth, in InputArrayProxy image, in InputArrayProxy pose);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_raycast(OpenCvSafeHandle obj, in InputArrayProxy cameraPose, in OutputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_raycastColor(OpenCvSafeHandle obj, in InputArrayProxy cameraPose, in OutputArrayProxy points, in OutputArrayProxy normals, in OutputArrayProxy colors);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_raycastEx(OpenCvSafeHandle obj, in InputArrayProxy cameraPose, int height, int width, in InputArrayProxy k, in OutputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_raycastExColor(OpenCvSafeHandle obj, in InputArrayProxy cameraPose, int height, int width, in InputArrayProxy k, in OutputArrayProxy points, in OutputArrayProxy normals, in OutputArrayProxy colors);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_fetchNormals(OpenCvSafeHandle obj, in InputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_fetchPointsNormals(OpenCvSafeHandle obj, in OutputArrayProxy points, in OutputArrayProxy normals);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_fetchPointsNormalsColors(OpenCvSafeHandle obj, in OutputArrayProxy points, in OutputArrayProxy normals, in OutputArrayProxy colors);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Volume_reset(OpenCvSafeHandle obj);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Volume_getVisibleBlocks(OpenCvSafeHandle obj, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Volume_getTotalVolumeUnits(OpenCvSafeHandle obj, out long returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ptcloud_Volume_getBoundingBox(OpenCvSafeHandle obj, in OutputArrayProxy bb, int precision);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Volume_setEnableGrowth(OpenCvSafeHandle obj, int v);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Volume_getEnableGrowth(OpenCvSafeHandle obj, out int returnValue);
}
