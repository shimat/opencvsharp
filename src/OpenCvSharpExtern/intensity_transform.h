#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_INTENSITY_TRANSFORM)
#include "include_opencv.h"
#include <opencv2/intensity_transform.hpp>

CVAPI(ExceptionStatus) intensity_transform_logTransform(const cv::Mat* input, cv::Mat* output)
{
    return cvTry([&] { cv::intensity_transform::logTransform(*input, *output); });
}

CVAPI(ExceptionStatus) intensity_transform_gammaCorrection(const cv::Mat* input, cv::Mat* output, float gamma)
{
    return cvTry([&] { cv::intensity_transform::gammaCorrection(*input, *output, gamma); });
}

CVAPI(ExceptionStatus) intensity_transform_autoscaling(const cv::Mat* input, cv::Mat* output)
{
    return cvTry([&] { cv::intensity_transform::autoscaling(*input, *output); });
}

CVAPI(ExceptionStatus) intensity_transform_contrastStretching(
    const cv::Mat* input, cv::Mat* output, int r1, int s1, int r2, int s2)
{
    return cvTry([&] { cv::intensity_transform::contrastStretching(*input, *output, r1, s1, r2, s2); });
}

CVAPI(ExceptionStatus) intensity_transform_bimef1(
    const interop::InputArrayProxy* input, const interop::OutputArrayProxy* output,
    float mu, float a, float b)
{
    return cvTry([&] { cv::intensity_transform::BIMEF(InProxy(*input), OutProxy(*output), mu, a, b); });
}

CVAPI(ExceptionStatus) intensity_transform_bimef2(
    const interop::InputArrayProxy* input, const interop::OutputArrayProxy* output,
    float exposureRatio, float mu, float a, float b)
{
    return cvTry([&] { cv::intensity_transform::BIMEF(InProxy(*input), OutProxy(*output), exposureRatio, mu, a, b); });
}
#endif // !NO_CONTRIB && HAVE_OPENCV_INTENSITY_TRANSFORM
