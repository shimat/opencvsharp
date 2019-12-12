#ifndef _CPP_ML_NORMALBAYESCLASSIFIER_H_
#define _CPP_ML_NORMALBAYESCLASSIFIER_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable CppInconsistentNaming

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_NormalBayesClassifier_predictProb(
    cv::ml::NormalBayesClassifier *obj, cv::_InputArray *inputs, 
    cv::_OutputArray *samples, cv::_OutputArray *outputProbs, int flags, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->predictProb(entity(inputs), entity(samples), entity(outputProbs), flags);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_NormalBayesClassifier_create(cv::Ptr<cv::ml::NormalBayesClassifier> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ml::NormalBayesClassifier::create();
    *returnValue = new cv::Ptr<cv::ml::NormalBayesClassifier>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_NormalBayesClassifier_delete(cv::Ptr<cv::ml::NormalBayesClassifier> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_NormalBayesClassifier_get(
    cv::Ptr<cv::ml::NormalBayesClassifier>* obj, cv::ml::NormalBayesClassifier **returnValue)

{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_NormalBayesClassifier_load(const char *filePath, cv::Ptr<cv::ml::NormalBayesClassifier> **returnValue)
{
    BEGIN_WRAP
    const auto  ptr = cv::Algorithm::load<cv::ml::NormalBayesClassifier>(filePath);
    *returnValue = new cv::Ptr<cv::ml::NormalBayesClassifier>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_NormalBayesClassifier_loadFromString(const char *strModel, cv::Ptr<cv::ml::NormalBayesClassifier> **returnValue)
{
    BEGIN_WRAP
    const auto objName = cv::ml::NormalBayesClassifier::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::NormalBayesClassifier>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::NormalBayesClassifier>(ptr);
    END_WRAP
}

#endif
