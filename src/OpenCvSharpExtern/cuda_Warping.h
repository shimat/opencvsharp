#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudawarping.hpp>

CVAPI(ExceptionStatus) cuda_buildWarpAffineMaps(cv::_InputArray *M, int inverse, cv::Size dsize, cv::_OutputArray *xmap, cv::_OutputArray *ymap, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::buildWarpAffineMaps(*M, inverse != 0, dsize, *xmap, *ymap, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_buildWarpPerspectiveMaps(cv::_InputArray *M, int inverse, cv::Size dsize, cv::_OutputArray *xmap, cv::_OutputArray *ymap, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::buildWarpPerspectiveMaps(*M, inverse != 0, dsize, *xmap, *ymap, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_pyrDown(cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::pyrDown(*src, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_pyrUp(cv::_InputArray *src, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::pyrUp(*src, *dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_remap( cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *xmap, cv::_InputArray *ymap, int interpolation, int borderMode, cv::Scalar borderValue, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::remap(*src, *dst, *xmap, *ymap, interpolation, borderMode, borderValue, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_resize(cv::_InputArray *src, cv::_OutputArray *dst, cv::Size dsize, double fx, double fy, int interpolation, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::resize(*src, *dst, dsize, fx, fy, interpolation, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_rotate(cv::_InputArray *src, cv::_OutputArray *dst, cv::Size dsize, double angle, double xShift, double yShift, int interpolation, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::rotate(*src, *dst, dsize, angle, xShift, yShift, interpolation, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_warpAffine(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *M, cv::Size dsize, int flags, int borderMode, cv::Scalar borderValue, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::warpAffine(*src, *dst, *M, dsize, flags, borderMode, borderValue, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_warpPerspective(cv::_InputArray *src, cv::_OutputArray *dst, cv::_InputArray *M, cv::Size dsize, int flags, int borderMode, cv::Scalar borderValue, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::warpPerspective(*src, *dst, *M, dsize, flags, borderMode, borderValue, streamRef);
    END_WRAP
}
