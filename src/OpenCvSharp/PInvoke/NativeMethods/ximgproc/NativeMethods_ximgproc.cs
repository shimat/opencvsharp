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
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_niBlackThreshold(
            IntPtr src, IntPtr dst, double maxValue, int type,
            int blockSize, double k, int binarizationMethod);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_thinning(IntPtr src, IntPtr dst, int thinningType);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_anisotropicDiffusion(IntPtr src, IntPtr dst, float alpha, float K, int niters);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_weightedMedianFilter(
            IntPtr joint, IntPtr src, IntPtr dst,
            int r, double sigma, int weightType, IntPtr mask);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ximgproc_covarianceEstimation(
            IntPtr src, IntPtr dst, int windowRows, int windowCols);
    }
}