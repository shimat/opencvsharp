#pragma once

#ifndef NO_CONTRIB
#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// ERFilter::Callback

CVAPI(ExceptionStatus) text_Ptr_ERFilterCallback_delete(cv::Ptr<cv::text::ERFilter::Callback>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) text_Ptr_ERFilterCallback_get(cv::Ptr<cv::text::ERFilter::Callback>* ptr, cv::text::ERFilter::Callback** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) text_loadClassifierNM1(const char* filename, cv::Ptr<cv::text::ERFilter::Callback>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::loadClassifierNM1(cv::String(filename));
        *returnValue = new cv::Ptr<cv::text::ERFilter::Callback>(ptr);
    });
}

CVAPI(ExceptionStatus) text_loadClassifierNM2(const char* filename, cv::Ptr<cv::text::ERFilter::Callback>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::loadClassifierNM2(cv::String(filename));
        *returnValue = new cv::Ptr<cv::text::ERFilter::Callback>(ptr);
    });
}

// ERFilter

CVAPI(ExceptionStatus) text_Ptr_ERFilter_delete(cv::Ptr<cv::text::ERFilter>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) text_Ptr_ERFilter_get(cv::Ptr<cv::text::ERFilter>* ptr, cv::text::ERFilter** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) text_createERFilterNM1_callback(
    cv::Ptr<cv::text::ERFilter::Callback>* cb, int thresholdDelta, float minArea, float maxArea,
    float minProbability, int nonMaxSuppression, float minProbabilityDiff,
    cv::Ptr<cv::text::ERFilter>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::createERFilterNM1(
            *cb, thresholdDelta, minArea, maxArea, minProbability, nonMaxSuppression != 0, minProbabilityDiff);
        *returnValue = new cv::Ptr<cv::text::ERFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) text_createERFilterNM1_file(
    const char* filename, int thresholdDelta, float minArea, float maxArea,
    float minProbability, int nonMaxSuppression, float minProbabilityDiff,
    cv::Ptr<cv::text::ERFilter>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::createERFilterNM1(
            cv::String(filename), thresholdDelta, minArea, maxArea, minProbability, nonMaxSuppression != 0, minProbabilityDiff);
        *returnValue = new cv::Ptr<cv::text::ERFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) text_createERFilterNM2_callback(
    cv::Ptr<cv::text::ERFilter::Callback>* cb, float minProbability, cv::Ptr<cv::text::ERFilter>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::createERFilterNM2(*cb, minProbability);
        *returnValue = new cv::Ptr<cv::text::ERFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) text_createERFilterNM2_file(
    const char* filename, float minProbability, cv::Ptr<cv::text::ERFilter>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::createERFilterNM2(cv::String(filename), minProbability);
        *returnValue = new cv::Ptr<cv::text::ERFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) text_ERFilter_setCallback(cv::text::ERFilter* obj, cv::Ptr<cv::text::ERFilter::Callback>* cb)
{
    return cvTry([&] {
        obj->setCallback(*cb);
    });
}

CVAPI(ExceptionStatus) text_ERFilter_setThresholdDelta(cv::text::ERFilter* obj, int thresholdDelta)
{
    return cvTry([&] { obj->setThresholdDelta(thresholdDelta); });
}

CVAPI(ExceptionStatus) text_ERFilter_setMinArea(cv::text::ERFilter* obj, float minArea)
{
    return cvTry([&] { obj->setMinArea(minArea); });
}

CVAPI(ExceptionStatus) text_ERFilter_setMaxArea(cv::text::ERFilter* obj, float maxArea)
{
    return cvTry([&] { obj->setMaxArea(maxArea); });
}

CVAPI(ExceptionStatus) text_ERFilter_setMinProbability(cv::text::ERFilter* obj, float minProbability)
{
    return cvTry([&] { obj->setMinProbability(minProbability); });
}

CVAPI(ExceptionStatus) text_ERFilter_setMinProbabilityDiff(cv::text::ERFilter* obj, float minProbabilityDiff)
{
    return cvTry([&] { obj->setMinProbabilityDiff(minProbabilityDiff); });
}

CVAPI(ExceptionStatus) text_ERFilter_setNonMaxSuppression(cv::text::ERFilter* obj, int nonMaxSuppression)
{
    return cvTry([&] { obj->setNonMaxSuppression(nonMaxSuppression != 0); });
}

CVAPI(ExceptionStatus) text_ERFilter_getNumRejected(cv::text::ERFilter* obj, int* returnValue)
{
    return cvTry([&] { *returnValue = obj->getNumRejected(); });
}

// Free functions

CVAPI(ExceptionStatus) text_computeNMChannels(
    const interop::InputArrayProxy* src, std::vector<cv::Mat>* channels, int mode)
{
    return cvTry([&] {
        cv::text::computeNMChannels(InProxy(*src), *channels, mode);
    });
}

CVAPI(ExceptionStatus) text_detectRegions_contours(
    const interop::InputArrayProxy* image,
    cv::Ptr<cv::text::ERFilter>* erFilter1,
    cv::Ptr<cv::text::ERFilter>* erFilter2,
    std::vector<std::vector<cv::Point>>* regions)
{
    return cvTry([&] {
        cv::text::detectRegions(InProxy(*image), *erFilter1, *erFilter2, *regions);
    });
}

CVAPI(ExceptionStatus) text_detectRegions_rects(
    const interop::InputArrayProxy* image,
    cv::Ptr<cv::text::ERFilter>* erFilter1,
    cv::Ptr<cv::text::ERFilter>* erFilter2,
    std::vector<cv::Rect>* groupsRects,
    int method,
    const char* filename,
    float minProbability)
{
    return cvTry([&] {
        cv::text::detectRegions(InProxy(*image), *erFilter1, *erFilter2, *groupsRects, method, cv::String(filename), minProbability);
    });
}

#endif // _WINRT_DLL
#endif // NO_CONTRIB
