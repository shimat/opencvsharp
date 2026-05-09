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

// ---------- createGeneralizedHoughBallard --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createGeneralizedHoughGuil(cv::Ptr<cv::GeneralizedHoughGuil> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createGeneralizedHoughGuil();
    *returnValue = new cv::Ptr<cv::GeneralizedHoughGuil>(ptr);
    END_WRAP
}
