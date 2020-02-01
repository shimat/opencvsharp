#ifndef _CPP_ML_KNEAREST_H_
#define _CPP_ML_KNEAREST_H_

#include "include_opencv.h"


CVAPI(ExceptionStatus) ml_KNearest_getDefaultK(cv::ml::KNearest *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDefaultK();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_KNearest_setDefaultK(cv::ml::KNearest *obj, int val)
{
    BEGIN_WRAP
    obj->setDefaultK(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_KNearest_getIsClassifier(cv::ml::KNearest *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getIsClassifier() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) ml_KNearest_setIsClassifier(cv::ml::KNearest *obj, int val)
{
    BEGIN_WRAP
    obj->setIsClassifier(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_KNearest_getEmax(cv::ml::KNearest *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getEmax();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_KNearest_setEmax(cv::ml::KNearest *obj, int val)
{
    BEGIN_WRAP
    obj->setEmax(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_KNearest_getAlgorithmType(cv::ml::KNearest *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getAlgorithmType();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_KNearest_setAlgorithmType(cv::ml::KNearest *obj, int val)
{
    BEGIN_WRAP
    obj->setAlgorithmType(val);
    END_WRAP
}


CVAPI(ExceptionStatus) ml_KNearest_findNearest(cv::ml::KNearest *obj, cv::_InputArray *samples, int k,
    cv::_OutputArray *results, cv::_OutputArray *neighborResponses, cv::_OutputArray *dist, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->findNearest(
        entity(samples), k, entity(results), entity(neighborResponses), entity(dist));
    END_WRAP
}


CVAPI(ExceptionStatus) ml_KNearest_create(cv::Ptr<cv::ml::KNearest> **returnValue)
{
    BEGIN_WRAP
    const auto  ptr = cv::ml::KNearest::create();
    *returnValue = new cv::Ptr<cv::ml::KNearest>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_KNearest_delete(cv::Ptr<cv::ml::KNearest> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_KNearest_get(cv::Ptr<cv::ml::KNearest>* obj, cv::ml::KNearest **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_KNearest_load(const char *filePath, cv::Ptr<cv::ml::KNearest> **returnValue)
{
    BEGIN_WRAP
    const auto  ptr = cv::Algorithm::load<cv::ml::KNearest>(filePath);
    *returnValue = new cv::Ptr<cv::ml::KNearest>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_KNearest_loadFromString(const char *strModel, cv::Ptr<cv::ml::KNearest> **returnValue)
{
    BEGIN_WRAP
    const auto objName = cv::ml::KNearest::create()->getDefaultName();
    const auto  ptr = cv::Algorithm::loadFromString<cv::ml::KNearest>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::KNearest>(ptr);
    END_WRAP
}

#endif
