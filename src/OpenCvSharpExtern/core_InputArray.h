/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_CORE_INPUTARRAY_H_
#define _CPP_CORE_INPUTARRAY_H_

#include "include_opencv.h"

CVAPI(cv::_InputArray*) core_InputArray_new_byMat(cv::Mat *mat)
{
	cv::_InputArray ia(*mat);
	return new cv::_InputArray(ia);
}

CVAPI(cv::_InputArray*) core_InputArray_new_byMatExpr(cv::MatExpr *expr)
{
	cv::_InputArray ia(*expr);
	return new cv::_InputArray(ia);
}

CVAPI(void) core_InputArray_delete(cv::_InputArray *ia)
{
	delete ia;
}

CVAPI(int) core_InputArray_kind(cv::_InputArray *ia)
{
	return ia->kind();
}

#endif