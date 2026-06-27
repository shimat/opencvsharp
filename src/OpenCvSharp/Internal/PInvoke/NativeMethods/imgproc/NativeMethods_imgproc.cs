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
    public static partial ExceptionStatus imgproc_getDerivKernels(
        IntPtr kx, IntPtr ky, int dx, int dy, int ksize, int normalize, MatType ktype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getGaborKernel(Size ksize, double sigma, double theta, double lambd,
        double gamma, double psi, int ktype, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getStructuringElement(int shape, Size ksize, Point anchor, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_medianBlur(IntPtr src, IntPtr dst, int ksize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_GaussianBlur(IntPtr src, IntPtr dst, Size ksize, double sigmaX,
        double sigmaY, BorderTypes borderType, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_bilateralFilter(IntPtr src, IntPtr dst, int d, double sigmaColor,
        double sigmaSpace, BorderTypes borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boxFilter(IntPtr src, IntPtr dst, MatType ddepth, Size ksize, Point anchor,
        int normalize, BorderTypes borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_sqrBoxFilter(IntPtr src, IntPtr dst, MatType ddepth, Size ksize, Point anchor,
        int normalize, BorderTypes borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_blur(IntPtr src, IntPtr dst, Size ksize, Point anchor, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_filter2D(IntPtr src, IntPtr dst, MatType ddepth, IntPtr kernel, Point anchor,
        double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_filter2Dp(IntPtr src, IntPtr dst, IntPtr kernel,
        int anchorX, int anchorY, int borderType, Scalar borderValue, int ddepth, double scale, double shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_sepFilter2D(IntPtr src, IntPtr dst, MatType ddepth, IntPtr kernelX,
        IntPtr kernelY, Point anchor, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_Sobel(IntPtr src, IntPtr dst, MatType ddepth,
        int dx, int dy, int ksize, double scale, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_spatialGradient(
        IntPtr src, IntPtr dx, IntPtr dy, int ksize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_Scharr(IntPtr src, IntPtr dst, MatType ddepth,
        int dx, int dy, double scale, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_Laplacian(IntPtr src, IntPtr dst, MatType ddepth,
        int ksize, double scale, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_Canny1(
        IntPtr src, IntPtr edges, double threshold1, double threshold2, int apertureSize, int l2Gradient);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_Canny2(
        IntPtr dx, IntPtr dy, IntPtr edges, double threshold1, double threshold2, int l2Gradient);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_cornerMinEigenVal(IntPtr src, IntPtr dst, int blockSize, int ksize,
        int borderType);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_cornerHarris(IntPtr src, IntPtr dst, int blockSize, int ksize,
        double  k, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_cornerEigenValsAndVecs(IntPtr src, IntPtr dst, int blockSize, int ksize,
        int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_preCornerDetect(IntPtr src, IntPtr dst, int ksize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_cornerSubPix(IntPtr image, IntPtr corners,
        Size winSize, Size zeroZone, TermCriteria criteria);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_goodFeaturesToTrack(IntPtr src, IntPtr corners,
        int maxCorners, double qualityLevel, double minDistance, IntPtr mask, int blockSize, int useHarrisDetector,
        double k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_HoughLines(IntPtr src, IntPtr lines,
        double rho, double theta, int threshold, double srn, double stn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_HoughLinesP(IntPtr src, IntPtr lines,
        double rho, double theta, int threshold, double minLineLength, double maxLineG);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_HoughLinesPointSet(
        IntPtr point, IntPtr lines, int linesMax, int threshold,
        double minRho, double maxRho, double rhoStep,
        double minTheta, double maxTheta, double thetaStep);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_HoughCircles(IntPtr src, IntPtr circles,
        int method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_erode(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations,
        int borderType, Scalar borderValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_dilate(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations,
        int borderType, Scalar borderValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_morphologyEx(IntPtr src, IntPtr dst, int op, IntPtr kernel, Point anchor,
        int iterations, int borderType, Scalar borderValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_resize(IntPtr src, IntPtr dst, Size dsize, double fx, double fy,
        int interpolation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_warpAffine(IntPtr src, IntPtr dst, IntPtr m, Size dsize, int flags,
        int borderMode, Scalar borderValue, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_warpPerspective_MisInputArray(
        IntPtr src, IntPtr dst, IntPtr m, Size dsize, int flags, int borderMode, Scalar borderValue, int hint);

    // The 3x3 matrix is a contiguous, blittable float[,]; pass it as a (pinned) ReadOnlySpan with the
    // dimensions kept as separate ints, so source-generated marshalling can handle it (native takes float*).
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_warpPerspective_MisArray(
        IntPtr src, IntPtr dst, ReadOnlySpan<float> m, int mRow, int mCol,
        Size dsize, int flags, int borderMode, Scalar borderValue, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_remap(IntPtr src, IntPtr dst, IntPtr map1, IntPtr map2, int interpolation,
        int borderMode, Scalar borderValue, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convertMaps(IntPtr map1, IntPtr map2, IntPtr dstmap1, IntPtr dstmap2,
        MatType dstmap1Type, int nninterpolation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getRotationMatrix2D(Point2f center, double angle, double scale, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_invertAffineTransform(IntPtr m, IntPtr im);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getPerspectiveTransform1(Point2f[] src, Point2f[] dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getPerspectiveTransform2(IntPtr src, IntPtr dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getAffineTransform1(Point2f[] src, Point2f[] dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getAffineTransform2(IntPtr src, IntPtr dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getRectSubPix(IntPtr image, Size patchSize, Point2f center, IntPtr patch,
        int patchType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_warpPolar(
        IntPtr src, IntPtr dst, Size dsize, Point2f center, double maxRadius, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_integral1(IntPtr src, IntPtr sum, int sdepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_integral2(IntPtr src, IntPtr sum, IntPtr sqsum, int sdepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_integral3(IntPtr src, IntPtr sum, IntPtr sqsum, IntPtr tilted, int sdepth, int sqdepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_accumulate(IntPtr src, IntPtr dst, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_accumulateSquare(IntPtr src, IntPtr dst, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_accumulateProduct(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_accumulateWeighted(IntPtr src, IntPtr dst, double alpha, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_phaseCorrelate(IntPtr src1, IntPtr src2, IntPtr window, 
        out double response, out Point2d returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_createHanningWindow(IntPtr dst, Size winSize, MatType type);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_threshold(IntPtr src, IntPtr dst, double thresh, double maxval, int type, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_adaptiveThreshold(IntPtr src, IntPtr dst,
        double maxValue, int adaptiveMethod, int thresholdType, int blockSize, double c);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_pyrDown(IntPtr src, IntPtr dst, Size dstsize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_buildPyramid(IntPtr src, IntPtr dst, int maxlevel, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_pyrUp(IntPtr src, IntPtr dst, Size dstsize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_calcHist(IntPtr[] images, int nimages,
        int[] channels, IntPtr mask, IntPtr hist, int dims, int[] histSize,
        IntPtr[] ranges, int uniform, int accumulate);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_calcBackProject(IntPtr[] images, int nimages,
        int[] channels, IntPtr hist, IntPtr backProject, IntPtr[] ranges, int uniform);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_compareHist(IntPtr h1, IntPtr h2, int method, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_equalizeHist(IntPtr src, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_EMD(IntPtr signature1, IntPtr signature2,
        int distType, IntPtr cost, out float lowerBound, IntPtr flow, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_watershed(IntPtr image, IntPtr markers);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_pyrMeanShiftFiltering(IntPtr src, IntPtr dst,
        double sp, double sr, int maxLevel, TermCriteria termcrit);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_grabCut(IntPtr img, IntPtr mask, Rect rect,
        IntPtr bgdModel, IntPtr fgdModel,
        int iterCount, int mode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_distanceTransformWithLabels(IntPtr src, IntPtr dst, IntPtr labels,
        int distanceType, int maskSize, int labelType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_distanceTransform(IntPtr src, IntPtr dst,
        int distanceType, int maskSize, int dstType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_floodFill1(IntPtr image,
        Point seedPoint, Scalar newVal, out Rect rect,
        Scalar loDiff, Scalar upDiff, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_floodFill2(IntPtr image, IntPtr mask,
        Point seedPoint, Scalar newVal, out Rect rect,
        Scalar loDiff, Scalar upDiff, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_blendLinear(
        IntPtr src1, IntPtr src2, IntPtr weights1, IntPtr weights2, IntPtr dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_cvtColor(IntPtr src, IntPtr dst, int code, int dstCn, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_cvtColorTwoPlane(IntPtr src1, IntPtr src2, IntPtr dst, int code, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_demosaicing(IntPtr src, IntPtr dst, int code, int dstCn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_moments(IntPtr arr, int binaryImage, out Moments.NativeStruct returnValue);

    //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus imgproc_HuMoments(ref Moments.NativeStruct moments, [MarshalAs(UnmanagedType.LPArray)] double[] hu);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_matchTemplate(
        IntPtr image, IntPtr templ, IntPtr result, int method, IntPtr mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_connectedComponentsWithAlgorithm(
        IntPtr image, IntPtr labels, int connectivity, MatType ltype, int ccltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_connectedComponents(
        IntPtr image, IntPtr labels, int connectivity, MatType ltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_connectedComponentsWithStatsWithAlgorithm(
        IntPtr image, IntPtr labels, IntPtr stats, IntPtr centroids, int connectivity, MatType ltype, int ccltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_connectedComponentsWithStats(
        IntPtr image, IntPtr labels, IntPtr stats, IntPtr centroids, int connectivity, MatType ltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_findContours1_vector(IntPtr image, IntPtr contours,
        IntPtr hierarchy, int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_findContours1_OutputArray(IntPtr image, IntPtr contours,
        IntPtr hierarchy, int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_findContours2_vector(IntPtr image, IntPtr contours,
        int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_findContours2_OutputArray(IntPtr image, IntPtr contours,
        int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_findContoursLinkRuns1(IntPtr image, IntPtr contours, IntPtr hierarchy);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_findContoursLinkRuns2(IntPtr image, IntPtr contours);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_approxPolyDP_InputArray(IntPtr curve, IntPtr approxCurve,
        double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_approxPolyDP_Point(Point[] curve, int curveLength,
        IntPtr approxCurve, double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_approxPolyDP_Point2f(Point2f[] curve, int curveLength,
        IntPtr approxCurve, double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_arcLength_InputArray(IntPtr curve, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_arcLength_Point(Point[] curve, int curveLength, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_arcLength_Point2f(Point2f[] curve, int curveLength, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boundingRect_InputArray(IntPtr curve, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boundingRect_Point(Point[] curve, int curveLength, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boundingRect_Point2f(Point2f[] curve, int curveLength, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_contourArea_InputArray(IntPtr contour, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_contourArea_Point(
        [MarshalAs(UnmanagedType.LPArray)] Point[] contour, int contourLength, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_contourArea_Point2f(
        [MarshalAs(UnmanagedType.LPArray)] Point2f[] contour, int contourLength, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minAreaRect_InputArray(IntPtr points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minAreaRect_Point(
        [MarshalAs(UnmanagedType.LPArray)] Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minAreaRect_Point2f(
        [MarshalAs(UnmanagedType.LPArray)] Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boxPoints_OutputArray(RotatedRect box, IntPtr points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boxPoints_Point2f(RotatedRect box, [MarshalAs(UnmanagedType.LPArray), Out] Point2f[] points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingCircle_InputArray(IntPtr points, out Point2f center,
        out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingCircle_Point(Point[] points, int pointsLength,
        out Point2f center, out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingCircle_Point2f(Point2f[] points, int pointsLength,
        out Point2f center, out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingTriangle_InputOutputArray(IntPtr points, IntPtr triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingTriangle_Point(
        [MarshalAs(UnmanagedType.LPArray), In] Point[] points, int pointsLength, IntPtr triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingTriangle_Point2f(
        [MarshalAs(UnmanagedType.LPArray), In] Point2f[] points, int pointsLength, IntPtr triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_matchShapes_InputArray(
        IntPtr contour1, IntPtr contour2, int method, double parameter, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_matchShapes_Point(
        Point[] contour1, int contour1Length, Point[] contour2, int contour2Length, int method, double parameter, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexHull_InputArray(IntPtr points, IntPtr hull,
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
    public static partial ExceptionStatus imgproc_convexityDefects_InputArray(IntPtr contour, IntPtr convexHull,
        IntPtr convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexityDefects_Point(Point[] contour, int contourLength, int[] convexHull,
        int convexHullLength, IntPtr convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexityDefects_Point2f(Point2f[] contour, int contourLength,
        int[] convexHull, int convexHullLength, IntPtr convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_isContourConvex_InputArray(IntPtr contour, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_isContourConvex_Point(Point[] contour, int contourLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_isContourConvex_Point2f(Point2f[] contour, int contourLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_intersectConvexConvex_InputArray(IntPtr p1, IntPtr p2,
        IntPtr p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_intersectConvexConvex_Point(Point[] p1, int p1Length, Point[] p2,
        int p2Length, IntPtr p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_intersectConvexConvex_Point2f(Point2f[] p1, int p1Length, Point2f[] p2,
        int p2Length, IntPtr p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipse_InputArray(IntPtr points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipse_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipse_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    // Not exported
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseAMS_InputArray(IntPtr points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseAMS_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseAMS_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    // Not exported
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseDirect_InputArray(IntPtr points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseDirect_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseDirect_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitLine_InputArray(IntPtr points, IntPtr line,
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
    public static partial ExceptionStatus imgproc_pointPolygonTest_InputArray(
        IntPtr contour, Point2f pt, int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_pointPolygonTest_Point(Point[] contour, int contourLength, Point2f pt,
        int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_pointPolygonTest_Point2f(Point2f[] contour, int contourLength,
        Point2f pt, int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rotatedRectangleIntersection_OutputArray(
        RotatedRect rect1, RotatedRect rect2, IntPtr intersectingRegion, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rotatedRectangleIntersection_vector(
        RotatedRect rect1, RotatedRect rect2, IntPtr intersectingRegion, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_applyColorMap1(IntPtr src, IntPtr dst, int colormap);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_applyColorMap2(IntPtr src, IntPtr dst, IntPtr userColor);

    #region Drawing

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_line(
        IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_arrowedLine(
        IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift, double tipLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rectangle_InputOutputArray_Point(
        IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rectangle_InputOutputArray_Rect(
        IntPtr img, Rect rect, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rectangle_Mat_Point(
        IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rectangle_Mat_Rect(
        IntPtr img, Rect rect, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_circle(IntPtr img, Point center, int radius, Scalar color, int thickness,
        int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_ellipse1(
        IntPtr img, Point center, Size axes,
        double angle, double startAngle, double endAngle, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_ellipse2(
        IntPtr img, RotatedRect box, Scalar color, int thickness, int lineType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_drawMarker(
        IntPtr img, Point position, Scalar color, int markerType, int markerSize, int thickness, int lineType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fillConvexPoly_Mat(
        IntPtr img, Point[] pts, int npts, Scalar color, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fillConvexPoly_InputOutputArray(
        IntPtr img, IntPtr points, Scalar color, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fillPoly_Mat(
        IntPtr img, IntPtr[] pts, int[] npts, int ncontours,
        Scalar color, int lineType, int shift, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fillPoly_InputOutputArray(
        IntPtr img, IntPtr pts, Scalar color, int lineType, int shift, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_polylines_Mat(
        IntPtr img, IntPtr[] pts, int[] npts,
        int ncontours, int isClosed, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_polylines_InputOutputArray(
        IntPtr img, IntPtr pts, int isClosed, Scalar color, int thickness, int lineType, int shift);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_drawContours_vector(IntPtr image,
        IntPtr[] contours, int contoursSize1, int[] contoursSize2,
        int contourIdx, Scalar color, int thickness, int lineType,
        Vec4i[] hierarchy, int hiearchyLength, int maxLevel, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_drawContours_vector(IntPtr image,
        IntPtr[] contours, int contoursSize1, int[] contoursSize2,
        int contourIdx, Scalar color, int thickness, int lineType,
        IntPtr hierarchy, int hiearchyLength, int maxLevel, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_drawContours_InputArray(IntPtr image,
        IntPtr[] contours, int contoursLength,
        int contourIdx, Scalar color, int thickness, int lineType,
        IntPtr hierarchy, int maxLevel, Point offset);

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
    public static partial ExceptionStatus imgproc_putText(IntPtr img, [MarshalAs(UnmanagedType.LPStr)] string text, Point org,
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
