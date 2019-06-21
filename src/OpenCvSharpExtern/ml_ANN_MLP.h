#ifndef _CPP_ML_ANN_MLP_H_
#define _CPP_ML_ANN_MLP_H_

#include "include_opencv.h"


CVAPI(void) ml_ANN_MLP_setTrainMethod(cv::ml::ANN_MLP *obj, int method, double param1, double param2)
{
    obj->setTrainMethod(method, param1, param2);
}

CVAPI(int) ml_ANN_MLP_getTrainMethod(cv::ml::ANN_MLP *obj)
{
    return obj->getTrainMethod();
}

CVAPI(void) ml_ANN_MLP_setActivationFunction(cv::ml::ANN_MLP *obj, int type, double param1, double param2)
{
    obj->setActivationFunction(type, param1, param2);
}

CVAPI(void) ml_ANN_MLP_setLayerSizes(cv::ml::ANN_MLP *obj, cv::_InputArray *_layer_sizes)
{
    obj->setLayerSizes(entity(_layer_sizes));
}

CVAPI(cv::Mat*) ml_ANN_MLP_getLayerSizes(cv::ml::ANN_MLP *obj)
{
    return new cv::Mat(obj->getLayerSizes());
}


CVAPI(MyCvTermCriteria) ml_ANN_MLP_getTermCriteria(cv::ml::ANN_MLP *obj)
{
    return c(obj->getTermCriteria());
}
CVAPI(void) ml_ANN_MLP_setTermCriteria(cv::ml::ANN_MLP *obj, MyCvTermCriteria val)
{
    obj->setTermCriteria(cpp(val));
}

CVAPI(double) ml_ANN_MLP_getBackpropWeightScale(cv::ml::ANN_MLP *obj)
{
    return obj->getBackpropWeightScale();
}
CVAPI(void) ml_ANN_MLP_setBackpropWeightScale(cv::ml::ANN_MLP *obj, double val)
{
    obj->setBackpropWeightScale(val);
}

CVAPI(double) ml_ANN_MLP_getBackpropMomentumScale(cv::ml::ANN_MLP *obj)
{
    return obj->getBackpropMomentumScale();
}
CVAPI(void) ml_ANN_MLP_setBackpropMomentumScale(cv::ml::ANN_MLP *obj, double val)
{
    obj->setBackpropMomentumScale(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDW0(cv::ml::ANN_MLP *obj)
{
    return obj->getRpropDW0();
}
CVAPI(void) ml_ANN_MLP_setRpropDW0(cv::ml::ANN_MLP *obj, double val)
{
    obj->setRpropDW0(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDWPlus(cv::ml::ANN_MLP *obj)
{
    return obj->getRpropDWPlus();
}
CVAPI(void) ml_ANN_MLP_setRpropDWPlus(cv::ml::ANN_MLP *obj, double val)
{
    obj->setRpropDWPlus(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDWMinus(cv::ml::ANN_MLP *obj)
{
    return obj->getRpropDWMinus();
}
CVAPI(void) ml_ANN_MLP_setRpropDWMinus(cv::ml::ANN_MLP *obj, double val)
{
    obj->setRpropDWMinus(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDWMin(cv::ml::ANN_MLP *obj)
{
    return obj->getRpropDWMin();
}
CVAPI(void) ml_ANN_MLP_setRpropDWMin(cv::ml::ANN_MLP *obj, double val)
{
    obj->setRpropDWMin(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDWMax(cv::ml::ANN_MLP *obj)
{
    return obj->getRpropDWMax();
}
CVAPI(void) ml_ANN_MLP_setRpropDWMax(cv::ml::ANN_MLP *obj, double val)
{
    obj->setRpropDWMax(val);
}

CVAPI(cv::Mat*) ml_ANN_MLP_getWeights(cv::ml::ANN_MLP *obj, int layerIdx)
{
    return new cv::Mat(obj->getWeights(layerIdx));
}


CVAPI(cv::Ptr<cv::ml::ANN_MLP>*) ml_ANN_MLP_create()
{
    const auto ptr = cv::ml::ANN_MLP::create();
    return new cv::Ptr<cv::ml::ANN_MLP>(ptr);
}

CVAPI(void) ml_Ptr_ANN_MLP_delete(cv::Ptr<cv::ml::ANN_MLP> *obj)
{
    delete obj;
}

CVAPI(cv::ml::ANN_MLP*) ml_Ptr_ANN_MLP_get(cv::Ptr<cv::ml::ANN_MLP> *obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<cv::ml::ANN_MLP>*) ml_ANN_MLP_load(const char *filePath)
{
    const auto ptr = cv::ml::ANN_MLP::load(filePath);
    return new cv::Ptr<cv::ml::ANN_MLP>(ptr);
}

CVAPI(cv::Ptr<cv::ml::ANN_MLP>*) ml_ANN_MLP_loadFromString(const char *strModel)
{
    const auto objname = cv::ml::ANN_MLP::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::ANN_MLP>(strModel, objname);
    return new cv::Ptr<cv::ml::ANN_MLP>(ptr);
}

#endif
