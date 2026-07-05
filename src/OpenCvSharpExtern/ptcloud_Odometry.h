#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>
#include <opencv2/ptcloud/depth.hpp>

CVAPI(ExceptionStatus) ptcloud_Odometry_new1(cv::Odometry **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Odometry();
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_new2(int otype, cv::Odometry **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Odometry(static_cast<cv::OdometryType>(otype));
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_new3(
    int otype,
    cv::OdometrySettings *settings,
    int algtype,
    cv::Odometry **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Odometry(static_cast<cv::OdometryType>(otype), *settings, static_cast<cv::OdometryAlgoType>(algtype));
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_delete(cv::Odometry *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_prepareFrame(cv::Odometry *obj, cv::OdometryFrame *frame)
{
    return cvTry([&] {
        obj->prepareFrame(*frame);
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_prepareFrames(
    cv::Odometry *obj,
    cv::OdometryFrame *srcFrame,
    cv::OdometryFrame *dstFrame)
{
    return cvTry([&] {
        obj->prepareFrames(*srcFrame, *dstFrame);
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_compute_Frame(
    cv::Odometry *obj,
    cv::OdometryFrame *srcFrame,
    cv::OdometryFrame *dstFrame,
    const interop::OutputArrayProxy* Rt,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->compute(*srcFrame, *dstFrame, OutProxy(*Rt)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_compute_Depth(
    cv::Odometry *obj,
    const interop::InputArrayProxy* srcDepth,
    const interop::InputArrayProxy* dstDepth,
    const interop::OutputArrayProxy* Rt,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->compute(InProxy(*srcDepth), InProxy(*dstDepth), OutProxy(*Rt)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_compute_DepthRGB(
    cv::Odometry *obj,
    const interop::InputArrayProxy* srcDepth,
    const interop::InputArrayProxy* srcRGB,
    const interop::InputArrayProxy* dstDepth,
    const interop::InputArrayProxy* dstRGB,
    const interop::OutputArrayProxy* Rt,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->compute(InProxy(*srcDepth), InProxy(*srcRGB), InProxy(*dstDepth), InProxy(*dstRGB), OutProxy(*Rt)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_getNormalsComputer(cv::Odometry *obj, cv::Ptr<cv::RgbdNormals> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::RgbdNormals>(obj->getNormalsComputer());
    });
}

#endif // NO_PTCLOUD
