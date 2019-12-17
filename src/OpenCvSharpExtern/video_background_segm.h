#ifndef _CPP_VIDEO_BACKGROUND_SEGM_H_
#define _CPP_VIDEO_BACKGROUND_SEGM_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


#pragma region BackgroundSubtractor

CVAPI(ExceptionStatus) video_BackgroundSubtractor_getBackgroundImage(cv::BackgroundSubtractor *obj, cv::_OutputArray *backgroundImage)
{
    BEGIN_WRAP
    obj->getBackgroundImage(*backgroundImage);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractor_apply(cv::BackgroundSubtractor *obj, cv::_InputArray *image, cv::_OutputArray *fgmask, double learningRate)
{
    BEGIN_WRAP
    obj->apply(*image, *fgmask, learningRate);
    END_WRAP
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractor_delete(cv::Ptr<cv::BackgroundSubtractor> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractor_get(cv::Ptr<cv::BackgroundSubtractor> *ptr, cv::BackgroundSubtractor **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region BackgroundSubtractorMOG2

CVAPI(ExceptionStatus) video_createBackgroundSubtractorMOG2(int history, double varThreshold, int detectShadows, cv::Ptr<cv::BackgroundSubtractorMOG2> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createBackgroundSubtractorMOG2(history, varThreshold, detectShadows != 0);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractorMOG2_delete(cv::Ptr<cv::BackgroundSubtractorMOG2> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractorMOG2_get(
    cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, cv::BackgroundSubtractorMOG2 **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getHistory(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getHistory();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setHistory(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setHistory(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getNMixtures(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getNMixtures();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setNMixtures(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setNMixtures(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getBackgroundRatio(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getBackgroundRatio();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setBackgroundRatio(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setBackgroundRatio(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getVarThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setVarThreshold(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarThresholdGen(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double *returnValue)
{
    BEGIN_WRAP
     *returnValue = (*ptr)->getVarThresholdGen();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarThresholdGen(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setVarThresholdGen(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarInit(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getVarInit();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarInit(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setVarInit(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarMin(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getVarMin();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarMin(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setVarMin(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getVarMax(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getVarMax();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setVarMax(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setVarMax(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getComplexityReductionThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setComplexityReductionThreshold(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getDetectShadows(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getDetectShadows() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setDetectShadows(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setDetectShadows(value != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getShadowValue(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getShadowValue();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setShadowValue(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setShadowValue(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_getShadowThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getShadowThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorMOG2_setShadowThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setShadowThreshold(value);
    END_WRAP
}

#pragma endregion

#pragma region BackgroundSubtractorKNN

CVAPI(ExceptionStatus) video_createBackgroundSubtractorKNN(
    int history, double dist2Threshold, int detectShadows, cv::Ptr<cv::BackgroundSubtractorKNN> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createBackgroundSubtractorKNN(
        history, dist2Threshold, detectShadows != 0);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractorKNN_delete(cv::Ptr<cv::BackgroundSubtractorKNN> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) video_Ptr_BackgroundSubtractorKNN_get(
    cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, cv::BackgroundSubtractorKNN **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getHistory(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getHistory();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setHistory(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setHistory(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getNSamples(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getNSamples();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setNSamples(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setNSamples(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getDist2Threshold(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getDist2Threshold();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setDist2Threshold(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setDist2Threshold(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getkNNSamples(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getkNNSamples();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setkNNSamples(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setkNNSamples(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getDetectShadows(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getDetectShadows() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setDetectShadows(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setDetectShadows(value != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getShadowValue(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getShadowValue();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setShadowValue(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    BEGIN_WRAP
    (*ptr)->setShadowValue(value);
    END_WRAP
}

CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_getShadowThreshold(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = (*ptr)->getShadowThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) video_BackgroundSubtractorKNN_setShadowThreshold(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, double value)
{
    BEGIN_WRAP
    (*ptr)->setShadowThreshold(value);
    END_WRAP
}

#pragma endregion

#endif