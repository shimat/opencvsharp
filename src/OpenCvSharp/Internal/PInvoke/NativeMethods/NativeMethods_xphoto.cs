using System.Runtime.CompilerServices;
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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_bm3dDenoising1(
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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_bm3dDenoising2(
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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_dctDenoising(IntPtr src, IntPtr dst, double sigma, int psize);

    #endregion

    #region inpainting.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_inpaint(IntPtr prt, IntPtr src, IntPtr dst, int algorithm);

    #endregion

    #region oilpainting.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_oilPainting(
        IntPtr src, IntPtr dst, int size, int dynRatio, int code);
        
    #endregion

    #region tonemap.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_TonemapDurand_getSaturation(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_TonemapDurand_setSaturation(OpenCvSafeHandle obj, float saturation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_TonemapDurand_getContrast(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_TonemapDurand_setContrast(OpenCvSafeHandle obj, float contrast);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_TonemapDurand_getSigmaSpace(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_TonemapDurand_setSigmaSpace(OpenCvSafeHandle obj, float saturation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_TonemapDurand_getSigmaColor(OpenCvSafeHandle obj, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_TonemapDurand_setSigmaColor(OpenCvSafeHandle obj, float saturation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_createTonemapDurand(
        float gamma, float contrast, float saturation, float sigmaSpace, float sigmaColor, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_Ptr_TonemapDurand_delete(IntPtr ptr);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_Ptr_TonemapDurand_get(IntPtr ptr, out IntPtr returnValue);

    #endregion

    #region white_balance.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_applyChannelGains(
        IntPtr src, IntPtr dst, float gainB, float gainG, float gainR);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_createGrayworldWB(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_Ptr_GrayworldWB_delete(IntPtr prt);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_Ptr_GrayworldWB_get(IntPtr prt, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_GrayworldWB_balanceWhite(OpenCvSafeHandle prt, IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_GrayworldWB_SaturationThreshold_get(OpenCvSafeHandle ptr, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_GrayworldWB_SaturationThreshold_set(OpenCvSafeHandle ptr, float val);


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_createLearningBasedWB([MarshalAs(UnmanagedType.LPStr)] string trackerType, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_Ptr_LearningBasedWB_delete(IntPtr prt);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_Ptr_LearningBasedWB_get(IntPtr prt, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_LearningBasedWB_balanceWhite(OpenCvSafeHandle prt, IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_LearningBasedWB_extractSimpleFeatures(OpenCvSafeHandle prt, IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_LearningBasedWB_HistBinNum_set(OpenCvSafeHandle prt, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_LearningBasedWB_RangeMaxVal_set(OpenCvSafeHandle prt, int value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_LearningBasedWB_SaturationThreshold_set(OpenCvSafeHandle prt, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_LearningBasedWB_HistBinNum_get(OpenCvSafeHandle prt, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_LearningBasedWB_RangeMaxVal_get(OpenCvSafeHandle prt, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_LearningBasedWB_SaturationThreshold_get(OpenCvSafeHandle prt, out float returnValue);


    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_createSimpleWB(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_Ptr_SimpleWB_delete(IntPtr prt);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_Ptr_SimpleWB_get(IntPtr prt, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_balanceWhite(OpenCvSafeHandle prt, IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_InputMax_get(OpenCvSafeHandle prt, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_InputMax_set(OpenCvSafeHandle prt, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_InputMin_get(OpenCvSafeHandle prt, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_InputMin_set(OpenCvSafeHandle prt, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_OutputMax_get(OpenCvSafeHandle prt, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_OutputMax_set(OpenCvSafeHandle prt, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_OutputMin_get(OpenCvSafeHandle prt, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_OutputMin_set(OpenCvSafeHandle prt, float value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_P_get(OpenCvSafeHandle prt, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus xphoto_SimpleWB_P_set(OpenCvSafeHandle prt, float value);

    #endregion

    }
