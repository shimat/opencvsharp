#ifndef _CPP_TRACKING_UNSCENTEDKALMANFILTER_H_
#define _CPP_TRACKING_UNSCENTEDKALMANFILTER_H_

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
    BEGIN_WRAP
    const auto p = cv::tracking::createUnscentedKalmanFilter();
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_UnscentedKalmanFilter_delete(
    cv::Ptr<cv::tracking::UnscentedKalmanFilter> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) tracking_Ptr_UnscentedKalmanFilter_get(
    cv::Ptr<cv::tracking::UnscentedKalmanFilter> *ptr, 
    cv::tracking::UnscentedKalmanFilter **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#endif

#endif