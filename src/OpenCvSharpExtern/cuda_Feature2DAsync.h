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

CVAPI(ExceptionStatus) cuda_Feature2DAsync_detectAsync(
    cv::cuda::Feature2DAsync *obj, cv::_InputArray *image, cv::_OutputArray *keypoints,
    cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->detectAsync(*image, *keypoints, mask ? *mask : cv::noArray(), streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Feature2DAsync_computeAsync(
    cv::cuda::Feature2DAsync *obj, cv::_InputArray *image, cv::_OutputArray *keypoints,
    cv::_OutputArray *descriptors, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->computeAsync(*image, *keypoints, *descriptors, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Feature2DAsync_detectAndComputeAsync(
    cv::cuda::Feature2DAsync *obj, cv::_InputArray *image, cv::_InputArray *mask,
    cv::_OutputArray *keypoints, cv::_OutputArray *descriptors, int useProvidedKeypoints, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->detectAndComputeAsync(*image, *mask, *keypoints, *descriptors, useProvidedKeypoints != 0, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Feature2DAsync_convert(
    cv::cuda::Feature2DAsync *obj, cv::_InputArray *gpu_keypoints, std::vector<cv::KeyPoint> *keypoints)
{
    BEGIN_WRAP
    obj->convert(*gpu_keypoints, *keypoints);
    END_WRAP
}


