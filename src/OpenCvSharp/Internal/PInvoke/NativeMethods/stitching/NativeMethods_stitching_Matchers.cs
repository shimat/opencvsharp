using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using OpenCvSharp.Detail;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_computeImageFeatures1(
        IntPtr featuresFinder,
        IntPtr[] images,
        int imagesLength,
        IntPtr featuresVec,
        IntPtr[]? masks);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern unsafe ExceptionStatus stitching_computeImageFeatures2(
        IntPtr featuresFinder,
        IntPtr image,
        WImageFeatures* features,
        IntPtr mask);


    // FeaturesMatcher

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_FeaturesMatcher_apply(
        IntPtr obj,
        ref WImageFeatures features1, 
        ref WImageFeatures features2,
        out int outSrcImgIdx, 
        out int outDstImgIdx,
        IntPtr outMatches, 
        IntPtr outInliersMask,
        out int outNumInliers,
        IntPtr outH,
        out double outConfidence);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_FeaturesMatcher_apply2(
        IntPtr obj,
        WImageFeatures[] features, int featuresSize,
        IntPtr mask,
        IntPtr outSrcImgIdx,
        IntPtr outDstImgIdx,
        IntPtr outMatches,
        IntPtr outInliersMask,
        IntPtr outNumInliers,
        IntPtr outH,
        IntPtr outConfidence);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_FeaturesMatcher_isThreadSafe(
        IntPtr obj, out int returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_FeaturesMatcher_collectGarbage(
        IntPtr obj);


    // BestOf2NearestMatcher

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_BestOf2NearestMatcher_new(
        int tryUseGpu, float matchConf, int numMatchesThresh1, int numMatchesThresh2,
        out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_BestOf2NearestMatcher_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_BestOf2NearestMatcher_collectGarbage(IntPtr obj);


    // AffineBestOf2NearestMatcher

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_AffineBestOf2NearestMatcher_new(
        int fullAffine, int tryUseGpu, float matchConf, int numMatchesThresh1,
        out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus stitching_AffineBestOf2NearestMatcher_delete(
        IntPtr obj);
}
