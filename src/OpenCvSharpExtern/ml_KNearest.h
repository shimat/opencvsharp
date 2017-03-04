#ifndef _CPP_ML_KNEAREST_H_
#define _CPP_ML_KNEAREST_H_

#include "include_opencv.h"
using namespace cv::ml;


CVAPI(int) ml_KNearest_getDefaultK(KNearest *obj)
{
    return obj->getDefaultK();
}
CVAPI(void) ml_KNearest_setDefaultK(KNearest *obj, int val)
{
    obj->setDefaultK(val);
}

CVAPI(int) ml_KNearest_getIsClassifier(KNearest *obj)
{
    return obj->getIsClassifier() ? 1 : 0;
}
CVAPI(void) ml_KNearest_setIsClassifier(KNearest *obj, int val)
{
    obj->setIsClassifier(val != 0);
}

CVAPI(int) ml_KNearest_getEmax(KNearest *obj)
{
    return obj->getEmax();
}
CVAPI(void) ml_KNearest_setEmax(KNearest *obj, int val)
{
    obj->setEmax(val);
}

CVAPI(int) ml_KNearest_getAlgorithmType(KNearest *obj)
{
    return obj->getAlgorithmType();
}
CVAPI(void) ml_KNearest_setAlgorithmType(KNearest *obj, int val)
{
    obj->setAlgorithmType(val);
}


CVAPI(float) ml_KNearest_findNearest(KNearest *obj, cv::_InputArray *samples, int k,
    cv::_OutputArray *results, cv::_OutputArray *neighborResponses, cv::_OutputArray *dist)
{
    return obj->findNearest(
        entity(samples), k, entity(results), entity(neighborResponses), entity(dist));
}


CVAPI(cv::Ptr<KNearest>*) ml_KNearest_create()
{
    cv::Ptr<KNearest> ptr = KNearest::create();
    return new cv::Ptr<KNearest>(ptr);
}

CVAPI(void) ml_Ptr_KNearest_delete(cv::Ptr<KNearest> *obj)
{
    delete obj;
}

CVAPI(KNearest*) ml_Ptr_KNearest_get(cv::Ptr<KNearest>* obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<KNearest>*) ml_KNearest_load(const char *filePath)
{
    cv::Ptr<KNearest> ptr = cv::Algorithm::load<KNearest>(filePath);
    return new cv::Ptr<KNearest>(ptr);
}

CVAPI(cv::Ptr<KNearest>*) ml_KNearest_loadFromString(const char *strModel)
{
    cv::String objname = cv::ml::KNearest::create()->getDefaultName();
    cv::Ptr<KNearest> ptr = cv::Algorithm::loadFromString<KNearest>(strModel, objname);
    return new cv::Ptr<KNearest>(ptr);
}

#endif
