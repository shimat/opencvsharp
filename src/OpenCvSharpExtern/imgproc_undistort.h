#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) imgproc_drawFrameAxes(
    const interop::InputOutputArrayProxy* image,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::InputArrayProxy* rvec,
    const interop::InputArrayProxy* tvec,
    float length,
    int thickness)
{
    return cvTry([&] {
    cv::drawFrameAxes(IoProxy(*image), InProxy(*cameraMatrix), InProxy(*distCoeffs), InProxy(*rvec), InProxy(*tvec), length, thickness);
    });
}


CVAPI(ExceptionStatus) imgproc_undistort(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::InputArrayProxy* newCameraMatrix)
{
    return cvTry([&] {
    cv::undistort(InProxy(*src), OutProxy(*dst), InProxy(*cameraMatrix), InProxy(*distCoeffs), InProxy(*newCameraMatrix));
    });
}


CVAPI(ExceptionStatus) imgproc_initUndistortRectifyMap(
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    const interop::InputArrayProxy* R,
    const interop::InputArrayProxy* newCameraMatrix,
    interop::Size size,
    int m1type,
    const interop::OutputArrayProxy* map1,
    const interop::OutputArrayProxy* map2)
{
    return cvTry([&] {
    cv::initUndistortRectifyMap(InProxy(*cameraMatrix), InProxy(*distCoeffs), InProxy(*R), InProxy(*newCameraMatrix), cpp(size), m1type, OutProxy(*map1), OutProxy(*map2));
    });
}


CVAPI(ExceptionStatus) imgproc_initWideAngleProjMap(
    const interop::InputArrayProxy* cameraMatrix,
    const interop::InputArrayProxy* distCoeffs,
    interop::Size imageSize,
    int destImageWidth,
    int m1type,
    const interop::OutputArrayProxy* map1,
    const interop::OutputArrayProxy* map2,
    int projType,
    double alpha,
    float *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::initWideAngleProjMap(InProxy(*cameraMatrix), InProxy(*distCoeffs), cpp(imageSize), destImageWidth, m1type, 
        OutProxy(*map1), OutProxy(*map2), static_cast<cv::UndistortTypes>(projType), alpha);
    });
}
