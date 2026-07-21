using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable IdentifierTypo

#pragma warning disable 1591
#pragma warning disable CA1401 // P/Invokes should not be visible
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
#pragma warning disable IDE1006 // Naming rules

namespace OpenCvSharp.Internal;

static partial class NativeMethods
{
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getGaussianKernel(
        int ksize, double sigma, MatType ktype, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_getDerivKernels(
        in OutputArrayProxy kx, in OutputArrayProxy ky, int dx, int dy, int ksize, int normalize, MatType ktype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getGaborKernel(Size ksize, double sigma, double theta, double lambd,
        double gamma, double psi, int ktype, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getStructuringElement(int shape, Size ksize, Point anchor, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_medianBlur(in InputArrayProxy src, in OutputArrayProxy dst, int ksize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_GaussianBlur(in InputArrayProxy src, in OutputArrayProxy dst, Size ksize, double sigmaX,
        double sigmaY, BorderTypes borderType, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_bilateralFilter(in InputArrayProxy src, in OutputArrayProxy dst, int d, double sigmaColor,
        double sigmaSpace, BorderTypes borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_boxFilter(in InputArrayProxy src, in OutputArrayProxy dst, MatType ddepth, Size ksize, Point anchor,
        int normalize, BorderTypes borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_sqrBoxFilter(in InputArrayProxy src, in OutputArrayProxy dst, MatType ddepth, Size ksize, Point anchor,
        int normalize, BorderTypes borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_blur(in InputArrayProxy src, in OutputArrayProxy dst, Size ksize, Point anchor, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_stackBlur(in InputArrayProxy src, in OutputArrayProxy dst, Size ksize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_filter2D(in InputArrayProxy src, in OutputArrayProxy dst, MatType ddepth, in InputArrayProxy kernel, Point anchor,
        double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_filter2Dp(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy kernel,
        int anchorX, int anchorY, int borderType, Scalar borderValue, int ddepth, double scale, double shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_sepFilter2D(in InputArrayProxy src, in OutputArrayProxy dst, MatType ddepth, in InputArrayProxy kernelX,
        in InputArrayProxy kernelY, Point anchor, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Sobel(in InputArrayProxy src, in OutputArrayProxy dst, MatType ddepth,
        int dx, int dy, int ksize, double scale, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_spatialGradient(
        in InputArrayProxy src, in OutputArrayProxy dx, in OutputArrayProxy dy, int ksize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Scharr(in InputArrayProxy src, in OutputArrayProxy dst, MatType ddepth,
        int dx, int dy, double scale, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Laplacian(in InputArrayProxy src, in OutputArrayProxy dst, MatType ddepth,
        int ksize, double scale, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Canny1(
        in InputArrayProxy src, in OutputArrayProxy edges, double threshold1, double threshold2, int apertureSize, int l2Gradient);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Canny2(
        in InputArrayProxy dx, in InputArrayProxy dy, in OutputArrayProxy edges, double threshold1, double threshold2, int l2Gradient);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cornerMinEigenVal(in InputArrayProxy src, in OutputArrayProxy dst, int blockSize, int ksize,
        int borderType);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cornerHarris(in InputArrayProxy src, in OutputArrayProxy dst, int blockSize, int ksize,
        double  k, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cornerEigenValsAndVecs(in InputArrayProxy src, in OutputArrayProxy dst, int blockSize, int ksize,
        int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_preCornerDetect(in InputArrayProxy src, in OutputArrayProxy dst, int ksize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cornerSubPix(in InputArrayProxy image, IntPtr corners,
        Size winSize, Size zeroZone, TermCriteria criteria);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_goodFeaturesToTrack(in InputArrayProxy src, IntPtr corners,
        int maxCorners, double qualityLevel, double minDistance, in InputArrayProxy mask, int blockSize, int useHarrisDetector,
        double k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_goodFeaturesToTrack_gradientSize(in InputArrayProxy src, IntPtr corners,
        int maxCorners, double qualityLevel, double minDistance, in InputArrayProxy mask, int blockSize, int gradientSize,
        int useHarrisDetector, double k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_goodFeaturesToTrackWithQuality(in InputArrayProxy src, IntPtr corners,
        int maxCorners, double qualityLevel, double minDistance, in InputArrayProxy mask, in OutputArrayProxy cornersQuality,
        int blockSize, int gradientSize, int useHarrisDetector, double k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_HoughLines(in InputArrayProxy src, IntPtr lines,
        double rho, double theta, int threshold, double srn, double stn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_HoughLinesP(in InputArrayProxy src, IntPtr lines,
        double rho, double theta, int threshold, double minLineLength, double maxLineG);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_HoughLinesPointSet(
        in InputArrayProxy point, in OutputArrayProxy lines, int linesMax, int threshold,
        double minRho, double maxRho, double rhoStep,
        double minTheta, double maxTheta, double thetaStep);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_HoughCircles(in InputArrayProxy src, IntPtr circles,
        int method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_erode(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy kernel, Point anchor, int iterations,
        int borderType, Scalar borderValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_dilate(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy kernel, Point anchor, int iterations,
        int borderType, Scalar borderValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_morphologyEx(in InputArrayProxy src, in OutputArrayProxy dst, int op, in InputArrayProxy kernel, Point anchor,
        int iterations, int borderType, Scalar borderValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_resize(in InputArrayProxy src, in OutputArrayProxy dst, Size dsize, double fx, double fy,
        int interpolation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_warpAffine(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy m, Size dsize, int flags,
        int borderMode, Scalar borderValue, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_warpPerspective_MisInputArray(
        in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy m, Size dsize, int flags, int borderMode, Scalar borderValue, int hint);

    // The 3x3 matrix is a contiguous, blittable float[,]; pass it as a (pinned) ReadOnlySpan with the
    // dimensions kept as separate ints, so source-generated marshalling can handle it (native takes float*).
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_warpPerspective_MisArray(
        in InputArrayProxy src, in OutputArrayProxy dst, ReadOnlySpan<float> m, int mRow, int mCol,
        Size dsize, int flags, int borderMode, Scalar borderValue, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_remap(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy map1, in InputArrayProxy map2, int interpolation,
        int borderMode, Scalar borderValue, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_convertMaps(in InputArrayProxy map1, in InputArrayProxy map2, in OutputArrayProxy dstmap1, in OutputArrayProxy dstmap2,
        MatType dstmap1Type, int nninterpolation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_getRectSubPix(in InputArrayProxy image, Size patchSize, Point2f center, in OutputArrayProxy patch,
        int patchType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_warpPolar(
        in InputArrayProxy src, in OutputArrayProxy dst, Size dsize, Point2f center, double maxRadius, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_integral1(in InputArrayProxy src, in OutputArrayProxy sum, int sdepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_integral2(in InputArrayProxy src, in OutputArrayProxy sum, in OutputArrayProxy sqsum, int sdepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_integral3(in InputArrayProxy src, in OutputArrayProxy sum, in OutputArrayProxy sqsum, in OutputArrayProxy tilted, int sdepth, int sqdepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_accumulate(in InputArrayProxy src, in InputOutputArrayProxy dst, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_accumulateSquare(in InputArrayProxy src, in InputOutputArrayProxy dst, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_accumulateProduct(in InputArrayProxy src1, in InputArrayProxy src2, in InputOutputArrayProxy dst, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_accumulateWeighted(in InputArrayProxy src, in InputOutputArrayProxy dst, double alpha, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_phaseCorrelate(in InputArrayProxy src1, in InputArrayProxy src2, in InputArrayProxy window,
        out double response, out Point2d returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_phaseCorrelateIterative(in InputArrayProxy src1, in InputArrayProxy src2,
        int l2size, int maxIters, out Point2d returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_createHanningWindow(in OutputArrayProxy dst, Size winSize, MatType type);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_threshold(in InputArrayProxy src, in OutputArrayProxy dst, double thresh, double maxval, int type, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_thresholdWithMask(in InputArrayProxy src, in InputOutputArrayProxy dst, in InputArrayProxy mask,
        double thresh, double maxval, int type, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_adaptiveThreshold(in InputArrayProxy src, in OutputArrayProxy dst,
        double maxValue, int adaptiveMethod, int thresholdType, int blockSize, double c);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_pyrDown(in InputArrayProxy src, in OutputArrayProxy dst, Size dstsize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_buildPyramid(in InputArrayProxy src, IntPtr dst, int maxlevel, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_pyrUp(in InputArrayProxy src, in OutputArrayProxy dst, Size dstsize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_calcHist(IntPtr[] images, int nimages,
        int[] channels, in InputArrayProxy mask, in OutputArrayProxy hist, int dims, int[] histSize,
        IntPtr[] ranges, int uniform, int accumulate);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_calcBackProject(IntPtr[] images, int nimages,
        int[] channels, in InputArrayProxy hist, in OutputArrayProxy backProject, IntPtr[] ranges, int uniform);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_compareHist(in InputArrayProxy h1, in InputArrayProxy h2, int method, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_equalizeHist(in InputArrayProxy src, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_EMD(in InputArrayProxy signature1, in InputArrayProxy signature2,
        int distType, in InputArrayProxy cost, out float lowerBound, in OutputArrayProxy flow, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_watershed(in InputArrayProxy image, in InputOutputArrayProxy markers);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_pyrMeanShiftFiltering(in InputArrayProxy src, in OutputArrayProxy dst,
        double sp, double sr, int maxLevel, TermCriteria termcrit);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_grabCut(in InputArrayProxy img, in InputOutputArrayProxy mask, Rect rect,
        in InputOutputArrayProxy bgdModel, in InputOutputArrayProxy fgdModel,
        int iterCount, int mode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_distanceTransformWithLabels(in InputArrayProxy src, in OutputArrayProxy dst, in OutputArrayProxy labels,
        int distanceType, int maskSize, int labelType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_distanceTransform(in InputArrayProxy src, in OutputArrayProxy dst,
        int distanceType, int maskSize, int dstType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_floodFill1(in InputOutputArrayProxy image,
        Point seedPoint, Scalar newVal, out Rect rect,
        Scalar loDiff, Scalar upDiff, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_floodFill2(in InputOutputArrayProxy image, in InputOutputArrayProxy mask,
        Point seedPoint, Scalar newVal, out Rect rect,
        Scalar loDiff, Scalar upDiff, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_blendLinear(
        in InputArrayProxy src1, in InputArrayProxy src2, in InputArrayProxy weights1, in InputArrayProxy weights2, in OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cvtColor(in InputArrayProxy src, in OutputArrayProxy dst, int code, int dstCn, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cvtColorTwoPlane(in InputArrayProxy src1, in InputArrayProxy src2, in OutputArrayProxy dst, int code, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_demosaicing(in InputArrayProxy src, in OutputArrayProxy dst, int code, int dstCn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_matchTemplate(
        in InputArrayProxy image, in InputArrayProxy templ, in OutputArrayProxy result, int method, in InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_connectedComponentsWithAlgorithm(
        in InputArrayProxy image, in OutputArrayProxy labels, int connectivity, MatType ltype, int ccltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_connectedComponents(
        in InputArrayProxy image, in OutputArrayProxy labels, int connectivity, MatType ltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_connectedComponentsWithStatsWithAlgorithm(
        in InputArrayProxy image, in OutputArrayProxy labels, in OutputArrayProxy stats, in OutputArrayProxy centroids, int connectivity, MatType ltype, int ccltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_connectedComponentsWithStats(
        in InputArrayProxy image, in OutputArrayProxy labels, in OutputArrayProxy stats, in OutputArrayProxy centroids, int connectivity, MatType ltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContours1_vector(in InputArrayProxy image, IntPtr contours,
        IntPtr hierarchy, int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContours1_OutputArray(in InputArrayProxy image, IntPtr contours,
        in OutputArrayProxy hierarchy, int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContours2_vector(in InputArrayProxy image, IntPtr contours,
        int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContours2_OutputArray(in InputArrayProxy image, IntPtr contours,
        int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContoursLinkRuns1(in InputArrayProxy image, IntPtr contours, IntPtr hierarchy);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContoursLinkRuns2(in InputArrayProxy image, IntPtr contours);

    // Not exported

    // Not exported

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_applyColorMap1(in InputArrayProxy src, in OutputArrayProxy dst, int colormap);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_applyColorMap2(in InputArrayProxy src, in OutputArrayProxy dst, in InputArrayProxy userColor);

    #region Drawing

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_line(
        in InputOutputArrayProxy img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_arrowedLine(
        in InputOutputArrayProxy img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift, double tipLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_rectangle_InputOutputArray_Point(
        in InputOutputArrayProxy img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_rectangle_InputOutputArray_Rect(
        in InputOutputArrayProxy img, Rect rect, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rectangle_Mat_Point(
        IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rectangle_Mat_Rect(
        IntPtr img, Rect rect, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_circle(in InputOutputArrayProxy img, Point center, int radius, Scalar color, int thickness,
        int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_ellipse1(
        in InputOutputArrayProxy img, Point center, Size axes,
        double angle, double startAngle, double endAngle, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_ellipse2(
        in InputOutputArrayProxy img, RotatedRect box, Scalar color, int thickness, int lineType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_drawMarker(
        in InputOutputArrayProxy img, Point position, Scalar color, int markerType, int markerSize, int thickness, int lineType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fillConvexPoly_Mat(
        IntPtr img, Point[] pts, int npts, Scalar color, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fillConvexPoly_InputOutputArray(
        in InputOutputArrayProxy img, in InputArrayProxy points, Scalar color, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fillPoly_Mat(
        IntPtr img, IntPtr[] pts, int[] npts, int ncontours,
        Scalar color, int lineType, int shift, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fillPoly_InputOutputArray(
        in InputOutputArrayProxy img, in InputArrayProxy pts, Scalar color, int lineType, int shift, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_polylines_Mat(
        IntPtr img, IntPtr[] pts, int[] npts,
        int ncontours, int isClosed, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_polylines_InputOutputArray(
        in InputOutputArrayProxy img, in InputArrayProxy pts, int isClosed, Scalar color, int thickness, int lineType, int shift);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_drawContours_vector(in InputOutputArrayProxy image,
        IntPtr[] contours, int contoursSize1, int[] contoursSize2,
        int contourIdx, Scalar color, int thickness, int lineType,
        Vec4i[] hierarchy, int hiearchyLength, int maxLevel, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_drawContours_vector(in InputOutputArrayProxy image,
        IntPtr[] contours, int contoursSize1, int[] contoursSize2,
        int contourIdx, Scalar color, int thickness, int lineType,
        IntPtr hierarchy, int hiearchyLength, int maxLevel, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_drawContours_InputArray(in InputOutputArrayProxy image,
        IntPtr[] contours, int contoursLength,
        int contourIdx, Scalar color, int thickness, int lineType,
        in InputArrayProxy hierarchy, int maxLevel, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_clipLine1(Size imgSize, ref Point pt1, ref Point pt2, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_clipLine2(Rect imgRect, ref Point pt1, ref Point pt2, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_ellipse2Poly_int(
        Point center, Size axes, int angle, int arcStart, int arcEnd, int delta, IntPtr pts);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_ellipse2Poly_double(
        Point2d center, Size2d axes, int angle, int arcStart, int arcEnd, int delta, IntPtr pts);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_putText(in InputOutputArrayProxy img, [MarshalAs(UnmanagedType.LPStr)] string text, Point org,
        int fontFace, double fontScale, Scalar color,
        int thickness, int lineType, int bottomLeftOrigin);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getTextSize([MarshalAs(UnmanagedType.LPStr)] string text, int fontFace,
        double fontScale, int thickness, out int baseLine, out Size returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getFontScaleFromHeight(
        int fontFace, int pixelHeight, int thickness, out double returnValue);

    #endregion
}
