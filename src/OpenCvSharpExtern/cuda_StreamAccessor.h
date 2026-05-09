#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>


#if !defined(__CUDA_RUNTIME_H__)
#define __CUDA_RUNTIME_H__
// Standard CUDA type definitions
typedef struct CUstream_st *cudaStream_t;
typedef struct CUevent_st *cudaEvent_t;
#endif

#include <opencv2/core/cuda_stream_accessor.hpp>

CVAPI(ExceptionStatus) cuda_StreamAccessor_getStream(cv::cuda::Stream *obj, void **returnValue)
{
    BEGIN_WRAP
    cudaStream_t raw = cv::cuda::StreamAccessor::getStream(*obj);
    *returnValue = reinterpret_cast<void *>(raw);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StreamAccessor_wrapStream(void *rawHandle, cv::cuda::Stream **returnValue)
{
    BEGIN_WRAP
    cudaStream_t raw = reinterpret_cast<cudaStream_t>(rawHandle);
    cv::cuda::Stream stream = cv::cuda::StreamAccessor::wrapStream(raw);
    *returnValue = new cv::cuda::Stream(stream);
    END_WRAP
}
