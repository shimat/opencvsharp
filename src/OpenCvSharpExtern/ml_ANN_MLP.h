#if WIN32
#pragma once
#endif

#ifndef _CPP_ML_ANN_MLP_H_
#define _CPP_ML_ANN_MLP_H_

#include "include_opencv.h"
using namespace cv::ml;


CVAPI(cv::Ptr<ANN_MLP>*) ml_ANN_MLP_create(ANN_MLP::Params params)
{
	cv::Ptr<ANN_MLP> val = ANN_MLP::create(params);
	return new cv::Ptr<ANN_MLP>(val);
}
CVAPI(void) ml_ANN_MLP_delete(cv::Ptr<ANN_MLP> *obj)
{
	delete obj;
}

CVAPI(ANN_MLP::Params) ml_ANN_MLP_getParams(cv::Ptr<ANN_MLP> *obj)
{
	return (*obj)->getParams();
}
CVAPI(void) ml_ANN_MLP_setParams(cv::Ptr<ANN_MLP> *obj, ANN_MLP::Params value)
{
	(*obj)->setParams(value);
}

CVAPI(cv::Mat*) ml_ANN_MLP_getWeights(cv::Ptr<ANN_MLP> *obj, int layerIdx)
{
	cv::Mat m = (*obj)->getWeights(layerIdx);
	return new cv::Mat(m);
}

#endif
