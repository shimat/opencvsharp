using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA1707 // Underscore
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    #region bm3d_image_denoising.hpp

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_bm3dDenoising1(
        IntPtr src,
        IntPtr dstStep1,
        IntPtr dstStep2,
        float h,
        int templateWindowSize,
        int searchWindowSize,
        int blockMatchingStep1,
        int blockMatchingStep2,
        int groupSize,
        int slidingStep,
        float beta,
        int normType,
        int step,
        int transformType);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_bm3dDenoising2(
        IntPtr src,
        IntPtr dst,
        float h,
        int templateWindowSize,
        int searchWindowSize,
        int blockMatchingStep1,
        int blockMatchingStep2,
        int groupSize,
        int slidingStep,
        float beta,
        int normType,
        int step,
        int transformType);

    #endregion

    #region dct_image_denoising.hpp

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_dctDenoising(IntPtr src, IntPtr dst, double sigma, int psize);

    #endregion

    #region inpainting.hpp

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_inpaint(IntPtr prt, IntPtr src, IntPtr dst, int algorithm);

    #endregion

    #region oilpainting.hpp

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_oilPainting(
        IntPtr src, IntPtr dst, int size, int dynRatio, int code);
        
    #endregion

    #region tonemap.hpp

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_TonemapDurand_getSaturation(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_TonemapDurand_setSaturation(IntPtr obj, float saturation);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_TonemapDurand_getContrast(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_TonemapDurand_setContrast(IntPtr obj, float contrast);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_TonemapDurand_getSigmaSpace(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_TonemapDurand_setSigmaSpace(IntPtr obj, float saturation);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_TonemapDurand_getSigmaColor(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_TonemapDurand_setSigmaColor(IntPtr obj, float saturation);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_createTonemapDurand(
        float gamma, float contrast, float saturation, float sigmaSpace, float sigmaColor, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_Ptr_TonemapDurand_delete(IntPtr ptr);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_Ptr_TonemapDurand_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region white_balance.hpp

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_applyChannelGains(
        IntPtr src, IntPtr dst, float gainB, float gainG, float gainR);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_createGrayworldWB(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_Ptr_GrayworldWB_delete(IntPtr prt);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_Ptr_GrayworldWB_get(IntPtr prt, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_GrayworldWB_balanceWhite(IntPtr prt, IntPtr src, IntPtr dst);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_GrayworldWB_SaturationThreshold_get(IntPtr ptr, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_GrayworldWB_SaturationThreshold_set(IntPtr ptr, float val);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_createLearningBasedWB(string trackerType, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_Ptr_LearningBasedWB_delete(IntPtr prt);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_Ptr_LearningBasedWB_get(IntPtr prt, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_LearningBasedWB_balanceWhite(IntPtr prt, IntPtr src, IntPtr dst);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_LearningBasedWB_extractSimpleFeatures(IntPtr prt, IntPtr src, IntPtr dst);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_LearningBasedWB_HistBinNum_set(IntPtr prt, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_LearningBasedWB_RangeMaxVal_set(IntPtr prt, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_LearningBasedWB_SaturationThreshold_set(IntPtr prt, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_LearningBasedWB_HistBinNum_get(IntPtr prt, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_LearningBasedWB_RangeMaxVal_get(IntPtr prt, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_LearningBasedWB_SaturationThreshold_get(IntPtr prt, out float returnValue);


    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_createSimpleWB(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_Ptr_SimpleWB_delete(IntPtr prt);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_Ptr_SimpleWB_get(IntPtr prt, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_balanceWhite(IntPtr prt, IntPtr src, IntPtr dst);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_InputMax_get(IntPtr prt, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_InputMax_set(IntPtr prt, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_InputMin_get(IntPtr prt, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_InputMin_set(IntPtr prt, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_OutputMax_get(IntPtr prt, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_OutputMax_set(IntPtr prt, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_OutputMin_get(IntPtr prt, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_OutputMin_set(IntPtr prt, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_P_get(IntPtr prt, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus xphoto_SimpleWB_P_set(IntPtr prt, float value);

    #endregion
}
