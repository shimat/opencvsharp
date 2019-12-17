#ifndef _CPP_PHOTO_H_
#define _CPP_PHOTO_H_

#include "include_opencv.h"


CVAPI(ExceptionStatus) photo_inpaint(cv::_InputArray *src, cv::_InputArray *inpaintMask,
    cv::_OutputArray *dst, double inpaintRadius, int flags)
{
    BEGIN_WRAP
    cv::inpaint(*src, *inpaintMask, *dst, inpaintRadius, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_fastNlMeansDenoising(cv::_InputArray *src, cv::_OutputArray *dst, float h,
    int templateWindowSize, int searchWindowSize)
{
    BEGIN_WRAP
    cv::fastNlMeansDenoising(*src, *dst, h, templateWindowSize, searchWindowSize);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_fastNlMeansDenoisingColored(cv::_InputArray *src, cv::_OutputArray *dst,
    float h, float hColor, int templateWindowSize, int searchWindowSize)
{
    BEGIN_WRAP
    cv::fastNlMeansDenoisingColored(*src, *dst, h, hColor, templateWindowSize, searchWindowSize);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_fastNlMeansDenoisingMulti(cv::_InputArray ** srcImgs, int srcImgsLength, 
    cv::_OutputArray *dst, int imgToDenoiseIndex, int temporalWindowSize,
    float h, int templateWindowSize, int searchWindowSize)
{
    BEGIN_WRAP
    std::vector<cv::_InputArray> srcImgsVec(srcImgsLength);
    for (int i = 0; i < srcImgsLength; i++)    
        srcImgsVec[i] = *srcImgs[i];
    cv::fastNlMeansDenoisingMulti(srcImgsVec, *dst, imgToDenoiseIndex, temporalWindowSize, h, templateWindowSize, searchWindowSize);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_fastNlMeansDenoisingColoredMulti(cv::_InputArray **srcImgs, int srcImgsLength, 
    cv::_OutputArray *dst, int imgToDenoiseIndex, int temporalWindowSize,
    float h, float hColor, int templateWindowSize, int searchWindowSize)
{
    BEGIN_WRAP
    std::vector<cv::_InputArray> srcImgsVec(srcImgsLength);
    for (int i = 0; i < srcImgsLength; i++)
        srcImgsVec[i] = *srcImgs[i];
    cv::fastNlMeansDenoisingColoredMulti(srcImgsVec, *dst, imgToDenoiseIndex, temporalWindowSize, h, hColor, templateWindowSize, searchWindowSize);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_denoise_TVL1(
    cv::Mat **observations, int observationsSize, cv::Mat *result, double lambda, int niters)
{
    BEGIN_WRAP
    std::vector<cv::Mat> observationsVec(observationsSize);
    for (int i = 0; i < observationsSize; i++)
    {
        observationsVec[i] = *observations[i];
    }
    cv::denoise_TVL1(observationsVec, *result, lambda, niters);
    END_WRAP
}



CVAPI(ExceptionStatus) photo_decolor(
    cv::_InputArray *src, cv::_OutputArray *grayscale, cv::_OutputArray *color_boost)
{
    BEGIN_WRAP
    cv::decolor(*src, *grayscale, *color_boost);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_seamlessClone(
    cv::_InputArray *src, cv::_InputArray *dst, cv::_InputArray *mask, MyCvPoint p,
    cv::_OutputArray *blend, int flags)
{
    BEGIN_WRAP
    cv::seamlessClone(*src, *dst, entity(mask), cpp(p), *blend, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_colorChange(
    cv::_InputArray *src, cv::_InputArray *mask, cv::_OutputArray *dst, float red_mul,
    float green_mul, float blue_mul)
{
    BEGIN_WRAP
    cv::colorChange(*src, entity(mask), *dst, red_mul, green_mul, blue_mul);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_illuminationChange(
    cv::_InputArray *src, cv::_InputArray *mask, cv::_OutputArray *dst,
    float alpha, float beta = 0.4f)
{
    BEGIN_WRAP
    cv::illuminationChange(*src, entity(mask), *dst, alpha, beta);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_textureFlattening(
    cv::_InputArray *src, cv::_InputArray *mask, cv::_OutputArray *dst,
    float low_threshold, float high_threshold, int kernel_size)
{
    BEGIN_WRAP
    cv::textureFlattening(*src, entity(mask), *dst, low_threshold, high_threshold, kernel_size);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_edgePreservingFilter(
    cv::_InputArray *src, cv::_OutputArray *dst, int flags,    float sigma_s, float sigma_r)
{
    BEGIN_WRAP
    cv::edgePreservingFilter(*src, *dst, flags, sigma_s, sigma_r);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_detailEnhance(
    cv::_InputArray *src, cv::_OutputArray *dst, float sigma_s,    float sigma_r)
{
    BEGIN_WRAP
    cv::detailEnhance(*src, *dst, sigma_s, sigma_r);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_pencilSketch(
    cv::_InputArray *src, cv::_OutputArray *dst1, cv::_OutputArray *dst2,
    float sigma_s, float sigma_r, float shade_factor)
{
    BEGIN_WRAP
    cv::pencilSketch(*src, *dst1, *dst2, sigma_s, sigma_r, shade_factor);
    END_WRAP
}

CVAPI(ExceptionStatus) photo_stylization(
    cv::_InputArray *src, cv::_OutputArray *dst, float sigma_s,    float sigma_r)
{
    BEGIN_WRAP
    cv::stylization(*src, *dst, sigma_s, sigma_r);
    END_WRAP
}

#endif