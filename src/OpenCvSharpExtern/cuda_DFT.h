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

// ---------- createDFT ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_createDFT(
    cv::Size dft_size, int flags, cv::Ptr<cv::cuda::DFT> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createDFT(dft_size, flags);
    *returnValue = new cv::Ptr<cv::cuda::DFT>(ptr);
    END_WRAP
}

// ---------- DFT_get ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_DFT_get(cv::Ptr<cv::cuda::DFT> *ptr, cv::cuda::DFT **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- FT_delete ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_DFT_delete(cv::Ptr<cv::cuda::DFT> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- cuda_DFT_compute ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_DFT_compute(cv::cuda::DFT *obj, cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->compute(*src, *dst, streamRef);
    END_WRAP
}
