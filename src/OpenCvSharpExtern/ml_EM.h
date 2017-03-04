#ifndef _CPP_ML_EM_H_
#define _CPP_ML_EM_H_

#include "include_opencv.h"
using namespace cv::ml;


CVAPI(int) ml_EM_getClustersNumber(EM *obj)
{
    return obj->getClustersNumber();
}
CVAPI(void) ml_EM_setClustersNumber(EM *obj, int val)
{
    obj->setClustersNumber(val);
}

CVAPI(int) ml_EM_getCovarianceMatrixType(EM *obj)
{
    return obj->getCovarianceMatrixType();
}
CVAPI(void) ml_EM_setCovarianceMatrixType(EM *obj, int val)
{
    obj->setCovarianceMatrixType(val);
}

CVAPI(MyCvTermCriteria) ml_EM_getTermCriteria(EM *obj)
{
    return c(obj->getTermCriteria());
}
CVAPI(void) ml_EM_setTermCriteria(EM *obj, MyCvTermCriteria val)
{
    obj->setTermCriteria(cpp(val));
}

CVAPI(cv::Mat*) ml_EM_getWeights(EM *obj)
{
    cv::Mat m = obj->getWeights();
    return new cv::Mat(m);
}

CVAPI(cv::Mat*) ml_EM_getMeans(EM *obj)
{
    cv::Mat m = obj->getMeans();
    return new cv::Mat(m);
}

CVAPI(void) ml_EM_getCovs(EM *obj, std::vector<cv::Mat*> *covs)
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
    EM *obj, cv::_InputArray *sample, cv::_OutputArray *probs)
{
    cv::Vec2d vec = obj->predict2(*sample, *probs);
    CvVec2d ret;
    ret.val[0] = vec[0];
    ret.val[1] = vec[1];
    return ret;
}

CVAPI(int) ml_EM_trainEM(
    EM *obj,
    cv::_InputArray *samples,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs)
{
    bool ret = obj->trainEM(*samples, entity(logLikelihoods), entity(labels), entity(probs));
    return ret ? 1 : 0;
}

CVAPI(int) ml_EM_trainE(
    EM *obj,
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
    EM *obj,
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


CVAPI(cv::Ptr<EM>*) ml_EM_create()
{
    cv::Ptr<EM> obj = EM::create();
    return new cv::Ptr<EM>(obj);
}

CVAPI(void) ml_Ptr_EM_delete(cv::Ptr<EM> *obj)
{
    delete obj;
}

CVAPI(EM*) ml_Ptr_EM_get(cv::Ptr<EM> *obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<EM>*) ml_EM_load(const char *filePath)
{
    cv::Ptr<EM> ptr = cv::Algorithm::load<EM>(filePath);
    return new cv::Ptr<EM>(ptr);
}

CVAPI(cv::Ptr<EM>*) ml_EM_loadFromString(const char *strModel)
{
    cv::String objname = cv::ml::EM::create()->getDefaultName();
    cv::Ptr<EM> ptr = cv::Algorithm::loadFromString<EM>(strModel, objname);
    return new cv::Ptr<EM>(ptr);
}

#endif
