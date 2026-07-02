#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>
#include <opencv2/ptcloud/depth.hpp>

CVAPI(ExceptionStatus) ptcloud_registerDepth(
    const interop::InputArrayProxy* unregisteredCameraMatrix,
    const interop::InputArrayProxy* registeredCameraMatrix,
    const interop::InputArrayProxy* registeredDistCoeffs,
    const interop::InputArrayProxy* Rt,
    const interop::InputArrayProxy* unregisteredDepth,
    interop::Size outputImagePlaneSize,
    const interop::OutputArrayProxy* registeredDepth,
    int depthDilation)
{
    return cvTry([&] {
    cv::registerDepth(
        InProxy(*unregisteredCameraMatrix), InProxy(*registeredCameraMatrix), InProxy(*registeredDistCoeffs),
        InProxy(*Rt), InProxy(*unregisteredDepth), cpp(outputImagePlaneSize),
        OutProxy(*registeredDepth), depthDilation != 0);
    });
}

CVAPI(ExceptionStatus) ptcloud_depthTo3dSparse(
    const interop::InputArrayProxy* depth,
    const interop::InputArrayProxy* in_K,
    const interop::InputArrayProxy* in_points,
    const interop::OutputArrayProxy* points3d)
{
    return cvTry([&] {
    cv::depthTo3dSparse(InProxy(*depth), InProxy(*in_K), InProxy(*in_points), OutProxy(*points3d));
    });
}

CVAPI(ExceptionStatus) ptcloud_depthTo3d(
    const interop::InputArrayProxy* depth,
    const interop::InputArrayProxy* K,
    const interop::OutputArrayProxy* points3d,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
    cv::depthTo3d(InProxy(*depth), InProxy(*K), OutProxy(*points3d), InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) ptcloud_rescaleDepth(
    const interop::InputArrayProxy* in,
    int type,
    const interop::OutputArrayProxy* out,
    double depth_factor)
{
    return cvTry([&] {
    cv::rescaleDepth(InProxy(*in), type, OutProxy(*out), depth_factor);
    });
}

CVAPI(ExceptionStatus) ptcloud_warpFrame(
    const interop::InputArrayProxy* depth,
    const interop::InputArrayProxy* image,
    const interop::InputArrayProxy* mask,
    const interop::InputArrayProxy* Rt,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::OutputArrayProxy* warpedDepth,
    const interop::OutputArrayProxy* warpedImage,
    const interop::OutputArrayProxy* warpedMask)
{
    return cvTry([&] {
    cv::warpFrame(
        InProxy(*depth), InProxy(*image), InProxy(*mask), InProxy(*Rt), InProxy(*cameraMatrix),
        OutProxy(*warpedDepth), OutProxy(*warpedImage), OutProxy(*warpedMask));
    });
}

CVAPI(ExceptionStatus) ptcloud_findPlanes(
    const interop::InputArrayProxy* points3d,
    const interop::InputArrayProxy* normals,
    const interop::OutputArrayProxy* mask,
    const interop::OutputArrayProxy* plane_coefficients,
    int block_size,
    int min_size,
    double threshold,
    double sensor_error_a,
    double sensor_error_b,
    double sensor_error_c,
    int method)
{
    return cvTry([&] {
    cv::findPlanes(
        InProxy(*points3d), InProxy(*normals), OutProxy(*mask), OutProxy(*plane_coefficients),
        block_size, min_size, threshold,
        sensor_error_a, sensor_error_b, sensor_error_c,
        static_cast<cv::RgbdPlaneMethod>(method));
    });
}

#endif // NO_PTCLOUD
