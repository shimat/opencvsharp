using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable IdentifierTypo

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_niBlackThreshold(
            IntPtr src, IntPtr dst, double maxValue, int type,
            int blockSize, double k, int binarizationMethod, double r);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_thinning(IntPtr src, IntPtr dst, int thinningType);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_anisotropicDiffusion(IntPtr src, IntPtr dst, float alpha, float K, int niters);

        // brightedges.hpp

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_BrightEdges(
            IntPtr original, IntPtr edgeview, int contrast, int shortRange, int longRange);

        // color_match.hpp

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createQuaternionImage(IntPtr img, IntPtr qimg);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_qconj(IntPtr qimg, IntPtr qcimg);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_qunitary(IntPtr qimg, IntPtr qnimg);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_qmultiply(IntPtr src1, IntPtr src2, IntPtr dst);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_qdft(IntPtr img, IntPtr qimg, int flags, int sideLeft);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_colorMatchTemplate(IntPtr img, IntPtr templ, IntPtr result);

        // deriche_filter.hpp

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_GradientDericheY(IntPtr op, IntPtr dst, double alpha, double omega);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_GradientDericheX(IntPtr op, IntPtr dst, double alpha, double omega);

        // edgepreserving_filter.hpp

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_edgePreservingFilter(IntPtr src, IntPtr dst, int d, double threshold);

        // estimated_covariance

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_covarianceEstimation(
            IntPtr src, IntPtr dst, int windowRows, int windowCols);

        // fast_hough_transform

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_FastHoughTransform(
            IntPtr src, IntPtr dst, int dstMatDepth, int angleRange, int op, int makeSkew);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_HoughPoint2Line(
            Point houghPoint, IntPtr srcImgInfo, int angleRange, int makeSkew, int rules, out Vec4i returnValue);

        // paillou_filter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_GradientPaillouY(IntPtr op, IntPtr dst, double alpha, double omega);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_GradientPaillouX(IntPtr op, IntPtr dst, double alpha, double omega);

        // peilin.hpp

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe ExceptionStatus ximgproc_PeiLinNormalization_Mat23d(IntPtr I, double* returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_PeiLinNormalization_OutputArray(IntPtr I, IntPtr T);

        // weighted_median_filter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_weightedMedianFilter(
            IntPtr joint, IntPtr src, IntPtr dst, int r, double sigma, int weightType, IntPtr mask);
    }
}