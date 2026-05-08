#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) saliency_Ptr_MotionSaliencyBinWangApr2014_delete(
    cv::Ptr<cv::saliency::MotionSaliencyBinWangApr2014> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_Ptr_MotionSaliencyBinWangApr2014_get(
    cv::Ptr<cv::saliency::MotionSaliencyBinWangApr2014> *ptr,
    cv::saliency::MotionSaliencyBinWangApr2014 **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_create(
    cv::Ptr<cv::saliency::MotionSaliencyBinWangApr2014> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::saliency::MotionSaliencyBinWangApr2014::create();
    *returnValue = new cv::Ptr<cv::saliency::MotionSaliencyBinWangApr2014>(p);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_computeSaliency(
    cv::saliency::MotionSaliencyBinWangApr2014 *obj,
    cv::_InputArray *image, cv::_OutputArray *saliencyMap, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->computeSaliency(*image, *saliencyMap) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_setImagesize(
    cv::saliency::MotionSaliencyBinWangApr2014 *obj, int W, int H)
{
    BEGIN_WRAP
    obj->setImagesize(W, H);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_init(
    cv::saliency::MotionSaliencyBinWangApr2014 *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->init() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_getImageWidth(
    cv::saliency::MotionSaliencyBinWangApr2014 *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getImageWidth();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_setImageWidth(
    cv::saliency::MotionSaliencyBinWangApr2014 *obj, int val)
{
    BEGIN_WRAP
    obj->setImageWidth(val);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_getImageHeight(
    cv::saliency::MotionSaliencyBinWangApr2014 *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getImageHeight();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_setImageHeight(
    cv::saliency::MotionSaliencyBinWangApr2014 *obj, int val)
{
    BEGIN_WRAP
    obj->setImageHeight(val);
    END_WRAP
}

#endif // NO_CONTRIB
