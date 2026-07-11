using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region BackgroundSubtractorMOG

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_createBackgroundSubtractorMOG(
        int history, int nMixtures, double backgroundRatio, double noiseSigma, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorMOG_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorMOG_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_getHistory(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_setHistory(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_getNMixtures(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_setNMixtures(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(OpenCvSafeHandle ptr, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_getNoiseSigma(OpenCvSafeHandle ptr, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_setNoiseSigma(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_apply(OpenCvSafeHandle ptr, in InputArrayProxy image, in OutputArrayProxy fgmask, double learningRate);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_BackgroundSubtractorMOG_getBackgroundImage(OpenCvSafeHandle ptr, in OutputArrayProxy backgroundImage);

    #endregion

    #region BackgroundSubtractorGMG

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_createBackgroundSubtractorGMG(
        int initializationFrames, double decisionThreshold, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorGMG_delete(IntPtr obj);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorGMG_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getMaxFeatures(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setMaxFeatures(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(OpenCvSafeHandle ptr, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getNumFrames(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setNumFrames(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(OpenCvSafeHandle ptr, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(OpenCvSafeHandle ptr, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getMinVal(OpenCvSafeHandle ptr, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setMinVal(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getMaxVal(OpenCvSafeHandle ptr, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_setMaxVal(OpenCvSafeHandle ptr, double value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_apply(OpenCvSafeHandle ptr, in InputArrayProxy image, in OutputArrayProxy fgmask, double learningRate);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_BackgroundSubtractorGMG_getBackgroundImage(OpenCvSafeHandle ptr, in OutputArrayProxy backgroundImage);

    #endregion

    #region BackgroundSubtractorCNT

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_createBackgroundSubtractorCNT(
        int minPixelStability, int useHistory, int maxPixelStability, int isParallel, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorCNT_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorCNT_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorCNT_getMinPixelStability(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorCNT_setMinPixelStability(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorCNT_getMaxPixelStability(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorCNT_setMaxPixelStability(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorCNT_getUseHistory(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorCNT_setUseHistory(OpenCvSafeHandle ptr, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorCNT_getIsParallel(OpenCvSafeHandle ptr, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_BackgroundSubtractorCNT_setIsParallel(OpenCvSafeHandle ptr, int value);

    #endregion

    #region BackgroundSubtractorGSOC

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_createBackgroundSubtractorGSOC(
        int mc, int nSamples, float replaceRate, float propagationRate, int hitsThreshold,
        float alpha, float beta, float blinkingSupressionDecay, float blinkingSupressionMultiplier,
        float noiseRemovalThresholdFacBG, float noiseRemovalThresholdFacFG,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorGSOC_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorGSOC_delete(IntPtr obj);

    #endregion

    #region BackgroundSubtractorLSBP

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_createBackgroundSubtractorLSBP(
        int mc, int nSamples, int lsbpRadius, float tLower, float tUpper, float tInc, float tDec,
        float rScale, float rIncdec, float noiseRemovalThresholdFacBG, float noiseRemovalThresholdFacFG,
        int lsbpThreshold, int minCount,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorLSBP_get(IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus bgsegm_Ptr_BackgroundSubtractorLSBP_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_BackgroundSubtractorLSBPDesc_calcLocalSVDValues(
        in OutputArrayProxy localSVDValues, IntPtr frame);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_BackgroundSubtractorLSBPDesc_computeFromLocalSVDValues(
        in OutputArrayProxy desc, IntPtr localSVDValues, [In] Point[] lsbpSamplePoints);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_BackgroundSubtractorLSBPDesc_compute(
        in OutputArrayProxy desc, IntPtr frame, [In] Point[] lsbpSamplePoints);

    #endregion

    #region SyntheticSequenceGenerator

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_SyntheticSequenceGenerator_new(
        in InputArrayProxy background, in InputArrayProxy @object,
        double amplitude, double wavelength, double wavespeed, double objspeed,
        out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_SyntheticSequenceGenerator_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus bgsegm_SyntheticSequenceGenerator_getNextFrame(
        OpenCvSafeHandle obj, in OutputArrayProxy frame, in OutputArrayProxy gtMask);

    #endregion
}
