#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_Odometry_new1(cv::Odometry **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Odometry();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Odometry_new2(int otype, cv::Odometry **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Odometry(static_cast<cv::OdometryType>(otype));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Odometry_new3(int otype, cv::OdometrySettings *settings, int algtype, cv::Odometry **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Odometry(static_cast<cv::OdometryType>(otype), *settings, static_cast<cv::OdometryAlgoType>(algtype));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Odometry_delete(cv::Odometry *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Odometry_prepareFrame(cv::Odometry *obj, cv::OdometryFrame *frame)
{
    BEGIN_WRAP
    obj->prepareFrame(*frame);
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Odometry_prepareFrames(cv::Odometry *obj, cv::OdometryFrame *srcFrame, cv::OdometryFrame *dstFrame)
{
    BEGIN_WRAP
    obj->prepareFrames(*srcFrame, *dstFrame);
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Odometry_compute_Frame(
    cv::Odometry *obj, cv::OdometryFrame *srcFrame, cv::OdometryFrame *dstFrame, cv::_OutputArray *Rt, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->compute(*srcFrame, *dstFrame, entity(Rt)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Odometry_compute_Depth(
    cv::Odometry *obj, cv::_InputArray *srcDepth, cv::_InputArray *dstDepth, cv::_OutputArray *Rt, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->compute(entity(srcDepth), entity(dstDepth), entity(Rt)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Odometry_compute_DepthRGB(
    cv::Odometry *obj, cv::_InputArray *srcDepth, cv::_InputArray *srcRGB, cv::_InputArray *dstDepth, cv::_InputArray *dstRGB,
    cv::_OutputArray *Rt, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->compute(entity(srcDepth), entity(srcRGB), entity(dstDepth), entity(dstRGB), entity(Rt)) ? 1 : 0;
    END_WRAP
}

#endif // NO_PTCLOUD
