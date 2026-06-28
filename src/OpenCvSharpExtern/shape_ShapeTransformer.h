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
    return cvTry([&] {
    obj->estimateTransformation(*transformingShape, *targetShape, *matches);
    });
}

CVAPI(ExceptionStatus) shape_ShapeTransformer_applyTransformation(
    cv::ShapeTransformer *obj,
    cv::_InputArray *input,
    cv::_OutputArray *output,
    float *returnValue)
{
    return cvTry([&] {
    if (output == nullptr)
        *returnValue = obj->applyTransformation(*input);
    else
        *returnValue = obj->applyTransformation(*input, *output);
    });
}

CVAPI(ExceptionStatus) shape_ShapeTransformer_warpImage(
    cv::ShapeTransformer *obj,
    cv::_InputArray *transformingImage,
    cv::_OutputArray *output,
    int flags,
    int borderMode,
    interop::Scalar borderValue)
{
    return cvTry([&] {
    obj->warpImage(*transformingImage, *output, flags, borderMode, cpp(borderValue));
    });
}


// ============================================================
// ThinPlateSplineShapeTransformer
// ============================================================

#pragma region ThinPlateSplineShapeTransformer

CVAPI(ExceptionStatus) shape_Ptr_ThinPlateSplineShapeTransformer_delete(
    cv::Ptr<cv::ThinPlateSplineShapeTransformer> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) shape_Ptr_ThinPlateSplineShapeTransformer_get(
    cv::Ptr<cv::ThinPlateSplineShapeTransformer> *ptr,
    cv::ThinPlateSplineShapeTransformer **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) shape_createThinPlateSplineShapeTransformer(
    double regularizationParameter,
    cv::Ptr<cv::ThinPlateSplineShapeTransformer> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::createThinPlateSplineShapeTransformer(regularizationParameter);
    *returnValue = new cv::Ptr<cv::ThinPlateSplineShapeTransformer>(ptr);
    });
}

CVAPI(ExceptionStatus) shape_ThinPlateSplineShapeTransformer_setRegularizationParameter(
    cv::ThinPlateSplineShapeTransformer *obj, double beta)
{
    return cvTry([&] {
    obj->setRegularizationParameter(beta);
    });
}

CVAPI(ExceptionStatus) shape_ThinPlateSplineShapeTransformer_getRegularizationParameter(
    cv::ThinPlateSplineShapeTransformer *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getRegularizationParameter();
    });
}

#pragma endregion


// ============================================================
// AffineTransformer
// ============================================================

#pragma region AffineTransformer

CVAPI(ExceptionStatus) shape_Ptr_AffineTransformer_delete(
    cv::Ptr<cv::AffineTransformer> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) shape_Ptr_AffineTransformer_get(
    cv::Ptr<cv::AffineTransformer> *ptr,
    cv::AffineTransformer **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) shape_createAffineTransformer(
    int fullAffine,
    cv::Ptr<cv::AffineTransformer> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::createAffineTransformer(fullAffine != 0);
    *returnValue = new cv::Ptr<cv::AffineTransformer>(ptr);
    });
}

CVAPI(ExceptionStatus) shape_AffineTransformer_setFullAffine(
    cv::AffineTransformer *obj, int value)
{
    return cvTry([&] {
    obj->setFullAffine(value != 0);
    });
}

CVAPI(ExceptionStatus) shape_AffineTransformer_getFullAffine(
    cv::AffineTransformer *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getFullAffine() ? 1 : 0;
    });
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
    return cvTry([&] {
    *returnValue = new cv::Ptr<cv::ShapeTransformer>(*src);
    });
}

CVAPI(ExceptionStatus) shape_Ptr_AffineTransformer_upcast(
    cv::Ptr<cv::AffineTransformer> *src,
    cv::Ptr<cv::ShapeTransformer> **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Ptr<cv::ShapeTransformer>(*src);
    });
}

CVAPI(ExceptionStatus) shape_Ptr_ShapeTransformer_delete(
    cv::Ptr<cv::ShapeTransformer> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setTransformAlgorithm(
    cv::ShapeContextDistanceExtractor *obj,
    cv::Ptr<cv::ShapeTransformer> *transformer)
{
    return cvTry([&] {
    obj->setTransformAlgorithm(*transformer);
    });
}


#endif // NO_CONTRIB