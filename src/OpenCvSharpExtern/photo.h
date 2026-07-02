#pragma once

#ifndef NO_PHOTO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) photo_inpaint(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* inpaintMask,
    const interop::OutputArrayProxy* dst,
    double inpaintRadius,
    int flags)
{
    return cvTry([&] {
    cv::inpaint(InProxy(*src), InProxy(*inpaintMask), OutProxy(*dst), inpaintRadius, flags);
    });
}

CVAPI(ExceptionStatus) photo_fastNlMeansDenoising(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    float h,
    int templateWindowSize,
    int searchWindowSize)
{
    return cvTry([&] {
    cv::fastNlMeansDenoising(InProxy(*src), OutProxy(*dst), h, templateWindowSize, searchWindowSize);
    });
}

CVAPI(ExceptionStatus) photo_fastNlMeansDenoisingColored(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    float h,
    float hColor,
    int templateWindowSize,
    int searchWindowSize)
{
    return cvTry([&] {
    cv::fastNlMeansDenoisingColored(InProxy(*src), OutProxy(*dst), h, hColor, templateWindowSize, searchWindowSize);
    });
}

CVAPI(ExceptionStatus) photo_fastNlMeansDenoisingMulti(
    cv::Mat **srcImgs,
    int srcImgsLength,
    const interop::OutputArrayProxy* dst,
    int imgToDenoiseIndex,
    int temporalWindowSize,
    float h,
    int templateWindowSize,
    int searchWindowSize)
{
    return cvTry([&] {

    std::vector<cv::Mat> srcImgsVec(srcImgsLength);
    for (int i = 0; i < srcImgsLength; i++)
        srcImgsVec[i] = *srcImgs[i];

    cv::fastNlMeansDenoisingMulti(
        srcImgsVec, OutProxy(*dst), imgToDenoiseIndex, temporalWindowSize, h, templateWindowSize, searchWindowSize);

    });
}

CVAPI(ExceptionStatus) photo_fastNlMeansDenoisingColoredMulti(
    cv::Mat**srcImgs,
    int srcImgsLength,
    const interop::OutputArrayProxy* dst,
    int imgToDenoiseIndex,
    int temporalWindowSize,
    float h,
    float hColor,
    int templateWindowSize,
    int searchWindowSize)
{
    return cvTry([&] {

    std::vector<cv::Mat> srcImgsVec(srcImgsLength);
    for (int i = 0; i < srcImgsLength; i++)
        srcImgsVec[i] = *srcImgs[i];

    cv::fastNlMeansDenoisingColoredMulti(
        srcImgsVec, OutProxy(*dst), imgToDenoiseIndex, temporalWindowSize, h, hColor, templateWindowSize, searchWindowSize);

    });
}

CVAPI(ExceptionStatus) photo_denoise_TVL1(
    cv::Mat **observations,
    int observationsSize,
    cv::Mat *result,
    double lambda,
    int niters)
{
    return cvTry([&] {
    std::vector<cv::Mat> observationsVec(observationsSize);
    for (int i = 0; i < observationsSize; i++)
    {
        observationsVec[i] = *observations[i];
    }
    cv::denoise_TVL1(observationsVec, *result, lambda, niters);
    });
}



CVAPI(ExceptionStatus) photo_decolor(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* grayscale,
    const interop::OutputArrayProxy* color_boost)
{
    return cvTry([&] {
    cv::decolor(InProxy(*src), OutProxy(*grayscale), OutProxy(*color_boost));
    });
}

CVAPI(ExceptionStatus) photo_seamlessClone(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* dst,
    const interop::InputArrayProxy* mask,
    interop::Point p,
    const interop::OutputArrayProxy* blend,
    int flags)
{
    return cvTry([&] {
    cv::seamlessClone(InProxy(*src), InProxy(*dst), InProxy(*mask), cpp(p), OutProxy(*blend), flags);
    });
}

CVAPI(ExceptionStatus) photo_colorChange(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* mask,
    const interop::OutputArrayProxy* dst,
    float red_mul,
    float green_mul,
    float blue_mul)
{
    return cvTry([&] {
    cv::colorChange(InProxy(*src), InProxy(*mask), OutProxy(*dst), red_mul, green_mul, blue_mul);
    });
}

CVAPI(ExceptionStatus) photo_illuminationChange(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* mask,
    const interop::OutputArrayProxy* dst,
    float alpha,
    float beta = 0.4f)
{
    return cvTry([&] {
    cv::illuminationChange(InProxy(*src), InProxy(*mask), OutProxy(*dst), alpha, beta);
    });
}

CVAPI(ExceptionStatus) photo_textureFlattening(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* mask,
    const interop::OutputArrayProxy* dst,
    float low_threshold,
    float high_threshold,
    int kernel_size)
{
    return cvTry([&] {
    cv::textureFlattening(InProxy(*src), InProxy(*mask), OutProxy(*dst), low_threshold, high_threshold, kernel_size);
    });
}

CVAPI(ExceptionStatus) photo_edgePreservingFilter(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int flags,
    float sigma_s,
    float sigma_r)
{
    return cvTry([&] {
    cv::edgePreservingFilter(InProxy(*src), OutProxy(*dst), flags, sigma_s, sigma_r);
    });
}

CVAPI(ExceptionStatus) photo_detailEnhance(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    float sigma_s,
    float sigma_r)
{
    return cvTry([&] {
    cv::detailEnhance(InProxy(*src), OutProxy(*dst), sigma_s, sigma_r);
    });
}

CVAPI(ExceptionStatus) photo_pencilSketch(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst1,
    const interop::OutputArrayProxy* dst2,
    float sigma_s,
    float sigma_r,
    float shade_factor)
{
    return cvTry([&] {
    cv::pencilSketch(InProxy(*src), OutProxy(*dst1), OutProxy(*dst2), sigma_s, sigma_r, shade_factor);
    });
}

CVAPI(ExceptionStatus) photo_stylization(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    float sigma_s,
    float sigma_r)
{
    return cvTry([&] {
    cv::stylization(InProxy(*src), OutProxy(*dst), sigma_s, sigma_r);
    });
}

#endif // NO_PHOTO
