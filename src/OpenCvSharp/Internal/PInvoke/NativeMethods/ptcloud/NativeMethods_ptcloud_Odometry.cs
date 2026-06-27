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
    public static partial ExceptionStatus ptcloud_Odometry_new1(out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Odometry_new2(int otype, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Odometry_new3(int otype, IntPtr settings, int algtype, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Odometry_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Odometry_prepareFrame(OpenCvSafeHandle obj, IntPtr frame);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Odometry_prepareFrames(OpenCvSafeHandle obj, IntPtr srcFrame, IntPtr dstFrame);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Odometry_compute_Frame(OpenCvSafeHandle obj, IntPtr srcFrame, IntPtr dstFrame, IntPtr rt, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Odometry_compute_Depth(OpenCvSafeHandle obj, IntPtr srcDepth, IntPtr dstDepth, IntPtr rt, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Odometry_compute_DepthRGB(OpenCvSafeHandle obj, IntPtr srcDepth, IntPtr srcRGB, IntPtr dstDepth, IntPtr dstRGB, IntPtr rt, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ptcloud_Odometry_getNormalsComputer(OpenCvSafeHandle obj, out IntPtr returnValue);
}
