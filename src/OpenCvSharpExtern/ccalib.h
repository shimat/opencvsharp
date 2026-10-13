#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_CCALIB)
#include "include_opencv.h"
#include <opencv2/ccalib/omnidir.hpp>

CVAPI(ExceptionStatus) ccalib_omnidir_projectPoints(
    const interop::InputArrayProxy* objectPoints, const interop::OutputArrayProxy* imagePoints,
    const interop::InputArrayProxy* rvec, const interop::InputArrayProxy* tvec,
    const interop::InputArrayProxy* K, double xi, const interop::InputArrayProxy* D,
    const interop::OutputArrayProxy* jacobian)
{
    return cvTry([&] {
        cv::omnidir::projectPoints(InProxy(*objectPoints), OutProxy(*imagePoints),
            InProxy(*rvec), InProxy(*tvec), InProxy(*K), xi, InProxy(*D), OutProxy(*jacobian));
    });
}

CVAPI(ExceptionStatus) ccalib_omnidir_undistortPoints(
    const interop::InputArrayProxy* distorted, const interop::OutputArrayProxy* undistorted,
    const interop::InputArrayProxy* K, const interop::InputArrayProxy* D,
    const interop::InputArrayProxy* xi, const interop::InputArrayProxy* R)
{
    return cvTry([&] {
        cv::omnidir::undistortPoints(InProxy(*distorted), OutProxy(*undistorted),
            InProxy(*K), InProxy(*D), InProxy(*xi), InProxy(*R));
    });
}

CVAPI(ExceptionStatus) ccalib_omnidir_initUndistortRectifyMap(
    const interop::InputArrayProxy* K, const interop::InputArrayProxy* D,
    const interop::InputArrayProxy* xi, const interop::InputArrayProxy* R,
    const interop::InputArrayProxy* P, interop::Size size, int m1type,
    const interop::OutputArrayProxy* map1, const interop::OutputArrayProxy* map2, int flags)
{
    return cvTry([&] {
        cv::omnidir::initUndistortRectifyMap(InProxy(*K), InProxy(*D), InProxy(*xi),
            InProxy(*R), InProxy(*P), cpp(size), m1type, OutProxy(*map1), OutProxy(*map2), flags);
    });
}

CVAPI(ExceptionStatus) ccalib_omnidir_undistortImage(
    const interop::InputArrayProxy* distorted, const interop::OutputArrayProxy* undistorted,
    const interop::InputArrayProxy* K, const interop::InputArrayProxy* D,
    const interop::InputArrayProxy* xi, int flags, const interop::InputArrayProxy* Knew,
    interop::Size newSize, const interop::InputArrayProxy* R)
{
    return cvTry([&] {
        cv::omnidir::undistortImage(InProxy(*distorted), OutProxy(*undistorted),
            InProxy(*K), InProxy(*D), InProxy(*xi), flags, InProxy(*Knew),
            cpp(newSize), InProxy(*R));
    });
}

CVAPI(ExceptionStatus) ccalib_omnidir_calibrate(
    std::vector<cv::Mat>* objectPoints, std::vector<cv::Mat>* imagePoints,
    interop::Size imageSize, const interop::InputOutputArrayProxy* K,
    const interop::InputOutputArrayProxy* xi, const interop::InputOutputArrayProxy* D,
    std::vector<cv::Mat>* rvecs, std::vector<cv::Mat>* tvecs,
    int flags, interop::TermCriteria criteria, const interop::OutputArrayProxy* indices,
    double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::omnidir::calibrate(*objectPoints, *imagePoints, cpp(imageSize),
            IoProxy(*K), IoProxy(*xi), IoProxy(*D), *rvecs, *tvecs,
            flags, cpp(criteria), OutProxy(*indices));
    });
}
#endif // !NO_CONTRIB && HAVE_OPENCV_CCALIB
