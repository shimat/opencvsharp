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
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getHistory(IntPtr ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setHistory(IntPtr ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getNMixtures(IntPtr ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setNMixtures(IntPtr ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getBackgroundRatio(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setBackgroundRatio(IntPtr ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarThreshold(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarThreshold(IntPtr ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarThresholdGen(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarThresholdGen(IntPtr ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarInit(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarInit(IntPtr ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarMin(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarMin(IntPtr ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getVarMax(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setVarMax(IntPtr ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(IntPtr ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getDetectShadows(IntPtr ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setDetectShadows(IntPtr ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getShadowValue(IntPtr ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setShadowValue(IntPtr ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_getShadowThreshold(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorMOG2_setShadowThreshold(IntPtr ptr, double value);

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
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getHistory(IntPtr ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setHistory(IntPtr ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getNSamples(IntPtr ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setNSamples(IntPtr ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getDist2Threshold(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setDist2Threshold(IntPtr ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getkNNSamples(IntPtr ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setkNNSamples(IntPtr ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getDetectShadows(IntPtr ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setDetectShadows(IntPtr ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getShadowValue(IntPtr ptr, out int returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setShadowValue(IntPtr ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_getShadowThreshold(IntPtr ptr, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus video_BackgroundSubtractorKNN_setShadowThreshold(IntPtr ptr, double value);

    #endregion

}
