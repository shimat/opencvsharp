#ifndef _CPP_GPU_H_
#define _CPP_GPU_H_

#include "include_opencv.h"
using namespace cv::gpu;

#pragma region Device

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

#pragma endregion

#pragma region CudaMem

CVAPI(void) gpu_registerPageLocked(cv::Mat *m)
{
	registerPageLocked(*m);
}
CVAPI(void) gpu_unregisterPageLocked(cv::Mat *m)
{
	unregisterPageLocked(*m);
}

CVAPI(CudaMem*) gpu_CudaMem_new1()
{
	return new CudaMem();
}
CVAPI(CudaMem*) gpu_CudaMem_new2(CudaMem *m)
{
	return new CudaMem(*m);
}
CVAPI(CudaMem*) gpu_CudaMem_new3(int rows, int cols, int type, int allocType)
{
	return new CudaMem(rows, cols, type, allocType);
}
CVAPI(CudaMem*) gpu_CudaMem_new4(cv::Mat *m, int allocType)
{
	return new CudaMem(*m, allocType);
}

CVAPI(void) gpu_CudaMem_delete(CudaMem *m)
{
	delete m;
}

CVAPI(void) gpu_CudaMem_opAssign(CudaMem *left, CudaMem *right)
{
	*left = *right;
}

CVAPI(CudaMem*) gpu_CudaMem_clone(CudaMem *obj)
{
	CudaMem ret = obj->clone();
	return new CudaMem(ret);
}

CVAPI(void) gpu_CudaMem_create(CudaMem *obj, int rows, int cols, int type, int allocType)
{
	obj->create(rows, cols, type, allocType);
}

CVAPI(void) gpu_CudaMem_release(CudaMem *obj)
{
	obj->release();
}

CVAPI(cv::Mat*) gpu_CudaMem_createMatHeader(CudaMem *obj)
{
	cv::Mat ret = obj->createMatHeader();
	return new cv::Mat(ret);
}

CVAPI(GpuMat*) gpu_CudaMem_createGpuMatHeader(CudaMem *obj)
{
	GpuMat ret = obj->createGpuMatHeader();
	return new GpuMat(ret);
}

CVAPI(int) gpu_CudaMem_canMapHostMemory()
{
	return CudaMem::canMapHostMemory() ? 1 : 0;
}

CVAPI(int) gpu_CudaMem_isContinuous(CudaMem *obj)
{
	return obj->isContinuous() ? 1 : 0;
}
CVAPI(uint64) gpu_CudaMem_elemSize(CudaMem *obj)
{
	return static_cast<uint64>(obj->elemSize());
}
CVAPI(uint64) gpu_CudaMem_elemSize1(CudaMem *obj)
{
	return static_cast<uint64>(obj->elemSize1());
}
CVAPI(int) gpu_CudaMem_type(CudaMem *obj)
{
	return obj->type();
}
CVAPI(int) gpu_CudaMem_depth(CudaMem *obj)
{
	return obj->depth();
}
CVAPI(int) gpu_CudaMem_channels(CudaMem *obj)
{
	return obj->channels();
}
CVAPI(uint64) gpu_CudaMem_step1(CudaMem *obj)
{
	return static_cast<uint64>(obj->step1());
}
CVAPI(CvSize) gpu_CudaMem_size(CudaMem *obj)
{
	return (CvSize)obj->size();
}
CVAPI(int) gpu_CudaMem_empty(CudaMem *obj)
{
	return obj->empty() ? 1: 0;
}

CVAPI(int) gpu_CudaMem_flags(CudaMem *obj)
{
	return obj->flags;
}
CVAPI(int) gpu_CudaMem_rows(CudaMem *obj)
{
	return obj->rows;
}
CVAPI(int) gpu_CudaMem_cols(CudaMem *obj)
{
	return obj->cols;
}
CVAPI(uint64) gpu_CudaMem_step(CudaMem *obj)
{
	return static_cast<uint64>(obj->step);
}

CVAPI(uchar*) gpu_CudaMem_data(CudaMem *obj)
{
	return obj->data;
}
CVAPI(int*) gpu_CudaMem_refcount(CudaMem *obj)
{
	return obj->refcount;
}

CVAPI(uchar*) gpu_CudaMem_datastart(CudaMem *obj)
{
	return obj->datastart;
}
CVAPI(uchar*) gpu_CudaMem_dataend(CudaMem *obj)
{
	return obj->dataend;
}

CVAPI(int) gpu_CudaMem_alloc_type(CudaMem *obj)
{
	return obj->alloc_type;
}

#pragma endregion

#pragma region Stream

CVAPI(Stream*) gpu_Stream_new1()
{
	return new Stream();
}
CVAPI(Stream*) gpu_Stream_new2(Stream* s)
{
	return new Stream(*s);
}

CVAPI(void) gpu_Stream_delete(Stream *obj)
{
	delete obj;
}

CVAPI(void) gpu_Stream_opAssign(Stream *left, Stream *right)
{
	*left = *right;
}

CVAPI(int) gpu_Stream_queryIfComplete(Stream *obj)
{
	return obj->queryIfComplete() ? 1 : 0;
}
CVAPI(void) gpu_Stream_waitForCompletion(Stream *obj)
{
	obj->waitForCompletion();
}

CVAPI(void) gpu_Stream_enqueueDownload_CudaMem(Stream *obj, GpuMat *src, CudaMem *dst)
{
	obj->enqueueDownload(*src, *dst);
}
CVAPI(void) gpu_Stream_enqueueDownload_Mat(Stream *obj, GpuMat *src, cv::Mat *dst)
{
	obj->enqueueDownload(*src, *dst);
}

CVAPI(void) gpu_Stream_enqueueUpload_CudaMem(Stream *obj, CudaMem *src, GpuMat *dst)
{
	obj->enqueueUpload(*src, *dst);
}
CVAPI(void) gpu_Stream_enqueueUpload_Mat(Stream *obj, cv::Mat *src, GpuMat *dst)
{
	obj->enqueueUpload(*src, *dst);
}

CVAPI(void) gpu_Stream_enqueueCopy(Stream *obj, GpuMat *src, GpuMat *dst)
{
	obj->enqueueCopy(*src, *dst);
}

CVAPI(void) gpu_Stream_enqueueMemSet(Stream *obj, GpuMat *src, CvScalar val)
{
	obj->enqueueMemSet(*src, val);
}
CVAPI(void) gpu_Stream_enqueueMemSet_WithMask(Stream *obj, GpuMat *src, CvScalar val, GpuMat *mask)
{
	obj->enqueueMemSet(*src, val, *mask);
}

CVAPI(void) gpu_Stream_enqueueConvert(
	Stream *obj, GpuMat *src, GpuMat *dst, int dtype, double a, double b)
{
	obj->enqueueConvert(*src, *dst, dtype, a, b);
}

CVAPI(void) gpu_Stream_enqueueHostCallback(
	Stream *obj, Stream::StreamCallback callback, void* userData)
{
	obj->enqueueHostCallback(callback, userData);
}

CVAPI(Stream*) gpu_Stream_Null()
{
	return &Stream::Null();
}

CVAPI(int) gpu_Stream_bool(Stream *obj)
{
	return (bool)(*obj) ? 1 : 0;
}

#pragma endregion

#endif