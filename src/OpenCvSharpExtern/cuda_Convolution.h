#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaarithm.hpp>

// ---------- createConvolution ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_createConvolution(cv::Size user_block_size, cv::Ptr<cv::cuda::Convolution> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createConvolution(user_block_size);
    *returnValue = new cv::Ptr<cv::cuda::Convolution>(ptr);
    END_WRAP
}

// ---------- Convolution_get ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_Convolution_get(cv::Ptr<cv::cuda::Convolution> *ptr, cv::cuda::Convolution **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- Convolution_delete ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_Convolution_delete(cv::Ptr<cv::cuda::Convolution> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- Convolution_convolve ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_Convolution_convolve(cv::cuda::Convolution *obj, cv::_InputArray *image, cv::_InputArray *templ, cv::_OutputArray *result, int conj, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->convolve(*image, *templ, *result, conj != 0, streamRef);
    END_WRAP
}
