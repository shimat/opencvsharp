#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>

CVAPI(ExceptionStatus) cuda_Stream_new1(cv::cuda::Stream **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::Stream();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_new2(cv::cuda::Stream *s, cv::cuda::Stream **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::Stream(*s);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_new3(size_t flags, cv::cuda::Stream **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::Stream(flags);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_delete(cv::cuda::Stream *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_opAssign(cv::cuda::Stream *left, cv::cuda::Stream *right)
{
    BEGIN_WRAP
    *left = *right;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_queryIfComplete(cv::cuda::Stream *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->queryIfComplete() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_waitForCompletion(cv::cuda::Stream *obj)
{
    BEGIN_WRAP
    obj->waitForCompletion();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_enqueueHostCallback(cv::cuda::Stream *obj, cv::cuda::Stream::StreamCallback callback, void *userData)
{
    BEGIN_WRAP
    obj->enqueueHostCallback(callback, userData);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_Null(cv::cuda::Stream **returnValue)
{
    BEGIN_WRAP
    *returnValue = const_cast<cv::cuda::Stream *>(&cv::cuda::Stream::Null());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_bool(cv::cuda::Stream *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (bool)(*obj) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_wrapStream(size_t cudaStreamMemoryAddress, cv::cuda::Stream **returnValue)
{
    BEGIN_WRAP
    // cv::cuda::wrapStream takes size_t, casts it to cudaStream_t internally
    // This is OpenCV's own public API for this exact use case
    *returnValue = new cv::cuda::Stream(cv::cuda::wrapStream(cudaStreamMemoryAddress));
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_cudaPtr(cv::cuda::Stream *obj, void **returnValue)
{
    BEGIN_WRAP
        if (obj == NULL)
        {
            *returnValue = NULL;
        }
        else
        {
            *returnValue = obj->cudaPtr();
        }
        
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_Stream_waitEvent(cv::cuda::Stream *obj, cv::cuda::Event *event)
{
    BEGIN_WRAP
    obj->waitEvent(*event);
    END_WRAP
}
