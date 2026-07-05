#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencyFineGrained_delete(cv::Ptr<cv::saliency::StaticSaliencyFineGrained> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencyFineGrained_get(cv::Ptr<cv::saliency::StaticSaliencyFineGrained> *ptr, cv::saliency::StaticSaliencyFineGrained **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_create(cv::Ptr<cv::saliency::StaticSaliencyFineGrained> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::saliency::StaticSaliencyFineGrained::create();
        *returnValue = new cv::Ptr<cv::saliency::StaticSaliencyFineGrained>(p);
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_computeSaliency(
    cv::saliency::StaticSaliencyFineGrained *obj,
    const interop::InputArrayProxy* image,
    const interop::OutputArrayProxy* saliencyMap,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->computeSaliency(InProxy(*image), OutProxy(*saliencyMap)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_computeBinaryMap(
    cv::saliency::StaticSaliencyFineGrained *obj,
    const interop::InputArrayProxy* saliencyMap,
    const interop::OutputArrayProxy* binaryMap,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->computeBinaryMap(InProxy(*saliencyMap), OutProxy(*binaryMap)) ? 1 : 0;
    });
}

#endif // NO_CONTRIB
