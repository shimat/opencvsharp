#pragma once

#include "include_opencv.h"

CVAPI(ExceptionStatus) ximgproc_RidgeDetectionFilter_create(
    int ddepth, int dx, int dy, int ksize, int out_dtype, double scale, double delta, int borderType,
    cv::Ptr<cv::ximgproc::RidgeDetectionFilter> **returnValue)
{
    BEGIN_WRAP
    auto obj = cv::ximgproc::RidgeDetectionFilter::create(
        ddepth, dx, dy, ksize, out_dtype, scale, delta, borderType);
    *returnValue = clone(obj);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_RidgeDetectionFilter_getRidgeFilteredImage(
    cv::ximgproc::RidgeDetectionFilter *obj,
    cv::_InputArray *_img, cv::_OutputArray *out)
{
    BEGIN_WRAP
    obj->getRidgeFilteredImage(*_img, *out);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_RidgeDetectionFilter_delete(cv::Ptr<cv::ximgproc::RidgeDetectionFilter> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_RidgeDetectionFilter_get(cv::Ptr<cv::ximgproc::RidgeDetectionFilter> *ptr, cv::ximgproc::RidgeDetectionFilter **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}
