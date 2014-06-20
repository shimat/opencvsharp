#ifndef _CPP_GPU_H_
#define _CPP_GPU_H_

#include "include_opencv.h"


CVAPI(int) gpu_getCudaEnabledDeviceCount()
{
	return cv::gpu::getCudaEnabledDeviceCount();
}

CVAPI(void) gpu_setDevice(int device)
{
	cv::gpu::setDevice(device);
}
CVAPI(int) gpu_getDevice()
{
	return cv::gpu::getDevice();
}

CVAPI(void) gpu_resetDevice()
{
    cv::gpu::resetDevice();
}

CVAPI(int) gpu_deviceSupports(int feature_set)
{
    return cv::gpu::deviceSupports(
        static_cast<cv::gpu::FeatureSet>(feature_set)) ? 1 : 0;
}

// TargetArchs
CVAPI(int) gpu_TargetArchs_builtWith(int feature_set)
{
    return cv::gpu::TargetArchs::builtWith(
        static_cast<cv::gpu::FeatureSet>(feature_set)) ? 1 : 0;
}
CVAPI(int) gpu_TargetArchs_has(int major, int minor)
{
    return cv::gpu::TargetArchs::has(major, minor) ? 1 : 0;
}
CVAPI(int) gpu_TargetArchs_hasPtx(int major, int minor)
{
    return cv::gpu::TargetArchs::hasPtx(major, minor) ? 1 : 0;
}
CVAPI(int) gpu_TargetArchs_hasBin(int major, int minor)
{
    return cv::gpu::TargetArchs::hasBin(major, minor) ? 1 : 0;
}
CVAPI(int) gpu_TargetArchs_hasEqualOrLessPtx(int major, int minor)
{
    return cv::gpu::TargetArchs::hasEqualOrLessPtx(major, minor) ? 1 : 0;
}
CVAPI(int) gpu_TargetArchs_hasEqualOrGreater(int major, int minor)
{
    return cv::gpu::TargetArchs::hasEqualOrGreater(major, minor) ? 1 : 0;
}
CVAPI(int) gpu_TargetArchs_hasEqualOrGreaterPtx(int major, int minor)
{
    return cv::gpu::TargetArchs::hasEqualOrGreaterPtx(major, minor) ? 1 : 0;
}
CVAPI(int) gpu_TargetArchs_hasEqualOrGreaterBin(int major, int minor)
{
    return cv::gpu::TargetArchs::hasEqualOrGreaterBin(major, minor) ? 1 : 0;
}

// DeviceInfo
CVAPI(cv::gpu::DeviceInfo*) gpu_DeviceInfo_new1()
{
    return new cv::gpu::DeviceInfo();
}
CVAPI(cv::gpu::DeviceInfo*) gpu_DeviceInfo_new2(int deviceId)
{
	return new cv::gpu::DeviceInfo(deviceId);
}
CVAPI(void) gpu_DeviceInfo_delete(cv::gpu::DeviceInfo *obj)
{
	delete obj;
}

CVAPI(void) gpu_DeviceInfo_name(cv::gpu::DeviceInfo *obj, char *buf, int bufLength)
{ 
    copyString(obj->name(), buf, bufLength);
}
CVAPI(int) gpu_DeviceInfo_majorVersion(cv::gpu::DeviceInfo *obj)
{ 
    return obj->majorVersion(); 
}
CVAPI(int) gpu_DeviceInfo_minorVersion(cv::gpu::DeviceInfo *obj)
{ 
    return obj->minorVersion();
}
CVAPI(int) gpu_DeviceInfo_multiProcessorCount(cv::gpu::DeviceInfo *obj)
{ 
    return obj->multiProcessorCount();
}
CVAPI(uint64) gpu_DeviceInfo_sharedMemPerBlock(cv::gpu::DeviceInfo *obj)
{
    return obj->sharedMemPerBlock();
}
CVAPI(void) gpu_DeviceInfo_queryMemory(
    cv::gpu::DeviceInfo *obj, uint64 *totalMemory, uint64 *freeMemory)
{
    size_t totalMemory0, freeMemory0;
    obj->queryMemory(totalMemory0, freeMemory0);
    *totalMemory = totalMemory0;
    *freeMemory = freeMemory0;
}
CVAPI(uint64) gpu_DeviceInfo_freeMemory(cv::gpu::DeviceInfo *obj)
{
    return obj->freeMemory();
}
CVAPI(uint64) gpu_DeviceInfo_totalMemory(cv::gpu::DeviceInfo *obj)
{
    return obj->totalMemory();
}
CVAPI(int) gpu_DeviceInfo_supports(cv::gpu::DeviceInfo *obj, int feature_set)
{
    return obj->supports(static_cast<cv::gpu::FeatureSet>(feature_set)) ? 1 : 0;
}
CVAPI(int) gpu_DeviceInfo_isCompatible(cv::gpu::DeviceInfo *obj)
{
    return obj->isCompatible() ? 1 : 0;
}
CVAPI(int) gpu_DeviceInfo_deviceID(cv::gpu::DeviceInfo *obj)
{
    return obj->deviceID();
}


CVAPI(void) gpu_printCudaDeviceInfo(int device)
{
    cv::gpu::printCudaDeviceInfo(device);
}
CVAPI(void) gpu_printShortCudaDeviceInfo(int device)
{
    cv::gpu::printShortCudaDeviceInfo(device);
}


#endif