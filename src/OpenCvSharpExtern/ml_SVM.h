#pragma once

#ifndef NO_ML

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable once CppInconsistentNaming

#include "include_opencv.h"
#include "ml.h"

CVAPI(ExceptionStatus) ml_SVM_getType(cv::ml::SVM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getType();
    });
}
CVAPI(ExceptionStatus) ml_SVM_setType(cv::ml::SVM *obj, int val)
{
    return cvTry([&] {
    obj->setType(val);
    });
}

CVAPI(ExceptionStatus) ml_SVM_getGamma(cv::ml::SVM *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getGamma();
    });
}
CVAPI(ExceptionStatus) ml_SVM_setGamma(cv::ml::SVM *obj, double val)
{
    return cvTry([&] {
    obj->setGamma(val);
    });
}

CVAPI(ExceptionStatus) ml_SVM_getCoef0(cv::ml::SVM *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getCoef0();
    });
}
CVAPI(ExceptionStatus) ml_SVM_setCoef0(cv::ml::SVM *obj, double val)
{
    return cvTry([&] {
    obj->setCoef0(val);
    });
}

CVAPI(ExceptionStatus) ml_SVM_getDegree(cv::ml::SVM *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getDegree();
    });
}
CVAPI(ExceptionStatus) ml_SVM_setDegree(cv::ml::SVM *obj, double val)
{
    return cvTry([&] {
    obj->setDegree(val);
    });
}

CVAPI(ExceptionStatus) ml_SVM_getC(cv::ml::SVM *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getC();
    });
}
CVAPI(ExceptionStatus) ml_SVM_setC(cv::ml::SVM *obj, double val)
{
    return cvTry([&] {
    obj->setC(val);
    });
}

CVAPI(ExceptionStatus) ml_SVM_getP(cv::ml::SVM *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getP();
    });
}
CVAPI(ExceptionStatus) ml_SVM_setP(cv::ml::SVM *obj, double val)
{
    return cvTry([&] {
    obj->setP(val);
    });
}

CVAPI(ExceptionStatus) ml_SVM_getNu(cv::ml::SVM *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNu();
    });
}
CVAPI(ExceptionStatus) ml_SVM_setNu(cv::ml::SVM *obj, double val)
{
    return cvTry([&] {
    obj->setNu(val);
    });
}

CVAPI(ExceptionStatus) ml_SVM_getClassWeights(cv::ml::SVM *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(obj->getClassWeights());
    });
}
CVAPI(ExceptionStatus) ml_SVM_setClassWeights(cv::ml::SVM *obj, cv::Mat *val)
{
    return cvTry([&] {
    obj->setClassWeights(*val);
    });
}

CVAPI(ExceptionStatus) ml_SVM_getTermCriteria(cv::ml::SVM *obj, interop::TermCriteria *returnValue)
{
    return cvTry([&] {
    *returnValue = c(obj->getTermCriteria());
    });
}
CVAPI(ExceptionStatus) ml_SVM_setTermCriteria(cv::ml::SVM *obj, interop::TermCriteria val)
{
    return cvTry([&] {
    obj->setTermCriteria(cpp(val));
    });
}

CVAPI(ExceptionStatus) ml_SVM_getKernelType(cv::ml::SVM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getKernelType();
    });
}

CVAPI(ExceptionStatus) ml_SVM_setKernel(cv::ml::SVM *obj, int kernelType)
{
    return cvTry([&] {
    obj->setKernel(kernelType);
    });
}

CVAPI(ExceptionStatus) ml_SVM_getSupportVectors(cv::ml::SVM *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(obj->getSupportVectors());
    });
}

CVAPI(ExceptionStatus) ml_SVM_getDecisionFunction(
    cv::ml::SVM *obj,
    int i,
    const interop::OutputArrayProxy* alpha,
    const interop::OutputArrayProxy* svidx,
    double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getDecisionFunction(i, OutProxy(*alpha), OutProxy(*svidx));
    });
}


// static

CVAPI(ExceptionStatus) ml_SVM_getDefaultGrid(int param_id, ParamGridStruct *returnValue)
{ 
    return cvTry([&] {
    *returnValue = c(cv::ml::SVM::getDefaultGrid(param_id));
    });
}

CVAPI(ExceptionStatus) ml_SVM_create(cv::Ptr<cv::ml::SVM> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ml::SVM::create();
    *returnValue = new cv::Ptr<cv::ml::SVM>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_SVM_delete(cv::Ptr<cv::ml::SVM> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_SVM_get(cv::Ptr<cv::ml::SVM>* obj, cv::ml::SVM **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_SVM_load(const char *filePath, cv::Ptr<cv::ml::SVM> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ml::SVM::load(filePath);
    *returnValue = new cv::Ptr<cv::ml::SVM>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_SVM_loadFromString(const char *strModel, cv::Ptr<cv::ml::SVM> **returnValue)
{
    return cvTry([&] {
    const auto objName = cv::ml::SVM::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::SVM>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::SVM>(ptr);
    });
}

#endif // NO_ML
