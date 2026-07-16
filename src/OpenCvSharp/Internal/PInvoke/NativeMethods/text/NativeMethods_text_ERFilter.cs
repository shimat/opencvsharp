using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // ERFilter::Callback

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_ERFilterCallback_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_ERFilterCallback_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_loadClassifierNM1(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_loadClassifierNM2(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, out IntPtr returnValue);

    // ERFilter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_ERFilter_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_Ptr_ERFilter_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_createERFilterNM1_callback(
        IntPtr cb, int thresholdDelta, float minArea, float maxArea,
        float minProbability, int nonMaxSuppression, float minProbabilityDiff, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_createERFilterNM1_file(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, int thresholdDelta, float minArea, float maxArea,
        float minProbability, int nonMaxSuppression, float minProbabilityDiff, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_createERFilterNM2_callback(
        IntPtr cb, float minProbability, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_createERFilterNM2_file(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, float minProbability, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_ERFilter_setCallback(OpenCvSafeHandle obj, IntPtr cb);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_ERFilter_setThresholdDelta(OpenCvSafeHandle obj, int thresholdDelta);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_ERFilter_setMinArea(OpenCvSafeHandle obj, float minArea);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_ERFilter_setMaxArea(OpenCvSafeHandle obj, float maxArea);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_ERFilter_setMinProbability(OpenCvSafeHandle obj, float minProbability);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_ERFilter_setMinProbabilityDiff(OpenCvSafeHandle obj, float minProbabilityDiff);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_ERFilter_setNonMaxSuppression(OpenCvSafeHandle obj, int nonMaxSuppression);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus text_ERFilter_getNumRejected(OpenCvSafeHandle obj, out int returnValue);

    // Free functions

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus text_computeNMChannels(in InputArrayProxy src, IntPtr channels, int mode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus text_detectRegions_contours(
        in InputArrayProxy image, IntPtr erFilter1, IntPtr erFilter2, IntPtr regions);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus text_detectRegions_rects(
        in InputArrayProxy image, IntPtr erFilter1, IntPtr erFilter2, IntPtr groupsRects,
        int method, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename, float minProbability);
}
