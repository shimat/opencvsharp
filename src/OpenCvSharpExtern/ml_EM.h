#pragma once

#ifndef NO_ML

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) ml_EM_getClustersNumber(cv::ml::EM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getClustersNumber();
    });
}
CVAPI(ExceptionStatus) ml_EM_setClustersNumber(cv::ml::EM *obj, int val)
{
    return cvTry([&] {
    obj->setClustersNumber(val);
    });
}

CVAPI(ExceptionStatus) ml_EM_getCovarianceMatrixType(cv::ml::EM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getCovarianceMatrixType();
    });
}
CVAPI(ExceptionStatus) ml_EM_setCovarianceMatrixType(cv::ml::EM *obj, int val)
{
    return cvTry([&] {
    obj->setCovarianceMatrixType(val);
    });
}

CVAPI(ExceptionStatus) ml_EM_getTermCriteria(cv::ml::EM *obj, interop::TermCriteria *returnValue)
{
    return cvTry([&] {
    *returnValue = c(obj->getTermCriteria());
    });
}
CVAPI(ExceptionStatus) ml_EM_setTermCriteria(cv::ml::EM *obj, interop::TermCriteria val)
{
    return cvTry([&] {
    obj->setTermCriteria(cpp(val));
    });
}

CVAPI(ExceptionStatus) ml_EM_getWeights(cv::ml::EM *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto m = obj->getWeights();
    *returnValue = new cv::Mat(m);
    });
}

CVAPI(ExceptionStatus) ml_EM_getMeans(cv::ml::EM *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto m = obj->getMeans();
    *returnValue = new cv::Mat(m);
    });
}

CVAPI(ExceptionStatus) ml_EM_getCovs(cv::ml::EM *obj, std::vector<cv::Mat*> *covs)
{
    return cvTry([&] {
    std::vector<cv::Mat> raw;
    obj->getCovs(raw);
    covs->resize(raw.size());
    for (size_t i = 0; i < raw.size(); i++)
    {
        covs->at(i) = new cv::Mat(raw[i]);
    }
    });
}


CVAPI(ExceptionStatus) ml_EM_predict2(
    cv::ml::EM *obj,
    const interop::InputArrayProxy* sample,
    const interop::OutputArrayProxy* probs,
    interop::Vec2d *returnValue)
{
    return cvTry([&] {
    auto vec = obj->predict2(InProxy(*sample), OutProxy(*probs));
    interop::Vec2d ret;
    ret.val[0] = vec[0];
    ret.val[1] = vec[1];
    *returnValue = ret;
    });
}

CVAPI(ExceptionStatus) ml_EM_trainEM(
    cv::ml::EM *obj,
    const interop::InputArrayProxy* samples,
    const interop::OutputArrayProxy* logLikelihoods,
    const interop::OutputArrayProxy* labels,
    const interop::OutputArrayProxy* probs,
    int *returnValue)
{
    return cvTry([&] {
    const auto ret = obj->trainEM(InProxy(*samples), OutProxy(*logLikelihoods), OutProxy(*labels), OutProxy(*probs));
    *returnValue = ret ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ml_EM_trainE(
    cv::ml::EM *obj,
    const interop::InputArrayProxy* samples,
    const interop::InputArrayProxy* means0,
    const interop::InputArrayProxy* covs0,
    const interop::InputArrayProxy* weights0,
    const interop::OutputArrayProxy* logLikelihoods,
    const interop::OutputArrayProxy* labels,
    const interop::OutputArrayProxy* probs,
    int *returnValue)
{
    return cvTry([&] {
    const auto ret = obj->trainE(
        InProxy(*samples), InProxy(*means0), InProxy(*covs0), InProxy(*weights0),
        OutProxy(*logLikelihoods), OutProxy(*labels), OutProxy(*probs));
    *returnValue = ret ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ml_EM_trainM(
    cv::ml::EM *obj,
    const interop::InputArrayProxy* samples,
    const interop::InputArrayProxy* probs0,
    const interop::OutputArrayProxy* logLikelihoods,
    const interop::OutputArrayProxy* labels,
    const interop::OutputArrayProxy* probs,
    int *returnValue)
{
    return cvTry([&] {
    const auto ret = obj->trainM(
        InProxy(*samples), InProxy(*probs0), OutProxy(*logLikelihoods), OutProxy(*labels), OutProxy(*probs));
    *returnValue = ret ? 1 : 0;
    });
}


CVAPI(ExceptionStatus) ml_EM_create(cv::Ptr<cv::ml::EM> **returnValue)
{
    return cvTry([&] {
    const auto obj = cv::ml::EM::create();
    *returnValue = new cv::Ptr<cv::ml::EM>(obj);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_EM_delete(cv::Ptr<cv::ml::EM> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_EM_get(cv::Ptr<cv::ml::EM> *obj, cv::ml::EM **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_EM_load(const char *filePath, cv::Ptr<cv::ml::EM> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::Algorithm::load<cv::ml::EM>(filePath);
    *returnValue = new cv::Ptr<cv::ml::EM>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_EM_loadFromString(const char *strModel, cv::Ptr<cv::ml::EM> **returnValue)
{
    return cvTry([&] {
    const auto objName = cv::ml::EM::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::EM>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::EM>(ptr);
    });
}

#endif // NO_ML
