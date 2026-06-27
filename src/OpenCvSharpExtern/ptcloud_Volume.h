#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_Volume_new(int vtype, cv::VolumeSettings *settings, cv::Volume **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Volume(static_cast<cv::VolumeType>(vtype), *settings);
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_delete(cv::Volume *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_integrateFrame(cv::Volume *obj, cv::OdometryFrame *frame, cv::_InputArray *pose)
{
    BEGIN_WRAP
    obj->integrate(*frame, entity(pose));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_integrate(cv::Volume *obj, cv::_InputArray *depth, cv::_InputArray *pose)
{
    BEGIN_WRAP
    obj->integrate(entity(depth), entity(pose));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_integrateColor(cv::Volume *obj, cv::_InputArray *depth, cv::_InputArray *image, cv::_InputArray *pose)
{
    BEGIN_WRAP
    obj->integrate(entity(depth), entity(image), entity(pose));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycast(cv::Volume *obj, cv::_InputArray *cameraPose, cv::_OutputArray *points, cv::_OutputArray *normals)
{
    BEGIN_WRAP
    obj->raycast(entity(cameraPose), entity(points), entity(normals));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycastColor(cv::Volume *obj, cv::_InputArray *cameraPose, cv::_OutputArray *points, cv::_OutputArray *normals, cv::_OutputArray *colors)
{
    BEGIN_WRAP
    obj->raycast(entity(cameraPose), entity(points), entity(normals), entity(colors));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycastEx(cv::Volume *obj, cv::_InputArray *cameraPose, int height, int width, cv::_InputArray *K, cv::_OutputArray *points, cv::_OutputArray *normals)
{
    BEGIN_WRAP
    obj->raycast(entity(cameraPose), height, width, entity(K), entity(points), entity(normals));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycastExColor(cv::Volume *obj, cv::_InputArray *cameraPose, int height, int width, cv::_InputArray *K, cv::_OutputArray *points, cv::_OutputArray *normals, cv::_OutputArray *colors)
{
    BEGIN_WRAP
    obj->raycast(entity(cameraPose), height, width, entity(K), entity(points), entity(normals), entity(colors));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_fetchNormals(cv::Volume *obj, cv::_InputArray *points, cv::_OutputArray *normals)
{
    BEGIN_WRAP
    obj->fetchNormals(entity(points), entity(normals));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_fetchPointsNormals(cv::Volume *obj, cv::_OutputArray *points, cv::_OutputArray *normals)
{
    BEGIN_WRAP
    obj->fetchPointsNormals(entity(points), entity(normals));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_fetchPointsNormalsColors(cv::Volume *obj, cv::_OutputArray *points, cv::_OutputArray *normals, cv::_OutputArray *colors)
{
    BEGIN_WRAP
    obj->fetchPointsNormalsColors(entity(points), entity(normals), entity(colors));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_reset(cv::Volume *obj)
{
    BEGIN_WRAP
    obj->reset();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_getVisibleBlocks(cv::Volume *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getVisibleBlocks();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_getTotalVolumeUnits(cv::Volume *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getTotalVolumeUnits();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_getBoundingBox(cv::Volume *obj, cv::_OutputArray *bb, int precision)
{
    BEGIN_WRAP
    obj->getBoundingBox(entity(bb), precision);
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_setEnableGrowth(cv::Volume *obj, int v)
{
    BEGIN_WRAP
    obj->setEnableGrowth(v != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_Volume_getEnableGrowth(cv::Volume *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getEnableGrowth() ? 1 : 0;
    END_WRAP
}

#endif // NO_PTCLOUD
