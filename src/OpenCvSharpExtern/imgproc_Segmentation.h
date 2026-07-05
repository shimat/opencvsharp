#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_new(cv::segmentation::IntelligentScissorsMB** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::segmentation::IntelligentScissorsMB();
    });
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_delete(cv::segmentation::IntelligentScissorsMB *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_setWeights(
    cv::segmentation::IntelligentScissorsMB *obj,
    float weight_non_edge,
    float weight_gradient_direction,
    float weight_gradient_magnitude)
{
    return cvTry([&] {
        obj->setWeights(weight_non_edge, weight_gradient_direction, weight_gradient_magnitude);
    });
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_setGradientMagnitudeMaxLimit(cv::segmentation::IntelligentScissorsMB *obj, float gradient_magnitude_threshold_max)
{
    return cvTry([&] {
        obj->setGradientMagnitudeMaxLimit(gradient_magnitude_threshold_max);
    });
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_setEdgeFeatureZeroCrossingParameters(cv::segmentation::IntelligentScissorsMB *obj, float gradient_magnitude_min_value)
{
    return cvTry([&] {
        obj->setEdgeFeatureZeroCrossingParameters(gradient_magnitude_min_value);
    });
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_setEdgeFeatureCannyParameters(
    cv::segmentation::IntelligentScissorsMB *obj,
    double threshold1,
    double threshold2,
    int apertureSize,
    int L2gradient)
{
    return cvTry([&] {
        obj->setEdgeFeatureCannyParameters(threshold1, threshold2, apertureSize, L2gradient != 0);
    });
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_applyImage(cv::segmentation::IntelligentScissorsMB *obj, const interop::InputArrayProxy* image)
{
    return cvTry([&] {
        obj->applyImage(InProxy(*image));
    });
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_applyImageFeatures(
    cv::segmentation::IntelligentScissorsMB *obj,
    const interop::InputArrayProxy* non_edge,
    const interop::InputArrayProxy* gradient_direction,
    const interop::InputArrayProxy* gradient_magnitude,
    const interop::InputArrayProxy* image)
{
    return cvTry([&] {
        obj->applyImageFeatures(InProxy(*non_edge), InProxy(*gradient_direction), InProxy(*gradient_magnitude), InProxy(*image));
    });
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_buildMap(cv::segmentation::IntelligentScissorsMB *obj, interop::Point sourcePt)
{
    return cvTry([&] {
        obj->buildMap(cpp(sourcePt));
    });
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_getContour(
    cv::segmentation::IntelligentScissorsMB *obj,
    interop::Point targetPt,
    const interop::OutputArrayProxy* contour,
    int backward)
{
    return cvTry([&] {
        obj->getContour(cpp(targetPt), OutProxy(*contour), backward != 0);
    });
}
