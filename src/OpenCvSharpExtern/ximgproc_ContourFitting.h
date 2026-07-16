#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// ContourFitting

CVAPI(ExceptionStatus) ximgproc_Ptr_ContourFitting_delete(cv::Ptr<cv::ximgproc::ContourFitting>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_ContourFitting_get(cv::Ptr<cv::ximgproc::ContourFitting>* ptr, cv::ximgproc::ContourFitting** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_createContourFitting(int ctr, int fd, cv::Ptr<cv::ximgproc::ContourFitting>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createContourFitting(ctr, fd);
        *returnValue = new cv::Ptr<cv::ximgproc::ContourFitting>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_ContourFitting_estimateTransformation(
    cv::ximgproc::ContourFitting* obj,
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* dst,
    const interop::OutputArrayProxy* alphaPhiST,
    double* dist,
    int fdContour)
{
    return cvTry([&] {
        obj->estimateTransformation(InProxy(*src), InProxy(*dst), OutProxy(*alphaPhiST), *dist, fdContour != 0);
    });
}

CVAPI(ExceptionStatus) ximgproc_ContourFitting_setCtrSize(cv::ximgproc::ContourFitting* obj, int n)
{
    return cvTry([&] {
        obj->setCtrSize(n);
    });
}

CVAPI(ExceptionStatus) ximgproc_ContourFitting_setFDSize(cv::ximgproc::ContourFitting* obj, int n)
{
    return cvTry([&] {
        obj->setFDSize(n);
    });
}

CVAPI(ExceptionStatus) ximgproc_ContourFitting_getCtrSize(cv::ximgproc::ContourFitting* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getCtrSize();
    });
}

CVAPI(ExceptionStatus) ximgproc_ContourFitting_getFDSize(cv::ximgproc::ContourFitting* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getFDSize();
    });
}

// fourier_descriptors.hpp free functions

CVAPI(ExceptionStatus) ximgproc_fourierDescriptor(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int nbElt,
    int nbFD)
{
    return cvTry([&] {
        cv::ximgproc::fourierDescriptor(InProxy(*src), OutProxy(*dst), nbElt, nbFD);
    });
}

CVAPI(ExceptionStatus) ximgproc_transformFD(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* t,
    const interop::OutputArrayProxy* dst,
    int fdContour)
{
    return cvTry([&] {
        cv::ximgproc::transformFD(InProxy(*src), InProxy(*t), OutProxy(*dst), fdContour != 0);
    });
}

CVAPI(ExceptionStatus) ximgproc_contourSampling(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* out,
    int nbElt)
{
    return cvTry([&] {
        cv::ximgproc::contourSampling(InProxy(*src), OutProxy(*out), nbElt);
    });
}
