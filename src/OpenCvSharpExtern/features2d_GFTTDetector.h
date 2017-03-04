#ifndef _CPP_FEATURES2D_GFTT_H_
#define _CPP_FEATURES2D_GFTT_H_

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::GFTTDetector>*) features2d_GFTTDetector_create(
    int maxCorners, double qualityLevel, double minDistance,
    int blockSize, int useHarrisDetector, double k)
{
    cv::Ptr<cv::GFTTDetector> ptr = cv::GFTTDetector::create(
        maxCorners, qualityLevel, minDistance,
        blockSize, useHarrisDetector != 0, k);
    return new cv::Ptr<cv::GFTTDetector>(ptr);
}
CVAPI(void) features2d_Ptr_GFTTDetector_delete(cv::Ptr<cv::GFTTDetector> *ptr)
{
    delete ptr;
}

CVAPI(cv::GFTTDetector*) features2d_Ptr_GFTTDetector_get(cv::Ptr<cv::GFTTDetector> *ptr)
{
    return ptr->get();
}

CVAPI(void) features2d_GFTTDetector_setMaxFeatures(cv::GFTTDetector *obj, int maxFeatures)
{
    obj->setMaxFeatures(maxFeatures);
}
CVAPI(int) features2d_GFTTDetector_getMaxFeatures(cv::GFTTDetector *obj)
{
    return obj->getMaxFeatures();
}

CVAPI(void) features2d_GFTTDetector_setQualityLevel(cv::GFTTDetector *obj, double qlevel)
{
    obj->setQualityLevel(qlevel);
}
CVAPI(double) features2d_GFTTDetector_getQualityLevel(cv::GFTTDetector *obj)
{
    return obj->getQualityLevel();
}

CVAPI(void) features2d_GFTTDetector_setMinDistance(cv::GFTTDetector *obj, double minDistance)
{
    obj->setMinDistance(minDistance);
}
CVAPI(double) features2d_GFTTDetector_getMinDistance(cv::GFTTDetector *obj)
{
    return obj->getMinDistance();
}

CVAPI(void) features2d_GFTTDetector_setBlockSize(cv::GFTTDetector *obj, int blockSize)
{
    obj->setBlockSize(blockSize);
}
CVAPI(int) features2d_GFTTDetector_getBlockSize(cv::GFTTDetector *obj)
{
    return obj->getBlockSize();
}

CVAPI(void) features2d_GFTTDetector_setHarrisDetector(cv::GFTTDetector *obj, int val)
{
    obj->setHarrisDetector(val != 0);
}
CVAPI(int) features2d_GFTTDetector_getHarrisDetector(cv::GFTTDetector *obj)
{
    return obj->getHarrisDetector() ? 1 : 0;
}

CVAPI(void) features2d_GFTTDetector_setK(cv::GFTTDetector *obj, double k)
{
    obj->setK(k);
}
CVAPI(double) features2d_GFTTDetector_getK(cv::GFTTDetector *obj)
{
    return obj->getK();
}

#endif