#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// ScanSegment

CVAPI(ExceptionStatus) ximgproc_Ptr_ScanSegment_delete(cv::Ptr<cv::ximgproc::ScanSegment>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_ScanSegment_get(cv::Ptr<cv::ximgproc::ScanSegment>* ptr, cv::ximgproc::ScanSegment** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_ScanSegment_getNumberOfSuperpixels(cv::ximgproc::ScanSegment* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNumberOfSuperpixels();
    });
}

CVAPI(ExceptionStatus) ximgproc_ScanSegment_iterate(
    cv::ximgproc::ScanSegment* obj,
    const interop::InputArrayProxy* img)
{
    return cvTry([&] {
        obj->iterate(InProxy(*img));
    });
}

CVAPI(ExceptionStatus) ximgproc_ScanSegment_getLabels(cv::ximgproc::ScanSegment* obj, const interop::OutputArrayProxy* labelsOut)
{
    return cvTry([&] {
        obj->getLabels(OutProxy(*labelsOut));
    });
}

CVAPI(ExceptionStatus) ximgproc_ScanSegment_getLabelContourMask(
    cv::ximgproc::ScanSegment* obj,
    const interop::OutputArrayProxy* image,
    int thickLine)
{
    return cvTry([&] {
        obj->getLabelContourMask(OutProxy(*image), thickLine != 0);
    });
}

CVAPI(ExceptionStatus) ximgproc_createScanSegment(
    int imageWidth,
    int imageHeight,
    int numSuperpixels,
    int slices,
    int mergeSmall,
    cv::Ptr<cv::ximgproc::ScanSegment>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createScanSegment(imageWidth, imageHeight, numSuperpixels, slices, mergeSmall != 0);
        *returnValue = new cv::Ptr<cv::ximgproc::ScanSegment>(ptr);
    });
}
