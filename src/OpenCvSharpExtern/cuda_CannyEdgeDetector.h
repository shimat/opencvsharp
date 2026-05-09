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


// ---------- createCannyEdgeDetector --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createCannyEdgeDetector(double low_thresh, double high_thresh, int apperture_size, int L2gradient, cv::Ptr<cv::cuda::CannyEdgeDetector> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createCannyEdgeDetector(low_thresh, high_thresh, apperture_size, L2gradient != 0);
    *returnValue = new cv::Ptr<cv::cuda::CannyEdgeDetector>(ptr);
    END_WRAP
}

// ---------- CannyEdgeDetector_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_get(cv::Ptr<cv::cuda::CannyEdgeDetector> *ptr, cv::cuda::CannyEdgeDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- CannyEdgeDetector_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_delete(cv::Ptr<cv::cuda::CannyEdgeDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- CannyEdgeDetector_detect --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_detect(cv::cuda::CannyEdgeDetector *obj, cv::_InputArray *image, cv::_OutputArray *edges, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->detect(*image, *edges, streamRef);
    END_WRAP
}

// ---------- CannyEdgeDetector_detect_dxdy --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_detect_dxdy(cv::cuda::CannyEdgeDetector *obj, cv::_InputArray *dx, cv::_InputArray *dy, cv::_OutputArray *edges, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->detect(*dx, *dy, *edges, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_getAppertureSize(cv::cuda::CannyEdgeDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getAppertureSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_setAppertureSize(cv::cuda::CannyEdgeDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setAppertureSize(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_getHighThreshold(cv::cuda::CannyEdgeDetector *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getHighThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_setHighThreshold(cv::cuda::CannyEdgeDetector *obj, double val)
{
    BEGIN_WRAP
    obj->setHighThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_getL2Gradient(cv::cuda::CannyEdgeDetector *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getL2Gradient() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_setL2Gradient(cv::cuda::CannyEdgeDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setL2Gradient(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_getLowThreshold(cv::cuda::CannyEdgeDetector *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getLowThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CannyEdgeDetector_setLowThreshold(cv::cuda::CannyEdgeDetector *obj, double val)
{
    BEGIN_WRAP
    obj->setLowThreshold(val);
    END_WRAP
}
