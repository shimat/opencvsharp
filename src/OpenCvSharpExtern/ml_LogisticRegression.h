#ifndef _CPP_ML_LOGISTICREGRESSION_H_
#define _CPP_ML_LOGISTICREGRESSION_H_

#include "include_opencv.h"
using namespace cv::ml;


CVAPI(double) ml_LogisticRegression_getLearningRate(LogisticRegression *obj)
{
    return obj->getLearningRate();
}
CVAPI(void) ml_LogisticRegression_setLearningRate(LogisticRegression *obj, double val)
{
    obj->setLearningRate(val);
}

CVAPI(int) ml_LogisticRegression_getIterations(LogisticRegression *obj)
{
    return obj->getIterations();
}
CVAPI(void) ml_LogisticRegression_setIterations(LogisticRegression *obj, int val)
{
    obj->setIterations(val);
}

CVAPI(int) ml_LogisticRegression_getRegularization(LogisticRegression *obj)
{
    return obj->getRegularization();
}
CVAPI(void) ml_LogisticRegression_setRegularization(LogisticRegression *obj, int val)
{
    obj->setRegularization(val);
}

CVAPI(int) ml_LogisticRegression_getTrainMethod(LogisticRegression *obj)
{
    return obj->getTrainMethod();
}
CVAPI(void) ml_LogisticRegression_setTrainMethod(LogisticRegression *obj, int val)
{
    obj->setTrainMethod(val);
}

CVAPI(int) ml_LogisticRegression_getMiniBatchSize(LogisticRegression *obj)
{
    return obj->getMiniBatchSize();
}
CVAPI(void) ml_LogisticRegression_setMiniBatchSize(LogisticRegression *obj, int val)
{
    obj->setMiniBatchSize(val);
}

CVAPI(MyCvTermCriteria) ml_LogisticRegression_getTermCriteria(LogisticRegression *obj)
{
    return c(obj->getTermCriteria());
}
CVAPI(void) ml_LogisticRegression_setTermCriteria(LogisticRegression *obj, MyCvTermCriteria val)
{
    obj->setTermCriteria(cpp(val));
}


CVAPI(float) ml_LogisticRegression_predict(
    LogisticRegression *obj, cv::_InputArray *samples, cv::_OutputArray *results, int flags)
{ 
    return obj->predict(entity(samples), entity(results), flags);
}

CVAPI(cv::Mat*) ml_LogisticRegression_get_learnt_thetas(LogisticRegression *obj)
{
    return new cv::Mat(obj->get_learnt_thetas());
}


CVAPI(cv::Ptr<LogisticRegression>*) ml_LogisticRegression_create()
{
    cv::Ptr<LogisticRegression> ptr = LogisticRegression::create();
    return new cv::Ptr<LogisticRegression>(ptr);
}

CVAPI(void) ml_Ptr_LogisticRegression_delete(cv::Ptr<LogisticRegression> *obj)
{
    delete obj;
}

CVAPI(LogisticRegression*) ml_Ptr_LogisticRegression_get(cv::Ptr<LogisticRegression> *obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<LogisticRegression>*) ml_LogisticRegression_load(const char *filePath)
{
    cv::Ptr<LogisticRegression> ptr = cv::Algorithm::load<LogisticRegression>(filePath);
    return new cv::Ptr<LogisticRegression>(ptr);
}

CVAPI(cv::Ptr<LogisticRegression>*) ml_LogisticRegression_loadFromString(const char *strModel)
{
    cv::String objname = cv::ml::LogisticRegression::create()->getDefaultName();
    cv::Ptr<LogisticRegression> ptr = cv::Algorithm::loadFromString<LogisticRegression>(strModel, objname);
    return new cv::Ptr<LogisticRegression>(ptr);
}

#endif
