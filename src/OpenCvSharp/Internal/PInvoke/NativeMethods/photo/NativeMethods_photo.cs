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
    internal static partial ExceptionStatus photo_inpaint(
        in InputArrayProxy src, in InputArrayProxy inpaintMask,
        in OutputArrayProxy dst, double inpaintRadius, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_fastNlMeansDenoising(
        in InputArrayProxy src, in OutputArrayProxy dst, float h,
        int templateWindowSize, int searchWindowSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_fastNlMeansDenoisingColored(
        in InputArrayProxy src, in OutputArrayProxy dst,
        float h, float hColor, int templateWindowSize, int searchWindowSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_fastNlMeansDenoisingMulti(
        IntPtr[] srcImgs, int srcImgsLength,
        in OutputArrayProxy dst, int imgToDenoiseIndex, int temporalWindowSize,
        float h, int templateWindowSize, int searchWindowSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_fastNlMeansDenoisingColoredMulti(IntPtr[] srcImgs, int srcImgsLength,
        in OutputArrayProxy dst, int imgToDenoiseIndex, int temporalWindowSize,
        float h, float hColor, int templateWindowSize, int searchWindowSize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus photo_denoise_TVL1(
        IntPtr[] observations, int observationsSize, IntPtr result, double lambda, int niters);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_decolor(
        in InputArrayProxy src, in OutputArrayProxy grayscale, in OutputArrayProxy color_boost);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_seamlessClone(
        in InputArrayProxy src, in InputArrayProxy dst, in InputArrayProxy mask, Point p, in OutputArrayProxy blend, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_colorChange(
        in InputArrayProxy src, in InputArrayProxy mask, in OutputArrayProxy dst, float red_mul, float green_mul, float blue_mul);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_illuminationChange(
        in InputArrayProxy src, in InputArrayProxy mask, in OutputArrayProxy dst, float alpha, float beta);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_textureFlattening(
        in InputArrayProxy src, in InputArrayProxy mask, in OutputArrayProxy dst,
        float low_threshold, float high_threshold, int kernel_size);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_edgePreservingFilter(
        in InputArrayProxy src, in OutputArrayProxy dst, int flags, float sigma_s, float sigma_r);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_detailEnhance(
        in InputArrayProxy src, in OutputArrayProxy dst, float sigma_s, float sigma_r);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_pencilSketch(
        in InputArrayProxy src, in OutputArrayProxy dst1, in OutputArrayProxy dst2,
        float sigma_s, float sigma_r, float shade_factor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus photo_stylization(
        in InputArrayProxy src, in OutputArrayProxy dst, float sigma_s, float sigma_r);

}
