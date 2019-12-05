#ifndef _CPP_XIMGPROC_H_
#define _CPP_XIMGPROC_H_

#include "include_opencv.h"

CVAPI(ExceptionStatus) ximgproc_niBlackThreshold(cv::_InputArray *src, cv::_OutputArray *dst,
    double maxValue, int type,
    int blockSize, double k, int binarizationMethod)
{
    BEGIN_WRAP
    cv::ximgproc::niBlackThreshold(*src, *dst, maxValue, type, blockSize, k, binarizationMethod);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_thinning(cv::_InputArray *src, cv::_OutputArray *dst, int thinningType)
{
    BEGIN_WRAP
    cv::ximgproc::thinning(*src, *dst, thinningType);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_anisotropicDiffusion(cv::_InputArray *src, cv::_OutputArray *dst, float alpha, float K, int niters)
{
    BEGIN_WRAP
    cv::ximgproc::anisotropicDiffusion(*src, *dst, alpha, K, niters);
    END_WRAP
}

// weighted_median_filter

CVAPI(ExceptionStatus) ximgproc_weightedMedianFilter(
    cv::_InputArray *joint, cv::_InputArray *src, cv::_OutputArray *dst,
    int r, double sigma, int weightType, cv::Mat *mask)
{
    BEGIN_WRAP
    cv::ximgproc::weightedMedianFilter(*joint, *src, *dst, r, sigma,
        static_cast<cv::ximgproc::WMFWeightType>(weightType), entity(mask));
    END_WRAP
}

// estimated_covariance

CVAPI(ExceptionStatus) ximgproc_covarianceEstimation(
    cv::_InputArray *src, cv::_OutputArray *dst, int windowRows, int windowCols)
{
    BEGIN_WRAP
    cv::ximgproc::covarianceEstimation(*src, *dst, windowRows, windowCols);
    END_WRAP
}

// paillou_filter

CVAPI(ExceptionStatus) ximgproc_GradientPaillouY(cv::_InputArray* op, cv::_OutputArray* dst, double alpha, double omega)
{
    BEGIN_WRAP
    cv::ximgproc::GradientPaillouY(*op, *dst, alpha, omega);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_GradientPaillouX(cv::_InputArray* op, cv::_OutputArray* dst, double alpha, double omega)
{
    BEGIN_WRAP
    cv::ximgproc::GradientPaillouX(*op, *dst, alpha, omega);
    END_WRAP
}

// fast_hough_transform

CVAPI(ExceptionStatus) ximgproc_FastHoughTransform(
    cv::_InputArray* src, cv::_OutputArray* dst,
    int dstMatDepth, int angleRange, int op, int makeSkew)
{
    BEGIN_WRAP
    cv::ximgproc::FastHoughTransform(*src, *dst, dstMatDepth, angleRange, op, makeSkew);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_HoughPoint2Line(MyCvPoint houghPoint, cv::_InputArray* srcImgInfo,
    int angleRange, int makeSkew, int rules, CvVec4i* returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::ximgproc::HoughPoint2Line(cpp(houghPoint), *srcImgInfo, angleRange, makeSkew, rules));
    END_WRAP
}

#endif