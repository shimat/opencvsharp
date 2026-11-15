#pragma once
#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_removeStatisticalOutliers(
    const interop::InputArrayProxy* inputCloud, const interop::OutputArrayProxy* outputCloud, int meanK,
    double stddevMulThresh, const interop::OutputArrayProxy* keptIndices)
{
    return cvTry([&] {
        cv::removeStatisticalOutliers(InProxy(*inputCloud), OutProxy(*outputCloud), meanK, stddevMulThresh, OutProxy(*keptIndices));
    });
}

CVAPI(ExceptionStatus) ptcloud_removeRadiusOutliers(
    const interop::InputArrayProxy* inputCloud, const interop::OutputArrayProxy* outputCloud, double radius,
    int minNeighbors, const interop::OutputArrayProxy* keptIndices)
{
    return cvTry([&] {
        cv::removeRadiusOutliers(InProxy(*inputCloud), OutProxy(*outputCloud), radius, minNeighbors, OutProxy(*keptIndices));
    });
}

CVAPI(ExceptionStatus) ptcloud_orientNormals(
    const interop::InputArrayProxy* inputCloud, const interop::InputOutputArrayProxy* normals,
    interop::Point3f viewpoint)
{
    return cvTry([&] {
        cv::orientNormals(InProxy(*inputCloud), IoProxy(*normals), cpp(viewpoint));
    });
}

CVAPI(ExceptionStatus) ptcloud_orientNormalsConsistent(
    const interop::InputArrayProxy* inputCloud, const interop::InputOutputArrayProxy* normals, int k)
{
    return cvTry([&] {
        cv::orientNormalsConsistent(InProxy(*inputCloud), IoProxy(*normals), k);
    });
}

CVAPI(ExceptionStatus) ptcloud_estimateMedianSpacing(
    const interop::InputArrayProxy* inputCloud, float* result)
{
    return cvTry([&] {
        *result = cv::estimateMedianSpacing(InProxy(*inputCloud));
    });
}

CVAPI(ExceptionStatus) ptcloud_createMeshBPA(
    const interop::InputArrayProxy* inputCloud, const interop::InputArrayProxy* normals,
    const interop::OutputArrayProxy* vertices, const interop::OutputArrayProxy* triangles,
    const interop::InputArrayProxy* radii)
{
    return cvTry([&] {
        cv::createMeshBPA(InProxy(*inputCloud), InProxy(*normals), OutProxy(*vertices), OutProxy(*triangles), InProxy(*radii));
    });
}

CVAPI(ExceptionStatus) ptcloud_boundingBox3D(
    const interop::InputArrayProxy* inputCloud, const interop::OutputArrayProxy* minBound,
    const interop::OutputArrayProxy* maxBound)
{
    return cvTry([&] {
        cv::boundingBox3D(InProxy(*inputCloud), OutProxy(*minBound), OutProxy(*maxBound));
    });
}

CVAPI(ExceptionStatus) ptcloud_orientedBoundingBox3D(
    const interop::InputArrayProxy* inputCloud, const interop::OutputArrayProxy* center,
    const interop::OutputArrayProxy* axes, const interop::OutputArrayProxy* halfExtents)
{
    return cvTry([&] {
        cv::orientedBoundingBox3D(InProxy(*inputCloud), OutProxy(*center), OutProxy(*axes), OutProxy(*halfExtents));
    });
}

CVAPI(ExceptionStatus) ptcloud_approxEnclosingSphere3D(
    const interop::InputArrayProxy* inputCloud, const interop::OutputArrayProxy* center, double* result)
{
    return cvTry([&] {
        *result = cv::approxEnclosingSphere3D(InProxy(*inputCloud), OutProxy(*center));
    });
}

CVAPI(ExceptionStatus) ptcloud_decodeGaussianSplats(
    const interop::InputArrayProxy* attributes, const interop::OutputArrayProxy* splats)
{
    return cvTry([&] {
        cv::decodeGaussianSplats(InProxy(*attributes), OutProxy(*splats));
    });
}

CVAPI(ExceptionStatus) ptcloud_decodeGaussianSplatsPacked(
    const interop::InputArrayProxy* buffer, const interop::OutputArrayProxy* splats)
{
    return cvTry([&] {
        cv::decodeGaussianSplatsPacked(InProxy(*buffer), OutProxy(*splats));
    });
}

CVAPI(ExceptionStatus) ptcloud_getGaussianSplatPlyPropNames(std::vector<std::string>* names)
{
    return cvTry([&] {
        *names = cv::getGaussianSplatPlyPropNames();
    });
}

CVAPI(ExceptionStatus) ptcloud_loadGaussianSplats(
    const char* filename, const interop::OutputArrayProxy* splats, const std::vector<std::string>* properties)
{
    return cvTry([&] {
        cv::loadGaussianSplats(filename, OutProxy(*splats), *properties);
    });
}

#endif
