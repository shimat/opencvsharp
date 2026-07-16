#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) saliency_Ptr_MotionSaliencyBinWangApr2014_delete(cv::Ptr<cv::saliency::MotionSaliencyBinWangApr2014> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) saliency_Ptr_MotionSaliencyBinWangApr2014_get(cv::Ptr<cv::saliency::MotionSaliencyBinWangApr2014> *ptr, cv::saliency::MotionSaliencyBinWangApr2014 **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_create(cv::Ptr<cv::saliency::MotionSaliencyBinWangApr2014> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::saliency::MotionSaliencyBinWangApr2014::create();
        *returnValue = new cv::Ptr<cv::saliency::MotionSaliencyBinWangApr2014>(p);
    });
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_computeSaliency(
    cv::saliency::MotionSaliencyBinWangApr2014 *obj,
    const interop::InputArrayProxy* image,
    const interop::OutputArrayProxy* saliencyMap,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->computeSaliency(InProxy(*image), OutProxy(*saliencyMap)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_setImagesize(
    cv::saliency::MotionSaliencyBinWangApr2014 *obj,
    int W,
    int H)
{
    return cvTry([&] {
        obj->setImagesize(W, H);
    });
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_init(cv::saliency::MotionSaliencyBinWangApr2014 *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->init() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_getImageWidth(cv::saliency::MotionSaliencyBinWangApr2014 *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getImageWidth();
    });
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_setImageWidth(cv::saliency::MotionSaliencyBinWangApr2014 *obj, int val)
{
    return cvTry([&] {
        obj->setImageWidth(val);
    });
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_getImageHeight(cv::saliency::MotionSaliencyBinWangApr2014 *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getImageHeight();
    });
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_setImageHeight(cv::saliency::MotionSaliencyBinWangApr2014 *obj, int val)
{
    return cvTry([&] {
        obj->setImageHeight(val);
    });
}

// write/read are called directly on the concrete type here (rather than going through the generic
// core_Algorithm_write/read, which take a cv::Algorithm*): cv::saliency::Saliency inherits Algorithm
// virtually, so a raw pointer obtained as MotionSaliencyBinWangApr2014* cannot be safely reinterpreted
// as Algorithm* on the managed side without the compiler-generated virtual-base offset adjustment.
CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_write(cv::saliency::MotionSaliencyBinWangApr2014 *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
        obj->write(*fs);
    });
}

CVAPI(ExceptionStatus) saliency_MotionSaliencyBinWangApr2014_read(cv::saliency::MotionSaliencyBinWangApr2014 *obj, cv::FileNode *fn)
{
    return cvTry([&] {
        obj->read(*fn);
    });
}

#endif // NO_CONTRIB
