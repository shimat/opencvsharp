#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencyFineGrained_delete(
    cv::Ptr<cv::saliency::StaticSaliencyFineGrained> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_Ptr_StaticSaliencyFineGrained_get(
    cv::Ptr<cv::saliency::StaticSaliencyFineGrained> *ptr,
    cv::saliency::StaticSaliencyFineGrained **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_create(
    cv::Ptr<cv::saliency::StaticSaliencyFineGrained> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::saliency::StaticSaliencyFineGrained::create();
    *returnValue = new cv::Ptr<cv::saliency::StaticSaliencyFineGrained>(p);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_computeSaliency(
    cv::saliency::StaticSaliencyFineGrained *obj,
    cv::_InputArray *image, cv::_OutputArray *saliencyMap, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->computeSaliency(*image, *saliencyMap) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_computeBinaryMap(
    cv::saliency::StaticSaliencyFineGrained *obj,
    cv::_InputArray *saliencyMap, cv::_OutputArray *binaryMap, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->computeBinaryMap(*saliencyMap, *binaryMap) ? 1 : 0;
    END_WRAP
}

#endif // NO_CONTRIB
