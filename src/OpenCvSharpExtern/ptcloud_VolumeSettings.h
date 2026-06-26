#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_new(int volumeType, cv::VolumeSettings **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::VolumeSettings(static_cast<cv::VolumeType>(volumeType));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_delete(cv::VolumeSettings *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setIntegrateWidth(cv::VolumeSettings *obj, int val)
{
    BEGIN_WRAP
    obj->setIntegrateWidth(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getIntegrateWidth(cv::VolumeSettings *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getIntegrateWidth();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setIntegrateHeight(cv::VolumeSettings *obj, int val)
{
    BEGIN_WRAP
    obj->setIntegrateHeight(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getIntegrateHeight(cv::VolumeSettings *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getIntegrateHeight();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setRaycastWidth(cv::VolumeSettings *obj, int val)
{
    BEGIN_WRAP
    obj->setRaycastWidth(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getRaycastWidth(cv::VolumeSettings *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRaycastWidth();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setRaycastHeight(cv::VolumeSettings *obj, int val)
{
    BEGIN_WRAP
    obj->setRaycastHeight(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getRaycastHeight(cv::VolumeSettings *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRaycastHeight();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setDepthFactor(cv::VolumeSettings *obj, float val)
{
    BEGIN_WRAP
    obj->setDepthFactor(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getDepthFactor(cv::VolumeSettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDepthFactor();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setVoxelSize(cv::VolumeSettings *obj, float val)
{
    BEGIN_WRAP
    obj->setVoxelSize(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getVoxelSize(cv::VolumeSettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getVoxelSize();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setTsdfTruncateDistance(cv::VolumeSettings *obj, float val)
{
    BEGIN_WRAP
    obj->setTsdfTruncateDistance(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getTsdfTruncateDistance(cv::VolumeSettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getTsdfTruncateDistance();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setMaxDepth(cv::VolumeSettings *obj, float val)
{
    BEGIN_WRAP
    obj->setMaxDepth(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getMaxDepth(cv::VolumeSettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxDepth();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setMaxWeight(cv::VolumeSettings *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxWeight(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getMaxWeight(cv::VolumeSettings *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxWeight();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setRaycastStepFactor(cv::VolumeSettings *obj, float val)
{
    BEGIN_WRAP
    obj->setRaycastStepFactor(val);
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getRaycastStepFactor(cv::VolumeSettings *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRaycastStepFactor();
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setVolumePose(cv::VolumeSettings *obj, cv::_InputArray *val)
{
    BEGIN_WRAP
    obj->setVolumePose(entity(val));
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getVolumePose(cv::VolumeSettings *obj, cv::_OutputArray *val)
{
    BEGIN_WRAP
    obj->getVolumePose(entity(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setVolumeResolution(cv::VolumeSettings *obj, cv::_InputArray *val)
{
    BEGIN_WRAP
    obj->setVolumeResolution(entity(val));
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getVolumeResolution(cv::VolumeSettings *obj, cv::_OutputArray *val)
{
    BEGIN_WRAP
    obj->getVolumeResolution(entity(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getVolumeStrides(cv::VolumeSettings *obj, cv::_OutputArray *val)
{
    BEGIN_WRAP
    obj->getVolumeStrides(entity(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setCameraIntegrateIntrinsics(cv::VolumeSettings *obj, cv::_InputArray *val)
{
    BEGIN_WRAP
    obj->setCameraIntegrateIntrinsics(entity(val));
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getCameraIntegrateIntrinsics(cv::VolumeSettings *obj, cv::_OutputArray *val)
{
    BEGIN_WRAP
    obj->getCameraIntegrateIntrinsics(entity(val));
    END_WRAP
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setCameraRaycastIntrinsics(cv::VolumeSettings *obj, cv::_InputArray *val)
{
    BEGIN_WRAP
    obj->setCameraRaycastIntrinsics(entity(val));
    END_WRAP
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getCameraRaycastIntrinsics(cv::VolumeSettings *obj, cv::_OutputArray *val)
{
    BEGIN_WRAP
    obj->getCameraRaycastIntrinsics(entity(val));
    END_WRAP
}

#endif // NO_PTCLOUD
