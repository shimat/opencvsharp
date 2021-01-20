#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region BackgroundSubtractorMOG

CVAPI(ExceptionStatus) bgsegm_createBackgroundSubtractorMOG(
    int history, int nmixtures, double backgroundRatio, double noiseSigma, cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::bgsegm::createBackgroundSubtractorMOG(history, nmixtures, backgroundRatio, noiseSigma);
    *returnValue = new cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG>(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorMOG_delete(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorMOG_get(
    cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, cv::bgsegm::BackgroundSubtractorMOG **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getHistory(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getHistory();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setHistory(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setHistory(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getNMixtures(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getNMixtures();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setNMixtures(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setNMixtures(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getBackgroundRatio();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setBackgroundRatio(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getNoiseSigma(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getNoiseSigma();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setNoiseSigma(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setNoiseSigma(value);
    END_WRAP
}

#pragma endregion

#pragma region BackgroundSubtractorGMG

CVAPI(ExceptionStatus) bgsegm_createBackgroundSubtractorGMG(
    int initializationFrames, double decisionThreshold, cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::bgsegm::createBackgroundSubtractorGMG(initializationFrames, decisionThreshold);
    *returnValue = new cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG>(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorGMG_delete(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorGMG_get(
    cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, cv::bgsegm::BackgroundSubtractorGMG **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getMaxFeatures(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getMaxFeatures();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setMaxFeatures(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setMaxFeatures(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getDefaultLearningRate();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setDefaultLearningRate(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getNumFrames(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getNumFrames();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setNumFrames(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setNumFrames(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getQuantizationLevels();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setQuantizationLevels(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getBackgroundPrior();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setBackgroundPrior(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getSmoothingRadius();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setSmoothingRadius(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getDecisionThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setDecisionThreshold(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getUpdateBackgroundModel() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setUpdateBackgroundModel(value != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getMinVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getMinVal();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setMinVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setMinVal(value);
    END_WRAP
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getMaxVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getMaxVal();
    END_WRAP
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setMaxVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setMaxVal(value);
    END_WRAP
}

#pragma endregion
