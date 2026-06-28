#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_Volume_new(int vtype, cv::VolumeSettings *settings, cv::Volume **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Volume(static_cast<cv::VolumeType>(vtype), *settings);
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_delete(cv::Volume *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_integrateFrame(cv::Volume *obj, cv::OdometryFrame *frame, cv::_InputArray *pose)
{
    return cvTry([&] {
    obj->integrate(*frame, entity(pose));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_integrate(cv::Volume *obj, cv::_InputArray *depth, cv::_InputArray *pose)
{
    return cvTry([&] {
    obj->integrate(entity(depth), entity(pose));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_integrateColor(cv::Volume *obj, cv::_InputArray *depth, cv::_InputArray *image, cv::_InputArray *pose)
{
    return cvTry([&] {
    obj->integrate(entity(depth), entity(image), entity(pose));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycast(cv::Volume *obj, cv::_InputArray *cameraPose, cv::_OutputArray *points, cv::_OutputArray *normals)
{
    return cvTry([&] {
    obj->raycast(entity(cameraPose), entity(points), entity(normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycastColor(cv::Volume *obj, cv::_InputArray *cameraPose, cv::_OutputArray *points, cv::_OutputArray *normals, cv::_OutputArray *colors)
{
    return cvTry([&] {
    obj->raycast(entity(cameraPose), entity(points), entity(normals), entity(colors));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycastEx(cv::Volume *obj, cv::_InputArray *cameraPose, int height, int width, cv::_InputArray *K, cv::_OutputArray *points, cv::_OutputArray *normals)
{
    return cvTry([&] {
    obj->raycast(entity(cameraPose), height, width, entity(K), entity(points), entity(normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycastExColor(cv::Volume *obj, cv::_InputArray *cameraPose, int height, int width, cv::_InputArray *K, cv::_OutputArray *points, cv::_OutputArray *normals, cv::_OutputArray *colors)
{
    return cvTry([&] {
    obj->raycast(entity(cameraPose), height, width, entity(K), entity(points), entity(normals), entity(colors));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_fetchNormals(cv::Volume *obj, cv::_InputArray *points, cv::_OutputArray *normals)
{
    return cvTry([&] {
    obj->fetchNormals(entity(points), entity(normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_fetchPointsNormals(cv::Volume *obj, cv::_OutputArray *points, cv::_OutputArray *normals)
{
    return cvTry([&] {
    obj->fetchPointsNormals(entity(points), entity(normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_fetchPointsNormalsColors(cv::Volume *obj, cv::_OutputArray *points, cv::_OutputArray *normals, cv::_OutputArray *colors)
{
    return cvTry([&] {
    obj->fetchPointsNormalsColors(entity(points), entity(normals), entity(colors));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_reset(cv::Volume *obj)
{
    return cvTry([&] {
    obj->reset();
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_getVisibleBlocks(cv::Volume *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getVisibleBlocks();
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_getTotalVolumeUnits(cv::Volume *obj, size_t *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getTotalVolumeUnits();
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_getBoundingBox(cv::Volume *obj, cv::_OutputArray *bb, int precision)
{
    return cvTry([&] {
    obj->getBoundingBox(entity(bb), precision);
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_setEnableGrowth(cv::Volume *obj, int v)
{
    return cvTry([&] {
    obj->setEnableGrowth(v != 0);
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_getEnableGrowth(cv::Volume *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getEnableGrowth() ? 1 : 0;
    });
}

#endif // NO_PTCLOUD
