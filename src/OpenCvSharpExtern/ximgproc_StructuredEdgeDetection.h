#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// RFFeatureGetter

CVAPI(ExceptionStatus) ximgproc_createRFFeatureGetter(cv::Ptr<cv::ximgproc::RFFeatureGetter> **returnValue)
{
    BEGIN_WRAP
    *returnValue = clone(cv::ximgproc::createRFFeatureGetter());
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_RFFeatureGetter_delete(cv::Ptr<cv::ximgproc::RFFeatureGetter> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_RFFeatureGetter_get(cv::Ptr<cv::ximgproc::RFFeatureGetter> *ptr, cv::ximgproc::RFFeatureGetter **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_RFFeatureGetter_getFeatures(
    cv::ximgproc::RFFeatureGetter *obj, cv::Mat *src, cv::Mat *features,
    const int gnrmRad, const int gsmthRad, const int shrink, const int outNum, const int gradNum)
{
    BEGIN_WRAP
    obj->getFeatures(*src, *features, gnrmRad, gsmthRad, shrink, outNum, gradNum);
    END_WRAP
}


// StructuredEdgeDetection

CVAPI(ExceptionStatus) ximgproc_createStructuredEdgeDetection(
    const char *model, cv::Ptr<cv::ximgproc::RFFeatureGetter> *howToGetFeatures, cv::Ptr<cv::ximgproc::StructuredEdgeDetection> **returnValue)
{
    BEGIN_WRAP
    if (howToGetFeatures == nullptr)
        *returnValue = clone(cv::ximgproc::createStructuredEdgeDetection(model));
    else
        *returnValue = clone(cv::ximgproc::createStructuredEdgeDetection(model, *howToGetFeatures));
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_StructuredEdgeDetection_delete(cv::Ptr<cv::ximgproc::StructuredEdgeDetection> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_StructuredEdgeDetection_get(cv::Ptr<cv::ximgproc::StructuredEdgeDetection> *ptr, cv::ximgproc::StructuredEdgeDetection **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_StructuredEdgeDetection_detectEdges(cv::ximgproc::StructuredEdgeDetection *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->detectEdges(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_StructuredEdgeDetection_computeOrientation(cv::ximgproc::StructuredEdgeDetection *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->computeOrientation(*src, *dst);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_StructuredEdgeDetection_edgesNms(cv::ximgproc::StructuredEdgeDetection *obj,
    cv::_InputArray *edge_image, cv::_InputArray *orientation_image, cv::_OutputArray *dst, 
    int r, int s, float m, int isParallel)
{
    BEGIN_WRAP
    obj->edgesNms(*edge_image, *orientation_image, *dst, r, s, m, isParallel != 0);
    END_WRAP
}
