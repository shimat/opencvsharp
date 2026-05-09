#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile


#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>

CVAPI(ExceptionStatus) cuda_HostMem_new1(int alloc_type, cv::cuda::HostMem **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::HostMem(static_cast<cv::cuda::HostMem::AllocType>(alloc_type));
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_new2(int rows, int cols, int type, int alloc_type, cv::cuda::HostMem **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::HostMem(rows, cols, type, static_cast<cv::cuda::HostMem::AllocType>(alloc_type));
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_new3(cv::_InputArray *arr, int alloc_type, cv::cuda::HostMem **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::HostMem(*arr, static_cast<cv::cuda::HostMem::AllocType>(alloc_type));
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_delete(cv::cuda::HostMem *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_channels(cv::cuda::HostMem *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->channels();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_depth(cv::cuda::HostMem *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->depth();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_elemSize(cv::cuda::HostMem *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->elemSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_elemSize1(cv::cuda::HostMem *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->elemSize1();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_empty(cv::cuda::HostMem *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_isContinuous(cv::cuda::HostMem *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isContinuous() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_size(cv::cuda::HostMem *obj, cv::Size *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->size();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_step(cv::cuda::HostMem *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->step;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_step1(cv::cuda::HostMem *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->step1();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_type(cv::cuda::HostMem *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->type();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_clone(cv::cuda::HostMem *obj, cv::cuda::HostMem **returnValue)
{
    BEGIN_WRAP
    cv::cuda::HostMem res = obj->clone();
    *returnValue = new cv::cuda::HostMem(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_create(cv::cuda::HostMem *obj, int rows, int cols, int type)
{
    BEGIN_WRAP
    obj->create(rows, cols, type);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_createGpuMatHeader(cv::cuda::HostMem *obj, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    cv::cuda::GpuMat res = obj->createGpuMatHeader();
    *returnValue = new cv::cuda::GpuMat(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_createMatHeader(cv::cuda::HostMem *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    cv::Mat res = obj->createMatHeader();
    *returnValue = new cv::Mat(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_release(cv::cuda::HostMem *obj)
{
    BEGIN_WRAP
    obj->release();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_reshape(cv::cuda::HostMem *obj, int cn, int rows, cv::cuda::HostMem **returnValue)
{
    BEGIN_WRAP
    cv::cuda::HostMem res = obj->reshape(cn, rows);
    *returnValue = new cv::cuda::HostMem(res);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_swap(cv::cuda::HostMem *obj, cv::cuda::HostMem *other)
{
    BEGIN_WRAP
    obj->swap(*other);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_HostMem_assignFrom(cv::cuda::HostMem *obj, cv::cuda::HostMem *other)
{
    BEGIN_WRAP
    *obj = *other;
    END_WRAP
}
