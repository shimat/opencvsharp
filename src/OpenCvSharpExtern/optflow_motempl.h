#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) optflow_motempl_updateMotionHistory(
    cv::_InputArray *silhouette, cv::_InputOutputArray *mhi,
    double timestamp, double duration)
{
    BEGIN_WRAP
    cv::motempl::updateMotionHistory(*silhouette, *mhi, timestamp, duration);
    END_WRAP
}

CVAPI(ExceptionStatus) optflow_motempl_calcMotionGradient(
    cv::_InputArray *mhi, cv::_OutputArray *mask, cv::_OutputArray *orientation,
    double delta1, double delta2, int apertureSize)
{
    BEGIN_WRAP
    cv::motempl::calcMotionGradient(*mhi, *mask, *orientation, delta1, delta2, apertureSize);
    END_WRAP
}

CVAPI(ExceptionStatus) optflow_motempl_calcGlobalOrientation(
    cv::_InputArray *orientation, cv::_InputArray *mask,
    cv::_InputArray *mhi, double timestamp, double duration, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::motempl::calcGlobalOrientation(*orientation, *mask, *mhi, timestamp, duration);
    END_WRAP
}

CVAPI(ExceptionStatus) optflow_motempl_segmentMotion(
    cv::_InputArray *mhi, cv::_OutputArray *segmask,
    std::vector<cv::Rect> *boundingRects,
    double timestamp, double segThresh)
{
    BEGIN_WRAP
    cv::motempl::segmentMotion(*mhi, *segmask, *boundingRects, timestamp, segThresh);
    END_WRAP
}
