/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_IMGPROC_H_
#define _CPP_IMGPROC_H_

#include "include_opencv.h"

CVAPI(cv::Mat*) imgproc_getGaborKernel(CvSize ksize, double sigma, double theta, double lambd, double gamma, double psi, int ktype)
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

CVAPI(void) imgproc_copyMakeBorder(cv::_InputArray *src, cv::_OutputArray *dst, int top, int bottom, int left, int right, int borderType, CvScalar value)
{
	cv::copyMakeBorder(*src, *dst, top, bottom, left, right, borderType, value);
}

CVAPI(void) imgproc_medianBlur(cv::_InputArray *src, cv::_OutputArray *dst, int ksize)
{
	cv::medianBlur(*src, *dst, ksize);
}

CVAPI(void) imgproc_GaussianBlur(cv::_InputArray *src, cv::_OutputArray *dst, CvSize ksize, double sigmaX, double sigmaY, int borderType)
{
	cv::GaussianBlur(*src, *dst, ksize, sigmaX, sigmaY, borderType);
}

CVAPI(void) imgproc_bilateralFilter(cv::_InputArray *src, cv::_OutputArray *dst, int d, double sigmaColor, double sigmaSpace, int borderType)
{
	cv::bilateralFilter(*src, *dst, d, sigmaColor, sigmaSpace, borderType);
}

CVAPI(void) imgproc_adaptiveBilateralFilter(cv::_InputArray *src, cv::_OutputArray *dst, CvSize ksize, double sigmaSpace,
	double maxSigmaColor, CvPoint anchor, int borderType)
{
	cv::adaptiveBilateralFilter(*src, *dst, ksize, sigmaSpace, maxSigmaColor, anchor, borderType);
}

CVAPI(void) imgproc_boxFilter(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth, CvSize ksize, CvPoint anchor, int normalize, int borderType)
{
	cv::boxFilter(*src, *dst, ddepth, ksize, anchor, normalize != 0, borderType);
}

CVAPI(void) imgproc_blur(cv::_InputArray *src, cv::_OutputArray *dst, CvSize ksize, CvPoint anchor, int borderType)
{
	cv::blur(*src, *dst, ksize, anchor, borderType);
}
//! applies non-separable 2D linear filter to the image
CVAPI(void) imgproc_filter2D(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	cv::_InputArray *kernel, CvPoint anchor, double delta, int borderType);

//! applies separable 2D linear filter to the image
CVAPI(void) imgproc_sepFilter2D(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	cv::_InputArray *kernelX, cv::_InputArray kernelY,
	CvPoint anchor,	double delta, int borderType);

//! applies generalized Sobel operator to the image
CVAPI(void) imgproc_Sobel(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	int dx, int dy, int ksize, double scale, double delta, int borderType);

//! applies the vertical or horizontal Scharr operator to the image
CVAPI(void) imgproc_Scharr(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	int dx, int dy, double scale, double delta,	int borderType);

//! applies Laplacian operator to the image
CVAPI(void) imgproc_Laplacian(cv::_InputArray *src, cv::_OutputArray *dst, int ddepth,
	int ksize, double scale, double delta, int borderType);

//! applies Canny edge detector and produces the edge map.
CVAPI(void) imgproc_Canny(cv::_InputArray *src, cv::_OutputArray *edges,
	double threshold1, double threshold2, int apertureSize, bool L2gradient);

//! computes minimum eigen value of 2x2 derivative covariation matrix at each pixel - the cornerness criteria
CVAPI(void) imgproc_cornerMinEigenVal(cv::_InputArray *src, cv::_OutputArray *dst,
	int blockSize, int ksize, int borderType);

//! computes Harris cornerness criteria at each image pixel
CVAPI(void) imgproc_cornerHarris(cv::_InputArray *src, cv::_OutputArray *dst, int blockSize,
	int ksize, double k, int borderType);

// low-level function for computing eigenvalues and eigenvectors of 2x2 matrices
CVAPI(void) imgproc_eigen2x2(const float* a, float* e, int n);

//! computes both eigenvalues and the eigenvectors of 2x2 derivative covariation matrix  at each pixel. The output is stored as 6-channel matrix.
CVAPI(void) imgproc_cornerEigenValsAndVecs(cv::_InputArray *src, cv::_OutputArray *dst,
	int blockSize, int ksize, int borderType);

//! computes another complex cornerness criteria at each pixel
CVAPI(void) imgproc_preCornerDetect(cv::_InputArray *src, cv::_OutputArray *dst, int ksize,	int borderType);

//! adjusts the corner locations with sub-pixel accuracy to maximize the certain cornerness criteria
CVAPI(void) imgproc_cornerSubPix(cv::_InputArray *src, cv::_OutputArray *corners,
	CvSize winSize, CvSize zeroZone, CvTermCriteria criteria);

//! finds the strong enough corners where the cornerMinEigenVal() or cornerHarris() report the local maxima
CVAPI(void) imgproc_goodFeaturesToTrack(cv::_InputArray *src, cv::_OutputArray *corners,
	int maxCorners, double qualityLevel, double minDistance,
	cv::_InputArray *mask, int blockSize, bool useHarrisDetector, double k);

//! finds lines in the black-n-white image using the standard or pyramid Hough transform
CVAPI(void) imgproc_HoughLines(cv::_InputArray *src, cv::_OutputArray *lines,
	double rho, double theta, int threshold,
	double srn = 0, double stn = 0);

//! finds line segments in the black-n-white image using probabilistic Hough transform
CVAPI(void) imgproc_HoughLinesP(cv::_InputArray *src, cv::_OutputArray *lines,
	double rho, double theta, int threshold,
	double minLineLength = 0, double maxLineGap = 0);

//! finds circles in the grayscale image using 2+1 gradient Hough transform
CVAPI(void) imgproc_HoughCircles(cv::_InputArray *src, cv::_OutputArray *circles,
	int method, double dp, double minDist,
	double param1 = 100, double param2 = 100,
	int minRadius = 0, int maxRadius = 0);

#endif