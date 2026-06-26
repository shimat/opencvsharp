using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_inpaint(
        IntPtr src, IntPtr inpaintMask,
        IntPtr dst, double inpaintRadius, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_fastNlMeansDenoising(
        IntPtr src, IntPtr dst, float h,
        int templateWindowSize, int searchWindowSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_fastNlMeansDenoisingColored(
        IntPtr src, IntPtr dst,
        float h, float hColor, int templateWindowSize, int searchWindowSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_fastNlMeansDenoisingMulti(
        IntPtr[] srcImgs, int srcImgsLength,
        IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize,
        float h, int templateWindowSize, int searchWindowSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_fastNlMeansDenoisingColoredMulti(IntPtr[] srcImgs, int srcImgsLength,
        IntPtr dst, int imgToDenoiseIndex, int temporalWindowSize,
        float h, float hColor, int templateWindowSize, int searchWindowSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_denoise_TVL1(
        IntPtr[] observations, int observationsSize, IntPtr result, double lambda, int niters);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_decolor(
        IntPtr src, IntPtr grayscale, IntPtr color_boost);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_seamlessClone(
        IntPtr src, IntPtr dst, IntPtr mask, Point p, IntPtr blend, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_colorChange(
        IntPtr src, IntPtr mask, IntPtr dst, float red_mul, float green_mul, float blue_mul);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_illuminationChange(
        IntPtr src, IntPtr mask, IntPtr dst, float alpha, float beta);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_textureFlattening(
        IntPtr src, IntPtr mask, IntPtr dst,
        float low_threshold, float high_threshold, int kernel_size);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_edgePreservingFilter(
        IntPtr src, IntPtr dst, int flags, float sigma_s, float sigma_r);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_detailEnhance(
        IntPtr src, IntPtr dst, float sigma_s, float sigma_r);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_pencilSketch(
        IntPtr src, IntPtr dst1, IntPtr dst2,
        float sigma_s, float sigma_r, float shade_factor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_stylization(
        IntPtr src, IntPtr dst, float sigma_s, float sigma_r);

}
