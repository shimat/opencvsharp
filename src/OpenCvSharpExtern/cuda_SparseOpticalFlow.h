#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaoptflow.hpp>

CVAPI(ExceptionStatus) cuda_SparseOpticalFlow_calc(
    cv::cuda::SparseOpticalFlow *obj,
    cv::_InputArray *prevImg,
    cv::_InputArray *nextImg,
    cv::_InputArray *prevPts,
    cv::_InputOutputArray *nextPts,
    cv::_OutputArray *status,
    cv::_OutputArray *err,
    cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->calc(*prevImg, *nextImg, *prevPts, *nextPts, *status, err ? *err : cv::noArray(), streamRef);
    END_WRAP
}
