#ifndef _CPP_CORE_SVD_H_
#define _CPP_CORE_SVD_H_

#include "include_opencv.h"

CVAPI(cv::SVD*) core_SVD_new1()
{
	return new cv::SVD;
}
CVAPI(cv::SVD*) core_SVD_new2(cv::_InputArray *src, int flags)
{
	return new cv::SVD(*src, flags);
}
CVAPI(void) core_SVD_delete(cv::SVD *obj)
{
	delete obj;
}

CVAPI(void) core_SVD_operatorThis(cv::SVD *obj, cv::_InputArray *src, int flags)
{
	(*obj)(*src, flags);
}
//! performs back substitution, so that dst is the solution or pseudo-solution of m*dst = rhs, where m is the decomposed matrix
CVAPI(void) core_SVD_backSubst(cv::SVD *obj, cv::_InputArray *rhs, cv::_OutputArray *dst)
{
	obj->backSubst(*rhs, *dst);
}

//! decomposes matrix and stores the results to user-provided matrices
CVAPI(void) core_SVD_static_compute1(cv::_InputArray *src, cv::_OutputArray *w,
	cv::_OutputArray *u, cv::_OutputArray *vt, int flags)
{
	cv::SVD::compute(*src, *w, *u, *vt, flags);
}
//! computes singular values of a matrix
CVAPI(void) core_SVD_static_compute2(cv::_InputArray *src, cv::_OutputArray *w, int flags)
{
	cv::SVD::compute(*src, *w, flags);
}
//! performs back substitution
CVAPI(void) core_SVD_static_backSubst(cv::_InputArray *w, cv::_InputArray *u,
	cv::_InputArray *vt, cv::_InputArray *rhs, cv::_OutputArray *dst)
{
	cv::SVD::backSubst(*w, *u, *vt, *rhs, *dst);
}
//! finds dst = arg min_{|dst|=1} |m*dst|
CVAPI(void) core_SVD_static_solveZ(cv::_InputArray *src, cv::_OutputArray *dst)
{
	cv::SVD::solveZ(*src, *dst);
}

CVAPI(cv::Mat*) core_SVD_u(cv::SVD *obj)
{
	return new cv::Mat(obj->u);
}
CVAPI(cv::Mat*) core_SVD_w(cv::SVD *obj)
{
	return new cv::Mat(obj->w);
}
CVAPI(cv::Mat*) core_SVD_vt(cv::SVD *obj)
{
	return new cv::Mat(obj->vt);
}

#endif