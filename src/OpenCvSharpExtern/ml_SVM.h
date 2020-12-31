#pragma once

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable once CppInconsistentNaming

#include "include_opencv.h"
#include "ml.h"

CVAPI(ExceptionStatus) ml_SVM_getType(cv::ml::SVM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getType();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_SVM_setType(cv::ml::SVM *obj, int val)
{
    BEGIN_WRAP
    obj->setType(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getGamma(cv::ml::SVM *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getGamma();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_SVM_setGamma(cv::ml::SVM *obj, double val)
{
    BEGIN_WRAP
    obj->setGamma(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getCoef0(cv::ml::SVM *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getCoef0();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_SVM_setCoef0(cv::ml::SVM *obj, double val)
{
    BEGIN_WRAP
    obj->setCoef0(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getDegree(cv::ml::SVM *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDegree();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_SVM_setDegree(cv::ml::SVM *obj, double val)
{
    BEGIN_WRAP
    obj->setDegree(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getC(cv::ml::SVM *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getC();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_SVM_setC(cv::ml::SVM *obj, double val)
{
    BEGIN_WRAP
    obj->setC(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getP(cv::ml::SVM *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getP();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_SVM_setP(cv::ml::SVM *obj, double val)
{
    BEGIN_WRAP
    obj->setP(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getNu(cv::ml::SVM *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNu();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_SVM_setNu(cv::ml::SVM *obj, double val)
{
    BEGIN_WRAP
    obj->setNu(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getClassWeights(cv::ml::SVM *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->getClassWeights());
    END_WRAP
}
CVAPI(ExceptionStatus) ml_SVM_setClassWeights(cv::ml::SVM *obj, cv::Mat *val)
{
    BEGIN_WRAP
    obj->setClassWeights(*val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getTermCriteria(cv::ml::SVM *obj, MyCvTermCriteria *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getTermCriteria());
    END_WRAP
}
CVAPI(ExceptionStatus) ml_SVM_setTermCriteria(cv::ml::SVM *obj, MyCvTermCriteria val)
{
    BEGIN_WRAP
    obj->setTermCriteria(cpp(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getKernelType(cv::ml::SVM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getKernelType();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_setKernel(cv::ml::SVM *obj, int kernelType)
{
    BEGIN_WRAP
    obj->setKernel(kernelType);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getSupportVectors(cv::ml::SVM *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->getSupportVectors());
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_getDecisionFunction(
    cv::ml::SVM *obj, int i, cv::_OutputArray *alpha, cv::_OutputArray *svidx, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDecisionFunction(i, entity(alpha), entity(svidx));
    END_WRAP
}


// static

CVAPI(ExceptionStatus) ml_SVM_getDefaultGrid(int param_id, ParamGridStruct *returnValue)
{ 
    BEGIN_WRAP
    *returnValue = c(cv::ml::SVM::getDefaultGrid(param_id));
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_create(cv::Ptr<cv::ml::SVM> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ml::SVM::create();
    *returnValue = new cv::Ptr<cv::ml::SVM>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_SVM_delete(cv::Ptr<cv::ml::SVM> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_SVM_get(cv::Ptr<cv::ml::SVM>* obj, cv::ml::SVM **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_load(const char *filePath, cv::Ptr<cv::ml::SVM> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ml::SVM::load(filePath);
    *returnValue = new cv::Ptr<cv::ml::SVM>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_SVM_loadFromString(const char *strModel, cv::Ptr<cv::ml::SVM> **returnValue)
{
    BEGIN_WRAP
    const auto objName = cv::ml::SVM::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::SVM>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::SVM>(ptr);
    END_WRAP
}
