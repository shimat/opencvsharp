#ifndef _CPP_ML_BOOST_H_
#define _CPP_ML_BOOST_H_

#include "include_opencv.h"


CVAPI(int) ml_Boost_getBoostType(cv::ml::Boost *obj)
{
    return obj->getBoostType();
}
CVAPI(void) ml_Boost_setBoostType(cv::ml::Boost *obj, int val)
{
    obj->setBoostType(val);
}

CVAPI(int) ml_Boost_getWeakCount(cv::ml::Boost *obj)
{
    return obj->getWeakCount();
}
CVAPI(void) ml_Boost_setWeakCount(cv::ml::Boost *obj, int val)
{
    obj->setWeakCount(val);
}

CVAPI(double) ml_Boost_getWeightTrimRate(cv::ml::Boost *obj)
{
    return obj->getWeightTrimRate();
}
CVAPI(void) ml_Boost_setWeightTrimRate(cv::ml::Boost *obj, double val)
{
    obj->setWeightTrimRate(val);
}


CVAPI(cv::Ptr<cv::ml::Boost>*) ml_Boost_create()
{
    const auto ptr = cv::ml::Boost::create();
    return new cv::Ptr<cv::ml::Boost>(ptr);
}

CVAPI(void) ml_Ptr_Boost_delete(cv::Ptr<cv::ml::Boost> *obj)
{
    delete obj;
}

CVAPI(cv::ml::Boost*) ml_Ptr_Boost_get(cv::Ptr<cv::ml::Boost>* obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<cv::ml::Boost>*) ml_Boost_load(const char *filePath)
{
    const auto ptr = cv::Algorithm::load<cv::ml::Boost>(filePath);
    return new cv::Ptr<cv::ml::Boost>(ptr);
}

CVAPI(cv::Ptr<cv::ml::Boost>*) ml_Boost_loadFromString(const char *strModel)
{
    const auto objname = cv::ml::Boost::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::Boost>(strModel, objname);
    return new cv::Ptr<cv::ml::Boost>(ptr);
}

#endif
