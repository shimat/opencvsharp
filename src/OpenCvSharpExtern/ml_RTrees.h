#pragma once

#ifndef NO_ML

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) ml_RTrees_getCalculateVarImportance(cv::ml::RTrees *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getCalculateVarImportance() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) ml_RTrees_setCalculateVarImportance(cv::ml::RTrees *obj, int val)
{
    return cvTry([&] {
    obj->setCalculateVarImportance(val != 0);
    });
}

CVAPI(ExceptionStatus) ml_RTrees_getActiveVarCount(cv::ml::RTrees *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getActiveVarCount();
    });
}
CVAPI(ExceptionStatus) ml_RTrees_setActiveVarCount(cv::ml::RTrees *obj, int val)
{
    return cvTry([&] {
    obj->setActiveVarCount(val);
    });
}

CVAPI(ExceptionStatus) ml_RTrees_getTermCriteria(cv::ml::RTrees *obj, interop::TermCriteria *returnValue)
{
    return cvTry([&] {
    *returnValue = c(obj->getTermCriteria());
    });
}
CVAPI(ExceptionStatus) ml_RTrees_setTermCriteria(cv::ml::RTrees *obj, interop::TermCriteria val)
{
    return cvTry([&] {
    obj->setTermCriteria(cpp(val));
    });
}

CVAPI(ExceptionStatus) ml_RTrees_getVarImportance(cv::ml::RTrees *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(obj->getVarImportance());
    });
}

CVAPI(ExceptionStatus) ml_RTrees_create(cv::Ptr<cv::ml::RTrees> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ml::RTrees::create();
    *returnValue = new cv::Ptr<cv::ml::RTrees>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_RTrees_delete(cv::Ptr<cv::ml::RTrees> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_RTrees_get(cv::Ptr<cv::ml::RTrees> *obj, cv::ml::RTrees **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_RTrees_load(const char *filePath, cv::Ptr<cv::ml::RTrees> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::Algorithm::load<cv::ml::RTrees>(filePath);
    *returnValue = new cv::Ptr<cv::ml::RTrees>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_RTrees_loadFromString(const char *strModel, cv::Ptr<cv::ml::RTrees> **returnValue)
{
    return cvTry([&] {
    const auto objName = cv::ml::RTrees::create()->getDefaultName();
    const auto ptr = cv::Algorithm::loadFromString<cv::ml::RTrees>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::RTrees>(ptr);
    });
}

#endif // NO_ML
