#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/shape/shape_transformer.hpp>


// ============================================================
// ShapeTransformer base class methods
// (called via raw pointer obtained from each subclass _get)
// ============================================================

CVAPI(ExceptionStatus) shape_ShapeTransformer_estimateTransformation(
    cv::ShapeTransformer *obj,
    cv::_InputArray *transformingShape,
    cv::_InputArray *targetShape,
    std::vector<cv::DMatch> *matches)
{
    BEGIN_WRAP
    obj->estimateTransformation(*transformingShape, *targetShape, *matches);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeTransformer_applyTransformation(
    cv::ShapeTransformer *obj,
    cv::_InputArray *input,
    cv::_OutputArray *output,
    float *returnValue)
{
    BEGIN_WRAP
    if (output == nullptr)
        *returnValue = obj->applyTransformation(*input);
    else
        *returnValue = obj->applyTransformation(*input, *output);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeTransformer_warpImage(
    cv::ShapeTransformer *obj,
    cv::_InputArray *transformingImage,
    cv::_OutputArray *output,
    int flags,
    int borderMode,
    MyCvScalar borderValue)
{
    BEGIN_WRAP
    obj->warpImage(*transformingImage, *output, flags, borderMode, cpp(borderValue));
    END_WRAP
}


// ============================================================
// ThinPlateSplineShapeTransformer
// ============================================================

#pragma region ThinPlateSplineShapeTransformer

CVAPI(ExceptionStatus) shape_Ptr_ThinPlateSplineShapeTransformer_delete(
    cv::Ptr<cv::ThinPlateSplineShapeTransformer> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) shape_Ptr_ThinPlateSplineShapeTransformer_get(
    cv::Ptr<cv::ThinPlateSplineShapeTransformer> *ptr,
    cv::ThinPlateSplineShapeTransformer **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_createThinPlateSplineShapeTransformer(
    double regularizationParameter,
    cv::Ptr<cv::ThinPlateSplineShapeTransformer> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createThinPlateSplineShapeTransformer(regularizationParameter);
    *returnValue = new cv::Ptr<cv::ThinPlateSplineShapeTransformer>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ThinPlateSplineShapeTransformer_setRegularizationParameter(
    cv::ThinPlateSplineShapeTransformer *obj, double beta)
{
    BEGIN_WRAP
    obj->setRegularizationParameter(beta);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ThinPlateSplineShapeTransformer_getRegularizationParameter(
    cv::ThinPlateSplineShapeTransformer *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRegularizationParameter();
    END_WRAP
}

#pragma endregion


// ============================================================
// AffineTransformer
// ============================================================

#pragma region AffineTransformer

CVAPI(ExceptionStatus) shape_Ptr_AffineTransformer_delete(
    cv::Ptr<cv::AffineTransformer> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) shape_Ptr_AffineTransformer_get(
    cv::Ptr<cv::AffineTransformer> *ptr,
    cv::AffineTransformer **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_createAffineTransformer(
    int fullAffine,
    cv::Ptr<cv::AffineTransformer> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::createAffineTransformer(fullAffine != 0);
    *returnValue = new cv::Ptr<cv::AffineTransformer>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_AffineTransformer_setFullAffine(
    cv::AffineTransformer *obj, int value)
{
    BEGIN_WRAP
    obj->setFullAffine(value != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_AffineTransformer_getFullAffine(
    cv::AffineTransformer *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getFullAffine() ? 1 : 0;
    END_WRAP
}

#pragma endregion


// ============================================================
// Upcast helpers: typed Ptr<Derived> → new Ptr<ShapeTransformer>
// Used by SetTransformAlgorithm on ShapeContextDistanceExtractor.
// ============================================================

CVAPI(ExceptionStatus) shape_Ptr_ThinPlateSplineShapeTransformer_upcast(
    cv::Ptr<cv::ThinPlateSplineShapeTransformer> *src,
    cv::Ptr<cv::ShapeTransformer> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::ShapeTransformer>(*src);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_Ptr_AffineTransformer_upcast(
    cv::Ptr<cv::AffineTransformer> *src,
    cv::Ptr<cv::ShapeTransformer> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::ShapeTransformer>(*src);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_Ptr_ShapeTransformer_delete(
    cv::Ptr<cv::ShapeTransformer> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setTransformAlgorithm(
    cv::ShapeContextDistanceExtractor *obj,
    cv::Ptr<cv::ShapeTransformer> *transformer)
{
    BEGIN_WRAP
    obj->setTransformAlgorithm(*transformer);
    END_WRAP
}


#endif // NO_CONTRIB