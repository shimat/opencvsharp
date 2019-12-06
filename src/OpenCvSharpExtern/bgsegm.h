#ifndef _CPP_BGSEGM_H_
#define _CPP_BGSEGM_H_

#include "include_opencv.h"


#pragma region BackgroundSubtractorMOG

CVAPI(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG>*) bgsegm_createBackgroundSubtractorMOG(
    int history, int nmixtures,    double backgroundRatio, double noiseSigma)
{
    cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> ptr = cv::bgsegm::createBackgroundSubtractorMOG(history, nmixtures, backgroundRatio, noiseSigma);
    return new cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG>(ptr);
}
CVAPI(void) bgsegm_Ptr_BackgroundSubtractorMOG_delete(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *obj)
{
    delete obj;
}

CVAPI(cv::bgsegm::BackgroundSubtractorMOG*) bgsegm_Ptr_BackgroundSubtractorMOG_get(
    cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr)
{
    return ptr->get();
}

CVAPI(int) bgsegm_BackgroundSubtractorMOG_getHistory(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr)
{
    return (*ptr)->getHistory();
}
CVAPI(void) bgsegm_BackgroundSubtractorMOG_setHistory(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int value)
{
    (*ptr)->setHistory(value);
}

CVAPI(int) bgsegm_BackgroundSubtractorMOG_getNMixtures(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr)
{
    return (*ptr)->getNMixtures();
}
CVAPI(void) bgsegm_BackgroundSubtractorMOG_setNMixtures(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, int value)
{
    (*ptr)->setNMixtures(value);
}

CVAPI(double) bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr)
{
    return (*ptr)->getBackgroundRatio();
}
CVAPI(void) bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double value)
{
    (*ptr)->setBackgroundRatio(value);
}

CVAPI(double) bgsegm_BackgroundSubtractorMOG_getNoiseSigma(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr)
{
    return (*ptr)->getNoiseSigma();
}
CVAPI(void) bgsegm_BackgroundSubtractorMOG_setNoiseSigma(cv::Ptr<cv::bgsegm::BackgroundSubtractorMOG> *ptr, double value)
{
    (*ptr)->setNoiseSigma(value);
}

#pragma endregion

#pragma region BackgroundSubtractorGMG

CVAPI(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG>*) bgsegm_createBackgroundSubtractorGMG(
    int initializationFrames, double decisionThreshold)
{
    cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> ptr = cv::bgsegm::createBackgroundSubtractorGMG(initializationFrames, decisionThreshold);
    return new cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG>(ptr);
}
CVAPI(void) bgsegm_Ptr_BackgroundSubtractorGMG_delete(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *obj)
{
    delete obj;
}

CVAPI(cv::bgsegm::BackgroundSubtractorGMG*) bgsegm_Ptr_BackgroundSubtractorGMG_get(
    cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return ptr->get();
}

CVAPI(int) bgsegm_BackgroundSubtractorGMG_getMaxFeatures(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getMaxFeatures();
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setMaxFeatures(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    (*ptr)->setMaxFeatures(value);
}

CVAPI(double) bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getDefaultLearningRate();
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    (*ptr)->setDefaultLearningRate(value);
}

CVAPI(int) bgsegm_BackgroundSubtractorGMG_getNumFrames(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getNumFrames();
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setNumFrames(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    (*ptr)->setNumFrames(value);
}

CVAPI(int) bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getQuantizationLevels();
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    (*ptr)->setQuantizationLevels(value);
}

CVAPI(double) bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getBackgroundPrior();
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    (*ptr)->setBackgroundPrior(value);
}

CVAPI(int) bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getSmoothingRadius();
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    (*ptr)->setSmoothingRadius(value);
}

CVAPI(double) bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getDecisionThreshold();
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    (*ptr)->setDecisionThreshold(value);
}

CVAPI(int) bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getUpdateBackgroundModel() ? 1 : 0;
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, int value)
{
    (*ptr)->setUpdateBackgroundModel(value != 0);
}

CVAPI(double) bgsegm_BackgroundSubtractorGMG_getMinVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getMinVal();
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setMinVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    (*ptr)->setMinVal(value);
}

CVAPI(double) bgsegm_BackgroundSubtractorGMG_getMaxVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr)
{
    return (*ptr)->getMaxVal();
}
CVAPI(void) bgsegm_BackgroundSubtractorGMG_setMaxVal(cv::Ptr<cv::bgsegm::BackgroundSubtractorGMG> *ptr, double value)
{
    (*ptr)->setMaxVal(value);
}

#pragma endregion

#endif
