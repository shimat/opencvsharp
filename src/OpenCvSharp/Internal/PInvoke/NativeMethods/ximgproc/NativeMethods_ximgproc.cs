using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable IDE1006 // Naming style
// ReSharper disable IdentifierTypo

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_niBlackThreshold(
        IntPtr src, IntPtr dst, double maxValue, int type,
        int blockSize, double k, int binarizationMethod, double r);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_thinning(IntPtr src, IntPtr dst, int thinningType);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_anisotropicDiffusion(IntPtr src, IntPtr dst, float alpha, float K, int niters);

    // brightedges.hpp

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_BrightEdges(
        IntPtr original, IntPtr edgeview, int contrast, int shortRange, int longRange);

    // color_match.hpp

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_createQuaternionImage(IntPtr img, IntPtr qimg);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_qconj(IntPtr qimg, IntPtr qcimg);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_qunitary(IntPtr qimg, IntPtr qnimg);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_qmultiply(IntPtr src1, IntPtr src2, IntPtr dst);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_qdft(IntPtr img, IntPtr qimg, int flags, int sideLeft);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_colorMatchTemplate(IntPtr img, IntPtr templ, IntPtr result);

    // deriche_filter.hpp

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_GradientDericheY(IntPtr op, IntPtr dst, double alpha, double omega);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_GradientDericheX(IntPtr op, IntPtr dst, double alpha, double omega);

    // edgepreserving_filter.hpp

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_edgePreservingFilter(IntPtr src, IntPtr dst, int d, double threshold);

    // estimated_covariance

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_covarianceEstimation(
        IntPtr src, IntPtr dst, int windowRows, int windowCols);

    // fast_hough_transform

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_FastHoughTransform(
        IntPtr src, IntPtr dst, MatType dstMatDepth, int angleRange, int op, int makeSkew);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_HoughPoint2Line(
        Point houghPoint, IntPtr srcImgInfo, int angleRange, int makeSkew, int rules, out Vec4i returnValue);

    // paillou_filter

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_GradientPaillouY(IntPtr op, IntPtr dst, double alpha, double omega);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_GradientPaillouX(IntPtr op, IntPtr dst, double alpha, double omega);

    // peilin.hpp

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static unsafe partial ExceptionStatus ximgproc_PeiLinNormalization_Mat23d(IntPtr I, double* returnValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_PeiLinNormalization_OutputArray(IntPtr I, IntPtr T);

    // run_length_morphology.hpp

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_rl_threshold(
        IntPtr src, IntPtr rlDest, double thresh, int type);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_rl_dilate(
        IntPtr rlSrc, IntPtr rlDest, IntPtr rlKernel, Point anchor);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_rl_erode(
        IntPtr rlSrc, IntPtr rlDest, IntPtr rlKernel, int bBoundaryOn, Point anchor);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_rl_getStructuringElement(
        int shape, Size ksize, IntPtr outValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_rl_paint(
        IntPtr image, IntPtr rlSrc, Scalar value);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_rl_isRLMorphologyPossible(
        IntPtr rlStructuringElement, out int outValue);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_rl_createRLEImage(
        Point3i[] runs, nint runsLength, IntPtr res, Size size);

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_rl_morphologyEx(
        IntPtr rlSrc, IntPtr rlDest, int op, IntPtr rlKernel, int bBoundaryOnForErosion, Point anchor);

    // weighted_median_filter

    [LibraryImport(DllExtern)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_weightedMedianFilter(
        IntPtr joint, IntPtr src, IntPtr dst, int r, double sigma, int weightType, IntPtr mask);
}
