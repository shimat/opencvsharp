#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region FontFace

CVAPI(ExceptionStatus) imgproc_FontFace_new1(cv::FontFace **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::FontFace();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_FontFace_new2(const char *fontPathOrName, cv::FontFace **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::FontFace(cv::String(fontPathOrName));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_FontFace_delete(cv::FontFace *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_FontFace_set(cv::FontFace *obj, const char *fontPathOrName, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->set(cv::String(fontPathOrName)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_FontFace_getName(cv::FontFace *obj, std::string *returnValue)
{
    BEGIN_WRAP
    returnValue->assign(obj->getName());
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_FontFace_setInstance(cv::FontFace *obj, int *params, int paramsLength, int *returnValue)
{
    BEGIN_WRAP
    const std::vector<int> v(params, params + paramsLength);
    *returnValue = obj->setInstance(v) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_FontFace_getInstance(cv::FontFace *obj, std::vector<int> *params, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getInstance(*params) ? 1 : 0;
    END_WRAP
}

#pragma endregion

#pragma region putText / getTextSize with FontFace

CVAPI(ExceptionStatus) imgproc_putText_FontFace(
    cv::_InputOutputArray *img, const char *text, MyCvPoint org, MyCvScalar color,
    cv::FontFace *fface, int size, int weight, int flags, int wrapStart, int wrapEnd,
    MyCvPoint *returnValue)
{
    BEGIN_WRAP
    const auto p = cv::putText(
        *img, cv::String(text), cpp(org), cpp(color), *fface, size, weight,
        static_cast<cv::PutTextFlags>(flags), cv::Range(wrapStart, wrapEnd));
    *returnValue = c(p);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_getTextSize_FontFace(
    MyCvSize imgsize, const char *text, MyCvPoint org,
    cv::FontFace *fface, int size, int weight, int flags, int wrapStart, int wrapEnd,
    MyCvRect *returnValue)
{
    BEGIN_WRAP
    const auto r = cv::getTextSize(
        cpp(imgsize), cv::String(text), cpp(org), *fface, size, weight,
        static_cast<cv::PutTextFlags>(flags), cv::Range(wrapStart, wrapEnd));
    *returnValue = c(r);
    END_WRAP
}

#pragma endregion
