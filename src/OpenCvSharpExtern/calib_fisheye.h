#pragma once

#ifndef NO_CALIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

/*CVAPI(ExceptionStatus) calib_fisheye_projectPoints1(
    const interop::InputArrayProxy* objectPoints,
    const interop::OutputArrayProxy* imagePoints,
    const cv::Affine3d& affine,
    const interop::InputArrayProxy* K,
    const interop::InputArrayProxy* D,
    double alpha,
    const interop::OutputArrayProxy* jacobian)
{
    return cvTry([&] {
        cv::fisheye::projectPoints(InProxy(*objectPoints), OutProxy(*imagePoints), affine, InProxy(*K), InProxy(*D), alpha, OutProxy(*jacobian));
    });
}*/

CVAPI(ExceptionStatus) calib_fisheye_projectPoints2(
    const interop::InputArrayProxy* objectPoints,
    const interop::OutputArrayProxy* imagePoints,
    const interop::InputArrayProxy* rvec,
    const interop::InputArrayProxy* tvec,
    const interop::InputArrayProxy* K,
    const interop::InputArrayProxy* D,
    double alpha,
    const interop::OutputArrayProxy* jacobian)
{
    return cvTry([&] {
        cv::fisheye::projectPoints(InProxy(*objectPoints), OutProxy(*imagePoints), InProxy(*rvec), InProxy(*tvec), InProxy(*K), InProxy(*D), alpha, OutProxy(*jacobian));
    });
}

CVAPI(ExceptionStatus) calib_fisheye_distortPoints(
    const interop::InputArrayProxy* undistorted,
    const interop::OutputArrayProxy* distorted,
    const interop::InputArrayProxy* K,
    const interop::InputArrayProxy* D,
    double alpha)
{
    return cvTry([&] {
        cv::fisheye::distortPoints(InProxy(*undistorted), OutProxy(*distorted), InProxy(*K), InProxy(*D), alpha);
    });
}

CVAPI(ExceptionStatus) calib_fisheye_distortPoints2(
    const interop::InputArrayProxy* undistorted,
    const interop::OutputArrayProxy* distorted,
    const interop::InputArrayProxy* Kundistorted,
    const interop::InputArrayProxy* K,
    const interop::InputArrayProxy* D,
    double alpha)
{
    return cvTry([&] {
        cv::fisheye::distortPoints(InProxy(*undistorted), OutProxy(*distorted), InProxy(*Kundistorted), InProxy(*K), InProxy(*D), alpha);
    });
}

CVAPI(ExceptionStatus) calib_fisheye_undistortPoints(
    const interop::InputArrayProxy* distorted,
    const interop::OutputArrayProxy* undistorted,
    const interop::InputArrayProxy* K,
    const interop::InputArrayProxy* D,
    const interop::InputArrayProxy* R,
    const interop::InputArrayProxy* P)
{
    return cvTry([&] {
        cv::fisheye::undistortPoints(InProxy(*distorted), OutProxy(*undistorted), InProxy(*K), InProxy(*D), InProxy(*R), InProxy(*P));
    });
}

CVAPI(ExceptionStatus) calib_fisheye_initUndistortRectifyMap(
    const interop::InputArrayProxy* K,
    const interop::InputArrayProxy* D,
    const interop::InputArrayProxy* R,
    const interop::InputArrayProxy* P,
    interop::Size size,
    int m1type,
    const interop::OutputArrayProxy* map1,
    const interop::OutputArrayProxy* map2)
{
    return cvTry([&] {
        cv::fisheye::initUndistortRectifyMap(InProxy(*K), InProxy(*D), InProxy(*R), InProxy(*P), cpp(size), m1type, OutProxy(*map1), OutProxy(*map2));
    });
}

CVAPI(ExceptionStatus) calib_fisheye_undistortImage(
    const interop::InputArrayProxy* distorted,
    const interop::OutputArrayProxy* undistorted,
    const interop::InputArrayProxy* K,
    const interop::InputArrayProxy* D,
    const interop::InputArrayProxy* Knew,
    interop::Size newSize)
{
    return cvTry([&] {
        cv::fisheye::undistortImage(InProxy(*distorted), OutProxy(*undistorted), InProxy(*K), InProxy(*D), InProxy(*Knew), cpp(newSize));
    });
}

CVAPI(ExceptionStatus) calib_fisheye_estimateNewCameraMatrixForUndistortRectify(
    const interop::InputArrayProxy* K,
    const interop::InputArrayProxy* D,
    interop::Size image_size,
    const interop::InputArrayProxy* R,
    const interop::OutputArrayProxy* P,
    double balance,
    interop::Size newSize,
    double fov_scale)
{
    return cvTry([&] {
        cv::fisheye::estimateNewCameraMatrixForUndistortRectify(InProxy(*K), InProxy(*D), cpp(image_size), InProxy(*R), OutProxy(*P), balance, cpp(newSize), fov_scale);
    });
}

CVAPI(ExceptionStatus) calib_fisheye_calibrate(
    std::vector<cv::Mat> *objectPoints,
    std::vector<cv::Mat> *imagePoints,
    interop::Size imageSize,
    const interop::InputOutputArrayProxy* K,
    const interop::InputOutputArrayProxy* D,
    std::vector<cv::Mat> *rvecs,
    std::vector<cv::Mat> *tvecs,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
        // Work around an OpenCV 5 upstream regression: cv::fisheye::calibrate's internal
        // ComputeJacobians/EstimateUncertainties helpers (modules/calib/src/fisheye.cpp) subtract
        // a `cv::Mat(std::vector<Point2d>)` from the per-view points Mat without transposing it
        // (their orientation check tests channels() == 1, which is never true for a 2-channel
        // points Mat). Since OpenCV 5 changed `Mat(vector<T>)` to build a 1xN mat instead of
        // OpenCV 4's Nx1, a column-shaped (Nx1) per-view Mat now mismatches and throws
        // StsUnmatchedSizes. Row-shaped (1xN) input sidesteps the bug, so reshape any Nx1 views
        // to 1xN before calling into OpenCV (reshape is a metadata-only view for continuous mats).
        const auto toRow = [](const cv::Mat &m) { return m.rows > m.cols ? m.reshape(0, 1) : m; };

        std::vector<cv::Mat> objectPointsRow(objectPoints->size());
        for (size_t i = 0; i < objectPoints->size(); i++)
            objectPointsRow[i] = toRow((*objectPoints)[i]);
        std::vector<cv::Mat> imagePointsRow(imagePoints->size());
        for (size_t i = 0; i < imagePoints->size(); i++)
            imagePointsRow[i] = toRow((*imagePoints)[i]);

        *returnValue = cv::fisheye::calibrate(
            objectPointsRow, imagePointsRow, cpp(imageSize),
            IoProxy(*K), IoProxy(*D), *rvecs, *tvecs, flags, cpp(criteria));
    });
}

CVAPI(ExceptionStatus) calib_fisheye_stereoRectify(
    const interop::InputArrayProxy* K1,
    const interop::InputArrayProxy* D1,
    const interop::InputArrayProxy* K2,
    const interop::InputArrayProxy* D2,
    interop::Size imageSize,
    const interop::InputArrayProxy* R,
    const interop::InputArrayProxy* tvec,
    const interop::OutputArrayProxy* R1,
    const interop::OutputArrayProxy* R2,
    const interop::OutputArrayProxy* P1,
    const interop::OutputArrayProxy* P2,
    const interop::OutputArrayProxy* Q,
    int flags,
    interop::Size newImageSize,
    double balance,
    double fov_scale)
{
    return cvTry([&] {
        cv::fisheye::stereoRectify(InProxy(*K1), InProxy(*D1), InProxy(*K2), InProxy(*D2), cpp(imageSize), InProxy(*R), InProxy(*tvec), OutProxy(*R1), OutProxy(*R2), OutProxy(*P1), OutProxy(*P2), OutProxy(*Q), flags, cpp(newImageSize), balance, fov_scale);
    });
}

CVAPI(ExceptionStatus) calib_fisheye_stereoCalibrate(
    std::vector<cv::Mat> *objectPoints,
    std::vector<cv::Mat> *imagePoints1,
    std::vector<cv::Mat> *imagePoints2,
    const interop::InputOutputArrayProxy* K1,
    const interop::InputOutputArrayProxy* D1,
    const interop::InputOutputArrayProxy* K2,
    const interop::InputOutputArrayProxy* D2,
    interop::Size imageSize,
    const interop::OutputArrayProxy* R,
    const interop::OutputArrayProxy* T,
    int flags,
    interop::TermCriteria criteria,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::fisheye::stereoCalibrate(
            *objectPoints, *imagePoints1, *imagePoints2,
            IoProxy(*K1), IoProxy(*D1),
            IoProxy(*K2), IoProxy(*D2),
            cpp(imageSize), OutProxy(*R), OutProxy(*T), flags, cpp(criteria));
    });
}

#endif // NO_CALIB
