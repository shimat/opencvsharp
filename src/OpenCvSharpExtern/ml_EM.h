#ifndef _CPP_ML_EM_H_
#define _CPP_ML_EM_H_

#include "include_opencv.h"
using namespace cv::ml;


CVAPI(cv::Ptr<EM>*) ml_EM_create(EM::Params params)
{
	cv::Ptr<EM> obj = EM::create(params);
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

CVAPI(cv::AlgorithmInfo*) ml_EM_info(cv::Ptr<EM> *obj)
{
	return (*obj)->info();
}

CVAPI(void) ml_EM_setParams(cv::Ptr<EM> *obj, EM::Params params)
{
	(*obj)->setParams(params);
}

CVAPI(EM::Params) ml_EM_getParams(cv::Ptr<EM> *obj)
{
	return (*obj)->getParams();
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


CVAPI(cv::Ptr<EM>*) ml_EM_static_train(
    cv::_InputArray *samples, 
    cv::_OutputArray *logLikelihoods, 
    cv::_OutputArray *labels, 
    cv::_OutputArray *probs)
{
	cv::Ptr<EM> em = EM::train(*samples, entity(logLikelihoods), entity(labels), entity(probs));
	return new cv::Ptr<EM>(em);
}

CVAPI(cv::Ptr<EM>*) ml_EM_static_train_startWithE(
    cv::_InputArray *samples,
    cv::_InputArray *means0,
    cv::_InputArray *covs0,
    cv::_InputArray *weights0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs,
	EM::Params params)
{
	cv::Ptr<EM> em = EM::train_startWithE(
        *samples, *means0, entity(covs0), entity(weights0), 
        entity(logLikelihoods), entity(labels), entity(probs));
	return new cv::Ptr<EM>(em);
}

CVAPI(cv::Ptr<EM>*) ml_EM_static_train_startWithM(
    cv::_InputArray *samples,
    cv::_InputArray *probs0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs,
	EM::Params params)
{
	cv::Ptr<EM> em = EM::train_startWithM(
        *samples, *probs0, entity(logLikelihoods), entity(labels), entity(probs));
	return new cv::Ptr<EM>(em);
}

#endif
