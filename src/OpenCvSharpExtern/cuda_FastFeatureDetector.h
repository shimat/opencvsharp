#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudafeatures2d.hpp>

CVAPI(ExceptionStatus) cuda_createFastFeatureDetector(
    int threshold, int nonmaxSuppression, int type, int max_npoints,
    cv::Ptr<cv::cuda::FastFeatureDetector> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::FastFeatureDetector::create(threshold, nonmaxSuppression != 0, type, max_npoints);
    *returnValue = new cv::Ptr<cv::cuda::FastFeatureDetector>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FastFeatureDetector_get(
    cv::Ptr<cv::cuda::FastFeatureDetector> *ptr, cv::cuda::FastFeatureDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FastFeatureDetector_delete(cv::Ptr<cv::cuda::FastFeatureDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FastFeatureDetector_getMaxNumPoints(cv::cuda::FastFeatureDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMaxNumPoints();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FastFeatureDetector_setMaxNumPoints(cv::cuda::FastFeatureDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxNumPoints(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_FastFeatureDetector_setThreshold(cv::cuda::FastFeatureDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setThreshold(val);
    END_WRAP
}
