#ifndef _CPP_CORE_SVD_H_
#define _CPP_CORE_SVD_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_SVD_new1(cv::SVD **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::SVD;
    END_WRAP
}
CVAPI(ExceptionStatus) core_SVD_new2(cv::_InputArray *src, int flags, cv::SVD **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::SVD(*src, flags);
    END_WRAP
}
CVAPI(ExceptionStatus) core_SVD_delete(cv::SVD *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) core_SVD_operatorThis(cv::SVD *obj, cv::_InputArray *src, int flags)
{
    BEGIN_WRAP
    (*obj)(*src, flags);
    END_WRAP
}
//! performs back substitution, so that dst is the solution or pseudo-solution of m*dst = rhs, where m is the decomposed matrix
CVAPI(ExceptionStatus) core_SVD_backSubst(cv::SVD *obj, cv::_InputArray *rhs, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->backSubst(*rhs, *dst);
    END_WRAP
}

//! decomposes matrix and stores the results to user-provided matrices
CVAPI(ExceptionStatus) core_SVD_static_compute1(cv::_InputArray *src, cv::_OutputArray *w,
                                                cv::_OutputArray *u, cv::_OutputArray *vt, int flags)
{
    BEGIN_WRAP
    cv::SVD::compute(*src, *w, *u, *vt, flags);
    END_WRAP
}
//! computes singular values of a matrix
CVAPI(ExceptionStatus) core_SVD_static_compute2(cv::_InputArray *src, cv::_OutputArray *w, int flags)
{
    BEGIN_WRAP
    cv::SVD::compute(*src, *w, flags);
    END_WRAP
}
//! performs back substitution
CVAPI(ExceptionStatus) core_SVD_static_backSubst(cv::_InputArray *w, cv::_InputArray *u,
                                                 cv::_InputArray *vt, cv::_InputArray *rhs, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::SVD::backSubst(*w, *u, *vt, *rhs, *dst);
    END_WRAP
}
//! finds dst = arg min_{|dst|=1} |m*dst|
CVAPI(ExceptionStatus) core_SVD_static_solveZ(cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::SVD::solveZ(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SVD_u(cv::SVD *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->u);
    END_WRAP
}
CVAPI(ExceptionStatus) core_SVD_w(cv::SVD *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->w);
    END_WRAP
}
CVAPI(ExceptionStatus) core_SVD_vt(cv::SVD *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->vt);
    END_WRAP
}

#endif