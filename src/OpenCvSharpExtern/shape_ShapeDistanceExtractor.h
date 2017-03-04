#ifndef _CPP_SHAPE_SHAPEDISTANCEEXTRACTOR_H_
#define _CPP_SHAPE_SHAPEDISTANCEEXTRACTOR_H_

#include "include_opencv.h"


CVAPI(float) shape_ShapeDistanceExtractor_computeDistance(
    cv::ShapeDistanceExtractor *obj, cv::_InputArray *contour1, cv::_InputArray *contour2)
{
    return obj->computeDistance(*contour1, *contour2);
}

#pragma region ShapeContextDistanceExtractor

CVAPI(void) shape_Ptr_ShapeContextDistanceExtractor_delete(
    cv::Ptr<cv::ShapeContextDistanceExtractor> *obj)
{
    delete obj;
}
CVAPI(cv::ShapeContextDistanceExtractor*) shape_Ptr_ShapeContextDistanceExtractor_get(
    cv::Ptr<cv::ShapeContextDistanceExtractor> *obj)
{
    return obj->get();
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setAngularBins(
    cv::ShapeContextDistanceExtractor *obj, int val)
{
    obj->setAngularBins(val);
}
CVAPI(int) shape_ShapeContextDistanceExtractor_getAngularBins(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getAngularBins();
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setRadialBins(
    cv::ShapeContextDistanceExtractor *obj, int val)
{
    obj->setRadialBins(val);
}
CVAPI(int) shape_ShapeContextDistanceExtractor_getRadialBins(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getRadialBins();
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setInnerRadius(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    obj->setInnerRadius(val);
}
CVAPI(float) shape_ShapeContextDistanceExtractor_getInnerRadius(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getInnerRadius();
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setOuterRadius(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    obj->setOuterRadius(val);
}
CVAPI(float) shape_ShapeContextDistanceExtractor_getOuterRadius(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getOuterRadius();
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setRotationInvariant(
    cv::ShapeContextDistanceExtractor *obj, int val)
{
    obj->setRotationInvariant(val != 0);
}
CVAPI(int) shape_ShapeContextDistanceExtractor_getRotationInvariant(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getRotationInvariant() ? 1 : 0;
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setShapeContextWeight(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    obj->setShapeContextWeight(val);
}
CVAPI(float) shape_ShapeContextDistanceExtractor_getShapeContextWeight(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getShapeContextWeight();
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    obj->setImageAppearanceWeight(val);
}
CVAPI(float) shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getImageAppearanceWeight();
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    obj->setBendingEnergyWeight(val);
}
CVAPI(float) shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getBendingEnergyWeight();
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setImages(
    cv::ShapeContextDistanceExtractor *obj, cv::_InputArray *image1, cv::_InputArray *image2)
{
    obj->setImages(*image1, *image2);
}
CVAPI(void) shape_ShapeContextDistanceExtractor_getImages(
    cv::ShapeContextDistanceExtractor *obj, cv::_OutputArray *image1, cv::_OutputArray *image2)
{
    obj->getImages(*image1, *image2);
}

CVAPI(void) shape_ShapeContextDistanceExtractor_setIterations(
    cv::ShapeContextDistanceExtractor *obj, int val)
{
    obj->setIterations(val);
}
CVAPI(int) shape_ShapeContextDistanceExtractor_getIterations(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getIterations();
}

/*
CVAPI(void) shape_ShapeContextDistanceExtractor_setCostExtractor(
    cv::ShapeContextDistanceExtractor *obj, Ptr<HistogramCostExtractor> comparer)
{

}
CVAPI(Ptr<HistogramCostExtractor>) shape_ShapeContextDistanceExtractor_getCostExtractor(
    cv::ShapeContextDistanceExtractor *obj)
{

}*/

CVAPI(void) shape_ShapeContextDistanceExtractor_setStdDev(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    obj->setStdDev(val);
}
CVAPI(float) shape_ShapeContextDistanceExtractor_getStdDev(
    cv::ShapeContextDistanceExtractor *obj)
{
    return obj->getStdDev();
}

/*
CVAPI(void) shape_ShapeContextDistanceExtractor_setTransformAlgorithm(
    cv::ShapeContextDistanceExtractor *obj, Ptr<ShapeTransformer> transformer)
{
}
CVAPI(Ptr<ShapeTransformer>) shape_ShapeContextDistanceExtractor_getTransformAlgorithm(
    cv::ShapeContextDistanceExtractor *obj)
{

}
*/

CVAPI(cv::Ptr<cv::ShapeContextDistanceExtractor>*) shape_createShapeContextDistanceExtractor(
    int nAngularBins, int nRadialBins,
    float innerRadius, float outerRadius, int iterations/*,
    const Ptr<HistogramCostExtractor> &comparer = createChiHistogramCostExtractor(),
    const Ptr<ShapeTransformer> &transformer = createThinPlateSplineShapeTransformer()*/)
{
    cv::Ptr<cv::ShapeContextDistanceExtractor> p = cv::createShapeContextDistanceExtractor(
        nAngularBins, nRadialBins, innerRadius, outerRadius, iterations);
    return new cv::Ptr<cv::ShapeContextDistanceExtractor>(p);
}

#pragma endregion

#pragma region HausdorffDistanceExtractor

CVAPI(void) shape_Ptr_HausdorffDistanceExtractor_delete(
    cv::Ptr<cv::HausdorffDistanceExtractor> *obj)
{
    delete obj;
}
CVAPI(cv::HausdorffDistanceExtractor*) shape_Ptr_HausdorffDistanceExtractor_get(
    cv::Ptr<cv::HausdorffDistanceExtractor> *obj)
{
    return obj->get();
}


CVAPI(void) shape_HausdorffDistanceExtractor_setDistanceFlag(
    cv::HausdorffDistanceExtractor *obj, int val)
{
    obj->setDistanceFlag(val);
}
CVAPI(int) shape_HausdorffDistanceExtractor_getDistanceFlag(
    cv::HausdorffDistanceExtractor *obj)
{
    return obj->getDistanceFlag();
}

CVAPI(void) shape_HausdorffDistanceExtractor_setRankProportion(
    cv::HausdorffDistanceExtractor *obj, float val)
{
    obj->setRankProportion(val);
}
CVAPI(float) shape_HausdorffDistanceExtractor_getRankProportion(
    cv::HausdorffDistanceExtractor *obj)
{
    return obj->getRankProportion();
}


CVAPI(cv::Ptr<cv::HausdorffDistanceExtractor>*) shape_createHausdorffDistanceExtractor(
    int distanceFlag, float rankProp)
{
    cv::Ptr<cv::HausdorffDistanceExtractor> p = cv::createHausdorffDistanceExtractor(
        distanceFlag, rankProp);
    return new cv::Ptr<cv::HausdorffDistanceExtractor>(p);
}

#pragma endregion

#endif