#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_new(
    cv::segmentation::IntelligentScissorsMB** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::segmentation::IntelligentScissorsMB();
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_delete(
    cv::segmentation::IntelligentScissorsMB *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_setWeights(
    cv::segmentation::IntelligentScissorsMB *obj,
    float weight_non_edge, float weight_gradient_direction, float weight_gradient_magnitude)
{
    BEGIN_WRAP
    obj->setWeights(weight_non_edge, weight_gradient_direction, weight_gradient_magnitude);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_setGradientMagnitudeMaxLimit(
    cv::segmentation::IntelligentScissorsMB *obj,
    float gradient_magnitude_threshold_max)
{
    BEGIN_WRAP
    obj->setGradientMagnitudeMaxLimit(gradient_magnitude_threshold_max);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_setEdgeFeatureZeroCrossingParameters(
    cv::segmentation::IntelligentScissorsMB *obj,
    float gradient_magnitude_min_value)
{
    BEGIN_WRAP
    obj->setEdgeFeatureZeroCrossingParameters(gradient_magnitude_min_value);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_setEdgeFeatureCannyParameters(
    cv::segmentation::IntelligentScissorsMB *obj,
    double threshold1, double threshold2,
    int apertureSize, int L2gradient)
{
    BEGIN_WRAP
    obj->setEdgeFeatureCannyParameters(threshold1, threshold2, apertureSize, L2gradient != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_applyImage(
    cv::segmentation::IntelligentScissorsMB *obj,
    cv::_InputArray *image)
{
    BEGIN_WRAP
    obj->applyImage(*image);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_applyImageFeatures(
    cv::segmentation::IntelligentScissorsMB *obj,
    cv::_InputArray *non_edge,
    cv::_InputArray *gradient_direction,
    cv::_InputArray *gradient_magnitude,
    cv::_InputArray *image)
{
    BEGIN_WRAP
    obj->applyImageFeatures(*non_edge, *gradient_direction, *gradient_magnitude, entity(image));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_buildMap(
    cv::segmentation::IntelligentScissorsMB *obj,
    MyCvPoint sourcePt)
{
    BEGIN_WRAP
    obj->buildMap(cpp(sourcePt));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_segmentation_IntelligentScissorsMB_getContour(
    cv::segmentation::IntelligentScissorsMB *obj,
    MyCvPoint targetPt, cv::_OutputArray *contour, int backward)
{
    BEGIN_WRAP
    obj->getContour(cpp(targetPt), *contour, backward != 0);
    END_WRAP
}
