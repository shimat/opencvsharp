#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) xstereo_Ptr_QuasiDenseStereo_delete(cv::Ptr<cv::stereo::QuasiDenseStereo>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) xstereo_Ptr_QuasiDenseStereo_get(
    cv::Ptr<cv::stereo::QuasiDenseStereo>* ptr, cv::stereo::QuasiDenseStereo** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_create(
    interop::Size monoImgSize,
    const char* paramFilepath,
    cv::Ptr<cv::stereo::QuasiDenseStereo>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::stereo::QuasiDenseStereo::create(cpp(monoImgSize), cv::String(paramFilepath));
        *returnValue = new cv::Ptr<cv::stereo::QuasiDenseStereo>(ptr);
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_loadParameters(
    cv::stereo::QuasiDenseStereo* obj, const char* filepath, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->loadParameters(cv::String(filepath));
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_saveParameters(
    cv::stereo::QuasiDenseStereo* obj, const char* filepath, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->saveParameters(cv::String(filepath));
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_getSparseMatches(
    cv::stereo::QuasiDenseStereo* obj, std::vector<cv::stereo::MatchQuasiDense>* sMatches)
{
    return cvTry([&] {
        obj->getSparseMatches(*sMatches);
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_getDenseMatches(
    cv::stereo::QuasiDenseStereo* obj, std::vector<cv::stereo::MatchQuasiDense>* denseMatches)
{
    return cvTry([&] {
        obj->getDenseMatches(*denseMatches);
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_process(
    cv::stereo::QuasiDenseStereo* obj, cv::Mat* imgLeft, cv::Mat* imgRight)
{
    return cvTry([&] {
        obj->process(*imgLeft, *imgRight);
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_getMatch(
    cv::stereo::QuasiDenseStereo* obj, int x, int y, interop::Point2f* returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getMatch(x, y));
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_getDisparity(
    cv::stereo::QuasiDenseStereo* obj, cv::Mat** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getDisparity());
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_getParam(
    cv::stereo::QuasiDenseStereo* obj, cv::stereo::PropagationParameters* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->Param;
    });
}

CVAPI(ExceptionStatus) xstereo_QuasiDenseStereo_setParam(
    cv::stereo::QuasiDenseStereo* obj, cv::stereo::PropagationParameters* value)
{
    return cvTry([&] {
        obj->Param = *value;
    });
}

#endif // NO_CONTRIB
