#pragma once

#ifndef NO_STITCHING

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


// Blender

CVAPI(ExceptionStatus) stitching_Blender_createDefault(
    int type, int tryGpu, cv::Ptr<cv::detail::Blender> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::detail::Blender::createDefault(type, tryGpu != 0);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_Blender_get(
    cv::Ptr<cv::detail::Blender> *ptr, cv::detail::Blender **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_Blender_delete(cv::Ptr<cv::detail::Blender> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) stitching_Blender_prepare1(
    cv::detail::Blender *obj,
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

        obj->prepare(cornersVec, sizesVec);
    });
}

CVAPI(ExceptionStatus) stitching_Blender_prepare2(cv::detail::Blender *obj, interop::Rect dstRoi)
{
    return cvTry([&] {
        obj->prepare(cpp(dstRoi));
    });
}

CVAPI(ExceptionStatus) stitching_Blender_feed(
    cv::detail::Blender *obj,
    const interop::InputArrayProxy *img,
    const interop::InputArrayProxy *mask,
    interop::Point tl)
{
    return cvTry([&] {
        obj->feed(InProxy(*img), InProxy(*mask), cpp(tl));
    });
}

CVAPI(ExceptionStatus) stitching_Blender_blend(
    cv::detail::Blender *obj,
    const interop::InputOutputArrayProxy *dst,
    const interop::InputOutputArrayProxy *dstMask)
{
    return cvTry([&] {
        obj->blend(IoProxy(*dst), IoProxy(*dstMask));
    });
}


// FeatherBlender

CVAPI(ExceptionStatus) stitching_FeatherBlender_new(float sharpness, cv::detail::FeatherBlender **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::FeatherBlender(sharpness);
    });
}

CVAPI(ExceptionStatus) stitching_FeatherBlender_delete(cv::detail::FeatherBlender *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_FeatherBlender_getSharpness(cv::detail::FeatherBlender *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->sharpness();
    });
}
CVAPI(ExceptionStatus) stitching_FeatherBlender_setSharpness(cv::detail::FeatherBlender *obj, float val)
{
    return cvTry([&] {
        obj->setSharpness(val);
    });
}

CVAPI(ExceptionStatus) stitching_FeatherBlender_createWeightMaps(
    cv::detail::FeatherBlender *obj,
    cv::Mat **masks, int masksLength,
    const interop::Point *corners, int cornersLength,
    cv::Mat **weightMaps, int weightMapsLength,
    interop::Rect *returnValue)
{
    return cvTry([&] {
        std::vector<cv::UMat> masksVec;
        toUMatVec(masks, masksLength, masksVec);

        std::vector<cv::Point> cornersVec;
        cornersVec.reserve(cornersLength);
        for (int i = 0; i < cornersLength; i++)
            cornersVec.push_back(cpp(corners[i]));

        std::vector<cv::UMat> weightMapsVec;
        toUMatVec(weightMaps, weightMapsLength, weightMapsVec);

        const auto roi = obj->createWeightMaps(masksVec, cornersVec, weightMapsVec);
        *returnValue = c(roi);

        for (int i = 0; i < weightMapsLength && i < static_cast<int>(weightMapsVec.size()); i++)
            weightMapsVec[static_cast<size_t>(i)].copyTo(*weightMaps[i]);
    });
}


// MultiBandBlender

CVAPI(ExceptionStatus) stitching_MultiBandBlender_new(
    int tryGpu, int numBands, int weightType, cv::detail::MultiBandBlender **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::detail::MultiBandBlender(tryGpu != 0, numBands, weightType);
    });
}

CVAPI(ExceptionStatus) stitching_MultiBandBlender_delete(cv::detail::MultiBandBlender *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_MultiBandBlender_getNumBands(cv::detail::MultiBandBlender *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->numBands();
    });
}
CVAPI(ExceptionStatus) stitching_MultiBandBlender_setNumBands(cv::detail::MultiBandBlender *obj, int val)
{
    return cvTry([&] {
        obj->setNumBands(val);
    });
}


// Auxiliary functions

CVAPI(ExceptionStatus) stitching_normalizeUsingWeightMap(
    const interop::InputArrayProxy *weight, const interop::InputOutputArrayProxy *src)
{
    return cvTry([&] {
        cv::detail::normalizeUsingWeightMap(InProxy(*weight), IoProxy(*src));
    });
}

CVAPI(ExceptionStatus) stitching_createWeightMap(
    const interop::InputArrayProxy *mask, float sharpness, const interop::InputOutputArrayProxy *weight)
{
    return cvTry([&] {
        cv::detail::createWeightMap(InProxy(*mask), sharpness, IoProxy(*weight));
    });
}

CVAPI(ExceptionStatus) stitching_createLaplacePyr(
    const interop::InputArrayProxy *img, int numLevels, std::vector<cv::Mat> *returnValue)
{
    return cvTry([&] {
        std::vector<cv::UMat> pyr;
        cv::detail::createLaplacePyr(InProxy(*img), numLevels, pyr);

        returnValue->reserve(pyr.size());
        for (const auto &level : pyr)
        {
            cv::Mat m;
            level.copyTo(m);
            returnValue->push_back(m);
        }
    });
}

CVAPI(ExceptionStatus) stitching_restoreImageFromLaplacePyr(
    cv::Mat **pyr, int pyrLength, cv::Mat *returnValue)
{
    return cvTry([&] {
        std::vector<cv::UMat> pyrVec;
        toUMatVec(pyr, pyrLength, pyrVec);

        cv::detail::restoreImageFromLaplacePyr(pyrVec);

        if (!pyrVec.empty())
            pyrVec[0].copyTo(*returnValue);
    });
}

#endif // NO_STITCHING
