#ifndef _CPP_ML_ANN_MLP_H_
#define _CPP_ML_ANN_MLP_H_

#include "include_opencv.h"
using namespace cv::ml;


// TODO

CVAPI(cv::Ptr<ANN_MLP>*) ml_ANN_MLP_create()
{
	cv::Ptr<ANN_MLP> val = ANN_MLP::create();
	return new cv::Ptr<ANN_MLP>(val);
}
CVAPI(void) ml_ANN_MLP_delete(cv::Ptr<ANN_MLP> *obj)
{
	delete obj;
}

CVAPI(int) ml_ANN_MLP_getTrainMethod(cv::Ptr<ANN_MLP> *obj)
{
	return (*obj)->getTrainMethod();
}
CVAPI(void) ml_ANN_MLP_setTrainMethod(cv::Ptr<ANN_MLP> *obj, int method, double param1, double param2)
{
	(*obj)->setTrainMethod(method, param1, param2);
}

CVAPI(cv::Mat*) ml_ANN_MLP_getWeights(cv::Ptr<ANN_MLP> *obj, int layerIdx)
{
	cv::Mat m = (*obj)->getWeights(layerIdx);
	return new cv::Mat(m);
}

#endif
