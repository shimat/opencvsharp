#ifndef _CPP_XIMGPROC_H_
#define _CPP_XIMGPROC_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ximgproc_niBlackThreshold(cv::_InputArray *src, cv::_OutputArray *dst,
    double maxValue, int type,
    int blockSize, double k, int binarizationMethod, double r)
{
    BEGIN_WRAP
    cv::ximgproc::niBlackThreshold(*src, *dst, maxValue, type, blockSize, k, binarizationMethod, r);
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

// brightedges.hpp

CVAPI(ExceptionStatus) ximgproc_BrightEdges(cv::Mat *original, cv::Mat *edgeview, int contrast, int shortrange, int longrange)
{
    BEGIN_WRAP
    cv::ximgproc::BrightEdges(*original, *edgeview, contrast, shortrange, longrange);
    END_WRAP
}

// color_match.hpp

CVAPI(ExceptionStatus) ximgproc_createQuaternionImage(cv::_InputArray *img, cv::_OutputArray *qimg)
{
    BEGIN_WRAP
    cv::ximgproc::createQuaternionImage(*img, *qimg);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_qconj(cv::_InputArray *qimg, cv::_OutputArray *qcimg)
{
    BEGIN_WRAP
    cv::ximgproc::qconj(*qimg, *qcimg);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_qunitary(cv::_InputArray *qimg, cv::_OutputArray *qnimg)
{
    BEGIN_WRAP
    cv::ximgproc::qunitary(*qimg, *qnimg);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_qmultiply(cv::_InputArray *src1, cv::_InputArray *src2, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    cv::ximgproc::qmultiply(*src1, *src2, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_qdft(cv::_InputArray *img, cv::_OutputArray *qimg, int flags, int sideLeft)
{
    BEGIN_WRAP
    cv::ximgproc::qdft(*img, *qimg, flags, sideLeft != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_colorMatchTemplate(cv::_InputArray *img, cv::_InputArray *templ, cv::_OutputArray *result)
{
    BEGIN_WRAP
    cv::ximgproc::colorMatchTemplate(*img, *templ, *result);
    END_WRAP
}

// deriche_filter.hpp

CVAPI(ExceptionStatus) ximgproc_GradientDericheY(cv::_InputArray *op, cv::_OutputArray *dst, double alpha, double omega)
{
    BEGIN_WRAP
    cv::ximgproc::GradientDericheY(*op, *dst, alpha, omega);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_GradientDericheX(cv::_InputArray *op, cv::_OutputArray *dst, double alpha, double omega)
{
    BEGIN_WRAP
    cv::ximgproc::GradientDericheX(*op, *dst, alpha, omega);
    END_WRAP
}

// edgepreserving_filter.hpp

CVAPI(ExceptionStatus) ximgproc_edgePreservingFilter(cv::_InputArray *src, cv::_OutputArray *dst, int d, double threshold)
{
    BEGIN_WRAP
    cv::ximgproc::edgePreservingFilter(*src, *dst, d, threshold);
    END_WRAP
}

// estimated_covariance.hpp

CVAPI(ExceptionStatus) ximgproc_covarianceEstimation(
    cv::_InputArray *src, cv::_OutputArray *dst, int windowRows, int windowCols)
{
    BEGIN_WRAP
    cv::ximgproc::covarianceEstimation(*src, *dst, windowRows, windowCols);
    END_WRAP
}

// fast_hough_transform.hpp

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

// paillou_filter.hpp

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

// peilin.hpp

CVAPI(ExceptionStatus) ximgproc_PeiLinNormalization_Mat23d(cv::_InputArray *I, double *returnValue)
{
    BEGIN_WRAP
    auto ret = cv::ximgproc::PeiLinNormalization(*I);
    for (int r = 0; r < 2; r++)
    {
        for (int c = 0; c < 3; ++c)
        {
            returnValue[r * 3 + c] = ret(r, c);
        }
    }
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_PeiLinNormalization_OutputArray(cv::_InputArray *I, cv::_OutputArray *T)
{
    BEGIN_WRAP
    cv::ximgproc::PeiLinNormalization(*I, *T);
    END_WRAP
}

// weighted_median_filter.hpp

CVAPI(ExceptionStatus) ximgproc_weightedMedianFilter(
    cv::_InputArray* joint, cv::_InputArray* src, cv::_OutputArray* dst,
    int r, double sigma, int weightType, cv::Mat* mask)
{
    BEGIN_WRAP
    cv::ximgproc::weightedMedianFilter(*joint, *src, *dst, r, sigma,
        static_cast<cv::ximgproc::WMFWeightType>(weightType), entity(mask));
    END_WRAP
}

#endif