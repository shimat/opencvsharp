#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencyFineGrained_delete(
    cv::Ptr<cv::saliency::StaticSaliencyFineGrained> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencyFineGrained_get(
    cv::Ptr<cv::saliency::StaticSaliencyFineGrained> *ptr,
    cv::saliency::StaticSaliencyFineGrained **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_create(
    cv::Ptr<cv::saliency::StaticSaliencyFineGrained> **returnValue)
{
    return cvTry([&] {
    const auto p = cv::saliency::StaticSaliencyFineGrained::create();
    *returnValue = new cv::Ptr<cv::saliency::StaticSaliencyFineGrained>(p);
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_computeSaliency(
    cv::saliency::StaticSaliencyFineGrained *obj,
    cv::_InputArray *image, cv::_OutputArray *saliencyMap, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->computeSaliency(*image, *saliencyMap) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_computeBinaryMap(
    cv::saliency::StaticSaliencyFineGrained *obj,
    cv::_InputArray *saliencyMap, cv::_OutputArray *binaryMap, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->computeBinaryMap(*saliencyMap, *binaryMap) ? 1 : 0;
    });
}

#endif // NO_CONTRIB
