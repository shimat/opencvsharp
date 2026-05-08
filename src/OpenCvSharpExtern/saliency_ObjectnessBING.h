#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) saliency_Ptr_ObjectnessBING_delete(
    cv::Ptr<cv::saliency::ObjectnessBING> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_Ptr_ObjectnessBING_get(
    cv::Ptr<cv::saliency::ObjectnessBING> *ptr,
    cv::saliency::ObjectnessBING **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_create(
    cv::Ptr<cv::saliency::ObjectnessBING> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::saliency::ObjectnessBING::create();
    *returnValue = new cv::Ptr<cv::saliency::ObjectnessBING>(p);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_computeSaliency(
    cv::saliency::ObjectnessBING *obj,
    cv::_InputArray *image,
    std::vector<cv::Vec4i> *objectnessBoundingBox,
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->computeSaliency(*image, *objectnessBoundingBox) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_getobjectnessValues(
    cv::saliency::ObjectnessBING *obj, std::vector<float> *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getobjectnessValues();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setTrainingPath(
    cv::saliency::ObjectnessBING *obj, const char *trainingPath)
{
    BEGIN_WRAP
    obj->setTrainingPath(trainingPath);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setBBResDir(
    cv::saliency::ObjectnessBING *obj, const char *resultsDir)
{
    BEGIN_WRAP
    obj->setBBResDir(resultsDir);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_getBase(
    cv::saliency::ObjectnessBING *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getBase();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setBase(
    cv::saliency::ObjectnessBING *obj, double val)
{
    BEGIN_WRAP
    obj->setBase(val);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_getNSS(
    cv::saliency::ObjectnessBING *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNSS();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setNSS(
    cv::saliency::ObjectnessBING *obj, int val)
{
    BEGIN_WRAP
    obj->setNSS(val);
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_getW(
    cv::saliency::ObjectnessBING *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getW();
    END_WRAP
}

CVAPI(ExceptionStatus) saliency_ObjectnessBING_setW(
    cv::saliency::ObjectnessBING *obj, int val)
{
    BEGIN_WRAP
    obj->setW(val);
    END_WRAP
}

#endif // NO_CONTRIB
