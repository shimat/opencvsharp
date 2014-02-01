/*
* (C) 2008-2014 Schima
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_MATEXPR_H_
#define _CPP_CORE_MATEXPR_H_

#include "include_opencv.h"

CVAPI(cv::MatExpr*) core_MatExpr_new()
{
	return new cv::MatExpr();
}
CVAPI(void) core_MatExpr_delete(cv::MatExpr *expr)
{
	delete expr;
}

CVAPI(cv::Mat*) core_MatExpr_toMat(cv::MatExpr *expr)
{
	cv::Mat ret = (cv::Mat)(*expr);
	return new cv::Mat(ret);
}

#endif