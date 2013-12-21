/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WCORE_H_
#define _CPP_WCORE_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/core/core.hpp>

#pragma region Miscellaneous

CVAPI(void) cv_setNumThreads(int nthreads)
{
	cv::setNumThreads(nthreads);
}
CVAPI(int) cv_getNumThreads()
{
	return cv::getNumThreads();
}
CVAPI(int) cv_getThreadNum()
{
	return cv::getThreadNum();
}

CVAPI(const char*) cv_getBuildInformation()
{
	const std::string& str = cv::getBuildInformation();
	return str.c_str();
}

CVAPI(int64) cv_getTickCount()
{
	return cv::getTickCount();
}
CVAPI(double) cv_getTickFrequency()
{
	return cv::getTickFrequency();
}
CVAPI(int64) cv_getCPUTickCount()
{
	return cv::getCPUTickCount();
}

CVAPI(bool) cv_checkHardwareSupport(int feature)
{
	return cv::checkHardwareSupport(feature);
}

CVAPI(int) cv_getNumberOfCPUs()
{
	return cv::getNumberOfCPUs();
}
    
CVAPI(void*) cv_fastMalloc(size_t bufSize)
{
	return cv::fastMalloc(bufSize);
}
CVAPI(void) cv_fastFree(void* ptr)
{
	return cv::fastFree(ptr);
}

CVAPI(void) cv_cvarrToMat(CvArr* arr, bool copyData, bool allowND, int coiMode, cv::Mat* outValue)
{
	*outValue = cv::cvarrToMat(arr, copyData, allowND, coiMode);
}
CVAPI(void) cv_extractImageCOI(const CvArr* arr, cv::Mat* coiimg, int coi)
{
	cv::extractImageCOI(arr, *coiimg, coi);
}
CVAPI(void) cv_insertImageCOI(cv::Mat* coiimg, CvArr* arr, int coi)
{
	cv::insertImageCOI(*coiimg, arr, coi);
}
#pragma endregion

#pragma region Array Operations
CVAPI(void) cv_abs1(cv::Mat* src, cv::Mat* dst)
{
	*dst = cv::abs(*src);
}
CVAPI(void) cv_add1(cv::Mat* a, cv::Mat* b, cv::Mat* c, cv::Mat* mask)
{
	if(mask == NULL)
		cv::add(*a, *b, *c);
	else
		cv::add(*a, *b, *c, *mask);
}
CVAPI(void) cv_add2(cv::Mat* a, CvScalar s, cv::Mat* c, cv::Mat* mask)
{
	if(mask == NULL)
		cv::add(*a, cv::InputArray(s), *c);
	else
		cv::add(*a, cv::InputArray(s), *c, *mask);
}
CVAPI(void) cv_subtract1(cv::Mat* a, cv::Mat* b, cv::Mat* c, cv::Mat* mask)
{
	if(mask == NULL)
		cv::subtract(*a, *b, *c);
	else
		cv::subtract(*a, *b, *c, *mask);
}
CVAPI(void) cv_subtract2(cv::Mat* a, CvScalar s, cv::Mat* c, cv::Mat* mask)
{
	if(mask == NULL)
		cv::subtract(*a, cv::InputArray(s), *c);
	else
		cv::subtract(*a, cv::InputArray(s), *c, *mask);
}
CVAPI(void) cv_subtract3(CvScalar s, cv::Mat* a, cv::Mat* c, cv::Mat* mask)
{
	if(mask == NULL)
		cv::subtract(cv::InputArray(s), *a, *c);
	else
		cv::subtract(cv::InputArray(s), *a, *c, *mask);
}

CVAPI(void) cv_multiply(cv::Mat* a, cv::Mat* b, cv::Mat* c, double scale)
{
	cv::multiply(*a, *b, *c, scale);
}
CVAPI(void) cv_divide1(cv::Mat* a, cv::Mat* b, cv::Mat* c, double scale)
{
	cv::divide(*a, *b, *c, scale);
}
CVAPI(void) cv_divide2(double scale, cv::Mat* b, cv::Mat* c)
{
	cv::divide(scale, *b, *c);
}


CVAPI(void) cv_convertScaleAbs(cv::Mat* src, cv::Mat* dst, double alpha, double beta)
{
	cv::convertScaleAbs(*src, *dst, alpha, beta);
}
#pragma endregion

#endif