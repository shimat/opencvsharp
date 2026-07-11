#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region VGG

CVAPI(ExceptionStatus) xfeatures2d_VGG_create(
    int desc, float isigma, int imgNormalize, int useScaleOrientation, float scaleFactor, int dscNormalize,
    cv::Ptr<cv::xfeatures2d::VGG> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::VGG::create(
            desc, isigma, imgNormalize != 0, useScaleOrientation != 0, scaleFactor, dscNormalize != 0);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_VGG_delete(cv::Ptr<cv::xfeatures2d::VGG> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_VGG_get(cv::Ptr<cv::xfeatures2d::VGG> *obj, cv::xfeatures2d::VGG **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_VGG_setSigma(cv::xfeatures2d::VGG *obj, float val)
{
    return cvTry([&] { obj->setSigma(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_VGG_getSigma(cv::xfeatures2d::VGG *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getSigma(); });
}

CVAPI(ExceptionStatus) xfeatures2d_VGG_setUseNormalizeImage(cv::xfeatures2d::VGG *obj, int val)
{
    return cvTry([&] { obj->setUseNormalizeImage(val != 0); });
}
CVAPI(ExceptionStatus) xfeatures2d_VGG_getUseNormalizeImage(cv::xfeatures2d::VGG *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getUseNormalizeImage() ? 1 : 0; });
}

CVAPI(ExceptionStatus) xfeatures2d_VGG_setUseScaleOrientation(cv::xfeatures2d::VGG *obj, int val)
{
    return cvTry([&] { obj->setUseScaleOrientation(val != 0); });
}
CVAPI(ExceptionStatus) xfeatures2d_VGG_getUseScaleOrientation(cv::xfeatures2d::VGG *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getUseScaleOrientation() ? 1 : 0; });
}

CVAPI(ExceptionStatus) xfeatures2d_VGG_setScaleFactor(cv::xfeatures2d::VGG *obj, float val)
{
    return cvTry([&] { obj->setScaleFactor(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_VGG_getScaleFactor(cv::xfeatures2d::VGG *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getScaleFactor(); });
}

CVAPI(ExceptionStatus) xfeatures2d_VGG_setUseNormalizeDescriptor(cv::xfeatures2d::VGG *obj, int val)
{
    return cvTry([&] { obj->setUseNormalizeDescriptor(val != 0); });
}
CVAPI(ExceptionStatus) xfeatures2d_VGG_getUseNormalizeDescriptor(cv::xfeatures2d::VGG *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getUseNormalizeDescriptor() ? 1 : 0; });
}

#pragma endregion

#pragma region BoostDesc

CVAPI(ExceptionStatus) xfeatures2d_BoostDesc_create(
    int desc, int useScaleOrientation, float scaleFactor,
    cv::Ptr<cv::xfeatures2d::BoostDesc> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::BoostDesc::create(desc, useScaleOrientation != 0, scaleFactor);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_BoostDesc_delete(cv::Ptr<cv::xfeatures2d::BoostDesc> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_BoostDesc_get(cv::Ptr<cv::xfeatures2d::BoostDesc> *obj, cv::xfeatures2d::BoostDesc **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BoostDesc_setUseScaleOrientation(cv::xfeatures2d::BoostDesc *obj, int val)
{
    return cvTry([&] { obj->setUseScaleOrientation(val != 0); });
}
CVAPI(ExceptionStatus) xfeatures2d_BoostDesc_getUseScaleOrientation(cv::xfeatures2d::BoostDesc *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getUseScaleOrientation() ? 1 : 0; });
}

CVAPI(ExceptionStatus) xfeatures2d_BoostDesc_setScaleFactor(cv::xfeatures2d::BoostDesc *obj, float val)
{
    return cvTry([&] { obj->setScaleFactor(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_BoostDesc_getScaleFactor(cv::xfeatures2d::BoostDesc *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getScaleFactor(); });
}

#pragma endregion

#endif // NO_CONTRIB
