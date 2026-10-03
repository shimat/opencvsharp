#pragma once
#ifndef NO_STITCHING
#include "include_opencv.h"
#include <opencv2/stitching/detail/autocalib.hpp>
#include <opencv2/stitching/detail/util.hpp>

CVAPI(ExceptionStatus) stitching_detail_focalsFromHomography(cv::Mat* homography,
    double* f0, double* f1, int* f0Ok, int* f1Ok)
{
    return cvTry([&] {
        bool ok0 = false, ok1 = false;
        cv::detail::focalsFromHomography(*homography, *f0, *f1, ok0, ok1);
        *f0Ok = ok0 ? 1 : 0;
        *f1Ok = ok1 ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) stitching_detail_calibrateRotatingCamera(
    std::vector<cv::Mat>* homographies, cv::Mat* cameraMatrix, int* returnValue)
{
    return cvTry([&] { *returnValue = cv::detail::calibrateRotatingCamera(
        *homographies, *cameraMatrix) ? 1 : 0; });
}

CVAPI(ExceptionStatus) stitching_detail_overlapRoi(interop::Point tl1, interop::Point tl2,
    interop::Size sz1, interop::Size sz2, interop::Rect* roi, int* returnValue)
{
    return cvTry([&] {
        cv::Rect result;
        *returnValue = cv::detail::overlapRoi(cpp(tl1), cpp(tl2),
            cpp(sz1), cpp(sz2), result) ? 1 : 0;
        *roi = c(result);
    });
}

CVAPI(ExceptionStatus) stitching_detail_resultRoiSizes(
    const interop::Point* corners, const interop::Size* sizes,
    int length, interop::Rect* returnValue)
{
    return cvTry([&] {
        std::vector<cv::Point> c0;
        std::vector<cv::Size> s0;
        c0.reserve(length);
        s0.reserve(length);
        for (int i = 0; i < length; ++i) {
            c0.push_back(cpp(corners[i]));
            s0.push_back(cpp(sizes[i]));
        }
        *returnValue = c(cv::detail::resultRoi(c0, s0));
    });
}

CVAPI(ExceptionStatus) stitching_detail_resultRoiImages(
    const interop::Point* corners, cv::UMat** images,
    int length, interop::Rect* returnValue)
{
    return cvTry([&] {
        std::vector<cv::Point> c0;
        std::vector<cv::UMat> imgs;
        c0.reserve(length);
        imgs.reserve(length);
        for (int i = 0; i < length; ++i) {
            c0.push_back(cpp(corners[i]));
            imgs.push_back(*images[i]);
        }
        *returnValue = c(cv::detail::resultRoi(c0, imgs));
    });
}

CVAPI(ExceptionStatus) stitching_detail_resultRoiIntersection(
    const interop::Point* corners, const interop::Size* sizes,
    int length, interop::Rect* returnValue)
{
    return cvTry([&] {
        std::vector<cv::Point> c0;
        std::vector<cv::Size> s0;
        c0.reserve(length);
        s0.reserve(length);
        for (int i = 0; i < length; ++i) {
            c0.push_back(cpp(corners[i]));
            s0.push_back(cpp(sizes[i]));
        }
        *returnValue = c(cv::detail::resultRoiIntersection(c0, s0));
    });
}

CVAPI(ExceptionStatus) stitching_detail_resultTl(
    const interop::Point* corners, int length, interop::Point* returnValue)
{
    return cvTry([&] {
        std::vector<cv::Point> c0;
        c0.reserve(length);
        for (int i = 0; i < length; ++i) c0.push_back(cpp(corners[i]));
        *returnValue = c(cv::detail::resultTl(c0));
    });
}

CVAPI(ExceptionStatus) stitching_detail_selectRandomSubset(
    int count, int size, std::vector<int>* subset)
{
    return cvTry([&] {
        cv::detail::selectRandomSubset(count, size, *subset);
        // OpenCV 5.0.0 can append extra values after count reaches zero because
        // randu<int>() may be negative before the modulo operation.
        subset->resize(count);
    });
}

CVAPI(ExceptionStatus) stitching_detail_getLogLevel(int* returnValue)
{ return cvTry([&] { *returnValue = cv::detail::stitchingLogLevel(); }); }
CVAPI(ExceptionStatus) stitching_detail_setLogLevel(int value)
{ return cvTry([&] { cv::detail::stitchingLogLevel() = value; }); }
#endif
