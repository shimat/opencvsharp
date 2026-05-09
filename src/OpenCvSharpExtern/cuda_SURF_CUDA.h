#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>
#include <opencv2/cudafeatures2d.hpp>
#include <opencv2/xfeatures2d/cuda.hpp>

CVAPI(ExceptionStatus) cuda_SURF_CUDA_new(
    double hessianThreshold, int nOctaves, int nOctaveLayers, int extended,
    float keypointsRatio, int upright, cv::Ptr<cv::cuda::SURF_CUDA> **returnValue)
{
    BEGIN_WRAP
    auto ptr = cv::cuda::SURF_CUDA::create(hessianThreshold, nOctaves, nOctaveLayers, extended != 0, keypointsRatio, upright != 0);
    *returnValue = new cv::Ptr<cv::cuda::SURF_CUDA>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_get(cv::Ptr<cv::cuda::SURF_CUDA> *ptr, cv::cuda::SURF_CUDA **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_delete(cv::Ptr<cv::cuda::SURF_CUDA> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_descriptorSize(cv::cuda::SURF_CUDA *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->descriptorSize();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_defaultNorm(cv::cuda::SURF_CUDA *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->defaultNorm();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_detect(
    cv::cuda::SURF_CUDA *obj, cv::cuda::GpuMat *img, cv::cuda::GpuMat *mask, cv::cuda::GpuMat *keypoints)
{
    BEGIN_WRAP
    obj->detect(*img, *mask, *keypoints);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_detectWithDescriptors(
    cv::cuda::SURF_CUDA *obj, cv::cuda::GpuMat *img, cv::cuda::GpuMat *mask,
    cv::cuda::GpuMat *keypoints, cv::cuda::GpuMat *descriptors, int useProvidedKeypoints)
{
    BEGIN_WRAP
    obj->detectWithDescriptors(*img, *mask, *keypoints, *descriptors, useProvidedKeypoints != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_downloadKeypoints(
    cv::cuda::SURF_CUDA *obj, cv::cuda::GpuMat *keypointsGPU, std::vector<cv::KeyPoint> *keypoints)
{
    BEGIN_WRAP
    obj->downloadKeypoints(*keypointsGPU, *keypoints);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_downloadDescriptors(
    cv::cuda::SURF_CUDA *obj, cv::cuda::GpuMat *descriptorsGPU, std::vector<float> *descriptors)
{
    BEGIN_WRAP
    obj->downloadDescriptors(*descriptorsGPU, *descriptors);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_uploadKeypoints(
    cv::cuda::SURF_CUDA *obj, std::vector<cv::KeyPoint> *keypoints, cv::cuda::GpuMat *keypointsGPU)
{
    BEGIN_WRAP
    obj->uploadKeypoints(*keypoints, *keypointsGPU);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_SURF_CUDA_getHessianThreshold(cv::cuda::SURF_CUDA *obj, double *val)
{
    BEGIN_WRAP
    *val = obj->hessianThreshold;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_SURF_CUDA_setHessianThreshold(cv::cuda::SURF_CUDA *obj, double val)
{
    BEGIN_WRAP
    obj->hessianThreshold = val;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_SURF_CUDA_getExtended(cv::cuda::SURF_CUDA *obj, int *val)
{
    BEGIN_WRAP
    *val = obj->extended ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_SURF_CUDA_setExtended(cv::cuda::SURF_CUDA *obj, int val)
{
    BEGIN_WRAP
    obj->extended = (val != 0);
    END_WRAP
}
