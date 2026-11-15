#pragma once
#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud/viz3d.hpp>

CVAPI(ExceptionStatus) ptcloud_viz3d_setPerspective(
    const char* windowName, float fieldOfView, float nearClip, float farClip)
{
    return cvTry([&] {
        cv::viz3d::setPerspective(windowName, fieldOfView, nearClip, farClip);
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_setGridVisible(
    const char* windowName, int visible)
{
    return cvTry([&] {
        cv::viz3d::setGridVisible(windowName, visible != 0);
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_setSun(
    const char* windowName, interop::Vec3f direction, interop::Vec3f ambient, interop::Vec3f diffuse)
{
    return cvTry([&] {
        cv::viz3d::setSun(windowName, cv::Vec3f(direction.val), cv::Vec3f(ambient.val), cv::Vec3f(diffuse.val));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_setSky(
    const char* windowName, interop::Vec3f color)
{
    return cvTry([&] {
        cv::viz3d::setSky(windowName, cv::Vec3f(color.val));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_showBox(
    const char* windowName, const char* objectName, interop::Vec3f size, interop::Vec3f color, int mode)
{
    return cvTry([&] {
        CV_Assert(mode >= cv::viz3d::RENDER_SIMPLE && mode <= cv::viz3d::RENDER_WIREFRAME);
        cv::viz3d::showBox(windowName, objectName, cv::Vec3f(size.val), cv::Vec3f(color.val),
                          static_cast<cv::viz3d::RenderMode>(mode));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_showPlane(
    const char* windowName, const char* objectName, interop::Vec2f size, interop::Vec3f color, int mode)
{
    return cvTry([&] {
        CV_Assert(mode >= cv::viz3d::RENDER_SIMPLE && mode <= cv::viz3d::RENDER_WIREFRAME);
        cv::viz3d::showPlane(windowName, objectName, cv::Vec2f(size.val), cv::Vec3f(color.val),
                            static_cast<cv::viz3d::RenderMode>(mode));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_showSphere(
    const char* windowName, const char* objectName, float radius, interop::Vec3f color, int mode, int subdivisions)
{
    return cvTry([&] {
        CV_Assert(mode >= cv::viz3d::RENDER_SIMPLE && mode <= cv::viz3d::RENDER_WIREFRAME);
        cv::viz3d::showSphere(windowName, objectName, radius, cv::Vec3f(color.val),
                             static_cast<cv::viz3d::RenderMode>(mode), subdivisions);
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_showCameraTrajectory(
    const char* windowName, const char* objectName,
    const interop::InputArrayProxy* trajectory, float aspect, float scale, interop::Vec3f frustumColor, interop::Vec3f lineColor)
{
    return cvTry([&] {
        cv::viz3d::showCameraTrajectory(windowName, objectName, InProxy(*trajectory), aspect, scale,
                                       cv::Vec3f(frustumColor.val), cv::Vec3f(lineColor.val));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_showMesh(
    const char* windowName, const char* objectName,
    const interop::InputArrayProxy* vertices, const interop::InputArrayProxy* indices)
{
    return cvTry([&] {
        const InProxy indicesProxy(*indices);
        const cv::_InputArray& indexArray = indicesProxy;
        if (indexArray.kind() == cv::_InputArray::NONE)
            cv::viz3d::showMesh(windowName, objectName, InProxy(*vertices));
        else
            cv::viz3d::showMesh(windowName, objectName, InProxy(*vertices), indexArray);
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_showPoints(
    const char* windowName, const char* objectName, const interop::InputArrayProxy* points)
{
    return cvTry([&] {
        cv::viz3d::showPoints(windowName, objectName, InProxy(*points));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_showLines(
    const char* windowName, const char* objectName, const interop::InputArrayProxy* points)
{
    return cvTry([&] {
        cv::viz3d::showLines(windowName, objectName, InProxy(*points));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_showGaussianSplats(
    const char* windowName, const char* objectName, const interop::InputArrayProxy* splats)
{
    return cvTry([&] {
        cv::viz3d::showGaussianSplats(windowName, objectName, InProxy(*splats));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_showRGBD(
    const char* windowName, const char* objectName,
    const interop::InputArrayProxy* image, const interop::InputArrayProxy* intrinsics, float scale)
{
    return cvTry([&] {
        const auto camera = static_cast<const cv::_InputArray&>(InProxy(*intrinsics)).getMat();
        CV_Assert(camera.dims == 2 && camera.rows == 3 && camera.cols == 3 && camera.channels() == 1);
        cv::Mat cameraFloat;
        camera.convertTo(cameraFloat, CV_32F);
        const cv::Matx33f cameraMatrix = cameraFloat;
        cv::viz3d::showRGBD(windowName, objectName, InProxy(*image), cameraMatrix, scale);
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_setObjectPosition(
    const char* windowName, const char* objectName, interop::Vec3f position)
{
    return cvTry([&] {
        cv::viz3d::setObjectPosition(windowName, objectName, cv::Vec3f(position.val));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_setObjectRotation(
    const char* windowName, const char* objectName, interop::Vec3f rotation)
{
    return cvTry([&] {
        cv::viz3d::setObjectRotation(windowName, objectName, cv::Vec3f(rotation.val));
    });
}

CVAPI(ExceptionStatus) ptcloud_viz3d_destroyObject(
    const char* windowName, const char* objectName)
{
    return cvTry([&] {
        cv::viz3d::destroyObject(windowName, objectName);
    });
}

#endif
