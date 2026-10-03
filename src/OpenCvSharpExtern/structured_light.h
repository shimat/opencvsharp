#pragma once

#if !defined(NO_CONTRIB) && defined(HAVE_OPENCV_STRUCTURED_LIGHT)

#include "include_opencv.h"
#include <opencv2/structured_light.hpp>

CVAPI(ExceptionStatus) structured_light_SinusoidalPattern_create(
    int width, int height, int periods, float shiftValue, int methodId,
    int pixelsBetweenMarkers, int horizontal, int setMarkers,
    cv::Ptr<cv::structured_light::SinusoidalPattern>** returnValue)
{
    return cvTry([&] {
        auto params = cv::makePtr<cv::structured_light::SinusoidalPattern::Params>();
        params->width = width;
        params->height = height;
        params->nbrOfPeriods = periods;
        params->shiftValue = shiftValue;
        params->methodId = methodId;
        params->nbrOfPixelsBetweenMarkers = pixelsBetweenMarkers;
        params->horizontal = horizontal != 0;
        params->setMarkers = setMarkers != 0;
        const auto ptr = cv::structured_light::SinusoidalPattern::create(params);
        *returnValue = new cv::Ptr<cv::structured_light::SinusoidalPattern>(ptr);
    });
}

CVAPI(ExceptionStatus) structured_light_Ptr_SinusoidalPattern_delete(
    cv::Ptr<cv::structured_light::SinusoidalPattern>* obj)
{ return cvTry([&] { delete obj; }); }

CVAPI(ExceptionStatus) structured_light_Ptr_SinusoidalPattern_get(
    cv::Ptr<cv::structured_light::SinusoidalPattern>* obj,
    cv::structured_light::SinusoidalPattern** returnValue)
{ return cvTry([&] { *returnValue = obj->get(); }); }

CVAPI(ExceptionStatus) structured_light_SinusoidalPattern_computePhaseMap(
    cv::structured_light::SinusoidalPattern* obj, std::vector<cv::Mat>* images,
    const interop::OutputArrayProxy* wrappedPhaseMap,
    const interop::OutputArrayProxy* shadowMask,
    const interop::InputArrayProxy* fundamental)
{
    return cvTry([&] { obj->computePhaseMap(*images, OutProxy(*wrappedPhaseMap),
        OutProxy(*shadowMask), InProxy(*fundamental)); });
}

CVAPI(ExceptionStatus) structured_light_SinusoidalPattern_unwrapPhaseMap(
    cv::structured_light::SinusoidalPattern* obj,
    const interop::InputArrayProxy* wrappedPhaseMap,
    const interop::OutputArrayProxy* unwrappedPhaseMap,
    interop::Size camSize, const interop::InputArrayProxy* shadowMask)
{
    return cvTry([&] { obj->unwrapPhaseMap(InProxy(*wrappedPhaseMap),
        OutProxy(*unwrappedPhaseMap), cpp(camSize), InProxy(*shadowMask)); });
}

CVAPI(ExceptionStatus) structured_light_SinusoidalPattern_findProCamMatches(
    cv::structured_light::SinusoidalPattern* obj,
    const interop::InputArrayProxy* projectorPhase,
    const interop::InputArrayProxy* cameraPhase, std::vector<cv::Mat>* matches)
{
    return cvTry([&] { obj->findProCamMatches(InProxy(*projectorPhase),
        InProxy(*cameraPhase), *matches); });
}

CVAPI(ExceptionStatus) structured_light_SinusoidalPattern_computeDataModulationTerm(
    cv::structured_light::SinusoidalPattern* obj, std::vector<cv::Mat>* images,
    const interop::OutputArrayProxy* modulation,
    const interop::InputArrayProxy* shadowMask)
{
    return cvTry([&] { obj->computeDataModulationTerm(*images,
        OutProxy(*modulation), InProxy(*shadowMask)); });
}

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
