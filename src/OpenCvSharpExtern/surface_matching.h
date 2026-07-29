#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_SURFACE_MATCHING)

#include "include_opencv.h"
#include <opencv2/surface_matching.hpp>
#include <opencv2/surface_matching/ppf_helpers.hpp>

CVAPI(ExceptionStatus) surface_matching_ICP_new1(cv::ppf_match_3d::ICP** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::ppf_match_3d::ICP();
    });
}

CVAPI(ExceptionStatus) surface_matching_ICP_new2(
    int iterations,
    float tolerance,
    float rejectionScale,
    int numLevels,
    cv::ppf_match_3d::ICP** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::ppf_match_3d::ICP(
            iterations,
            tolerance,
            rejectionScale,
            numLevels);
    });
}

CVAPI(ExceptionStatus) surface_matching_ICP_delete(cv::ppf_match_3d::ICP* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) surface_matching_ICP_registerModelToScene(
    cv::ppf_match_3d::ICP* obj,
    const interop::InputArrayProxy* sourcePointCloud,
    const interop::InputArrayProxy* destinationPointCloud,
    double* residual,
    cv::Mat** pose,
    int* returnValue)
{
    return cvTry([&] {
        cv::Matx44d poseValue;
        *returnValue = obj->registerModelToScene(
            static_cast<const cv::_InputArray&>(InProxy(*sourcePointCloud)).getMat(),
            static_cast<const cv::_InputArray&>(InProxy(*destinationPointCloud)).getMat(),
            *residual,
            poseValue);
        *pose = new cv::Mat(poseValue);
    });
}

CVAPI(ExceptionStatus) surface_matching_computeNormalsPC3d(
    const interop::InputArrayProxy* pointCloud,
    const interop::OutputArrayProxy* pointCloudWithNormals,
    int numberOfNeighbors,
    int flipViewpoint,
    interop::Vec3f viewpoint,
    int* returnValue)
{
    return cvTry([&] {
        cv::Mat result;
        const cv::Vec3f viewpointValue(viewpoint.val);
        *returnValue = cv::ppf_match_3d::computeNormalsPC3d(
            static_cast<const cv::_InputArray&>(InProxy(*pointCloud)).getMat(),
            result,
            numberOfNeighbors,
            flipViewpoint != 0,
            viewpointValue);
        result.copyTo(OutProxy(*pointCloudWithNormals));
    });
}

#endif
