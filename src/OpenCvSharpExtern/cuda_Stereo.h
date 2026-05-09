#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudastereo.hpp>

// ---------- cuda_StereoConstantSpaceBP_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_drawColorDisp(cv::_InputArray *src_disp, cv::_OutputArray *dst_disp, int ndisp, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::drawColorDisp(*src_disp, *dst_disp, ndisp, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_reprojectImageTo3D(cv::_InputArray *disp, cv::_OutputArray *xyzw, cv::_InputArray *Q, int dst_cn, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::reprojectImageTo3D(*disp, *xyzw, *Q, dst_cn, streamRef);
    END_WRAP
}



