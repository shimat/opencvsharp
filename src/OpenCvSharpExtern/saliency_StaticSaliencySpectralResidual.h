#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencySpectralResidual_delete(
    cv::Ptr<cv::saliency::StaticSaliencySpectralResidual> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencySpectralResidual_get(
    cv::Ptr<cv::saliency::StaticSaliencySpectralResidual> *ptr,
    cv::saliency::StaticSaliencySpectralResidual **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_create(
    cv::Ptr<cv::saliency::StaticSaliencySpectralResidual> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::saliency::StaticSaliencySpectralResidual::create();
    *returnValue = new cv::Ptr<cv::saliency::StaticSaliencySpectralResidual>(p);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_computeSaliency(
    cv::saliency::StaticSaliencySpectralResidual *obj,
    cv::_InputArray *image, cv::_OutputArray *saliencyMap, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->computeSaliency(*image, *saliencyMap) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_computeBinaryMap(
    cv::saliency::StaticSaliencySpectralResidual *obj,
    cv::_InputArray *saliencyMap, cv::_OutputArray *binaryMap, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->computeBinaryMap(*saliencyMap, *binaryMap) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_getImageWidth(
    cv::saliency::StaticSaliencySpectralResidual *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getImageWidth();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_setImageWidth(
    cv::saliency::StaticSaliencySpectralResidual *obj, int val)
{
    BEGIN_WRAP
    obj->setImageWidth(val);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_getImageHeight(
    cv::saliency::StaticSaliencySpectralResidual *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getImageHeight();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_setImageHeight(
    cv::saliency::StaticSaliencySpectralResidual *obj, int val)
{
    BEGIN_WRAP
    obj->setImageHeight(val);
    END_WRAP
}

#endif // NO_CONTRIB
