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
        OutputArrayProxy kx, OutputArrayProxy ky, int dx, int dy, int ksize, int normalize, MatType ktype);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getGaborKernel(Size ksize, double sigma, double theta, double lambd,
        double gamma, double psi, int ktype, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getStructuringElement(int shape, Size ksize, Point anchor, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_medianBlur(InputArrayProxy src, OutputArrayProxy dst, int ksize);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_GaussianBlur(InputArrayProxy src, OutputArrayProxy dst, Size ksize, double sigmaX,
        double sigmaY, BorderTypes borderType, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_bilateralFilter(InputArrayProxy src, OutputArrayProxy dst, int d, double sigmaColor,
        double sigmaSpace, BorderTypes borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_boxFilter(InputArrayProxy src, OutputArrayProxy dst, MatType ddepth, Size ksize, Point anchor,
        int normalize, BorderTypes borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_sqrBoxFilter(InputArrayProxy src, OutputArrayProxy dst, MatType ddepth, Size ksize, Point anchor,
        int normalize, BorderTypes borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_blur(InputArrayProxy src, OutputArrayProxy dst, Size ksize, Point anchor, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_filter2D(InputArrayProxy src, OutputArrayProxy dst, MatType ddepth, InputArrayProxy kernel, Point anchor,
        double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_filter2Dp(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy kernel,
        int anchorX, int anchorY, int borderType, Scalar borderValue, int ddepth, double scale, double shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_sepFilter2D(InputArrayProxy src, OutputArrayProxy dst, MatType ddepth, InputArrayProxy kernelX,
        InputArrayProxy kernelY, Point anchor, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Sobel(InputArrayProxy src, OutputArrayProxy dst, MatType ddepth,
        int dx, int dy, int ksize, double scale, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_spatialGradient(
        InputArrayProxy src, OutputArrayProxy dx, OutputArrayProxy dy, int ksize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Scharr(InputArrayProxy src, OutputArrayProxy dst, MatType ddepth,
        int dx, int dy, double scale, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Laplacian(InputArrayProxy src, OutputArrayProxy dst, MatType ddepth,
        int ksize, double scale, double delta, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Canny1(
        InputArrayProxy src, OutputArrayProxy edges, double threshold1, double threshold2, int apertureSize, int l2Gradient);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_Canny2(
        InputArrayProxy dx, InputArrayProxy dy, OutputArrayProxy edges, double threshold1, double threshold2, int l2Gradient);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cornerMinEigenVal(InputArrayProxy src, OutputArrayProxy dst, int blockSize, int ksize,
        int borderType);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cornerHarris(InputArrayProxy src, OutputArrayProxy dst, int blockSize, int ksize,
        double  k, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cornerEigenValsAndVecs(InputArrayProxy src, OutputArrayProxy dst, int blockSize, int ksize,
        int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_preCornerDetect(InputArrayProxy src, OutputArrayProxy dst, int ksize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cornerSubPix(InputArrayProxy image, IntPtr corners,
        Size winSize, Size zeroZone, TermCriteria criteria);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_goodFeaturesToTrack(InputArrayProxy src, IntPtr corners,
        int maxCorners, double qualityLevel, double minDistance, InputArrayProxy mask, int blockSize, int useHarrisDetector,
        double k);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_HoughLines(InputArrayProxy src, IntPtr lines,
        double rho, double theta, int threshold, double srn, double stn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_HoughLinesP(InputArrayProxy src, IntPtr lines,
        double rho, double theta, int threshold, double minLineLength, double maxLineG);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_HoughLinesPointSet(
        InputArrayProxy point, OutputArrayProxy lines, int linesMax, int threshold,
        double minRho, double maxRho, double rhoStep,
        double minTheta, double maxTheta, double thetaStep);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_HoughCircles(InputArrayProxy src, IntPtr circles,
        int method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_erode(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy kernel, Point anchor, int iterations,
        int borderType, Scalar borderValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_dilate(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy kernel, Point anchor, int iterations,
        int borderType, Scalar borderValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_morphologyEx(InputArrayProxy src, OutputArrayProxy dst, int op, InputArrayProxy kernel, Point anchor,
        int iterations, int borderType, Scalar borderValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_resize(InputArrayProxy src, OutputArrayProxy dst, Size dsize, double fx, double fy,
        int interpolation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_warpAffine(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy m, Size dsize, int flags,
        int borderMode, Scalar borderValue, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_warpPerspective_MisInputArray(
        InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy m, Size dsize, int flags, int borderMode, Scalar borderValue, int hint);

    // The 3x3 matrix is a contiguous, blittable float[,]; pass it as a (pinned) ReadOnlySpan with the
    // dimensions kept as separate ints, so source-generated marshalling can handle it (native takes float*).
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_warpPerspective_MisArray(
        InputArrayProxy src, OutputArrayProxy dst, ReadOnlySpan<float> m, int mRow, int mCol,
        Size dsize, int flags, int borderMode, Scalar borderValue, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_remap(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy map1, InputArrayProxy map2, int interpolation,
        int borderMode, Scalar borderValue, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_convertMaps(InputArrayProxy map1, InputArrayProxy map2, OutputArrayProxy dstmap1, OutputArrayProxy dstmap2,
        MatType dstmap1Type, int nninterpolation);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getRotationMatrix2D(Point2f center, double angle, double scale, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_invertAffineTransform(InputArrayProxy m, OutputArrayProxy im);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getPerspectiveTransform1(Point2f[] src, Point2f[] dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_getPerspectiveTransform2(InputArrayProxy src, InputArrayProxy dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_getAffineTransform1(Point2f[] src, Point2f[] dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_getAffineTransform2(InputArrayProxy src, InputArrayProxy dst, out IntPtr returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_getRectSubPix(InputArrayProxy image, Size patchSize, Point2f center, OutputArrayProxy patch,
        int patchType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_warpPolar(
        InputArrayProxy src, OutputArrayProxy dst, Size dsize, Point2f center, double maxRadius, int flags);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_integral1(InputArrayProxy src, OutputArrayProxy sum, int sdepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_integral2(InputArrayProxy src, OutputArrayProxy sum, OutputArrayProxy sqsum, int sdepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_integral3(InputArrayProxy src, OutputArrayProxy sum, OutputArrayProxy sqsum, OutputArrayProxy tilted, int sdepth, int sqdepth);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_accumulate(InputArrayProxy src, InputOutputArrayProxy dst, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_accumulateSquare(InputArrayProxy src, InputOutputArrayProxy dst, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_accumulateProduct(InputArrayProxy src1, InputArrayProxy src2, InputOutputArrayProxy dst, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_accumulateWeighted(InputArrayProxy src, InputOutputArrayProxy dst, double alpha, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_phaseCorrelate(InputArrayProxy src1, InputArrayProxy src2, InputArrayProxy window, 
        out double response, out Point2d returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_createHanningWindow(OutputArrayProxy dst, Size winSize, MatType type);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_threshold(InputArrayProxy src, OutputArrayProxy dst, double thresh, double maxval, int type, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_adaptiveThreshold(InputArrayProxy src, OutputArrayProxy dst,
        double maxValue, int adaptiveMethod, int thresholdType, int blockSize, double c);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_pyrDown(InputArrayProxy src, OutputArrayProxy dst, Size dstsize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_buildPyramid(InputArrayProxy src, IntPtr dst, int maxlevel, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_pyrUp(InputArrayProxy src, OutputArrayProxy dst, Size dstsize, int borderType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_calcHist(IntPtr[] images, int nimages,
        int[] channels, InputArrayProxy mask, OutputArrayProxy hist, int dims, int[] histSize,
        IntPtr[] ranges, int uniform, int accumulate);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_calcBackProject(IntPtr[] images, int nimages,
        int[] channels, InputArrayProxy hist, OutputArrayProxy backProject, IntPtr[] ranges, int uniform);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_compareHist(InputArrayProxy h1, InputArrayProxy h2, int method, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_equalizeHist(InputArrayProxy src, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_EMD(InputArrayProxy signature1, InputArrayProxy signature2,
        int distType, InputArrayProxy cost, out float lowerBound, OutputArrayProxy flow, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_watershed(InputArrayProxy image, InputOutputArrayProxy markers);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_pyrMeanShiftFiltering(InputArrayProxy src, OutputArrayProxy dst,
        double sp, double sr, int maxLevel, TermCriteria termcrit);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_grabCut(InputArrayProxy img, InputOutputArrayProxy mask, Rect rect,
        InputOutputArrayProxy bgdModel, InputOutputArrayProxy fgdModel,
        int iterCount, int mode);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_distanceTransformWithLabels(InputArrayProxy src, OutputArrayProxy dst, OutputArrayProxy labels,
        int distanceType, int maskSize, int labelType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_distanceTransform(InputArrayProxy src, OutputArrayProxy dst,
        int distanceType, int maskSize, int dstType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_floodFill1(InputOutputArrayProxy image,
        Point seedPoint, Scalar newVal, out Rect rect,
        Scalar loDiff, Scalar upDiff, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_floodFill2(InputOutputArrayProxy image, InputOutputArrayProxy mask,
        Point seedPoint, Scalar newVal, out Rect rect,
        Scalar loDiff, Scalar upDiff, int flags, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_blendLinear(
        InputArrayProxy src1, InputArrayProxy src2, InputArrayProxy weights1, InputArrayProxy weights2, OutputArrayProxy dst);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cvtColor(InputArrayProxy src, OutputArrayProxy dst, int code, int dstCn, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_cvtColorTwoPlane(InputArrayProxy src1, InputArrayProxy src2, OutputArrayProxy dst, int code, int hint);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_demosaicing(InputArrayProxy src, OutputArrayProxy dst, int code, int dstCn);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_moments(InputArrayProxy arr, int binaryImage, out Moments.NativeStruct returnValue);

    //[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern ExceptionStatus imgproc_HuMoments(ref Moments.NativeStruct moments, [MarshalAs(UnmanagedType.LPArray)] double[] hu);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_matchTemplate(
        InputArrayProxy image, InputArrayProxy templ, OutputArrayProxy result, int method, InputArrayProxy mask);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_connectedComponentsWithAlgorithm(
        InputArrayProxy image, OutputArrayProxy labels, int connectivity, MatType ltype, int ccltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_connectedComponents(
        InputArrayProxy image, OutputArrayProxy labels, int connectivity, MatType ltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_connectedComponentsWithStatsWithAlgorithm(
        InputArrayProxy image, OutputArrayProxy labels, OutputArrayProxy stats, OutputArrayProxy centroids, int connectivity, MatType ltype, int ccltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_connectedComponentsWithStats(
        InputArrayProxy image, OutputArrayProxy labels, OutputArrayProxy stats, OutputArrayProxy centroids, int connectivity, MatType ltype, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContours1_vector(InputArrayProxy image, IntPtr contours,
        IntPtr hierarchy, int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContours1_OutputArray(InputArrayProxy image, IntPtr contours,
        OutputArrayProxy hierarchy, int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContours2_vector(InputArrayProxy image, IntPtr contours,
        int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContours2_OutputArray(InputArrayProxy image, IntPtr contours,
        int mode, int method, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContoursLinkRuns1(InputArrayProxy image, IntPtr contours, IntPtr hierarchy);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_findContoursLinkRuns2(InputArrayProxy image, IntPtr contours);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_approxPolyDP_InputArray(InputArrayProxy curve, OutputArrayProxy approxCurve,
        double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_approxPolyDP_Point(Point[] curve, int curveLength,
        IntPtr approxCurve, double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_approxPolyDP_Point2f(Point2f[] curve, int curveLength,
        IntPtr approxCurve, double epsilon, int closed);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_arcLength_InputArray(InputArrayProxy curve, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_arcLength_Point(Point[] curve, int curveLength, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_arcLength_Point2f(Point2f[] curve, int curveLength, int closed, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_boundingRect_InputArray(InputArrayProxy curve, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boundingRect_Point(Point[] curve, int curveLength, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boundingRect_Point2f(Point2f[] curve, int curveLength, out Rect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_contourArea_InputArray(InputArrayProxy contour, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_contourArea_Point(
        [MarshalAs(UnmanagedType.LPArray)] Point[] contour, int contourLength, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_contourArea_Point2f(
        [MarshalAs(UnmanagedType.LPArray)] Point2f[] contour, int contourLength, int oriented, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_minAreaRect_InputArray(InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minAreaRect_Point(
        [MarshalAs(UnmanagedType.LPArray)] Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minAreaRect_Point2f(
        [MarshalAs(UnmanagedType.LPArray)] Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_boxPoints_OutputArray(RotatedRect box, OutputArrayProxy points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_boxPoints_Point2f(RotatedRect box, [MarshalAs(UnmanagedType.LPArray), Out] Point2f[] points);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_minEnclosingCircle_InputArray(InputArrayProxy points, out Point2f center,
        out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingCircle_Point(Point[] points, int pointsLength,
        out Point2f center, out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingCircle_Point2f(Point2f[] points, int pointsLength,
        out Point2f center, out float radius);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_minEnclosingTriangle_InputOutputArray(InputArrayProxy points, OutputArrayProxy triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingTriangle_Point(
        [MarshalAs(UnmanagedType.LPArray), In] Point[] points, int pointsLength, IntPtr triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_minEnclosingTriangle_Point2f(
        [MarshalAs(UnmanagedType.LPArray), In] Point2f[] points, int pointsLength, IntPtr triangle, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_matchShapes_InputArray(
        InputArrayProxy contour1, InputArrayProxy contour2, int method, double parameter, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_matchShapes_Point(
        Point[] contour1, int contour1Length, Point[] contour2, int contour2Length, int method, double parameter, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_convexHull_InputArray(InputArrayProxy points, OutputArrayProxy hull,
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
    internal static partial ExceptionStatus imgproc_convexityDefects_InputArray(InputArrayProxy contour, InputArrayProxy convexHull,
        OutputArrayProxy convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexityDefects_Point(Point[] contour, int contourLength, int[] convexHull,
        int convexHullLength, IntPtr convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_convexityDefects_Point2f(Point2f[] contour, int contourLength,
        int[] convexHull, int convexHullLength, IntPtr convexityDefects);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_isContourConvex_InputArray(InputArrayProxy contour, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_isContourConvex_Point(Point[] contour, int contourLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_isContourConvex_Point2f(Point2f[] contour, int contourLength, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_intersectConvexConvex_InputArray(InputArrayProxy p1, InputArrayProxy p2,
        OutputArrayProxy p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_intersectConvexConvex_Point(Point[] p1, int p1Length, Point[] p2,
        int p2Length, IntPtr p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_intersectConvexConvex_Point2f(Point2f[] p1, int p1Length, Point2f[] p2,
        int p2Length, IntPtr p12, int handleNested, out float returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fitEllipse_InputArray(InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipse_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipse_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    // Not exported
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fitEllipseAMS_InputArray(InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseAMS_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseAMS_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    // Not exported
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fitEllipseDirect_InputArray(InputArrayProxy points, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseDirect_Point(Point[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fitEllipseDirect_Point2f(Point2f[] points, int pointsLength, out RotatedRect returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fitLine_InputArray(InputArrayProxy points, OutputArrayProxy line,
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
        InputArrayProxy contour, Point2f pt, int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_pointPolygonTest_Point(Point[] contour, int contourLength, Point2f pt,
        int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_pointPolygonTest_Point2f(Point2f[] contour, int contourLength,
        Point2f pt, int measureDist, out double returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_rotatedRectangleIntersection_OutputArray(
        RotatedRect rect1, RotatedRect rect2, OutputArrayProxy intersectingRegion, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rotatedRectangleIntersection_vector(
        RotatedRect rect1, RotatedRect rect2, IntPtr intersectingRegion, out int returnValue);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_applyColorMap1(InputArrayProxy src, OutputArrayProxy dst, int colormap);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_applyColorMap2(InputArrayProxy src, OutputArrayProxy dst, InputArrayProxy userColor);

    #region Drawing

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_line(
        InputOutputArrayProxy img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_arrowedLine(
        InputOutputArrayProxy img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift, double tipLength);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_rectangle_InputOutputArray_Point(
        InputOutputArrayProxy img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_rectangle_InputOutputArray_Rect(
        InputOutputArrayProxy img, Rect rect, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rectangle_Mat_Point(
        IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_rectangle_Mat_Rect(
        IntPtr img, Rect rect, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_circle(InputOutputArrayProxy img, Point center, int radius, Scalar color, int thickness,
        int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_ellipse1(
        InputOutputArrayProxy img, Point center, Size axes,
        double angle, double startAngle, double endAngle, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_ellipse2(
        InputOutputArrayProxy img, RotatedRect box, Scalar color, int thickness, int lineType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_drawMarker(
        InputOutputArrayProxy img, Point position, Scalar color, int markerType, int markerSize, int thickness, int lineType);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fillConvexPoly_Mat(
        IntPtr img, Point[] pts, int npts, Scalar color, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fillConvexPoly_InputOutputArray(
        InputOutputArrayProxy img, InputArrayProxy points, Scalar color, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_fillPoly_Mat(
        IntPtr img, IntPtr[] pts, int[] npts, int ncontours,
        Scalar color, int lineType, int shift, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_fillPoly_InputOutputArray(
        InputOutputArrayProxy img, InputArrayProxy pts, Scalar color, int lineType, int shift, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ExceptionStatus imgproc_polylines_Mat(
        IntPtr img, IntPtr[] pts, int[] npts,
        int ncontours, int isClosed, Scalar color, int thickness, int lineType, int shift);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_polylines_InputOutputArray(
        InputOutputArrayProxy img, InputArrayProxy pts, int isClosed, Scalar color, int thickness, int lineType, int shift);
        
    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_drawContours_vector(InputOutputArrayProxy image,
        IntPtr[] contours, int contoursSize1, int[] contoursSize2,
        int contourIdx, Scalar color, int thickness, int lineType,
        Vec4i[] hierarchy, int hiearchyLength, int maxLevel, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_drawContours_vector(InputOutputArrayProxy image,
        IntPtr[] contours, int contoursSize1, int[] contoursSize2,
        int contourIdx, Scalar color, int thickness, int lineType,
        IntPtr hierarchy, int hiearchyLength, int maxLevel, Point offset);

    [LibraryImport(DllExtern), UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    internal static partial ExceptionStatus imgproc_drawContours_InputArray(InputOutputArrayProxy image,
        IntPtr[] contours, int contoursLength,
        int contourIdx, Scalar color, int thickness, int lineType,
        InputArrayProxy hierarchy, int maxLevel, Point offset);

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
    internal static partial ExceptionStatus imgproc_putText(InputOutputArrayProxy img, [MarshalAs(UnmanagedType.LPStr)] string text, Point org,
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
