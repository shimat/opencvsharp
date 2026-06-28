#pragma once

#ifndef NO_CONTRIB

#include "include_opencv.h"

CVAPI(ExceptionStatus) ximgproc_RidgeDetectionFilter_create(
    int ddepth, int dx, int dy, int ksize, int out_dtype, double scale, double delta, int borderType,
    cv::Ptr<cv::ximgproc::RidgeDetectionFilter> **returnValue)
{
    return cvTry([&] {
    auto obj = cv::ximgproc::RidgeDetectionFilter::create(
        ddepth, dx, dy, ksize, out_dtype, scale, delta, borderType);
    *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) ximgproc_RidgeDetectionFilter_getRidgeFilteredImage(
    cv::ximgproc::RidgeDetectionFilter *obj,
    cv::_InputArray *_img, cv::_OutputArray *out)
{
    return cvTry([&] {
    obj->getRidgeFilteredImage(*_img, *out);
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_RidgeDetectionFilter_delete(cv::Ptr<cv::ximgproc::RidgeDetectionFilter> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_RidgeDetectionFilter_get(cv::Ptr<cv::ximgproc::RidgeDetectionFilter> *ptr, cv::ximgproc::RidgeDetectionFilter **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

#endif // NO_CONTRIB
