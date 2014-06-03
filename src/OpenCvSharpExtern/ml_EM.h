#ifndef _CPP_ML_EM_H_
#define _CPP_ML_EM_H_

#include "include_opencv.h"

CVAPI(cv::EM*) ml_EM_new(int nclusters, int covMatType, CvTermCriteria termCrit)
{
	cv::TermCriteria tc(termCrit);
	return new cv::EM(nclusters, covMatType, tc);
}
CVAPI(void) ml_EM_delete(cv::EM *model)
{
	delete model;
}

CVAPI(void) ml_EM_clear(cv::EM *model)
{
	model->clear();
}
CVAPI(int) ml_EM_train(
    cv::EM *model, 
    cv::_InputArray *samples, 
    cv::_OutputArray *logLikelihoods, 
    cv::_OutputArray *labels, 
    cv::_OutputArray *probs)
{
	return model->train(*samples, entity(logLikelihoods), entity(labels), entity(probs)) ? 1 : 0;
}

CVAPI(int) ml_EM_trainE(
    cv::EM *model, 
    cv::_InputArray *samples,
    cv::_InputArray *means0,
    cv::_InputArray *covs0,
    cv::_InputArray *weights0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs)
{
	return model->trainE(
        *samples, *means0, entity(covs0), entity(weights0), 
        entity(logLikelihoods), entity(labels), entity(probs)) ? 1 : 0;
}
CVAPI(int) ml_EM_trainM(
    cv::EM *model, 
    cv::_InputArray *samples,
    cv::_InputArray *probs0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs)
{
	return model->trainM(
        *samples, *probs0, entity(logLikelihoods), entity(labels), entity(probs)) ? 1 : 0;
}
CVAPI(void) ml_EM_predict(
    cv::EM *model, 
    cv::_InputArray *sample, 
    cv::_OutputArray *probs, 
    cv::Vec2d *ret)
{
	*ret = model->predict(*sample, entity(probs));
}
CVAPI(int) ml_EM_isTrained(cv::EM *model)
{
	return model->isTrained() ? 1 : 0;
}

CVAPI(cv::AlgorithmInfo*) ml_EM_info(cv::EM *model)
{
    return model->info();
}

CVAPI(void) ml_EM_read(cv::EM *model, cv::FileNode *fn)
{
    model->read(*fn);
}

CVAPI(cv::EM*) ml_Ptr_EM_obj(cv::Ptr<cv::EM> *ptr)
{
    return ptr->obj;
}
CVAPI(void) ml_Ptr_EM_delete(cv::Ptr<cv::EM> *ptr)
{
    delete ptr;
}

#endif
