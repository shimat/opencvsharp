#pragma once

#ifndef NO_CONTRIB
#ifndef NO_STEREO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// DisparityFilter (base class methods, called via raw pointer obtained from DisparityWLSFilter's _get)

CVAPI(ExceptionStatus) ximgproc_DisparityFilter_filter(
    cv::ximgproc::DisparityFilter* obj,
    const interop::InputArrayProxy* disparityMapLeft,
    const interop::InputArrayProxy* leftView,
    const interop::OutputArrayProxy* filteredDisparityMap,
    const interop::InputArrayProxy* disparityMapRight,
    interop::Rect roi,
    const interop::InputArrayProxy* rightView)
{
    return cvTry([&] {
        obj->filter(InProxy(*disparityMapLeft), InProxy(*leftView), OutProxy(*filteredDisparityMap),
            InProxy(*disparityMapRight), cpp(roi), InProxy(*rightView));
    });
}

// DisparityWLSFilter

CVAPI(ExceptionStatus) ximgproc_Ptr_DisparityWLSFilter_delete(cv::Ptr<cv::ximgproc::DisparityWLSFilter>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_DisparityWLSFilter_get(cv::Ptr<cv::ximgproc::DisparityWLSFilter>* ptr, cv::ximgproc::DisparityWLSFilter** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_createDisparityWLSFilter(cv::Ptr<cv::StereoMatcher>* matcherLeft, cv::Ptr<cv::ximgproc::DisparityWLSFilter>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createDisparityWLSFilter(*matcherLeft);
        *returnValue = new cv::Ptr<cv::ximgproc::DisparityWLSFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_createDisparityWLSFilterGeneric(int useConfidence, cv::Ptr<cv::ximgproc::DisparityWLSFilter>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createDisparityWLSFilterGeneric(useConfidence != 0);
        *returnValue = new cv::Ptr<cv::ximgproc::DisparityWLSFilter>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_createRightMatcher(cv::Ptr<cv::StereoMatcher>* matcherLeft, cv::Ptr<cv::StereoMatcher>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ximgproc::createRightMatcher(*matcherLeft);
        *returnValue = new cv::Ptr<cv::StereoMatcher>(ptr);
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_getLambda(cv::ximgproc::DisparityWLSFilter* obj, double* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getLambda();
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_setLambda(cv::ximgproc::DisparityWLSFilter* obj, double lambda)
{
    return cvTry([&] {
        obj->setLambda(lambda);
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_getSigmaColor(cv::ximgproc::DisparityWLSFilter* obj, double* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSigmaColor();
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_setSigmaColor(cv::ximgproc::DisparityWLSFilter* obj, double sigmaColor)
{
    return cvTry([&] {
        obj->setSigmaColor(sigmaColor);
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_getLRCthresh(cv::ximgproc::DisparityWLSFilter* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getLRCthresh();
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_setLRCthresh(cv::ximgproc::DisparityWLSFilter* obj, int lrcThresh)
{
    return cvTry([&] {
        obj->setLRCthresh(lrcThresh);
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_getDepthDiscontinuityRadius(cv::ximgproc::DisparityWLSFilter* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDepthDiscontinuityRadius();
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_setDepthDiscontinuityRadius(cv::ximgproc::DisparityWLSFilter* obj, int discRadius)
{
    return cvTry([&] {
        obj->setDepthDiscontinuityRadius(discRadius);
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_getConfidenceMap(cv::ximgproc::DisparityWLSFilter* obj, cv::Mat** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getConfidenceMap());
    });
}

CVAPI(ExceptionStatus) ximgproc_DisparityWLSFilter_getROI(cv::ximgproc::DisparityWLSFilter* obj, interop::Rect* returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getROI());
    });
}

// Free functions

CVAPI(ExceptionStatus) ximgproc_readGT(const char* srcPath, const interop::OutputArrayProxy* dst, int* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::ximgproc::readGT(cv::String(srcPath), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) ximgproc_computeMSE(
    const interop::InputArrayProxy* gt, const interop::InputArrayProxy* src, interop::Rect roi, double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::ximgproc::computeMSE(InProxy(*gt), InProxy(*src), cpp(roi));
    });
}

CVAPI(ExceptionStatus) ximgproc_computeBadPixelPercent(
    const interop::InputArrayProxy* gt, const interop::InputArrayProxy* src, interop::Rect roi, int thresh, double* returnValue)
{
    return cvTry([&] {
        *returnValue = cv::ximgproc::computeBadPixelPercent(InProxy(*gt), InProxy(*src), cpp(roi), thresh);
    });
}

CVAPI(ExceptionStatus) ximgproc_getDisparityVis(
    const interop::InputArrayProxy* src, const interop::OutputArrayProxy* dst, double scale)
{
    return cvTry([&] {
        cv::ximgproc::getDisparityVis(InProxy(*src), OutProxy(*dst), scale);
    });
}

#endif // NO_STEREO
#endif // NO_CONTRIB
