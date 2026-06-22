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
    BEGIN_WRAP
    *returnValue = new cv::OdometryFrame(entity(depth), entity(image), entity(mask), entity(normals));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_delete(cv::OdometryFrame *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getImage(cv::OdometryFrame *obj, cv::_OutputArray *image)
{
    BEGIN_WRAP
    obj->getImage(entity(image));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getGrayImage(cv::OdometryFrame *obj, cv::_OutputArray *image)
{
    BEGIN_WRAP
    obj->getGrayImage(entity(image));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getDepth(cv::OdometryFrame *obj, cv::_OutputArray *depth)
{
    BEGIN_WRAP
    obj->getDepth(entity(depth));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getProcessedDepth(cv::OdometryFrame *obj, cv::_OutputArray *depth)
{
    BEGIN_WRAP
    obj->getProcessedDepth(entity(depth));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getMask(cv::OdometryFrame *obj, cv::_OutputArray *mask)
{
    BEGIN_WRAP
    obj->getMask(entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getNormals(cv::OdometryFrame *obj, cv::_OutputArray *normals)
{
    BEGIN_WRAP
    obj->getNormals(entity(normals));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getPyramidLevels(cv::OdometryFrame *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getPyramidLevels();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometryFrame_getPyramidAt(cv::OdometryFrame *obj, cv::_OutputArray *img, int pyrType, size_t level)
{
    BEGIN_WRAP
    obj->getPyramidAt(entity(img), static_cast<cv::OdometryFramePyramidType>(pyrType), level);
    END_WRAP
}

#endif // NO_PTCLOUD
