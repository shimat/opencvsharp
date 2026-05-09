#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaimgproc.hpp>

// ---------- cuda_createHarrisCorner --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createHarrisCorner(int srcType, int blockSize, int ksize, double k, int borderType, cv::Ptr<cv::cuda::CornernessCriteria> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createHarrisCorner(srcType, blockSize, ksize, k, borderType);
    *returnValue = new cv::Ptr<cv::cuda::CornernessCriteria>(ptr);
    END_WRAP
}

// ---------- cuda_CornernessCriteria_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CornernessCriteria_get(cv::Ptr<cv::cuda::CornernessCriteria> *ptr, cv::cuda::CornernessCriteria **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- cuda_CornernessCriteria_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CornernessCriteria_delete(cv::Ptr<cv::cuda::CornernessCriteria> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- cuda_CornernessCriteria_compute --------------------------------------------------
CVAPI(ExceptionStatus) cuda_CornernessCriteria_compute(cv::cuda::CornernessCriteria *obj, cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->compute(*src, *dst, streamRef);
    END_WRAP
}

// ---------- cuda_createMinEigenValCorner --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createMinEigenValCorner(int srcType, int blockSize, int ksize, int borderType, cv::Ptr<cv::cuda::CornernessCriteria> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createMinEigenValCorner(srcType, blockSize, ksize, borderType);
    *returnValue = new cv::Ptr<cv::cuda::CornernessCriteria>(ptr);
    END_WRAP
}
