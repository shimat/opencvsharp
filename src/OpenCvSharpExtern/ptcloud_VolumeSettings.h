#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#ifndef NO_PTCLOUD

#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_new(int volumeType, cv::VolumeSettings **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::VolumeSettings(static_cast<cv::VolumeType>(volumeType));
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_delete(cv::VolumeSettings *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setIntegrateWidth(cv::VolumeSettings *obj, int val)
{
    return cvTry([&] {
        obj->setIntegrateWidth(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getIntegrateWidth(cv::VolumeSettings *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getIntegrateWidth();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setIntegrateHeight(cv::VolumeSettings *obj, int val)
{
    return cvTry([&] {
        obj->setIntegrateHeight(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getIntegrateHeight(cv::VolumeSettings *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getIntegrateHeight();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setRaycastWidth(cv::VolumeSettings *obj, int val)
{
    return cvTry([&] {
        obj->setRaycastWidth(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getRaycastWidth(cv::VolumeSettings *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRaycastWidth();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setRaycastHeight(cv::VolumeSettings *obj, int val)
{
    return cvTry([&] {
        obj->setRaycastHeight(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getRaycastHeight(cv::VolumeSettings *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRaycastHeight();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setDepthFactor(cv::VolumeSettings *obj, float val)
{
    return cvTry([&] {
        obj->setDepthFactor(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getDepthFactor(cv::VolumeSettings *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDepthFactor();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setVoxelSize(cv::VolumeSettings *obj, float val)
{
    return cvTry([&] {
        obj->setVoxelSize(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getVoxelSize(cv::VolumeSettings *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getVoxelSize();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setTsdfTruncateDistance(cv::VolumeSettings *obj, float val)
{
    return cvTry([&] {
        obj->setTsdfTruncateDistance(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getTsdfTruncateDistance(cv::VolumeSettings *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getTsdfTruncateDistance();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setMaxDepth(cv::VolumeSettings *obj, float val)
{
    return cvTry([&] {
        obj->setMaxDepth(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getMaxDepth(cv::VolumeSettings *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMaxDepth();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setMaxWeight(cv::VolumeSettings *obj, int val)
{
    return cvTry([&] {
        obj->setMaxWeight(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getMaxWeight(cv::VolumeSettings *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMaxWeight();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setRaycastStepFactor(cv::VolumeSettings *obj, float val)
{
    return cvTry([&] {
        obj->setRaycastStepFactor(val);
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getRaycastStepFactor(cv::VolumeSettings *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRaycastStepFactor();
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setVolumePose(cv::VolumeSettings *obj, const interop::InputArrayProxy* val)
{
    return cvTry([&] {
        obj->setVolumePose(InProxy(*val));
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getVolumePose(cv::VolumeSettings *obj, const interop::OutputArrayProxy* val)
{
    return cvTry([&] {
        obj->getVolumePose(OutProxy(*val));
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setVolumeResolution(cv::VolumeSettings *obj, const interop::InputArrayProxy* val)
{
    return cvTry([&] {
        obj->setVolumeResolution(InProxy(*val));
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getVolumeResolution(cv::VolumeSettings *obj, const interop::OutputArrayProxy* val)
{
    return cvTry([&] {
        obj->getVolumeResolution(OutProxy(*val));
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getVolumeStrides(cv::VolumeSettings *obj, const interop::OutputArrayProxy* val)
{
    return cvTry([&] {
        obj->getVolumeStrides(OutProxy(*val));
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setCameraIntegrateIntrinsics(cv::VolumeSettings *obj, const interop::InputArrayProxy* val)
{
    return cvTry([&] {
        obj->setCameraIntegrateIntrinsics(InProxy(*val));
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getCameraIntegrateIntrinsics(cv::VolumeSettings *obj, const interop::OutputArrayProxy* val)
{
    return cvTry([&] {
        obj->getCameraIntegrateIntrinsics(OutProxy(*val));
    });
}

CVAPI(ExceptionStatus) ptcloud_VolumeSettings_setCameraRaycastIntrinsics(cv::VolumeSettings *obj, const interop::InputArrayProxy* val)
{
    return cvTry([&] {
        obj->setCameraRaycastIntrinsics(InProxy(*val));
    });
}
CVAPI(ExceptionStatus) ptcloud_VolumeSettings_getCameraRaycastIntrinsics(cv::VolumeSettings *obj, const interop::OutputArrayProxy* val)
{
    return cvTry([&] {
        obj->getCameraRaycastIntrinsics(OutProxy(*val));
    });
}

#endif // NO_PTCLOUD
