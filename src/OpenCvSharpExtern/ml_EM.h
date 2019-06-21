#ifndef _CPP_ML_EM_H_
#define _CPP_ML_EM_H_

#include "include_opencv.h"


CVAPI(int) ml_EM_getClustersNumber(cv::ml::EM *obj)
{
    return obj->getClustersNumber();
}
CVAPI(void) ml_EM_setClustersNumber(cv::ml::EM *obj, int val)
{
    obj->setClustersNumber(val);
}

CVAPI(int) ml_EM_getCovarianceMatrixType(cv::ml::EM *obj)
{
    return obj->getCovarianceMatrixType();
}
CVAPI(void) ml_EM_setCovarianceMatrixType(cv::ml::EM *obj, int val)
{
    obj->setCovarianceMatrixType(val);
}

CVAPI(MyCvTermCriteria) ml_EM_getTermCriteria(cv::ml::EM *obj)
{
    return c(obj->getTermCriteria());
}
CVAPI(void) ml_EM_setTermCriteria(cv::ml::EM *obj, MyCvTermCriteria val)
{
    obj->setTermCriteria(cpp(val));
}

CVAPI(cv::Mat*) ml_EM_getWeights(cv::ml::EM *obj)
{
    cv::Mat m = obj->getWeights();
    return new cv::Mat(m);
}

CVAPI(cv::Mat*) ml_EM_getMeans(cv::ml::EM *obj)
{
    cv::Mat m = obj->getMeans();
    return new cv::Mat(m);
}

CVAPI(void) ml_EM_getCovs(cv::ml::EM *obj, std::vector<cv::Mat*> *covs)
{
    std::vector<cv::Mat> raw;
    obj->getCovs(raw);
    covs->resize(raw.size());
    for (size_t i = 0; i < raw.size(); i++)
    {
        covs->at(i) = new cv::Mat(raw[i]);
    }
}


CVAPI(CvVec2d) ml_EM_predict2(
    cv::ml::EM *obj, cv::_InputArray *sample, cv::_OutputArray *probs)
{
    cv::Vec2d vec = obj->predict2(*sample, *probs);
    CvVec2d ret;
    ret.val[0] = vec[0];
    ret.val[1] = vec[1];
    return ret;
}

CVAPI(int) ml_EM_trainEM(
    cv::ml::EM *obj,
    cv::_InputArray *samples,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs)
{
    bool ret = obj->trainEM(*samples, entity(logLikelihoods), entity(labels), entity(probs));
    return ret ? 1 : 0;
}

CVAPI(int) ml_EM_trainE(
    cv::ml::EM *obj,
    cv::_InputArray *samples,
    cv::_InputArray *means0,
    cv::_InputArray *covs0,
    cv::_InputArray *weights0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs)
{
    bool ret = obj->trainE(
        *samples, *means0, entity(covs0), entity(weights0),
        entity(logLikelihoods), entity(labels), entity(probs));
    return ret ? 1 : 0;
}

CVAPI(int) ml_EM_trainM(
    cv::ml::EM *obj,
    cv::_InputArray *samples,
    cv::_InputArray *probs0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs)
{
    bool ret = obj->trainM(
        *samples, *probs0, entity(logLikelihoods), entity(labels), entity(probs));
    return ret ? 1 : 0;
}


CVAPI(cv::Ptr<cv::ml::EM>*) ml_EM_create()
{
    const auto obj = cv::ml::EM::create();
    return new cv::Ptr<cv::ml::EM>(obj);
}

CVAPI(void) ml_Ptr_EM_delete(cv::Ptr<cv::ml::EM> *obj)
{
    delete obj;
}

CVAPI(cv::ml::EM*) ml_Ptr_EM_get(cv::Ptr<cv::ml::EM> *obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<cv::ml::EM>*) ml_EM_load(const char *filePath)
{
    const auto ptr = cv::Algorithm::load<cv::ml::EM>(filePath);
    return new cv::Ptr<cv::ml::EM>(ptr);
}

CVAPI(cv::Ptr<cv::ml::EM>*) ml_EM_loadFromString(const char *strModel)
{
    const auto objname = cv::ml::EM::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::EM>(strModel, objname);
    return new cv::Ptr<cv::ml::EM>(ptr);
}

#endif
