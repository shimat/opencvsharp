#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_new(
    cv::_InputArray *depth, cv::_InputArray *image, cv::_InputArray *mask, cv::_InputArray *normals,
    cv::OdometryFrame **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::OdometryFrame(entity(depth), entity(image), entity(mask), entity(normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_delete(cv::OdometryFrame *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getImage(cv::OdometryFrame *obj, cv::_OutputArray *image)
{
    return cvTry([&] {
    obj->getImage(entity(image));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getGrayImage(cv::OdometryFrame *obj, cv::_OutputArray *image)
{
    return cvTry([&] {
    obj->getGrayImage(entity(image));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getDepth(cv::OdometryFrame *obj, cv::_OutputArray *depth)
{
    return cvTry([&] {
    obj->getDepth(entity(depth));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getProcessedDepth(cv::OdometryFrame *obj, cv::_OutputArray *depth)
{
    return cvTry([&] {
    obj->getProcessedDepth(entity(depth));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getMask(cv::OdometryFrame *obj, cv::_OutputArray *mask)
{
    return cvTry([&] {
    obj->getMask(entity(mask));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getNormals(cv::OdometryFrame *obj, cv::_OutputArray *normals)
{
    return cvTry([&] {
    obj->getNormals(entity(normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getPyramidLevels(cv::OdometryFrame *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getPyramidLevels();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getPyramidAt(cv::OdometryFrame *obj, cv::_OutputArray *img, int pyrType, size_t level)
{
    return cvTry([&] {
    obj->getPyramidAt(entity(img), static_cast<cv::OdometryFramePyramidType>(pyrType), level);
    });
}

#endif // NO_PTCLOUD
