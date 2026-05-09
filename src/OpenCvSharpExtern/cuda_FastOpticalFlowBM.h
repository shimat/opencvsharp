#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudalegacy.hpp>

CVAPI(ExceptionStatus) cuda_FastOpticalFlowBM_compute(cv::cuda::GpuMat *I0, cv::cuda::GpuMat *I1, cv::cuda::GpuMat *flowx, cv::cuda::GpuMat *flowy, int search_window, int block_window, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::FastOpticalFlowBM handler;
    handler(*I0, *I1, *flowx, *flowy, search_window, block_window, streamRef);
    END_WRAP
}
