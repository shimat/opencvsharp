#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>

CVAPI(ExceptionStatus) cuda_BufferPool_new(cv::cuda::Stream *stream, cv::cuda::BufferPool **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::BufferPool(*stream);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BufferPool_delete(cv::cuda::BufferPool *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BufferPool_getBuffer(
    cv::cuda::BufferPool *obj, int rows, int cols, int type, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    cv::cuda::GpuMat buffer = obj->getBuffer(rows, cols, type);
    *returnValue = new cv::cuda::GpuMat(buffer);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BufferPool_getAllocator(
    cv::cuda::BufferPool *obj, cv::Ptr<cv::cuda::GpuMat::Allocator> **returnValue)
{
    BEGIN_WRAP
    auto ptr = obj->getAllocator();
    *returnValue = new cv::Ptr<cv::cuda::GpuMat::Allocator>(ptr);
    END_WRAP
}
