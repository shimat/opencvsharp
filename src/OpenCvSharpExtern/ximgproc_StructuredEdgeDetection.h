#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// RFFeatureGetter

CVAPI(ExceptionStatus) ximgproc_createRFFeatureGetter(cv::Ptr<cv::ximgproc::RFFeatureGetter> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::ximgproc::createRFFeatureGetter());
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_RFFeatureGetter_delete(cv::Ptr<cv::ximgproc::RFFeatureGetter> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_RFFeatureGetter_get(cv::Ptr<cv::ximgproc::RFFeatureGetter> *ptr, cv::ximgproc::RFFeatureGetter **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_RFFeatureGetter_getFeatures(
    cv::ximgproc::RFFeatureGetter *obj,
    cv::Mat *src,
    cv::Mat *features,
    const int gnrmRad,
    const int gsmthRad,
    const int shrink,
    const int outNum,
    const int gradNum)
{
    return cvTry([&] {
        obj->getFeatures(*src, *features, gnrmRad, gsmthRad, shrink, outNum, gradNum);
    });
}


// StructuredEdgeDetection

CVAPI(ExceptionStatus) ximgproc_createStructuredEdgeDetection(
    const char *model,
    cv::Ptr<cv::ximgproc::RFFeatureGetter> *howToGetFeatures,
    cv::Ptr<cv::ximgproc::StructuredEdgeDetection> **returnValue)
{
    return cvTry([&] {
        if (howToGetFeatures == nullptr)
            *returnValue = clone(cv::ximgproc::createStructuredEdgeDetection(model));
        else
            *returnValue = clone(cv::ximgproc::createStructuredEdgeDetection(model, *howToGetFeatures));
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_StructuredEdgeDetection_delete(cv::Ptr<cv::ximgproc::StructuredEdgeDetection> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ximgproc_Ptr_StructuredEdgeDetection_get(cv::Ptr<cv::ximgproc::StructuredEdgeDetection> *ptr, cv::ximgproc::StructuredEdgeDetection **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) ximgproc_StructuredEdgeDetection_detectEdges(
    cv::ximgproc::StructuredEdgeDetection *obj,
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        obj->detectEdges(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) ximgproc_StructuredEdgeDetection_computeOrientation(
    cv::ximgproc::StructuredEdgeDetection *obj,
    const interop::InputArrayProxy* src,
    const interop::OutputArrayProxy* dst)
{
    return cvTry([&] {
        obj->computeOrientation(InProxy(*src), OutProxy(*dst));
    });
}

CVAPI(ExceptionStatus) ximgproc_StructuredEdgeDetection_edgesNms(
    cv::ximgproc::StructuredEdgeDetection *obj,
    const interop::InputArrayProxy* edge_image,
    const interop::InputArrayProxy* orientation_image,
    const interop::OutputArrayProxy* dst,
    int r,
    int s,
    float m,
    int isParallel)
{
    return cvTry([&] {
        obj->edgesNms(InProxy(*edge_image), InProxy(*orientation_image), OutProxy(*dst), r, s, m, isParallel != 0);
    });
}

#endif // NO_CONTRIB
