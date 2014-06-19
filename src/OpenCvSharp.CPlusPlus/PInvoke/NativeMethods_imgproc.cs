using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_getGaborKernel(Size ksize, double sigma, double theta, double lambd, double gamma, double psi, int ktype);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_getStructuringElement(int shape, Size ksize, Point anchor);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_copyMakeBorder(IntPtr src, IntPtr dst, int top, int bottom, int left,
                                                         int right, int borderType, CvScalar value);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_medianBlur(IntPtr src, IntPtr dst, int ksize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_GaussianBlur(IntPtr src, IntPtr dst, CvSize ksize, double sigmaX,
                                                       double sigmaY, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_bilateralFilter(IntPtr src, IntPtr dst, int d, double sigmaColor,
                                                          double sigmaSpace, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_adaptiveBilateralFilter(IntPtr src, IntPtr dst, Size ksize,
            double sigmaSpace, double maxSigmaColor, CvPoint anchor, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_boxFilter(IntPtr src, IntPtr dst, int ddepth, Size ksize, Point anchor,
                                                    int normalize, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_blur(IntPtr src, IntPtr dst, Size ksize, Point anchor, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_filter2D(IntPtr src, IntPtr dst, int ddepth, IntPtr kernel, Point anchor, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_sepFilter2D(IntPtr src, IntPtr dst, int ddepth, IntPtr kernelX, IntPtr kernelY, Point anchor, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Sobel(IntPtr src, IntPtr dst, int ddepth,
            int dx, int dy, int ksize, double scale, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Scharr(IntPtr src, IntPtr dst, int ddepth,
            int dx, int dy, double scale, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Laplacian(IntPtr src, IntPtr dst, int ddepth,
            int ksize, double scale, double delta, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_Canny(IntPtr src, IntPtr edges,
            double threshold1, double threshold2, int apertureSize, int L2gradient);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_eigen2x2([In] float[,] a, [Out] float[,] e, int n);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_cornerEigenValsAndVecs(IntPtr src, IntPtr dst,int blockSize, int ksize, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_preCornerDetect(IntPtr src, IntPtr dst, int ksize, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_cornerSubPix(IntPtr image, IntPtr corners,
            Size winSize, Size zeroZone, CvTermCriteria criteria);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_goodFeaturesToTrack(IntPtr src, IntPtr corners,
            int maxCorners, double qualityLevel, double minDistance, IntPtr mask, int blockSize, int useHarrisDetector, double k);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_HoughLines(IntPtr src, IntPtr lines,
            double rho, double theta, int threshold, double srn, double stn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_HoughLinesP(IntPtr src, IntPtr lines,
            double rho, double theta, int threshold, double minLineLength, double maxLineG);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_HoughCircles(IntPtr src, IntPtr circles,
            int method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_erode(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations, int borderType, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_dilate(IntPtr src, IntPtr dst, IntPtr kernel, Point anchor, int iterations, int borderType, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_morphologyEx(IntPtr src, IntPtr dst, int op, IntPtr kernel, Point anchor, int iterations, int borderType, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_resize(IntPtr src, IntPtr dst, CvSize dsize, double fx, double fy, int interpolation);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_warpAffine(IntPtr src, IntPtr dst, IntPtr m, CvSize dsize, int flags, int borderMode, CvScalar borderValue);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_warpPerspective_MisInputArray(
            IntPtr src, IntPtr dst, IntPtr m, CvSize dsize, int flags, int borderMode, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_warpPerspective_MisArray(
            IntPtr src, IntPtr dst, [MarshalAs(UnmanagedType.LPArray)] float[,] m, int mRow, int mCol, 
            CvSize dsize, int flags, int borderMode, CvScalar borderValue);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_remap(IntPtr src, IntPtr dst, IntPtr map1, IntPtr map2, int interpolation, int borderMode, CvScalar borderValue);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_convertMaps(IntPtr map1, IntPtr map2, IntPtr dstmap1, IntPtr dstmap2, int dstmap1Type, int nninterpolation);
        
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_getRotationMatrix2D(CvPoint2D32f center, double angle, double scale);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_invertAffineTransform(IntPtr M, IntPtr iM);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_getPerspectiveTransform1")]
        public static extern IntPtr imgproc_getPerspectiveTransform(Point2f[] src, Point2f[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_getPerspectiveTransform1")]
        public static extern IntPtr imgproc_getPerspectiveTransform(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_getAffineTransform1")]
        public static extern IntPtr imgproc_getAffineTransform(Point2f[] src, Point2f[] dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_getAffineTransform2")]
        public static extern IntPtr imgproc_getAffineTransform(IntPtr src, IntPtr dst);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_getRectSubPix(IntPtr image, Size patchSize, Point2f center, IntPtr patch, int patchType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_integral1")]
        public static extern void imgproc_integral(IntPtr src, IntPtr sum, int sdepth);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_integral2")]
        public static extern void imgproc_integral(IntPtr src, IntPtr sum, IntPtr sqsum, int sdepth);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_integral3")]
        public static extern void imgproc_integral(IntPtr src, IntPtr sum, IntPtr sqsum, IntPtr tilted, int sdepth);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_accumulate(IntPtr src, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_accumulateSquare(IntPtr src, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_accumulateProduct(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_accumulateWeighted(IntPtr src, IntPtr dst, double alpha, IntPtr mask);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_PSNR(IntPtr src1, IntPtr src2);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvPoint2D64f imgproc_phaseCorrelate(IntPtr src1, IntPtr src2, IntPtr window);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvPoint2D64f imgproc_phaseCorrelateRes(IntPtr src1, IntPtr src2, IntPtr window, out double response);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_createHanningWindow(IntPtr dst, CvSize winSize, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_threshold(IntPtr src, IntPtr dst, double thresh, double maxval, int type);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_adaptiveThreshold(IntPtr src, IntPtr dst,
            double maxValue, int adaptiveMethod, int thresholdType, int blockSize, double c);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_pyrDown(IntPtr src, IntPtr dst, CvSize dstsize, int borderType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_pyrUp(IntPtr src, IntPtr dst, CvSize dstsize, int borderType);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_undistort(IntPtr src, IntPtr dst,
            IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr newCameraMatrix);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_initUndistortRectifyMap(IntPtr cameraMatrix,IntPtr distCoeffs,
            IntPtr r, IntPtr newCameraMatrix, CvSize size, int m1Type, IntPtr map1, IntPtr map2);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float imgproc_initWideAngleProjMap(IntPtr cameraMatrix, IntPtr distCoeffs,
            CvSize imageSize, int destImageWidth, int m1Type, IntPtr map1, IntPtr map2,
            int projType, double alpha);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr imgproc_getDefaultNewCameraMatrix(IntPtr cameraMatrix, CvSize imgSize,
            int centerPrincipalPoint);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_undistortPoints(IntPtr src, IntPtr dst,
            IntPtr cameraMatrix, IntPtr distCoeffs, IntPtr r, IntPtr p);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_calcHist1(IntPtr[] images, int nimages,
            int[] channels, IntPtr mask, IntPtr hist, int dims, int[] histSize,
            IntPtr[] ranges, int uniform, int accumulate);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_calcBackProject(IntPtr[] images, int nimages,
                                                          int[] channels, IntPtr hist, IntPtr backProject,
                                                          IntPtr[] ranges, int uniform);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_compareHist1(IntPtr h1, IntPtr h2, int method);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_equalizeHist(IntPtr src, IntPtr dst);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float imgproc_EMD(IntPtr signature1, IntPtr signature2,
            int distType, IntPtr cost, out float lowerBound, IntPtr flow);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_watershed(IntPtr image, IntPtr markers);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_pyrMeanShiftFiltering(IntPtr src, IntPtr dst,
            double sp, double sr, int maxLevel, CvTermCriteria termcrit);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_grabCut(IntPtr img, IntPtr mask, CvRect rect,
                                                  IntPtr bgdModel, IntPtr fgdModel,
                                                  int iterCount, int mode);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_distanceTransformWithLabels(IntPtr src, IntPtr dst, IntPtr labels,
                                                              int distanceType, int maskSize, int labelType);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_distanceTransform(IntPtr src, IntPtr dst,
                                                    int distanceType, int maskSize);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_floodFill1")]
        public static extern int imgproc_floodFill(IntPtr image,
                                                    CvPoint seedPoint, CvScalar newVal, out CvRect rect,
                                                    CvScalar loDiff, CvScalar upDiff, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, EntryPoint = "imgproc_floodFill2")]
        public static extern int imgproc_floodFill(IntPtr image, IntPtr mask,
                                                    CvPoint seedPoint, CvScalar newVal, out CvRect rect,
                                                    CvScalar loDiff, CvScalar upDiff, int flags);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_cvtColor(IntPtr src, IntPtr dst, int code, int dstCn);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern WCvMoments imgproc_moments(IntPtr arr, int binaryImage);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_matchTemplate(IntPtr image, IntPtr templ, IntPtr result, int method);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_findContours1_vector(IntPtr image, out IntPtr contours,
            out IntPtr hierarchy, int mode, int method, CvPoint offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_findContours1_OutputArray(IntPtr image, out IntPtr contours,
            IntPtr hierarchy, int mode, int method, CvPoint offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_findContours2_vector(IntPtr image, out IntPtr contours,
            int mode, int method, CvPoint offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_findContours2_OutputArray(IntPtr image, out IntPtr contours,
            int mode, int method, CvPoint offset);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_drawContours_vector(IntPtr image,
            IntPtr[] contours, int contoursSize1, int[] contoursSize2,
            int contourIdx, CvScalar color, int thickness, int lineType,
            Vec4i[] hierarchy, int hiearchyLength, int maxLevel, CvPoint offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_drawContours_vector(IntPtr image,
            IntPtr[] contours, int contoursSize1, int[] contoursSize2,
            int contourIdx, CvScalar color, int thickness, int lineType,
            IntPtr hierarchy, int hiearchyLength, int maxLevel, CvPoint offset);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_drawContours_InputArray(IntPtr image,
            IntPtr[] contours, int contoursLength,
            int contourIdx, CvScalar color, int thickness, int lineType,
            IntPtr hierarchy, int maxLevel, CvPoint offset);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_approxPolyDP_InputArray(IntPtr curve, IntPtr approxCurve,
                                                                  double epsilon, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_approxPolyDP_Point(Point[] curve, int curveLength,
            out IntPtr approxCurve, double epsilon, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_approxPolyDP_Point2f(Point2f[] curve, int curveLength,
            out IntPtr approxCurve, double epsilon, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_arcLength_InputArray(IntPtr curve, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_arcLength_Point(Point[] curve, int curveLength, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_arcLength_Point2f(Point2f[] curve, int curveLength, int closed);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect imgproc_boundingRect_InputArray(IntPtr curve);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect imgproc_boundingRect_Point(Point[] curve, int curveLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvRect imgproc_boundingRect_Point2f(Point2f[] curve, int curveLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_contourArea_InputArray(IntPtr contour, int oriented);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_contourArea_Point(Point[] contour, int contourLength, int oriented);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_contourArea_Point2f(Point2f[] contour, int contourLength, int oriented);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D imgproc_minAreaRect_InputArray(IntPtr points);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D imgproc_minAreaRect_Point(Point[] points, int pointsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D imgproc_minAreaRect_Point2f(Point2f[] points, int pointsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_minEnclosingCircle_InputArray(IntPtr points, out Point2f center, out float radius);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_minEnclosingCircle_Point(Point[] points, int pointsLength,
            out Point2f center, out float radius);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_minEnclosingCircle_Point2f(Point2f[] points, int pointsLength,
            out Point2f center, out float radius);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_matchShapes_InputArray(IntPtr contour1, IntPtr contour2,
            int method, double parameter);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_matchShapes_Point(Point[] contour1, int contour1Length,
            Point[] contour2, int contour2Length, int method, double parameter);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_convexHull_InputArray(IntPtr points, IntPtr hull,
                                                                int clockwise, int returnPoints);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_convexHull_Point_ReturnsPoints(Point[] points, int pointsLength,
            out IntPtr hull, int clockwise);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_convexHull_Point2f_ReturnsPoints(Point2f[] points, int pointsLength,
            out IntPtr hull, int clockwise);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_convexHull_Point_ReturnsIndices(Point[] points, int pointsLength,
            out IntPtr hull, int clockwise);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_convexHull_Point2f_ReturnsIndices(Point2f[] points, int pointsLength,
            out IntPtr hull, int clockwise);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_convexityDefects_InputArray(IntPtr contour, IntPtr convexHull,
                                                                      IntPtr convexityDefects);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_convexityDefects_Point(Point[] contour, int contourLength, int[] convexHull,
            int convexHullLength, out IntPtr convexityDefects);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_convexityDefects_Point2f(Point2f[] contour, int contourLength,
            int[] convexHull, int convexHullLength, out IntPtr convexityDefects);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_isContourConvex_InputArray(IntPtr contour);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_isContourConvex_Point(Point[] contour, int contourLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern int imgproc_isContourConvex_Point2f(Point2f[] contour, int contourLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float imgproc_intersectConvexConvex_InputArray(IntPtr p1, IntPtr p2,
                                                                            IntPtr p12, int handleNested);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float imgproc_intersectConvexConvex_Point(Point[] p1, int p1Length, Point[] p2,
            int p2Length,out IntPtr p12, int handleNested);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern float imgproc_intersectConvexConvex_Point2f(Point2f[] p1, int p1Length, Point2f[] p2,
            int p2Length,out IntPtr p12, int handleNested);

        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D imgproc_fitEllipse_InputArray(IntPtr points);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D imgproc_fitEllipse_Point(Point[] points, int pointsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvBox2D imgproc_fitEllipse_Point2f(Point2f[] points, int pointsLength);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_fitLine_InputArray(IntPtr points, IntPtr line,
                                                             int distType, double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_fitLine_Point(Point[] points, int pointsLength, [In, Out] float[] line, int distType,
            double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_fitLine_Point2f(Point2f[] points, int pointsLength, [In, Out] float[] line,
            int distType,double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_fitLine_Point3i(Point3i[] points, int pointsLength, [In, Out] float[] line,
            int distType,double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern void imgproc_fitLine_Point3f(Point3f[] points, int pointsLength, [In, Out] float[] line,
            int distType,double param, double reps, double aeps);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_pointPolygonTest_InputArray(IntPtr contour, Point2f pt, int measureDist);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_pointPolygonTest_Point(Point[] contour, int contourLength, Point2f pt,
            int measureDist);
        [DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl)]
        public static extern double imgproc_pointPolygonTest_Point2f(Point2f[] contour, int contourLength,
            Point2f pt, int measureDist);
    }
}