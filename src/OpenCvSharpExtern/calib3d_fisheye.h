#ifndef _CPP_CALIB3D_FISHEYE_H_
#define _CPP_CALIB3D_FISHEYE_H_

#include "include_opencv.h"

CVAPI(void) calib3d_fisheye_projectPoints1(
    cv::_InputArray *objectPoints, cv::_OutputArray *imagePoints, const cv::Affine3d& affine,
    cv::_InputArray *K, cv::_InputArray *D, double alpha, cv::_OutputArray *jacobian)
{
    cv::fisheye::projectPoints(*objectPoints, *imagePoints, affine, *K, *D, alpha, entity(jacobian));
}

CVAPI(void) calib3d_fisheye_projectPoints2(
    cv::_InputArray *objectPoints, cv::_OutputArray *imagePoints, cv::_InputArray *rvec, cv::_InputArray *tvec,
    cv::_InputArray *K, cv::_InputArray *D, double alpha, cv::_OutputArray *jacobian)
{
    cv::fisheye::projectPoints(*objectPoints, *imagePoints, *rvec, *tvec, *K, *D, alpha, entity(jacobian));
}

CVAPI(void) calib3d_fisheye_distortPoints(
    cv::_InputArray *undistorted, cv::_OutputArray *distorted, cv::_InputArray *K, cv::_InputArray *D, double alpha)
{
    cv::fisheye::distortPoints(*undistorted, *distorted, *K, *D, alpha);
}

CVAPI(void) calib3d_fisheye_undistortPoints(
    cv::_InputArray *distorted, cv::_OutputArray *undistorted,
    cv::_InputArray *K, cv::_InputArray *D, cv::_InputArray *R, cv::_InputArray *P)
{
    cv::fisheye::undistortPoints(*distorted, *undistorted, *K, *D, entity(R), entity(P));
}

CVAPI(void) calib3d_fisheye_initUndistortRectifyMap(
    cv::_InputArray *K, cv::_InputArray *D, cv::_InputArray *R, cv::_InputArray *P,
    MyCvSize size, int m1type, cv::_OutputArray *map1, cv::_OutputArray *map2)
{
    cv::fisheye::initUndistortRectifyMap(*K, *D, *R, *P, cpp(size), m1type, *map1, *map2);
}

CVAPI(void) calib3d_fisheye_undistortImage(
    cv::_InputArray *distorted, cv::_OutputArray *undistorted,
    cv::_InputArray *K, cv::_InputArray *D, cv::_InputArray *Knew, MyCvSize newSize)
{
    cv::fisheye::undistortImage(*distorted, *undistorted, *K, *D, entity(Knew), cpp(newSize));
}

CVAPI(void) calib3d_fisheye_estimateNewCameraMatrixForUndistortRectify(
    cv::_InputArray *K, cv::_InputArray *D, MyCvSize image_size, cv::_InputArray *R,
    cv::_OutputArray *P, double balance, MyCvSize newSize, double fov_scale)
{
    cv::fisheye::estimateNewCameraMatrixForUndistortRectify(*K, *D, cpp(image_size), *R, *P, balance, cpp(newSize), fov_scale);
}

CVAPI(double) calib3d_fisheye_calibrate(
    std::vector<cv::Mat> *objectPoints,
    std::vector<cv::Mat> *imagePoints,
    MyCvSize imageSize,
    cv::_InputOutputArray *K,
    cv::_InputOutputArray *D,
    std::vector<cv::Mat> *rvecs,
    std::vector<cv::Mat> *tvecs,
    int flags,
    MyCvTermCriteria criteria)
{
    return cv::fisheye::calibrate(
        *objectPoints, *imagePoints, cpp(imageSize),
        *K, *D, *rvecs, *tvecs, flags, cpp(criteria));
}

CVAPI(void) calib3d_fisheye_stereoRectify(
    cv::_InputArray *K1, cv::_InputArray *D1, cv::_InputArray *K2, cv::_InputArray *D2, MyCvSize imageSize, cv::_InputArray *R, cv::_InputArray *tvec,
    cv::_OutputArray *R1, cv::_OutputArray *R2, cv::_OutputArray *P1, cv::_OutputArray *P2, cv::_OutputArray *Q, int flags, MyCvSize newImageSize,
    double balance, double fov_scale)
{
    cv::fisheye::stereoRectify(*K1, *D1, *K2, *D2, cpp(imageSize), *R, *tvec, *R1, *R2, *P1, *P2, *Q, flags, cpp(newImageSize), balance, fov_scale);
}

CVAPI(double) calib3d_fisheye_stereoCalibrate(
    std::vector<cv::Mat> *objectPoints,
    std::vector<cv::Mat> *imagePoints1, 
    std::vector<cv::Mat> *imagePoints2, 
    cv::_InputOutputArray *K1,
    cv::_InputOutputArray *D1,
    cv::_InputOutputArray *K2,
    cv::_InputOutputArray *D2,
    MyCvSize imageSize,
    cv::_OutputArray *R,
    cv::_OutputArray *T,
    int flags,
    MyCvTermCriteria criteria)
{
    return cv::fisheye::stereoCalibrate(
        *objectPoints, *imagePoints1, *imagePoints2,
        *K1, *D1,
        *K2, *D2,
        cpp(imageSize), entity(R), entity(T), flags, cpp(criteria));
}

#endif