#pragma once

#ifndef NO_PTCLOUD

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_loadPointCloud(
    const char *filename,
    const interop::OutputArrayProxy* vertices,
    const interop::OutputArrayProxy* normals,
    const interop::OutputArrayProxy* rgb)
{
    return cvTry([&] {
        cv::loadPointCloud(filename, OutProxy(*vertices), OutProxy(*normals), OutProxy(*rgb));
    });
}

CVAPI(ExceptionStatus) ptcloud_savePointCloud(
    const char *filename,
    const interop::InputArrayProxy* vertices,
    const interop::InputArrayProxy* normals,
    const interop::InputArrayProxy* rgb)
{
    return cvTry([&] {
        cv::savePointCloud(filename, InProxy(*vertices), InProxy(*normals), InProxy(*rgb));
    });
}

CVAPI(ExceptionStatus) ptcloud_loadMesh(
    const char *filename,
    const interop::OutputArrayProxy* vertices,
    std::vector<cv::Mat> *indices,
    const interop::OutputArrayProxy* normals,
    const interop::OutputArrayProxy* colors,
    const interop::OutputArrayProxy* texCoords)
{
    return cvTry([&] {
        cv::loadMesh(filename, OutProxy(*vertices), *indices, OutProxy(*normals), OutProxy(*colors), OutProxy(*texCoords));
    });
}

CVAPI(ExceptionStatus) ptcloud_saveMesh(
    const char *filename,
    const interop::InputArrayProxy* vertices,
    std::vector<cv::Mat> *indices,
    const interop::InputArrayProxy* normals,
    const interop::InputArrayProxy* colors,
    const interop::InputArrayProxy* texCoords)
{
    return cvTry([&] {
        cv::saveMesh(filename, InProxy(*vertices), *indices, InProxy(*normals), InProxy(*colors), InProxy(*texCoords));
    });
}

#endif // NO_PTCLOUD
