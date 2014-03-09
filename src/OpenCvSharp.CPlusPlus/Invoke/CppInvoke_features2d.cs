/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>

    internal static partial class CppInvoke
    {
        // FeatureDetector
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "features2d_FeatureDetector_detect1")]
        public static extern void features2d_FeatureDetector_detect(IntPtr detector, IntPtr image, IntPtr keypoints, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "features2d_FeatureDetector_detect2")]
        public static extern void features2d_FeatureDetector_detect(IntPtr detector, IntPtr[] images, int imageLength, IntPtr keypoints, IntPtr[] mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_FeatureDetector_empty(IntPtr detector);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_FeatureDetector_create([MarshalAs(UnmanagedType.LPStr)] string detectorType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_Feature2D_compute(IntPtr obj, IntPtr image, IntPtr keypoints, IntPtr descriptors);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_Feature2D_create([MarshalAs(UnmanagedType.LPStr)] string detectorType);

        // BRISK
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_BRISK_new(int thresh, int octaves, float patternScale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_BRISK_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_BRISK_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_BRISK_descriptorType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_BRISK_run1(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_BRISK_run2(IntPtr obj, IntPtr image, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_BRISK_info(IntPtr obj);

        // ORB
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_ORB_new(int nFeatures, float scaleFactor, int nlevels, int edgeThreshold,
            int firstLevel, int wtaK, int scoreType, int patchSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_ORB_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_ORB_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int features2d_ORB_descriptorType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_ORB_run1(IntPtr obj, IntPtr image, IntPtr mask, IntPtr keypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_ORB_run2(IntPtr obj, IntPtr image, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_ORB_info(IntPtr obj);

        // MSER
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_MSER_new(int delta, int minArea, int maxArea,
                                                        double maxVariation, double minDiversity, int maxEvolution,
                                                        double areaThreshold, double minMargin, int edgeBlurSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_MSER_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_MSER_detect(IntPtr obj, IntPtr image, out IntPtr msers, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_MSER_info(IntPtr obj);

        // StarDetector
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_StarDetector_new(int maxSize, int responseThreshold,
            int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_StarDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_StarDetector_detect(IntPtr obj, IntPtr image, out IntPtr keypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_StarDetector_info(IntPtr obj);

        // FAST
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_FAST(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_FASTX(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression, int type);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_FastFeatureDetector_new(int threshold, int nonmaxSuppression);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_FastFeatureDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_FastFeatureDetector_info(IntPtr obj);

        // GFTTDetector
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_GFTTDetector_new(int maxCorners, double qualityLevel, 
            double minDistance, int blockSize, int useHarrisDetector, double k);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_GFTTDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_GFTTDetector_info(IntPtr obj);


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_drawKeypoints(IntPtr image, KeyPoint[] keypoints, int keypointsLength,
            IntPtr outImage, CvScalar color, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_drawMatches1(IntPtr img1, KeyPoint[] keypoints1, int keypoints1Length,
            IntPtr img2, KeyPoint[] keypoints2, int keypoints2Length,
            DMatch[] matches1to2, int matches1to2Length, IntPtr outImg,
            CvScalar matchColor, CvScalar singlePointColor,
            byte[] matchesMask, int matchesMaskLength, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_drawMatches2(IntPtr img1, KeyPoint[] keypoints1, int keypoints1Length,
            IntPtr img2, KeyPoint[] keypoints2, int keypoints2Length,
            IntPtr[] matches1to2, int matches1to2Size1, int[] matches1to2Size2,
            IntPtr outImg, CvScalar matchColor, CvScalar singlePointColor,
            IntPtr[] matchesMask, int matchesMaskSize1, int[] matchesMaskSize2, int flags);
    }
}