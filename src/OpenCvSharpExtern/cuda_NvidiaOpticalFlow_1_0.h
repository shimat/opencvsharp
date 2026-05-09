#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudaoptflow.hpp>

CVAPI(ExceptionStatus) cuda_createNvidiaOpticalFlow_1_0(
    cv::Size imageSize, int perfPreset, int enableTemporalHints,
    int enableExternalHints, int enableCostBuffer, int gpuId,
    cv::cuda::Stream *inputStream, cv::cuda::Stream *outputStream,
    cv::Ptr<cv::cuda::NvidiaOpticalFlow_1_0> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::NvidiaOpticalFlow_1_0::create(
        imageSize,
        static_cast<cv::cuda::NvidiaOpticalFlow_1_0::NVIDIA_OF_PERF_LEVEL>(perfPreset),
        enableTemporalHints != 0,
        enableExternalHints != 0,
        enableCostBuffer != 0,
        gpuId,
        inputStream ? *inputStream : cv::cuda::Stream::Null(),
        outputStream ? *outputStream : cv::cuda::Stream::Null());
    *returnValue = new cv::Ptr<cv::cuda::NvidiaOpticalFlow_1_0>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_NvidiaOpticalFlow_1_0_get(
    cv::Ptr<cv::cuda::NvidiaOpticalFlow_1_0> *ptr, cv::cuda::NvidiaOpticalFlow_1_0 **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_NvidiaOpticalFlow_1_0_delete(cv::Ptr<cv::cuda::NvidiaOpticalFlow_1_0> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_NvidiaOpticalFlow_1_0_upSampler(
    cv::cuda::NvidiaOpticalFlow_1_0 *obj, cv::_InputArray *flow,
    cv::Size imageSize, int gridSize, cv::_InputOutputArray *upsampledFlow)
{
    BEGIN_WRAP
    obj->upSampler(*flow, imageSize, gridSize, *upsampledFlow);
    END_WRAP
}
