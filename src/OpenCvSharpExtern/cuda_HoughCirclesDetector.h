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

// ---------- cuda_createHoughCirclesDetector --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createHoughCirclesDetector(float dp, float minDist, int cannyThreshold, int votesThreshold, int minRadius, int maxRadius, int maxCircles, cv::Ptr<cv::cuda::HoughCirclesDetector> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createHoughCirclesDetector(dp, minDist, cannyThreshold, votesThreshold, minRadius, maxRadius, maxCircles);
    *returnValue = new cv::Ptr<cv::cuda::HoughCirclesDetector>(ptr);
    END_WRAP
}

// ---------- cuda_HoughCirclesDetector_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_get(cv::Ptr<cv::cuda::HoughCirclesDetector> *ptr, cv::cuda::HoughCirclesDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- cuda_HoughCirclesDetector_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_delete(cv::Ptr<cv::cuda::HoughCirclesDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- cuda_HoughCirclesDetector_detect --------------------------------------------------
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_detect(cv::cuda::HoughCirclesDetector *obj, cv::_InputArray *src, cv::_OutputArray *circles, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->detect(*src, *circles, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_getCannyThreshold(cv::cuda::HoughCirclesDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getCannyThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_setCannyThreshold(cv::cuda::HoughCirclesDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setCannyThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_getDp(cv::cuda::HoughCirclesDetector *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getDp();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_setDp(cv::cuda::HoughCirclesDetector *obj, float val)
{
    BEGIN_WRAP
    obj->setDp(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_getMaxCircles(cv::cuda::HoughCirclesDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMaxCircles();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_setMaxCircles(cv::cuda::HoughCirclesDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxCircles(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_getMaxRadius(cv::cuda::HoughCirclesDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMaxRadius();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_setMaxRadius(cv::cuda::HoughCirclesDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxRadius(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_getMinDist(cv::cuda::HoughCirclesDetector *obj, float *val)
{
    BEGIN_WRAP
    *val = obj->getMinDist();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_setMinDist(cv::cuda::HoughCirclesDetector *obj, float val)
{
    BEGIN_WRAP
    obj->setMinDist(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_getMinRadius(cv::cuda::HoughCirclesDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMinRadius();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_setMinRadius(cv::cuda::HoughCirclesDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setMinRadius(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_getVotesThreshold(cv::cuda::HoughCirclesDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getVotesThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_HoughCirclesDetector_setVotesThreshold(cv::cuda::HoughCirclesDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setVotesThreshold(val);
    END_WRAP
}
