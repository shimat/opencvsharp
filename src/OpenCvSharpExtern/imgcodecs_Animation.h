#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) imgcodecs_Animation_new(
    int loopCount,
    interop::Scalar bgColor,
    cv::Animation **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Animation(loopCount, cpp(bgColor));
    });
}

CVAPI(ExceptionStatus) imgcodecs_Animation_delete(cv::Animation *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) imgcodecs_Animation_get_loop_count(cv::Animation *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->loop_count; });
}
CVAPI(ExceptionStatus) imgcodecs_Animation_set_loop_count(cv::Animation *obj, int value)
{
    return cvTry([&] { obj->loop_count = value; });
}

CVAPI(ExceptionStatus) imgcodecs_Animation_get_bgcolor(cv::Animation *obj, interop::Scalar *returnValue)
{
    return cvTry([&] { *returnValue = c(obj->bgcolor); });
}
CVAPI(ExceptionStatus) imgcodecs_Animation_set_bgcolor(cv::Animation *obj, interop::Scalar value)
{
    return cvTry([&] { obj->bgcolor = cpp(value); });
}

CVAPI(ExceptionStatus) imgcodecs_Animation_get_durations(cv::Animation *obj, std::vector<int> *outVec)
{
    return cvTry([&] { *outVec = obj->durations; });
}
CVAPI(ExceptionStatus) imgcodecs_Animation_set_durations(cv::Animation *obj, int *data, int length)
{
    return cvTry([&] { obj->durations.assign(data, data + length); });
}

CVAPI(ExceptionStatus) imgcodecs_Animation_get_frames(cv::Animation *obj, std::vector<cv::Mat> *outVec)
{
    return cvTry([&] { *outVec = obj->frames; });
}
CVAPI(ExceptionStatus) imgcodecs_Animation_set_frames(cv::Animation *obj, std::vector<cv::Mat> *frames)
{
    return cvTry([&] { obj->frames = *frames; });
}

CVAPI(ExceptionStatus) imgcodecs_Animation_get_still_image(cv::Animation *obj, cv::Mat **returnValue)
{
    return cvTry([&] { *returnValue = new cv::Mat(obj->still_image); });
}
CVAPI(ExceptionStatus) imgcodecs_Animation_set_still_image(cv::Animation *obj, cv::Mat *image)
{
    return cvTry([&] { obj->still_image = *image; });
}

// On Windows, if 'filename' can't be represented in the process ANSI code page, *acpOk is set to 0
// (and *returnValue to 0) without calling cv::imreadanimation at all; the managed caller retries by
// copying the source to an ASCII-safe temp path and calling this function again with that path.
CVAPI(ExceptionStatus) imgcodecs_imreadanimation(
    const char *filename,
    cv::Animation *animation,
    int start,
    int count,
    int *acpOk,
    int *returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        std::string acp;
        if (pathRoundTripsAcp(filename, acp))
        {
            *acpOk = 1;
            *returnValue = cv::imreadanimation(acp, *animation, start, count) ? 1 : 0;
        }
        else
        {
            *acpOk = 0;
            *returnValue = 0;
        }
#else
        *acpOk = 1;
        *returnValue = cv::imreadanimation(filename, *animation, start, count) ? 1 : 0;
#endif
    });
}

CVAPI(ExceptionStatus) imgcodecs_imdecodeanimation(
    const interop::InputArrayProxy *buf,
    cv::Animation *animation,
    int start,
    int count,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::imdecodeanimation(InProxy(*buf), *animation, start, count) ? 1 : 0;
    });
}

// See imgcodecs_imreadanimation for the acpOk/managed-retry contract (write side retries by writing
// to an ASCII-safe temp path and moving it to the real destination).
CVAPI(ExceptionStatus) imgcodecs_imwriteanimation(
    const char *filename,
    cv::Animation *animation,
    int *params,
    int paramsLength,
    int *acpOk,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<int> paramsVec;
        if (params != nullptr)
            paramsVec = std::vector<int>(params, params + paramsLength);
#ifdef _WIN32
        std::string acp;
        if (pathRoundTripsAcp(filename, acp))
        {
            *acpOk = 1;
            *returnValue = cv::imwriteanimation(acp, *animation, paramsVec) ? 1 : 0;
        }
        else
        {
            *acpOk = 0;
            *returnValue = 0;
        }
#else
        *acpOk = 1;
        *returnValue = cv::imwriteanimation(filename, *animation, paramsVec) ? 1 : 0;
#endif
    });
}

CVAPI(ExceptionStatus) imgcodecs_imencodeanimation(
    const char *ext,
    cv::Animation *animation,
    std::vector<uchar> *buf,
    int *params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<int> paramsVec;
        if (params != nullptr)
            paramsVec = std::vector<int>(params, params + paramsLength);
        *returnValue = cv::imencodeanimation(ext, *animation, *buf, paramsVec) ? 1 : 0;
    });
}
