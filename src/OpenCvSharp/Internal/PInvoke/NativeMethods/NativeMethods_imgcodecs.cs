using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // imread (UTF-8 everywhere; the native side converts to a wide path on Windows so non-ANSI names work)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imread(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, int flags, out IntPtr returnValue);

    // imreadmulti (UTF-8 everywhere; native reads via a wide path on Windows)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imreadmulti(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr mats, int flags, out int returnValue);

    // imwrite (UTF-8 everywhere; the native side converts to a wide path on Windows so non-ANSI names work)

    [LibraryImport(DllExtern, EntryPoint = "imgcodecs_imwrite"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus imgcodecs_imwrite_utf8(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

    public static ExceptionStatus imgcodecs_imwrite(string fileName, IntPtr img, int[] @params, int paramsLength, out int returnValue)
    {
        if (IsWasm()) {
            returnValue = default(int);
            return ExceptionStatus.Occurred;
        }

        return imgcodecs_imwrite_utf8(fileName, img, @params, paramsLength, out returnValue);
    }

    // imwrite_multi (UTF-8 everywhere; native writes via a wide path on Windows)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imwrite_multi(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, IntPtr img, [In] int[] @params, int paramsLength, out int returnValue);

    // 

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imdecode_Mat(
        IntPtr buf, int flags, out IntPtr returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus imgcodecs_imdecode_vector(
        byte* buf, int bufLength, int flags, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imdecode_InputArray(
        IntPtr buf, int flags, out IntPtr returnValue);

    // Do not consider that "ext" may not be ASCII characters
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_imencode_vector(
        [MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, IntPtr buf, [In] int[] @params, int paramsLength, out int returnValue);

    // haveImageReader (UTF-8 everywhere; native probes via a wide path on Windows)

    [LibraryImport(DllExtern, EntryPoint = "imgcodecs_haveImageReader"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial ExceptionStatus imgcodecs_haveImageReader_utf8(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string fileName, out int returnValue);

    public static ExceptionStatus imgcodecs_haveImageReader(string fileName, out int returnValue)
    {
        if (IsWasm()) {
            returnValue = default(int);
            return ExceptionStatus.Occurred;
        }

        return imgcodecs_haveImageReader_utf8(fileName, out returnValue);
    }
        
    // haveImageWriter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgcodecs_haveImageWriter(
        [MarshalAs(UnmanagedType.LPStr)] string fileName, out int returnValue);
}
