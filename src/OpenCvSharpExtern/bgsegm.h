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


CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getHistory(cv::bgsegm::BackgroundSubtractorMOG *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getHistory();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setHistory(cv::bgsegm::BackgroundSubtractorMOG *ptr, int value)
{
    return cvTry([&] {
        ptr->setHistory(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getNMixtures(cv::bgsegm::BackgroundSubtractorMOG *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getNMixtures();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setNMixtures(cv::bgsegm::BackgroundSubtractorMOG *ptr, int value)
{
    return cvTry([&] {
        ptr->setNMixtures(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getBackgroundRatio(cv::bgsegm::BackgroundSubtractorMOG *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getBackgroundRatio();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setBackgroundRatio(cv::bgsegm::BackgroundSubtractorMOG *ptr, double value)
{
    return cvTry([&] {
        ptr->setBackgroundRatio(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_getNoiseSigma(cv::bgsegm::BackgroundSubtractorMOG *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getNoiseSigma();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorMOG_setNoiseSigma(cv::bgsegm::BackgroundSubtractorMOG *ptr, double value)
{
    return cvTry([&] {
        ptr->setNoiseSigma(value);
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


CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getMaxFeatures(cv::bgsegm::BackgroundSubtractorGMG *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getMaxFeatures();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setMaxFeatures(cv::bgsegm::BackgroundSubtractorGMG *ptr, int value)
{
    return cvTry([&] {
        ptr->setMaxFeatures(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getDefaultLearningRate(cv::bgsegm::BackgroundSubtractorGMG *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getDefaultLearningRate();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setDefaultLearningRate(cv::bgsegm::BackgroundSubtractorGMG *ptr, double value)
{
    return cvTry([&] {
        ptr->setDefaultLearningRate(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getNumFrames(cv::bgsegm::BackgroundSubtractorGMG *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getNumFrames();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setNumFrames(cv::bgsegm::BackgroundSubtractorGMG *ptr, int value)
{
    return cvTry([&] {
        ptr->setNumFrames(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getQuantizationLevels(cv::bgsegm::BackgroundSubtractorGMG *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getQuantizationLevels();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setQuantizationLevels(cv::bgsegm::BackgroundSubtractorGMG *ptr, int value)
{
    return cvTry([&] {
        ptr->setQuantizationLevels(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getBackgroundPrior(cv::bgsegm::BackgroundSubtractorGMG *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getBackgroundPrior();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setBackgroundPrior(cv::bgsegm::BackgroundSubtractorGMG *ptr, double value)
{
    return cvTry([&] {
        ptr->setBackgroundPrior(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getSmoothingRadius(cv::bgsegm::BackgroundSubtractorGMG *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getSmoothingRadius();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setSmoothingRadius(cv::bgsegm::BackgroundSubtractorGMG *ptr, int value)
{
    return cvTry([&] {
        ptr->setSmoothingRadius(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getDecisionThreshold(cv::bgsegm::BackgroundSubtractorGMG *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getDecisionThreshold();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setDecisionThreshold(cv::bgsegm::BackgroundSubtractorGMG *ptr, double value)
{
    return cvTry([&] {
        ptr->setDecisionThreshold(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getUpdateBackgroundModel(cv::bgsegm::BackgroundSubtractorGMG *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getUpdateBackgroundModel() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setUpdateBackgroundModel(cv::bgsegm::BackgroundSubtractorGMG *ptr, int value)
{
    return cvTry([&] {
        ptr->setUpdateBackgroundModel(value != 0);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getMinVal(cv::bgsegm::BackgroundSubtractorGMG *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getMinVal();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setMinVal(cv::bgsegm::BackgroundSubtractorGMG *ptr, double value)
{
    return cvTry([&] {
        ptr->setMinVal(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_getMaxVal(cv::bgsegm::BackgroundSubtractorGMG *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getMaxVal();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorGMG_setMaxVal(cv::bgsegm::BackgroundSubtractorGMG *ptr, double value)
{
    return cvTry([&] {
        ptr->setMaxVal(value);
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

#pragma region BackgroundSubtractorCNT

CVAPI(ExceptionStatus) bgsegm_createBackgroundSubtractorCNT(
    int minPixelStability,
    int useHistory,
    int maxPixelStability,
    int isParallel,
    cv::Ptr<cv::bgsegm::BackgroundSubtractorCNT> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::bgsegm::createBackgroundSubtractorCNT(
            minPixelStability, useHistory != 0, maxPixelStability, isParallel != 0);
        *returnValue = new cv::Ptr<cv::bgsegm::BackgroundSubtractorCNT>(ptr);
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorCNT_get(cv::Ptr<cv::bgsegm::BackgroundSubtractorCNT> *obj, cv::bgsegm::BackgroundSubtractorCNT **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorCNT_delete(cv::Ptr<cv::bgsegm::BackgroundSubtractorCNT> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorCNT_getMinPixelStability(cv::bgsegm::BackgroundSubtractorCNT *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getMinPixelStability();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorCNT_setMinPixelStability(cv::bgsegm::BackgroundSubtractorCNT *ptr, int value)
{
    return cvTry([&] {
        ptr->setMinPixelStability(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorCNT_getMaxPixelStability(cv::bgsegm::BackgroundSubtractorCNT *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getMaxPixelStability();
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorCNT_setMaxPixelStability(cv::bgsegm::BackgroundSubtractorCNT *ptr, int value)
{
    return cvTry([&] {
        ptr->setMaxPixelStability(value);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorCNT_getUseHistory(cv::bgsegm::BackgroundSubtractorCNT *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getUseHistory() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorCNT_setUseHistory(cv::bgsegm::BackgroundSubtractorCNT *ptr, int value)
{
    return cvTry([&] {
        ptr->setUseHistory(value != 0);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorCNT_getIsParallel(cv::bgsegm::BackgroundSubtractorCNT *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getIsParallel() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorCNT_setIsParallel(cv::bgsegm::BackgroundSubtractorCNT *ptr, int value)
{
    return cvTry([&] {
        ptr->setIsParallel(value != 0);
    });
}

#pragma endregion

#pragma region BackgroundSubtractorGSOC

CVAPI(ExceptionStatus) bgsegm_createBackgroundSubtractorGSOC(
    int mc, int nSamples, float replaceRate, float propagationRate, int hitsThreshold,
    float alpha, float beta, float blinkingSupressionDecay, float blinkingSupressionMultiplier,
    float noiseRemovalThresholdFacBG, float noiseRemovalThresholdFacFG,
    cv::Ptr<cv::bgsegm::BackgroundSubtractorGSOC> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::bgsegm::createBackgroundSubtractorGSOC(
            mc, nSamples, replaceRate, propagationRate, hitsThreshold,
            alpha, beta, blinkingSupressionDecay, blinkingSupressionMultiplier,
            noiseRemovalThresholdFacBG, noiseRemovalThresholdFacFG);
        *returnValue = new cv::Ptr<cv::bgsegm::BackgroundSubtractorGSOC>(ptr);
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorGSOC_get(cv::Ptr<cv::bgsegm::BackgroundSubtractorGSOC> *obj, cv::bgsegm::BackgroundSubtractorGSOC **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorGSOC_delete(cv::Ptr<cv::bgsegm::BackgroundSubtractorGSOC> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

#pragma endregion

#pragma region BackgroundSubtractorLSBP

CVAPI(ExceptionStatus) bgsegm_createBackgroundSubtractorLSBP(
    int mc, int nSamples, int lsbpRadius, float tLower, float tUpper, float tInc, float tDec,
    float rScale, float rIncdec, float noiseRemovalThresholdFacBG, float noiseRemovalThresholdFacFG,
    int lsbpThreshold, int minCount,
    cv::Ptr<cv::bgsegm::BackgroundSubtractorLSBP> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::bgsegm::createBackgroundSubtractorLSBP(
            mc, nSamples, lsbpRadius, tLower, tUpper, tInc, tDec,
            rScale, rIncdec, noiseRemovalThresholdFacBG, noiseRemovalThresholdFacFG,
            lsbpThreshold, minCount);
        *returnValue = new cv::Ptr<cv::bgsegm::BackgroundSubtractorLSBP>(ptr);
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorLSBP_get(cv::Ptr<cv::bgsegm::BackgroundSubtractorLSBP> *obj, cv::bgsegm::BackgroundSubtractorLSBP **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}
CVAPI(ExceptionStatus) bgsegm_Ptr_BackgroundSubtractorLSBP_delete(cv::Ptr<cv::bgsegm::BackgroundSubtractorLSBP> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorLSBPDesc_calcLocalSVDValues(
    const interop::OutputArrayProxy* localSVDValues, cv::Mat* frame)
{
    return cvTry([&] {
        cv::bgsegm::BackgroundSubtractorLSBPDesc::calcLocalSVDValues(OutProxy(*localSVDValues), *frame);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorLSBPDesc_computeFromLocalSVDValues(
    const interop::OutputArrayProxy* desc, cv::Mat* localSVDValues, cv::Point2i* lsbpSamplePoints)
{
    return cvTry([&] {
        cv::bgsegm::BackgroundSubtractorLSBPDesc::computeFromLocalSVDValues(OutProxy(*desc), *localSVDValues, lsbpSamplePoints);
    });
}

CVAPI(ExceptionStatus) bgsegm_BackgroundSubtractorLSBPDesc_compute(
    const interop::OutputArrayProxy* desc, cv::Mat* frame, cv::Point2i* lsbpSamplePoints)
{
    return cvTry([&] {
        cv::bgsegm::BackgroundSubtractorLSBPDesc::compute(OutProxy(*desc), *frame, lsbpSamplePoints);
    });
}

#pragma endregion

#pragma region SyntheticSequenceGenerator

CVAPI(ExceptionStatus) bgsegm_SyntheticSequenceGenerator_new(
    const interop::InputArrayProxy* background,
    const interop::InputArrayProxy* object,
    double amplitude, double wavelength, double wavespeed, double objspeed,
    cv::bgsegm::SyntheticSequenceGenerator** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::bgsegm::SyntheticSequenceGenerator(
            InProxy(*background), InProxy(*object), amplitude, wavelength, wavespeed, objspeed);
    });
}

CVAPI(ExceptionStatus) bgsegm_SyntheticSequenceGenerator_delete(cv::bgsegm::SyntheticSequenceGenerator* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) bgsegm_SyntheticSequenceGenerator_getNextFrame(
    cv::bgsegm::SyntheticSequenceGenerator* obj,
    const interop::OutputArrayProxy* frame,
    const interop::OutputArrayProxy* gtMask)
{
    return cvTry([&] {
        obj->getNextFrame(OutProxy(*frame), OutProxy(*gtMask));
    });
}

#pragma endregion

// (no NO_CONTRIB guard: kept in every profile for OpenCV 5)
