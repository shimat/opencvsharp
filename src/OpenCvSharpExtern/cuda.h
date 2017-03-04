#ifndef _CPP_cuda_H_
#define _CPP_cuda_H_

#include "include_opencv.h"
using namespace cv::cuda;

#pragma region Device

CVAPI(int) cuda_getCudaEnabledDeviceCount()
{
    return getCudaEnabledDeviceCount();
}

CVAPI(void) cuda_setDevice(int device)
{
    setDevice(device);
}
CVAPI(int) cuda_getDevice()
{
    return getDevice();
}

CVAPI(void) cuda_resetDevice()
{
    resetDevice();
}

CVAPI(int) cuda_deviceSupports(int feature_set)
{
    return deviceSupports(
        static_cast<FeatureSet>(feature_set)) ? 1 : 0;
}

// TargetArchs
CVAPI(int) cuda_TargetArchs_builtWith(int feature_set)
{
    return TargetArchs::builtWith(
        static_cast<FeatureSet>(feature_set)) ? 1 : 0;
}
CVAPI(int) cuda_TargetArchs_has(int major, int minor)
{
    return TargetArchs::has(major, minor) ? 1 : 0;
}
CVAPI(int) cuda_TargetArchs_hasPtx(int major, int minor)
{
    return TargetArchs::hasPtx(major, minor) ? 1 : 0;
}
CVAPI(int) cuda_TargetArchs_hasBin(int major, int minor)
{
    return TargetArchs::hasBin(major, minor) ? 1 : 0;
}
CVAPI(int) cuda_TargetArchs_hasEqualOrLessPtx(int major, int minor)
{
    return TargetArchs::hasEqualOrLessPtx(major, minor) ? 1 : 0;
}
CVAPI(int) cuda_TargetArchs_hasEqualOrGreater(int major, int minor)
{
    return TargetArchs::hasEqualOrGreater(major, minor) ? 1 : 0;
}
CVAPI(int) cuda_TargetArchs_hasEqualOrGreaterPtx(int major, int minor)
{
    return TargetArchs::hasEqualOrGreaterPtx(major, minor) ? 1 : 0;
}
CVAPI(int) cuda_TargetArchs_hasEqualOrGreaterBin(int major, int minor)
{
    return TargetArchs::hasEqualOrGreaterBin(major, minor) ? 1 : 0;
}

// DeviceInfo
CVAPI(DeviceInfo*) cuda_DeviceInfo_new1()
{
    return new DeviceInfo();
}
CVAPI(DeviceInfo*) cuda_DeviceInfo_new2(int deviceId)
{
    return new DeviceInfo(deviceId);
}
CVAPI(void) cuda_DeviceInfo_delete(DeviceInfo *obj)
{
    delete obj;
}

CVAPI(void) cuda_DeviceInfo_name(DeviceInfo *obj, char *buf, int bufLength)
{ 
    copyString(obj->name(), buf, bufLength);
}
CVAPI(int) cuda_DeviceInfo_majorVersion(DeviceInfo *obj)
{ 
    return obj->majorVersion(); 
}
CVAPI(int) cuda_DeviceInfo_minorVersion(DeviceInfo *obj)
{ 
    return obj->minorVersion();
}
CVAPI(int) cuda_DeviceInfo_multiProcessorCount(DeviceInfo *obj)
{ 
    return obj->multiProcessorCount();
}
CVAPI(uint64) cuda_DeviceInfo_sharedMemPerBlock(DeviceInfo *obj)
{
    return obj->sharedMemPerBlock();
}
CVAPI(void) cuda_DeviceInfo_queryMemory(
    DeviceInfo *obj, uint64 *totalMemory, uint64 *freeMemory)
{
    size_t totalMemory0, freeMemory0;
    obj->queryMemory(totalMemory0, freeMemory0);
    *totalMemory = totalMemory0;
    *freeMemory = freeMemory0;
}
CVAPI(uint64) cuda_DeviceInfo_freeMemory(DeviceInfo *obj)
{
    return obj->freeMemory();
}
CVAPI(uint64) cuda_DeviceInfo_totalMemory(DeviceInfo *obj)
{
    return obj->totalMemory();
}
CVAPI(int) cuda_DeviceInfo_supports(DeviceInfo *obj, int feature_set)
{
    return obj->supports(static_cast<FeatureSet>(feature_set)) ? 1 : 0;
}
CVAPI(int) cuda_DeviceInfo_isCompatible(DeviceInfo *obj)
{
    return obj->isCompatible() ? 1 : 0;
}
CVAPI(int) cuda_DeviceInfo_deviceID(DeviceInfo *obj)
{
    return obj->deviceID();
}
CVAPI(int) cuda_DeviceInfo_canMapHostMemory(DeviceInfo *obj)
{
    return obj->canMapHostMemory() ? 1 : 0;
}


CVAPI(void) cuda_printCudaDeviceInfo(int device)
{
    printCudaDeviceInfo(device);
}
CVAPI(void) cuda_printShortCudaDeviceInfo(int device)
{
    printShortCudaDeviceInfo(device);
}

#pragma endregion

#pragma region Stream

CVAPI(Stream*) cuda_Stream_new1()
{
    return new Stream();
}
CVAPI(Stream*) cuda_Stream_new2(Stream* s)
{
    return new Stream(*s);
}

CVAPI(void) cuda_Stream_delete(Stream *obj)
{
    delete obj;
}

CVAPI(void) cuda_Stream_opAssign(Stream *left, Stream *right)
{
    *left = *right;
}

CVAPI(int) cuda_Stream_queryIfComplete(Stream *obj)
{
    return obj->queryIfComplete() ? 1 : 0;
}
CVAPI(void) cuda_Stream_waitForCompletion(Stream *obj)
{
    obj->waitForCompletion();
}

CVAPI(void) cuda_Stream_enqueueHostCallback(
    Stream *obj, Stream::StreamCallback callback, void* userData)
{
    obj->enqueueHostCallback(callback, userData);
}

CVAPI(Stream*) cuda_Stream_Null()
{
    return &Stream::Null();
}

CVAPI(int) cuda_Stream_bool(Stream *obj)
{
    return (bool)(*obj) ? 1 : 0;
}

#pragma endregion

#endif