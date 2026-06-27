using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_new1(
        out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_new2(
        [MarshalAs(UnmanagedType.LPStr)] string algo, int scale, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_readModel1(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string path);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_readModel2(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string weights, [MarshalAs(UnmanagedType.LPStr)] string definition);


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_setModel(
        OpenCvSafeHandle obj, [MarshalAs(UnmanagedType.LPStr)] string algo, int scale);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_setPreferableBackend(
        OpenCvSafeHandle obj, int backendId);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_setPreferableTarget(
        OpenCvSafeHandle obj, int targetId);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_upsample(
        OpenCvSafeHandle obj, IntPtr img, IntPtr result);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_upsampleMultioutput(
        OpenCvSafeHandle obj, IntPtr img, IntPtr imgsNew,
        int[] scaleFactors, int scaleFactorsSize, 
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] nodeNames,  int nodeNamesSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_getScale(
        OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus dnn_superres_DnnSuperResImpl_getAlgorithm(
        OpenCvSafeHandle obj, IntPtr returnValue);

}
