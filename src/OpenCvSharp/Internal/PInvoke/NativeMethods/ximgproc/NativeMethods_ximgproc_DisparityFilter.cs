using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // DisparityFilter (base class methods)

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_DisparityFilter_filter(
        OpenCvSafeHandle obj, in InputArrayProxy disparityMapLeft, in InputArrayProxy leftView, in OutputArrayProxy filteredDisparityMap,
        in InputArrayProxy disparityMapRight, Rect roi, in InputArrayProxy rightView);

    // DisparityWLSFilter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_DisparityWLSFilter_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_DisparityWLSFilter_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createDisparityWLSFilter(IntPtr matcherLeft, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createDisparityWLSFilterGeneric(int useConfidence, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createRightMatcher(IntPtr matcherLeft, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_getLambda(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_setLambda(OpenCvSafeHandle obj, double lambda);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_getSigmaColor(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_setSigmaColor(OpenCvSafeHandle obj, double sigmaColor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_getLRCthresh(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_setLRCthresh(OpenCvSafeHandle obj, int lrcThresh);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_getDepthDiscontinuityRadius(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_setDepthDiscontinuityRadius(OpenCvSafeHandle obj, int discRadius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_getConfidenceMap(OpenCvSafeHandle obj, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_DisparityWLSFilter_getROI(OpenCvSafeHandle obj, out Rect returnValue);

    // Free functions

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_readGT(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string srcPath, in OutputArrayProxy dst, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_computeMSE(
        in InputArrayProxy gt, in InputArrayProxy src, Rect roi, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_computeBadPixelPercent(
        in InputArrayProxy gt, in InputArrayProxy src, Rect roi, int thresh, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_getDisparityVis(
        in InputArrayProxy src, in OutputArrayProxy dst, double scale);
}
