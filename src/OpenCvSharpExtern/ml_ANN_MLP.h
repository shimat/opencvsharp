#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_ANN_MLP_setTrainMethod(cv::ml::ANN_MLP *obj, int method, double param1, double param2)
{
    BEGIN_WRAP
    obj->setTrainMethod(method, param1, param2);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getTrainMethod(cv::ml::ANN_MLP *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getTrainMethod();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_setActivationFunction(cv::ml::ANN_MLP *obj, int type, double param1, double param2)
{
    BEGIN_WRAP
    obj->setActivationFunction(type, param1, param2);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_setLayerSizes(cv::ml::ANN_MLP *obj, cv::_InputArray *_layer_sizes)
{
    BEGIN_WRAP
    obj->setLayerSizes(entity(_layer_sizes));
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getLayerSizes(cv::ml::ANN_MLP *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->getLayerSizes());
    END_WRAP
}


CVAPI(ExceptionStatus) ml_ANN_MLP_getTermCriteria(cv::ml::ANN_MLP *obj, MyCvTermCriteria *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getTermCriteria());
    END_WRAP
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setTermCriteria(cv::ml::ANN_MLP *obj, MyCvTermCriteria val)
{
    BEGIN_WRAP
    obj->setTermCriteria(cpp(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getBackpropWeightScale(cv::ml::ANN_MLP *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getBackpropWeightScale();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setBackpropWeightScale(cv::ml::ANN_MLP *obj, double val)
{
    BEGIN_WRAP
    obj->setBackpropWeightScale(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getBackpropMomentumScale(cv::ml::ANN_MLP *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getBackpropMomentumScale();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setBackpropMomentumScale(cv::ml::ANN_MLP *obj, double val)
{
    BEGIN_WRAP
    obj->setBackpropMomentumScale(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDW0(cv::ml::ANN_MLP *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRpropDW0();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDW0(cv::ml::ANN_MLP *obj, double val)
{
    BEGIN_WRAP
    obj->setRpropDW0(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDWPlus(cv::ml::ANN_MLP *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRpropDWPlus();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDWPlus(cv::ml::ANN_MLP *obj, double val)
{
    BEGIN_WRAP
    obj->setRpropDWPlus(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDWMinus(cv::ml::ANN_MLP *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRpropDWMinus();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDWMinus(cv::ml::ANN_MLP *obj, double val)
{
    BEGIN_WRAP
    obj->setRpropDWMinus(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDWMin(cv::ml::ANN_MLP *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRpropDWMin();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDWMin(cv::ml::ANN_MLP *obj, double val)
{
    BEGIN_WRAP
    obj->setRpropDWMin(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDWMax(cv::ml::ANN_MLP *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRpropDWMax();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDWMax(cv::ml::ANN_MLP *obj, double val)
{
    BEGIN_WRAP
    obj->setRpropDWMax(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getWeights(cv::ml::ANN_MLP *obj, int layerIdx, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->getWeights(layerIdx));
    END_WRAP
}


CVAPI(ExceptionStatus) ml_ANN_MLP_create(cv::Ptr<cv::ml::ANN_MLP> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ml::ANN_MLP::create();
    *returnValue = new cv::Ptr<cv::ml::ANN_MLP>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_ANN_MLP_delete(cv::Ptr<cv::ml::ANN_MLP> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_ANN_MLP_get(cv::Ptr<cv::ml::ANN_MLP> *obj, cv::ml::ANN_MLP **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_load(const char *filePath, cv::Ptr<cv::ml::ANN_MLP> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ml::ANN_MLP::load(filePath);
    *returnValue = new cv::Ptr<cv::ml::ANN_MLP>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_ANN_MLP_loadFromString(const char *strModel, cv::Ptr<cv::ml::ANN_MLP> **returnValue)
{
    BEGIN_WRAP
    const auto objName = cv::ml::ANN_MLP::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::ANN_MLP>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::ANN_MLP>(ptr);
    END_WRAP
}

