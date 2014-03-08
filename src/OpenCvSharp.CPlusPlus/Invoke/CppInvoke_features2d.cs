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

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_StarDetector_new(int maxSize, int responseThreshold,
            int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_StarDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_StarDetector_detect(IntPtr obj, IntPtr image, out IntPtr keypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_StarDetector_info(IntPtr obj);

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

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_GFTTDetector_new(int maxCorners, double qualityLevel, 
            double minDistance, int blockSize, int useHarrisDetector, double k);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_GFTTDetector_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr features2d_GFTTDetector_info(IntPtr obj);

    }
}