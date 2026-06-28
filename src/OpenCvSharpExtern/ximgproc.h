#pragma once

// OpenCV 5: kept available in every profile (including slim); see include_opencv.h.

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ximgproc_niBlackThreshold(cv::_InputArray *src, cv::_OutputArray *dst,
    double maxValue, int type,
    int blockSize, double k, int binarizationMethod, double r)
{
    return cvTry([&] {
    cv::ximgproc::niBlackThreshold(*src, *dst, maxValue, type, blockSize, k, binarizationMethod, r);
    });
}

CVAPI(ExceptionStatus) ximgproc_thinning(cv::_InputArray *src, cv::_OutputArray *dst, int thinningType)
{
    return cvTry([&] {
    cv::ximgproc::thinning(*src, *dst, thinningType);
    });
}

CVAPI(ExceptionStatus) ximgproc_anisotropicDiffusion(cv::_InputArray *src, cv::_OutputArray *dst, float alpha, float K, int niters)
{
    return cvTry([&] {
    cv::ximgproc::anisotropicDiffusion(*src, *dst, alpha, K, niters);
    });
}

// brightedges.hpp

CVAPI(ExceptionStatus) ximgproc_BrightEdges(cv::Mat *original, cv::Mat *edgeview, int contrast, int shortrange, int longrange)
{
    return cvTry([&] {
    cv::ximgproc::BrightEdges(*original, *edgeview, contrast, shortrange, longrange);
    });
}

// color_match.hpp

CVAPI(ExceptionStatus) ximgproc_createQuaternionImage(cv::_InputArray *img, cv::_OutputArray *qimg)
{
    return cvTry([&] {
    cv::ximgproc::createQuaternionImage(*img, *qimg);
    });
}

CVAPI(ExceptionStatus) ximgproc_qconj(cv::_InputArray *qimg, cv::_OutputArray *qcimg)
{
    return cvTry([&] {
    cv::ximgproc::qconj(*qimg, *qcimg);
    });
}

CVAPI(ExceptionStatus) ximgproc_qunitary(cv::_InputArray *qimg, cv::_OutputArray *qnimg)
{
    return cvTry([&] {
    cv::ximgproc::qunitary(*qimg, *qnimg);
    });
}

CVAPI(ExceptionStatus) ximgproc_qmultiply(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    return cvTry([&] {
    cv::ximgproc::qmultiply(*src1, *src2, *dst);
    });
}

CVAPI(ExceptionStatus) ximgproc_qdft(cv::_InputArray *img, cv::_OutputArray *qimg, int flags, int sideLeft)
{
    return cvTry([&] {
    cv::ximgproc::qdft(*img, *qimg, flags, sideLeft != 0);
    });
}

CVAPI(ExceptionStatus) ximgproc_colorMatchTemplate(cv::_InputArray *img, cv::_InputArray *templ, cv::_OutputArray *result)
{
    return cvTry([&] {
    cv::ximgproc::colorMatchTemplate(*img, *templ, *result);
    });
}

// deriche_filter.hpp

CVAPI(ExceptionStatus) ximgproc_GradientDericheY(cv::_InputArray *op, cv::_OutputArray *dst, double alpha, double omega)
{
    return cvTry([&] {
    cv::ximgproc::GradientDericheY(*op, *dst, alpha, omega);
    });
}

CVAPI(ExceptionStatus) ximgproc_GradientDericheX(cv::_InputArray *op, cv::_OutputArray *dst, double alpha, double omega)
{
    return cvTry([&] {
    cv::ximgproc::GradientDericheX(*op, *dst, alpha, omega);
    });
}

// edgepreserving_filter.hpp

CVAPI(ExceptionStatus) ximgproc_edgePreservingFilter(cv::_InputArray *src, cv::_OutputArray *dst, int d, double threshold)
{
    return cvTry([&] {
    cv::ximgproc::edgePreservingFilter(*src, *dst, d, threshold);
    });
}

// estimated_covariance.hpp

CVAPI(ExceptionStatus) ximgproc_covarianceEstimation(
    cv::_InputArray *src, cv::_OutputArray *dst, int windowRows, int windowCols)
{
    return cvTry([&] {
    cv::ximgproc::covarianceEstimation(*src, *dst, windowRows, windowCols);
    });
}

// fast_hough_transform.hpp

CVAPI(ExceptionStatus) ximgproc_FastHoughTransform(
    cv::_InputArray* src, cv::_OutputArray* dst,
    int dstMatDepth, int angleRange, int op, int makeSkew)
{
    return cvTry([&] {
    cv::ximgproc::FastHoughTransform(*src, *dst, dstMatDepth, angleRange, op, makeSkew);
    });
}

CVAPI(ExceptionStatus) ximgproc_HoughPoint2Line(interop::Point houghPoint, cv::_InputArray* srcImgInfo,
    int angleRange, int makeSkew, int rules, interop::Vec4i* returnValue)
{
    return cvTry([&] {
    *returnValue = c(cv::ximgproc::HoughPoint2Line(cpp(houghPoint), *srcImgInfo, angleRange, makeSkew, rules));
    });
}

// paillou_filter.hpp

CVAPI(ExceptionStatus) ximgproc_GradientPaillouY(cv::_InputArray* op, cv::_OutputArray* dst, double alpha, double omega)
{
    return cvTry([&] {
    cv::ximgproc::GradientPaillouY(*op, *dst, alpha, omega);
    });
}

CVAPI(ExceptionStatus) ximgproc_GradientPaillouX(cv::_InputArray* op, cv::_OutputArray* dst, double alpha, double omega)
{
    return cvTry([&] {
    cv::ximgproc::GradientPaillouX(*op, *dst, alpha, omega);
    });
}

// peilin.hpp

CVAPI(ExceptionStatus) ximgproc_PeiLinNormalization_Mat23d(cv::_InputArray *I, double *returnValue)
{
    return cvTry([&] {
    auto ret = cv::ximgproc::PeiLinNormalization(*I);
    for (int r = 0; r < 2; r++)
    {
        for (int c = 0; c < 3; ++c)
        {
            returnValue[r * 3 + c] = ret(r, c);
        }
    }
    });
}

CVAPI(ExceptionStatus) ximgproc_PeiLinNormalization_OutputArray(cv::_InputArray *I, cv::_OutputArray *T)
{
    return cvTry([&] {
    cv::ximgproc::PeiLinNormalization(*I, *T);
    });
}

// run_length_morphology.hpp

CVAPI(ExceptionStatus) ximgproc_rl_threshold(cv::_InputArray *src, cv::_OutputArray *rlDest, double thresh, int type)
{
    return cvTry([&] {
    cv::ximgproc::rl::threshold(*src, *rlDest, thresh, type);
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_dilate(
    cv::_InputArray *rlSrc, cv::_OutputArray *rlDest, cv::_InputArray *rlKernel, interop::Point anchor)
{
    return cvTry([&] {
    cv::ximgproc::rl::dilate(*rlSrc, *rlDest, *rlKernel, cpp(anchor));
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_erode(
    cv::_InputArray *rlSrc, cv::_OutputArray *rlDest, cv::_InputArray *rlKernel,
    int bBoundaryOn, interop::Point anchor)
{
    return cvTry([&] {
    cv::ximgproc::rl::erode(*rlSrc, *rlDest, *rlKernel, bBoundaryOn != 0, cpp(anchor));
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_getStructuringElement(int shape, interop::Size ksize, cv::Mat *outValue)
{
    return cvTry([&] {
    auto result = cv::ximgproc::rl::getStructuringElement(shape, cpp(ksize));
    result.copyTo(*outValue);
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_paint(cv::_InputOutputArray *image, cv::_InputArray *rlSrc, interop::Scalar value)
{
    return cvTry([&] {
    cv::ximgproc::rl::paint(*image, *rlSrc, cpp(value));
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_isRLMorphologyPossible(cv::_InputArray *rlStructuringElement, int *outValue)
{
    return cvTry([&] {
    *outValue = cv::ximgproc::rl::isRLMorphologyPossible(*rlStructuringElement) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_createRLEImage(interop::Point3i *runs, size_t runsLength, cv::_OutputArray *res, interop::Size size)
{
    return cvTry([&] {
    std::vector<cv::Point3i> runsVec(runsLength);
    for (size_t i = 0; i < runsLength; i++)
    {
        runsVec[i] = cpp(runs[i]);
    }
    cv::ximgproc::rl::createRLEImage(runsVec, *res, cpp(size));
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_morphologyEx(
    cv::_InputArray *rlSrc, cv::_OutputArray *rlDest, int op, cv::_InputArray *rlKernel,
    int bBoundaryOnForErosion, interop::Point anchor)
{
    return cvTry([&] {
    cv::ximgproc::rl::morphologyEx(*rlSrc, *rlDest, op, *rlKernel, bBoundaryOnForErosion != 0, cpp(anchor));
    });
}

// weighted_median_filter.hpp

CVAPI(ExceptionStatus) ximgproc_weightedMedianFilter(
    cv::_InputArray* joint, cv::_InputArray* src, cv::_OutputArray* dst,
    int r, double sigma, int weightType, cv::Mat* mask)
{
    return cvTry([&] {
    cv::ximgproc::weightedMedianFilter(*joint, *src, *dst, r, sigma,
        static_cast<cv::ximgproc::WMFWeightType>(weightType), entity(mask));
    });
}

// (no NO_CONTRIB guard: kept in every profile for OpenCV 5)
