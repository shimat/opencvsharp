/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_IMGPROC_H_
#define _CPP_IMGPROC_H_

#include "include_opencv.h"

CVAPI(cv::Mat*) imgproc_getGaborKernel(CvSize ksize, double sigma, double theta, 
	double lambd, double gamma, double psi, int ktype)
{
	cv::Mat ret = cv::getGaborKernel(ksize, sigma, theta, lambd, gamma, ktype);
	return new cv::Mat(ret);
}

CVAPI(cv::Mat*) imgproc_getStructuringElement(int shape, CvSize ksize, CvPoint anchor)
{
	cv::Mat ret = cv::getStructuringElement(shape, ksize, anchor);
	return new cv::Mat(ret);
}

CVAPI(void) imgproc_copyMakeBorder(cv::_InputArray *src, cv::_OutputArray *dst, 
	int top, int bottom, int left, int right, int borderType, CvScalar value)
{
	cv::copyMakeBorder(*src, *dst, top, bottom, left, right, borderType, value);
}

CVAPI(void) imgproc_medianBlur(cv::_InputArray *src, cv::_OutputArray *dst, int ksize)
{
	cv::medianBlur(*src, *dst, ksize);
}

CVAPI(void) imgproc_GaussianBlur(cv::_InputArray *src, cv::_OutputArray *dst, 
	CvSize ksize, double sigmaX, double sigmaY, int borderType)
{
	cv::GaussianBlur(*src, *dst, ksize, sigmaX, sigmaY, borderType);
}

CVAPI(void) imgproc_bilateralFilter(cv::_InputArray *src, cv::_OutputArray *dst, 
	int d, double sigmaColor, double sigmaSpace, int borderType)
{
	cv::bilateralFilter(*src, *dst, d, sigmaColor, sigmaSpace, borderType);
}

CVAPI(void) imgproc_adaptiveBilateralFilter(cv::_InputArray *src, cv::_OutputArray *dst, 
	CvSize ksize, double sigmaSpace, double maxSigmaColor, CvPoint anchor, int borderType)
{
	cv::adaptiveBilateralFilter(*src, *dst, ksize, sigmaSpace, maxSigmaColor, anchor, borderType);
}

CVAPI(void) imgproc_boxFilter(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth, 
	CvSize ksize, CvPoint anchor, int normalize, int borderType)
{
	cv::boxFilter(*src, *dst, ddepth, ksize, anchor, normalize != 0, borderType);
}

CVAPI(void) imgproc_blur(cv::_InputArray *src, cv::_OutputArray *dst, CvSize ksize, CvPoint anchor, int borderType)
{
	cv::blur(*src, *dst, ksize, anchor, borderType);
}

CVAPI(void) imgproc_filter2D(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	cv::_InputArray *kernel, CvPoint anchor, double delta, int borderType)
{
	cv::filter2D(*src, *dst, ddepth, *kernel, anchor, delta, borderType);
}

CVAPI(void) imgproc_sepFilter2D(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	cv::_InputArray *kernelX, cv::_InputArray *kernelY,
	CvPoint anchor,	double delta, int borderType)
{
	cv::sepFilter2D(*src, *dst, ddepth, *kernelX, *kernelY, anchor, delta, borderType);
}

CVAPI(void) imgproc_Sobel(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	int dx, int dy, int ksize, double scale, double delta, int borderType)
{
	cv::Sobel(*src, *dst, ddepth, dx, dy, ksize, scale, delta, borderType);
}

CVAPI(void) imgproc_Scharr(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	int dx, int dy, double scale, double delta,	int borderType)
{
	cv::Scharr(*src, *dst, ddepth, dx, dy, scale, delta, borderType);
}

CVAPI(void) imgproc_Laplacian(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	int ksize, double scale, double delta, int borderType)
{
	cv::Laplacian(*src, *dst, ddepth, ksize, scale, delta, borderType);
}

CVAPI(void) imgproc_Canny(cv::_InputArray *src, cv::_OutputArray *edges,
	double threshold1, double threshold2, int apertureSize, int L2gradient)
{
	cv::Canny(*src, *edges, threshold1, threshold2, apertureSize, L2gradient != 0);
}

CVAPI(void) imgproc_cornerMinEigenVal(cv::_InputArray *src, cv::_OutputArray *dst,
	int blockSize, int ksize, int borderType)
{
	cv::cornerMinEigenVal(*src, *dst, blockSize, ksize, borderType);
}

CVAPI(void) imgproc_cornerHarris(cv::_InputArray *src, cv::_OutputArray *dst, 
	int blockSize, int ksize, double k, int borderType)
{
	cv::cornerHarris(*src, *dst, blockSize, ksize, k, borderType);
}

CVAPI(void) imgproc_eigen2x2(const float* a, float* e, int n)
{
	cv::eigen2x2(a, e, n);
}

CVAPI(void) imgproc_cornerEigenValsAndVecs(cv::_InputArray *src, cv::_OutputArray *dst,
	int blockSize, int ksize, int borderType)
{
	cv::cornerEigenValsAndVecs(*src, *dst, blockSize, ksize, borderType);
}

CVAPI(void) imgproc_preCornerDetect(cv::_InputArray *src, cv::_OutputArray *dst, int ksize,	int borderType)
{
	cv::preCornerDetect(*src, *dst, ksize, borderType);
}

CVAPI(void) imgproc_cornerSubPix(cv::_InputArray *image, std::vector<cv::Point2f> *corners,
	CvSize winSize, CvSize zeroZone, CvTermCriteria criteria)
{
	cv::cornerSubPix(*image, *corners, winSize, zeroZone, criteria);
}

CVAPI(void) imgproc_goodFeaturesToTrack(cv::_InputArray *src, std::vector<cv::Point2f> *corners,
	int maxCorners, double qualityLevel, double minDistance,
	cv::_InputArray *mask, int blockSize, int useHarrisDetector, double k)
{
	cv::goodFeaturesToTrack(*src, *corners, maxCorners, qualityLevel, minDistance, entity(mask), blockSize, useHarrisDetector != 0, k);
}

CVAPI(void) imgproc_HoughLines(cv::_InputArray *src, std::vector<cv::Vec2f> *lines,
	double rho, double theta, int threshold,
	double srn, double stn)
{
	cv::HoughLines(*src, *lines, rho, theta, threshold, srn, stn);
}

CVAPI(void) imgproc_HoughLinesP(cv::_InputArray *src, std::vector<cv::Vec4i> *lines,
	double rho, double theta, int threshold,
	double minLineLength, double maxLineGap)
{
	cv::HoughLinesP(*src, *lines, rho, theta, threshold, minLineLength, maxLineGap);
}

CVAPI(void) imgproc_HoughCircles(cv::_InputArray *src, std::vector<cv::Vec3f> *circles,
	int method, double dp, double minDist,
	double param1, double param2, int minRadius, int maxRadius)
{
	cv::HoughCircles(*src, *circles, method, dp, minDist, param1, param2, minRadius, maxRadius);
}


CVAPI(void) imgproc_erode(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *kernel,
	CvPoint anchor, int iterations,	int borderType,	CvScalar borderValue)
{
	cv::erode(*src, *dst, entity(kernel), anchor, iterations, borderType, borderValue);
}
CVAPI(void) imgproc_dilate(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *kernel,
	CvPoint anchor, int iterations, int borderType, CvScalar borderValue)
{
	cv::dilate(*src, *dst, entity(kernel), anchor, iterations, borderType, borderValue);
}
CVAPI(void) imgproc_morphologyEx(cv::_InputArray *src, cv::_OutputArray *dst, int op, cv::_InputArray *kernel,
	CvPoint anchor, int iterations, int borderType, CvScalar borderValue)
{
	cv::morphologyEx(*src, *dst, op, entity(kernel), anchor, iterations, borderType, borderValue);
}

CVAPI(void) imgproc_resize(cv::_InputArray* src, cv::_OutputArray* dst, CvSize dsize, double fx, double fy, int interpolation)
{
	cv::resize(*src, *dst, dsize, fx, fy, interpolation);
}

CVAPI(void) imgproc_warpAffine(cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray* M, CvSize dsize, 
	int flags, int borderMode, CvScalar borderValue)
{
	cv::warpAffine(*src, *dst, *M, dsize, flags, borderMode, borderValue);
}

CVAPI(void) imgproc_warpPerspective(cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray* M, CvSize dsize, 
	int flags, int borderMode, CvScalar borderValue)
{
	cv::warpPerspective(*src, *dst, *M, dsize, flags, borderMode, borderValue);
}

CVAPI(void) imgproc_remap(cv::_InputArray* src, cv::_OutputArray* dst, cv::_InputArray* map1, cv::_InputArray* map2, 
	int interpolation, int borderMode, CvScalar borderValue)
{
	cv::remap(*src, *dst, *map1, *map2, interpolation, borderMode, borderValue);
}

CVAPI(void) imgproc_convertMaps(cv::_InputArray* map1, cv::_InputArray* map2, cv::_OutputArray* dstmap1, cv::_OutputArray* dstmap2, 
	int dstmap1type, int nninterpolation)
{
	cv::convertMaps(*map1, *map2, *dstmap1, *dstmap2, dstmap1type, nninterpolation != 0);
}

CVAPI(cv::Mat*) imgproc_getRotationMatrix2D(CvPoint2D32f center, double angle, double scale)
{
	cv::Mat ret = cv::getRotationMatrix2D(center, angle, scale);
	return new cv::Mat(ret);

}
CVAPI(void) imgproc_invertAffineTransform(cv::_InputArray* M, cv::_OutputArray *iM)
{
	cv::invertAffineTransform(*M, *iM);
}

CVAPI(cv::Mat*) imgproc_getPerspectiveTransform1(cv::Point2f *src, cv::Point2f *dst)
{
	cv::Mat ret = cv::getPerspectiveTransform(src, dst);
	return new cv::Mat(ret);
}
CVAPI(cv::Mat*) imgproc_getPerspectiveTransform2(cv::_InputArray *src, cv::_InputArray *dst)
{
	cv::Mat ret = cv::getPerspectiveTransform(*src, *dst);
	return new cv::Mat(ret);
}

CVAPI(cv::Mat*) imgproc_getAffineTransform1(cv::Point2f *src, cv::Point2f *dst)
{
	cv::Mat ret = cv::getAffineTransform(src, dst);
	return new cv::Mat(ret);
}
CVAPI(cv::Mat*) imgproc_getAffineTransform2(cv::_InputArray *src, cv::_InputArray *dst)
{
	cv::Mat ret = cv::getAffineTransform(*src, *dst);
	return new cv::Mat(ret);
}

CVAPI(void) imgproc_getRectSubPix(cv::_InputArray *image, CvSize patchSize, CvPoint2D32f center, cv::_OutputArray *patch, int patchType)
{
	cv::getRectSubPix(*image, patchSize, center, *patch, patchType);
}

CVAPI(void) imgproc_integral1(cv::_InputArray *src, cv::_OutputArray *sum, int sdepth)
{
	cv::integral(*src, *sum, sdepth);
}
CVAPI(void) imgproc_integral2(cv::_InputArray *src, cv::_OutputArray *sum, cv::_OutputArray *sqsum, int sdepth)
{
	cv::integral(*src, *sum, *sqsum, sdepth);
}
CVAPI(void) imgproc_integral3(cv::_InputArray *src, cv::_OutputArray *sum, cv::_OutputArray *sqsum, cv::_OutputArray *tilted, int sdepth)
{
	cv::integral(*src, *sum, *sqsum, *tilted, sdepth);
}

CVAPI(void) imgproc_accumulate(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *mask)
{
	cv::accumulate(*src, *dst, entity(mask));
}
CVAPI(void) imgproc_accumulateSquare(cv::_InputArray* src, cv::_OutputArray *dst, cv::_InputArray *mask)
{
	cv::accumulateSquare(*src, *dst, entity(mask));
}
CVAPI(void) imgproc_accumulateProduct(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, cv::_InputArray *mask)
{
	cv::accumulateProduct(*src1, *src2, *dst, entity(mask));
}
CVAPI(void) imgproc_accumulateWeighted(cv::_InputArray *src, cv::_OutputArray *dst, double alpha, cv::_InputArray *mask)
{
	cv::accumulateWeighted(*src, *dst, alpha, entity(mask));
}

CVAPI(double) imgproc_PSNR(cv::_InputArray *src1, cv::_InputArray *src2)
{
	return cv::PSNR(*src1, *src2);
}

CVAPI(CvPoint2D64f) imgproc_phaseCorrelate(cv::_InputArray *src1, cv::_InputArray *src2,
                                  cv::_InputArray *window)
{
	cv::Point2d p = cv::phaseCorrelate(*src1, *src2, entity(window));
	return cvPoint2D64f(p.x, p.y);
}
CVAPI(CvPoint2D64f) imgproc_phaseCorrelateRes(cv::_InputArray *src1, cv::_InputArray *src2,
                                    cv::_InputArray *window, double* response)
{
	cv::Point2d p = cv::phaseCorrelateRes(*src1, *src2, *window, response);
	return cvPoint2D64f(p.x, p.y);
}
CVAPI(void) imgproc_createHanningWindow(cv::_OutputArray *dst, CvSize winSize, int type)
{
	cv::createHanningWindow(*dst, winSize, type);
}

CVAPI(double) imgproc_threshold(cv::_InputArray *src, cv::_OutputArray *dst,
	double thresh, double maxval, int type)
{
	return cv::threshold(*src, *dst, thresh, maxval, type);
}
CVAPI(void) imgproc_adaptiveThreshold(cv::_InputArray *src, cv::_OutputArray *dst,
	double maxValue, int adaptiveMethod,
	int thresholdType, int blockSize, double C)
{
	cv::adaptiveThreshold(*src, *dst, maxValue, adaptiveMethod, thresholdType, blockSize, C);
}

CVAPI(void) imgproc_pyrDown(cv::_InputArray *src, cv::_OutputArray *dst, CvSize dstsize, int borderType)
{
	cv::pyrDown(*src, *dst, dstsize, borderType);
}
CVAPI(void) imgproc_pyrUp(cv::_InputArray *src, cv::_OutputArray *dst, CvSize dstsize, int borderType)
{
	cv::pyrUp(*src, *dst, dstsize, borderType);
}

CVAPI(void) imgproc_undistort(cv::_InputArray *src, cv::_OutputArray *dst,
	cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs, cv::_InputArray *newCameraMatrix)
{
	cv::undistort(*src, *dst, *cameraMatrix, *distCoeffs, entity(newCameraMatrix));
}
CVAPI(void) imgproc_initUndistortRectifyMap(cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
	cv::_InputArray *r, cv::_InputArray *newCameraMatrix, CvSize size, int m1type,
	cv::_OutputArray *map1, cv::_OutputArray *map2)
{
	cv::initUndistortRectifyMap(*cameraMatrix, *distCoeffs, *r, *newCameraMatrix, size, m1type, *map1, *map2);
}
CVAPI(float) imgproc_initWideAngleProjMap(cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
	CvSize imageSize, int destImageWidth, int m1type, cv::_OutputArray *map1, cv::_OutputArray *map2, int projType, double alpha)
{
	return cv::initWideAngleProjMap(*cameraMatrix, *distCoeffs, imageSize, destImageWidth, m1type, *map1, *map2, projType, alpha);
}
CVAPI(cv::Mat*) imgproc_getDefaultNewCameraMatrix(cv::_InputArray *cameraMatrix, CvSize imgSize, int centerPrincipalPoint)
{
	cv::Mat ret = cv::getDefaultNewCameraMatrix(*cameraMatrix, imgSize, centerPrincipalPoint != 0);
	return new cv::Mat(ret);
}
CVAPI(void) imgproc_undistortPoints(cv::_InputArray *src, cv::_OutputArray *dst,
	cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
	cv::_InputArray *R, cv::_InputArray *P)
{
	cv::undistortPoints(*src, *dst, *cameraMatrix, *distCoeffs, entity(R), entity(P));
}
CVAPI(void) imgproc_calcHist1(cv::Mat **images, int nimages,
	const int* channels, cv::_InputArray *mask,
	cv::_OutputArray *hist, int dims, const int* histSize,
	const float** ranges, int uniform, int accumulate)
{
	std::vector<cv::Mat> imagesVec(nimages);
	for (int i = 0; i < nimages; i++)
		imagesVec[i] = *(images[i]);
	cv::calcHist(&imagesVec[0], nimages, channels, entity(mask), *hist, dims, histSize, ranges, uniform != 0, accumulate != 0);
}

CVAPI(void) imgproc_calcBackProject(cv::Mat **images, int nimages,
	const int* channels, cv::_InputArray *hist, cv::_OutputArray *backProject, 
	const float** ranges, int uniform)
{
	std::vector<cv::Mat> imagesVec(nimages);
	for (int i = 0; i < nimages; i++)
		imagesVec[i] = *(images[i]);
	cv::calcBackProject(&imagesVec[0], nimages, channels, *hist, *backProject, ranges, uniform != 0);
}


CVAPI(double) imgproc_compareHist1(cv::_InputArray *h1, cv::_InputArray *h2, int method)
{
	return cv::compareHist(*h1, *h2, method);
}
CVAPI(void) imgproc_equalizeHist(cv::_InputArray *src, cv::_OutputArray *dst)
{
	cv::equalizeHist(*src, *dst);
}

CVAPI(float) imgproc_EMD(cv::_InputArray *signature1, cv::_InputArray *signature2,
	int distType, cv::_InputArray *cost, float* lowerBound, cv::_OutputArray *flow)
{
	return cv::EMD(*signature1, *signature2, distType, entity(cost), lowerBound, entity(flow));
}
CVAPI(void) imgproc_watershed(cv::_InputArray *image, cv::_OutputArray *markers)
{
	cv::watershed(*image, *markers);
}
CVAPI(void) imgproc_pyrMeanShiftFiltering(cv::_InputArray *src, cv::_OutputArray *dst,
	double sp, double sr, int maxLevel, CvTermCriteria termcrit)
{
	cv::pyrMeanShiftFiltering(*src, *dst, sp, sr, maxLevel, termcrit);
}
CVAPI(void) imgproc_grabCut(cv::_InputArray *img, cv::_OutputArray *mask, CvRect rect,
                           cv::_OutputArray *bgdModel, cv::_OutputArray *fgdModel,
                           int iterCount, int mode )
{
	cv::grabCut(*img, *mask, rect, *bgdModel, *fgdModel, iterCount, mode);
}

CVAPI(void) imgproc_distanceTransformWithLabels(cv::_InputArray *src, cv::_OutputArray *dst,
                                     cv::_OutputArray *labels, int distanceType, int maskSize,
                                     int labelType)
{
	cv::distanceTransform(*src, *dst, *labels, distanceType, maskSize, labelType);
}
CVAPI(void) imgproc_distanceTransform(cv::_InputArray *src, cv::_OutputArray *dst,
                                     int distanceType, int maskSize )
{
	cv::distanceTransform(*src, *dst, distanceType, maskSize);
}
CVAPI(int) imgproc_floodFill1(cv::_OutputArray *image,
                          CvPoint seedPoint, CvScalar newVal, CvRect *rect,
                          CvScalar loDiff, CvScalar upDiff, int flags)
{
	cv::Rect rect0;
	int ret = cv::floodFill(*image, seedPoint, newVal, &rect0, loDiff, upDiff, flags);
	*rect = rect0;
	return ret;
}
CVAPI(int) imgproc_floodFill2(cv::_OutputArray *image, cv::_OutputArray *mask,
                            CvPoint seedPoint, CvScalar newVal, CvRect *rect,
                            CvScalar loDiff, CvScalar upDiff, int flags)
{
	cv::Rect rect0;
	int ret = cv::floodFill(*image, *mask, seedPoint, newVal, &rect0, loDiff, upDiff, flags);
	*rect = rect0;
	return ret;
}
CVAPI(void) imgproc_cvtColor(cv::_InputArray *src, cv::_OutputArray *dst, int code, int dstCn)
{
	cv::cvtColor(*src, *dst, code, dstCn); 
}
CVAPI(CvMoments) imgproc_moments(cv::_InputArray *arr, int binaryImage )
{
	cv::Moments m = cv::moments(*arr, binaryImage != 0);
	return (CvMoments)m;
}
CVAPI(void) imgproc_matchTemplate(cv::_InputArray *image, cv::_InputArray *templ,
	cv::_OutputArray *result, int method)
{
	cv::matchTemplate(*image, *templ, *result, method);
}
CVAPI(void) imgproc_findContours1(cv::_OutputArray *image, std::vector<std::vector<cv::Point> > **contours,
	std::vector<cv::Vec4i> **hierarchy, int mode,
	int method, CvPoint offset)
{
	*contours = new std::vector<std::vector<cv::Point> >;
	*hierarchy = new std::vector<cv::Vec4i>;
	cv::findContours(*image, **contours, **hierarchy, mode, method, offset);
}
CVAPI(void) imgproc_findContours2(cv::_OutputArray *image, std::vector<std::vector<cv::Point> > **contours,
	int mode, int method, CvPoint offset)
{
	*contours = new std::vector<std::vector<cv::Point> >;
	cv::findContours(*image, **contours, mode, method, offset);
}
CVAPI(void) imgproc_drawContours(cv::_OutputArray *image,
	cv::Point **contours, int contoursSize1, int *contoursSize2,
	int contourIdx, CvScalar color, int thickness, int lineType,
	cv::Vec4i *hierarchy, int hiearchyLength, int maxLevel, CvPoint offset)
{
	std::vector<std::vector<cv::Point> > contoursVec;
	for (int i = 0; i < contoursSize1; i++)
	{
		std::vector<cv::Point> c1(contours[i], contours[i] + contoursSize2[i]);
		contoursVec.push_back(c1);
	}
	std::vector<cv::Vec4i> hiearchyVec;
	if (hierarchy != NULL)
	{
		hiearchyVec = std::vector<cv::Vec4i>(hierarchy, hierarchy + hiearchyLength);
	}

	cv::drawContours(*image, contoursVec, contourIdx, color, thickness, lineType, hiearchyVec, maxLevel, offset);
}

CVAPI(void) imgproc_approxPolyDP_Point(cv::Point *curve, int curveLength, std::vector<cv::Point> **approxCurve, double epsilon, int closed)
{
	std::vector<cv::Point> curveVec(curve, curve + curveLength);
	*approxCurve = new std::vector<cv::Point>;
	cv::approxPolyDP(curveVec, **approxCurve, epsilon, closed != 0);
}
CVAPI(void) imgproc_approxPolyDP_Point2f(cv::Point2f *curve, int curveLength, std::vector<cv::Point2f> **approxCurve, double epsilon, int closed)
{
	std::vector<cv::Point2f> curveVec(curve, curve + curveLength);
	*approxCurve = new std::vector<cv::Point2f>;
	cv::approxPolyDP(curveVec, **approxCurve, epsilon, closed != 0);
}

CVAPI(double) imgproc_arcLength_Point(cv::Point *curve, int curveLength, int closed)
{
	std::vector<cv::Point> curveVec(curve, curve + curveLength);
	return cv::arcLength(curveVec, closed != 0);
}
CVAPI(double) imgproc_arcLength_Point2f(cv::Point2f *curve, int curveLength, int closed)
{
	std::vector<cv::Point2f> curveVec(curve, curve + curveLength);
	return cv::arcLength(curveVec, closed != 0);
}

CVAPI(CvRect) imgproc_boundingRect_Point(cv::Point *curve, int curveLength)
{
	std::vector<cv::Point> curveVec(curve, curve + curveLength);
	return cv::boundingRect(curveVec);
}
CVAPI(CvRect) imgproc_boundingRect_Point2f(cv::Point2f *curve, int curveLength)
{
	std::vector<cv::Point2f> curveVec(curve, curve + curveLength);
	return cv::boundingRect(curveVec);
}

CVAPI(double) imgproc_contourArea_Point(cv::Point *contour, int contourLength, int oriented)
{
	std::vector<cv::Point> contourVec(contour, contour + contourLength);
	return cv::contourArea(contourVec, oriented != 0);
}
CVAPI(double) imgproc_contourArea_Point2f(cv::Point2f *contour, int contourLength, int oriented)
{
	std::vector<cv::Point2f> contourVec(contour, contour + contourLength);
	return cv::contourArea(contourVec, oriented != 0);
}

CVAPI(CvBox2D) imgproc_minAreaRect_Point(cv::Point *points, int pointsLength)
{
	std::vector<cv::Point> pointsVec(points, points + pointsLength);
	return cv::minAreaRect(pointsVec);
}
CVAPI(CvBox2D) imgproc_minAreaRect_Point2f(cv::Point2f *points, int pointsLength)
{
	std::vector<cv::Point2f> pointsVec(points, points + pointsLength);
	return cv::minAreaRect(pointsVec);
}

CVAPI(void) imgproc_minEnclosingCircle_Point(cv::Point *points, int pointsLength, cv::Point2f *center, float *radius)
{
	std::vector<cv::Point> pointsVec(points, points + pointsLength);
	cv::Point2f center0;
	float radius0;
	cv::minEnclosingCircle(pointsVec, center0, radius0);
	*center = center0;
	*radius = radius0;
}
CVAPI(void) imgproc_minEnclosingCircle_Point2f(cv::Point2f *points, int pointsLength, cv::Point2f *center, float *radius)
{
	std::vector<cv::Point2f> pointsVec(points, points + pointsLength);
	cv::Point2f center0;
	float radius0;
	cv::minEnclosingCircle(pointsVec, center0, radius0);
	*center = center0;
	*radius = radius0;
}

CVAPI(double) imgproc_matchShapes_InputArray(cv::_InputArray *contour1, cv::_InputArray *contour2, int method, double parameter)
{
	return cv::matchShapes(*contour1, *contour2, method, parameter);
}
CVAPI(double) imgproc_matchShapes_Point(cv::Point *contour1, int contour1Length, cv::Point *contour2, int contour2Length, 
	int method, double parameter)
{
	std::vector<cv::Point> contour1Vec(contour1, contour1 + contour1Length);
	std::vector<cv::Point> contour2Vec(contour2, contour2 + contour2Length);
	return cv::matchShapes(contour1Vec, contour2Vec, method, parameter);
}

CVAPI(void) imgproc_convexHull_Point_ReturnsPoints(cv::Point *points, int pointsLength, std::vector<cv::Point> **hull, int clockwise)
{
	std::vector<cv::Point> pointsVec(points, points + pointsLength);
	*hull = new std::vector<cv::Point>;
	cv::convexHull(pointsVec, **hull, clockwise != 0, true);
}
CVAPI(void) imgproc_convexHull_Point2f_ReturnsPoints(cv::Point2f *points, int pointsLength, std::vector<cv::Point2f> **hull, int clockwise)
{
	std::vector<cv::Point2f> pointsVec(points, points + pointsLength);
	*hull = new std::vector<cv::Point2f>;
	cv::convexHull(pointsVec, **hull, clockwise != 0, true);
}
CVAPI(void) imgproc_convexHull_Point_ReturnsIndices(cv::Point *points, int pointsLength, std::vector<int> **hull, int clockwise)
{
	std::vector<cv::Point> pointsVec(points, points + pointsLength);
	*hull = new std::vector<int>;
	cv::convexHull(pointsVec, **hull, clockwise != 0, false);
}
CVAPI(void) imgproc_convexHull_Point2f_ReturnsIndices(cv::Point2f *points, int pointsLength, std::vector<int> **hull, int clockwise)
{
	std::vector<cv::Point2f> pointsVec(points, points + pointsLength);
	*hull = new std::vector<int>;
	cv::convexHull(pointsVec, **hull, clockwise != 0, false);
}

CVAPI(void) imgproc_convexityDefects_Point(cv::Point *contour, int contourLength, int *convexHull, int convexHullLength, 
	std::vector<cv::Vec4i> **convexityDefects)
{
	std::vector<cv::Point> contourVec(contour, contour + contourLength);
	std::vector<int> convexHullVec(convexHull, convexHull + convexHullLength);
	*convexityDefects = new std::vector<cv::Vec4i>;
	cv::convexityDefects(contourVec, convexHullVec, **convexityDefects);
}
CVAPI(void) imgproc_convexityDefects_Point2f(cv::Point2f *contour, int contourLength, int *convexHull, int convexHullLength,
	std::vector<cv::Vec4i> **convexityDefects)
{
	std::vector<cv::Point2f> contourVec(contour, contour + contourLength);
	std::vector<int> convexHullVec(convexHull, convexHull + convexHullLength);
	*convexityDefects = new std::vector<cv::Vec4i>;
	cv::convexityDefects(contourVec, convexHullVec, **convexityDefects);
}

CVAPI(int) imgproc_isContourConvex_Point(cv::Point *contour, int contourLength)
{
	std::vector<cv::Point> contourVec(contour, contour + contourLength);
	return cv::isContourConvex(contourVec) ? 1 : 0;
}
CVAPI(int) imgproc_isContourConvex_Point2f(cv::Point2f *contour, int contourLength)
{
	std::vector<cv::Point2f> contourVec(contour, contour + contourLength);
	return cv::isContourConvex(contourVec) ? 1 : 0;
}

CVAPI(float) imgproc_intersectConvexConvex_Point(cv::Point *p1, int p1Length, cv::Point *p2, int p2Length,
	std::vector<cv::Point> **p12, int handleNested)
{
	std::vector<cv::Point> p1Vec(p1, p1 + p1Length);
	std::vector<cv::Point> p2Vec(p2, p2 + p2Length);
	*p12 = new std::vector<cv::Point>;
	return cv::intersectConvexConvex(p1Vec, p2Vec, **p12, handleNested != 0);
}
CVAPI(float) imgproc_intersectConvexConvex_Point2f(cv::Point2f *p1, int p1Length, cv::Point2f *p2, int p2Length,
	std::vector<cv::Point2f> **p12, int handleNested)
{
	std::vector<cv::Point2f> p1Vec(p1, p1 + p1Length);
	std::vector<cv::Point2f> p2Vec(p2, p2 + p2Length);
	*p12 = new std::vector<cv::Point2f>;
	return cv::intersectConvexConvex(p1Vec, p2Vec, **p12, handleNested != 0);
}

CVAPI(CvBox2D) imgproc_fitEllipse_Point(cv::Point *points, int pointsLength)
{
	std::vector<cv::Point> pointsVec(points, points + pointsLength);
	return cv::fitEllipse(pointsVec);
}
CVAPI(CvBox2D) imgproc_fitEllipse_Point2f(cv::Point2f *points, int pointsLength)
{
	std::vector<cv::Point2f> pointsVec(points, points + pointsLength);
	return cv::fitEllipse(pointsVec);
}

CVAPI(void) imgproc_fitLine_Point(cv::Point *points, int pointsLength, float *line, int distType,
	double param, double reps, double aeps)
{
	std::vector<cv::Point> pointsVec(points, points + pointsLength);
	std::vector<float> lineVec;
	cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
	memcpy(line, &lineVec[0], sizeof(float) * 4);
}
CVAPI(void) imgproc_fitLine_Point2f(cv::Point2f *points, int pointsLength, float *line, int distType,
	double param, double reps, double aeps)
{
	std::vector<cv::Point2f> pointsVec(points, points + pointsLength);
	std::vector<float> lineVec;
	cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
	memcpy(line, &lineVec[0], sizeof(float)* 4);
}
CVAPI(void) imgproc_fitLine_Point3i(cv::Point3i *points, int pointsLength, float *line, int distType,
	double param, double reps, double aeps)
{
	std::vector<cv::Point3i> pointsVec(points, points + pointsLength);
	std::vector<float> lineVec;
	cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
	memcpy(line, &lineVec[0], sizeof(float)* 6);
}
CVAPI(void) imgproc_fitLine_Point3f(cv::Point3f *points, int pointsLength, float *line, int distType,
	double param, double reps, double aeps)
{
	std::vector<cv::Point3f> pointsVec(points, points + pointsLength);
	std::vector<float> lineVec;
	cv::fitLine(pointsVec, lineVec, distType, param, reps, aeps);
	memcpy(line, &lineVec[0], sizeof(float)* 6);
}

CVAPI(double) imgproc_pointPolygonTest_Point(cv::Point *contour, int contourLength, cv::Point2f pt, int measureDist)
{
	std::vector<cv::Point> contourVec(contour, contour + contourLength);
	return cv::pointPolygonTest(contourVec, pt, measureDist != 0);
}
CVAPI(double) imgproc_pointPolygonTest_Point2f(cv::Point2f *contour, int contourLength, cv::Point2f pt, int measureDist)
{
	std::vector<cv::Point2f> contourVec(contour, contour + contourLength);
	return cv::pointPolygonTest(contourVec, pt, measureDist != 0);
}

#endif