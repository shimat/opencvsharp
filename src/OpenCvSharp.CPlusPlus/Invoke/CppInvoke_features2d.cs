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
        public static extern void features2d_FAST(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void features2d_FASTX(IntPtr image, IntPtr keypoints, int threshold, int nonmaxSupression, int type);
    }
}