using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // GraphSegmentation

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createGraphSegmentation(double sigma, float k, int min_size);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_Ptr_GraphSegmentation_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_Ptr_GraphSegmentation_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_GraphSegmentation_processImage(IntPtr obj, IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_GraphSegmentation_setSigma(IntPtr obj, double value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double ximgproc_segmentation_GraphSegmentation_getSigma(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_GraphSegmentation_setK(IntPtr obj, float value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ximgproc_segmentation_GraphSegmentation_getK(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_GraphSegmentation_setMinSize(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int ximgproc_segmentation_GraphSegmentation_getMinSize(IntPtr obj);


        // SelectiveSearchSegmentationStrategy

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentationStrategy_setImage(IntPtr obj,
            IntPtr img, IntPtr regions, IntPtr sizes, int image_id);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float ximgproc_segmentation_SelectiveSearchSegmentationStrategy_get(IntPtr obj, int r1, int r2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentationStrategy_merge(IntPtr obj, int r1, int r2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyColor();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategySize();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyTexture();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyFill();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyColor_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategySize_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyTexture_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyFill_get(IntPtr ptr);


        // SelectiveSearchSegmentationStrategyMultiple

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_addStrategy(IntPtr obj, IntPtr g, float weight);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentationStrategyMultiple_clearStrategies(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple0();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple1(
            IntPtr s1);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple2(
            IntPtr s1, IntPtr s2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple3(
            IntPtr s1, IntPtr s2, IntPtr s3);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentationStrategyMultiple4(
            IntPtr s1, IntPtr s2, IntPtr s3, IntPtr s4);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentationStrategyMultiple_get(IntPtr ptr);


        // SelectiveSearchSegmentation

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_setBaseImage(IntPtr obj, IntPtr img);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_switchToSingleStrategy(IntPtr obj,
            int k, float sigma);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchFast(
            IntPtr obj, int base_k, int inc_k, float sigma);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_switchToSelectiveSearchQuality(
            IntPtr obj, int base_k, int inc_k, float sigma);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_addImage(IntPtr obj, IntPtr img);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_clearImages(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_addGraphSegmentation(IntPtr obj, IntPtr g);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_clearGraphSegmentations(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_addStrategy(IntPtr obj, IntPtr s);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_clearStrategies(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_SelectiveSearchSegmentation_process(IntPtr obj, IntPtr rects);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_createSelectiveSearchSegmentation();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ximgproc_segmentation_Ptr_SelectiveSearchSegmentation_get(IntPtr ptr);
    }
}