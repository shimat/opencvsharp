#pragma once

#ifndef NO_ML

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_Boost_getBoostType(cv::ml::Boost *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getBoostType();
    });
}
CVAPI(ExceptionStatus) ml_Boost_setBoostType(cv::ml::Boost *obj, int val)
{
    return cvTry([&] {
    obj->setBoostType(val);
    });
}

CVAPI(ExceptionStatus) ml_Boost_getWeakCount(cv::ml::Boost *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getWeakCount();
    });
}
CVAPI(ExceptionStatus) ml_Boost_setWeakCount(cv::ml::Boost *obj, int val)
{
    return cvTry([&] {
    obj->setWeakCount(val);
    });
}

CVAPI(ExceptionStatus) ml_Boost_getWeightTrimRate(cv::ml::Boost *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getWeightTrimRate();
    });
}
CVAPI(ExceptionStatus) ml_Boost_setWeightTrimRate(cv::ml::Boost *obj, double val)
{
    return cvTry([&] {
    obj->setWeightTrimRate(val);
    });
}


CVAPI(ExceptionStatus) ml_Boost_create(cv::Ptr<cv::ml::Boost> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ml::Boost::create();
    *returnValue = new cv::Ptr<cv::ml::Boost>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_Boost_delete(cv::Ptr<cv::ml::Boost> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_Boost_get(cv::Ptr<cv::ml::Boost>* obj, cv::ml::Boost **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_Boost_load(const char *filePath, cv::Ptr<cv::ml::Boost> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::Algorithm::load<cv::ml::Boost>(filePath);
    *returnValue = new cv::Ptr<cv::ml::Boost>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Boost_loadFromString(const char *strModel, cv::Ptr<cv::ml::Boost> **returnValue)
{
    return cvTry([&] {
    const auto objName = cv::ml::Boost::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::Boost>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::Boost>(ptr);
    });
}

#endif // NO_ML
