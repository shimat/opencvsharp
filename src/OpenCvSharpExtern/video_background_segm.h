#ifndef _CPP_VIDEO_BACKGROUND_SEGM_H_
#define _CPP_VIDEO_BACKGROUND_SEGM_H_

#include "include_opencv.h"


#pragma region BackgroundSubtractor
CVAPI(void) video_BackgroundSubtractor_getBackgroundImage(cv::BackgroundSubtractor *obj, cv::_OutputArray *backgroundImage)
{
    obj->getBackgroundImage(*backgroundImage);
}
CVAPI(void) video_BackgroundSubtractor_apply(cv::BackgroundSubtractor *obj, cv::_InputArray *image, cv::_OutputArray *fgmask, double learningRate)
{
    obj->apply(*image, *fgmask, learningRate);
}

CVAPI(void) video_Ptr_BackgroundSubtractor_delete(cv::Ptr<cv::BackgroundSubtractor> *ptr)
{
    delete ptr;
}
CVAPI(cv::BackgroundSubtractor*) video_Ptr_BackgroundSubtractor_get(cv::Ptr<cv::BackgroundSubtractor> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region BackgroundSubtractorMOG2
CVAPI(cv::Ptr<cv::BackgroundSubtractorMOG2>*) video_createBackgroundSubtractorMOG2(int history, double varThreshold, int detectShadows)
{
    cv::Ptr<cv::BackgroundSubtractorMOG2> ptr = cv::createBackgroundSubtractorMOG2(history, varThreshold, detectShadows != 0);
    return new cv::Ptr<cv::BackgroundSubtractorMOG2>(ptr);
}
CVAPI(void) video_Ptr_BackgroundSubtractorMOG2_delete(cv::Ptr<cv::BackgroundSubtractorMOG2> *obj)
{
    delete obj;
}

CVAPI(cv::BackgroundSubtractorMOG2*) video_Ptr_BackgroundSubtractorMOG2_get(
    cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return ptr->get();
}

CVAPI(int) video_BackgroundSubtractorMOG2_getHistory(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getHistory();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setHistory(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int value)
{
    (*ptr)->setHistory(value);
}

CVAPI(int) video_BackgroundSubtractorMOG2_getNMixtures(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getNMixtures();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setNMixtures(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int value)
{
    (*ptr)->setNMixtures(value);
}

CVAPI(double) video_BackgroundSubtractorMOG2_getBackgroundRatio(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getBackgroundRatio();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setBackgroundRatio(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    (*ptr)->setBackgroundRatio(value);
}

CVAPI(double) video_BackgroundSubtractorMOG2_getVarThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getVarThreshold();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setVarThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    (*ptr)->setVarThreshold(value);
}

CVAPI(double) video_BackgroundSubtractorMOG2_getVarThresholdGen(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getVarThresholdGen();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setVarThresholdGen(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    (*ptr)->setVarThresholdGen(value);
}

CVAPI(double) video_BackgroundSubtractorMOG2_getVarInit(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getVarInit();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setVarInit(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    (*ptr)->setVarInit(value);
}

CVAPI(double) video_BackgroundSubtractorMOG2_getVarMin(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getVarMin();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setVarMin(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    (*ptr)->setVarMin(value);
}

CVAPI(double) video_BackgroundSubtractorMOG2_getVarMax(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getVarMax();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setVarMax(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    (*ptr)->setVarMax(value);
}

CVAPI(double) video_BackgroundSubtractorMOG2_getComplexityReductionThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getComplexityReductionThreshold();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setComplexityReductionThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    (*ptr)->setComplexityReductionThreshold(value);
}

CVAPI(int) video_BackgroundSubtractorMOG2_getDetectShadows(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getDetectShadows() ? 1 : 0;
}
CVAPI(void) video_BackgroundSubtractorMOG2_setDetectShadows(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int value)
{
    (*ptr)->setDetectShadows(value != 0);
}

CVAPI(int) video_BackgroundSubtractorMOG2_getShadowValue(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getShadowValue();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setShadowValue(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, int value)
{
    (*ptr)->setShadowValue(value);
}

CVAPI(double) video_BackgroundSubtractorMOG2_getShadowThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr)
{
    return (*ptr)->getShadowThreshold();
}
CVAPI(void) video_BackgroundSubtractorMOG2_setShadowThreshold(cv::Ptr<cv::BackgroundSubtractorMOG2> *ptr, double value)
{
    (*ptr)->setShadowThreshold(value);
}

#pragma endregion

#pragma region BackgroundSubtractorKNN
CVAPI(cv::Ptr<cv::BackgroundSubtractorKNN>*) video_createBackgroundSubtractorKNN(
    int history, double dist2Threshold, int detectShadows)
{
    cv::Ptr<cv::BackgroundSubtractorKNN> ptr = cv::createBackgroundSubtractorKNN(
        history, dist2Threshold, detectShadows != 0);
    return new cv::Ptr<cv::BackgroundSubtractorKNN>(ptr);
}
CVAPI(void) video_Ptr_BackgroundSubtractorKNN_delete(cv::Ptr<cv::BackgroundSubtractorKNN> *obj)
{
    delete obj;
}

CVAPI(cv::BackgroundSubtractorKNN*) video_Ptr_BackgroundSubtractorKNN_get(
    cv::Ptr<cv::BackgroundSubtractorKNN> *ptr)
{
    return ptr->get();
}

CVAPI(int) video_BackgroundSubtractorKNN_getHistory(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr)
{
    return (*ptr)->getHistory();
}
CVAPI(void) video_BackgroundSubtractorKNN_setHistory(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    (*ptr)->setHistory(value);
}

CVAPI(int) video_BackgroundSubtractorKNN_getNSamples(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr)
{
    return (*ptr)->getNSamples();
}
CVAPI(void) video_BackgroundSubtractorKNN_setNSamples(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    (*ptr)->setNSamples(value);
}

CVAPI(double) video_BackgroundSubtractorKNN_getDist2Threshold(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr)
{
    return (*ptr)->getDist2Threshold();
}
CVAPI(void) video_BackgroundSubtractorKNN_setDist2Threshold(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, double value)
{
    (*ptr)->setDist2Threshold(value);
}

CVAPI(int) video_BackgroundSubtractorKNN_getkNNSamples(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr)
{
    return (*ptr)->getkNNSamples();
}
CVAPI(void) video_BackgroundSubtractorKNN_setkNNSamples(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    (*ptr)->setkNNSamples(value);
}

CVAPI(int) video_BackgroundSubtractorKNN_getDetectShadows(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr)
{
    return (*ptr)->getDetectShadows() ? 1 : 0;
}
CVAPI(void) video_BackgroundSubtractorKNN_setDetectShadows(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    (*ptr)->setDetectShadows(value != 0);
}

CVAPI(int) video_BackgroundSubtractorKNN_getShadowValue(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr)
{
    return (*ptr)->getShadowValue();
}
CVAPI(void) video_BackgroundSubtractorKNN_setShadowValue(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, int value)
{
    (*ptr)->setShadowValue(value);
}

CVAPI(double) video_BackgroundSubtractorKNN_getShadowThreshold(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr)
{
    return (*ptr)->getShadowThreshold();
}
CVAPI(void) video_BackgroundSubtractorKNN_setShadowThreshold(cv::Ptr<cv::BackgroundSubtractorKNN> *ptr, double value)
{
    (*ptr)->setShadowThreshold(value);
}

#pragma endregion

#endif