#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_FUZZY)
#include "include_opencv.h"
#include <opencv2/fuzzy.hpp>

CVAPI(ExceptionStatus) fuzzy_createKernel(
    int function, int radius, const interop::OutputArrayProxy* kernel, int channels)
{
    return cvTry([&] { cv::ft::createKernel(function, radius, OutProxy(*kernel), channels); });
}

CVAPI(ExceptionStatus) fuzzy_createKernelFromFunctions(
    const interop::InputArrayProxy* a, const interop::InputArrayProxy* b,
    const interop::OutputArrayProxy* kernel, int channels)
{
    return cvTry([&] { cv::ft::createKernel(InProxy(*a), InProxy(*b), OutProxy(*kernel), channels); });
}

CVAPI(ExceptionStatus) fuzzy_filter(
    const interop::InputArrayProxy* image, const interop::InputArrayProxy* kernel,
    const interop::OutputArrayProxy* output)
{
    return cvTry([&] { cv::ft::filter(InProxy(*image), InProxy(*kernel), OutProxy(*output)); });
}

CVAPI(ExceptionStatus) fuzzy_inpaint(
    const interop::InputArrayProxy* image, const interop::InputArrayProxy* mask,
    const interop::OutputArrayProxy* output, int radius, int function, int algorithm)
{
    return cvTry([&] {
        cv::ft::inpaint(InProxy(*image), InProxy(*mask), OutProxy(*output), radius, function, algorithm);
    });
}

CVAPI(ExceptionStatus) fuzzy_ft02dProcess(
    const interop::InputArrayProxy* image, const interop::InputArrayProxy* kernel,
    const interop::OutputArrayProxy* output, const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::ft::FT02D_process(InProxy(*image), InProxy(*kernel), OutProxy(*output), InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) fuzzy_ft12dProcess(
    const interop::InputArrayProxy* image, const interop::InputArrayProxy* kernel,
    const interop::OutputArrayProxy* output, const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::ft::FT12D_process(InProxy(*image), InProxy(*kernel), OutProxy(*output), InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) fuzzy_ft02dFastLinearProcess(
    const interop::InputArrayProxy* image, int radius, const interop::OutputArrayProxy* output)
{
    return cvTry([&] { cv::ft::FT02D_FL_process(InProxy(*image), radius, OutProxy(*output)); });
}

CVAPI(ExceptionStatus) fuzzy_ft02dFastLinearProcessFloat(
    const interop::InputArrayProxy* image, int radius, const interop::OutputArrayProxy* output)
{
    return cvTry([&] { cv::ft::FT02D_FL_process_float(InProxy(*image), radius, OutProxy(*output)); });
}
#endif // !NO_CONTRIB && HAVE_OPENCV_FUZZY
