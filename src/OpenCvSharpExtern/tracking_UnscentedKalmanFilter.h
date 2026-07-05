#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

// TODO
#if false
#include "include_opencv.h"
#include <opencv2/tracking/kalman_filters.hpp>

CVAPI(ExceptionStatus) tracking_createUnscentedKalmanFilter(
    cv::Ptr<cv::tracking::UnscentedKalmanFilter> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::tracking::createUnscentedKalmanFilter();
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) tracking_Ptr_UnscentedKalmanFilter_delete(
    cv::Ptr<cv::tracking::UnscentedKalmanFilter> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) tracking_Ptr_UnscentedKalmanFilter_get(
    cv::Ptr<cv::tracking::UnscentedKalmanFilter> *ptr, 
    cv::tracking::UnscentedKalmanFilter **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

#endif
