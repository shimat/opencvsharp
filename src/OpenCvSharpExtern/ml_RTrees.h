#ifndef _CPP_ML_RTREES_H_
#define _CPP_ML_RTREES_H_

#include "include_opencv.h"


CVAPI(int) ml_RTrees_getCalculateVarImportance(cv::ml::RTrees *obj)
{
    return obj->getCalculateVarImportance() ? 1 : 0;
}
CVAPI(void) ml_RTrees_setCalculateVarImportance(cv::ml::RTrees *obj, int val)
{
    obj->setCalculateVarImportance(val != 0);
}

CVAPI(int) ml_RTrees_getActiveVarCount(cv::ml::RTrees *obj)
{
    return obj->getActiveVarCount();
}
CVAPI(void) ml_RTrees_setActiveVarCount(cv::ml::RTrees *obj, int val)
{
    obj->setActiveVarCount(val);
}

CVAPI(MyCvTermCriteria) ml_RTrees_getTermCriteria(cv::ml::RTrees *obj)
{
    return c(obj->getTermCriteria());
}
CVAPI(void) ml_RTrees_setTermCriteria(cv::ml::RTrees *obj, MyCvTermCriteria val)
{
    obj->setTermCriteria(cpp(val));
}

CVAPI(cv::Mat*) ml_RTrees_getVarImportance(cv::ml::RTrees *obj)
{
    return new cv::Mat(obj->getVarImportance());
}

CVAPI(cv::Ptr<cv::ml::RTrees>*) ml_RTrees_create()
{
    const auto ptr = cv::ml::RTrees::create();
    return new cv::Ptr<cv::ml::RTrees>(ptr);
}

CVAPI(void) ml_Ptr_RTrees_delete(cv::Ptr<cv::ml::RTrees> *obj)
{
    delete obj;
}

CVAPI(cv::ml::RTrees*) ml_Ptr_RTrees_get(cv::Ptr<cv::ml::RTrees> *obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<cv::ml::RTrees>*) ml_RTrees_load(const char *filePath)
{
    const auto ptr = cv::Algorithm::load<cv::ml::RTrees>(filePath);
    return new cv::Ptr<cv::ml::RTrees>(ptr);
}

CVAPI(cv::Ptr<cv::ml::RTrees>*) ml_RTrees_loadFromString(const char *strModel)
{
    const auto objname = cv::ml::RTrees::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::RTrees>(strModel, objname);
    return new cv::Ptr<cv::ml::RTrees>(ptr);
}

#endif
