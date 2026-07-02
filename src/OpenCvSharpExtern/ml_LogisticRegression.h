#pragma once

#ifndef NO_ML

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_LogisticRegression_getLearningRate(cv::ml::LogisticRegression *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getLearningRate();
    });
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setLearningRate(cv::ml::LogisticRegression *obj, double val)
{
    return cvTry([&] {
    obj->setLearningRate(val);
    });
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getIterations(cv::ml::LogisticRegression *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getIterations();
    });
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setIterations(cv::ml::LogisticRegression *obj, int val)
{
    return cvTry([&] {
    obj->setIterations(val);
    });
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getRegularization(cv::ml::LogisticRegression *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getRegularization();
    });
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setRegularization(cv::ml::LogisticRegression *obj, int val)
{
    return cvTry([&] {
    obj->setRegularization(val);
    });
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getTrainMethod(cv::ml::LogisticRegression *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getTrainMethod();
    });
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setTrainMethod(cv::ml::LogisticRegression *obj, int val)
{
    return cvTry([&] {
    obj->setTrainMethod(val);
    });
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getMiniBatchSize(cv::ml::LogisticRegression *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMiniBatchSize();
    });
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setMiniBatchSize(cv::ml::LogisticRegression *obj, int val)
{
    return cvTry([&] {
    obj->setMiniBatchSize(val);
    });
}

CVAPI(ExceptionStatus) ml_LogisticRegression_getTermCriteria(cv::ml::LogisticRegression *obj, interop::TermCriteria *returnValue)
{
    return cvTry([&] {
    *returnValue = c(obj->getTermCriteria());
    });
}
CVAPI(ExceptionStatus) ml_LogisticRegression_setTermCriteria(cv::ml::LogisticRegression *obj, interop::TermCriteria val)
{
    return cvTry([&] {
    obj->setTermCriteria(cpp(val));
    });
}


CVAPI(ExceptionStatus) ml_LogisticRegression_predict(
    cv::ml::LogisticRegression *obj,
    const interop::InputArrayProxy* samples,
    const interop::OutputArrayProxy* results,
    int flags,
    float *returnValue)
{ 
    return cvTry([&] {
    *returnValue = obj->predict(InProxy(*samples), OutProxy(*results), flags);
    });
}

CVAPI(ExceptionStatus) ml_LogisticRegression_get_learnt_thetas(cv::ml::LogisticRegression *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(obj->get_learnt_thetas());
    });
}


CVAPI(ExceptionStatus) ml_LogisticRegression_create(cv::Ptr<cv::ml::LogisticRegression> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ml::LogisticRegression::create();
    *returnValue = new cv::Ptr<cv::ml::LogisticRegression>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_LogisticRegression_delete(cv::Ptr<cv::ml::LogisticRegression> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_LogisticRegression_get(cv::Ptr<cv::ml::LogisticRegression> *obj, cv::ml::LogisticRegression **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_LogisticRegression_load(const char *filePath, cv::Ptr<cv::ml::LogisticRegression> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::Algorithm::load<cv::ml::LogisticRegression>(filePath);
    *returnValue = new cv::Ptr<cv::ml::LogisticRegression>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_LogisticRegression_loadFromString(const char *strModel, cv::Ptr<cv::ml::LogisticRegression> **returnValue)
{
    return cvTry([&] {
    const auto objName = cv::ml::LogisticRegression::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::LogisticRegression>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::LogisticRegression>(ptr);
    });
}

#endif // NO_ML
