#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) ml_EM_getClustersNumber(cv::ml::EM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getClustersNumber();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_EM_setClustersNumber(cv::ml::EM *obj, int val)
{
    BEGIN_WRAP
    obj->setClustersNumber(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_getCovarianceMatrixType(cv::ml::EM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getCovarianceMatrixType();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_EM_setCovarianceMatrixType(cv::ml::EM *obj, int val)
{
    BEGIN_WRAP
    obj->setCovarianceMatrixType(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_getTermCriteria(cv::ml::EM *obj, MyCvTermCriteria *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getTermCriteria());
    END_WRAP
}
CVAPI(ExceptionStatus) ml_EM_setTermCriteria(cv::ml::EM *obj, MyCvTermCriteria val)
{
    BEGIN_WRAP
    obj->setTermCriteria(cpp(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_getWeights(cv::ml::EM *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto m = obj->getWeights();
    *returnValue = new cv::Mat(m);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_getMeans(cv::ml::EM *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto m = obj->getMeans();
    *returnValue = new cv::Mat(m);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_getCovs(cv::ml::EM *obj, std::vector<cv::Mat*> *covs)
{
    BEGIN_WRAP
    std::vector<cv::Mat> raw;
    obj->getCovs(raw);
    covs->resize(raw.size());
    for (size_t i = 0; i < raw.size(); i++)
    {
        covs->at(i) = new cv::Mat(raw[i]);
    }
    END_WRAP
}


CVAPI(ExceptionStatus) ml_EM_predict2(
    cv::ml::EM *obj, cv::_InputArray *sample, cv::_OutputArray *probs, CvVec2d *returnValue)
{
    BEGIN_WRAP
    auto vec = obj->predict2(*sample, *probs);
    CvVec2d ret;
    ret.val[0] = vec[0];
    ret.val[1] = vec[1];
    *returnValue = ret;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_trainEM(
    cv::ml::EM *obj,
    cv::_InputArray *samples,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs, 
    int *returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->trainEM(*samples, entity(logLikelihoods), entity(labels), entity(probs));
    *returnValue = ret ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_trainE(
    cv::ml::EM *obj,
    cv::_InputArray *samples,
    cv::_InputArray *means0,
    cv::_InputArray *covs0,
    cv::_InputArray *weights0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs, 
    int *returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->trainE(
        *samples, *means0, entity(covs0), entity(weights0),
        entity(logLikelihoods), entity(labels), entity(probs));
    *returnValue = ret ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_trainM(
    cv::ml::EM *obj,
    cv::_InputArray *samples,
    cv::_InputArray *probs0,
    cv::_OutputArray *logLikelihoods,
    cv::_OutputArray *labels,
    cv::_OutputArray *probs, 
    int *returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->trainM(
        *samples, *probs0, entity(logLikelihoods), entity(labels), entity(probs));
    *returnValue = ret ? 1 : 0;
    END_WRAP
}


CVAPI(ExceptionStatus) ml_EM_create(cv::Ptr<cv::ml::EM> **returnValue)
{
    BEGIN_WRAP
    const auto obj = cv::ml::EM::create();
    *returnValue = new cv::Ptr<cv::ml::EM>(obj);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_EM_delete(cv::Ptr<cv::ml::EM> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_EM_get(cv::Ptr<cv::ml::EM> *obj, cv::ml::EM **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_load(const char *filePath, cv::Ptr<cv::ml::EM> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::Algorithm::load<cv::ml::EM>(filePath);
    *returnValue = new cv::Ptr<cv::ml::EM>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_EM_loadFromString(const char *strModel, cv::Ptr<cv::ml::EM> **returnValue)
{
    BEGIN_WRAP
    const auto objName = cv::ml::EM::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::EM>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::EM>(ptr);
    END_WRAP
}

