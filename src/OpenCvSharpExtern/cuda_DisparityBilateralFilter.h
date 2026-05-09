#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudastereo.hpp>

// ---------- createDisparityBilateralFilter --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createDisparityBilateralFilter(int ndisp, int radius, int iters, cv::Ptr<cv::cuda::DisparityBilateralFilter> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createDisparityBilateralFilter(ndisp, radius, iters);
    *returnValue = new cv::Ptr<cv::cuda::DisparityBilateralFilter>(ptr);
    END_WRAP
}

// ---------- DisparityBilateralFilter_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_get(cv::Ptr<cv::cuda::DisparityBilateralFilter> *ptr, cv::cuda::DisparityBilateralFilter **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- DisparityBilateralFilter_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_delete(cv::Ptr<cv::cuda::DisparityBilateralFilter> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- DisparityBilateralFilter_apply --------------------------------------------------
CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_apply(cv::cuda::DisparityBilateralFilter *obj, cv::_InputArray *disparity, cv::_InputArray *image, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->apply(*disparity, *image, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_getEdgeThreshold(cv::cuda::DisparityBilateralFilter *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getEdgeThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_setEdgeThreshold(cv::cuda::DisparityBilateralFilter *obj, float val)
{
    BEGIN_WRAP
    obj->setEdgeThreshold(val);
    END_WRAP
}

// --- MaxDiscThreshold ---
CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_getMaxDiscThreshold(cv::cuda::DisparityBilateralFilter *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getMaxDiscThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_setMaxDiscThreshold(cv::cuda::DisparityBilateralFilter *obj, float val)
{
    BEGIN_WRAP
    obj->setMaxDiscThreshold(val);
    END_WRAP
}

// --- NumDisparities ---
CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_getNumDisparities(cv::cuda::DisparityBilateralFilter *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumDisparities();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_setNumDisparities(cv::cuda::DisparityBilateralFilter *obj, int val)
{
    BEGIN_WRAP
    obj->setNumDisparities(val);
    END_WRAP
}

// --- NumIters ---
CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_getNumIters(cv::cuda::DisparityBilateralFilter *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumIters();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_setNumIters(cv::cuda::DisparityBilateralFilter *obj, int val)
{
    BEGIN_WRAP
    obj->setNumIters(val);
    END_WRAP
}

// --- Radius ---
CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_getRadius(cv::cuda::DisparityBilateralFilter *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getRadius();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_setRadius(cv::cuda::DisparityBilateralFilter *obj, int val)
{
    BEGIN_WRAP
    obj->setRadius(val);
    END_WRAP
}

// --- SigmaRange ---
CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_getSigmaRange(cv::cuda::DisparityBilateralFilter *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getSigmaRange();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DisparityBilateralFilter_setSigmaRange(cv::cuda::DisparityBilateralFilter *obj, float val)
{
    BEGIN_WRAP
    obj->setSigmaRange(val);
    END_WRAP
}
