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

// write/read are called directly on the concrete type here (rather than going through the generic
// core_Algorithm_write/read, which take a cv::Algorithm*): cv::saliency::Saliency inherits Algorithm
// virtually, so a raw pointer obtained as StaticSaliencyFineGrained* cannot be safely reinterpreted
// as Algorithm* on the managed side without the compiler-generated virtual-base offset adjustment.
CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_write(cv::saliency::StaticSaliencyFineGrained *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
        obj->write(*fs);
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencyFineGrained_read(cv::saliency::StaticSaliencyFineGrained *obj, cv::FileNode *fn)
{
    return cvTry([&] {
        obj->read(*fn);
    });
}

#endif // NO_CONTRIB
