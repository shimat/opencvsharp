#pragma once

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>

CVAPI(ExceptionStatus) cuda_DeviceInfo_new1(cv::cuda::DeviceInfo **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::DeviceInfo();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_new2(int deviceId, cv::cuda::DeviceInfo **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::DeviceInfo(deviceId);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_delete(cv::cuda::DeviceInfo *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_asyncEngineCount(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->asyncEngineCount();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_canMapHostMemory(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->canMapHostMemory() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_clockRate(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->clockRate();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_computeMode(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->computeMode());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_concurrentKernels(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->concurrentKernels() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_deviceID(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->deviceID();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_ECCEnabled(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->ECCEnabled() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_freeMemory(cv::cuda::DeviceInfo *obj, uint64_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<uint64_t>(obj->freeMemory());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_integrated(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->integrated() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_isCompatible(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isCompatible() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_kernelExecTimeoutEnabled(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->kernelExecTimeoutEnabled() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_l2CacheSize(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->l2CacheSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_majorVersion(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->majorVersion();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxGridSize(cv::cuda::DeviceInfo *obj, cv::Vec3i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxGridSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxSurface1D(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxSurface1D();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxSurface1DLayered(cv::cuda::DeviceInfo *obj, cv::Vec2i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxSurface1DLayered();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxSurface2D(cv::cuda::DeviceInfo *obj, cv::Vec2i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxSurface2D();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxSurface2DLayered(cv::cuda::DeviceInfo *obj, cv::Vec3i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxSurface2DLayered();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxSurface3D(cv::cuda::DeviceInfo *obj, cv::Vec3i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxSurface3D();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxSurfaceCubemap(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxSurfaceCubemap();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxSurfaceCubemapLayered(cv::cuda::DeviceInfo *obj, cv::Vec2i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxSurfaceCubemapLayered();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture1D(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture1D();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture1DLayered(cv::cuda::DeviceInfo *obj, cv::Vec2i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture1DLayered();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture1DLinear(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture1DLinear();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture1DMipmap(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture1DMipmap();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture2D(cv::cuda::DeviceInfo *obj, cv::Vec2i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture2D();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture2DGather(cv::cuda::DeviceInfo *obj, cv::Vec2i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture2DGather();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture2DLayered(cv::cuda::DeviceInfo *obj, cv::Vec3i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture2DLayered();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture2DLinear(cv::cuda::DeviceInfo *obj, cv::Vec3i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture2DLinear();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture2DMipmap(cv::cuda::DeviceInfo *obj, cv::Vec2i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture2DMipmap();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTexture3D(cv::cuda::DeviceInfo *obj, cv::Vec3i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTexture3D();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTextureCubemap(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTextureCubemap();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxTextureCubemapLayered(cv::cuda::DeviceInfo *obj, cv::Vec2i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxTextureCubemapLayered();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxThreadsDim(cv::cuda::DeviceInfo *obj, cv::Vec3i *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxThreadsDim();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxThreadsPerBlock(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxThreadsPerBlock();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_maxThreadsPerMultiProcessor(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->maxThreadsPerMultiProcessor();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_memoryBusWidth(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->memoryBusWidth();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_memoryClockRate(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->memoryClockRate();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_memPitch(cv::cuda::DeviceInfo *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->memPitch();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_minorVersion(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->minorVersion();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_multiProcessorCount(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->multiProcessorCount();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_name(cv::cuda::DeviceInfo *obj, char *buf, int bufLength)
{
    BEGIN_WRAP
    copyString(obj->name(), buf, bufLength);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_pciBusID(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->pciBusID();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_pciDeviceID(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->pciDeviceID();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_pciDomainID(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->pciDomainID();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_queryMemory(cv::cuda::DeviceInfo *obj, uint64_t *totalMemory, uint64_t *freeMemory)
{
    BEGIN_WRAP
    size_t totalMemory0, freeMemory0;
    obj->queryMemory(totalMemory0, freeMemory0);
    *totalMemory = static_cast<uint64_t>(totalMemory0);
    *freeMemory = static_cast<uint64_t>(freeMemory0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_regsPerBlock(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->regsPerBlock();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_sharedMemPerBlock(cv::cuda::DeviceInfo *obj, uint64_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<uint64_t>(obj->sharedMemPerBlock());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_supports(cv::cuda::DeviceInfo *obj, int feature_set, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->supports(static_cast<cv::cuda::FeatureSet>(feature_set)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_surfaceAlignment(cv::cuda::DeviceInfo *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->surfaceAlignment();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_tccDriver(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->tccDriver() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_textureAlignment(cv::cuda::DeviceInfo *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->textureAlignment();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_texturePitchAlignment(cv::cuda::DeviceInfo *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->texturePitchAlignment();
    END_WRAP
}


CVAPI(ExceptionStatus) cuda_DeviceInfo_totalConstMem(cv::cuda::DeviceInfo *obj, uint64_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<uint64_t>(obj->totalConstMem());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_totalGlobalMem(cv::cuda::DeviceInfo *obj, uint64_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<uint64_t>(obj->totalGlobalMem());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_totalMemory(cv::cuda::DeviceInfo *obj, uint64_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<uint64_t>(obj->totalMemory());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_unifiedAddressing(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->unifiedAddressing() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_DeviceInfo_warpSize(cv::cuda::DeviceInfo *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->warpSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_getCudaEnabledDeviceCount(int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::getCudaEnabledDeviceCount();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_setDevice(int device)
{
    BEGIN_WRAP
    cv::cuda::setDevice(device);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_getDevice(int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::getDevice();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_resetDevice()
{
    BEGIN_WRAP
    cv::cuda::resetDevice();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_deviceSupports(int feature_set, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::deviceSupports(static_cast<cv::cuda::FeatureSet>(feature_set)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_printCudaDeviceInfo(int device)
{
    BEGIN_WRAP
    cv::cuda::printCudaDeviceInfo(device);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_printShortCudaDeviceInfo(int device)
{
    BEGIN_WRAP
    cv::cuda::printShortCudaDeviceInfo(device);
    END_WRAP
}
