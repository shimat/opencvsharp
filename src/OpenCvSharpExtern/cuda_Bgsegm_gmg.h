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

// ---------- createBackgroundSubtractorGMG --------------------------------------------------
CVAPI(ExceptionStatus) cuda_createBackgroundSubtractorGMG(int initializationFrames, double decisionThreshold, cv::Ptr<cv::cuda::BackgroundSubtractorGMG> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::createBackgroundSubtractorGMG(initializationFrames, decisionThreshold);
    *returnValue = new cv::Ptr<cv::cuda::BackgroundSubtractorGMG>(ptr);
    END_WRAP
}

// ---------- BackgroundSubtractorGMG_get --------------------------------------------------
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_get(cv::Ptr<cv::cuda::BackgroundSubtractorGMG> *ptr, cv::cuda::BackgroundSubtractorGMG **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

// ---------- BackgroundSubtractorGMG_delete --------------------------------------------------
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_delete(cv::Ptr<cv::cuda::BackgroundSubtractorGMG> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

// ---------- BackgroundSubtractorGMG_apply --------------------------------------------------
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_apply(cv::cuda::BackgroundSubtractorGMG *obj, cv::_InputArray *image, cv::_OutputArray *fgmask, double learningRate, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->apply(*image, *fgmask, learningRate, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_apply_withMask(cv::cuda::BackgroundSubtractorGMG *obj, cv::_InputArray *image, cv::_InputArray *knownForegroundMask, cv::_OutputArray *fgmask, double learningRate, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->apply(*image, *knownForegroundMask, *fgmask, learningRate, streamRef);
    END_WRAP
}

// --- Properties (Getters / Setters) ---
CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getBackgroundPrior(cv::cuda::BackgroundSubtractorGMG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getBackgroundPrior();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setBackgroundPrior(cv::cuda::BackgroundSubtractorGMG *obj, double val)
{
    BEGIN_WRAP
    obj->setBackgroundPrior(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getDecisionThreshold(cv::cuda::BackgroundSubtractorGMG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getDecisionThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setDecisionThreshold(cv::cuda::BackgroundSubtractorGMG *obj, double val)
{
    BEGIN_WRAP
    obj->setDecisionThreshold(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getDefaultLearningRate(cv::cuda::BackgroundSubtractorGMG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getDefaultLearningRate();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setDefaultLearningRate(cv::cuda::BackgroundSubtractorGMG *obj, double val)
{
    BEGIN_WRAP
    obj->setDefaultLearningRate(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getMaxFeatures(cv::cuda::BackgroundSubtractorGMG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getMaxFeatures();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setMaxFeatures(cv::cuda::BackgroundSubtractorGMG *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxFeatures(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getMaxVal(cv::cuda::BackgroundSubtractorGMG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getMaxVal();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setMaxVal(cv::cuda::BackgroundSubtractorGMG *obj, double val)
{
    BEGIN_WRAP
    obj->setMaxVal(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getMinVal(cv::cuda::BackgroundSubtractorGMG *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->getMinVal();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setMinVal(cv::cuda::BackgroundSubtractorGMG *obj, double val)
{
    BEGIN_WRAP
    obj->setMinVal(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getNumFrames(cv::cuda::BackgroundSubtractorGMG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getNumFrames();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setNumFrames(cv::cuda::BackgroundSubtractorGMG *obj, int val)
{
    BEGIN_WRAP
    obj->setNumFrames(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getQuantizationLevels(cv::cuda::BackgroundSubtractorGMG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getQuantizationLevels();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setQuantizationLevels(cv::cuda::BackgroundSubtractorGMG *obj, int val)
{
    BEGIN_WRAP
    obj->setQuantizationLevels(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getSmoothingRadius(cv::cuda::BackgroundSubtractorGMG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getSmoothingRadius();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setSmoothingRadius(cv::cuda::BackgroundSubtractorGMG *obj, int val)
{
    BEGIN_WRAP
    obj->setSmoothingRadius(val);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_getUpdateBackgroundModel(cv::cuda::BackgroundSubtractorGMG *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->getUpdateBackgroundModel() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_BackgroundSubtractorGMG_setUpdateBackgroundModel(cv::cuda::BackgroundSubtractorGMG *obj, int val)
{
    BEGIN_WRAP
    obj->setUpdateBackgroundModel(val != 0);
    END_WRAP
}

