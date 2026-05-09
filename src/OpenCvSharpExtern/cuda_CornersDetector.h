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

// ---------- createGoodFeaturesToTrackDetector --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createGoodFeaturesToTrackDetector(int srcType, int maxCorners, double qualityLevel, double minDistance, int blockSize, int useHarrisDetector, double harrisK, cv::Ptr<cv::cuda::CornersDetector> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createGoodFeaturesToTrackDetector(srcType, maxCorners, qualityLevel, minDistance, blockSize, useHarrisDetector != 0, harrisK);
    *returnValue = new cv::Ptr<cv::cuda::CornersDetector>(ptr);
    END_WRAP
}

// ---------- CornersDetector_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CornersDetector_get(cv::Ptr<cv::cuda::CornersDetector> *ptr, cv::cuda::CornersDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- CornersDetector_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CornersDetector_delete(cv::Ptr<cv::cuda::CornersDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- CornersDetector_detect --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CornersDetector_detect(cv::cuda::CornersDetector *obj, cv::_InputArray *image, cv::_OutputArray *corners, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->detect(*image, *corners, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CornersDetector_setMinDistance( cv::cuda::CornersDetector *obj, double val)
{
    BEGIN_WRAP
    obj->setMinDistance(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_CornersDetector_setMaxCorners(cv::cuda::CornersDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxCorners(val);
    END_WRAP
}
