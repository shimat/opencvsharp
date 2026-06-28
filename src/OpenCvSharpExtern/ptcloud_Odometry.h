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

CVAPI(ExceptionStatus) ptcloud_Odometry_new3(int otype, cv::OdometrySettings *settings, int algtype, cv::Odometry **returnValue)
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

CVAPI(ExceptionStatus) ptcloud_Odometry_prepareFrames(cv::Odometry *obj, cv::OdometryFrame *srcFrame, cv::OdometryFrame *dstFrame)
{
    return cvTry([&] {
    obj->prepareFrames(*srcFrame, *dstFrame);
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_compute_Frame(
    cv::Odometry *obj, cv::OdometryFrame *srcFrame, cv::OdometryFrame *dstFrame, cv::_OutputArray *Rt, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->compute(*srcFrame, *dstFrame, entity(Rt)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_compute_Depth(
    cv::Odometry *obj, cv::_InputArray *srcDepth, cv::_InputArray *dstDepth, cv::_OutputArray *Rt, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->compute(entity(srcDepth), entity(dstDepth), entity(Rt)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_compute_DepthRGB(
    cv::Odometry *obj, cv::_InputArray *srcDepth, cv::_InputArray *srcRGB, cv::_InputArray *dstDepth, cv::_InputArray *dstRGB,
    cv::_OutputArray *Rt, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->compute(entity(srcDepth), entity(srcRGB), entity(dstDepth), entity(dstRGB), entity(Rt)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ptcloud_Odometry_getNormalsComputer(cv::Odometry *obj, cv::Ptr<cv::RgbdNormals> **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Ptr<cv::RgbdNormals>(obj->getNormalsComputer());
    });
}

#endif // NO_PTCLOUD
