using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_inpaint(IntPtr src, IntPtr inpaintMask,
            IntPtr dst, double inpaintRadius, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_fastNlMeansDenoising(IntPtr src, IntPtr dst, float h,
            int templateWindowSize, int searchWindowSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_fastNlMeansDenoisingColored(IntPtr src, IntPtr dst,
            float h, float hColor, int templateWindowSize, int searchWindowSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_fastNlMeansDenoisingMulti(IntPtr[] srcImgs, int srcImgsLength,
            IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize,
            float h, int templateWindowSize, int searchWindowSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_fastNlMeansDenoisingColoredMulti(IntPtr[] srcImgs, int srcImgsLength,
            IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize,
            float h, float hColor, int templateWindowSize, int searchWindowSize);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_denoise_TVL1(
            IntPtr[] observations, int observationsSize, IntPtr result, double lambda, int niters);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_decolor(
            IntPtr src, IntPtr grayscale, IntPtr color_boost);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_seamlessClone(
            IntPtr src, IntPtr dst, IntPtr mask, Point p, IntPtr blend, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_colorChange(
            IntPtr src, IntPtr mask, IntPtr dst, float red_mul, float green_mul, float blue_mul);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_illuminationChange(
            IntPtr src, IntPtr mask, IntPtr dst, float alpha, float beta);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_textureFlattening(
            IntPtr src, IntPtr mask, IntPtr dst,
            float low_threshold, float high_threshold, int kernel_size);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_edgePreservingFilter(
            IntPtr src, IntPtr dst, int flags, float sigma_s, float sigma_r);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_detailEnhance(
            IntPtr src, IntPtr dst, float sigma_s, float sigma_r);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_pencilSketch(
            IntPtr src, IntPtr dst1, IntPtr dst2,
            float sigma_s, float sigma_r, float shade_factor);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void photo_stylization(
            IntPtr src, IntPtr dst, float sigma_s, float sigma_r);

    }
}