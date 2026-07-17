#pragma once

#ifndef NO_STITCHING

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include "opencv2/stitching/detail/timelapsers.hpp"


// Timelapser

CVAPI(ExceptionStatus) stitching_Timelapser_createDefault(
    int type, cv::Ptr<cv::detail::Timelapser> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::detail::Timelapser::createDefault(type);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_Timelapser_get(
    cv::Ptr<cv::detail::Timelapser> *ptr, cv::detail::Timelapser **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_Timelapser_delete(cv::Ptr<cv::detail::Timelapser> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) stitching_Timelapser_initialize(
    cv::detail::Timelapser *obj,
    const interop::Point *corners, int cornersLength,
    const interop::Size *sizes, int sizesLength)
{
    return cvTry([&] {
        std::vector<cv::Point> cornersVec;
        cornersVec.reserve(cornersLength);
        for (int i = 0; i < cornersLength; i++)
            cornersVec.push_back(cpp(corners[i]));

        std::vector<cv::Size> sizesVec;
        sizesVec.reserve(sizesLength);
        for (int i = 0; i < sizesLength; i++)
            sizesVec.push_back(cpp(sizes[i]));

        obj->initialize(cornersVec, sizesVec);
    });
}

CVAPI(ExceptionStatus) stitching_Timelapser_process(
    cv::detail::Timelapser *obj,
    const interop::InputArrayProxy *img,
    const interop::InputArrayProxy *mask,
    interop::Point tl)
{
    return cvTry([&] {
        obj->process(InProxy(*img), InProxy(*mask), cpp(tl));
    });
}

CVAPI(ExceptionStatus) stitching_Timelapser_getDst(
    cv::detail::Timelapser *obj, cv::Mat *returnValue)
{
    return cvTry([&] {
        obj->getDst().copyTo(*returnValue);
    });
}

#endif // NO_STITCHING
