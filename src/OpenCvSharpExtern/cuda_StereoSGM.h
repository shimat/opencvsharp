#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudastereo.hpp>

CVAPI(ExceptionStatus) cuda_createStereoSGM(int minDisparity, int numDisparities, int P1, int P2, int uniquenessRatio, int mode, cv::Ptr<cv::cuda::StereoSGM> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createStereoSGM(minDisparity, numDisparities, P1, P2, uniquenessRatio, mode);
    *returnValue = new cv::Ptr<cv::cuda::StereoSGM>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoSGM_get(cv::Ptr<cv::cuda::StereoSGM> *ptr, cv::cuda::StereoSGM **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_StereoSGM_delete(cv::Ptr<cv::cuda::StereoSGM> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}
