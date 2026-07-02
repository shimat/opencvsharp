#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_Volume_new(
    int vtype,
    cv::VolumeSettings *settings,
    cv::Volume **returnValue)
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

CVAPI(ExceptionStatus) ptcloud_Volume_integrateFrame(
    cv::Volume *obj,
    cv::OdometryFrame *frame,
    const interop::InputArrayProxy* pose)
{
    return cvTry([&] {
    obj->integrate(*frame, InProxy(*pose));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_integrate(
    cv::Volume *obj,
    const interop::InputArrayProxy* depth,
    const interop::InputArrayProxy* pose)
{
    return cvTry([&] {
    obj->integrate(InProxy(*depth), InProxy(*pose));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_integrateColor(
    cv::Volume *obj,
    const interop::InputArrayProxy* depth,
    const interop::InputArrayProxy* image,
    const interop::InputArrayProxy* pose)
{
    return cvTry([&] {
    obj->integrate(InProxy(*depth), InProxy(*image), InProxy(*pose));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycast(
    cv::Volume *obj,
    const interop::InputArrayProxy* cameraPose,
    const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* normals)
{
    return cvTry([&] {
    obj->raycast(InProxy(*cameraPose), OutProxy(*points), OutProxy(*normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycastColor(
    cv::Volume *obj,
    const interop::InputArrayProxy* cameraPose,
    const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* normals,
    const interop::OutputArrayProxy* colors)
{
    return cvTry([&] {
    obj->raycast(InProxy(*cameraPose), OutProxy(*points), OutProxy(*normals), OutProxy(*colors));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycastEx(
    cv::Volume *obj,
    const interop::InputArrayProxy* cameraPose,
    int height,
    int width,
    const interop::InputArrayProxy* K,
    const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* normals)
{
    return cvTry([&] {
    obj->raycast(InProxy(*cameraPose), height, width, InProxy(*K), OutProxy(*points), OutProxy(*normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_raycastExColor(
    cv::Volume *obj,
    const interop::InputArrayProxy* cameraPose,
    int height,
    int width,
    const interop::InputArrayProxy* K,
    const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* normals,
    const interop::OutputArrayProxy* colors)
{
    return cvTry([&] {
    obj->raycast(InProxy(*cameraPose), height, width, InProxy(*K), OutProxy(*points), OutProxy(*normals), OutProxy(*colors));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_fetchNormals(
    cv::Volume *obj,
    const interop::InputArrayProxy* points,
    const interop::OutputArrayProxy* normals)
{
    return cvTry([&] {
    obj->fetchNormals(InProxy(*points), OutProxy(*normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_fetchPointsNormals(
    cv::Volume *obj,
    const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* normals)
{
    return cvTry([&] {
    obj->fetchPointsNormals(OutProxy(*points), OutProxy(*normals));
    });
}

CVAPI(ExceptionStatus) ptcloud_Volume_fetchPointsNormalsColors(
    cv::Volume *obj,
    const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* normals,
    const interop::OutputArrayProxy* colors)
{
    return cvTry([&] {
    obj->fetchPointsNormalsColors(OutProxy(*points), OutProxy(*normals), OutProxy(*colors));
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

CVAPI(ExceptionStatus) ptcloud_Volume_getBoundingBox(
    cv::Volume *obj,
    const interop::OutputArrayProxy* bb,
    int precision)
{
    return cvTry([&] {
    obj->getBoundingBox(OutProxy(*bb), precision);
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
