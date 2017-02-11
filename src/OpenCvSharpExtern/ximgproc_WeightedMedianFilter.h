#ifndef _CPP_XIMGPROC_WEIGHTEDMEDIANFILTER_H_
#define _CPP_XIMGPROC_WEIGHTEDMEDIANFILTER_H_

#include "include_opencv.h"

CVAPI(void) ximgproc_weightedMedianFilter(
    cv::_InputArray *joint, cv::_InputArray *src, cv::_OutputArray *dst, 
    int r, double sigma, int weightType, cv::Mat *mask)
{
    cv::ximgproc::weightedMedianFilter(*joint, *src, *dst, r, sigma, 
        static_cast<cv::ximgproc::WMFWeightType>(weightType), entity(mask));
}

#endif