#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) saliency_Ptr_ObjectnessBING_delete(cv::Ptr<cv::saliency::ObjectnessBING> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) saliency_Ptr_ObjectnessBING_get(cv::Ptr<cv::saliency::ObjectnessBING> *ptr, cv::saliency::ObjectnessBING **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_create(cv::Ptr<cv::saliency::ObjectnessBING> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::saliency::ObjectnessBING::create();
        *returnValue = new cv::Ptr<cv::saliency::ObjectnessBING>(p);
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_computeSaliency(
    cv::saliency::ObjectnessBING *obj,
    const interop::InputArrayProxy* image,
    std::vector<cv::Vec4i> *objectnessBoundingBox,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->computeSaliency(InProxy(*image), *objectnessBoundingBox) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_getobjectnessValues(cv::saliency::ObjectnessBING *obj, std::vector<float> *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getobjectnessValues();
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setTrainingPath(cv::saliency::ObjectnessBING *obj, const char *trainingPath)
{
    return cvTry([&] {
        obj->setTrainingPath(trainingPath);
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setBBResDir(cv::saliency::ObjectnessBING *obj, const char *resultsDir)
{
    return cvTry([&] {
        obj->setBBResDir(resultsDir);
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_getBase(cv::saliency::ObjectnessBING *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getBase();
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setBase(cv::saliency::ObjectnessBING *obj, double val)
{
    return cvTry([&] {
        obj->setBase(val);
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_getNSS(cv::saliency::ObjectnessBING *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNSS();
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setNSS(cv::saliency::ObjectnessBING *obj, int val)
{
    return cvTry([&] {
        obj->setNSS(val);
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_getW(cv::saliency::ObjectnessBING *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getW();
    });
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setW(cv::saliency::ObjectnessBING *obj, int val)
{
    return cvTry([&] {
        obj->setW(val);
    });
}

#endif // NO_CONTRIB
