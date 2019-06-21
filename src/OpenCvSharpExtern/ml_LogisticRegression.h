#ifndef _CPP_ML_LOGISTICREGRESSION_H_
#define _CPP_ML_LOGISTICREGRESSION_H_

#include "include_opencv.h"


CVAPI(double) ml_LogisticRegression_getLearningRate(cv::ml::LogisticRegression *obj)
{
    return obj->getLearningRate();
}
CVAPI(void) ml_LogisticRegression_setLearningRate(cv::ml::LogisticRegression *obj, double val)
{
    obj->setLearningRate(val);
}

CVAPI(int) ml_LogisticRegression_getIterations(cv::ml::LogisticRegression *obj)
{
    return obj->getIterations();
}
CVAPI(void) ml_LogisticRegression_setIterations(cv::ml::LogisticRegression *obj, int val)
{
    obj->setIterations(val);
}

CVAPI(int) ml_LogisticRegression_getRegularization(cv::ml::LogisticRegression *obj)
{
    return obj->getRegularization();
}
CVAPI(void) ml_LogisticRegression_setRegularization(cv::ml::LogisticRegression *obj, int val)
{
    obj->setRegularization(val);
}

CVAPI(int) ml_LogisticRegression_getTrainMethod(cv::ml::LogisticRegression *obj)
{
    return obj->getTrainMethod();
}
CVAPI(void) ml_LogisticRegression_setTrainMethod(cv::ml::LogisticRegression *obj, int val)
{
    obj->setTrainMethod(val);
}

CVAPI(int) ml_LogisticRegression_getMiniBatchSize(cv::ml::LogisticRegression *obj)
{
    return obj->getMiniBatchSize();
}
CVAPI(void) ml_LogisticRegression_setMiniBatchSize(cv::ml::LogisticRegression *obj, int val)
{
    obj->setMiniBatchSize(val);
}

CVAPI(MyCvTermCriteria) ml_LogisticRegression_getTermCriteria(cv::ml::LogisticRegression *obj)
{
    return c(obj->getTermCriteria());
}
CVAPI(void) ml_LogisticRegression_setTermCriteria(cv::ml::LogisticRegression *obj, MyCvTermCriteria val)
{
    obj->setTermCriteria(cpp(val));
}


CVAPI(float) ml_LogisticRegression_predict(
    cv::ml::LogisticRegression *obj, cv::_InputArray *samples, cv::_OutputArray *results, int flags)
{ 
    return obj->predict(entity(samples), entity(results), flags);
}

CVAPI(cv::Mat*) ml_LogisticRegression_get_learnt_thetas(cv::ml::LogisticRegression *obj)
{
    return new cv::Mat(obj->get_learnt_thetas());
}


CVAPI(cv::Ptr<cv::ml::LogisticRegression>*) ml_LogisticRegression_create()
{
    const auto ptr = cv::ml::LogisticRegression::create();
    return new cv::Ptr<cv::ml::LogisticRegression>(ptr);
}

CVAPI(void) ml_Ptr_LogisticRegression_delete(cv::Ptr<cv::ml::LogisticRegression> *obj)
{
    delete obj;
}

CVAPI(cv::ml::LogisticRegression*) ml_Ptr_LogisticRegression_get(cv::Ptr<cv::ml::LogisticRegression> *obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<cv::ml::LogisticRegression>*) ml_LogisticRegression_load(const char *filePath)
{
    const auto ptr = cv::Algorithm::load<cv::ml::LogisticRegression>(filePath);
    return new cv::Ptr<cv::ml::LogisticRegression>(ptr);
}

CVAPI(cv::Ptr<cv::ml::LogisticRegression>*) ml_LogisticRegression_loadFromString(const char *strModel)
{
    const auto objname = cv::ml::LogisticRegression::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::LogisticRegression>(strModel, objname);
    return new cv::Ptr<cv::ml::LogisticRegression>(ptr);
}

#endif
