#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/photo/cuda.hpp>

CVAPI(ExceptionStatus) cuda_fastNlMeansDenoising(cv::_InputArray *src, cv::_OutputArray *dst, float h, int search_window, int block_size, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::fastNlMeansDenoising(*src, *dst, h, search_window, block_size, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_fastNlMeansDenoisingColored(cv::_InputArray *src, cv::_OutputArray *dst, float h_luminance, float photo_render, int search_window, int block_size, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::fastNlMeansDenoisingColored(*src, *dst, h_luminance, photo_render, search_window, block_size, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_nonLocalMeans(cv::_InputArray *src, cv::_OutputArray *dst, float h, int search_window, int block_size, int borderMode, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::nonLocalMeans(*src, *dst, h, search_window, block_size, borderMode, streamRef);
    END_WRAP
}
