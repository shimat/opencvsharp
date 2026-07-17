#pragma once

#ifndef NO_STITCHING

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


// SeamFinder

CVAPI(ExceptionStatus) stitching_SeamFinder_createDefault(
    int type, cv::Ptr<cv::detail::SeamFinder> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::detail::SeamFinder::createDefault(type);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_SeamFinder_get(
    cv::Ptr<cv::detail::SeamFinder> *ptr, cv::detail::SeamFinder **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_SeamFinder_delete(cv::Ptr<cv::detail::SeamFinder> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) stitching_SeamFinder_find(
    cv::detail::SeamFinder *obj,
    cv::Mat **src, int srcLength,
    const interop::Point *corners, int cornersLength,
    cv::Mat **masks, int masksLength)
{
    return cvTry([&] {
        std::vector<cv::UMat> srcVec;
        toUMatVec(src, srcLength, srcVec);

        std::vector<cv::Point> cornersVec;
        cornersVec.reserve(cornersLength);
        for (int i = 0; i < cornersLength; i++)
            cornersVec.push_back(cpp(corners[i]));

        std::vector<cv::UMat> masksVec;
        toUMatVec(masks, masksLength, masksVec);

        obj->find(srcVec, cornersVec, masksVec);

        for (int i = 0; i < masksLength && i < static_cast<int>(masksVec.size()); i++)
            masksVec[static_cast<size_t>(i)].copyTo(*masks[i]);
    });
}


// NoSeamFinder

CVAPI(ExceptionStatus) stitching_NoSeamFinder_new(cv::detail::NoSeamFinder **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::NoSeamFinder();
    });
}

CVAPI(ExceptionStatus) stitching_NoSeamFinder_delete(cv::detail::NoSeamFinder *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// VoronoiSeamFinder

CVAPI(ExceptionStatus) stitching_VoronoiSeamFinder_new(cv::detail::VoronoiSeamFinder **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::VoronoiSeamFinder();
    });
}

CVAPI(ExceptionStatus) stitching_VoronoiSeamFinder_delete(cv::detail::VoronoiSeamFinder *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// DpSeamFinder

CVAPI(ExceptionStatus) stitching_DpSeamFinder_new(const char *costFunc, cv::detail::DpSeamFinder **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::DpSeamFinder(cv::String(costFunc));
    });
}

CVAPI(ExceptionStatus) stitching_DpSeamFinder_delete(cv::detail::DpSeamFinder *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_DpSeamFinder_setCostFunction(cv::detail::DpSeamFinder *obj, const char *val)
{
    return cvTry([&] {
        obj->setCostFunction(cv::String(val));
    });
}


// GraphCutSeamFinder

CVAPI(ExceptionStatus) stitching_GraphCutSeamFinder_new(
    const char *costType, float terminalCost, float badRegionPenalty, cv::detail::GraphCutSeamFinder **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::GraphCutSeamFinder(cv::String(costType), terminalCost, badRegionPenalty);
    });
}

CVAPI(ExceptionStatus) stitching_GraphCutSeamFinder_delete(cv::detail::GraphCutSeamFinder *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_GraphCutSeamFinder_find(
    cv::detail::GraphCutSeamFinder *obj,
    cv::Mat **src, int srcLength,
    const interop::Point *corners, int cornersLength,
    cv::Mat **masks, int masksLength)
{
    return cvTry([&] {
        std::vector<cv::UMat> srcVec;
        toUMatVec(src, srcLength, srcVec);

        std::vector<cv::Point> cornersVec;
        cornersVec.reserve(cornersLength);
        for (int i = 0; i < cornersLength; i++)
            cornersVec.push_back(cpp(corners[i]));

        std::vector<cv::UMat> masksVec;
        toUMatVec(masks, masksLength, masksVec);

        obj->find(srcVec, cornersVec, masksVec);

        for (int i = 0; i < masksLength && i < static_cast<int>(masksVec.size()); i++)
            masksVec[static_cast<size_t>(i)].copyTo(*masks[i]);
    });
}

#endif // NO_STITCHING
