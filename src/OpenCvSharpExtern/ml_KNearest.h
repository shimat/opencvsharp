#pragma once

#ifndef NO_ML

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) ml_KNearest_getDefaultK(cv::ml::KNearest *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDefaultK();
    });
}
CVAPI(ExceptionStatus) ml_KNearest_setDefaultK(cv::ml::KNearest *obj, int val)
{
    return cvTry([&] {
        obj->setDefaultK(val);
    });
}

CVAPI(ExceptionStatus) ml_KNearest_getIsClassifier(cv::ml::KNearest *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getIsClassifier() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) ml_KNearest_setIsClassifier(cv::ml::KNearest *obj, int val)
{
    return cvTry([&] {
        obj->setIsClassifier(val != 0);
    });
}

CVAPI(ExceptionStatus) ml_KNearest_getEmax(cv::ml::KNearest *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getEmax();
    });
}
CVAPI(ExceptionStatus) ml_KNearest_setEmax(cv::ml::KNearest *obj, int val)
{
    return cvTry([&] {
        obj->setEmax(val);
    });
}

CVAPI(ExceptionStatus) ml_KNearest_getAlgorithmType(cv::ml::KNearest *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getAlgorithmType();
    });
}
CVAPI(ExceptionStatus) ml_KNearest_setAlgorithmType(cv::ml::KNearest *obj, int val)
{
    return cvTry([&] {
        obj->setAlgorithmType(val);
    });
}


CVAPI(ExceptionStatus) ml_KNearest_findNearest(
    cv::ml::KNearest *obj,
    const interop::InputArrayProxy* samples,
    int k,
    const interop::OutputArrayProxy* results,
    const interop::OutputArrayProxy* neighborResponses,
    const interop::OutputArrayProxy* dist,
    float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->findNearest(
            InProxy(*samples), k, OutProxy(*results), OutProxy(*neighborResponses), OutProxy(*dist));
    });
}


CVAPI(ExceptionStatus) ml_KNearest_create(cv::Ptr<cv::ml::KNearest> **returnValue)
{
    return cvTry([&] {
        const auto  ptr = cv::ml::KNearest::create();
        *returnValue = new cv::Ptr<cv::ml::KNearest>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_KNearest_delete(cv::Ptr<cv::ml::KNearest> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_KNearest_get(cv::Ptr<cv::ml::KNearest>* obj, cv::ml::KNearest **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_KNearest_load(const char *filePath, cv::Ptr<cv::ml::KNearest> **returnValue)
{
    return cvTry([&] {
        const auto  ptr = cv::Algorithm::load<cv::ml::KNearest>(filePath);
        *returnValue = new cv::Ptr<cv::ml::KNearest>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_KNearest_loadFromString(const char *strModel, cv::Ptr<cv::ml::KNearest> **returnValue)
{
    return cvTry([&] {
        const auto objName = cv::ml::KNearest::create()->getDefaultName();
        const auto  ptr = cv::Algorithm::loadFromString<cv::ml::KNearest>(strModel, objName);
        *returnValue = new cv::Ptr<cv::ml::KNearest>(ptr);
    });
}

#endif // NO_ML
