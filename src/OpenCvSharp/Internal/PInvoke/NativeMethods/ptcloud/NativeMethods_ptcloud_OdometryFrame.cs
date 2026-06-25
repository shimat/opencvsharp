using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1720 // Identifiers should not contain type names
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_new(
        IntPtr depth, IntPtr image, IntPtr mask, IntPtr normals, out IntPtr returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_delete(IntPtr obj);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_getImage(IntPtr obj, IntPtr image);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_getGrayImage(IntPtr obj, IntPtr image);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_getDepth(IntPtr obj, IntPtr depth);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_getProcessedDepth(IntPtr obj, IntPtr depth);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_getMask(IntPtr obj, IntPtr mask);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_getNormals(IntPtr obj, IntPtr normals);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_getPyramidLevels(IntPtr obj, out int returnValue);
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_OdometryFrame_getPyramidAt(IntPtr obj, IntPtr img, int pyrType, IntPtr level);
}
