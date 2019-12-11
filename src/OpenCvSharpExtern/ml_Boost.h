#ifndef _CPP_ML_BOOST_H_
#define _CPP_ML_BOOST_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_Boost_getBoostType(cv::ml::Boost *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getBoostType();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_Boost_setBoostType(cv::ml::Boost *obj, int val)
{
    BEGIN_WRAP
    obj->setBoostType(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Boost_getWeakCount(cv::ml::Boost *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getWeakCount();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_Boost_setWeakCount(cv::ml::Boost *obj, int val)
{
    BEGIN_WRAP
    obj->setWeakCount(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Boost_getWeightTrimRate(cv::ml::Boost *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getWeightTrimRate();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_Boost_setWeightTrimRate(cv::ml::Boost *obj, double val)
{
    BEGIN_WRAP
    obj->setWeightTrimRate(val);
    END_WRAP
}


CVAPI(ExceptionStatus) ml_Boost_create(cv::Ptr<cv::ml::Boost> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ml::Boost::create();
    *returnValue = new cv::Ptr<cv::ml::Boost>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_Boost_delete(cv::Ptr<cv::ml::Boost> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_Boost_get(cv::Ptr<cv::ml::Boost>* obj, cv::ml::Boost **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Boost_load(const char *filePath, cv::Ptr<cv::ml::Boost> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::Algorithm::load<cv::ml::Boost>(filePath);
    *returnValue = new cv::Ptr<cv::ml::Boost>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Boost_loadFromString(const char *strModel, cv::Ptr<cv::ml::Boost> **returnValue)
{
    BEGIN_WRAP
    const auto objName = cv::ml::Boost::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::Boost>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::Boost>(ptr);
    END_WRAP
}

#endif
