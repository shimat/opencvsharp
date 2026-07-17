using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenCvSharp.Detail;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // Estimator

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_Estimator_apply(
        OpenCvSafeHandle obj,
        WImageFeatures[] features, int featuresSize,
        WMatchesInfo[] pairwiseMatches, int pairwiseMatchesSize,
        WCameraParams[] cameras, int camerasSize,
        out int returnValue);


    // HomographyBasedEstimator

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_HomographyBasedEstimator_new(int isFocalsEstimated, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_HomographyBasedEstimator_delete(IntPtr obj);


    // AffineBasedEstimator

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_AffineBasedEstimator_new(out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_AffineBasedEstimator_delete(IntPtr obj);


    // BundleAdjusterBase

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterBase_delete(IntPtr obj);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterBase_refinementMask(OpenCvSafeHandle obj, IntPtr returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterBase_setRefinementMask(OpenCvSafeHandle obj, IntPtr mask);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterBase_confThresh(OpenCvSafeHandle obj, out double returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterBase_setConfThresh(OpenCvSafeHandle obj, double confThresh);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterBase_termCriteria(OpenCvSafeHandle obj, out TermCriteria returnValue);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterBase_setTermCriteria(OpenCvSafeHandle obj, TermCriteria termCriteria);


    // NoBundleAdjuster

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_NoBundleAdjuster_new(out IntPtr returnValue);


    // BundleAdjusterReproj

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterReproj_new(out IntPtr returnValue);


    // BundleAdjusterRay

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterRay_new(out IntPtr returnValue);


    // BundleAdjusterAffine

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterAffine_new(out IntPtr returnValue);


    // BundleAdjusterAffinePartial

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_BundleAdjusterAffinePartial_new(out IntPtr returnValue);


    // Auxiliary functions

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_waveCorrect(IntPtr[] rmats, int rmatsLength, int kind);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_matchesGraphAsString(
        int numImages, WMatchesInfo[] pairwiseMatches, int pairwiseMatchesSize, float confThreshold, IntPtr buf);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus stitching_leaveBiggestComponent(
        WImageFeatures[] features, int featuresSize,
        WMatchesInfo[] pairwiseMatches, int pairwiseMatchesSize,
        float confThreshold,
        IntPtr returnValue);
}
