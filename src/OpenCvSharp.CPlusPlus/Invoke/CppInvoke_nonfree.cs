/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// P/Invoke methods of OpenCV 2.x C++ interface
    /// </summary>
    internal static partial class CppInvoke
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nonfree_initModule_nonfree();

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nonfree_SURF_new1")]
        public static extern IntPtr nonfree_SURF_new();
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nonfree_SURF_new2")]
        public static extern IntPtr nonfree_SURF_new(double hessianThreshold, int nOctaves,
            int nOctaveLayers, int extended, int upright);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SURF_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nonfree_SURF_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nonfree_SURF_descriptorType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nonfree_SURF_run1")]
        public static extern void nonfree_SURF_run(IntPtr obj, IntPtr img, IntPtr mask,
            IntPtr keypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nonfree_SURF_run2")]
        public static extern void nonfree_SURF_run(IntPtr obj, IntPtr img, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr nonfree_SURF_info(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double nonfree_SURF_hessianThreshold_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nonfree_SURF_nOctaves_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nonfree_SURF_nOctaveLayers_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nonfree_SURF_extended_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nonfree_SURF_upright_get(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SURF_hessianThreshold_set(IntPtr obj, double value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SURF_nOctaves_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SURF_nOctaveLayers_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SURF_extended_set(IntPtr obj, int value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SURF_upright_set(IntPtr obj, int value);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr nonfree_SIFT_new(int nfeatures, int nOctaveLayers,
            double contrastThreshold, double edgeThreshold, double sigma);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SIFT_delete(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nonfree_SIFT_descriptorSize(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nonfree_SIFT_descriptorType(IntPtr obj);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nonfree_SIFT_run1")]
        public static extern void nonfree_SIFT_run(IntPtr obj, IntPtr img, IntPtr mask,
            IntPtr keypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "nonfree_SIFT_run2")]
        public static extern void nonfree_SIFT_run(IntPtr obj, IntPtr img, IntPtr mask,
            IntPtr keypoints, IntPtr descriptors, int useProvidedKeypoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr nonfree_SIFT_info(IntPtr obj);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SIFT_buildGaussianPyramid(IntPtr obj, IntPtr baseMat,
            IntPtr pyr, int nOctaves);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SIFT_buildDoGPyramid(IntPtr obj, IntPtr[] pyr, int pyrLength, IntPtr dogPyr);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nonfree_SIFT_findScaleSpaceExtrema(IntPtr obj, IntPtr[] gaussPyr, int gaussPyrLength,
            IntPtr[] dogPyr, int dogPyrLength, IntPtr keypoints);
    }
}