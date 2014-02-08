/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_H_
#define _CPP_CORE_H_

#include "include_opencv.h"

#pragma region Miscellaneous

CVAPI(void) core_setNumThreads(int nthreads)
{
	cv::setNumThreads(nthreads);
}
CVAPI(int) core_getNumThreads()
{
	return cv::getNumThreads();
}
CVAPI(int) core_getThreadNum()
{
	return cv::getThreadNum();
}

CVAPI(void) core_getBuildInformation(char* buf, uint32 maxLength)
{
	const std::string& str = cv::getBuildInformation();
	const char* srcPtr = str.c_str();
	uint32 length = std::max(str.length() + 1, maxLength);
	memcpy(buf, srcPtr, length);
}

CVAPI(int64) core_getTickCount()
{
	return cv::getTickCount();
}
CVAPI(double) core_getTickFrequency()
{
	return cv::getTickFrequency();
}
CVAPI(int64) core_getCPUTickCount()
{
	return cv::getCPUTickCount();
}

CVAPI(int) core_checkHardwareSupport(int feature)
{
	return cv::checkHardwareSupport(feature) ? 1 : 0;
}

CVAPI(int) core_getNumberOfCPUs()
{
	return cv::getNumberOfCPUs();
}

CVAPI(void*) core_fastMalloc(size_t bufSize)
{
	return cv::fastMalloc(bufSize);
}
CVAPI(void) core_fastFree(void* ptr)
{
	return cv::fastFree(ptr);
}

CVAPI(void) core_setUseOptimized(int onoff)
{
	cv::setUseOptimized(onoff != 0);
}
CVAPI(int) core_useOptimized()
{
	return cv::useOptimized() ? 1 : 0;
}

CVAPI(cv::Mat*) core_cvarrToMat(CvArr* arr, int copyData, int allowND, int coiMode)
{
	cv::Mat ret = cv::cvarrToMat(arr, copyData != 0, allowND != 0, coiMode);
	return new cv::Mat(ret);
}
CVAPI(void) core_extractImageCOI(CvArr *arr, cv::_OutputArray *coiimg, int coi)
{
	cv::extractImageCOI(arr, *coiimg, coi);
}
CVAPI(void) core_insertImageCOI(cv::_InputArray *coiimg, CvArr* arr, int coi)
{
	cv::insertImageCOI(*coiimg, arr, coi);
}
#pragma endregion

#pragma region Array Operations

CVAPI(void) cv_add(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray* dst, cv::_InputArray *mask, int dtype)
{
	cv::add(*src1, *src2, *dst, entity(mask), dtype);
}
CVAPI(void) cv_subtract(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray* dst, cv::_InputArray *mask, int dtype)
{
	cv::subtract(*src1, *src2, *dst, entity(mask), dtype);
}
CVAPI(void) cv_multiply(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray* dst, double scale, int dtype)
{
	cv::multiply(*src1, *src2, *dst, scale, dtype);
}
CVAPI(void) cv_divide1(double scale, cv::_InputArray *src2, cv::_OutputArray* dst, int dtype)
{
	cv::divide(scale, *src2, *dst, dtype);
}
CVAPI(void) cv_divide2(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, double scale, int dtype)
{
	cv::divide(*src1, *src2, *dst);
}


CVAPI(void) cv_convertScaleAbs(cv::_InputArray *src, cv::_OutputArray *dst, double alpha, double beta)
{
	cv::convertScaleAbs(*src, *dst, alpha, beta);
}
#pragma endregion

#pragma region Drawing

CVAPI(void) core_line(cv::Mat *img, CvPoint pt1, CvPoint pt2, CvScalar color,
	int thickness, int lineType, int shift)
{
	cv::line(*img, pt1, pt2, color, thickness, lineType, shift);
}

CVAPI(void) core_rectangle1(cv::Mat *img, CvPoint pt1, CvPoint pt2,
	CvScalar color, int thickness, int lineType, int shift)
{
	cv::rectangle(*img, pt1, pt2, color, thickness, shift);
}
CVAPI(void) core_rectangle2(cv::Mat *img, CvRect rect,
	CvScalar color, int thickness, int lineType, int shift)
{
	cv::rectangle(*img, rect, color, thickness, shift);
}

CVAPI(void) core_circle(cv::Mat *img, CvPoint center, int radius,
	CvScalar color, int thickness, int lineType, int shift)
{
	cv::circle(*img, center, radius, color, thickness, lineType, shift);
}

CVAPI(void) core_ellipse1(cv::Mat *img, CvPoint center, CvSize axes,
	double angle, double startAngle, double endAngle,
	CvScalar& color, int thickness,	int lineType, int shift)
{
	cv::ellipse(*img, center, axes, angle, startAngle, endAngle, color, thickness, lineType, shift);
}
CVAPI(void) core_ellipse2(cv::Mat *img, CvBox2D box, CvScalar color, int thickness, int lineType)
{
	cv::ellipse(*img, box, color, thickness, lineType);
}

CVAPI(void) core_fillConvexPoly(cv::Mat *img, cv::Point* pts, int npts,
	CvScalar color, int lineType, int shift)
{
	cv::fillConvexPoly(*img, pts, npts, color, lineType, shift);
}

CVAPI(void) core_fillPoly(cv::Mat *img, const cv::Point **pts, const int* npts, 
	int ncontours, CvScalar color, int lineType, int shift, CvPoint offset)
{
	cv::fillPoly(*img, pts, npts, ncontours, color, lineType, shift, offset);
}

CVAPI(void) core_polylines(cv::Mat *img, const cv::Point **pts, const int* npts,
	int ncontours, int isClosed, CvScalar color,
	int thickness, int lineType, int shift)
{
	cv::polylines(
		*img, pts, npts, ncontours, isClosed != 0, color, thickness, lineType, shift);
}

CVAPI(int) core_clipLine1(CvSize imgSize, CvPoint *pt1, CvPoint *pt2)
{
	cv::Point pt1c = *pt1, pt2c = *pt2;
	bool result = cv::clipLine(imgSize, pt1c, pt2c);
	*pt1 = pt1c;
	*pt2 = pt2c;
	return result ? 1 : 0;
}
CVAPI(int) core_clipLine2(CvRect imgRect, CvPoint *pt1, CvPoint *pt2)
{
	cv::Point pt1c = *pt1, pt2c = *pt2;
	bool result = cv::clipLine(imgRect, pt1c, pt2c);
	*pt1 = pt1c;
	*pt2 = pt2c;
	return result ? 1 : 0;
}

#pragma endregion


#endif