#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>
#include <opencv2/ptcloud/depth.hpp>

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_create(
    int rows, int cols, int depth, cv::_InputArray *K, int window_size, float diff_threshold, int method,
    cv::Ptr<cv::RgbdNormals> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::RgbdNormals::create(
        rows, cols, depth, entity(K), window_size, diff_threshold,
        static_cast<cv::RgbdNormals::RgbdNormalsMethod>(method));
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) ptcloud_Ptr_RgbdNormals_delete(cv::Ptr<cv::RgbdNormals> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ptcloud_Ptr_RgbdNormals_get(cv::Ptr<cv::RgbdNormals> *obj, cv::RgbdNormals **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_apply(cv::RgbdNormals *obj, cv::_InputArray *points, cv::_OutputArray *normals)
{
    return cvTry([&] {
    obj->apply(entity(points), entity(normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_cache(cv::RgbdNormals *obj)
{
    return cvTry([&] {
    obj->cache();
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getRows(cv::RgbdNormals *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getRows();
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_setRows(cv::RgbdNormals *obj, int val)
{
    return cvTry([&] {
    obj->setRows(val);
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getCols(cv::RgbdNormals *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getCols();
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_setCols(cv::RgbdNormals *obj, int val)
{
    return cvTry([&] {
    obj->setCols(val);
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getWindowSize(cv::RgbdNormals *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getWindowSize();
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_setWindowSize(cv::RgbdNormals *obj, int val)
{
    return cvTry([&] {
    obj->setWindowSize(val);
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getDepth(cv::RgbdNormals *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getDepth();
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getK(cv::RgbdNormals *obj, cv::_OutputArray *val)
{
    return cvTry([&] {
    obj->getK(entity(val));
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_setK(cv::RgbdNormals *obj, cv::_InputArray *val)
{
    return cvTry([&] {
    obj->setK(entity(val));
    });
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getMethod(cv::RgbdNormals *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = static_cast<int>(obj->getMethod());
    });
}

#endif // NO_PTCLOUD
