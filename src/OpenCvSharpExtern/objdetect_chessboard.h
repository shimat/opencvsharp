#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) objdetect_checkChessboard(
    const interop::InputArrayProxy* img,
    interop::Size size,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::checkChessboard(InProxy(*img), cpp(size)) ? 1 : 0;
    });
}


CVAPI(ExceptionStatus) objdetect_estimateChessboardSharpness(
    const interop::InputArrayProxy* image,
    interop::Size patternSize,
    const interop::InputArrayProxy* corners,
    float riseDistance,
    int vertical,
    const interop::OutputArrayProxy* sharpness,
    interop::Scalar *returnValue)
{
    return cvTry([&] {
        const auto ret = cv::estimateChessboardSharpness(
            InProxy(*image), cpp(patternSize), InProxy(*corners), riseDistance, vertical != 0, OutProxy(*sharpness));
        *returnValue = c(ret);
    });
}


CVAPI(ExceptionStatus) objdetect_findChessboardCornersSB_OutputArray(
    const interop::InputArrayProxy* image,
    interop::Size patternSize,
    const interop::OutputArrayProxy* corners,
    int flags,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::findChessboardCornersSB(InProxy(*image), cpp(patternSize), OutProxy(*corners), flags) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_findChessboardCornersSB_vector(
    const interop::InputArrayProxy* image,
    interop::Size patternSize,
    std::vector<cv::Point2f> *corners,
    int flags,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::findChessboardCornersSB(InProxy(*image), cpp(patternSize), *corners, flags) ? 1 : 0;
    });
}


CVAPI(ExceptionStatus) objdetect_find4QuadCornerSubpix_InputArray(
    const interop::InputArrayProxy* img,
    const interop::InputOutputArrayProxy* corners,
    interop::Size regionSize,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::find4QuadCornerSubpix(InProxy(*img), IoProxy(*corners), cpp(regionSize)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) objdetect_find4QuadCornerSubpix_vector(
    const interop::InputArrayProxy* img,
    std::vector<cv::Point2f> *corners,
    interop::Size regionSize,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::find4QuadCornerSubpix(InProxy(*img), *corners, cpp(regionSize)) ? 1 : 0;
    });
}


CVAPI(ExceptionStatus) objdetect_drawChessboardCorners_InputArray(
    const interop::InputOutputArrayProxy* image,
    interop::Size patternSize,
    const interop::InputArrayProxy* corners,
    int patternWasFound)
{
    return cvTry([&] {
        cv::drawChessboardCorners(IoProxy(*image), cpp(patternSize), InProxy(*corners), patternWasFound != 0);
    });
}

CVAPI(ExceptionStatus) objdetect_drawChessboardCorners_array(
    const interop::InputOutputArrayProxy* image,
    interop::Size patternSize,
    cv::Point2f *corners,
    int cornersLength,
    int patternWasFound)
{
    return cvTry([&] {
        const std::vector<cv::Point2f> cornersVec(corners, corners + cornersLength);
        cv::drawChessboardCorners(IoProxy(*image), cpp(patternSize), cornersVec, patternWasFound != 0);
    });
}

#endif // NO_OBJDETECT
