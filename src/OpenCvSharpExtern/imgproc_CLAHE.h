#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) imgproc_createCLAHE(
    double clipLimit,
    interop::Size tileGridSize,
    cv::Ptr<cv::CLAHE> **returnValue)
{
    return cvTry([&] {
        const auto ret = cv::createCLAHE(clipLimit, cpp(tileGridSize));
        *returnValue = clone(ret);
    });
}

CVAPI(ExceptionStatus) imgproc_Ptr_CLAHE_delete(cv::Ptr<cv::CLAHE> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) imgproc_Ptr_CLAHE_get(cv::Ptr<cv::CLAHE> *obj, cv::CLAHE **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}


CVAPI(ExceptionStatus) imgproc_CLAHE_apply(
    cv::CLAHE *obj,
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        obj->apply(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) imgproc_CLAHE_setClipLimit(cv::CLAHE *obj, double clipLimit)
{
    return cvTry([&] {
        obj->setClipLimit(clipLimit);
    });
}

CVAPI(ExceptionStatus) imgproc_CLAHE_getClipLimit(cv::CLAHE *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getClipLimit();
    });
}

CVAPI(ExceptionStatus) imgproc_CLAHE_setTilesGridSize(cv::CLAHE *obj, interop::Size tileGridSize)
{
    return cvTry([&] {
        obj->setTilesGridSize(cpp(tileGridSize));
    });
}

CVAPI(ExceptionStatus) imgproc_CLAHE_getTilesGridSize(cv::CLAHE *obj, interop::Size *returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getTilesGridSize());
    });
}

CVAPI(ExceptionStatus) imgproc_CLAHE_collectGarbage(cv::CLAHE *obj)
{
    return cvTry([&] {
        obj->collectGarbage();
    });
}
