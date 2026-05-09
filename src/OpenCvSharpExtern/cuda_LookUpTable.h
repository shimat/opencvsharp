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

// ---------- cuda_createLookUpTable ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_createLookUpTable(cv::_InputArray *lut, cv::Ptr<cv::cuda::LookUpTable> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createLookUpTable(*lut);
    *returnValue = new cv::Ptr<cv::cuda::LookUpTable>(ptr);
    END_WRAP
}

// ---------- cuda_LookUpTable_get ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_LookUpTable_get(cv::Ptr<cv::cuda::LookUpTable> *ptr, cv::cuda::LookUpTable **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- cuda_LookUpTable_delete ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_LookUpTable_delete(cv::Ptr<cv::cuda::LookUpTable> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- cuda_LookUpTable_transform ----------------------------------------------------
CVAPI(ExceptionStatus) cuda_LookUpTable_transform(cv::cuda::LookUpTable *obj, cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->transform(*src, *dst, streamRef);
    END_WRAP
}
