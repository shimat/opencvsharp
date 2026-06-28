#pragma once

#ifndef NO_CALIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

/*CVAPI(ExceptionStatus) calib_fisheye_projectPoints1(
    cv::_InputArray *objectPoints, cv::_OutputArray *imagePoints, const cv::Affine3d& affine,
    cv::_InputArray *K, cv::_InputArray *D, double alpha, cv::_OutputArray *jacobian)
{
    return cvTry([&] {
    cv::fisheye::projectPoints(*objectPoints, *imagePoints, affine, *K, *D, alpha, entity(jacobian));
    });
}*/

CVAPI(ExceptionStatus) calib_fisheye_projectPoints2(
    cv::_InputArray *objectPoints, cv::_OutputArray *imagePoints, cv::_InputArray *rvec, cv::_InputArray *tvec,
    cv::_InputArray *K, cv::_InputArray *D, double alpha, cv::_OutputArray *jacobian)
{
    return cvTry([&] {
    cv::fisheye::projectPoints(*objectPoints, *imagePoints, *rvec, *tvec, *K, *D, alpha, entity(jacobian));
    });
}

CVAPI(ExceptionStatus) calib_fisheye_distortPoints(
    cv::_InputArray *undistorted, cv::_OutputArray *distorted, cv::_InputArray *K, cv::_InputArray *D, double alpha)
{
    return cvTry([&] {
    cv::fisheye::distortPoints(*undistorted, *distorted, *K, *D, alpha);
    });
}

CVAPI(ExceptionStatus) calib_fisheye_distortPoints2(
    cv::_InputArray *undistorted, cv::_OutputArray *distorted, cv::_InputArray *Kundistorted, cv::_InputArray *K, cv::_InputArray *D, double alpha)
{
    return cvTry([&] {
    cv::fisheye::distortPoints(*undistorted, *distorted, *Kundistorted, *K, *D, alpha);
    });
}

CVAPI(ExceptionStatus) calib_fisheye_undistortPoints(
    cv::_InputArray *distorted, cv::_OutputArray *undistorted,
    cv::_InputArray *K, cv::_InputArray *D, cv::_InputArray *R, cv::_InputArray *P)
{
    return cvTry([&] {
    cv::fisheye::undistortPoints(*distorted, *undistorted, *K, *D, entity(R), entity(P));
    });
}

CVAPI(ExceptionStatus) calib_fisheye_initUndistortRectifyMap(
    cv::_InputArray *K, cv::_InputArray *D, cv::_InputArray *R, cv::_InputArray *P,
    interop::Size size, int m1type, cv::_OutputArray *map1, cv::_OutputArray *map2)
{
    return cvTry([&] {
    cv::fisheye::initUndistortRectifyMap(*K, *D, *R, *P, cpp(size), m1type, *map1, *map2);
    });
}

CVAPI(ExceptionStatus) calib_fisheye_undistortImage(
    cv::_InputArray *distorted, cv::_OutputArray *undistorted,
    cv::_InputArray *K, cv::_InputArray *D, cv::_InputArray *Knew, interop::Size newSize)
{
    return cvTry([&] {
    cv::fisheye::undistortImage(*distorted, *undistorted, *K, *D, entity(Knew), cpp(newSize));
    });
}

CVAPI(ExceptionStatus) calib_fisheye_estimateNewCameraMatrixForUndistortRectify(
    cv::_InputArray *K, cv::_InputArray *D, interop::Size image_size, cv::_InputArray *R,
    cv::_OutputArray *P, double balance, interop::Size newSize, double fov_scale)
{
    return cvTry([&] {
    cv::fisheye::estimateNewCameraMatrixForUndistortRectify(*K, *D, cpp(image_size), *R, *P, balance, cpp(newSize), fov_scale);
    });
}

CVAPI(ExceptionStatus) calib_fisheye_calibrate(
    std::vector<cv::Mat> *objectPoints,
    std::vector<cv::Mat> *imagePoints,
    interop::Size imageSize,
    cv::_InputOutputArray *K,
    cv::_InputOutputArray *D,
    std::vector<cv::Mat> *rvecs,
    std::vector<cv::Mat> *tvecs,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::fisheye::calibrate(
        *objectPoints, *imagePoints, cpp(imageSize),
        *K, *D, *rvecs, *tvecs, flags, cpp(criteria));
    });
}

CVAPI(ExceptionStatus) calib_fisheye_stereoRectify(
    cv::_InputArray *K1, cv::_InputArray *D1, cv::_InputArray *K2, cv::_InputArray *D2, interop::Size imageSize, cv::_InputArray *R, cv::_InputArray *tvec,
    cv::_OutputArray *R1, cv::_OutputArray *R2, cv::_OutputArray *P1, cv::_OutputArray *P2, cv::_OutputArray *Q, int flags, interop::Size newImageSize,
    double balance, double fov_scale)
{
    return cvTry([&] {
    cv::fisheye::stereoRectify(*K1, *D1, *K2, *D2, cpp(imageSize), *R, *tvec, *R1, *R2, *P1, *P2, *Q, flags, cpp(newImageSize), balance, fov_scale);
    });
}

CVAPI(ExceptionStatus) calib_fisheye_stereoCalibrate(
    std::vector<cv::Mat> *objectPoints,
    std::vector<cv::Mat> *imagePoints1, 
    std::vector<cv::Mat> *imagePoints2, 
    cv::_InputOutputArray *K1,
    cv::_InputOutputArray *D1,
    cv::_InputOutputArray *K2,
    cv::_InputOutputArray *D2,
    interop::Size imageSize,
    cv::_OutputArray *R,
    cv::_OutputArray *T,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
    *returnValue = cv::fisheye::stereoCalibrate(
        *objectPoints, *imagePoints1, *imagePoints2,
        *K1, *D1,
        *K2, *D2,
        cpp(imageSize), entity(R), entity(T), flags, cpp(criteria));
    });
}

#endif // NO_CALIB
