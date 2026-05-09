#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile


#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>

CVAPI(ExceptionStatus) cuda_GpuMatND_new1(cv::cuda::GpuMatND **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMatND();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_new2(int dims, int *sizes, int type, cv::cuda::GpuMatND **returnValue)
{
    BEGIN_WRAP
    std::vector<int> _sizes(sizes, sizes + dims);
    *returnValue = new cv::cuda::GpuMatND(_sizes, type);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_delete(cv::cuda::GpuMatND *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_create(cv::cuda::GpuMatND *obj, int dims, int *sizes, int type)
{
    BEGIN_WRAP
    std::vector<int> _sizes(sizes, sizes + dims);
    obj->create(_sizes, type);
    END_WRAP
}



CVAPI(ExceptionStatus) cuda_GpuMatND_empty(cv::cuda::GpuMatND *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_clone(
    cv::cuda::GpuMatND *obj,
    cv::cuda::GpuMatND **returnValue,
    cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    cv::cuda::GpuMatND res = obj->clone(streamRef);
    *returnValue = new cv::cuda::GpuMatND(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_createGpuMatHeader1(
    cv::cuda::GpuMatND *obj, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    cv::cuda::GpuMat res = obj->createGpuMatHeader();
    *returnValue = new cv::cuda::GpuMat(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_createGpuMatHeader2(
    cv::cuda::GpuMatND *obj,
    int *indices, 
    int indexCount,
    cv::Range rowRange,
    cv::Range colRange,
    cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    std::vector<int> idx(indices, indices + indexCount);
    cv::cuda::GpuMat res = obj->createGpuMatHeader(idx, rowRange, colRange);
    *returnValue = new cv::cuda::GpuMat(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_download(cv::cuda::GpuMatND *obj, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->download(*dst);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_download_stream(cv::cuda::GpuMatND *obj, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    cv::cuda::Stream &streamRef = stream ? *stream : cv::cuda::Stream::Null();
    obj->download(*dst, streamRef);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_elemSize(cv::cuda::GpuMatND *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->elemSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_elemSize1(cv::cuda::GpuMatND *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->elemSize1();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_external(cv::cuda::GpuMatND *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->external() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_getDevicePtr(cv::cuda::GpuMatND *obj, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDevicePtr();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_isContinuous(cv::cuda::GpuMatND *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isContinuous() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_isSubmatrix(cv::cuda::GpuMatND *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isSubmatrix() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_opToGpuMat(cv::cuda::GpuMatND *obj, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    cv::cuda::GpuMat res = (cv::cuda::GpuMat)*obj;
    *returnValue = new cv::cuda::GpuMat(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_opSubMat(
    cv::cuda::GpuMatND *obj, int *starts, int *ends, int count, cv::cuda::GpuMatND **returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Range> ranges;
    for (int i = 0; i < count; i++)
    {
        ranges.push_back(cv::Range(starts[i], ends[i]));
    }
    cv::cuda::GpuMatND res = (*obj)(ranges);
    *returnValue = new cv::cuda::GpuMatND(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_opIndex2D(
    cv::cuda::GpuMatND *obj, int *indices, int indexCount,
    cv::Range rowRange, cv::Range colRange, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    std::vector<int> idx(indices, indices + indexCount);
    cv::cuda::GpuMat res = (*obj)(idx, rowRange, colRange);
    *returnValue = new cv::cuda::GpuMat(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_opAssign(cv::cuda::GpuMatND *obj, cv::cuda::GpuMatND *other)
{
    BEGIN_WRAP
    *obj = *other;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_release(cv::cuda::GpuMatND *obj)
{
    BEGIN_WRAP
    obj->release();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_swap(cv::cuda::GpuMatND *obj, cv::cuda::GpuMatND *other)
{
    BEGIN_WRAP
    obj->swap(*other);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_total(cv::cuda::GpuMatND *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->total();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_totalMemSize(cv::cuda::GpuMatND *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->totalMemSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_type(cv::cuda::GpuMatND *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->type();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_upload(cv::cuda::GpuMatND *obj, cv::_InputArray *src)
{
    BEGIN_WRAP
    obj->upload(*src);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_upload_stream(cv::cuda::GpuMatND *obj, cv::_InputArray *src, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    obj->upload(*src, *stream);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_getDims(cv::cuda::GpuMatND *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->dims;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_getFlags(cv::cuda::GpuMatND *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->flags;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_getSize(cv::cuda::GpuMatND *obj, std::vector<int> *resultVector)
{
    BEGIN_WRAP
    *resultVector = obj->size;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMatND_getStep(cv::cuda::GpuMatND *obj, std::vector<uint64_t> *resultVector)
{
    BEGIN_WRAP
    resultVector->assign(obj->step.begin(), obj->step.end());
    END_WRAP
}
