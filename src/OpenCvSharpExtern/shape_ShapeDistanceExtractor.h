#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) shape_ShapeDistanceExtractor_computeDistance(
    cv::ShapeDistanceExtractor* obj,
    const interop::InputArrayProxy* contour1,
    const interop::InputArrayProxy* contour2,
    float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->computeDistance(InProxy(*contour1), InProxy(*contour2));
    });
}

#pragma region ShapeContextDistanceExtractor

CVAPI(ExceptionStatus) shape_Ptr_ShapeContextDistanceExtractor_get(cv::Ptr<cv::ShapeContextDistanceExtractor> *obj, cv::ShapeContextDistanceExtractor **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) shape_Ptr_ShapeContextDistanceExtractor_delete(cv::Ptr<cv::ShapeContextDistanceExtractor> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setAngularBins(cv::ShapeContextDistanceExtractor *obj, int val)
{
    return cvTry([&] {
        obj->setAngularBins(val);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getAngularBins(cv::ShapeContextDistanceExtractor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getAngularBins();
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setRadialBins(cv::ShapeContextDistanceExtractor *obj, int val)
{
    return cvTry([&] {
        obj->setRadialBins(val);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getRadialBins(cv::ShapeContextDistanceExtractor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRadialBins();
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setInnerRadius(cv::ShapeContextDistanceExtractor *obj, float val)
{
    return cvTry([&] {
        obj->setInnerRadius(val);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getInnerRadius(cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getInnerRadius();
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setOuterRadius(cv::ShapeContextDistanceExtractor *obj, float val)
{
    return cvTry([&] {
        obj->setOuterRadius(val);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getOuterRadius(cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getOuterRadius();
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setRotationInvariant(cv::ShapeContextDistanceExtractor *obj, int val)
{
    return cvTry([&] {
        obj->setRotationInvariant(val != 0);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getRotationInvariant(cv::ShapeContextDistanceExtractor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRotationInvariant() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setShapeContextWeight(cv::ShapeContextDistanceExtractor *obj, float val)
{
    return cvTry([&] {
        obj->setShapeContextWeight(val);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getShapeContextWeight(cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getShapeContextWeight();
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(cv::ShapeContextDistanceExtractor *obj, float val)
{
    return cvTry([&] {
        obj->setImageAppearanceWeight(val);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getImageAppearanceWeight();
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(cv::ShapeContextDistanceExtractor *obj, float val)
{
    return cvTry([&] {
        obj->setBendingEnergyWeight(val);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getBendingEnergyWeight();
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setImages(
    cv::ShapeContextDistanceExtractor *obj,
    const interop::InputArrayProxy* image1,
    const interop::InputArrayProxy* image2)
{
    return cvTry([&] {
        obj->setImages(InProxy(*image1), InProxy(*image2));
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getImages(
    cv::ShapeContextDistanceExtractor *obj,
    const interop::OutputArrayProxy* image1,
    const interop::OutputArrayProxy* image2)
{
    return cvTry([&] {
        obj->getImages(OutProxy(*image1), OutProxy(*image2));
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setIterations(cv::ShapeContextDistanceExtractor *obj, int val)
{
    return cvTry([&] {
        obj->setIterations(val);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getIterations(cv::ShapeContextDistanceExtractor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getIterations();
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setCostExtractor(cv::ShapeContextDistanceExtractor *obj, cv::Ptr<cv::HistogramCostExtractor> *comparer)
{
    return cvTry([&] {
        obj->setCostExtractor(*comparer);
    });
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setStdDev(cv::ShapeContextDistanceExtractor *obj, float val)
{
    return cvTry([&] {
        obj->setStdDev(val);
    });
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getStdDev(cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getStdDev();
    });
}

// shape_ShapeContextDistanceExtractor_setTransformAlgorithm is defined in shape_ShapeTransformer.h

CVAPI(ExceptionStatus) shape_createShapeContextDistanceExtractor(
    int nAngularBins,
    int nRadialBins,
    float innerRadius,
    float outerRadius,
    int iterations/*,
    const Ptr<HistogramCostExtractor> &comparer = createChiHistogramCostExtractor(),
    const Ptr<ShapeTransformer> &transformer = createThinPlateSplineShapeTransformer()*/,
    cv::Ptr<cv::ShapeContextDistanceExtractor> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::createShapeContextDistanceExtractor(
            nAngularBins, nRadialBins, innerRadius, outerRadius, iterations);
        *returnValue = clone(p);
    });
}

#pragma endregion

#pragma region HausdorffDistanceExtractor

CVAPI(ExceptionStatus) shape_Ptr_HausdorffDistanceExtractor_get(cv::Ptr<cv::HausdorffDistanceExtractor> *obj, cv::HausdorffDistanceExtractor **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) shape_Ptr_HausdorffDistanceExtractor_delete(cv::Ptr<cv::HausdorffDistanceExtractor> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


CVAPI(ExceptionStatus) shape_HausdorffDistanceExtractor_setDistanceFlag(cv::HausdorffDistanceExtractor *obj, int val)
{
    return cvTry([&] {
        obj->setDistanceFlag(val);
    });
}
CVAPI(ExceptionStatus) shape_HausdorffDistanceExtractor_getDistanceFlag(cv::HausdorffDistanceExtractor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDistanceFlag();
    });
}

CVAPI(ExceptionStatus) shape_HausdorffDistanceExtractor_setRankProportion(cv::HausdorffDistanceExtractor *obj, float val)
{
    return cvTry([&] {
        obj->setRankProportion(val);
    });
}
CVAPI(ExceptionStatus) shape_HausdorffDistanceExtractor_getRankProportion(cv::HausdorffDistanceExtractor *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRankProportion();
    });
}


CVAPI(ExceptionStatus) shape_createHausdorffDistanceExtractor(
    int distanceFlag,
    float rankProp,
    cv::Ptr<cv::HausdorffDistanceExtractor> **returnValue)
{
    return cvTry([&] {
        const auto p = cv::createHausdorffDistanceExtractor(
            distanceFlag, rankProp);
        *returnValue = clone(p);
    });
}

#pragma endregion


#endif // NO_CONTRIB
