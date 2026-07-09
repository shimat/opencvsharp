#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) imgcodecs_ImageCollection_new1(cv::ImageCollection **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::ImageCollection();
    });
}

CVAPI(ExceptionStatus) imgcodecs_ImageCollection_new2(
    const char *filename,
    int flags,
    cv::ImageCollection **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::ImageCollection(filename, flags);
    });
}

CVAPI(ExceptionStatus) imgcodecs_ImageCollection_delete(cv::ImageCollection *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) imgcodecs_ImageCollection_init(
    cv::ImageCollection *obj,
    const char *filename,
    int flags)
{
    return cvTry([&] {
        obj->init(filename, flags);
    });
}

CVAPI(ExceptionStatus) imgcodecs_ImageCollection_size(cv::ImageCollection *obj, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->size();
    });
}

CVAPI(ExceptionStatus) imgcodecs_ImageCollection_at(
    cv::ImageCollection *obj,
    int index,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->at(index));
    });
}

CVAPI(ExceptionStatus) imgcodecs_ImageCollection_releaseCache(cv::ImageCollection *obj, int index)
{
    return cvTry([&] {
        obj->releaseCache(index);
    });
}
