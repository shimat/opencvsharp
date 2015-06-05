#ifndef _CPP_ML_EM_H_
#define _CPP_ML_EM_H_

#include "include_opencv.h"
using namespace cv::ml;

// TODO

CVAPI(cv::Ptr<EM>*) ml_EM_create()
{
	cv::Ptr<EM> obj = EM::create();
	return new cv::Ptr<EM>(obj);
}

CVAPI(void) ml_EM_delete(cv::Ptr<EM> *obj)
{
	delete obj;
}

CVAPI(EM*) ml_Ptr_EM_get(cv::Ptr<EM> *obj)
{
	return obj->get();
}

CVAPI(int) ml_EM_getClustersNumber(cv::Ptr<EM> *obj)
{
	return (*obj)->getClustersNumber();
}

CVAPI(void) ml_EM_setClustersNumber(cv::Ptr<EM> *obj, int val)
{
	(*obj)->setClustersNumber(val);
}

CVAPI(cv::Mat*) ml_EM_getWeights(cv::Ptr<EM> *obj)
{
	cv::Mat m = (*obj)->getWeights();
	return new cv::Mat(m);
}

CVAPI(cv::Mat*) ml_EM_getMeans(cv::Ptr<EM> *obj)
{
	cv::Mat m = (*obj)->getMeans();
	return new cv::Mat(m);
}

CVAPI(void) ml_EM_getCovs(cv::Ptr<EM> *obj, std::vector<cv::Mat*> *covs)
{
	std::vector<cv::Mat> raw;
	(*obj)->getCovs(raw);
	covs->resize(raw.size());
	for (size_t i = 0; i < raw.size(); i++)
	{
		covs->at(i) = new cv::Mat(raw[i]);
	}
}


CVAPI(int) ml_EM_train(
	cv::Ptr<EM> *obj, cv::Ptr<TrainData> *trainData, int flags)
{
	return (*obj)->train(*trainData, flags) ? 1 : 0;
}

CVAPI(CvVec2d) ml_EM_predict2(
	cv::Ptr<EM> *obj, cv::_InputArray *sample, cv::_OutputArray *probs)
{
	cv::Vec2d vec = (*obj)->predict2(*sample, *probs);
	CvVec2d ret;
	ret.val[0] = vec[0];
	ret.val[1] = vec[1];
	return ret;
}


CVAPI(int) ml_EM_trainEM(
	cv::Ptr<EM> *obj,
    cv::_InputArray *samples, 
    cv::_OutputArray *logLikelihoods, 
    cv::_OutputArray *labels, 
    cv::_OutputArray *probs)
{
	bool ret = (*obj)->trainEM(*samples, entity(logLikelihoods), entity(labels), entity(probs));
	return ret ? 1 : 0;
}

CVAPI(int) ml_EM_trainE(
	cv::Ptr<EM> *obj,
    cv::_InputArray *samples,
    cv::_InputArray *means0,
    cv::_InputArray *covs0,
    cv::_InputArray *weights0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs)
{
	bool ret = (*obj)->trainE(
        *samples, *means0, entity(covs0), entity(weights0), 
        entity(logLikelihoods), entity(labels), entity(probs));
	return ret ? 1 : 0;
}

CVAPI(int) ml_EM_trainM(
	cv::Ptr<EM> *obj,
    cv::_InputArray *samples,
    cv::_InputArray *probs0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs)
{
	bool ret = (*obj)->trainM(
        *samples, *probs0, entity(logLikelihoods), entity(labels), entity(probs));
	return ret ? 1 : 0;
}

#endif
