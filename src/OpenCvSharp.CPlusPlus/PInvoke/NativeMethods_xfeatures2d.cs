using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        // BriefDescriptorExtractor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_BriefDescriptorExtractor_new(int bytes);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_BriefDescriptorExtractor_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_BriefDescriptorExtractor_read(IntPtr obj, IntPtr fn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_BriefDescriptorExtractor_write(IntPtr obj, IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_BriefDescriptorExtractor_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_BriefDescriptorExtractor_descriptorType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_BriefDescriptorExtractor_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_Ptr_BriefDescriptorExtractor_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_Ptr_BriefDescriptorExtractor_delete(IntPtr ptr);

        // FREAK
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_FREAK_new(int orientationNormalized,
            int scaleNormalized, float patternScale, int nOctaves,
            int[] selectedPairs, int selectedPairsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_FREAK_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_FREAK_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_FREAK_descriptorType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_FREAK_selectPairs(IntPtr obj, IntPtr[] images, int imagesLength,
            IntPtr keypoints, double corrThresh, int verbose, IntPtr outVal);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_FREAK_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_Ptr_FREAK_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_Ptr_FREAK_delete(IntPtr ptr);

        // StarDetector
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_StarDetector_new(int maxSize, int responseThreshold,
            int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_StarDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_StarDetector_detect(IntPtr obj, IntPtr image, out IntPtr keypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_StarDetector_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_Ptr_StarDetector_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_Ptr_StarDetector_delete(IntPtr ptr);

        // DenseFeatureDetector
        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_DenseFeatureDetector_new(
            float initFeatureScale, int featureScaleLevels, float featureScaleMul,
            int initXyStep, int initImgBound, int varyXyStepWithScale, int varyImgBoundWithScale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_DenseFeatureDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_DenseFeatureDetector_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_Ptr_DenseFeatureDetector_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_Ptr_DenseFeatureDetector_delete(IntPtr ptr);
        */

        // SURF
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_SURF_new1();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_SURF_new2(double hessianThreshold, int nOctaves,
            int nOctaveLayers, int extended, int upright);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SURF_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr xfeatures2d_SURF_createAlgorithm([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_Ptr_SURF_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_Ptr_SURF_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_SURF_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_SURF_descriptorType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SURF_run1(IntPtr obj, IntPtr img, IntPtr mask, IntPtr keypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SURF_run2_vector(IntPtr obj, IntPtr img, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SURF_run2_OutputArray(IntPtr obj, IntPtr img, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_SURF_info(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double xfeatures2d_SURF_hessianThreshold_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_SURF_nOctaves_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_SURF_nOctaveLayers_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_SURF_extended_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_SURF_upright_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SURF_hessianThreshold_set(IntPtr obj, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SURF_nOctaves_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SURF_nOctaveLayers_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SURF_extended_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SURF_upright_set(IntPtr obj, int value);

        // SIFT
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_SIFT_new(int nfeatures, int nOctaveLayers,
            double contrastThreshold, double edgeThreshold, double sigma);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SIFT_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr xfeatures2d_SIFT_createAlgorithm([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_Ptr_SIFT_cast(IntPtr ptrAlgorithm);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_Ptr_SIFT_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_Ptr_SIFT_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_SIFT_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int xfeatures2d_SIFT_descriptorType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SIFT_run1(IntPtr obj, IntPtr img, IntPtr mask, IntPtr keypoints);
        /*[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SIFT_run2_vector(IntPtr obj, IntPtr img, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);*/
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SIFT_run2_OutputArray(IntPtr obj, IntPtr img, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xfeatures2d_SIFT_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SIFT_buildGaussianPyramid(IntPtr obj, IntPtr baseMat,
            IntPtr pyr, int nOctaves);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SIFT_buildDoGPyramid(IntPtr obj, IntPtr[] pyr, int pyrLength, IntPtr dogPyr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void xfeatures2d_SIFT_findScaleSpaceExtrema(IntPtr obj, IntPtr[] gaussPyr, int gaussPyrLength,
            IntPtr[] dogPyr, int dogPyrLength, IntPtr keypoints);
    }
}