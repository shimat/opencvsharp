#pragma once

// OpenCV 5: kept available in every profile (including slim); see include_opencv.h.

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region BackgroundSubtractorMOG

CVAPI(ExceptionStatus) bgsegm_createBackgroundSubtractorMOG(
    int history,
    int nmixtures,
    double backgroundRatio,
    double noiseSigma,
    cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::bgsegm::createBackgroundSubtractorMOG(history, nmixtures, backgroundRatio, noiseSigma);
        *returnValue = new cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG>(ptr);
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorMOG_get(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *obj, cv::bgsegm::BackgroundSubtractorMOG **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorMOG_delete(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getHistory(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getHistory();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setHistory(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int value)
{
    return cvTry([&] {
        (*ptr)->setHistory(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getNMixtures(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getNMixtures();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setNMixtures(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int value)
{
    return cvTry([&] {
        (*ptr)->setNMixtures(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getBackgroundRatio();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double value)
{
    return cvTry([&] {
        (*ptr)->setBackgroundRatio(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getNoiseSigma(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getNoiseSigma();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setNoiseSigma(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double value)
{
    return cvTry([&] {
        (*ptr)->setNoiseSigma(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_apply(
    cv::bgsegm::BackgroundSubtractorMOG *obj,
    const interop::InputArrayProxy* image,
    const interop::OutputArrayProxy* fgmask,
    double learningRate)
{
    return cvTry([&] {
        obj->apply(InProxy(*image), OutProxy(*fgmask), learningRate);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getBackgroundImage(cv::bgsegm::BackgroundSubtractorMOG *obj, const interop::OutputArrayProxy* backgroundImage)
{
    return cvTry([&] {
        obj->getBackgroundImage(OutProxy(*backgroundImage));
    });
}

#pragma endregion

#pragma region BackgroundSubtractorGMG

CVAPI(ExceptionStatus) bgsegm_createBackgroundSubtractorGMG(
    int initializationFrames,
    double decisionThreshold,
    cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::bgsegm::createBackgroundSubtractorGMG(initializationFrames, decisionThreshold);
        *returnValue = new cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG>(ptr);
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorGMG_get(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *obj, cv::bgsegm::BackgroundSubtractorGMG **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorGMG_delete(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getMaxFeatures(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getMaxFeatures();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setMaxFeatures(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    return cvTry([&] {
        (*ptr)->setMaxFeatures(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getDefaultLearningRate();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    return cvTry([&] {
        (*ptr)->setDefaultLearningRate(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getNumFrames(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getNumFrames();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setNumFrames(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    return cvTry([&] {
        (*ptr)->setNumFrames(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getQuantizationLevels();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    return cvTry([&] {
        (*ptr)->setQuantizationLevels(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getBackgroundPrior();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    return cvTry([&] {
        (*ptr)->setBackgroundPrior(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getSmoothingRadius();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    return cvTry([&] {
        (*ptr)->setSmoothingRadius(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getDecisionThreshold();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    return cvTry([&] {
        (*ptr)->setDecisionThreshold(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getUpdateBackgroundModel() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    return cvTry([&] {
        (*ptr)->setUpdateBackgroundModel(value != 0);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getMinVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getMinVal();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setMinVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    return cvTry([&] {
        (*ptr)->setMinVal(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getMaxVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = (*ptr)->getMaxVal();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setMaxVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    return cvTry([&] {
        (*ptr)->setMaxVal(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_apply(
    cv::bgsegm::BackgroundSubtractorGMG *obj,
    const interop::InputArrayProxy* image,
    const interop::OutputArrayProxy* fgmask,
    double learningRate)
{
    return cvTry([&] {
        obj->apply(InProxy(*image), OutProxy(*fgmask), learningRate);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getBackgroundImage(cv::bgsegm::BackgroundSubtractorGMG *obj, const interop::OutputArrayProxy* backgroundImage)
{
    return cvTry([&] {
        obj->getBackgroundImage(OutProxy(*backgroundImage));
    });
}

#pragma endregion

// (no NO_CONTRIB guard: kept in every profile for OpenCV 5)
