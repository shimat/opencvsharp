using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ReSharper disable InconsistentNaming

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_FontFace_new1(out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "imgproc_FontFace_new2")]
    public static extern ExceptionStatus imgproc_FontFace_new2_NotWindows(
        [MarshalAs(StringUnmanagedTypeNotWindows)] string fontPathOrName, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "imgproc_FontFace_new2")]
    public static extern ExceptionStatus imgproc_FontFace_new2_Windows(
        [MarshalAs(StringUnmanagedTypeWindows)] string fontPathOrName, out IntPtr returnValue);

    public static ExceptionStatus imgproc_FontFace_new2(string fontPathOrName, out IntPtr returnValue)
        => IsWindows()
            ? imgproc_FontFace_new2_Windows(fontPathOrName, out returnValue)
            : imgproc_FontFace_new2_NotWindows(fontPathOrName, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_FontFace_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "imgproc_FontFace_set")]
    public static extern ExceptionStatus imgproc_FontFace_set_NotWindows(
        IntPtr obj, [MarshalAs(StringUnmanagedTypeNotWindows)] string fontPathOrName, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true,
        EntryPoint = "imgproc_FontFace_set")]
    public static extern ExceptionStatus imgproc_FontFace_set_Windows(
        IntPtr obj, [MarshalAs(StringUnmanagedTypeWindows)] string fontPathOrName, out int returnValue);

    public static ExceptionStatus imgproc_FontFace_set(IntPtr obj, string fontPathOrName, out int returnValue)
        => IsWindows()
            ? imgproc_FontFace_set_Windows(obj, fontPathOrName, out returnValue)
            : imgproc_FontFace_set_NotWindows(obj, fontPathOrName, out returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_FontFace_getName(IntPtr obj, IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_FontFace_setInstance(IntPtr obj, int[] @params, int paramsLength, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus imgproc_FontFace_getInstance(IntPtr obj, IntPtr @params, out int returnValue);

    // putText / getTextSize with FontFace (text is UTF-8 for full Unicode support)

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus imgproc_putText_FontFace(
        IntPtr img, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, Point org, Scalar color,
        IntPtr fface, int size, int weight, int flags, int wrapStart, int wrapEnd, out Point returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
    public static extern ExceptionStatus imgproc_getTextSize_FontFace(
        Size imgsize, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, Point org,
        IntPtr fface, int size, int weight, int flags, int wrapStart, int wrapEnd, out Rect returnValue);
}
