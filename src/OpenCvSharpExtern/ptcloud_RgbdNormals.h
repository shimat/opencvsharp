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
    BEGIN_WRAP
    const auto ptr = cv::RgbdNormals::create(
        rows, cols, depth, entity(K), window_size, diff_threshold,
        static_cast<cv::RgbdNormals::RgbdNormalsMethod>(method));
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Ptr_RgbdNormals_delete(cv::Ptr<cv::RgbdNormals> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Ptr_RgbdNormals_get(cv::Ptr<cv::RgbdNormals> *obj, cv::RgbdNormals **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_apply(cv::RgbdNormals *obj, cv::_InputArray *points, cv::_OutputArray *normals)
{
    BEGIN_WRAP
    obj->apply(entity(points), entity(normals));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_cache(cv::RgbdNormals *obj)
{
    BEGIN_WRAP
    obj->cache();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getRows(cv::RgbdNormals *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRows();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_setRows(cv::RgbdNormals *obj, int val)
{
    BEGIN_WRAP
    obj->setRows(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getCols(cv::RgbdNormals *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getCols();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_setCols(cv::RgbdNormals *obj, int val)
{
    BEGIN_WRAP
    obj->setCols(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getWindowSize(cv::RgbdNormals *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getWindowSize();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_setWindowSize(cv::RgbdNormals *obj, int val)
{
    BEGIN_WRAP
    obj->setWindowSize(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getDepth(cv::RgbdNormals *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDepth();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getK(cv::RgbdNormals *obj, cv::_OutputArray *val)
{
    BEGIN_WRAP
    obj->getK(entity(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_setK(cv::RgbdNormals *obj, cv::_InputArray *val)
{
    BEGIN_WRAP
    obj->setK(entity(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_RgbdNormals_getMethod(cv::RgbdNormals *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->getMethod());
    END_WRAP
}

#endif // NO_PTCLOUD
