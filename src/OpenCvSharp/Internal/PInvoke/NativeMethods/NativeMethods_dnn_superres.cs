using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_new1(
        out IntPtr returnValue);
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_new2(
        [MarshalAs(UnmanagedType.LPStr)] string algo, int scale, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_readModel1(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string path);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_readModel2(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string weights, [MarshalAs(UnmanagedType.LPStr)] string definition);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_setModel(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string algo, int scale);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_setPreferableBackend(
        IntPtr obj, int backendId);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_setPreferableTarget(
        IntPtr obj, int targetId);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_upsample(
        IntPtr obj, IntPtr img, IntPtr result);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_upsampleMultioutput(
        IntPtr obj, IntPtr img, IntPtr imgsNew,
        int[] scaleFactors, int scaleFactorsSize, 
        string[] nodeNames,  int nodeNamesSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_getScale(
        IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_getAlgorithm(
        IntPtr obj, IntPtr returnValue);

}
