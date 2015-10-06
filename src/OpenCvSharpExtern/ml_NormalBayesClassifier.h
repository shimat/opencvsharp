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

#endif
