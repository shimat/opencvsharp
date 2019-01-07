#ifndef _CPP_ML_NORMALBAYESCLASSIFIER_H_
#define _CPP_ML_NORMALBAYESCLASSIFIER_H_

#include "include_opencv.h"


CVAPI(float) ml_NormalBayesClassifier_predictProb(
    cv::ml::NormalBayesClassifier *obj, cv::_InputArray *inputs, 
    cv::_OutputArray *samples, cv::_OutputArray *outputProbs, int flags)
{
    return obj->predictProb(entity(inputs), entity(samples), entity(outputProbs), flags);
}

CVAPI(cv::Ptr<cv::ml::NormalBayesClassifier>*) ml_NormalBayesClassifier_create()
{
    const auto ptr = cv::ml::NormalBayesClassifier::create();
    return new cv::Ptr<cv::ml::NormalBayesClassifier>(ptr);
}

CVAPI(void) ml_Ptr_NormalBayesClassifier_delete(cv::Ptr<cv::ml::NormalBayesClassifier> *obj)
{
    delete obj;
}

CVAPI(cv::ml::NormalBayesClassifier*) ml_Ptr_NormalBayesClassifier_get(
    cv::Ptr<cv::ml::NormalBayesClassifier>* obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<cv::ml::NormalBayesClassifier>*) ml_NormalBayesClassifier_load(const char *filePath)
{
    const auto  ptr = cv::Algorithm::load<cv::ml::NormalBayesClassifier>(filePath);
    return new cv::Ptr<cv::ml::NormalBayesClassifier>(ptr);
}

CVAPI(cv::Ptr<cv::ml::NormalBayesClassifier>*) ml_NormalBayesClassifier_loadFromString(const char *strModel)
{
    const auto objname = cv::ml::NormalBayesClassifier::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::NormalBayesClassifier>(strModel, objname);
    return new cv::Ptr<cv::ml::NormalBayesClassifier>(ptr);
}

#endif
