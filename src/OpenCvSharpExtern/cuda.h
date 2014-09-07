#if WIN32
#pragma once
#endif

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

#pragma region CudaMem

CVAPI(void) cuda_registerPageLocked(cv::Mat *m)
{
	registerPageLocked(*m);
}
CVAPI(void) cuda_unregisterPageLocked(cv::Mat *m)
{
	unregisterPageLocked(*m);
}

CVAPI(CudaMem*) cuda_CudaMem_new1()
{
	return new CudaMem();
}
CVAPI(CudaMem*) cuda_CudaMem_new2(CudaMem *m)
{
	return new CudaMem(*m);
}
CVAPI(CudaMem*) cuda_CudaMem_new3(int rows, int cols, int type)
{
	return new CudaMem(rows, cols, type);
}
CVAPI(CudaMem*) cuda_CudaMem_new4(cv::_InputArray *m)
{
	return new CudaMem(*m);
}

CVAPI(void) cuda_CudaMem_delete(CudaMem *m)
{
	delete m;
}

CVAPI(void) cuda_CudaMem_opAssign(CudaMem *left, CudaMem *right)
{
	*left = *right;
}

CVAPI(CudaMem*) cuda_CudaMem_clone(CudaMem *obj)
{
	CudaMem ret = obj->clone();
	return new CudaMem(ret);
}

CVAPI(void) cuda_CudaMem_create(CudaMem *obj, int rows, int cols, int type)
{
	obj->create(rows, cols, type);
}

CVAPI(void) cuda_CudaMem_release(CudaMem *obj)
{
	obj->release();
}

CVAPI(cv::Mat*) cuda_CudaMem_createMatHeader(CudaMem *obj)
{
	cv::Mat ret = obj->createMatHeader();
	return new cv::Mat(ret);
}

CVAPI(GpuMat*) cuda_CudaMem_createGpuMatHeader(CudaMem *obj)
{
	GpuMat ret = obj->createGpuMatHeader();
	return new GpuMat(ret);
}

CVAPI(int) cuda_CudaMem_isContinuous(CudaMem *obj)
{
	return obj->isContinuous() ? 1 : 0;
}
CVAPI(uint64) cuda_CudaMem_elemSize(CudaMem *obj)
{
	return static_cast<uint64>(obj->elemSize());
}
CVAPI(uint64) cuda_CudaMem_elemSize1(CudaMem *obj)
{
	return static_cast<uint64>(obj->elemSize1());
}
CVAPI(int) cuda_CudaMem_type(CudaMem *obj)
{
	return obj->type();
}
CVAPI(int) cuda_CudaMem_depth(CudaMem *obj)
{
	return obj->depth();
}
CVAPI(int) cuda_CudaMem_channels(CudaMem *obj)
{
	return obj->channels();
}
CVAPI(uint64) cuda_CudaMem_step1(CudaMem *obj)
{
	return static_cast<uint64>(obj->step1());
}
CVAPI(CvSize) cuda_CudaMem_size(CudaMem *obj)
{
	return (CvSize)obj->size();
}
CVAPI(int) cuda_CudaMem_empty(CudaMem *obj)
{
	return obj->empty() ? 1: 0;
}

CVAPI(int) cuda_CudaMem_flags(CudaMem *obj)
{
	return obj->flags;
}
CVAPI(int) cuda_CudaMem_rows(CudaMem *obj)
{
	return obj->rows;
}
CVAPI(int) cuda_CudaMem_cols(CudaMem *obj)
{
	return obj->cols;
}
CVAPI(uint64) cuda_CudaMem_step(CudaMem *obj)
{
	return static_cast<uint64>(obj->step);
}

CVAPI(uchar*) cuda_CudaMem_data(CudaMem *obj)
{
	return obj->data;
}
CVAPI(int*) cuda_CudaMem_refcount(CudaMem *obj)
{
	return obj->refcount;
}

CVAPI(uchar*) cuda_CudaMem_datastart(CudaMem *obj)
{
	return obj->datastart;
}
CVAPI(const uchar*) cuda_CudaMem_dataend(CudaMem *obj)
{
	return obj->dataend;
}

CVAPI(int) cuda_CudaMem_alloc_type(CudaMem *obj)
{
	return obj->alloc_type;
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