#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) optflow_motempl_updateMotionHistory(
    const interop::InputArrayProxy* silhouette,
    const interop::InputOutputArrayProxy* mhi,
    double timestamp,
    double duration)
{
    return cvTry([&] {
        cv::motempl::updateMotionHistory(InProxy(*silhouette), IoProxy(*mhi), timestamp, duration);
    });
}

CVAPI(ExceptionStatus) optflow_motempl_calcMotionGradient(
    const interop::InputArrayProxy* mhi,
    const interop::OutputArrayProxy* mask,
    const interop::OutputArrayProxy* orientation,
    double delta1,
    double delta2,
    int apertureSize)
{
    return cvTry([&] {
        cv::motempl::calcMotionGradient(InProxy(*mhi), OutProxy(*mask), OutProxy(*orientation), delta1, delta2, apertureSize);
    });
}

CVAPI(ExceptionStatus) optflow_motempl_calcGlobalOrientation(
    const interop::InputArrayProxy* orientation,
    const interop::InputArrayProxy* mask,
    const interop::InputArrayProxy* mhi,
    double timestamp,
    double duration,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::motempl::calcGlobalOrientation(InProxy(*orientation), InProxy(*mask), InProxy(*mhi), timestamp, duration);
    });
}

CVAPI(ExceptionStatus) optflow_motempl_segmentMotion(
    const interop::InputArrayProxy* mhi,
    const interop::OutputArrayProxy* segmask,
    std::vector<cv::Rect> *boundingRects,
    double timestamp,
    double segThresh)
{
    return cvTry([&] {
        cv::motempl::segmentMotion(InProxy(*mhi), OutProxy(*segmask), *boundingRects, timestamp, segThresh);
    });
}

#endif // NO_CONTRIB
