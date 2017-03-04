#ifndef _CPP_ML_NORMALBAYESCLASSIFIER_H_
#define _CPP_ML_NORMALBAYESCLASSIFIER_H_

#include "include_opencv.h"
using namespace cv::ml;


CVAPI(float) ml_NormalBayesClassifier_predictProb(
    NormalBayesClassifier *obj, cv::_InputArray *inputs, 
    cv::_OutputArray *samples, cv::_OutputArray *outputProbs, int flags)
{
    return obj->predictProb(entity(inputs), entity(samples), entity(outputProbs), flags);
}

CVAPI(cv::Ptr<NormalBayesClassifier>*) ml_NormalBayesClassifier_create()
{
    cv::Ptr<NormalBayesClassifier> ptr = NormalBayesClassifier::create();
    return new cv::Ptr<NormalBayesClassifier>(ptr);
}

CVAPI(void) ml_Ptr_NormalBayesClassifier_delete(cv::Ptr<NormalBayesClassifier> *obj)
{
    delete obj;
}

CVAPI(NormalBayesClassifier*) ml_Ptr_NormalBayesClassifier_get(
    cv::Ptr<NormalBayesClassifier>* obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<NormalBayesClassifier>*) ml_NormalBayesClassifier_load(const char *filePath)
{
    cv::Ptr<NormalBayesClassifier> ptr = cv::Algorithm::load<NormalBayesClassifier>(filePath);
    return new cv::Ptr<NormalBayesClassifier>(ptr);
}

CVAPI(cv::Ptr<NormalBayesClassifier>*) ml_NormalBayesClassifier_loadFromString(const char *strModel)
{
    cv::String objname = cv::ml::NormalBayesClassifier::create()->getDefaultName();
    cv::Ptr<NormalBayesClassifier> ptr = cv::Algorithm::loadFromString<NormalBayesClassifier>(strModel, objname);
    return new cv::Ptr<NormalBayesClassifier>(ptr);
}

#endif
