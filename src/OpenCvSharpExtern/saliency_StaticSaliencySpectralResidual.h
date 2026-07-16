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

// write/read are called directly on the concrete type here (rather than going through the generic
// core_Algorithm_write/read, which take a cv::Algorithm*): cv::saliency::Saliency inherits Algorithm
// virtually, so a raw pointer obtained as StaticSaliencySpectralResidual* cannot be safely reinterpreted
// as Algorithm* on the managed side without the compiler-generated virtual-base offset adjustment.
CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_write(cv::saliency::StaticSaliencySpectralResidual *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
        obj->write(*fs);
    });
}

CVAPI(ExceptionStatus) saliency_StaticSaliencySpectralResidual_read(cv::saliency::StaticSaliencySpectralResidual *obj, cv::FileNode *fn)
{
    return cvTry([&] {
        obj->read(*fn);
    });
}

#endif // NO_CONTRIB
