using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // VideoCapture

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_new1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_new2(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_new3(int device, int apiPreference, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_new4(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, [In] int[] @params, int paramsLength, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_new5(int device, int apiPreference, [In] int[] @params, int paramsLength, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_open1(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_open2(OpenCvSafeHandle obj, int device, int apiPreference, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_isOpened(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_release(OpenCvSafeHandle obj);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_grab(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_retrieve_OutputArray(OpenCvSafeHandle obj, IntPtr image, int flag, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_retrieve_Mat(OpenCvSafeHandle obj, IntPtr image, int flag, out int returnValue);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_operatorRightShift_Mat(OpenCvSafeHandle obj, IntPtr image);

    //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus videoio_VideoCapture_operatorRightShift_UMat(IntPtr obj, IntPtr image);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_read_OutputArray(OpenCvSafeHandle obj, IntPtr image, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_read_Mat(OpenCvSafeHandle obj, IntPtr image, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_set(OpenCvSafeHandle obj, int propId, double value, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_get(OpenCvSafeHandle obj, int propId, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_getBackendName(OpenCvSafeHandle obj, IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_setExceptionMode(OpenCvSafeHandle obj, int enable);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_getExceptionMode(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoCapture_waitAny(
        IntPtr[] streams, nuint streamsSize,
        IntPtr readyIndex, long timeoutNs, out int returnValue);


    // VideoWriter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_new1(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_new2(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int fourcc, double fps,
        Size frameSize, int isColor, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_new3(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, int fourcc, double fps,
        Size frameSize, int isColor, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_new4(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int fourcc, double fps,
        Size frameSize, [In] int[] @params, int paramsLength, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_new5(
        [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, int fourcc, double fps,
        Size frameSize, [In] int[] @params, int paramsLength, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_open1(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string filename,
        int fourcc, double fps, Size frameSize, int isColor, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_open2(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string filename, int apiPreference, 
        int fourcc, double fps, Size frameSize, int isColor, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_isOpened(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_release(OpenCvSafeHandle obj);

    //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus videoio_VideoWriter_OperatorLeftShift(IntPtr obj, IntPtr image);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_write(OpenCvSafeHandle obj, IntPtr image);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_set(OpenCvSafeHandle obj, int propId, double value, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_get(OpenCvSafeHandle obj, int propId, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_fourcc(sbyte c1, sbyte c2, sbyte c3, sbyte c4, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus videoio_VideoWriter_getBackendName(OpenCvSafeHandle obj, IntPtr returnValue);
}
