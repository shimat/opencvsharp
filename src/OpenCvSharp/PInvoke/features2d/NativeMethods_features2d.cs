using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        // DenseFeatureDetector
        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_DenseFeatureDetector_new(
            float initFeatureScale, int featureScaleLevels, float featureScaleMul,
            int initXyStep, int initImgBound, int varyXyStepWithScale, int varyImgBoundWithScale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_DenseFeatureDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_DenseFeatureDetector_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_Ptr_DenseFeatureDetector_get(IntPtr ptr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Ptr_DenseFeatureDetector_delete(IntPtr ptr);
        */
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_drawKeypoints(IntPtr image, KeyPoint[] keypoints, int keypointsLength,
            IntPtr outImage, Scalar color, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_drawMatches1(IntPtr img1, KeyPoint[] keypoints1, int keypoints1Length,
            IntPtr img2, KeyPoint[] keypoints2, int keypoints2Length,
            DMatch[] matches1to2, int matches1to2Length, IntPtr outImg,
            Scalar matchColor, Scalar singlePointColor,
            byte[] matchesMask, int matchesMaskLength, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_drawMatches2(IntPtr img1, KeyPoint[] keypoints1, int keypoints1Length,
            IntPtr img2, KeyPoint[] keypoints2, int keypoints2Length,
            IntPtr[] matches1to2, int matches1to2Size1, int[] matches1to2Size2,
            IntPtr outImg, Scalar matchColor, Scalar singlePointColor,
            IntPtr[] matchesMask, int matchesMaskSize1, int[] matchesMaskSize2, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_evaluateFeatureDetector(
            IntPtr img1, IntPtr img2, IntPtr H1to2,
            IntPtr keypoints1, IntPtr keypoints2,
            out float repeatability, out int correspCount);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_computeRecallPrecisionCurve(
            IntPtr[] matches1to2, int matches1to2Size1, int[] matches1to2Size2,
            IntPtr[] correctMatches1to2Mask, int correctMatches1to2MaskSize1, int[] correctMatches1to2MaskSize2,
            IntPtr recallPrecisionCurve);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float features2d_getRecall(
            Point2f[] recallPrecisionCurve, int recallPrecisionCurveSize, float l_precision);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_getNearestPoint(
            Point2f[] recallPrecisionCurve, int recallPrecisionCurveSize, float l_precision);
    }
}