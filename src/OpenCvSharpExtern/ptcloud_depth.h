#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>
#include <opencv2/ptcloud/depth.hpp>

CVAPI(ExceptionStatus) ptcloud_registerDepth(
    cv::_InputArray *unregisteredCameraMatrix, cv::_InputArray *registeredCameraMatrix, cv::_InputArray *registeredDistCoeffs,
    cv::_InputArray *Rt, cv::_InputArray *unregisteredDepth, interop::Size outputImagePlaneSize,
    cv::_OutputArray *registeredDepth, int depthDilation)
{
    return cvTry([&] {
    cv::registerDepth(
        entity(unregisteredCameraMatrix), entity(registeredCameraMatrix), entity(registeredDistCoeffs),
        entity(Rt), entity(unregisteredDepth), cpp(outputImagePlaneSize),
        entity(registeredDepth), depthDilation != 0);
    });
}

CVAPI(ExceptionStatus) ptcloud_depthTo3dSparse(
    cv::_InputArray *depth, cv::_InputArray *in_K, cv::_InputArray *in_points, cv::_OutputArray *points3d)
{
    return cvTry([&] {
    cv::depthTo3dSparse(entity(depth), entity(in_K), entity(in_points), entity(points3d));
    });
}

CVAPI(ExceptionStatus) ptcloud_depthTo3d(
    cv::_InputArray *depth, cv::_InputArray *K, cv::_OutputArray *points3d, cv::_InputArray *mask)
{
    return cvTry([&] {
    cv::depthTo3d(entity(depth), entity(K), entity(points3d), entity(mask));
    });
}

CVAPI(ExceptionStatus) ptcloud_rescaleDepth(
    cv::_InputArray *in, int type, cv::_OutputArray *out, double depth_factor)
{
    return cvTry([&] {
    cv::rescaleDepth(entity(in), type, entity(out), depth_factor);
    });
}

CVAPI(ExceptionStatus) ptcloud_warpFrame(
    cv::_InputArray *depth, cv::_InputArray *image, cv::_InputArray *mask, cv::_InputArray *Rt, cv::_InputArray *cameraMatrix,
    cv::_OutputArray *warpedDepth, cv::_OutputArray *warpedImage, cv::_OutputArray *warpedMask)
{
    return cvTry([&] {
    cv::warpFrame(
        entity(depth), entity(image), entity(mask), entity(Rt), entity(cameraMatrix),
        entity(warpedDepth), entity(warpedImage), entity(warpedMask));
    });
}

CVAPI(ExceptionStatus) ptcloud_findPlanes(
    cv::_InputArray *points3d, cv::_InputArray *normals, cv::_OutputArray *mask, cv::_OutputArray *plane_coefficients,
    int block_size, int min_size, double threshold,
    double sensor_error_a, double sensor_error_b, double sensor_error_c, int method)
{
    return cvTry([&] {
    cv::findPlanes(
        entity(points3d), entity(normals), entity(mask), entity(plane_coefficients),
        block_size, min_size, threshold,
        sensor_error_a, sensor_error_b, sensor_error_c,
        static_cast<cv::RgbdPlaneMethod>(method));
    });
}

#endif // NO_PTCLOUD
