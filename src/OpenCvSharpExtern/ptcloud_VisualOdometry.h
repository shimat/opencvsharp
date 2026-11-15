#pragma once
#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud/slam/visual_odometry.hpp>

namespace
{
using Odometry = cv::slam::VisualOdometry;

struct VisualOdometryParams
{
    int minInitInliers;
    double minInitParallaxDeg;
    int minInitPoints;
    double hfRatioThresh;
    double minGrowthParallaxDeg;
    double essentialRansacThresh;
    double essentialRansacConfidence;
    double pnpReprojThresh;
    int pnpMinInliers;
    int pnpRansacIters;
    double pnpConfidence;
    double motionModelRadius;
    double motionModelRadiusWide;
    int motionModelMinMatches;
    double descProjThresh;
    int opticalFlowMinInliers;
    int kfMinFrames;
    int kfMaxFrames;
    double kfInlierRatio;
    int kfMinInliers;
    double kfRotThreshDeg;
    double kfTransThresh;
    int localMapTopK;
    int localMapNeighborK;
    double localMapRadius;
};

VisualOdometryParams fromNative(const cv::slam::OdometryParams& parameters)
{
    return {
        parameters.minInitInliers,
        parameters.minInitParallaxDeg,
        parameters.minInitPoints,
        parameters.hfRatioThresh,
        parameters.minGrowthParallaxDeg,
        parameters.essentialRansacThresh,
        parameters.essentialRansacConfidence,
        parameters.pnpReprojThresh,
        parameters.pnpMinInliers,
        parameters.pnpRansacIters,
        parameters.pnpConfidence,
        parameters.motionModelRadius,
        parameters.motionModelRadiusWide,
        parameters.motionModelMinMatches,
        parameters.descProjThresh,
        parameters.opticalFlowMinInliers,
        parameters.kfMinFrames,
        parameters.kfMaxFrames,
        parameters.kfInlierRatio,
        parameters.kfMinInliers,
        parameters.kfRotThreshDeg,
        parameters.kfTransThresh,
        parameters.localMapTopK,
        parameters.localMapNeighborK,
        parameters.localMapRadius,
    };
}

cv::slam::OdometryParams toNative(const VisualOdometryParams& parameters)
{
    cv::slam::OdometryParams result;
    result.minInitInliers = parameters.minInitInliers;
    result.minInitParallaxDeg = parameters.minInitParallaxDeg;
    result.minInitPoints = parameters.minInitPoints;
    result.hfRatioThresh = parameters.hfRatioThresh;
    result.minGrowthParallaxDeg = parameters.minGrowthParallaxDeg;
    result.essentialRansacThresh = parameters.essentialRansacThresh;
    result.essentialRansacConfidence = parameters.essentialRansacConfidence;
    result.pnpReprojThresh = parameters.pnpReprojThresh;
    result.pnpMinInliers = parameters.pnpMinInliers;
    result.pnpRansacIters = parameters.pnpRansacIters;
    result.pnpConfidence = parameters.pnpConfidence;
    result.motionModelRadius = parameters.motionModelRadius;
    result.motionModelRadiusWide = parameters.motionModelRadiusWide;
    result.motionModelMinMatches = parameters.motionModelMinMatches;
    result.descProjThresh = parameters.descProjThresh;
    result.opticalFlowMinInliers = parameters.opticalFlowMinInliers;
    result.kfMinFrames = parameters.kfMinFrames;
    result.kfMaxFrames = parameters.kfMaxFrames;
    result.kfInlierRatio = parameters.kfInlierRatio;
    result.kfMinInliers = parameters.kfMinInliers;
    result.kfRotThreshDeg = parameters.kfRotThreshDeg;
    result.kfTransThresh = parameters.kfTransThresh;
    result.localMapTopK = parameters.localMapTopK;
    result.localMapNeighborK = parameters.localMapNeighborK;
    result.localMapRadius = parameters.localMapRadius;
    return result;
}
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_create(
    cv::Feature2D* detector, cv::DescriptorMatcher* matcher,
    const interop::InputArrayProxy* cameraMatrix, const interop::InputArrayProxy* distCoeffs,
    const VisualOdometryParams* parameters, cv::Ptr<Odometry>** odometry)
{
    return cvTry([&] {
        // The managed owner retains the original handles until the pipeline is destroyed.
        const cv::Ptr<cv::Feature2D> retainedDetector(detector, [](cv::Feature2D*) {});
        const cv::Ptr<cv::DescriptorMatcher> retainedMatcher(matcher, [](cv::DescriptorMatcher*) {});
        *odometry = new cv::Ptr<Odometry>(Odometry::create(
            retainedDetector, retainedMatcher, InProxy(*cameraMatrix), InProxy(*distCoeffs), toNative(*parameters)));
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_delete(cv::Ptr<Odometry>* odometry)
{
    return cvTry([&] {
        delete odometry;
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_getDefaultParams(VisualOdometryParams* parameters)
{
    return cvTry([&] {
        *parameters = fromNative(cv::slam::OdometryParams{});
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_processFrame(const cv::Ptr<Odometry>* odometry, const interop::InputArrayProxy* image, int* emitted)
{
    return cvTry([&] {
        *emitted = (*odometry)->processFrame(InProxy(*image)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_reset(cv::Ptr<Odometry>* odometry)
{
    return cvTry([&] {
        (*odometry)->reset();
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_getState(const cv::Ptr<Odometry>* odometry, int* state)
{
    return cvTry([&] {
        *state = static_cast<int>((*odometry)->getState());
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_getLastPose(const cv::Ptr<Odometry>* odometry, const interop::OutputArrayProxy* pose)
{
    return cvTry([&] {
        cv::Mat((*odometry)->getLastPose()).copyTo(OutProxy(*pose));
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_getNumKeyframes(const cv::Ptr<Odometry>* odometry, int* count)
{
    return cvTry([&] {
        *count = (*odometry)->getNumKeyframes();
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_getNumMapPoints(const cv::Ptr<Odometry>* odometry, int* count)
{
    return cvTry([&] {
        *count = (*odometry)->getNumMapPoints();
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_getTrajectory(const cv::Ptr<Odometry>* odometry, std::vector<cv::Mat>* poses)
{
    return cvTry([&] {
        const auto& trajectory = (*odometry)->getTrajectory();
        poses->reserve(trajectory.size());
        for (const auto& pose : trajectory)
            poses->emplace_back(pose);
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_getParams(const cv::Ptr<Odometry>* odometry, VisualOdometryParams* parameters)
{
    return cvTry([&] {
        *parameters = fromNative((*odometry)->getParams());
    });
}

CVAPI(ExceptionStatus) ptcloud_VisualOdometry_setParams(cv::Ptr<Odometry>* odometry, const VisualOdometryParams* parameters)
{
    return cvTry([&] {
        (*odometry)->setParams(toNative(*parameters));
    });
}

#endif
