#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudalegacy.hpp>

// ---------- cuda_createImagePyramid --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createImagePyramid(
    cv::_InputArray *img, int nLayers, cv::cuda::Stream *stream,
    cv::Ptr<cv::cuda::ImagePyramid> **returnValue)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    auto ptr = cv::cuda::createImagePyramid(*img, nLayers, streamRef);
    *returnValue = new cv::Ptr<cv::cuda::ImagePyramid>(ptr);
    END_WRAP
}

// ---------- cuda_ImagePyramid_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_ImagePyramid_get(cv::Ptr<cv::cuda::ImagePyramid> *ptr, cv::cuda::ImagePyramid **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- cuda_ImagePyramid_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_ImagePyramid_delete(cv::Ptr<cv::cuda::ImagePyramid> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- cuda_ImagePyramid_getLayer --------------------------------------------------
CVAPI(ExceptionStatus) cuda_ImagePyramid_getLayer(cv::cuda::ImagePyramid *obj, cv::_OutputArray *outImg, cv::Size dsize, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->getLayer(*outImg, dsize, streamRef);
    END_WRAP
}
