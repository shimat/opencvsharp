#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_new(
    const interop::InputArrayProxy* depth,
    const interop::InputArrayProxy* image,
    const interop::InputArrayProxy* mask,
    const interop::InputArrayProxy* normals,
    cv::OdometryFrame **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::OdometryFrame(InProxy(*depth), InProxy(*image), InProxy(*mask), InProxy(*normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_delete(cv::OdometryFrame *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getImage(cv::OdometryFrame *obj, const interop::OutputArrayProxy* image)
{
    return cvTry([&] {
        obj->getImage(OutProxy(*image));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getGrayImage(cv::OdometryFrame *obj, const interop::OutputArrayProxy* image)
{
    return cvTry([&] {
        obj->getGrayImage(OutProxy(*image));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getDepth(cv::OdometryFrame *obj, const interop::OutputArrayProxy* depth)
{
    return cvTry([&] {
        obj->getDepth(OutProxy(*depth));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getProcessedDepth(cv::OdometryFrame *obj, const interop::OutputArrayProxy* depth)
{
    return cvTry([&] {
        obj->getProcessedDepth(OutProxy(*depth));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getMask(cv::OdometryFrame *obj, const interop::OutputArrayProxy* mask)
{
    return cvTry([&] {
        obj->getMask(OutProxy(*mask));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getNormals(cv::OdometryFrame *obj, const interop::OutputArrayProxy* normals)
{
    return cvTry([&] {
        obj->getNormals(OutProxy(*normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getPyramidLevels(cv::OdometryFrame *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getPyramidLevels();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getPyramidAt(
    cv::OdometryFrame *obj,
    const interop::OutputArrayProxy* img,
    int pyrType,
    size_t level)
{
    return cvTry([&] {
        obj->getPyramidAt(OutProxy(*img), static_cast<cv::OdometryFramePyramidType>(pyrType), level);
    });
}

#endif // NO_PTCLOUD
