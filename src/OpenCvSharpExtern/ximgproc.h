#pragma once

// OpenCV 5: kept available in every profile (including slim); see include_opencv.h.

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ximgproc_niBlackThreshold(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    double maxValue,
    int type,
    int blockSize,
    double k,
    int binarizationMethod,
    double r)
{
    return cvTry([&] {
        cv::ximgproc::niBlackThreshold(InProxy(*src), OutProxy(*dst), maxValue, type, blockSize, k, binarizationMethod, r);
    });
}

CVAPI(ExceptionStatus) ximgproc_thinning(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int thinningType)
{
    return cvTry([&] {
        cv::ximgproc::thinning(InProxy(*src), OutProxy(*dst), thinningType);
    });
}

CVAPI(ExceptionStatus) ximgproc_anisotropicDiffusion(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    float alpha,
    float K,
    int niters)
{
    return cvTry([&] {
        cv::ximgproc::anisotropicDiffusion(InProxy(*src), OutProxy(*dst), alpha, K, niters);
    });
}

// brightedges.hpp

CVAPI(ExceptionStatus) ximgproc_BrightEdges(
    cv::Mat *original,
    cv::Mat *edgeview,
    int contrast,
    int shortrange,
    int longrange)
{
    return cvTry([&] {
        cv::ximgproc::BrightEdges(*original, *edgeview, contrast, shortrange, longrange);
    });
}

// color_match.hpp

CVAPI(ExceptionStatus) ximgproc_createQuaternionImage(const interop::InputArrayProxy* img, const interop::OutputArrayProxy* qimg)
{
    return cvTry([&] {
        cv::ximgproc::createQuaternionImage(InProxy(*img), OutProxy(*qimg));
    });
}

CVAPI(ExceptionStatus) ximgproc_qconj(const interop::InputArrayProxy* qimg, const interop::OutputArrayProxy* qcimg)
{
    return cvTry([&] {
        cv::ximgproc::qconj(InProxy(*qimg), OutProxy(*qcimg));
    });
}

CVAPI(ExceptionStatus) ximgproc_qunitary(const interop::InputArrayProxy* qimg, const interop::OutputArrayProxy* qnimg)
{
    return cvTry([&] {
        cv::ximgproc::qunitary(InProxy(*qimg), OutProxy(*qnimg));
    });
}

CVAPI(ExceptionStatus) ximgproc_qmultiply(
    const interop::InputArrayProxy* src1,
    const interop::InputArrayProxy* src2,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        cv::ximgproc::qmultiply(InProxy(*src1), InProxy(*src2), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) ximgproc_qdft(
    const interop::InputArrayProxy* img,
    const interop::OutputArrayProxy* qimg,
    int flags,
    int sideLeft)
{
    return cvTry([&] {
        cv::ximgproc::qdft(InProxy(*img), OutProxy(*qimg), flags, sideLeft != 0);
    });
}

CVAPI(ExceptionStatus) ximgproc_colorMatchTemplate(
    const interop::InputArrayProxy* img,
    const interop::InputArrayProxy* templ,
    const interop::OutputArrayProxy* result)
{
    return cvTry([&] {
        cv::ximgproc::colorMatchTemplate(InProxy(*img), InProxy(*templ), OutProxy(*result));
    });
}

// deriche_filter.hpp

CVAPI(ExceptionStatus) ximgproc_GradientDericheY(
    const interop::InputArrayProxy* op,
    const interop::OutputArrayProxy* dst,
    double alpha,
    double omega)
{
    return cvTry([&] {
        cv::ximgproc::GradientDericheY(InProxy(*op), OutProxy(*dst), alpha, omega);
    });
}

CVAPI(ExceptionStatus) ximgproc_GradientDericheX(
    const interop::InputArrayProxy* op,
    const interop::OutputArrayProxy* dst,
    double alpha,
    double omega)
{
    return cvTry([&] {
        cv::ximgproc::GradientDericheX(InProxy(*op), OutProxy(*dst), alpha, omega);
    });
}

// edgepreserving_filter.hpp

CVAPI(ExceptionStatus) ximgproc_edgePreservingFilter(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int d,
    double threshold)
{
    return cvTry([&] {
        cv::ximgproc::edgePreservingFilter(InProxy(*src), OutProxy(*dst), d, threshold);
    });
}

// estimated_covariance.hpp

CVAPI(ExceptionStatus) ximgproc_covarianceEstimation(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int windowRows,
    int windowCols)
{
    return cvTry([&] {
        cv::ximgproc::covarianceEstimation(InProxy(*src), OutProxy(*dst), windowRows, windowCols);
    });
}

// fast_hough_transform.hpp

CVAPI(ExceptionStatus) ximgproc_FastHoughTransform(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int dstMatDepth,
    int angleRange,
    int op,
    int makeSkew)
{
    return cvTry([&] {
        cv::ximgproc::FastHoughTransform(InProxy(*src), OutProxy(*dst), dstMatDepth, angleRange, op, makeSkew);
    });
}

CVAPI(ExceptionStatus) ximgproc_HoughPoint2Line(
    interop::Point houghPoint,
    const interop::InputArrayProxy* srcImgInfo,
    int angleRange,
    int makeSkew,
    int rules,
    interop::Vec4i* returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::ximgproc::HoughPoint2Line(cpp(houghPoint), InProxy(*srcImgInfo), angleRange, makeSkew, rules));
    });
}

// paillou_filter.hpp

CVAPI(ExceptionStatus) ximgproc_GradientPaillouY(
    const interop::InputArrayProxy* op,
    const interop::OutputArrayProxy* dst,
    double alpha,
    double omega)
{
    return cvTry([&] {
        cv::ximgproc::GradientPaillouY(InProxy(*op), OutProxy(*dst), alpha, omega);
    });
}

CVAPI(ExceptionStatus) ximgproc_GradientPaillouX(
    const interop::InputArrayProxy* op,
    const interop::OutputArrayProxy* dst,
    double alpha,
    double omega)
{
    return cvTry([&] {
        cv::ximgproc::GradientPaillouX(InProxy(*op), OutProxy(*dst), alpha, omega);
    });
}

// peilin.hpp

CVAPI(ExceptionStatus) ximgproc_PeiLinNormalization_Mat23d(const interop::InputArrayProxy* I, double *returnValue)
{
    return cvTry([&] {
        auto ret = cv::ximgproc::PeiLinNormalization(InProxy(*I));
        for (int r = 0; r < 2; r++)
        {
            for (int c = 0; c < 3; ++c)
            {
                returnValue[r * 3 + c] = ret(r, c);
            }
        }
    });
}

CVAPI(ExceptionStatus) ximgproc_PeiLinNormalization_OutputArray(const interop::InputArrayProxy* I, const interop::OutputArrayProxy* T)
{
    return cvTry([&] {
        cv::ximgproc::PeiLinNormalization(InProxy(*I), OutProxy(*T));
    });
}

// run_length_morphology.hpp

CVAPI(ExceptionStatus) ximgproc_rl_threshold(
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* rlDest,
    double thresh,
    int type)
{
    return cvTry([&] {
        cv::ximgproc::rl::threshold(InProxy(*src), OutProxy(*rlDest), thresh, type);
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_dilate(
    const interop::InputArrayProxy* rlSrc,
    const interop::OutputArrayProxy* rlDest,
    const interop::InputArrayProxy* rlKernel,
    interop::Point anchor)
{
    return cvTry([&] {
        cv::ximgproc::rl::dilate(InProxy(*rlSrc), OutProxy(*rlDest), InProxy(*rlKernel), cpp(anchor));
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_erode(
    const interop::InputArrayProxy* rlSrc,
    const interop::OutputArrayProxy* rlDest,
    const interop::InputArrayProxy* rlKernel,
    int bBoundaryOn,
    interop::Point anchor)
{
    return cvTry([&] {
        cv::ximgproc::rl::erode(InProxy(*rlSrc), OutProxy(*rlDest), InProxy(*rlKernel), bBoundaryOn != 0, cpp(anchor));
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_getStructuringElement(
    int shape,
    interop::Size ksize,
    cv::Mat *outValue)
{
    return cvTry([&] {
        auto result = cv::ximgproc::rl::getStructuringElement(shape, cpp(ksize));
        result.copyTo(*outValue);
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_paint(
    const interop::InputOutputArrayProxy* image,
    const interop::InputArrayProxy* rlSrc,
    interop::Scalar value)
{
    return cvTry([&] {
        cv::ximgproc::rl::paint(IoProxy(*image), InProxy(*rlSrc), cpp(value));
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_isRLMorphologyPossible(const interop::InputArrayProxy* rlStructuringElement, int *outValue)
{
    return cvTry([&] {
        *outValue = cv::ximgproc::rl::isRLMorphologyPossible(InProxy(*rlStructuringElement)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_createRLEImage(
    interop::Point3i *runs,
    size_t runsLength,
    const interop::OutputArrayProxy* res,
    interop::Size size)
{
    return cvTry([&] {
        std::vector<cv::Point3i> runsVec(runsLength);
        for (size_t i = 0; i < runsLength; i++)
        {
            runsVec[i] = cpp(runs[i]);
        }
        cv::ximgproc::rl::createRLEImage(runsVec, OutProxy(*res), cpp(size));
    });
}

CVAPI(ExceptionStatus) ximgproc_rl_morphologyEx(
    const interop::InputArrayProxy* rlSrc,
    const interop::OutputArrayProxy* rlDest,
    int op,
    const interop::InputArrayProxy* rlKernel,
    int bBoundaryOnForErosion,
    interop::Point anchor)
{
    return cvTry([&] {
        cv::ximgproc::rl::morphologyEx(InProxy(*rlSrc), OutProxy(*rlDest), op, InProxy(*rlKernel), bBoundaryOnForErosion != 0, cpp(anchor));
    });
}

// weighted_median_filter.hpp

CVAPI(ExceptionStatus) ximgproc_weightedMedianFilter(
    const interop::InputArrayProxy* joint,
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst,
    int r,
    double sigma,
    int weightType,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
        cv::ximgproc::weightedMedianFilter(InProxy(*joint), InProxy(*src), OutProxy(*dst), r, sigma,
            static_cast<cv::ximgproc::WMFWeightType>(weightType), InProxy(*mask));
    });
}

// (no NO_CONTRIB guard: kept in every profile for OpenCV 5)
