using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ReSharper disable InconsistentNaming

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_FontFace_new1(out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "imgproc_FontFace_new2"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_FontFace_new2_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string fontPathOrName, out IntPtr returnValue);

    [LibraryImport(DllExtern, EntryPoint = "imgproc_FontFace_new2"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_FontFace_new2_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string fontPathOrName, out IntPtr returnValue);

    public static ExceptionStatus imgproc_FontFace_new2(string fontPathOrName, out IntPtr returnValue)
        => IsWindows()
            ? imgproc_FontFace_new2_Windows(fontPathOrName, out returnValue)
            : imgproc_FontFace_new2_NotWindows(fontPathOrName, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_FontFace_delete(IntPtr obj);

    [LibraryImport(DllExtern, EntryPoint = "imgproc_FontFace_set"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_FontFace_set_NotWindows(
        OpenCvSafeHandle obj, [MarshalAs(StringUnmanagedTypeNotWindows)] string fontPathOrName, out int returnValue);

    [LibraryImport(DllExtern, EntryPoint = "imgproc_FontFace_set"), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_FontFace_set_Windows(
        OpenCvSafeHandle obj, [MarshalAs(StringUnmanagedTypeWindows)] string fontPathOrName, out int returnValue);

    public static ExceptionStatus imgproc_FontFace_set(OpenCvSafeHandle obj, string fontPathOrName, out int returnValue)
        => IsWindows()
            ? imgproc_FontFace_set_Windows(obj, fontPathOrName, out returnValue)
            : imgproc_FontFace_set_NotWindows(obj, fontPathOrName, out returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_FontFace_getName(OpenCvSafeHandle obj, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_FontFace_setInstance(OpenCvSafeHandle obj, int[] @params, int paramsLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_FontFace_getInstance(OpenCvSafeHandle obj, IntPtr @params, out int returnValue);

    // putText / getTextSize with FontFace (text is UTF-8 for full Unicode support)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_putText_FontFace(
        IntPtr img, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, Point org, Scalar color,
        IntPtr fface, int size, int weight, int flags, int wrapStart, int wrapEnd, out Point returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getTextSize_FontFace(
        Size imgsize, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, Point org,
        IntPtr fface, int size, int weight, int flags, int wrapStart, int wrapEnd, out Rect returnValue);
}
