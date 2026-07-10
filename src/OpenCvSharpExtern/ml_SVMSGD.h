#pragma once

#ifndef NO_ML

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable once CppInconsistentNaming

#include "include_opencv.h"
#include "ml.h"

CVAPI(ExceptionStatus) ml_SVMSGD_getWeights(cv::ml::SVMSGD *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getWeights());
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_getShift(cv::ml::SVMSGD *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getShift();
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_setOptimalParameters(cv::ml::SVMSGD *obj, int svmsgdType, int marginType)
{
    return cvTry([&] {
        obj->setOptimalParameters(svmsgdType, marginType);
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_getSvmsgdType(cv::ml::SVMSGD *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSvmsgdType();
    });
}
CVAPI(ExceptionStatus) ml_SVMSGD_setSvmsgdType(cv::ml::SVMSGD *obj, int val)
{
    return cvTry([&] {
        obj->setSvmsgdType(val);
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_getMarginType(cv::ml::SVMSGD *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMarginType();
    });
}
CVAPI(ExceptionStatus) ml_SVMSGD_setMarginType(cv::ml::SVMSGD *obj, int val)
{
    return cvTry([&] {
        obj->setMarginType(val);
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_getMarginRegularization(cv::ml::SVMSGD *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMarginRegularization();
    });
}
CVAPI(ExceptionStatus) ml_SVMSGD_setMarginRegularization(cv::ml::SVMSGD *obj, float val)
{
    return cvTry([&] {
        obj->setMarginRegularization(val);
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_getInitialStepSize(cv::ml::SVMSGD *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getInitialStepSize();
    });
}
CVAPI(ExceptionStatus) ml_SVMSGD_setInitialStepSize(cv::ml::SVMSGD *obj, float val)
{
    return cvTry([&] {
        obj->setInitialStepSize(val);
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_getStepDecreasingPower(cv::ml::SVMSGD *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getStepDecreasingPower();
    });
}
CVAPI(ExceptionStatus) ml_SVMSGD_setStepDecreasingPower(cv::ml::SVMSGD *obj, float val)
{
    return cvTry([&] {
        obj->setStepDecreasingPower(val);
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_getTermCriteria(cv::ml::SVMSGD *obj, interop::TermCriteria *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getTermCriteria());
    });
}
CVAPI(ExceptionStatus) ml_SVMSGD_setTermCriteria(cv::ml::SVMSGD *obj, interop::TermCriteria val)
{
    return cvTry([&] {
        obj->setTermCriteria(cpp(val));
    });
}

// static

CVAPI(ExceptionStatus) ml_SVMSGD_create(cv::Ptr<cv::ml::SVMSGD> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ml::SVMSGD::create();
        *returnValue = new cv::Ptr<cv::ml::SVMSGD>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_SVMSGD_delete(cv::Ptr<cv::ml::SVMSGD> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_SVMSGD_get(cv::Ptr<cv::ml::SVMSGD>* obj, cv::ml::SVMSGD **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_load(const char *filePath, cv::Ptr<cv::ml::SVMSGD> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::Algorithm::load<cv::ml::SVMSGD>(filePath);
        if (ptr.empty())
            CV_Error(cv::Error::StsError, cv::format("Failed to load SVMSGD model from: %s", filePath));
        *returnValue = new cv::Ptr<cv::ml::SVMSGD>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_SVMSGD_loadFromString(const char *strModel, cv::Ptr<cv::ml::SVMSGD> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::Algorithm::loadFromString<cv::ml::SVMSGD>(strModel);
        if (ptr.empty())
            CV_Error(cv::Error::StsError, "Failed to load SVMSGD model from string");
        *returnValue = new cv::Ptr<cv::ml::SVMSGD>(ptr);
    });
}

#endif // NO_ML
