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
	cv::Ptr<cv::ml::NormalBayesClassifier> ptr = cv::ml::NormalBayesClassifier::create();
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

#endif
