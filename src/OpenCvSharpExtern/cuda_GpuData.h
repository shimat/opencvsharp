#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>

CVAPI(ExceptionStatus) cuda_GpuData_new(size_t size, cv::cuda::GpuData **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuData(size);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuData_delete(cv::cuda::GpuData *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuData_data(cv::cuda::GpuData *obj, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->data;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuData_size(cv::cuda::GpuData *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->size;
    END_WRAP
}
