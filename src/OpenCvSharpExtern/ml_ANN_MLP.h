#ifndef _CPP_ML_ANN_MLP_H_
#define _CPP_ML_ANN_MLP_H_

#include "include_opencv.h"
using namespace cv::ml;


CVAPI(void) ml_ANN_MLP_setTrainMethod(ANN_MLP *obj, int method, double param1, double param2)
{
    obj->setTrainMethod(method, param1, param2);
}

CVAPI(int) ml_ANN_MLP_getTrainMethod(ANN_MLP *obj)
{
    return obj->getTrainMethod();
}

CVAPI(void) ml_ANN_MLP_setActivationFunction(ANN_MLP *obj, int type, double param1, double param2)
{
    obj->setActivationFunction(type, param1, param2);
}

CVAPI(void) ml_ANN_MLP_setLayerSizes(ANN_MLP *obj, cv::_InputArray *_layer_sizes)
{
    obj->setLayerSizes(entity(_layer_sizes));
}

CVAPI(cv::Mat*) ml_ANN_MLP_getLayerSizes(ANN_MLP *obj)
{
    return new cv::Mat(obj->getLayerSizes());
}


CVAPI(MyCvTermCriteria) ml_ANN_MLP_getTermCriteria(ANN_MLP *obj)
{
    return c(obj->getTermCriteria());
}
CVAPI(void) ml_ANN_MLP_setTermCriteria(ANN_MLP *obj, MyCvTermCriteria val)
{
    obj->setTermCriteria(cpp(val));
}

CVAPI(double) ml_ANN_MLP_getBackpropWeightScale(ANN_MLP *obj)
{
    return obj->getBackpropWeightScale();
}
CVAPI(void) ml_ANN_MLP_setBackpropWeightScale(ANN_MLP *obj, double val)
{
    obj->setBackpropWeightScale(val);
}

CVAPI(double) ml_ANN_MLP_getBackpropMomentumScale(ANN_MLP *obj)
{
    return obj->getBackpropMomentumScale();
}
CVAPI(void) ml_ANN_MLP_setBackpropMomentumScale(ANN_MLP *obj, double val)
{
    obj->setBackpropMomentumScale(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDW0(ANN_MLP *obj)
{
    return obj->getRpropDW0();
}
CVAPI(void) ml_ANN_MLP_setRpropDW0(ANN_MLP *obj, double val)
{
    obj->setRpropDW0(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDWPlus(ANN_MLP *obj)
{
    return obj->getRpropDWPlus();
}
CVAPI(void) ml_ANN_MLP_setRpropDWPlus(ANN_MLP *obj, double val)
{
    obj->setRpropDWPlus(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDWMinus(ANN_MLP *obj)
{
    return obj->getRpropDWMinus();
}
CVAPI(void) ml_ANN_MLP_setRpropDWMinus(ANN_MLP *obj, double val)
{
    obj->setRpropDWMinus(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDWMin(ANN_MLP *obj)
{
    return obj->getRpropDWMin();
}
CVAPI(void) ml_ANN_MLP_setRpropDWMin(ANN_MLP *obj, double val)
{
    obj->setRpropDWMin(val);
}

CVAPI(double) ml_ANN_MLP_getRpropDWMax(ANN_MLP *obj)
{
    return obj->getRpropDWMax();
}
CVAPI(void) ml_ANN_MLP_setRpropDWMax(ANN_MLP *obj, double val)
{
    obj->setRpropDWMax(val);
}

CVAPI(cv::Mat*) ml_ANN_MLP_getWeights(ANN_MLP *obj, int layerIdx)
{
    return new cv::Mat(obj->getWeights(layerIdx));
}


CVAPI(cv::Ptr<ANN_MLP>*) ml_ANN_MLP_create()
{
    cv::Ptr<ANN_MLP> ptr = ANN_MLP::create();
    return new cv::Ptr<ANN_MLP>(ptr);
}

CVAPI(void) ml_Ptr_ANN_MLP_delete(cv::Ptr<ANN_MLP> *obj)
{
    delete obj;
}

CVAPI(ANN_MLP*) ml_Ptr_ANN_MLP_get(cv::Ptr<ANN_MLP> *obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<ANN_MLP>*) ml_ANN_MLP_load(const char *filePath)
{
    cv::Ptr<ANN_MLP> ptr = ANN_MLP::load(filePath);
    return new cv::Ptr<ANN_MLP>(ptr);
}

CVAPI(cv::Ptr<ANN_MLP>*) ml_ANN_MLP_loadFromString(const char *strModel)
{
    cv::String objname = cv::ml::ANN_MLP::create()->getDefaultName();
    cv::Ptr<ANN_MLP> ptr = cv::Algorithm::loadFromString<ANN_MLP>(strModel, objname);
    return new cv::Ptr<ANN_MLP>(ptr);
}

#endif
