#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_LogisticRegression_getLearningRate(cv::ml::LogisticRegression *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getLearningRate();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setLearningRate(cv::ml::LogisticRegression *obj, double val)
{
    BEGIN_WRAP
    obj->setLearningRate(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getIterations(cv::ml::LogisticRegression *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getIterations();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setIterations(cv::ml::LogisticRegression *obj, int val)
{
    BEGIN_WRAP
    obj->setIterations(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getRegularization(cv::ml::LogisticRegression *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRegularization();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setRegularization(cv::ml::LogisticRegression *obj, int val)
{
    BEGIN_WRAP
    obj->setRegularization(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getTrainMethod(cv::ml::LogisticRegression *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getTrainMethod();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setTrainMethod(cv::ml::LogisticRegression *obj, int val)
{
    BEGIN_WRAP
    obj->setTrainMethod(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getMiniBatchSize(cv::ml::LogisticRegression *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMiniBatchSize();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setMiniBatchSize(cv::ml::LogisticRegression *obj, int val)
{
    BEGIN_WRAP
    obj->setMiniBatchSize(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getTermCriteria(cv::ml::LogisticRegression *obj, MyCvTermCriteria *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getTermCriteria());
    END_WRAP
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setTermCriteria(cv::ml::LogisticRegression *obj, MyCvTermCriteria val)
{
    BEGIN_WRAP
    obj->setTermCriteria(cpp(val));
    END_WRAP
}


CVAPI(ExceptionStatus) ml_LogisticRegression_predict(
    cv::ml::LogisticRegression *obj, cv::_InputArray *samples, cv::_OutputArray *results, int flags, float *returnValue)
{ 
    BEGIN_WRAP
    *returnValue = obj->predict(entity(samples), entity(results), flags);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_LogisticRegression_get_learnt_thetas(cv::ml::LogisticRegression *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->get_learnt_thetas());
    END_WRAP
}


CVAPI(ExceptionStatus) ml_LogisticRegression_create(cv::Ptr<cv::ml::LogisticRegression> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ml::LogisticRegression::create();
    *returnValue = new cv::Ptr<cv::ml::LogisticRegression>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_LogisticRegression_delete(cv::Ptr<cv::ml::LogisticRegression> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_LogisticRegression_get(
    cv::Ptr<cv::ml::LogisticRegression> *obj, cv::ml::LogisticRegression **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_LogisticRegression_load(
    const char *filePath, cv::Ptr<cv::ml::LogisticRegression> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::Algorithm::load<cv::ml::LogisticRegression>(filePath);
    *returnValue = new cv::Ptr<cv::ml::LogisticRegression>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_LogisticRegression_loadFromString(
    const char *strModel, cv::Ptr<cv::ml::LogisticRegression> **returnValue)
{
    BEGIN_WRAP
    const auto objName = cv::ml::LogisticRegression::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::LogisticRegression>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::LogisticRegression>(ptr);
    END_WRAP
}
