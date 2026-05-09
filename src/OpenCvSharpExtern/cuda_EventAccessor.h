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

// Extract raw cudaEvent_t from cv::cuda::Event
CVAPI(ExceptionStatus) cuda_Event_getEvent(cv::cuda::Event *obj, void **returnValue)
{
    BEGIN_WRAP
    // This will now compile because it's in the stream_accessor header
    cudaEvent_t raw = cv::cuda::EventAccessor::getEvent(*obj);
    *returnValue = reinterpret_cast<void *>(raw);
    END_WRAP
}

// Wrap raw cudaEvent_t into cv::cuda::Event
CVAPI(ExceptionStatus) cuda_Event_wrapEvent(void *rawHandle, cv::cuda::Event **returnValue)
{
    BEGIN_WRAP
    cudaEvent_t raw = reinterpret_cast<cudaEvent_t>(rawHandle);
    cv::cuda::Event ev = cv::cuda::EventAccessor::wrapEvent(raw);

    *returnValue = new cv::cuda::Event(ev);
    END_WRAP
}
