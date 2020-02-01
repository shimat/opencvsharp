﻿using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_niBlackThreshold(
            IntPtr src, IntPtr dst, double maxValue, int type,
            int blockSize, double k, int binarizationMethod);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_thinning(IntPtr src, IntPtr dst, int thinningType);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_anisotropicDiffusion(IntPtr src, IntPtr dst, float alpha, float K, int niters);


        // weighted_median_filter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_weightedMedianFilter(
            IntPtr joint, IntPtr src, IntPtr dst,
            int r, double sigma, int weightType, IntPtr mask);


        // estimated_covariance

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_covarianceEstimation(
            IntPtr src, IntPtr dst, int windowRows, int windowCols);


        // paillou_filter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_GradientPaillouY(IntPtr op, IntPtr dst, double alpha, double omega);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_GradientPaillouX(IntPtr op, IntPtr dst, double alpha, double omega);


        // fast_hough_transform

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_FastHoughTransform(
            IntPtr src, IntPtr dst,
            int dstMatDepth, int angleRange, int op, int makeSkew);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_HoughPoint2Line(
            Point houghPoint, IntPtr srcImgInfo,
            int angleRange, int makeSkew, int rules, out Vec4i returnValue);
    }
}