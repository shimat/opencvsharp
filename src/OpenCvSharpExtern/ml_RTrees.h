#ifndef _CPP_ML_RTREES_H_
#define _CPP_ML_RTREES_H_

#include "include_opencv.h"


CVAPI(ExceptionStatus) ml_RTrees_getCalculateVarImportance(cv::ml::RTrees *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getCalculateVarImportance() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) ml_RTrees_setCalculateVarImportance(cv::ml::RTrees *obj, int val)
{
    BEGIN_WRAP
    obj->setCalculateVarImportance(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_RTrees_getActiveVarCount(cv::ml::RTrees *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getActiveVarCount();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_RTrees_setActiveVarCount(cv::ml::RTrees *obj, int val)
{
    BEGIN_WRAP
    obj->setActiveVarCount(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_RTrees_getTermCriteria(cv::ml::RTrees *obj, MyCvTermCriteria *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getTermCriteria());
    END_WRAP
}
CVAPI(ExceptionStatus) ml_RTrees_setTermCriteria(cv::ml::RTrees *obj, MyCvTermCriteria val)
{
    BEGIN_WRAP
    obj->setTermCriteria(cpp(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ml_RTrees_getVarImportance(cv::ml::RTrees *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->getVarImportance());
    END_WRAP
}

CVAPI(ExceptionStatus) ml_RTrees_create(cv::Ptr<cv::ml::RTrees> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ml::RTrees::create();
    *returnValue = new cv::Ptr<cv::ml::RTrees>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_RTrees_delete(cv::Ptr<cv::ml::RTrees> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_RTrees_get(cv::Ptr<cv::ml::RTrees> *obj, cv::ml::RTrees **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_RTrees_load(const char *filePath, cv::Ptr<cv::ml::RTrees> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::Algorithm::load<cv::ml::RTrees>(filePath);
    *returnValue = new cv::Ptr<cv::ml::RTrees>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_RTrees_loadFromString(const char *strModel, cv::Ptr<cv::ml::RTrees> **returnValue)
{
    BEGIN_WRAP
    const auto objName = cv::ml::RTrees::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::RTrees>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::RTrees>(ptr);
    END_WRAP
}

#endif
