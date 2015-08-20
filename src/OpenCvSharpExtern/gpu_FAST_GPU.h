#ifndef _CPP_GPU_FAST_GPU_H_
#define _CPP_GPU_FAST_GPU_H_

#include "include_opencv.h"
using namespace cv::gpu;

CVAPI(FAST_GPU*) gpu_FAST_GPU_new(int threshold, int nonmaxSuppression, double keypointsRatio)
{
    return new FAST_GPU(threshold, nonmaxSuppression != 0, keypointsRatio);
}

CVAPI(void) gpu_FAST_GPU_delete(FAST_GPU *obj)
{
    delete obj;
}

CVAPI(void) gpu_FAST_GPU_operator1(FAST_GPU *obj, GpuMat *image, GpuMat *mask, GpuMat *keypoints)
{
    (*obj)(*image, *mask, *keypoints);
}
CVAPI(void) gpu_FAST_GPU_operator2(FAST_GPU *obj, GpuMat *image, GpuMat *mask, std::vector<cv::KeyPoint> *keypoints)
{
    (*obj)(*image, *mask, *keypoints);
}

CVAPI(void) gpu_FAST_GPU_downloadKeypoints(FAST_GPU *obj, GpuMat *d_keypoints, std::vector<cv::KeyPoint> *keypoints)
{
    obj->downloadKeypoints(*d_keypoints, *keypoints);
}

CVAPI(void) gpu_FAST_GPU_convertKeypoints(FAST_GPU *obj, cv::Mat *h_keypoints, std::vector<cv::KeyPoint> *keypoints)
{
    obj->convertKeypoints(*h_keypoints, *keypoints);
}

CVAPI(void) gpu_FAST_GPU_release(FAST_GPU *obj)
{
    obj->release();
}

CVAPI(int) gpu_FAST_GPU_nonmaxSuppression_get(FAST_GPU *obj)
{
    return obj->nonmaxSuppression ? 1 : 0;
}
CVAPI(void) gpu_FAST_GPU_nonmaxSuppression_set(FAST_GPU *obj, int value)
{
    obj->nonmaxSuppression = (value != 0);
}

CVAPI(int) gpu_FAST_GPU_threshold_get(FAST_GPU *obj)
{
    return obj->threshold;
}
CVAPI(void) gpu_FAST_GPU_threshold_set(FAST_GPU *obj, int value)
{
    obj->threshold = value;
}

CVAPI(double) gpu_FAST_GPU_keypointsRatio_get(FAST_GPU *obj)
{
    return obj->keypointsRatio;
}
CVAPI(void) gpu_FAST_GPU_keypointsRatio_set(FAST_GPU *obj, double value)
{
    obj->keypointsRatio = value;
}

CVAPI(int) gpu_FAST_GPU_calcKeyPointsLocation(FAST_GPU *obj, GpuMat *image, GpuMat *mask)
{
    return obj->calcKeyPointsLocation(*image, *mask);
}

CVAPI(int) gpu_FAST_GPU_getKeyPoints(FAST_GPU *obj, GpuMat *keypoints)
{
    return obj->getKeyPoints(*keypoints);
}

#endif