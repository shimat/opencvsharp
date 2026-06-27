#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) imgproc_drawFrameAxes(
    cv::_InputOutputArray *image, cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputArray *rvec, cv::_InputArray *tvec, float length, int thickness)
{
    BEGIN_WRAP
    cv::drawFrameAxes(*image, *cameraMatrix, *distCoeffs, *rvec, *tvec, length, thickness);
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_undistort(
    cv::_InputArray *src, cv::_OutputArray *dst,
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs, cv::_InputArray *newCameraMatrix)
{
    BEGIN_WRAP
    cv::undistort(*src, *dst, *cameraMatrix, entity(distCoeffs), entity(newCameraMatrix));
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_initUndistortRectifyMap(
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    cv::_InputArray *R, cv::_InputArray *newCameraMatrix,
    interop::Size size, int m1type, cv::_OutputArray *map1, cv::_OutputArray *map2)
{
    BEGIN_WRAP
    cv::initUndistortRectifyMap(*cameraMatrix, *distCoeffs, *R, *newCameraMatrix, cpp(size), m1type, *map1, *map2);
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_initWideAngleProjMap(
    cv::_InputArray *cameraMatrix, cv::_InputArray *distCoeffs,
    interop::Size imageSize, int destImageWidth,
    int m1type, cv::_OutputArray *map1, cv::_OutputArray *map2,
    int projType, double alpha,
    float *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::initWideAngleProjMap(*cameraMatrix, *distCoeffs, cpp(imageSize), destImageWidth, m1type, 
        *map1, *map2, static_cast<cv::UndistortTypes>(projType), alpha);
    END_WRAP
}
