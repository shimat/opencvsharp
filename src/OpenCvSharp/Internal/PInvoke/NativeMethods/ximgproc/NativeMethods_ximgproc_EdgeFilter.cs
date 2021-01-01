using System;
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
        // DTFilter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_DTFilter_delete(
            IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_DTFilter_get(
            IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_DTFilter_filter(
            IntPtr obj, IntPtr src, IntPtr dst, int dDepth);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createDTFilter(
            IntPtr guide, double sigmaSpatial, double sigmaColor, int mode, int numIters, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_dtFilter(
            IntPtr guide, IntPtr src, IntPtr dst, double sigmaSpatial, double sigmaColor, int mode, int numIters);
        
        //////////////////////////////////////////////////////////////////////////
        // GuidedFilter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_GuidedFilter_delete(
            IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_GuidedFilter_get(
            IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_GuidedFilter_filter(
            IntPtr obj, IntPtr src, IntPtr dst, int dDepth);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createGuidedFilter(
            IntPtr guide, int radius, double eps, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_guidedFilter(
            IntPtr guide, IntPtr src, IntPtr dst, int radius, double eps, int dDepth);

        //////////////////////////////////////////////////////////////////////////
        // AdaptiveManifoldFilter

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_AdaptiveManifoldFilter_delete(
            IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_AdaptiveManifoldFilter_get(
            IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_filter(
            IntPtr obj, IntPtr src, IntPtr dst, IntPtr joint);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_collectGarbage(
            IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_getSigmaS(IntPtr obj, out double returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_setSigmaS(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_getSigmaR(IntPtr obj, out double returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_setSigmaR(IntPtr obj, double val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_getTreeHeight(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_setTreeHeight(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_getPCAIterations(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_setPCAIterations(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_getAdjustOutliers(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_setAdjustOutliers(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_getUseRNG(IntPtr obj, out int returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_AdaptiveManifoldFilter_setUseRNG(IntPtr obj, int val);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createAMFilter(
            double sigma_s, double sigma_r, int adjust_outliers, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_amFilter(
            IntPtr joint, IntPtr src, IntPtr dst, double sigma_s, double sigma_r, int adjust_outliers);

        //////////////////////////////////////////////////////////////////////////

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_jointBilateralFilter(
            IntPtr joint, IntPtr src, IntPtr dst, int d, double sigmaColor, double sigmaSpace, int borderType);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_bilateralTextureFilter(
            IntPtr src, IntPtr dst, int fr, int numIter, double sigmaAlpha, double sigmaAvg);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_rollingGuidanceFilter(
            IntPtr src, IntPtr dst, int d, double sigmaColor, double sigmaSpace, int numOfIter, int borderType);
        
        //////////////////////////////////////////////////////////////////////////
        // FastBilateralSolverFilter 

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_FastBilateralSolverFilter_delete(
            IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_FastBilateralSolverFilter_get(
            IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_FastBilateralSolverFilter_filter(
            IntPtr obj, IntPtr src, IntPtr confidence, IntPtr dst);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createFastBilateralSolverFilter(
            IntPtr guide, double sigma_spatial, double sigma_luma, double sigma_chroma, double lambda, int num_iter, 
            double max_tol, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_fastBilateralSolverFilter(
            IntPtr guide, IntPtr src, IntPtr confidence, IntPtr dst,
            double sigma_spatial, double sigma_luma, double sigma_chroma, double lambda, int num_iter, double max_tol);
        
        //////////////////////////////////////////////////////////////////////////
        // FastGlobalSmootherFilter 

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_FastGlobalSmootherFilter_delete(
            IntPtr obj);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_Ptr_FastGlobalSmootherFilter_get(
            IntPtr ptr, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_FastGlobalSmootherFilter_filter(
            IntPtr obj, IntPtr src, IntPtr dst);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_createFastGlobalSmootherFilter(
            IntPtr guide, double lambda, double sigma_color, double lambda_attenuation, int num_iter, out IntPtr returnValue);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_fastGlobalSmootherFilter(
            IntPtr guide, IntPtr src, IntPtr dst, double lambda, double sigma_color, double lambda_attenuation, int num_iter);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ExceptionStatus ximgproc_l0Smooth(IntPtr src, IntPtr dst, double lambda, double kappa);
    }
}