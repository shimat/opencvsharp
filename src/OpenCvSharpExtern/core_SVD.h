#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_SVD_new1(cv::SVD **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::SVD;
    });
}
CVAPI(ExceptionStatus) core_SVD_new2(cv::_InputArray *src, int flags, cv::SVD **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::SVD(*src, flags);
    });
}
CVAPI(ExceptionStatus) core_SVD_delete(cv::SVD *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) core_SVD_operatorThis(cv::SVD *obj, cv::_InputArray *src, int flags)
{
    return cvTry([&] {
    (*obj)(*src, flags);
    });
}
//! performs back substitution, so that dst is the solution or pseudo-solution of m*dst = rhs, where m is the decomposed matrix
CVAPI(ExceptionStatus) core_SVD_backSubst(cv::SVD *obj, cv::_InputArray *rhs, cv::_OutputArray *dst)
{
    return cvTry([&] {
    obj->backSubst(*rhs, *dst);
    });
}

//! decomposes matrix and stores the results to user-provided matrices
CVAPI(ExceptionStatus) core_SVD_static_compute1(cv::_InputArray *src, cv::_OutputArray *w,
                                                cv::_OutputArray *u, cv::_OutputArray *vt, int flags)
{
    return cvTry([&] {
    cv::SVD::compute(*src, *w, *u, *vt, flags);
    });
}
//! computes singular values of a matrix
CVAPI(ExceptionStatus) core_SVD_static_compute2(cv::_InputArray *src, cv::_OutputArray *w, int flags)
{
    return cvTry([&] {
    cv::SVD::compute(*src, *w, flags);
    });
}
//! performs back substitution
CVAPI(ExceptionStatus) core_SVD_static_backSubst(cv::_InputArray *w, cv::_InputArray *u,
                                                 cv::_InputArray *vt, cv::_InputArray *rhs, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::SVD::backSubst(*w, *u, *vt, *rhs, *dst);
    });
}
//! finds dst = arg min_{|dst|=1} |m*dst|
CVAPI(ExceptionStatus) core_SVD_static_solveZ(cv::_InputArray *src, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::SVD::solveZ(*src, *dst);
    });
}

CVAPI(ExceptionStatus) core_SVD_u(cv::SVD *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(obj->u);
    });
}
CVAPI(ExceptionStatus) core_SVD_w(cv::SVD *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(obj->w);
    });
}
CVAPI(ExceptionStatus) core_SVD_vt(cv::SVD *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(obj->vt);
    });
}
