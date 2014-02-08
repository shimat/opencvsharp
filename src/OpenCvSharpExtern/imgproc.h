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

CVAPI(void) imgproc_cvtColor(cv::_InputArray *src, cv::_OutputArray *dst, int code, int dstCn)
{
	cv::cvtColor(*src, *dst, code, dstCn); 
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




#endif