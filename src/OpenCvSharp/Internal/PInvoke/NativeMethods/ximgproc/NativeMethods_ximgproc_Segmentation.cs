using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    // GraphSegmentation

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createGraphSegmentation(double sigma, float k, int minSize, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_GraphSegmentation_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_GraphSegmentation_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_GraphSegmentation_processImage(IntPtr obj, IntPtr src, IntPtr dst);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_GraphSegmentation_setSigma(IntPtr obj, double value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_GraphSegmentation_getSigma(IntPtr obj, out double returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_GraphSegmentation_setK(IntPtr obj, float value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_GraphSegmentation_getK(IntPtr obj, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_GraphSegmentation_setMinSize(IntPtr obj, int value);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_GraphSegmentation_getMinSize(IntPtr obj, out int returnValue);


    // SelectiveSearchSegmentationStrategy

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage(IntPtr obj,
        IntPtr img, IntPtr regions, IntPtr sizes, int image_id);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get(IntPtr obj, int r1, int r2, out float returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge(IntPtr obj, int r1, int r2);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get(IntPtr ptr, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get(IntPtr ptr, out IntPtr returnValue);


    // SelectiveSearchSegmentationStrategyMultiple

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_addStrategy(IntPtr obj, IntPtr g, float weight);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_clearStrategies(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0(
        out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1(
        IntPtr s1, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2(
        IntPtr s1, IntPtr s2, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3(
        IntPtr s1, IntPtr s2, IntPtr s3, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4(
        IntPtr s1, IntPtr s2, IntPtr s3, IntPtr s4, out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get(IntPtr ptr, out IntPtr returnValue);


    // SelectiveSearchSegmentation

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage(IntPtr obj, IntPtr img);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy(IntPtr obj,
        int k, float sigma);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast(
        IntPtr obj, int base_k, int inc_k, float sigma);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality(
        IntPtr obj, int base_k, int inc_k, float sigma);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_addImage(IntPtr obj, IntPtr img);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_clearImages(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation(IntPtr obj, IntPtr g);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy(IntPtr obj, IntPtr s);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_SelectiveSearchSegmentation_process(IntPtr obj, IntPtr rects);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_createSelectiveSearchSegmentation(out IntPtr returnValue);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete(IntPtr obj);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get(IntPtr ptr, out IntPtr returnValue);
}
