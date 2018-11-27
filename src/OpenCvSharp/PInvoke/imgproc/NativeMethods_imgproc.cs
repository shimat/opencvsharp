using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_getGaussianKernel(
            int ksize, double sigma, int ktype);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_getDerivKernels(
            IntPtr kx, IntPtr ky,int dx, int dy, int ksize, int normalize, int ktype);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_getGaborKernel(Size ksize, double sigma, double theta, double lambd, double gamma, double psi, int ktype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_getStructuringElement(int shape, Size ksize, Point anchor);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_medianBlur(IntPtr src, IntPtr dst, int ksize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_GaussianBlur(IntPtr src, IntPtr dst, Size ksize, double sigmaX,
                                                       double sigmaY, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_bilateralFilter(IntPtr src, IntPtr dst, int d, double sigmaColor,
                                                          double sigmaSpace, int borderType);
        
        /*
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_adaptiveBilateralFilter(IntPtr src, IntPtr dst, Size ksize,
            double sigmaSpace, double maxSigmaColor, CvPoint anchor, int borderType);
        */

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_boxFilter(IntPtr src, IntPtr dst, int ddepth, Size ksize, Point anchor,
                                                    int normalize, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_blur(IntPtr src, IntPtr dst, Size ksize, Point anchor, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_filter2D(IntPtr src, IntPtr dst, int ddepth, IntPtr kernel, Point anchor, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_sepFilter2D(IntPtr src, IntPtr dst, int ddepth, IntPtr kernelX, IntPtr kernelY, Point anchor, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_Sobel(IntPtr src, IntPtr dst, int ddepth,
            int dx, int dy, int ksize, double scale, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_Scharr(IntPtr src, IntPtr dst, int ddepth,
            int dx, int dy, double scale, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_Laplacian(IntPtr src, IntPtr dst, int ddepth,
            int ksize, double scale, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_Canny(IntPtr src, IntPtr edges,
            double threshold1, double threshold2, int apertureSize, int L2gradient);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_cornerEigenValsAndVecs(IntPtr src, IntPtr dst,int blockSize, int ksize, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_preCornerDetect(IntPtr src, IntPtr dst, int ksize, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_cornerSubPix(IntPtr image, IntPtr corners,
            Size winSize, Size zeroZone, TermCriteria criteria);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_goodFeaturesToTrack(IntPtr src, IntPtr corners,
            int maxCorners, double qualityLevel, double minDistance, IntPtr mask, int blockSize, int useHarrisDetector, double k);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_HoughLines(IntPtr src, IntPtr lines,
            double rho, double theta, int threshold, double srn, double stn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_HoughLinesP(IntPtr src, IntPtr lines,
            double rho, double theta, int threshold, double minLineLength, double maxLineG);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_HoughCircles(IntPtr src, IntPtr circles,
            int method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_erode(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations, int borderType, Scalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_dilate(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations, int borderType, Scalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_morphologyEx(IntPtr src, IntPtr dst, int op, IntPtr kernel, Point anchor, int iterations, int borderType, Scalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_resize(IntPtr src, IntPtr dst, Size dsize, double fx, double fy, int interpolation);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_warpAffine(IntPtr src, IntPtr dst, IntPtr m, Size dsize, int flags, int borderMode, Scalar borderValue);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_warpPerspective_MisInputArray(
            IntPtr src, IntPtr dst, IntPtr m, Size dsize, int flags, int borderMode, Scalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_warpPerspective_MisArray(
            IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.LPArray)] float[,] m, int mRow, int mCol, 
            Size dsize, int flags, int borderMode, Scalar borderValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_remap(IntPtr src, IntPtr dst, IntPtr map1, IntPtr map2, int interpolation, int borderMode, Scalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_convertMaps(IntPtr map1, IntPtr map2, IntPtr dstmap1, IntPtr dstmap2, int dstmap1Type, int nninterpolation);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_getRotationMatrix2D(Point2f center, double angle, double scale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_invertAffineTransform(IntPtr m, IntPtr im);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_getPerspectiveTransform1(Point2f[] src, Point2f[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_getPerspectiveTransform2(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_getAffineTransform1(Point2f[] src, Point2f[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr imgproc_getAffineTransform2(IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_getRectSubPix(IntPtr image, Size patchSize, Point2f center, IntPtr patch, int patchType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_logPolar(
            IntPtr src, IntPtr dst, Point2f center, double m, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_linearPolar(
            IntPtr src, IntPtr dst, Point2f center, double maxRadius, int flags);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_integral1(IntPtr src, IntPtr sum, int sdepth);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_integral2(IntPtr src, IntPtr sum, IntPtr sqsum, int sdepth);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_integral3(IntPtr src, IntPtr sum, IntPtr sqsum, IntPtr tilted, int sdepth);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_accumulate(IntPtr src, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_accumulateSquare(IntPtr src, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_accumulateProduct(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_accumulateWeighted(IntPtr src, IntPtr dst, double alpha, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_PSNR(IntPtr src1, IntPtr src2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Point2d imgproc_phaseCorrelate(IntPtr src1, IntPtr src2, IntPtr window);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Point2d imgproc_phaseCorrelateRes(IntPtr src1, IntPtr src2, IntPtr window, out double response);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_createHanningWindow(IntPtr dst, Size winSize, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_threshold(IntPtr src, IntPtr dst, double thresh, double maxval, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_adaptiveThreshold(IntPtr src, IntPtr dst,
            double maxValue, int adaptiveMethod, int thresholdType, int blockSize, double c);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_pyrDown(IntPtr src, IntPtr dst, Size dstsize, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_pyrUp(IntPtr src, IntPtr dst, Size dstsize, int borderType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_calcHist1(IntPtr[] images, int nimages,
            int[] channels, IntPtr mask, IntPtr hist, int dims, int[] histSize,
            IntPtr[] ranges, int uniform, int accumulate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_calcBackProject(IntPtr[] images, int nimages,
                                                          int[] channels, IntPtr hist, IntPtr backProject,
                                                          IntPtr[] ranges, int uniform);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_compareHist1(IntPtr h1, IntPtr h2, int method);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_equalizeHist(IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float imgproc_EMD(IntPtr signature1, IntPtr signature2,
            int distType, IntPtr cost, out float lowerBound, IntPtr flow);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_watershed(IntPtr image, IntPtr markers);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_pyrMeanShiftFiltering(IntPtr src, IntPtr dst,
            double sp, double sr, int maxLevel, TermCriteria termcrit);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_grabCut(IntPtr img, IntPtr mask, Rect rect,
                                                  IntPtr bgdModel, IntPtr fgdModel,
                                                  int iterCount, int mode);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_distanceTransformWithLabels(IntPtr src, IntPtr dst, IntPtr labels,
                                                              int distanceType, int maskSize, int labelType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_distanceTransform(IntPtr src, IntPtr dst,
                                                    int distanceType, int maskSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_floodFill1(IntPtr image,
                                                    Point seedPoint, Scalar newVal, out Rect rect,
                                                    Scalar loDiff, Scalar upDiff, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_floodFill2(IntPtr image, IntPtr mask,
                                                    Point seedPoint, Scalar newVal, out Rect rect,
                                                    Scalar loDiff, Scalar upDiff, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_cvtColor(IntPtr src, IntPtr dst, int code, int dstCn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Moments.NativeStruct imgproc_moments(IntPtr arr, int binaryImage);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_matchTemplate(
            IntPtr image, IntPtr templ, IntPtr result, int method, IntPtr mask);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_connectedComponents(
            IntPtr image, IntPtr labels, int connectivity, int ltype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_connectedComponentsWithStats(
            IntPtr image, IntPtr labels, IntPtr stats, IntPtr centroids, int connectivity, int ltype);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_findContours1_vector(IntPtr image, out IntPtr contours,
            out IntPtr hierarchy, int mode, int method, Point offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_findContours1_OutputArray(IntPtr image, out IntPtr contours,
            IntPtr hierarchy, int mode, int method, Point offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_findContours2_vector(IntPtr image, out IntPtr contours,
            int mode, int method, Point offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_findContours2_OutputArray(IntPtr image, out IntPtr contours,
            int mode, int method, Point offset);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_drawContours_vector(IntPtr image,
            IntPtr[] contours, int contoursSize1, int[] contoursSize2,
            int contourIdx, Scalar color, int thickness, int lineType,
            Vec4i[] hierarchy, int hiearchyLength, int maxLevel, Point offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_drawContours_vector(IntPtr image,
            IntPtr[] contours, int contoursSize1, int[] contoursSize2,
            int contourIdx, Scalar color, int thickness, int lineType,
            IntPtr hierarchy, int hiearchyLength, int maxLevel, Point offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_drawContours_InputArray(IntPtr image,
            IntPtr[] contours, int contoursLength,
            int contourIdx, Scalar color, int thickness, int lineType,
            IntPtr hierarchy, int maxLevel, Point offset);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_approxPolyDP_InputArray(IntPtr curve, IntPtr approxCurve,
                                                                  double epsilon, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_approxPolyDP_Point(Point[] curve, int curveLength,
            out IntPtr approxCurve, double epsilon, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_approxPolyDP_Point2f(Point2f[] curve, int curveLength,
            out IntPtr approxCurve, double epsilon, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_arcLength_InputArray(IntPtr curve, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_arcLength_Point(Point[] curve, int curveLength, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_arcLength_Point2f(Point2f[] curve, int curveLength, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Rect imgproc_boundingRect_InputArray(IntPtr curve);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Rect imgproc_boundingRect_Point(Point[] curve, int curveLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Rect imgproc_boundingRect_Point2f(Point2f[] curve, int curveLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_contourArea_InputArray(IntPtr contour, int oriented);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_contourArea_Point(Point[] contour, int contourLength, int oriented);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_contourArea_Point2f(Point2f[] contour, int contourLength, int oriented);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern RotatedRect imgproc_minAreaRect_InputArray(IntPtr points);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern RotatedRect imgproc_minAreaRect_Point(Point[] points, int pointsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern RotatedRect imgproc_minAreaRect_Point2f(Point2f[] points, int pointsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_minEnclosingCircle_InputArray(IntPtr points, out Point2f center, out float radius);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_minEnclosingCircle_Point(Point[] points, int pointsLength,
            out Point2f center, out float radius);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_minEnclosingCircle_Point2f(Point2f[] points, int pointsLength,
            out Point2f center, out float radius);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_matchShapes_InputArray(IntPtr contour1, IntPtr contour2,
            int method, double parameter);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_matchShapes_Point(Point[] contour1, int contour1Length,
            Point[] contour2, int contour2Length, int method, double parameter);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_convexHull_InputArray(IntPtr points, IntPtr hull,
                                                                int clockwise, int returnPoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_convexHull_Point_ReturnsPoints(Point[] points, int pointsLength,
            out IntPtr hull, int clockwise);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_convexHull_Point2f_ReturnsPoints(Point2f[] points, int pointsLength,
            out IntPtr hull, int clockwise);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_convexHull_Point_ReturnsIndices(Point[] points, int pointsLength,
            out IntPtr hull, int clockwise);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_convexHull_Point2f_ReturnsIndices(Point2f[] points, int pointsLength,
            out IntPtr hull, int clockwise);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_convexityDefects_InputArray(IntPtr contour, IntPtr convexHull,
                                                                      IntPtr convexityDefects);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_convexityDefects_Point(Point[] contour, int contourLength, int[] convexHull,
            int convexHullLength, out IntPtr convexityDefects);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_convexityDefects_Point2f(Point2f[] contour, int contourLength,
            int[] convexHull, int convexHullLength, out IntPtr convexityDefects);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_isContourConvex_InputArray(IntPtr contour);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_isContourConvex_Point(Point[] contour, int contourLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_isContourConvex_Point2f(Point2f[] contour, int contourLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float imgproc_intersectConvexConvex_InputArray(IntPtr p1, IntPtr p2,
                                                                            IntPtr p12, int handleNested);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float imgproc_intersectConvexConvex_Point(Point[] p1, int p1Length, Point[] p2,
            int p2Length,out IntPtr p12, int handleNested);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float imgproc_intersectConvexConvex_Point2f(Point2f[] p1, int p1Length, Point2f[] p2,
            int p2Length,out IntPtr p12, int handleNested);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern RotatedRect imgproc_fitEllipse_InputArray(IntPtr points);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern RotatedRect imgproc_fitEllipse_Point(Point[] points, int pointsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern RotatedRect imgproc_fitEllipse_Point2f(Point2f[] points, int pointsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_fitLine_InputArray(IntPtr points, IntPtr line,
                                                             int distType, double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_fitLine_Point(Point[] points, int pointsLength, [In, Out] float[] line, int distType,
            double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_fitLine_Point2f(Point2f[] points, int pointsLength, [In, Out] float[] line,
            int distType,double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_fitLine_Point3i(Point3i[] points, int pointsLength, [In, Out] float[] line,
            int distType,double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_fitLine_Point3f(Point3f[] points, int pointsLength, [In, Out] float[] line,
            int distType,double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_pointPolygonTest_InputArray(IntPtr contour, Point2f pt, int measureDist);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_pointPolygonTest_Point(Point[] contour, int contourLength, Point2f pt,
            int measureDist);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern double imgproc_pointPolygonTest_Point2f(Point2f[] contour, int contourLength,
            Point2f pt, int measureDist);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_rotatedRectangleIntersection_OutputArray(
            RotatedRect rect1, RotatedRect rect2, IntPtr intersectingRegion);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_rotatedRectangleIntersection_vector(
            RotatedRect rect1, RotatedRect rect2, IntPtr intersectingRegion);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_applyColorMap(IntPtr src, IntPtr dst, int colormap);


        #region Drawing

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_line(
            IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_arrowedLine(
            IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift, double tipLength);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_rectangle_InputOutputArray(
            IntPtr img, Point pt1, Point pt2, Scalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_rectangle_Mat(
            IntPtr img, Rect rect, Scalar color, int thickness, int lineType, int shift);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_circle(IntPtr img, Point center, int radius, Scalar color, int thickness, int lineType, int shift);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_ellipse1(IntPtr img, Point center, Size axes,
            double angle, double startAngle, double endAngle, Scalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_ellipse2(IntPtr img, RotatedRect box, Scalar color, int thickness, int lineType);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_fillConvexPoly_Mat(
            IntPtr img, Point[] pts, int npts, Scalar color, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_fillConvexPoly_InputOutputArray(
            IntPtr img, IntPtr points, Scalar color, int lineType, int shift);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_fillPoly_Mat(
            IntPtr img, IntPtr[] pts, int[] npts, int ncontours,
            Scalar color, int lineType, int shift, Point offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_fillPoly_InputOutputArray(
            IntPtr img, IntPtr pts, Scalar color, int lineType, int shift, Point offset);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_polylines_Mat(
            IntPtr img, IntPtr[] pts, int[] npts,
            int ncontours, int isClosed, Scalar color, int thickness, int lineType, int shift);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_polylines_InputOutputArray(
            IntPtr img, IntPtr pts, int isClosed, Scalar color, int thickness, int lineType, int shift);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_clipLine1(Size imgSize, ref Point pt1, ref Point pt2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int imgproc_clipLine2(Rect imgRect, ref Point pt1, ref Point pt2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void imgproc_ellipse2Poly(
            Point center, Size axes, int angle, int arcStart, int arcEnd, int delta, IntPtr pts);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern void core_putText(IntPtr img, [MarshalAs(UnmanagedType.LPStr)] string text, Point org,
            int fontFace, double fontScale, Scalar color,
            int thickness, int lineType, int bottomLeftOrigin);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        public static extern Size core_getTextSize([MarshalAs(UnmanagedType.LPStr)] string text, int fontFace,
            double fontScale, int thickness, out int baseLine);

        #endregion
    }
}