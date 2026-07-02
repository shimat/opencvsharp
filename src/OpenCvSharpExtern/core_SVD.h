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
CVAPI(ExceptionStatus) core_SVD_new2(
    const interop::InputArrayProxy* src,
    int flags,
    cv::SVD **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::SVD(InProxy(*src), flags);
    });
}
CVAPI(ExceptionStatus) core_SVD_delete(cv::SVD *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) core_SVD_operatorThis(
    cv::SVD *obj,
    const interop::InputArrayProxy* src,
    int flags)
{
    return cvTry([&] {
    (*obj)(InProxy(*src), flags);
    });
}
//! performs back substitution, so that dst is the solution or pseudo-solution of m*dst = rhs, where m is the decomposed matrix
CVAPI(ExceptionStatus) core_SVD_backSubst(
    cv::SVD *obj,
    const interop::InputArrayProxy* rhs,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
    obj->backSubst(InProxy(*rhs), OutProxy(*dst));
    });
}

//! decomposes matrix and stores the results to user-provided matrices
CVAPI(ExceptionStatus) core_SVD_static_compute1(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* w,
    const interop::OutputArrayProxy* u,
    const interop::OutputArrayProxy* vt,
    int flags)
{
    return cvTry([&] {
    cv::SVD::compute(InProxy(*src), OutProxy(*w), OutProxy(*u), OutProxy(*vt), flags);
    });
}
//! computes singular values of a matrix
CVAPI(ExceptionStatus) core_SVD_static_compute2(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* w,
    int flags)
{
    return cvTry([&] {
    cv::SVD::compute(InProxy(*src), OutProxy(*w), flags);
    });
}
//! performs back substitution
CVAPI(ExceptionStatus) core_SVD_static_backSubst(
    const interop::InputArrayProxy* w,
    const interop::InputArrayProxy* u,
    const interop::InputArrayProxy* vt,
    const interop::InputArrayProxy* rhs,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
    cv::SVD::backSubst(InProxy(*w), InProxy(*u), InProxy(*vt), InProxy(*rhs), OutProxy(*dst));
    });
}
//! finds dst = arg min_{|dst|=1} |m*dst|
CVAPI(ExceptionStatus) core_SVD_static_solveZ(const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
    cv::SVD::solveZ(InProxy(*src), OutProxy(*dst));
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
