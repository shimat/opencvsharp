#pragma once

// -----------------------------------------------------------------------
// OpenCvSharpExtern – cv::cuda arithmetic wrappers
// These are the C-linkage functions that the C# P/Invoke layer calls.
// Each function catches cv::Exception, stores it, and returns an
// ExceptionStatus so managed code can rethrow it as a .NET exception.
// -----------------------------------------------------------------------

#include "include_opencv.h"
#include <opencv2/cudabgsegm.hpp>

// ---------- createBackgroundSubtractorMOG --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createBackgroundSubtractorMOG(int history, int nmixtures, double backgroundRatio, double noiseSigma, cv::Ptr<cv::cuda::BackgroundSubtractorMOG> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createBackgroundSubtractorMOG(history, nmixtures, backgroundRatio, noiseSigma);
    *returnValue = new cv::Ptr<cv::cuda::BackgroundSubtractorMOG>(ptr);
    END_WRAP
}

// ---------- BackgroundSubtractorMOG_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_get(cv::Ptr<cv::cuda::BackgroundSubtractorMOG> *ptr, cv::cuda::BackgroundSubtractorMOG **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- BackgroundSubtractorMOG_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_delete(cv::Ptr<cv::cuda::BackgroundSubtractorMOG> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- BackgroundSubtractorMOG_apply --------------------------------------------------
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_apply(cv::cuda::BackgroundSubtractorMOG *obj, cv::_InputArray *image, cv::_OutputArray *fgmask, double learningRate, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->apply(*image, *fgmask, learningRate, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_apply_withMask(
    cv::cuda::BackgroundSubtractorMOG *obj, cv::_InputArray *image,
    cv::_InputArray *knownForegroundMask, cv::_OutputArray *fgmask,
    double learningRate, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->apply(*image, *knownForegroundMask, *fgmask, learningRate, streamRef);
    END_WRAP
}

// --- Get Background Image (With Stream) ---
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_getBackgroundImage(
    cv::cuda::BackgroundSubtractorMOG *obj, cv::_OutputArray *backgroundImage, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->getBackgroundImage(*backgroundImage, streamRef);
    END_WRAP
}

// --- Properties (Getters / Setters) ---
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_getBackgroundRatio(cv::cuda::BackgroundSubtractorMOG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getBackgroundRatio();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_setBackgroundRatio(cv::cuda::BackgroundSubtractorMOG *obj, double val)
{
    BEGIN_WRAP
    obj->setBackgroundRatio(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_getHistory(cv::cuda::BackgroundSubtractorMOG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getHistory();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_setHistory(cv::cuda::BackgroundSubtractorMOG *obj, int val)
{
    BEGIN_WRAP
    obj->setHistory(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_getNMixtures(cv::cuda::BackgroundSubtractorMOG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNMixtures();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_setNMixtures(cv::cuda::BackgroundSubtractorMOG *obj, int val)
{
    BEGIN_WRAP
    obj->setNMixtures(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_getNoiseSigma(cv::cuda::BackgroundSubtractorMOG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getNoiseSigma();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorMOG_setNoiseSigma(cv::cuda::BackgroundSubtractorMOG *obj, double val)
{
    BEGIN_WRAP
    obj->setNoiseSigma(val);
    END_WRAP
}
