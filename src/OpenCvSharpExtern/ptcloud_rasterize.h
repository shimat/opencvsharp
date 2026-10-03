#pragma once
#ifndef NO_PTCLOUD
#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

static cv::TriangleRasterizeSettings ptcloud_rasterSettings(int shading, int culling, int glCompatible)
{
    cv::TriangleRasterizeSettings settings;
    settings.shadingType = static_cast<cv::TriangleShadingType>(shading);
    settings.cullingMode = static_cast<cv::TriangleCullingMode>(culling);
    settings.glCompatibleMode = static_cast<cv::TriangleGlCompatibleMode>(glCompatible);
    return settings;
}

CVAPI(ExceptionStatus) ptcloud_triangleRasterize(
    const interop::InputArrayProxy* vertices, const interop::InputArrayProxy* indices,
    const interop::InputArrayProxy* colors, const interop::InputOutputArrayProxy* colorBuf,
    const interop::InputOutputArrayProxy* depthBuf, const interop::InputArrayProxy* world2cam,
    double fovY, double zNear, double zFar, int shading, int culling, int glCompatible)
{
    return cvTry([&] { cv::triangleRasterize(InProxy(*vertices), InProxy(*indices), InProxy(*colors),
        IoProxy(*colorBuf), IoProxy(*depthBuf), InProxy(*world2cam), fovY, zNear, zFar,
        ptcloud_rasterSettings(shading, culling, glCompatible)); });
}

CVAPI(ExceptionStatus) ptcloud_triangleRasterizeDepth(
    const interop::InputArrayProxy* vertices, const interop::InputArrayProxy* indices,
    const interop::InputOutputArrayProxy* depthBuf, const interop::InputArrayProxy* world2cam,
    double fovY, double zNear, double zFar, int shading, int culling, int glCompatible)
{
    return cvTry([&] { cv::triangleRasterizeDepth(InProxy(*vertices), InProxy(*indices),
        IoProxy(*depthBuf), InProxy(*world2cam), fovY, zNear, zFar,
        ptcloud_rasterSettings(shading, culling, glCompatible)); });
}

CVAPI(ExceptionStatus) ptcloud_triangleRasterizeColor(
    const interop::InputArrayProxy* vertices, const interop::InputArrayProxy* indices,
    const interop::InputArrayProxy* colors, const interop::InputOutputArrayProxy* colorBuf,
    const interop::InputArrayProxy* world2cam, double fovY, double zNear, double zFar,
    int shading, int culling, int glCompatible)
{
    return cvTry([&] { cv::triangleRasterizeColor(InProxy(*vertices), InProxy(*indices),
        InProxy(*colors), IoProxy(*colorBuf), InProxy(*world2cam), fovY, zNear, zFar,
        ptcloud_rasterSettings(shading, culling, glCompatible)); });
}
#endif
