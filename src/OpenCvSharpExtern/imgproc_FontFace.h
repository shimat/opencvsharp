#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region FontFace

CVAPI(ExceptionStatus) imgproc_FontFace_new1(cv::FontFace **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::FontFace();
    });
}

CVAPI(ExceptionStatus) imgproc_FontFace_new2(const char *fontPathOrName, cv::FontFace **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::FontFace(cv::String(fontPathOrName));
    });
}

CVAPI(ExceptionStatus) imgproc_FontFace_delete(cv::FontFace *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) imgproc_FontFace_set(
    cv::FontFace *obj,
    const char *fontPathOrName,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->set(cv::String(fontPathOrName)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) imgproc_FontFace_getName(cv::FontFace *obj, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(obj->getName());
    });
}

CVAPI(ExceptionStatus) imgproc_FontFace_setInstance(
    cv::FontFace *obj,
    int *params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
        const std::vector<int> v(params, params + paramsLength);
        *returnValue = obj->setInstance(v) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) imgproc_FontFace_getInstance(
    cv::FontFace *obj,
    std::vector<int> *params,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getInstance(*params) ? 1 : 0;
    });
}

#pragma endregion

#pragma region putText / getTextSize with FontFace

CVAPI(ExceptionStatus) imgproc_putText_FontFace(
    const interop::InputOutputArrayProxy* img,
    const char *text,
    interop::Point org,
    interop::Scalar color,
    cv::FontFace *fface,
    int size,
    int weight,
    int flags,
    int wrapStart,
    int wrapEnd,
    interop::Point *returnValue)
{
    return cvTry([&] {
        const auto p = cv::putText(
            IoProxy(*img), cv::String(text), cpp(org), cpp(color), *fface, size, weight,
            static_cast<cv::PutTextFlags>(flags), cv::Range(wrapStart, wrapEnd));
        *returnValue = c(p);
    });
}

CVAPI(ExceptionStatus) imgproc_getTextSize_FontFace(
    interop::Size imgsize,
    const char *text,
    interop::Point org,
    cv::FontFace *fface,
    int size,
    int weight,
    int flags,
    int wrapStart,
    int wrapEnd,
    interop::Rect *returnValue)
{
    return cvTry([&] {
        const auto r = cv::getTextSize(
            cpp(imgsize), cv::String(text), cpp(org), *fface, size, weight,
            static_cast<cv::PutTextFlags>(flags), cv::Range(wrapStart, wrapEnd));
        *returnValue = c(r);
    });
}

#pragma endregion
