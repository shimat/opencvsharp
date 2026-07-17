#pragma once

#ifndef NO_VIDEO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


#pragma region BackgroundSubtractor

CVAPI(ExceptionStatus) video_BackgroundSubtractor_getBackgroundImage(cv::BackgroundSubtractor *obj, const interop::OutputArrayProxy* backgroundImage)
{
    return cvTry([&] {
        obj->getBackgroundImage(OutProxy(*backgroundImage));
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractor_apply(
    cv::BackgroundSubtractor *obj,
    const interop::InputArrayProxy* image,
    const interop::OutputArrayProxy* fgmask,
    double learningRate)
{
    return cvTry([&] {
        obj->apply(InProxy(*image), OutProxy(*fgmask), learningRate);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractor_applyWithMask(
    cv::BackgroundSubtractor *obj,
    const interop::InputArrayProxy* image,
    const interop::InputArrayProxy* knownForegroundMask,
    const interop::OutputArrayProxy* fgmask,
    double learningRate)
{
    return cvTry([&] {
        obj->apply(InProxy(*image), InProxy(*knownForegroundMask), OutProxy(*fgmask), learningRate);
    });
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractor_delete(cv::Ptr<cv::BackgroundSubtractor> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractor_get(cv::Ptr<cv::BackgroundSubtractor> *ptr, cv::BackgroundSubtractor **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#pragma endregion

#pragma region BackgroundSubtractorMOG2

CVAPI(ExceptionStatus) video_createBackgroundSubtractorMOG2(
    int history,
    double varThreshold,
    int detectShadows,
    cv::Ptr<cv::BackgroundSubtractorMOG2> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::createBackgroundSubtractorMOG2(history, varThreshold, detectShadows != 0);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractorMOG2_delete(cv::Ptr<cv::BackgroundSubtractorMOG2> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractorMOG2_get(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, cv::BackgroundSubtractorMOG2 **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getHistory(cv::BackgroundSubtractorMOG2 *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getHistory();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setHistory(cv::BackgroundSubtractorMOG2 *ptr, int value)
{
    return cvTry([&] {
        ptr->setHistory(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getNMixtures(cv::BackgroundSubtractorMOG2 *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getNMixtures();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setNMixtures(cv::BackgroundSubtractorMOG2 *ptr, int value)
{
    return cvTry([&] {
        ptr->setNMixtures(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getBackgroundRatio(cv::BackgroundSubtractorMOG2 *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getBackgroundRatio();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setBackgroundRatio(cv::BackgroundSubtractorMOG2 *ptr, double value)
{
    return cvTry([&] {
        ptr->setBackgroundRatio(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarThreshold(cv::BackgroundSubtractorMOG2 *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getVarThreshold();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarThreshold(cv::BackgroundSubtractorMOG2 *ptr, double value)
{
    return cvTry([&] {
        ptr->setVarThreshold(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarThresholdGen(cv::BackgroundSubtractorMOG2 *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getVarThresholdGen();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarThresholdGen(cv::BackgroundSubtractorMOG2 *ptr, double value)
{
    return cvTry([&] {
        ptr->setVarThresholdGen(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarInit(cv::BackgroundSubtractorMOG2 *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getVarInit();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarInit(cv::BackgroundSubtractorMOG2 *ptr, double value)
{
    return cvTry([&] {
        ptr->setVarInit(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarMin(cv::BackgroundSubtractorMOG2 *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getVarMin();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarMin(cv::BackgroundSubtractorMOG2 *ptr, double value)
{
    return cvTry([&] {
        ptr->setVarMin(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarMax(cv::BackgroundSubtractorMOG2 *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getVarMax();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarMax(cv::BackgroundSubtractorMOG2 *ptr, double value)
{
    return cvTry([&] {
        ptr->setVarMax(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(cv::BackgroundSubtractorMOG2 *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getComplexityReductionThreshold();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(cv::BackgroundSubtractorMOG2 *ptr, double value)
{
    return cvTry([&] {
        ptr->setComplexityReductionThreshold(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getDetectShadows(cv::BackgroundSubtractorMOG2 *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getDetectShadows() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setDetectShadows(cv::BackgroundSubtractorMOG2 *ptr, int value)
{
    return cvTry([&] {
        ptr->setDetectShadows(value != 0);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getShadowValue(cv::BackgroundSubtractorMOG2 *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getShadowValue();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setShadowValue(cv::BackgroundSubtractorMOG2 *ptr, int value)
{
    return cvTry([&] {
        ptr->setShadowValue(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getShadowThreshold(cv::BackgroundSubtractorMOG2 *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getShadowThreshold();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setShadowThreshold(cv::BackgroundSubtractorMOG2 *ptr, double value)
{
    return cvTry([&] {
        ptr->setShadowThreshold(value);
    });
}

#pragma endregion

#pragma region BackgroundSubtractorKNN

CVAPI(ExceptionStatus) video_createBackgroundSubtractorKNN(
    int history,
    double dist2Threshold,
    int detectShadows,
    cv::Ptr<cv::BackgroundSubtractorKNN> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::createBackgroundSubtractorKNN(
            history, dist2Threshold, detectShadows != 0);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractorKNN_delete(cv::Ptr<cv::BackgroundSubtractorKNN> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractorKNN_get(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, cv::BackgroundSubtractorKNN **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getHistory(cv::BackgroundSubtractorKNN *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getHistory();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setHistory(cv::BackgroundSubtractorKNN *ptr, int value)
{
    return cvTry([&] {
        ptr->setHistory(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getNSamples(cv::BackgroundSubtractorKNN *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getNSamples();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setNSamples(cv::BackgroundSubtractorKNN *ptr, int value)
{
    return cvTry([&] {
        ptr->setNSamples(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getDist2Threshold(cv::BackgroundSubtractorKNN *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getDist2Threshold();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setDist2Threshold(cv::BackgroundSubtractorKNN *ptr, double value)
{
    return cvTry([&] {
        ptr->setDist2Threshold(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getkNNSamples(cv::BackgroundSubtractorKNN *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getkNNSamples();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setkNNSamples(cv::BackgroundSubtractorKNN *ptr, int value)
{
    return cvTry([&] {
        ptr->setkNNSamples(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getDetectShadows(cv::BackgroundSubtractorKNN *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getDetectShadows() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setDetectShadows(cv::BackgroundSubtractorKNN *ptr, int value)
{
    return cvTry([&] {
        ptr->setDetectShadows(value != 0);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getShadowValue(cv::BackgroundSubtractorKNN *ptr, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getShadowValue();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setShadowValue(cv::BackgroundSubtractorKNN *ptr, int value)
{
    return cvTry([&] {
        ptr->setShadowValue(value);
    });
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getShadowThreshold(cv::BackgroundSubtractorKNN *ptr, double *returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->getShadowThreshold();
    });
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setShadowThreshold(cv::BackgroundSubtractorKNN *ptr, double value)
{
    return cvTry([&] {
        ptr->setShadowThreshold(value);
    });
}

#pragma endregion

#endif // NO_VIDEO
