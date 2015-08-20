#ifndef _CPP_GPU_ORB_GPU_H_
#define _CPP_GPU_ORB_GPU_H_

#include "include_opencv.h"
using namespace cv::gpu;


CVAPI(ORB_GPU*) gpu_ORB_GPU_new(
    int nFeatures, float scaleFactor, int nLevels, int edgeThreshold,
    int firstLevel, int WTA_K, int scoreType, int patchSize)
{
    return new ORB_GPU(nFeatures, scaleFactor, nLevels, edgeThreshold,
        firstLevel, WTA_K, scoreType, patchSize);
}

CVAPI(void) gpu_ORB_GPU_delete(ORB_GPU *obj)
{
    delete obj;
}

CVAPI(void) gpu_ORB_GPU_operator1(ORB_GPU *obj, GpuMat *image, GpuMat *mask, GpuMat *keypoints)
{
    (*obj)(*image, *mask, *keypoints);
}
CVAPI(void) gpu_ORB_GPU_operator2(ORB_GPU *obj, GpuMat *image, GpuMat *mask, std::vector<cv::KeyPoint> *keypoints)
{
    (*obj)(*image, *mask, *keypoints);
}

CVAPI(void) gpu_ORB_GPU_operator3(ORB_GPU *obj, GpuMat *image, GpuMat *mask, std::vector<cv::KeyPoint> *keypoints, GpuMat *descriptors)
{
    (*obj)(*image, *mask, *keypoints, *descriptors);
}
CVAPI(void) gpu_ORB_GPU_operator4(ORB_GPU *obj, GpuMat *image, GpuMat *mask, GpuMat *keypoints, GpuMat *descriptors)
{
    (*obj)(*image, *mask, *keypoints, *descriptors);
}

CVAPI(void) gpu_ORB_GPU_downloadKeyPoints(ORB_GPU *obj, GpuMat *d_keypoints, std::vector<cv::KeyPoint> *keypoints)
{
    obj->downloadKeyPoints(*d_keypoints, *keypoints);
}

CVAPI(void) gpu_ORB_GPU_convertKeyPoints(ORB_GPU *obj, cv::Mat *h_keypoints, std::vector<cv::KeyPoint> *keypoints)
{
    obj->convertKeyPoints(*h_keypoints, *keypoints);
}

CVAPI(int) gpu_ORB_GPU_descriptorSize(ORB_GPU *obj)
{
    return obj->descriptorSize();
}

CVAPI(void) gpu_ORB_GPU_release(ORB_GPU *obj)
{
    obj->release();
}

CVAPI(void) gpu_ORB_GPU_setFastParams(ORB_GPU *obj, int threshold, int nonmaxSuppression)
{
    obj->setFastParams(threshold, nonmaxSuppression != 0);
}

CVAPI(int) gpu_ORB_GPU_blurForDescriptor_get(ORB_GPU *obj)
{
    return obj->blurForDescriptor ? 1 : 0;
}
CVAPI(void) gpu_ORB_GPU_blurForDescriptor_set(ORB_GPU *obj, int value)
{
    obj->blurForDescriptor = (value != 0);
}

#endif