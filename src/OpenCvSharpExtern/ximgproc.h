#ifndef _CPP_XIMGPROC_H_
#define _CPP_XIMGPROC_H_

#include "include_opencv.h"

CVAPI(void) ximgproc_niBlackThreshold(cv::_InputArray *src, cv::_OutputArray *dst,
    double maxValue, int type,
    int blockSize, double delta)
{
    cv::ximgproc::niBlackThreshold(*src, *dst, maxValue, type, blockSize, delta);
}

CVAPI(void) ximgproc_thinning(cv::_InputArray *src, cv::_OutputArray *dst, int thinningType)
{
    cv::ximgproc::thinning(*src, *dst, thinningType);
}

CVAPI(void) ximgproc_weightedMedianFilter(
    cv::_InputArray *joint, cv::_InputArray *src, cv::_OutputArray *dst,
    int r, double sigma, int weightType, cv::Mat *mask)
{
    cv::ximgproc::weightedMedianFilter(*joint, *src, *dst, r, sigma,
        static_cast<cv::ximgproc::WMFWeightType>(weightType), entity(mask));
}

CVAPI(void) ximgproc_covarianceEstimation(
    cv::_InputArray *src, cv::_OutputArray *dst, int windowRows, int windowCols)
{
    cv::ximgproc::covarianceEstimation(*src, *dst, windowRows, windowCols);
}

#endif