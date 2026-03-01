using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_new1(
        out IntPtr returnValue);
    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_new2(
        [MarshalAs(UnmanagedType.LPStr)] string algo, int scale, out IntPtr returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_delete(IntPtr obj);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_readModel1(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string path);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_readModel2(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string weights, [MarshalAs(UnmanagedType.LPStr)] string definition);


    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_setModel(
        IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string algo, int scale);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_setPreferableBackend(
        IntPtr obj, int backendId);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_setPreferableTarget(
        IntPtr obj, int targetId);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_upsample(
        IntPtr obj, IntPtr img, IntPtr result);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_upsampleMultioutput(
        IntPtr obj, IntPtr img, IntPtr imgsNew,
        int[] scaleFactors, int scaleFactorsSize, 
        string[] nodeNames,  int nodeNamesSize);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_getScale(
        IntPtr obj, out int returnValue);

    [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false,
         ThrowOnUnmappableChar = true, ExactSpelling = true)]
    public static extern ExceptionStatus dnn_superres_DnnSuperResImpl_getAlgorithm(
        IntPtr obj, IntPtr returnValue);

}
