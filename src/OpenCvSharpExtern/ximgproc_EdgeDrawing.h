#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

/// <summary>
/// Plain-C struct for marshaling EdgeDrawing::Params across the P/Invoke boundary.
/// All bool fields are represented as int (0 = false, non-zero = true).
/// Layout must stay in sync with OpenCvSharp.XImgProc.EdgeDrawingParams in C#.
/// </summary>
struct CvEdgeDrawingParams
{
    int    PFmode;
    int    EdgeDetectionOperator;
    int    GradientThresholdValue;
    int    AnchorThresholdValue;
    int    ScanInterval;
    int    MinPathLength;
    float  Sigma;
    int    SumFlag;
    int    NFAValidation;
    int    MinLineLength;
    double MaxDistanceBetweenTwoLines;
    double LineFitErrorThreshold;
    double MaxErrorThreshold;
};


CVAPI(ExceptionStatus) ximgproc_Ptr_EdgeDrawing_delete(cv::Ptr<cv::ximgproc::EdgeDrawing> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_EdgeDrawing_get(
    cv::Ptr<cv::ximgproc::EdgeDrawing> *ptr, cv::ximgproc::EdgeDrawing **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_createEdgeDrawing(
    cv::Ptr<cv::ximgproc::EdgeDrawing> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ximgproc::createEdgeDrawing();
    *returnValue = new cv::Ptr<cv::ximgproc::EdgeDrawing>(ptr);
    END_WRAP
}


CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_detectEdges(
    cv::ximgproc::EdgeDrawing *obj, cv::_InputArray *src)
{
    BEGIN_WRAP
    obj->detectEdges(*src);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_getEdgeImage(
    cv::ximgproc::EdgeDrawing *obj, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->getEdgeImage(*dst);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_getGradientImage(
    cv::ximgproc::EdgeDrawing *obj, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->getGradientImage(*dst);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_getSegments(
    cv::ximgproc::EdgeDrawing *obj,
    std::vector<std::vector<cv::Point>> *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSegments();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_getSegmentIndicesOfLines(
    cv::ximgproc::EdgeDrawing *obj, std::vector<int> *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSegmentIndicesOfLines();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_detectLines(
    cv::ximgproc::EdgeDrawing *obj, cv::_OutputArray *lines)
{
    BEGIN_WRAP
    obj->detectLines(*lines);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_detectLines_vector(
    cv::ximgproc::EdgeDrawing *obj, std::vector<cv::Vec4f> *lines)
{
    BEGIN_WRAP
    obj->detectLines(*lines);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_detectEllipses(
    cv::ximgproc::EdgeDrawing *obj, cv::_OutputArray *ellipses)
{
    BEGIN_WRAP
    obj->detectEllipses(*ellipses);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_detectEllipses_vector(
    cv::ximgproc::EdgeDrawing *obj, std::vector<cv::Vec6d> *ellipses)
{
    BEGIN_WRAP
    obj->detectEllipses(*ellipses);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_getParams(
    cv::ximgproc::EdgeDrawing *obj, CvEdgeDrawingParams *returnValue)
{
    BEGIN_WRAP
    const auto &p = obj->params;
    returnValue->PFmode                      = p.PFmode ? 1 : 0;
    returnValue->EdgeDetectionOperator       = p.EdgeDetectionOperator;
    returnValue->GradientThresholdValue      = p.GradientThresholdValue;
    returnValue->AnchorThresholdValue        = p.AnchorThresholdValue;
    returnValue->ScanInterval                = p.ScanInterval;
    returnValue->MinPathLength               = p.MinPathLength;
    returnValue->Sigma                       = p.Sigma;
    returnValue->SumFlag                     = p.SumFlag ? 1 : 0;
    returnValue->NFAValidation               = p.NFAValidation ? 1 : 0;
    returnValue->MinLineLength               = p.MinLineLength;
    returnValue->MaxDistanceBetweenTwoLines  = p.MaxDistanceBetweenTwoLines;
    returnValue->LineFitErrorThreshold       = p.LineFitErrorThreshold;
    returnValue->MaxErrorThreshold           = p.MaxErrorThreshold;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_setParams(
    cv::ximgproc::EdgeDrawing *obj, CvEdgeDrawingParams *params)
{
    BEGIN_WRAP
    cv::ximgproc::EdgeDrawing::Params p;
    p.PFmode                     = params->PFmode != 0;
    p.EdgeDetectionOperator      = params->EdgeDetectionOperator;
    p.GradientThresholdValue     = params->GradientThresholdValue;
    p.AnchorThresholdValue       = params->AnchorThresholdValue;
    p.ScanInterval               = params->ScanInterval;
    p.MinPathLength              = params->MinPathLength;
    p.Sigma                      = params->Sigma;
    p.SumFlag                    = params->SumFlag != 0;
    p.NFAValidation              = params->NFAValidation != 0;
    p.MinLineLength              = params->MinLineLength;
    p.MaxDistanceBetweenTwoLines = params->MaxDistanceBetweenTwoLines;
    p.LineFitErrorThreshold      = params->LineFitErrorThreshold;
    p.MaxErrorThreshold          = params->MaxErrorThreshold;
    obj->setParams(p);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_EdgeDrawing_Params_default(CvEdgeDrawingParams *returnValue)
{
    BEGIN_WRAP
    cv::ximgproc::EdgeDrawing::Params p;
    returnValue->PFmode                     = p.PFmode ? 1 : 0;
    returnValue->EdgeDetectionOperator      = p.EdgeDetectionOperator;
    returnValue->GradientThresholdValue     = p.GradientThresholdValue;
    returnValue->AnchorThresholdValue       = p.AnchorThresholdValue;
    returnValue->ScanInterval               = p.ScanInterval;
    returnValue->MinPathLength              = p.MinPathLength;
    returnValue->Sigma                      = p.Sigma;
    returnValue->SumFlag                    = p.SumFlag ? 1 : 0;
    returnValue->NFAValidation              = p.NFAValidation ? 1 : 0;
    returnValue->MinLineLength              = p.MinLineLength;
    returnValue->MaxDistanceBetweenTwoLines = p.MaxDistanceBetweenTwoLines;
    returnValue->LineFitErrorThreshold      = p.LineFitErrorThreshold;
    returnValue->MaxErrorThreshold          = p.MaxErrorThreshold;
    END_WRAP
}

#endif // NO_CONTRIB
