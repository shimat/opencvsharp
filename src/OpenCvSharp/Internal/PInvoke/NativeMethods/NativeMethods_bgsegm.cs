using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region BackgroundSubtractorMOG

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_createBackgroundSubtractorMOG(
        int history, int nMixtures, double backgroundRatio, double noiseSigma, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_Ptr_BackgroundSubtractorMOG_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_Ptr_BackgroundSubtractorMOG_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorMOG_getHistory(IntPtr ptr, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorMOG_setHistory(IntPtr ptr, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorMOG_getNMixtures(IntPtr ptr, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorMOG_setNMixtures(IntPtr ptr, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(IntPtr ptr, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(IntPtr ptr, double value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorMOG_getNoiseSigma(IntPtr ptr, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorMOG_setNoiseSigma(IntPtr ptr, double value);

    #endregion

    #region BackgroundSubtractorGMG

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_createBackgroundSubtractorGMG(
        int initializationFrames, double decisionThreshold, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_Ptr_BackgroundSubtractorGMG_delete(IntPtr obj);
        
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_Ptr_BackgroundSubtractorGMG_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getMaxFeatures(IntPtr ptr, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setMaxFeatures(IntPtr ptr, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(IntPtr ptr, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(IntPtr ptr, double value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getNumFrames(IntPtr ptr, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setNumFrames(IntPtr ptr, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(IntPtr ptr, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(IntPtr ptr, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(IntPtr ptr, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(IntPtr ptr, double value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(IntPtr ptr, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(IntPtr ptr, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(IntPtr ptr, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(IntPtr ptr, double value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(IntPtr ptr, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(IntPtr ptr, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getMinVal(IntPtr ptr, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setMinVal(IntPtr ptr, double value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_getMaxVal(IntPtr ptr, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus bgsegm_BackgroundSubtractorGMG_setMaxVal(IntPtr ptr, double value);

    #endregion
}
