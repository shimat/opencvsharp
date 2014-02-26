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
	uint32 length = (uint32)std::max<uint64>(str.length() + 1, maxLength);
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

CVAPI(void) core_add(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray* dst, cv::_InputArray *mask, int dtype)
{
	cv::add(*src1, *src2, *dst, entity(mask), dtype);
}
CVAPI(void) core_subtract(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray* dst, cv::_InputArray *mask, int dtype)
{
	cv::subtract(*src1, *src2, *dst, entity(mask), dtype);
}
CVAPI(void) core_multiply(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray* dst, double scale, int dtype)
{
	cv::multiply(*src1, *src2, *dst, scale, dtype);
}
CVAPI(void) core_divide1(double scale, cv::_InputArray *src2, cv::_OutputArray* dst, int dtype)
{
	cv::divide(scale, *src2, *dst, dtype);
}
CVAPI(void) core_divide2(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst, double scale, int dtype)
{
	cv::divide(*src1, *src2, *dst);
}

CVAPI(void) core_scaleAdd(cv::_InputArray *src1, double alpha, cv::_InputArray *src2, cv::_OutputArray *dst)
{
	cv::scaleAdd(*src1, alpha, *src2, *dst);
}
CVAPI(void) core_addWeighted(cv::_InputArray *src1, double alpha, cv::_InputArray *src2,
	double beta, double gamma, cv::_OutputArray *dst, int dtype)
{
	cv::addWeighted(*src1, alpha, *src2, beta, gamma, *dst, dtype);
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

//! renders text string in the image
CVAPI(void) core_putText(cv::Mat *img, const char *text, CvPoint org,
	int fontFace, double fontScale, CvScalar color,
	int thickness, int lineType, int bottomLeftOrigin)
{
	cv::putText(*img, text, org, fontFace, fontScale, color, thickness, lineType, bottomLeftOrigin != 0);
}

//! returns bounding box of the text string
CVAPI(CvSize) core_getTextSize(const char *text, int fontFace,
	double fontScale, int thickness, int* baseLine)
{
	return cv::getTextSize(text, fontFace, fontScale, thickness, baseLine);
}


#pragma endregion

CVAPI(void) core_convertScaleAbs(cv::_InputArray *src, cv::_OutputArray *dst, double alpha, double beta)
{
	cv::convertScaleAbs(*src, *dst, alpha, beta);
}

CVAPI(void) core_LUT(cv::_InputArray *src, cv::_InputArray *lut, cv::_OutputArray *dst, int interpolation)
{
	cv::LUT(*src, *lut, *dst, interpolation);
}
CVAPI(CvScalar) core_sum(cv::_InputArray *src)
{
	return cv::sum(*src);
}
CVAPI(int) core_countNonZero(cv::_InputArray *src)
{
	return cv::countNonZero(*src);
}
CVAPI(void) core_findNonZero(cv::_InputArray *src, cv::_OutputArray *idx)
{
	cv::findNonZero(*src, *idx);
}

CVAPI(void) core_normalize(cv::_InputArray *src, cv::_OutputArray *dst, double alpha, double beta,
	int normType, int dtype, cv::_InputArray *mask)
{
	cv::InputArray maskVal = entity(mask);
	cv::normalize(*src, *dst, alpha, beta, normType, dtype, maskVal);
}

CVAPI(void) core_minMaxLoc1(cv::_InputArray *src, double* minVal, double* maxVal)
{
	cv::minMaxLoc(*src, minVal, maxVal);
}
CVAPI(void) core_minMaxLoc2(cv::_InputArray *src, double* minVal, double* maxVal,
	CvPoint* minLoc, CvPoint* maxLoc, cv::_InputArray* mask)
{
	cv::InputArray maskVal = entity(mask);
	cv::Point minLoc0, maxLoc0;
	cv::minMaxLoc(*src, minVal, maxVal, &minLoc0, &maxLoc0, maskVal);
	*minLoc = minLoc0;
	*maxLoc = maxLoc0;
}
CVAPI(void) core_minMaxIdx1(cv::_InputArray *src, double* minVal, double* maxVal)
{
	cv::minMaxIdx(*src, minVal, maxVal);
}
CVAPI(void) core_minMaxIdx2(cv::_InputArray *src, double* minVal, double* maxVal,
	int* minIdx, int* maxIdx, cv::_InputArray *mask)
{
	cv::InputArray maskVal = entity(mask);
	cv::minMaxIdx(*src, minVal, maxVal, minIdx, maxIdx, maskVal);
}

CVAPI(int) core_eigen1(cv::_InputArray *src, cv::_OutputArray *eigenvalues, int lowindex, int highindex)
{
	return cv::eigen(*src, *eigenvalues, lowindex, highindex) ? 1 : 0;
}
CVAPI(int) core_eigen2(cv::_InputArray *src, cv::_OutputArray *eigenvalues,
	cv::_OutputArray *eigenvectors, int lowindex, int highindex)
{
	return cv::eigen(*src, *eigenvalues, *eigenvectors, lowindex, highindex) ? 1 : 0;
}
CVAPI(int) core_eigen3(cv::_InputArray *src, bool computeEigenvectors,
	cv::_OutputArray *eigenvalues, cv::_OutputArray *eigenvectors)
{
	return cv::eigen(*src, computeEigenvectors, *eigenvalues, *eigenvectors) ? 1 : 0;
}

#endif