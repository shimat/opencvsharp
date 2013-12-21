/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WCV_H_
#define _CPP_WCV_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/opencv.hpp>

CVAPI(void) cv_cvtColor( cv::Mat* src, cv::Mat* dst, int code, int dstCn )
{
	cv::cvtColor(*src, *dst, code, dstCn);
}


CVAPI(void) cv_copyMakeBorder( cv::Mat* src, cv::Mat* dst, int top, int bottom, int left, int right, int borderType, CvScalar value )
{

}

CVAPI(void) cv_medianBlur( cv::Mat* src, cv::Mat* dst, int kCvSize )
{
}

CVAPI(void) cv_GaussianBlur( cv::Mat* src, cv::Mat* dst, CvSize kCvSize, double sigma1, double sigma2, int borderType )
{
}

CVAPI(void) cv_bilateralFilter( cv::Mat* src, cv::Mat* dst, int d, double sigmaColor, double sigmaSpace, int borderType )
{
}

CVAPI(void) cv_boxFilter( cv::Mat* src, cv::Mat* dst, int ddepth, CvSize ksize, CvPoint anchor, bool normalize, int borderType )
{
}

CVAPI(void) cv_blur( cv::Mat* src, cv::Mat* dst, CvSize ksize, CvPoint anchor, int borderType )
{
	cv::blur(*src, *dst, ksize, anchor, borderType);
}

CVAPI(void) cv_filter2D( cv::Mat* src, cv::Mat* dst, int ddepth, cv::Mat* kernel, CvPoint anchor, double delta, int borderType )
{
}

CVAPI(void) cv_sepFilter2D( cv::Mat* src, cv::Mat* dst, int ddepth, cv::Mat* kernelX, cv::Mat* kernelY, CvPoint anchor, double delta, int borderType )
{
}

CVAPI(void) cv_Sobel( cv::Mat* src, cv::Mat* dst, int ddepth, int dx, int dy, int ksize, double scale, double delta, int borderType )
{
}

CVAPI(void) cv_Scharr( cv::Mat* src, cv::Mat* dst, int ddepth, int dx, int dy, double scale, double delta, int borderType )
{
}

CVAPI(void) cv_Laplacian( cv::Mat* src, cv::Mat* dst, int ddepth, int ksize, double scale, double delta, int borderType )
{
}

CVAPI(void) cv_Canny( cv::Mat* image, cv::Mat* edges, double threshold1, double threshold2, int apertureSize, bool L2gradient )
{
	cv::Canny(*image, *edges, threshold1, threshold2, apertureSize, L2gradient);
}

CVAPI(void) cv_cornerMinEigenVal( cv::Mat* src, cv::Mat* dst, int blockSize, int kaize, int borderType )
{
}

CVAPI(void) cv_cornerHarris( cv::Mat* src, cv::Mat* dst, int blockSize, int ksize, double k, int borderType )
{
	cv::cornerHarris(*src, *dst, blockSize, ksize, k, borderType);
}

CVAPI(void) cv_cornerEigenValsAndVecs( cv::Mat* src, cv::Mat* dst, int blockSize, int ksize, int borderType )
{
	cv::cornerEigenValsAndVecs(*src, *dst, blockSize, ksize, borderType);
}

CVAPI(void) cv_preCornerDetect( cv::Mat* src, cv::Mat* dst, int ksize, int borderType )
{
	cv::preCornerDetect(*src, *dst, ksize, borderType);
}

CVAPI(void) cv_cornerSubPix( cv::Mat* image, std::vector<cv::Point2f>* corners, CvSize winSize, CvSize zeroZone, CvTermCriteria criteria )
{
	cv::cornerSubPix(*image, *corners, winSize, zeroZone, criteria);
}

CVAPI(void) cv_goodFeaturesToTrack( cv::Mat* image, std::vector<cv::Point2f>* corners, int maxCorners, double qualityLevel, double minDistance, cv::Mat* mask, int blocksize, bool useHarrisDetector, double k )
{
	cv::goodFeaturesToTrack(*image, *corners, maxCorners, qualityLevel, minDistance, *mask, blocksize, useHarrisDetector, k);
}

CVAPI(void) cv_HoughLines( cv::Mat* image, std::vector<cv::Vec2f>* lines, double rho, double theta, int threshold, double srn, double stn )
{
	cv::HoughLines(*image, *lines, rho, theta, threshold, srn, stn);
}

CVAPI(void) cv_HoughLinesP( cv::Mat* image, std::vector<cv::Vec4i>* lines, double rho, double theta, int threshold, double minLineLength, double maxLineGap )
{
	cv::HoughLinesP(*image, *lines, rho, theta, threshold, minLineLength, maxLineGap);
}

CVAPI(void) cv_HoughCircles( cv::Mat* image, std::vector<cv::Vec3f>* circles, int method, double dp, double minDist, double param1, double param2, int minRadius, int maxRadius )
{
	cv::HoughCircles(*image, *circles, method, dp, minDist, param1, param2, minRadius, maxRadius);
}

CVAPI(void) cv_erode( cv::Mat* src, cv::Mat* dst, cv::Mat* kernel, CvPoint anchor, int iterations, int borderType, CvScalar borderValue )
{
	cv::erode(*src, *dst, *kernel, anchor, iterations, borderType, borderValue); //cv::morphologyDefaultBorderValue();
}

CVAPI(void) cv_dilate( cv::Mat* src, cv::Mat* dst, cv::Mat* kernel, CvPoint anchor, int iterations, int borderType, CvScalar borderValue )
{
	cv::dilate(*src, *dst, *kernel, anchor, iterations, borderType, borderValue);
}

CVAPI(void) cv_morphologyEx( cv::Mat* src, cv::Mat* dst, int op, cv::Mat* kernel, CvPoint anchor, int iterations, int borderType, CvScalar borderValue )
{
	cv::morphologyEx(*src, *dst, op, *kernel, anchor, iterations, borderType, borderValue);
}

CVAPI(void) cv_resize( cv::Mat* src, cv::Mat* dst,  CvSize dsize, double fx, double fy, int interpolation )
{
	cv::resize(*src, *dst, dsize, fx, fy, interpolation);
}

CVAPI(void) cv_warpAffine( cv::Mat* src, cv::Mat* dst, cv::Mat* M, CvSize dsize, int flags, int borderMode, CvScalar borderValue)
{
	cv::warpAffine(*src, *dst, *M, dsize, flags, borderMode, borderValue);
}

CVAPI(void) cv_warpPerspective( cv::Mat* src, cv::Mat* dst, cv::Mat* M, CvSize dsize, int flags, int borderMode, CvScalar borderValue)
{
	cv::warpPerspective(*src, *dst, *M, dsize, flags, borderMode, borderValue);
}

CVAPI(void) cv_remap( cv::Mat* src, cv::Mat* dst, cv::Mat* map1, cv::Mat* map2, int interpolation, int borderMode, CvScalar borderValue)
{
	cv::remap(*src, *dst, *map1, *map2, interpolation, borderMode, borderValue);
}

CVAPI(void) cv_convertMaps( cv::Mat* map1, cv::Mat* map2, cv::Mat* dstmap1, cv::Mat* dstmap2, int dstmap1type, bool nninterpolation )
{
	cv::convertMaps(*map1, *map2, *dstmap1, *dstmap2, dstmap1type, nninterpolation);
}



CVAPI(void) cv_solvePnP( cv::Mat* objectPoints, cv::Mat* imagePoints, cv::Mat* cameraMatrix, cv::Mat* distCoeffs, cv::Mat* rvec, cv::Mat* tvec, bool useExtrinsicGuess )
{
	cv::solvePnP(*objectPoints, *imagePoints, *cameraMatrix, *distCoeffs, *rvec, *tvec, useExtrinsicGuess);
}

#endif