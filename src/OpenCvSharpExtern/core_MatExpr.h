/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_MATEXPR_H_
#define _CPP_CORE_MATEXPR_H_

#include "include_opencv.h"

CVAPI(cv::MatExpr*) core_MatExpr_new1()
{
	return new cv::MatExpr();
}
CVAPI(cv::MatExpr*) core_MatExpr_new2(cv::Mat *mat)
{
	return new cv::MatExpr(*mat);
}
CVAPI(void) core_MatExpr_delete(cv::MatExpr *expr)
{
	delete expr;
}

CVAPI(cv::Mat*) core_MatExpr_toMat(cv::MatExpr *expr)
{
	cv::Mat ret = (*expr);
	return new cv::Mat(ret);
}


CVAPI(cv::MatExpr*) core_operatorDivide_MatExprMat(cv::MatExpr *e, cv::Mat *m) 
{ 
	cv::MatExpr ret = (*e) / (*m);
	return new cv::MatExpr(ret);
}
CVAPI(cv::MatExpr*) core_operatorDivide_MatMatExpr(cv::Mat *m, cv::MatExpr *e) 
{ 
	cv::MatExpr ret = (*m) / (*e);
	return new cv::MatExpr(ret);
}
CVAPI(cv::MatExpr*) core_operatorDivide_MatExprDouble(cv::MatExpr *e, double s) 
{ 
	cv::MatExpr ret = (*e) / s;
	return new cv::MatExpr(ret);
}
CVAPI(cv::MatExpr*) core_operatorDivide_DoubleMatExpr(double s, cv::MatExpr *e) 
{ 
	cv::MatExpr ret = s / (*e);
	return new cv::MatExpr(ret);
}
CVAPI(cv::MatExpr*) core_operatorDivide_MatExprMatExpr(cv::MatExpr *e1, cv::MatExpr *e2) 
{ 
	cv::MatExpr ret = (*e1) / (*e2);
	return new cv::MatExpr(ret);
}

#endif