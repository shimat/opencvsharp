#pragma once

#ifndef NO_ML

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_ANN_MLP_setTrainMethod(
    cv::ml::ANN_MLP *obj,
    int method,
    double param1,
    double param2)
{
    return cvTry([&] {
        obj->setTrainMethod(method, param1, param2);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getTrainMethod(cv::ml::ANN_MLP *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getTrainMethod();
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_setActivationFunction(
    cv::ml::ANN_MLP *obj,
    int type,
    double param1,
    double param2)
{
    return cvTry([&] {
        obj->setActivationFunction(type, param1, param2);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_setLayerSizes(cv::ml::ANN_MLP *obj, const interop::InputArrayProxy* _layer_sizes)
{
    return cvTry([&] {
        obj->setLayerSizes(InProxy(*_layer_sizes));
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getLayerSizes(cv::ml::ANN_MLP *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getLayerSizes());
    });
}


CVAPI(ExceptionStatus) ml_ANN_MLP_getTermCriteria(cv::ml::ANN_MLP *obj, interop::TermCriteria *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getTermCriteria());
    });
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setTermCriteria(cv::ml::ANN_MLP *obj, interop::TermCriteria val)
{
    return cvTry([&] {
        obj->setTermCriteria(cpp(val));
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getBackpropWeightScale(cv::ml::ANN_MLP *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getBackpropWeightScale();
    });
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setBackpropWeightScale(cv::ml::ANN_MLP *obj, double val)
{
    return cvTry([&] {
        obj->setBackpropWeightScale(val);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getBackpropMomentumScale(cv::ml::ANN_MLP *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getBackpropMomentumScale();
    });
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setBackpropMomentumScale(cv::ml::ANN_MLP *obj, double val)
{
    return cvTry([&] {
        obj->setBackpropMomentumScale(val);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDW0(cv::ml::ANN_MLP *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRpropDW0();
    });
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDW0(cv::ml::ANN_MLP *obj, double val)
{
    return cvTry([&] {
        obj->setRpropDW0(val);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDWPlus(cv::ml::ANN_MLP *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRpropDWPlus();
    });
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDWPlus(cv::ml::ANN_MLP *obj, double val)
{
    return cvTry([&] {
        obj->setRpropDWPlus(val);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDWMinus(cv::ml::ANN_MLP *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRpropDWMinus();
    });
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDWMinus(cv::ml::ANN_MLP *obj, double val)
{
    return cvTry([&] {
        obj->setRpropDWMinus(val);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDWMin(cv::ml::ANN_MLP *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRpropDWMin();
    });
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDWMin(cv::ml::ANN_MLP *obj, double val)
{
    return cvTry([&] {
        obj->setRpropDWMin(val);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getRpropDWMax(cv::ml::ANN_MLP *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRpropDWMax();
    });
}
CVAPI(ExceptionStatus) ml_ANN_MLP_setRpropDWMax(cv::ml::ANN_MLP *obj, double val)
{
    return cvTry([&] {
        obj->setRpropDWMax(val);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_getWeights(
    cv::ml::ANN_MLP *obj,
    int layerIdx,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getWeights(layerIdx));
    });
}


CVAPI(ExceptionStatus) ml_ANN_MLP_create(cv::Ptr<cv::ml::ANN_MLP> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ml::ANN_MLP::create();
        *returnValue = new cv::Ptr<cv::ml::ANN_MLP>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_ANN_MLP_delete(cv::Ptr<cv::ml::ANN_MLP> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_ANN_MLP_get(cv::Ptr<cv::ml::ANN_MLP> *obj, cv::ml::ANN_MLP **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_load(const char *filePath, cv::Ptr<cv::ml::ANN_MLP> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ml::ANN_MLP::load(filePath);
        *returnValue = new cv::Ptr<cv::ml::ANN_MLP>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_ANN_MLP_loadFromString(const char *strModel, cv::Ptr<cv::ml::ANN_MLP> **returnValue)
{
    return cvTry([&] {
        const auto objName = cv::ml::ANN_MLP::create()->getDefaultName();
        const auto ptr = cv::Algorithm::loadFromString<cv::ml::ANN_MLP>(strModel, objName);
        *returnValue = new cv::Ptr<cv::ml::ANN_MLP>(ptr);
    });
}

#endif // NO_ML
