#ifndef _CPP_ML_SVM_H_
#define _CPP_ML_SVM_H_

#include "include_opencv.h"
#include "ml.h"


CVAPI(int) ml_SVM_getType(cv::ml::SVM *obj)
{
	return obj->getType();
}
CVAPI(void) ml_SVM_setType(cv::ml::SVM *obj, int val)
{
	obj->setType(val);
}

CVAPI(double) ml_SVM_getGamma(cv::ml::SVM *obj)
{
	return obj->getGamma();
}
CVAPI(void) ml_SVM_setGamma(cv::ml::SVM *obj, double val)
{
	obj->setGamma(val);
}

CVAPI(double) ml_SVM_getCoef0(cv::ml::SVM *obj)
{
	return obj->getCoef0();
}
CVAPI(void) ml_SVM_setCoef0(cv::ml::SVM *obj, double val)
{
	obj->setCoef0(val);
}

CVAPI(double) ml_SVM_getDegree(cv::ml::SVM *obj)
{
	return obj->getDegree();
}
CVAPI(void) ml_SVM_setDegree(cv::ml::SVM *obj, double val)
{
	obj->setDegree(val);
}

CVAPI(double) ml_SVM_getC(cv::ml::SVM *obj)
{
	return obj->getC();
}
CVAPI(void) ml_SVM_setC(cv::ml::SVM *obj, double val)
{
	obj->setC(val);
}

CVAPI(double) ml_SVM_getP(cv::ml::SVM *obj)
{
	return obj->getP();
}
CVAPI(void) ml_SVM_setP(cv::ml::SVM *obj, double val)
{
	obj->setP(val);
}

CVAPI(double) ml_SVM_getNu(cv::ml::SVM *obj)
{
	return obj->getNu();
}
CVAPI(void) ml_SVM_setNu(cv::ml::SVM *obj, double val)
{
	obj->setNu(val);
}

CVAPI(cv::Mat*) ml_SVM_getClassWeights(cv::ml::SVM *obj)
{
	return new cv::Mat(obj->getClassWeights());
}
CVAPI(void) ml_SVM_setClassWeights(cv::ml::SVM *obj, cv::Mat *val)
{
	obj->setClassWeights(*val);
}

CVAPI(MyCvTermCriteria) ml_SVM_getTermCriteria(cv::ml::SVM *obj)
{
	return c(obj->getTermCriteria());
}
CVAPI(void) ml_SVM_setTermCriteria(cv::ml::SVM *obj, MyCvTermCriteria val)
{
	obj->setTermCriteria(cpp(val));
}

CVAPI(int) ml_SVM_getKernelType(cv::ml::SVM *obj)
{
	return obj->getKernelType();
}

CVAPI(void) ml_SVM_setKernel(cv::ml::SVM *obj, int kernelType)
{
	obj->setKernel(kernelType);
}

CVAPI(cv::Mat*) ml_SVM_getSupportVectors(cv::ml::SVM *obj)
{
	return new cv::Mat(obj->getSupportVectors());
}

CVAPI(double) ml_SVM_getDecisionFunction(
	cv::ml::SVM *obj, int i, cv::_OutputArray *alpha, cv::_OutputArray *svidx)
{
	return obj->getDecisionFunction(i, *alpha, *svidx);
}

CVAPI(ParamGridStruct) ml_SVM_getDefaultGrid(int param_id)
{ 
	return c(cv::ml::SVM::getDefaultGrid(param_id));
}

CVAPI(cv::Ptr<SVM>*) ml_SVM_create()
{
	cv::Ptr<cv::ml::SVM> ptr = cv::ml::SVM::create();
	return new cv::Ptr<cv::ml::SVM>(ptr);
}

CVAPI(void) ml_Ptr_SVM_delete(cv::Ptr<cv::ml::SVM> *obj)
{
	delete obj;
}

CVAPI(cv::ml::SVM*) ml_Ptr_SVM_get(cv::Ptr<cv::ml::SVM>* obj)
{
	return obj->get();
}

#endif
