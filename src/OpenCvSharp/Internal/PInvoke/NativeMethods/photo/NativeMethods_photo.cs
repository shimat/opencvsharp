using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_inpaint(
        IntPtr src, IntPtr inpaintMask,
        IntPtr dst, double inpaintRadius, int flags);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_fastNlMeansDenoising(
        IntPtr src, IntPtr dst, float h,
        int templateWindowSize, int searchWindowSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_fastNlMeansDenoisingColored(
        IntPtr src, IntPtr dst,
        float h, float hColor, int templateWindowSize, int searchWindowSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_fastNlMeansDenoisingMulti(
        IntPtr[] srcImgs, int srcImgsLength,
        IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize,
        float h, int templateWindowSize, int searchWindowSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_fastNlMeansDenoisingColoredMulti(IntPtr[] srcImgs, int srcImgsLength,
        IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize,
        float h, float hColor, int templateWindowSize, int searchWindowSize);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_denoise_TVL1(
        IntPtr[] observations, int observationsSize, IntPtr result, double lambda, int niters);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_decolor(
        IntPtr src, IntPtr grayscale, IntPtr color_boost);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_seamlessClone(
        IntPtr src, IntPtr dst, IntPtr mask, Point p, IntPtr blend, int flags);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_colorChange(
        IntPtr src, IntPtr mask, IntPtr dst, float red_mul, float green_mul, float blue_mul);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_illuminationChange(
        IntPtr src, IntPtr mask, IntPtr dst, float alpha, float beta);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_textureFlattening(
        IntPtr src, IntPtr mask, IntPtr dst,
        float low_threshold, float high_threshold, int kernel_size);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_edgePreservingFilter(
        IntPtr src, IntPtr dst, int flags, float sigma_s, float sigma_r);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_detailEnhance(
        IntPtr src, IntPtr dst, float sigma_s, float sigma_r);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_pencilSketch(
        IntPtr src, IntPtr dst1, IntPtr dst2,
        float sigma_s, float sigma_r, float shade_factor);

    [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ExceptionStatus photo_stylization(
        IntPtr src, IntPtr dst, float sigma_s, float sigma_r);

}
