using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        // BriefDescriptorExtractor
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_BriefDescriptorExtractor_create(int bytes);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_Ptr_BriefDescriptorExtractor_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_BriefDescriptorExtractor_read(IntPtr obj, IntPtr fn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_BriefDescriptorExtractor_write(IntPtr obj, IntPtr fs);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int xfeatures2d_BriefDescriptorExtractor_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int xfeatures2d_BriefDescriptorExtractor_descriptorType(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_Ptr_BriefDescriptorExtractor_get(IntPtr ptr);

        // FREAK
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_FREAK_create(int orientationNormalized,
            int scaleNormalized, float patternScale, int nOctaves,
            int[] selectedPairs, int selectedPairsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_Ptr_FREAK_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_Ptr_FREAK_get(IntPtr ptr);

        // StarDetector
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_StarDetector_create(
            int maxSize, int responseThreshold,
            int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_Ptr_StarDetector_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_Ptr_StarDetector_get(IntPtr ptr);

        // DenseFeatureDetector
        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_DenseFeatureDetector_new(
            float initFeatureScale, int featureScaleLevels, float featureScaleMul,
            int initXyStep, int initImgBound, int varyXyStepWithScale, int varyImgBoundWithScale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_DenseFeatureDetector_delete(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_Ptr_DenseFeatureDetector_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_Ptr_DenseFeatureDetector_delete(IntPtr ptr);
        */

        // LUCID
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_LUCID_create(int lucid_kernel = 1, int blur_kernel = 2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_Ptr_LUCID_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_Ptr_LUCID_get(IntPtr ptr);

        // LATCH
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_LATCH_create(int bytes, int rotationInvariance, int half_ssd_size, double sigma);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_Ptr_LATCH_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_Ptr_LATCH_get(IntPtr ptr);

        // SURF
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_SURF_create(
            double hessianThreshold, int nOctaves,
            int nOctaveLayers, int extended, int upright);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_Ptr_SURF_delete(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_Ptr_SURF_get(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double xfeatures2d_SURF_getHessianThreshold(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int xfeatures2d_SURF_getNOctaves(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int xfeatures2d_SURF_getNOctaveLayers(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int xfeatures2d_SURF_getExtended(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int xfeatures2d_SURF_getUpright(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_SURF_setHessianThreshold(IntPtr obj, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_SURF_setNOctaves(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_SURF_setNOctaveLayers(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_SURF_setExtended(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_SURF_setUpright(IntPtr obj, int value);

        // SIFT
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_SIFT_create(int nfeatures, int nOctaveLayers,
            double contrastThreshold, double edgeThreshold, double sigma);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void xfeatures2d_Ptr_SIFT_delete(IntPtr ptr);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr xfeatures2d_Ptr_SIFT_get(IntPtr ptr);
    }
}