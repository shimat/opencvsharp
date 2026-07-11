#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region MSDDetector

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_create(
    int patchRadius, int searchAreaRadius, int nmsRadius, int nmsScaleRadius, float thSaliency,
    int kNN, float scaleFactor, int nScales, int computeOrientation,
    cv::Ptr<cv::xfeatures2d::MSDDetector> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::MSDDetector::create(
            patchRadius, searchAreaRadius, nmsRadius, nmsScaleRadius, thSaliency,
            kNN, scaleFactor, nScales, computeOrientation != 0);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_MSDDetector_delete(cv::Ptr<cv::xfeatures2d::MSDDetector> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_MSDDetector_get(cv::Ptr<cv::xfeatures2d::MSDDetector> *obj, cv::xfeatures2d::MSDDetector **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_setPatchRadius(cv::xfeatures2d::MSDDetector *obj, int val)
{
    return cvTry([&] { obj->setPatchRadius(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_getPatchRadius(cv::xfeatures2d::MSDDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getPatchRadius(); });
}

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_setSearchAreaRadius(cv::xfeatures2d::MSDDetector *obj, int val)
{
    return cvTry([&] { obj->setSearchAreaRadius(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_getSearchAreaRadius(cv::xfeatures2d::MSDDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getSearchAreaRadius(); });
}

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_setNmsRadius(cv::xfeatures2d::MSDDetector *obj, int val)
{
    return cvTry([&] { obj->setNmsRadius(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_getNmsRadius(cv::xfeatures2d::MSDDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNmsRadius(); });
}

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_setNmsScaleRadius(cv::xfeatures2d::MSDDetector *obj, int val)
{
    return cvTry([&] { obj->setNmsScaleRadius(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_getNmsScaleRadius(cv::xfeatures2d::MSDDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNmsScaleRadius(); });
}

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_setThSaliency(cv::xfeatures2d::MSDDetector *obj, float val)
{
    return cvTry([&] { obj->setThSaliency(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_getThSaliency(cv::xfeatures2d::MSDDetector *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getThSaliency(); });
}

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_setKNN(cv::xfeatures2d::MSDDetector *obj, int val)
{
    return cvTry([&] { obj->setKNN(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_getKNN(cv::xfeatures2d::MSDDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getKNN(); });
}

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_setScaleFactor(cv::xfeatures2d::MSDDetector *obj, float val)
{
    return cvTry([&] { obj->setScaleFactor(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_getScaleFactor(cv::xfeatures2d::MSDDetector *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getScaleFactor(); });
}

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_setNScales(cv::xfeatures2d::MSDDetector *obj, int val)
{
    return cvTry([&] { obj->setNScales(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_getNScales(cv::xfeatures2d::MSDDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNScales(); });
}

CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_setComputeOrientation(cv::xfeatures2d::MSDDetector *obj, int val)
{
    return cvTry([&] { obj->setComputeOrientation(val != 0); });
}
CVAPI(ExceptionStatus) xfeatures2d_MSDDetector_getComputeOrientation(cv::xfeatures2d::MSDDetector *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getComputeOrientation() ? 1 : 0; });
}

#pragma endregion

#endif // NO_CONTRIB
