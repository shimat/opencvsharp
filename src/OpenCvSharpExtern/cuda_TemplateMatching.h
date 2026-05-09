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

// ---------- cuda_createTemplateMatching --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createTemplateMatching(int srcType, int method, cv::Size user_block_size, cv::Ptr<cv::cuda::TemplateMatching> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createTemplateMatching(srcType, method, user_block_size);
    *returnValue = new cv::Ptr<cv::cuda::TemplateMatching>(ptr);
    END_WRAP
}

// ---------- cuda_TemplateMatching_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_TemplateMatching_get(
    cv::Ptr<cv::cuda::TemplateMatching> *ptr, cv::cuda::TemplateMatching **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- cuda_TemplateMatching_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_TemplateMatching_delete(cv::Ptr<cv::cuda::TemplateMatching> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- cuda_TemplateMatching_match --------------------------------------------------
CVAPI(ExceptionStatus) cuda_TemplateMatching_match(cv::cuda::TemplateMatching *obj, cv::_InputArray *image, cv::_InputArray *templ, cv::_OutputArray *result, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->match(*image, *templ, *result, streamRef);
    END_WRAP
}
