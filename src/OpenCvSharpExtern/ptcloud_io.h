#pragma once

#ifndef NO_PTCLOUD

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_loadPointCloud(
    const char *filename, cv::_OutputArray *vertices, cv::_OutputArray *normals, cv::_OutputArray *rgb)
{
    return cvTry([&] {
    cv::loadPointCloud(filename, *vertices, entity(normals), entity(rgb));
    });
}

CVAPI(ExceptionStatus) ptcloud_savePointCloud(
    const char *filename, cv::_InputArray *vertices, cv::_InputArray *normals, cv::_InputArray *rgb)
{
    return cvTry([&] {
    cv::savePointCloud(filename, *vertices, entity(normals), entity(rgb));
    });
}

CVAPI(ExceptionStatus) ptcloud_loadMesh(
    const char *filename, cv::_OutputArray *vertices, std::vector<cv::Mat> *indices,
    cv::_OutputArray *normals, cv::_OutputArray *colors, cv::_OutputArray *texCoords)
{
    return cvTry([&] {
    cv::loadMesh(filename, *vertices, *indices, entity(normals), entity(colors), entity(texCoords));
    });
}

CVAPI(ExceptionStatus) ptcloud_saveMesh(
    const char *filename, cv::_InputArray *vertices, std::vector<cv::Mat> *indices,
    cv::_InputArray *normals, cv::_InputArray *colors, cv::_InputArray *texCoords)
{
    return cvTry([&] {
    cv::saveMesh(filename, *vertices, *indices, entity(normals), entity(colors), entity(texCoords));
    });
}

#endif // NO_PTCLOUD
