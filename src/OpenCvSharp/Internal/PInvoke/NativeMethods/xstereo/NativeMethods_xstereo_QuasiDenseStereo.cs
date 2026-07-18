using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

// ReSharper disable InconsistentNaming
static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_Ptr_QuasiDenseStereo_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_Ptr_QuasiDenseStereo_get(IntPtr obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_create(
        Size monoImgSize, [MarshalAs(UnmanagedType.LPStr)] string paramFilepath, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_loadParameters(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string filepath, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_saveParameters(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string filepath, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_getSparseMatches(
        OpenCvSafeHandle obj, IntPtr sMatches);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_getDenseMatches(
        OpenCvSafeHandle obj, IntPtr denseMatches);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_process(
        OpenCvSafeHandle obj, IntPtr imgLeft, IntPtr imgRight);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_getMatch(
        OpenCvSafeHandle obj, int x, int y, out Point2f returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_getDisparity(
        OpenCvSafeHandle obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_getParam(
        OpenCvSafeHandle obj, out PropagationParameters returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xstereo_QuasiDenseStereo_setParam(
        OpenCvSafeHandle obj, ref PropagationParameters value);
}
