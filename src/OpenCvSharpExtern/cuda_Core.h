#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>

CVAPI(ExceptionStatus) cuda_convertFp16(
    cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::convertFp16(*src, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_registerPageLocked(cv::Mat *m)
{
    BEGIN_WRAP
    cv::cuda::registerPageLocked(*m);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_unregisterPageLocked(cv::Mat *m)
{
    BEGIN_WRAP
    cv::cuda::unregisterPageLocked(*m);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_setBufferPoolConfig(int deviceId, size_t stackSize, int stackCount)
{
    BEGIN_WRAP
    cv::cuda::setBufferPoolConfig(deviceId, stackSize, stackCount);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_setBufferPoolUsage(int on)
{
    BEGIN_WRAP
    cv::cuda::setBufferPoolUsage(on != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_createGpuMatFromCudaMemory(int rows, int cols, int type, void *cudaMemoryAddress, size_t step, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(rows, cols, type, cudaMemoryAddress, step);
    END_WRAP
}
