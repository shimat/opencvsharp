#ifndef _CPP_SHAPE_SHAPEDISTANCEEXTRACTOR_H_
#define _CPP_SHAPE_SHAPEDISTANCEEXTRACTOR_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) shape_ShapeDistanceExtractor_computeDistance(
    cv::ShapeDistanceExtractor *obj, cv::_InputArray *contour1, cv::_InputArray *contour2, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->computeDistance(*contour1, *contour2);
    END_WRAP
}

#pragma region ShapeContextDistanceExtractor

CVAPI(ExceptionStatus) shape_Ptr_ShapeContextDistanceExtractor_delete(
    cv::Ptr<cv::ShapeContextDistanceExtractor> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) shape_Ptr_ShapeContextDistanceExtractor_get(
    cv::Ptr<cv::ShapeContextDistanceExtractor> *obj, cv::ShapeContextDistanceExtractor **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setAngularBins(
    cv::ShapeContextDistanceExtractor *obj, int val)
{
    BEGIN_WRAP
    obj->setAngularBins(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getAngularBins(
    cv::ShapeContextDistanceExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getAngularBins();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setRadialBins(
    cv::ShapeContextDistanceExtractor *obj, int val)
{
    BEGIN_WRAP
    obj->setRadialBins(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getRadialBins(
    cv::ShapeContextDistanceExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRadialBins();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setInnerRadius(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    BEGIN_WRAP
    obj->setInnerRadius(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getInnerRadius(
    cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getInnerRadius();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setOuterRadius(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    BEGIN_WRAP
    obj->setOuterRadius(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getOuterRadius(
    cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getOuterRadius();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setRotationInvariant(
    cv::ShapeContextDistanceExtractor *obj, int val)
{
    BEGIN_WRAP
    obj->setRotationInvariant(val != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getRotationInvariant(
    cv::ShapeContextDistanceExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRotationInvariant() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setShapeContextWeight(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    BEGIN_WRAP
    obj->setShapeContextWeight(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getShapeContextWeight(
    cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getShapeContextWeight();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setImageAppearanceWeight(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    BEGIN_WRAP
    obj->setImageAppearanceWeight(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getImageAppearanceWeight(
    cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getImageAppearanceWeight();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setBendingEnergyWeight(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    BEGIN_WRAP
    obj->setBendingEnergyWeight(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getBendingEnergyWeight(
    cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getBendingEnergyWeight();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setImages(
    cv::ShapeContextDistanceExtractor *obj, cv::_InputArray *image1, cv::_InputArray *image2)
{
    BEGIN_WRAP
    obj->setImages(*image1, *image2);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getImages(
    cv::ShapeContextDistanceExtractor *obj, cv::_OutputArray *image1, cv::_OutputArray *image2)
{
    BEGIN_WRAP
    obj->getImages(*image1, *image2);
    END_WRAP
}

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setIterations(
    cv::ShapeContextDistanceExtractor *obj, int val)
{
    BEGIN_WRAP
    obj->setIterations(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getIterations(
    cv::ShapeContextDistanceExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getIterations();
    END_WRAP
}

/*CVAPI(void) shape_ShapeContextDistanceExtractor_setCostExtractor(
    cv::ShapeContextDistanceExtractor *obj, Ptr<HistogramCostExtractor> comparer)
{

}*/
/*CVAPI(Ptr<HistogramCostExtractor>) shape_ShapeContextDistanceExtractor_getCostExtractor(
    cv::ShapeContextDistanceExtractor *obj)
{

}*/

CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_setStdDev(
    cv::ShapeContextDistanceExtractor *obj, float val)
{
    BEGIN_WRAP
    obj->setStdDev(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_ShapeContextDistanceExtractor_getStdDev(
    cv::ShapeContextDistanceExtractor *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getStdDev();
    END_WRAP
}

/*CVAPI(void) shape_ShapeContextDistanceExtractor_setTransformAlgorithm(
    cv::ShapeContextDistanceExtractor *obj, Ptr<ShapeTransformer> transformer)
{
}*/
/*CVAPI(Ptr<ShapeTransformer>) shape_ShapeContextDistanceExtractor_getTransformAlgorithm(
    cv::ShapeContextDistanceExtractor *obj)
{

}
*/

CVAPI(ExceptionStatus) shape_createShapeContextDistanceExtractor(
    int nAngularBins, int nRadialBins,
    float innerRadius, float outerRadius, int iterations/*,
    const Ptr<HistogramCostExtractor> &comparer = createChiHistogramCostExtractor(),
    const Ptr<ShapeTransformer> &transformer = createThinPlateSplineShapeTransformer()*/,
    cv::Ptr<cv::ShapeContextDistanceExtractor> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::createShapeContextDistanceExtractor(
        nAngularBins, nRadialBins, innerRadius, outerRadius, iterations);
    *returnValue = clone(p);
    END_WRAP
}

#pragma endregion

#pragma region HausdorffDistanceExtractor

CVAPI(ExceptionStatus) shape_Ptr_HausdorffDistanceExtractor_delete(
    cv::Ptr<cv::HausdorffDistanceExtractor> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) shape_Ptr_HausdorffDistanceExtractor_get(
    cv::Ptr<cv::HausdorffDistanceExtractor> *obj, cv::HausdorffDistanceExtractor **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}


CVAPI(ExceptionStatus) shape_HausdorffDistanceExtractor_setDistanceFlag(
    cv::HausdorffDistanceExtractor *obj, int val)
{
    BEGIN_WRAP
    obj->setDistanceFlag(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_HausdorffDistanceExtractor_getDistanceFlag(
    cv::HausdorffDistanceExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDistanceFlag();
    END_WRAP
}

CVAPI(ExceptionStatus) shape_HausdorffDistanceExtractor_setRankProportion(
    cv::HausdorffDistanceExtractor *obj, float val)
{
    BEGIN_WRAP
    obj->setRankProportion(val);
    END_WRAP
}
CVAPI(ExceptionStatus) shape_HausdorffDistanceExtractor_getRankProportion(
    cv::HausdorffDistanceExtractor *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRankProportion();
    END_WRAP
}


CVAPI(ExceptionStatus) shape_createHausdorffDistanceExtractor(
    int distanceFlag, float rankProp, cv::Ptr<cv::HausdorffDistanceExtractor> **returnValue)
{
    BEGIN_WRAP
    const auto p = cv::createHausdorffDistanceExtractor(
        distanceFlag, rankProp);
    *returnValue = clone(p);
    END_WRAP
}

#pragma endregion

#endif