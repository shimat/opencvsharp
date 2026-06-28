#pragma once

#ifndef NO_ML

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable CppInconsistentNaming

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_NormalBayesClassifier_predictProb(
    cv::ml::NormalBayesClassifier *obj, cv::_InputArray *inputs, 
    cv::_OutputArray *samples, cv::_OutputArray *outputProbs, int flags, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->predictProb(entity(inputs), entity(samples), entity(outputProbs), flags);
    });
}

CVAPI(ExceptionStatus) ml_NormalBayesClassifier_create(cv::Ptr<cv::ml::NormalBayesClassifier> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ml::NormalBayesClassifier::create();
    *returnValue = new cv::Ptr<cv::ml::NormalBayesClassifier>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_NormalBayesClassifier_delete(cv::Ptr<cv::ml::NormalBayesClassifier> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_NormalBayesClassifier_get(
    cv::Ptr<cv::ml::NormalBayesClassifier>* obj, cv::ml::NormalBayesClassifier **returnValue)

{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_NormalBayesClassifier_load(const char *filePath, cv::Ptr<cv::ml::NormalBayesClassifier> **returnValue)
{
    return cvTry([&] {
    const auto  ptr = cv::Algorithm::load<cv::ml::NormalBayesClassifier>(filePath);
    *returnValue = new cv::Ptr<cv::ml::NormalBayesClassifier>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_NormalBayesClassifier_loadFromString(const char *strModel, cv::Ptr<cv::ml::NormalBayesClassifier> **returnValue)
{
    return cvTry([&] {
    const auto objName = cv::ml::NormalBayesClassifier::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::NormalBayesClassifier>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::NormalBayesClassifier>(ptr);
    });
}

#endif // NO_ML
