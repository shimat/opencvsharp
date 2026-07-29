#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_STRUCTURED_LIGHT)

#include "include_opencv.h"
#include <opencv2/structured_light.hpp>

CVAPI(ExceptionStatus) structured_light_Ptr_GrayCodePattern_delete(
    cv::Ptr<cv::structured_light::GrayCodePattern>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) structured_light_Ptr_GrayCodePattern_get(
    cv::Ptr<cv::structured_light::GrayCodePattern>* ptr,
    cv::structured_light::GrayCodePattern** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) structured_light_GrayCodePattern_create(
    int width,
    int height,
    cv::Ptr<cv::structured_light::GrayCodePattern>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::structured_light::GrayCodePattern::create(width, height);
        *returnValue = new cv::Ptr<cv::structured_light::GrayCodePattern>(ptr);
    });
}

CVAPI(ExceptionStatus) structured_light_StructuredLightPattern_generate(
    cv::structured_light::StructuredLightPattern* obj,
    std::vector<cv::Mat>* patternImages,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->generate(*patternImages) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) structured_light_StructuredLightPattern_decode(
    cv::structured_light::StructuredLightPattern* obj,
    cv::Mat*** patternImages,
    const int* patternImageCounts,
    int cameraCount,
    std::vector<cv::Mat>* blackImages,
    std::vector<cv::Mat>* whiteImages,
    const interop::OutputArrayProxy* disparityMap,
    int* returnValue)
{
    return cvTry([&] {
        std::vector<std::vector<cv::Mat>> patternImageVector(cameraCount);
        for (int cameraIndex = 0; cameraIndex < cameraCount; cameraIndex++)
        {
            auto& cameraImages = patternImageVector[cameraIndex];
            cameraImages.reserve(patternImageCounts[cameraIndex]);
            for (int imageIndex = 0; imageIndex < patternImageCounts[cameraIndex]; imageIndex++)
            {
                cameraImages.emplace_back(*patternImages[cameraIndex][imageIndex]);
            }
        }

        *returnValue = obj->decode(
            patternImageVector,
            OutProxy(*disparityMap),
            *blackImages,
            *whiteImages,
            cv::structured_light::DECODE_3D_UNDERWORLD) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) structured_light_GrayCodePattern_getNumberOfPatternImages(
    cv::structured_light::GrayCodePattern* obj,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->getNumberOfPatternImages());
    });
}

CVAPI(ExceptionStatus) structured_light_GrayCodePattern_setWhiteThreshold(
    cv::structured_light::GrayCodePattern* obj,
    int value)
{
    return cvTry([&] {
        obj->setWhiteThreshold(static_cast<size_t>(value));
    });
}

CVAPI(ExceptionStatus) structured_light_GrayCodePattern_setBlackThreshold(
    cv::structured_light::GrayCodePattern* obj,
    int value)
{
    return cvTry([&] {
        obj->setBlackThreshold(static_cast<size_t>(value));
    });
}

CVAPI(ExceptionStatus) structured_light_GrayCodePattern_getImagesForShadowMasks(
    cv::structured_light::GrayCodePattern* obj,
    const interop::OutputArrayProxy* blackImage,
    const interop::OutputArrayProxy* whiteImage)
{
    return cvTry([&] {
        cv::Mat blackImageValue;
        cv::Mat whiteImageValue;
        obj->getImagesForShadowMasks(blackImageValue, whiteImageValue);
        blackImageValue.copyTo(OutProxy(*blackImage));
        whiteImageValue.copyTo(OutProxy(*whiteImage));
    });
}

CVAPI(ExceptionStatus) structured_light_GrayCodePattern_getProjectorPixel(
    cv::structured_light::GrayCodePattern* obj,
    std::vector<cv::Mat>* patternImages,
    int x,
    int y,
    interop::Point* projectorPixel,
    int* returnValue)
{
    return cvTry([&] {
        cv::Point projectorPixelValue;
        const bool hasError = obj->getProjPixel(
            *patternImages,
            x,
            y,
            projectorPixelValue);
        *projectorPixel = c(projectorPixelValue);
        *returnValue = hasError ? 0 : 1;
    });
}

#endif
