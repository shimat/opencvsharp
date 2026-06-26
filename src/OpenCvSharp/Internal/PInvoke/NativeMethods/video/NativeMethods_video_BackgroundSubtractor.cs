using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region BackgroundSubtractor

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractor_getBackgroundImage(OpenCvSafeHandle self, IntPtr backgroundImage);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractor_apply(OpenCvSafeHandle self, IntPtr image, IntPtr fgmask, double learningRate);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_BackgroundSubtractor_delete(IntPtr ptr);

    #endregion

    #region BackgroundSubtractorMOG2

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_createBackgroundSubtractorMOG2(
        int history, double varThreshold, int detectShadows, out IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_BackgroundSubtractorMOG2_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_BackgroundSubtractorMOG2_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getHistory(OpenCvSafeHandle ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setHistory(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getNMixtures(OpenCvSafeHandle ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setNMixtures(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getBackgroundRatio(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setBackgroundRatio(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarThreshold(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarThreshold(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarThresholdGen(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarThresholdGen(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarInit(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarInit(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarMin(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarMin(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarMax(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarMax(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getDetectShadows(OpenCvSafeHandle ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setDetectShadows(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getShadowValue(OpenCvSafeHandle ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setShadowValue(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getShadowThreshold(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setShadowThreshold(OpenCvSafeHandle ptr, double value);

    #endregion

    #region BackgroundSubtractorKNN

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_createBackgroundSubtractorKNN(
        int history, double dist2Threshold, int detectShadows, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_BackgroundSubtractorKNN_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_Ptr_BackgroundSubtractorKNN_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getHistory(OpenCvSafeHandle ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setHistory(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getNSamples(OpenCvSafeHandle ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setNSamples(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getDist2Threshold(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setDist2Threshold(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getkNNSamples(OpenCvSafeHandle ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setkNNSamples(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getDetectShadows(OpenCvSafeHandle ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setDetectShadows(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getShadowValue(OpenCvSafeHandle ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setShadowValue(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getShadowThreshold(OpenCvSafeHandle ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setShadowThreshold(OpenCvSafeHandle ptr, double value);

    #endregion

}
