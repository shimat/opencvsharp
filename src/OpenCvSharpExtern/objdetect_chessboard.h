#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) objdetect_checkChessboard(
    cv::_InputArray *img, MyCvSize size, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::checkChessboard(*img, cpp(size)) ? 1 : 0;
    END_WRAP
}


CVAPI(ExceptionStatus) objdetect_findChessboardCornersSB_OutputArray(
    cv::_InputArray *image, MyCvSize patternSize, cv::_OutputArray *corners, int flags, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findChessboardCornersSB(*image, cpp(patternSize), *corners, flags) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_findChessboardCornersSB_vector(
    cv::_InputArray *image, MyCvSize patternSize, std::vector<cv::Point2f> *corners, int flags, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::findChessboardCornersSB(*image, cpp(patternSize), *corners, flags) ? 1 : 0;
    END_WRAP
}


CVAPI(ExceptionStatus) objdetect_find4QuadCornerSubpix_InputArray(
    cv::_InputArray *img, cv::_InputOutputArray *corners, MyCvSize regionSize, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::find4QuadCornerSubpix(*img, *corners, cpp(regionSize)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_find4QuadCornerSubpix_vector(
    cv::_InputArray *img, std::vector<cv::Point2f> *corners, MyCvSize regionSize, 
    int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::find4QuadCornerSubpix(*img, *corners, cpp(regionSize)) ? 1 : 0;
    END_WRAP
}


CVAPI(ExceptionStatus) objdetect_drawChessboardCorners_InputArray(
    cv::_InputOutputArray *image, MyCvSize patternSize,
    cv::_InputArray *corners, int patternWasFound)
{
    BEGIN_WRAP
    cv::drawChessboardCorners(*image, cpp(patternSize), *corners, patternWasFound != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_drawChessboardCorners_array(
    cv::_InputOutputArray *image, MyCvSize patternSize,
    cv::Point2f *corners, int cornersLength, int patternWasFound)
{
    BEGIN_WRAP
    const std::vector<cv::Point2f> cornersVec(corners, corners + cornersLength);
    cv::drawChessboardCorners(*image, cpp(patternSize), cornersVec, patternWasFound != 0);
    END_WRAP
}

#endif // NO_OBJDETECT
