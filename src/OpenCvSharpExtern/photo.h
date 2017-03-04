#ifndef _CPP_PHOTO_H_
#define _CPP_PHOTO_H_

#include "include_opencv.h"


CVAPI(void) photo_inpaint(cv::_InputArray *src, cv::_InputArray *inpaintMask,
    cv::_OutputArray *dst, double inpaintRadius, int flags)
{
    cv::inpaint(*src, *inpaintMask, *dst, inpaintRadius, flags); 
}

CVAPI(void) photo_fastNlMeansDenoising(cv::_InputArray *src, cv::_OutputArray *dst, float h,
    int templateWindowSize, int searchWindowSize)
{
    cv::fastNlMeansDenoising(*src, *dst, h, templateWindowSize, searchWindowSize);
}

CVAPI(void) photo_fastNlMeansDenoisingColored(cv::_InputArray *src, cv::_OutputArray *dst,
    float h, float hColor, int templateWindowSize, int searchWindowSize)
{
    cv::fastNlMeansDenoisingColored(*src, *dst, h, hColor, templateWindowSize, searchWindowSize);
}

CVAPI(void) photo_fastNlMeansDenoisingMulti(cv::_InputArray ** srcImgs, int srcImgsLength, 
    cv::_OutputArray *dst, int imgToDenoiseIndex, int temporalWindowSize,
    float h, int templateWindowSize, int searchWindowSize)
{
    std::vector<cv::_InputArray> srcImgsVec(srcImgsLength);
    for (int i = 0; i < srcImgsLength; i++)    
        srcImgsVec[i] = *srcImgs[i];
    cv::fastNlMeansDenoisingMulti(srcImgsVec, *dst, imgToDenoiseIndex, temporalWindowSize, h, templateWindowSize, searchWindowSize);
}

CVAPI(void) photo_fastNlMeansDenoisingColoredMulti(cv::_InputArray **srcImgs, int srcImgsLength, 
    cv::_OutputArray *dst, int imgToDenoiseIndex, int temporalWindowSize,
    float h, float hColor, int templateWindowSize, int searchWindowSize)
{
    std::vector<cv::_InputArray> srcImgsVec(srcImgsLength);
    for (int i = 0; i < srcImgsLength; i++)
        srcImgsVec[i] = *srcImgs[i];
    cv::fastNlMeansDenoisingColoredMulti(srcImgsVec, *dst, imgToDenoiseIndex, temporalWindowSize, h, hColor, templateWindowSize, searchWindowSize);
}

CVAPI(void) photo_denoise_TVL1(
    cv::Mat **observations, int observationsSize, cv::Mat *result, double lambda, int niters)
{
    std::vector<cv::Mat> observationsVec(observationsSize);
    for (int i = 0; i < observationsSize; i++)
    {
        observationsVec[i] = *observations[i];
    }
    cv::denoise_TVL1(observationsVec, *result, lambda, niters);
}



CVAPI(void) photo_decolor(
    cv::_InputArray *src, cv::_OutputArray *grayscale, cv::_OutputArray *color_boost)
{
    cv::decolor(*src, *grayscale, *color_boost);
}

CVAPI(void) photo_seamlessClone(
    cv::_InputArray *src, cv::_InputArray *dst, cv::_InputArray *mask, MyCvPoint p,
    cv::_OutputArray *blend, int flags)
{
    cv::seamlessClone(*src, *dst, entity(mask), cpp(p), *blend, flags);
}

CVAPI(void) photo_colorChange(
    cv::_InputArray *src, cv::_InputArray *mask, cv::_OutputArray *dst, float red_mul,
    float green_mul, float blue_mul)
{
    cv::colorChange(*src, entity(mask), *dst, red_mul, green_mul, blue_mul);
}

CVAPI(void) photo_illuminationChange(
    cv::_InputArray *src, cv::_InputArray *mask, cv::_OutputArray *dst,
    float alpha, float beta = 0.4f)
{
    cv::illuminationChange(*src, entity(mask), *dst, alpha, beta);
}

CVAPI(void) photo_textureFlattening(
    cv::_InputArray *src, cv::_InputArray *mask, cv::_OutputArray *dst,
    float low_threshold, float high_threshold, int kernel_size)
{
    cv::textureFlattening(*src, entity(mask), *dst, low_threshold, high_threshold, kernel_size);
}

CVAPI(void) photo_edgePreservingFilter(
    cv::_InputArray *src, cv::_OutputArray *dst, int flags,    float sigma_s, float sigma_r)
{
    cv::edgePreservingFilter(*src, *dst, flags, sigma_s, sigma_r);
}

CVAPI(void) photo_detailEnhance(
    cv::_InputArray *src, cv::_OutputArray *dst, float sigma_s,    float sigma_r)
{
    cv::detailEnhance(*src, *dst, sigma_s, sigma_r);
}

CVAPI(void) photo_pencilSketch(
    cv::_InputArray *src, cv::_OutputArray *dst1, cv::_OutputArray *dst2,
    float sigma_s, float sigma_r, float shade_factor)
{
    cv::pencilSketch(*src, *dst1, *dst2, sigma_s, sigma_r, shade_factor);
}

CVAPI(void) photo_stylization(
    cv::_InputArray *src, cv::_OutputArray *dst, float sigma_s,    float sigma_r)
{
    cv::stylization(*src, *dst, sigma_s, sigma_r);
}

#endif