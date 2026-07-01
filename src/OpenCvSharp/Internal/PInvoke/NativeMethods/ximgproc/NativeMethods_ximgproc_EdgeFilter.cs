using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // DTFilter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_DTFilter_delete(
        IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_DTFilter_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_DTFilter_filter(
        OpenCvSafeHandle obj, in InputArrayProxy src, in OutputArrayProxy dst, int dDepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_createDTFilter(
        in InputArrayProxy guide, double sigmaSpatial, double sigmaColor, int mode, int numIters, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_dtFilter(
        in InputArrayProxy guide, in InputArrayProxy src, in OutputArrayProxy dst, double sigmaSpatial, double sigmaColor, int mode, int numIters);
        
    //////////////////////////////////////////////////////////////////////////
    // GuidedFilter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_GuidedFilter_delete(
        IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_GuidedFilter_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_GuidedFilter_filter(
        OpenCvSafeHandle obj, in InputArrayProxy src, in OutputArrayProxy dst, int dDepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_createGuidedFilter(
        in InputArrayProxy guide, int radius, double eps, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_guidedFilter(
        in InputArrayProxy guide, in InputArrayProxy src, in OutputArrayProxy dst, int radius, double eps, int dDepth);

    //////////////////////////////////////////////////////////////////////////
    // AdaptiveManifoldFilter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_AdaptiveManifoldFilter_delete(
        IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_AdaptiveManifoldFilter_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_filter(
        OpenCvSafeHandle obj, in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy joint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_collectGarbage(
        OpenCvSafeHandle obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_getSigmaS(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_setSigmaS(OpenCvSafeHandle obj, double val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_getSigmaR(OpenCvSafeHandle obj, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_setSigmaR(OpenCvSafeHandle obj, double val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_getTreeHeight(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_setTreeHeight(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_getPCAIterations(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_setPCAIterations(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_getAdjustOutliers(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_setAdjustOutliers(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_getUseRNG(OpenCvSafeHandle obj, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_AdaptiveManifoldFilter_setUseRNG(OpenCvSafeHandle obj, int val);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createAMFilter(
        double sigma_s, double sigma_r, int adjust_outliers, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_amFilter(
        in InputArrayProxy joint, in InputArrayProxy src, in OutputArrayProxy dst, double sigma_s, double sigma_r, int adjust_outliers);

    //////////////////////////////////////////////////////////////////////////

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_jointBilateralFilter(
        in InputArrayProxy joint, in InputArrayProxy src, in OutputArrayProxy dst, int d, double sigmaColor, double sigmaSpace, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_bilateralTextureFilter(
        in InputArrayProxy src, in OutputArrayProxy dst, int fr, int numIter, double sigmaAlpha, double sigmaAvg);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_rollingGuidanceFilter(
        in InputArrayProxy src, in OutputArrayProxy dst, int d, double sigmaColor, double sigmaSpace, int numOfIter, int borderType);
        
    //////////////////////////////////////////////////////////////////////////
    // FastBilateralSolverFilter 

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_FastBilateralSolverFilter_delete(
        IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_FastBilateralSolverFilter_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_FastBilateralSolverFilter_filter(
        OpenCvSafeHandle obj, in InputArrayProxy src, in InputArrayProxy confidence, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_createFastBilateralSolverFilter(
        in InputArrayProxy guide, double sigma_spatial, double sigma_luma, double sigma_chroma, double lambda, int num_iter, 
        double max_tol, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_fastBilateralSolverFilter(
        in InputArrayProxy guide, in InputArrayProxy src, in InputArrayProxy confidence, in OutputArrayProxy dst,
        double sigma_spatial, double sigma_luma, double sigma_chroma, double lambda, int num_iter, double max_tol);
        
    //////////////////////////////////////////////////////////////////////////
    // FastGlobalSmootherFilter 

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_FastGlobalSmootherFilter_delete(
        IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_Ptr_FastGlobalSmootherFilter_get(
        IntPtr ptr, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_FastGlobalSmootherFilter_filter(
        OpenCvSafeHandle obj, in InputArrayProxy src, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_createFastGlobalSmootherFilter(
        in InputArrayProxy guide, double lambda, double sigma_color, double lambda_attenuation, int num_iter, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_fastGlobalSmootherFilter(
        in InputArrayProxy guide, in InputArrayProxy src, in OutputArrayProxy dst, double lambda, double sigma_color, double lambda_attenuation, int num_iter);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_l0Smooth(in InputArrayProxy src, in OutputArrayProxy dst, double lambda, double kappa);





}
