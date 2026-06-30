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
    public static partial ExceptionStatus imgproc_getRotationMatrix2D(Point2f center, double angle, double scale, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_invertAffineTransform(in InputArrayProxy m, in OutputArrayProxy im);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getPerspectiveTransform1(Point2f[] src, Point2f[] dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_getPerspectiveTransform2(in InputArrayProxy src, in InputArrayProxy dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getAffineTransform1(Point2f[] src, Point2f[] dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_getAffineTransform2(in InputArrayProxy src, in InputArrayProxy dst, out IntPtr returnValue);

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
    internal static partial ExceptionStatus imgproc_createHanningWindow(in OutputArrayProxy dst, Size winSize, MatType type);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_threshold(in InputArrayProxy src, in OutputArrayProxy dst, double thresh, double maxval, int type, out double returnValue);

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
    internal static partial ExceptionStatus imgproc_moments(in InputArrayProxy arr, int binaryImage, out Moments.NativeStruct returnValue);

    //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus imgproc_HuMoments(ref Moments.NativeStruct moments, [MarshalAs(UnmanagedType.LPArray)] double[] hu);

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

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_approxPolyDP_InputArray(in InputArrayProxy curve, in OutputArrayProxy approxCurve,
        double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_approxPolyDP_Point(Point[] curve, int curveLength,
        IntPtr approxCurve, double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_approxPolyDP_Point2f(Point2f[] curve, int curveLength,
        IntPtr approxCurve, double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_arcLength_InputArray(in InputArrayProxy curve, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_arcLength_Point(Point[] curve, int curveLength, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_arcLength_Point2f(Point2f[] curve, int curveLength, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_boundingRect_InputArray(in InputArrayProxy curve, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boundingRect_Point(Point[] curve, int curveLength, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boundingRect_Point2f(Point2f[] curve, int curveLength, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_contourArea_InputArray(in InputArrayProxy contour, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_contourArea_Point(
        [MarshalAs(UnmanagedType.LPArray)] Point[] contour, int contourLength, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_contourArea_Point2f(
        [MarshalAs(UnmanagedType.LPArray)] Point2f[] contour, int contourLength, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_minAreaRect_InputArray(in InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minAreaRect_Point(
        [MarshalAs(UnmanagedType.LPArray)] Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minAreaRect_Point2f(
        [MarshalAs(UnmanagedType.LPArray)] Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_boxPoints_OutputArray(RotatedRect box, in OutputArrayProxy points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boxPoints_Point2f(RotatedRect box, [MarshalAs(UnmanagedType.LPArray), Out] Point2f[] points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_minEnclosingCircle_InputArray(in InputArrayProxy points, out Point2f center,
        out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingCircle_Point(Point[] points, int pointsLength,
        out Point2f center, out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingCircle_Point2f(Point2f[] points, int pointsLength,
        out Point2f center, out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_minEnclosingTriangle_InputOutputArray(in InputArrayProxy points, in OutputArrayProxy triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingTriangle_Point(
        [MarshalAs(UnmanagedType.LPArray), In] Point[] points, int pointsLength, IntPtr triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingTriangle_Point2f(
        [MarshalAs(UnmanagedType.LPArray), In] Point2f[] points, int pointsLength, IntPtr triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_matchShapes_InputArray(
        in InputArrayProxy contour1, in InputArrayProxy contour2, int method, double parameter, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_matchShapes_Point(
        Point[] contour1, int contour1Length, Point[] contour2, int contour2Length, int method, double parameter, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_convexHull_InputArray(in InputArrayProxy points, in OutputArrayProxy hull,
        int clockwise, int returnPoints);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexHull_Point_ReturnsPoints(Point[] points, int pointsLength,
        IntPtr hull, int clockwise);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexHull_Point2f_ReturnsPoints(Point2f[] points, int pointsLength,
        IntPtr hull, int clockwise);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexHull_Point_ReturnsIndices(Point[] points, int pointsLength,
        IntPtr hull, int clockwise);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexHull_Point2f_ReturnsIndices(Point2f[] points, int pointsLength,
        IntPtr hull, int clockwise);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_convexityDefects_InputArray(in InputArrayProxy contour, in InputArrayProxy convexHull,
        in OutputArrayProxy convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexityDefects_Point(Point[] contour, int contourLength, int[] convexHull,
        int convexHullLength, IntPtr convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexityDefects_Point2f(Point2f[] contour, int contourLength,
        int[] convexHull, int convexHullLength, IntPtr convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_isContourConvex_InputArray(in InputArrayProxy contour, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_isContourConvex_Point(Point[] contour, int contourLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_isContourConvex_Point2f(Point2f[] contour, int contourLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_intersectConvexConvex_InputArray(in InputArrayProxy p1, in InputArrayProxy p2,
        in OutputArrayProxy p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_intersectConvexConvex_Point(Point[] p1, int p1Length, Point[] p2,
        int p2Length, IntPtr p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_intersectConvexConvex_Point2f(Point2f[] p1, int p1Length, Point2f[] p2,
        int p2Length, IntPtr p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fitEllipse_InputArray(in InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipse_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipse_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    // Not exported
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fitEllipseAMS_InputArray(in InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseAMS_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseAMS_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    // Not exported
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fitEllipseDirect_InputArray(in InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseDirect_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseDirect_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fitLine_InputArray(in InputArrayProxy points, in OutputArrayProxy line,
        int distType, double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitLine_Point(Point[] points, int pointsLength, [In, Out] float[] line,
        int distType,
        double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitLine_Point2f(Point2f[] points, int pointsLength, [In, Out] float[] line,
        int distType, double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitLine_Point3i(Point3i[] points, int pointsLength, [In, Out] float[] line,
        int distType, double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitLine_Point3f(Point3f[] points, int pointsLength, [In, Out] float[] line,
        int distType, double param, double reps, double aeps);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_pointPolygonTest_InputArray(
        in InputArrayProxy contour, Point2f pt, int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_pointPolygonTest_Point(Point[] contour, int contourLength, Point2f pt,
        int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_pointPolygonTest_Point2f(Point2f[] contour, int contourLength,
        Point2f pt, int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_rotatedRectangleIntersection_OutputArray(
        RotatedRect rect1, RotatedRect rect2, in OutputArrayProxy intersectingRegion, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rotatedRectangleIntersection_vector(
        RotatedRect rect1, RotatedRect rect2, IntPtr intersectingRegion, out int returnValue);

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
