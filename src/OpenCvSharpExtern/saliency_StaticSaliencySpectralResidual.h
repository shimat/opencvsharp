#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencySpectralResidual_delete(cv::Ptr<cv::saliency::StaticSaliencySpectralResidual> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencySpectralResidual_get(cv::Ptr<cv::saliency::StaticSaliencySpectralResidual> *ptr, cv::saliency::StaticSaliencySpectralResidual **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_create(cv::Ptr<cv::saliency::StaticSaliencySpectralResidual> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::saliency::StaticSaliencySpectralResidual::create();
        *returnValue = new cv::Ptr<cv::saliency::StaticSaliencySpectralResidual>(p);
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_computeSaliency(
    cv::saliency::StaticSaliencySpectralResidual *obj,
    const interop::InputArrayProxy* image,
    const interop::OutputArrayProxy* saliencyMap,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->computeSaliency(InProxy(*image), OutProxy(*saliencyMap)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_computeBinaryMap(
    cv::saliency::StaticSaliencySpectralResidual *obj,
    const interop::InputArrayProxy* saliencyMap,
    const interop::OutputArrayProxy* binaryMap,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->computeBinaryMap(InProxy(*saliencyMap), OutProxy(*binaryMap)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_getImageWidth(cv::saliency::StaticSaliencySpectralResidual *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getImageWidth();
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_setImageWidth(cv::saliency::StaticSaliencySpectralResidual *obj, int val)
{
    return cvTry([&] {
        obj->setImageWidth(val);
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_getImageHeight(cv::saliency::StaticSaliencySpectralResidual *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getImageHeight();
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_setImageHeight(cv::saliency::StaticSaliencySpectralResidual *obj, int val)
{
    return cvTry([&] {
        obj->setImageHeight(val);
    });
}

#endif // NO_CONTRIB
