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
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_niBlackThreshold(
        in InputArrayProxy src, in OutputArrayProxy dst, double maxValue, int type,
        int blockSize, double k, int binarizationMethod, double r);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_thinning(in InputArrayProxy src, in OutputArrayProxy dst, int thinningType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_anisotropicDiffusion(in InputArrayProxy src, in OutputArrayProxy dst, float alpha, float K, int niters);

    // brightedges.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_BrightEdges(
        IntPtr original, IntPtr edgeview, int contrast, int shortRange, int longRange);

    // color_match.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_createQuaternionImage(in InputArrayProxy img, in OutputArrayProxy qimg);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_qconj(in InputArrayProxy qimg, in OutputArrayProxy qcimg);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_qunitary(in InputArrayProxy qimg, in OutputArrayProxy qnimg);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_qmultiply(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_qdft(in InputArrayProxy img, in OutputArrayProxy qimg, int flags, int sideLeft);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_colorMatchTemplate(in InputArrayProxy img, in InputArrayProxy templ, in OutputArrayProxy result);

    // deriche_filter.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_GradientDericheY(in InputArrayProxy op, in OutputArrayProxy dst, double alpha, double omega);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_GradientDericheX(in InputArrayProxy op, in OutputArrayProxy dst, double alpha, double omega);

    // edgepreserving_filter.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_edgePreservingFilter(in InputArrayProxy src, in OutputArrayProxy dst, int d, double threshold);

    // estimated_covariance

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_covarianceEstimation(
        in InputArrayProxy src, in OutputArrayProxy dst, int windowRows, int windowCols);

    // fast_hough_transform

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_FastHoughTransform(
        in InputArrayProxy src, in OutputArrayProxy dst, MatType dstMatDepth, int angleRange, int op, int makeSkew);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_HoughPoint2Line(
        Point houghPoint, in InputArrayProxy srcImgInfo, int angleRange, int makeSkew, int rules, out Vec4i returnValue);

    // find_ellipses.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_findEllipses(
        in InputArrayProxy image, in OutputArrayProxy ellipses, float scoreThreshold, float reliabilityThreshold, float centerDistanceThreshold);

    // paillou_filter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_GradientPaillouY(in InputArrayProxy op, in OutputArrayProxy dst, double alpha, double omega);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_GradientPaillouX(in InputArrayProxy op, in OutputArrayProxy dst, double alpha, double omega);

    // peilin.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static unsafe partial ExceptionStatus ximgproc_PeiLinNormalization_Mat23d(in InputArrayProxy I, double* returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_PeiLinNormalization_OutputArray(in InputArrayProxy I, in OutputArrayProxy T);

    // radon_transform.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_RadonTransform(
        in InputArrayProxy src, in OutputArrayProxy dst, double theta, double startAngle, double endAngle, int crop, int norm);

    // run_length_morphology.hpp

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_rl_threshold(
        in InputArrayProxy src, in OutputArrayProxy rlDest, double thresh, int type);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_rl_dilate(
        in InputArrayProxy rlSrc, in OutputArrayProxy rlDest, in InputArrayProxy rlKernel, Point anchor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_rl_erode(
        in InputArrayProxy rlSrc, in OutputArrayProxy rlDest, in InputArrayProxy rlKernel, int bBoundaryOn, Point anchor);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus ximgproc_rl_getStructuringElement(
        int shape, Size ksize, IntPtr outValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_rl_paint(
        in InputOutputArrayProxy image, in InputArrayProxy rlSrc, Scalar value);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_rl_isRLMorphologyPossible(
        in InputArrayProxy rlStructuringElement, out int outValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_rl_createRLEImage(
        Point3i[] runs, nint runsLength, in OutputArrayProxy res, Size size);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_rl_morphologyEx(
        in InputArrayProxy rlSrc, in OutputArrayProxy rlDest, int op, in InputArrayProxy rlKernel, int bBoundaryOnForErosion, Point anchor);

    // weighted_median_filter

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus ximgproc_weightedMedianFilter(
        in InputArrayProxy joint, in InputArrayProxy src, in OutputArrayProxy dst, int r, double sigma, int weightType, in InputArrayProxy mask);
}
