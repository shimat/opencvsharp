#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region HarrisLaplaceFeatureDetector

CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_create(
    int numOctaves, float cornThresh, float dogThresh, int maxCorners, int numLayers,
    cv::Ptr<cv::xfeatures2d::HarrisLaplaceFeatureDetector> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::HarrisLaplaceFeatureDetector::create(
            numOctaves, cornThresh, dogThresh, maxCorners, numLayers);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_HarrisLaplaceFeatureDetector_delete(cv::Ptr<cv::xfeatures2d::HarrisLaplaceFeatureDetector> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_HarrisLaplaceFeatureDetector_get(
    cv::Ptr<cv::xfeatures2d::HarrisLaplaceFeatureDetector> *obj, cv::xfeatures2d::HarrisLaplaceFeatureDetector **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_setNumOctaves(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, int val)
{
    return cvTry([&] { obj->setNumOctaves(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_getNumOctaves(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNumOctaves(); });
}

CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_setCornThresh(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, float val)
{
    return cvTry([&] { obj->setCornThresh(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_getCornThresh(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getCornThresh(); });
}

CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_setDOGThresh(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, float val)
{
    return cvTry([&] { obj->setDOGThresh(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_getDOGThresh(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getDOGThresh(); });
}

CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_setMaxCorners(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, int val)
{
    return cvTry([&] { obj->setMaxCorners(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_getMaxCorners(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getMaxCorners(); });
}

CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_setNumLayers(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, int val)
{
    return cvTry([&] { obj->setNumLayers(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_HarrisLaplaceFeatureDetector_getNumLayers(cv::xfeatures2d::HarrisLaplaceFeatureDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNumLayers(); });
}

#pragma endregion

#pragma region TBMR

CVAPI(ExceptionStatus) xfeatures2d_TBMR_create(
    int minArea, float maxAreaRelative, float scaleFactor, int nScales,
    cv::Ptr<cv::xfeatures2d::TBMR> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::TBMR::create(minArea, maxAreaRelative, scaleFactor, nScales);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_TBMR_delete(cv::Ptr<cv::xfeatures2d::TBMR> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_TBMR_get(cv::Ptr<cv::xfeatures2d::TBMR> *obj, cv::xfeatures2d::TBMR **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_TBMR_setMinArea(cv::xfeatures2d::TBMR *obj, int val)
{
    return cvTry([&] { obj->setMinArea(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_TBMR_getMinArea(cv::xfeatures2d::TBMR *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getMinArea(); });
}

CVAPI(ExceptionStatus) xfeatures2d_TBMR_setMaxAreaRelative(cv::xfeatures2d::TBMR *obj, float val)
{
    return cvTry([&] { obj->setMaxAreaRelative(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_TBMR_getMaxAreaRelative(cv::xfeatures2d::TBMR *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getMaxAreaRelative(); });
}

CVAPI(ExceptionStatus) xfeatures2d_TBMR_setScaleFactor(cv::xfeatures2d::TBMR *obj, float val)
{
    return cvTry([&] { obj->setScaleFactor(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_TBMR_getScaleFactor(cv::xfeatures2d::TBMR *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getScaleFactor(); });
}

CVAPI(ExceptionStatus) xfeatures2d_TBMR_setNScales(cv::xfeatures2d::TBMR *obj, int val)
{
    return cvTry([&] { obj->setNScales(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_TBMR_getNScales(cv::xfeatures2d::TBMR *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNScales(); });
}

#pragma endregion

#endif // NO_CONTRIB
