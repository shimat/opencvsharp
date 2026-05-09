#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudabgsegm.hpp>

// ---------- createBackgroundSubtractorMOG2 --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createBackgroundSubtractorMOG2(int history, double varThreshold, int detectShadows, cv::Ptr<cv::cuda::BackgroundSubtractorMOG2> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createBackgroundSubtractorMOG2(history, varThreshold, detectShadows != 0);
    *returnValue = new cv::Ptr<cv::cuda::BackgroundSubtractorMOG2>(ptr);
    END_WRAP
}

// ---------- BackgroundSubtractorMOG2_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG2_get(cv::Ptr<cv::cuda::BackgroundSubtractorMOG2> *ptr, cv::cuda::BackgroundSubtractorMOG2 **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- BackgroundSubtractorMOG2_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG2_delete(cv::Ptr<cv::cuda::BackgroundSubtractorMOG2> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- BackgroundSubtractorMOG2_apply --------------------------------------------------
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG2_apply(cv::cuda::BackgroundSubtractorMOG2 *obj, cv::_InputArray *image, cv::_OutputArray *fgmask, double learningRate, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->apply(*image, *fgmask, learningRate, streamRef);
    END_WRAP
}


CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG2_apply_withMask(
    cv::cuda::BackgroundSubtractorMOG2 *obj, cv::_InputArray *image,
    cv::_InputArray *knownForegroundMask, cv::_OutputArray *fgmask,
    double learningRate, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->apply(*image, *knownForegroundMask, *fgmask, learningRate, streamRef);
    END_WRAP
}

// --- Get Background Image (With Stream) ---
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG2_getBackgroundImage(
    cv::cuda::BackgroundSubtractorMOG2 *obj, cv::_OutputArray *backgroundImage, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->getBackgroundImage(*backgroundImage, streamRef);
    END_WRAP
}
