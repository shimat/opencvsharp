#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_new(cv::OdometrySettings **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::OdometrySettings();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_delete(cv::OdometrySettings *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setCameraMatrix(cv::OdometrySettings *obj, const interop::InputArrayProxy* val)
{
    return cvTry([&] {
    obj->setCameraMatrix(InProxy(*val));
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getCameraMatrix(cv::OdometrySettings *obj, const interop::OutputArrayProxy* val)
{
    return cvTry([&] {
    obj->getCameraMatrix(OutProxy(*val));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setIterCounts(cv::OdometrySettings *obj, const interop::InputArrayProxy* val)
{
    return cvTry([&] {
    obj->setIterCounts(InProxy(*val));
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getIterCounts(cv::OdometrySettings *obj, const interop::OutputArrayProxy* val)
{
    return cvTry([&] {
    obj->getIterCounts(OutProxy(*val));
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMinDepth(cv::OdometrySettings *obj, float val)
{
    return cvTry([&] {
    obj->setMinDepth(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMinDepth(cv::OdometrySettings *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMinDepth();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxDepth(cv::OdometrySettings *obj, float val)
{
    return cvTry([&] {
    obj->setMaxDepth(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxDepth(cv::OdometrySettings *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxDepth();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxDepthDiff(cv::OdometrySettings *obj, float val)
{
    return cvTry([&] {
    obj->setMaxDepthDiff(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxDepthDiff(cv::OdometrySettings *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxDepthDiff();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxPointsPart(cv::OdometrySettings *obj, float val)
{
    return cvTry([&] {
    obj->setMaxPointsPart(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxPointsPart(cv::OdometrySettings *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxPointsPart();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setSobelSize(cv::OdometrySettings *obj, int val)
{
    return cvTry([&] {
    obj->setSobelSize(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getSobelSize(cv::OdometrySettings *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSobelSize();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setSobelScale(cv::OdometrySettings *obj, double val)
{
    return cvTry([&] {
    obj->setSobelScale(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getSobelScale(cv::OdometrySettings *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSobelScale();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setNormalWinSize(cv::OdometrySettings *obj, int val)
{
    return cvTry([&] {
    obj->setNormalWinSize(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getNormalWinSize(cv::OdometrySettings *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNormalWinSize();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setNormalDiffThreshold(cv::OdometrySettings *obj, float val)
{
    return cvTry([&] {
    obj->setNormalDiffThreshold(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getNormalDiffThreshold(cv::OdometrySettings *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNormalDiffThreshold();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setNormalMethod(cv::OdometrySettings *obj, int nm)
{
    return cvTry([&] {
    obj->setNormalMethod(static_cast<cv::RgbdNormals::RgbdNormalsMethod>(nm));
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getNormalMethod(cv::OdometrySettings *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = static_cast<int>(obj->getNormalMethod());
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setAngleThreshold(cv::OdometrySettings *obj, float val)
{
    return cvTry([&] {
    obj->setAngleThreshold(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getAngleThreshold(cv::OdometrySettings *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getAngleThreshold();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxTranslation(cv::OdometrySettings *obj, float val)
{
    return cvTry([&] {
    obj->setMaxTranslation(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxTranslation(cv::OdometrySettings *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxTranslation();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxRotation(cv::OdometrySettings *obj, float val)
{
    return cvTry([&] {
    obj->setMaxRotation(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxRotation(cv::OdometrySettings *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxRotation();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMinGradientMagnitude(cv::OdometrySettings *obj, float val)
{
    return cvTry([&] {
    obj->setMinGradientMagnitude(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMinGradientMagnitude(cv::OdometrySettings *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMinGradientMagnitude();
    });
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMinGradientMagnitudes(cv::OdometrySettings *obj, const interop::InputArrayProxy* val)
{
    return cvTry([&] {
    obj->setMinGradientMagnitudes(InProxy(*val));
    });
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMinGradientMagnitudes(cv::OdometrySettings *obj, const interop::OutputArrayProxy* val)
{
    return cvTry([&] {
    obj->getMinGradientMagnitudes(OutProxy(*val));
    });
}

#endif // NO_PTCLOUD
