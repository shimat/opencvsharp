using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        #region Filter Engine

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_boxFilter(
            IntPtr src, IntPtr dst, int ddepth, Size ksize, Point anchor, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_erode1(
            IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_erode2(
            IntPtr src, IntPtr dst, IntPtr kernel, IntPtr buf,
            Point anchor, int iterations, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_dilate1(
            IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_dilate2(
            IntPtr src, IntPtr dst, IntPtr kernel, IntPtr buf,
            Point anchor, int iterations, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_morphologyEx1(
            IntPtr src, IntPtr dst, int op, IntPtr kernel, Point anchor, int iterations);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_morphologyEx2(
            IntPtr src, IntPtr dst, int op, IntPtr kernel, IntPtr buf1, IntPtr buf2,
            Point anchor, int iterations, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_filter2D(
            IntPtr src, IntPtr dst, int ddepth, IntPtr kernel, Point anchor, int borderType, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_sepFilter2D1(
            IntPtr src, IntPtr dst, int ddepth, IntPtr kernelX,
            IntPtr kernelY, Point anchor, int rowBorderType, int columnBorderType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_sepFilter2D2(
            IntPtr src, IntPtr dst, int ddepth, IntPtr kernelX,
            IntPtr kernelY, IntPtr buf, Point anchor, int rowBorderType, int columnBorderType, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Sobel1(
            IntPtr src, IntPtr dst, int ddepth, int dx, int dy, int ksize,
            double scale, int rowBorderType, int columnBorderType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Sobel2(
            IntPtr src, IntPtr dst, int ddepth, int dx, int dy, IntPtr buf,
            int ksize, double scale, int rowBorderType, int columnBorderType, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Scharr1(
            IntPtr src, IntPtr dst, int ddepth, int dx, int dy, double scale, int rowBorderType, int columnBorderType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Scharr2(
            IntPtr src, IntPtr dst, int ddepth, int dx, int dy, IntPtr buf, double scale,
            int rowBorderType, int columnBorderType, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_GaussianBlur1(
            IntPtr src, IntPtr dst, Size ksize, double sigma1, double sigma2,
            int rowBorderType, int columnBorderType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_GaussianBlur2(
            IntPtr src, IntPtr dst, Size ksize, IntPtr buf, double sigma1, double sigma2,
            int rowBorderType, int columnBorderType, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_Laplacian(
            IntPtr src, IntPtr dst, int ddepth, int ksize, double scale, int borderType, IntPtr stream);

        #endregion


        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_minMaxLoc1(
            IntPtr src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc,
            IntPtr mask);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_minMaxLoc2(
            IntPtr src, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc,
            IntPtr mask, IntPtr valbuf, IntPtr locbuf);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_matchTemplate1(
            IntPtr image, IntPtr templ, IntPtr result, int method, IntPtr stream);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void gpu_matchTemplate2(
            IntPtr image, IntPtr templ, IntPtr result, int method, IntPtr buf, IntPtr stream);
    }
}