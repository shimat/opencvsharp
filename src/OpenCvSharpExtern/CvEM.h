/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVEM_H_
#define _CVEM_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

CVAPI(int) cv_EM_sizeof()
{
	return sizeof(cv::EM);
}

CVAPI(cv::EM*) cv_EM_new(int nclusters, int covMatType, CvTermCriteria termCrit)
{
	cv::TermCriteria tc(termCrit);
	return new cv::EM(nclusters, covMatType, tc);
}
CVAPI(void) cv_EM_delete(cv::EM* model)
{
	delete model;
}


CVAPI(void) cv_EM_clear(cv::EM* model)
{
	model->clear();
}
CVAPI(int) cv_EM_train(cv::EM* model, CvMat* samples, CvMat* logLikelihoods, CvMat* labels, CvMat* probs)
{
	cv::Mat _samples(samples);
	cv::OutputArray _logLikelihoods = (logLikelihoods == NULL) ? cv::noArray() : cv::Mat(logLikelihoods);
	cv::OutputArray _labels = (labels == NULL) ? cv::noArray() : cv::Mat(labels);
	cv::OutputArray _probs = (probs == NULL) ? cv::noArray() : cv::Mat(probs);
	return model->train(_samples, _logLikelihoods, _labels, _probs) ? 1 : 0;
}

CVAPI(int) cv_EM_trainE(cv::EM* model, CvMat* samples, CvMat* covs0, CvMat* weights0, 
	CvMat* logLikelihoods, CvMat* labels, CvMat* probs)
{
	cv::Mat _samples(samples);
	cv::InputArray _covs0 = (covs0 == NULL) ? cv::noArray() : cv::Mat(covs0);
	cv::InputArray _weights0 = (weights0 == NULL) ? cv::noArray() : cv::Mat(weights0);
	cv::OutputArray _logLikelihoods = (logLikelihoods == NULL) ? cv::noArray() : cv::Mat(logLikelihoods);
	cv::OutputArray _labels = (labels == NULL) ? cv::noArray() : cv::Mat(labels);
	cv::OutputArray _probs = (probs == NULL) ? cv::noArray() : cv::Mat(probs);
	return model->trainE(_samples, _covs0, _weights0, _logLikelihoods, _labels, _probs) ? 1 : 0;
}
CVAPI(int) cv_EM_trainM(cv::EM* model, CvMat* samples, CvMat* probs0, CvMat* logLikelihoods, CvMat* labels, CvMat* probs)
{
	cv::Mat _samples(samples);
	cv::InputArray _probs0 = (probs0 == NULL) ? cv::noArray() : cv::Mat(probs0);
	cv::OutputArray _logLikelihoods = (logLikelihoods == NULL) ? cv::noArray() : cv::Mat(logLikelihoods);
	cv::OutputArray _labels = (labels == NULL) ? cv::noArray() : cv::Mat(labels);
	cv::OutputArray _probs = (probs == NULL) ? cv::noArray() : cv::Mat(probs);
	return model->trainM(_samples, _probs0, _logLikelihoods, _labels, _probs) ? 1 : 0;
}
CVAPI(void) cv_EM_predict(cv::EM* model, CvMat* sample, CvMat* probs, float* ret0, float* ret1)
{
	cv::Mat _sample(sample);
	cv::OutputArray _probs = (probs == NULL) ? cv::noArray() : cv::Mat(probs);
	cv::Vec2d ret = model->predict(_sample, _probs);
	*ret0 = ret[0];
	*ret1 = ret[1];
}
CVAPI(int) cv_EM_isTrained(cv::EM* model)
{
	return model->isTrained() ? 1 : 0;
}

#endif
