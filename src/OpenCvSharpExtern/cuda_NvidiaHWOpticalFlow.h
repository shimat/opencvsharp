#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaoptflow.hpp>

CVAPI(ExceptionStatus) cuda_NvidiaHWOpticalFlow_calc(
    cv::cuda::NvidiaHWOpticalFlow *obj,
    cv::_InputArray *inputImage,
    cv::_InputArray *referenceImage,
    cv::_InputOutputArray *flow,
    cv::cuda::Stream *stream,
    cv::_InputArray *hint,
    cv::_OutputArray *cost)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->calc(*inputImage, *referenceImage, *flow, streamRef,
              hint ? *hint : cv::noArray(),
              cost ? *cost : cv::noArray());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_NvidiaHWOpticalFlow_collectGarbage(cv::cuda::NvidiaHWOpticalFlow *obj)
{
    BEGIN_WRAP
    obj->collectGarbage();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_NvidiaHWOpticalFlow_getGridSize(cv::cuda::NvidiaHWOpticalFlow *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getGridSize();
    END_WRAP
}
