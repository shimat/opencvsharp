#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudaoptflow.hpp>
CVAPI(ExceptionStatus) cuda_DenseOpticalFlow_calc(
    cv::cuda::DenseOpticalFlow *obj,
    cv::_InputArray *I0,
    cv::_InputArray *I1,
    cv::_InputOutputArray *flow,
    cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->calc(*I0, *I1, *flow, streamRef);
    END_WRAP
}
