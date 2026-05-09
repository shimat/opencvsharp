#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaimgproc.hpp>

// ---------- cuda_createHoughLinesDetector --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createHoughLinesDetector(float rho, float theta, int threshold, int doSort, int maxLines, cv::Ptr<cv::cuda::HoughLinesDetector> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createHoughLinesDetector(rho, theta, threshold, doSort != 0, maxLines);
    *returnValue = new cv::Ptr<cv::cuda::HoughLinesDetector>(ptr);
    END_WRAP
}

// ---------- cuda_HoughLinesDetector_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_HoughLinesDetector_get(cv::Ptr<cv::cuda::HoughLinesDetector> *ptr, cv::cuda::HoughLinesDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- cuda_HoughLinesDetector_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_HoughLinesDetector_delete(cv::Ptr<cv::cuda::HoughLinesDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- cuda_HoughLinesDetector_detect --------------------------------------------------
CVAPI(ExceptionStatus) cuda_HoughLinesDetector_detect(cv::cuda::HoughLinesDetector *obj, cv::_InputArray *src, cv::_OutputArray *lines, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->detect(*src, *lines, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughLinesDetector_downloadResults(
    cv::cuda::HoughLinesDetector *obj,
    cv::_InputArray *d_lines,
    cv::_OutputArray *h_lines,
    cv::_OutputArray *h_votes,
    cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->downloadResults(*d_lines, *h_lines, h_votes ? *h_votes : cv::noArray(), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughLinesDetector_getDoSort(cv::cuda::HoughLinesDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getDoSort() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughLinesDetector_setDoSort(cv::cuda::HoughLinesDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setDoSort(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughLinesDetector_getMaxLines(cv::cuda::HoughLinesDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMaxLines();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughLinesDetector_setMaxLines(cv::cuda::HoughLinesDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxLines(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughLinesDetector_getRho(cv::cuda::HoughLinesDetector *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getRho();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughLinesDetector_setRho(cv::cuda::HoughLinesDetector *obj, float val)
{
    BEGIN_WRAP
    obj->setRho(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughLinesDetector_getTheta(cv::cuda::HoughLinesDetector *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getTheta();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughLinesDetector_setTheta(cv::cuda::HoughLinesDetector *obj, float val)
{
    BEGIN_WRAP
    obj->setTheta(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughLinesDetector_getThreshold(cv::cuda::HoughLinesDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughLinesDetector_setThreshold(cv::cuda::HoughLinesDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setThreshold(val);
    END_WRAP
}
