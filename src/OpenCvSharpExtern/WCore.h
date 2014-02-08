/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WCORE_H_
#define _CPP_WCORE_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/core/core.hpp>

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