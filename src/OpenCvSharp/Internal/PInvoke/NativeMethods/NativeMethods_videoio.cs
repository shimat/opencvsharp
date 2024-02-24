using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // VideoCapture

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_new1(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_new2(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_new3(int device, int apiPreference, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_new4(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, [In] int[] @params, int paramsLength, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_new5(int device, int apiPreference, [In] int[] @params, int paramsLength, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_open1(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_open2(IntPtr obj, int device, int apiPreference, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_isOpened(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_release(IntPtr obj);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_grab(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_retrieve_OutputArray(IntPtr obj, IntPtr image, int flag, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_retrieve_Mat(IntPtr obj, IntPtr image, int flag, out int returnValue);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_operatorRightShift_Mat(IntPtr obj, IntPtr image);

    //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus videoio_VideoCapture_operatorRightShift_UMat(IntPtr obj, IntPtr image);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_read_OutputArray(IntPtr obj, IntPtr image, out int returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_read_Mat(IntPtr obj, IntPtr image, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_set(IntPtr obj, int propId, double value, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_get(IntPtr obj, int propId, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_getBackendName(IntPtr obj, IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_setExceptionMode(IntPtr obj, int enable);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_getExceptionMode(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoCapture_waitAny(
        IntPtr[] streams, nuint streamsSize,
        IntPtr readyIndex, long timeoutNs, out int returnValue);


    // VideoWriter

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_new1(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_new2(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int fourcc, double fps,
        Size frameSize, int isColor, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_new3(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, int fourcc, double fps,
        Size frameSize, int isColor, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_new4(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int fourcc, double fps,
        Size frameSize, [In] int[] @params, int paramsLength, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_new5(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, int fourcc, double fps,
        Size frameSize, [In] int[] @params, int paramsLength, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_open1(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename,
        int fourcc, double fps, Size frameSize, int isColor, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_open2(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, 
        int fourcc, double fps, Size frameSize, int isColor, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_isOpened(IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_release(IntPtr obj);

    //[Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus videoio_VideoWriter_OperatorLeftShift(IntPtr obj, IntPtr image);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_write(IntPtr obj, IntPtr image);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_set(IntPtr obj, int propId, double value, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_get(IntPtr obj, int propId, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_fourcc(sbyte c1, sbyte c2, sbyte c3, sbyte c4, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus videoio_VideoWriter_getBackendName(IntPtr obj, IntPtr returnValue);
}
