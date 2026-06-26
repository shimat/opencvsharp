#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_new(cv::OdometrySettings **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::OdometrySettings();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_delete(cv::OdometrySettings *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setCameraMatrix(cv::OdometrySettings *obj, cv::_InputArray *val)
{
    BEGIN_WRAP
    obj->setCameraMatrix(entity(val));
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getCameraMatrix(cv::OdometrySettings *obj, cv::_OutputArray *val)
{
    BEGIN_WRAP
    obj->getCameraMatrix(entity(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setIterCounts(cv::OdometrySettings *obj, cv::_InputArray *val)
{
    BEGIN_WRAP
    obj->setIterCounts(entity(val));
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getIterCounts(cv::OdometrySettings *obj, cv::_OutputArray *val)
{
    BEGIN_WRAP
    obj->getIterCounts(entity(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMinDepth(cv::OdometrySettings *obj, float val)
{
    BEGIN_WRAP
    obj->setMinDepth(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMinDepth(cv::OdometrySettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinDepth();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxDepth(cv::OdometrySettings *obj, float val)
{
    BEGIN_WRAP
    obj->setMaxDepth(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxDepth(cv::OdometrySettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxDepth();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxDepthDiff(cv::OdometrySettings *obj, float val)
{
    BEGIN_WRAP
    obj->setMaxDepthDiff(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxDepthDiff(cv::OdometrySettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxDepthDiff();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxPointsPart(cv::OdometrySettings *obj, float val)
{
    BEGIN_WRAP
    obj->setMaxPointsPart(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxPointsPart(cv::OdometrySettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxPointsPart();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setSobelSize(cv::OdometrySettings *obj, int val)
{
    BEGIN_WRAP
    obj->setSobelSize(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getSobelSize(cv::OdometrySettings *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSobelSize();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setSobelScale(cv::OdometrySettings *obj, double val)
{
    BEGIN_WRAP
    obj->setSobelScale(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getSobelScale(cv::OdometrySettings *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSobelScale();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setNormalWinSize(cv::OdometrySettings *obj, int val)
{
    BEGIN_WRAP
    obj->setNormalWinSize(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getNormalWinSize(cv::OdometrySettings *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNormalWinSize();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setNormalDiffThreshold(cv::OdometrySettings *obj, float val)
{
    BEGIN_WRAP
    obj->setNormalDiffThreshold(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getNormalDiffThreshold(cv::OdometrySettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNormalDiffThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setNormalMethod(cv::OdometrySettings *obj, int nm)
{
    BEGIN_WRAP
    obj->setNormalMethod(static_cast<cv::RgbdNormals::RgbdNormalsMethod>(nm));
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getNormalMethod(cv::OdometrySettings *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->getNormalMethod());
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setAngleThreshold(cv::OdometrySettings *obj, float val)
{
    BEGIN_WRAP
    obj->setAngleThreshold(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getAngleThreshold(cv::OdometrySettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getAngleThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxTranslation(cv::OdometrySettings *obj, float val)
{
    BEGIN_WRAP
    obj->setMaxTranslation(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxTranslation(cv::OdometrySettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxTranslation();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMaxRotation(cv::OdometrySettings *obj, float val)
{
    BEGIN_WRAP
    obj->setMaxRotation(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMaxRotation(cv::OdometrySettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxRotation();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMinGradientMagnitude(cv::OdometrySettings *obj, float val)
{
    BEGIN_WRAP
    obj->setMinGradientMagnitude(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMinGradientMagnitude(cv::OdometrySettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinGradientMagnitude();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_OdometrySettings_setMinGradientMagnitudes(cv::OdometrySettings *obj, cv::_InputArray *val)
{
    BEGIN_WRAP
    obj->setMinGradientMagnitudes(entity(val));
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_OdometrySettings_getMinGradientMagnitudes(cv::OdometrySettings *obj, cv::_OutputArray *val)
{
    BEGIN_WRAP
    obj->getMinGradientMagnitudes(entity(val));
    END_WRAP
}

#endif // NO_PTCLOUD
