#ifndef _CPP_ML_SVM_H_
#define _CPP_ML_SVM_H_

#include "include_opencv.h"
#include "ml.h"

using namespace cv::ml;


CVAPI(int) ml_SVM_getType(SVM *obj)
{
    return obj->getType();
}
CVAPI(void) ml_SVM_setType(SVM *obj, int val)
{
    obj->setType(val);
}

CVAPI(double) ml_SVM_getGamma(SVM *obj)
{
    return obj->getGamma();
}
CVAPI(void) ml_SVM_setGamma(SVM *obj, double val)
{
    obj->setGamma(val);
}

CVAPI(double) ml_SVM_getCoef0(SVM *obj)
{
    return obj->getCoef0();
}
CVAPI(void) ml_SVM_setCoef0(SVM *obj, double val)
{
    obj->setCoef0(val);
}

CVAPI(double) ml_SVM_getDegree(SVM *obj)
{
    return obj->getDegree();
}
CVAPI(void) ml_SVM_setDegree(SVM *obj, double val)
{
    obj->setDegree(val);
}

CVAPI(double) ml_SVM_getC(SVM *obj)
{
    return obj->getC();
}
CVAPI(void) ml_SVM_setC(SVM *obj, double val)
{
    obj->setC(val);
}

CVAPI(double) ml_SVM_getP(SVM *obj)
{
    return obj->getP();
}
CVAPI(void) ml_SVM_setP(SVM *obj, double val)
{
    obj->setP(val);
}

CVAPI(double) ml_SVM_getNu(SVM *obj)
{
    return obj->getNu();
}
CVAPI(void) ml_SVM_setNu(SVM *obj, double val)
{
    obj->setNu(val);
}

CVAPI(cv::Mat*) ml_SVM_getClassWeights(SVM *obj)
{
    return new cv::Mat(obj->getClassWeights());
}
CVAPI(void) ml_SVM_setClassWeights(SVM *obj, cv::Mat *val)
{
    obj->setClassWeights(*val);
}

CVAPI(MyCvTermCriteria) ml_SVM_getTermCriteria(SVM *obj)
{
    return c(obj->getTermCriteria());
}
CVAPI(void) ml_SVM_setTermCriteria(SVM *obj, MyCvTermCriteria val)
{
    obj->setTermCriteria(cpp(val));
}

CVAPI(int) ml_SVM_getKernelType(SVM *obj)
{
    return obj->getKernelType();
}

CVAPI(void) ml_SVM_setKernel(SVM *obj, int kernelType)
{
    obj->setKernel(kernelType);
}

CVAPI(cv::Mat*) ml_SVM_getSupportVectors(SVM *obj)
{
    return new cv::Mat(obj->getSupportVectors());
}

CVAPI(double) ml_SVM_getDecisionFunction(
    cv::ml::SVM *obj, int i, cv::_OutputArray *alpha, cv::_OutputArray *svidx)
{
    return obj->getDecisionFunction(i, entity(alpha), entity(svidx));
}


// static

CVAPI(ParamGridStruct) ml_SVM_getDefaultGrid(int param_id)
{ 
    return c(cv::ml::SVM::getDefaultGrid(param_id));
}

CVAPI(cv::Ptr<SVM>*) ml_SVM_create()
{
    cv::Ptr<SVM> ptr = SVM::create();
    return new cv::Ptr<SVM>(ptr);
}

CVAPI(void) ml_Ptr_SVM_delete(cv::Ptr<SVM> *obj)
{
    delete obj;
}

CVAPI(cv::ml::SVM*) ml_Ptr_SVM_get(cv::Ptr<SVM>* obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<SVM>*) ml_SVM_load(const char *filePath)
{
    cv::Ptr<SVM> ptr = SVM::load(filePath);
    return new cv::Ptr<SVM>(ptr);
}

CVAPI(cv::Ptr<SVM>*) ml_SVM_loadFromString(const char *strModel)
{
    cv::String objname = cv::ml::SVM::create()->getDefaultName();
    cv::Ptr<SVM> ptr = cv::Algorithm::loadFromString<SVM>(strModel, objname);
    return new cv::Ptr<SVM>(ptr);
}

#endif
