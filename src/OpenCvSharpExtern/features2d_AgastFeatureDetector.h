#ifndef _CPP_FEATURES2D_AGASTFEATUREDETECTOR_H_
#define _CPP_FEATURES2D_AGASTFEATUREDETECTOR_H_

#include "include_opencv.h"


CVAPI(void) features2d_AGAST(cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints,
    int threshold, int nonmaxSuppression, int type)
{
    cv::AGAST(entity(image), *keypoints, threshold, nonmaxSuppression != 0, type);
}


CVAPI(cv::Ptr<cv::AgastFeatureDetector>*) features2d_AgastFeatureDetector_create(
    int threshold, int nonmaxSuppression, int type)
{
    cv::Ptr<cv::AgastFeatureDetector> ptr = cv::AgastFeatureDetector::create(
        threshold, nonmaxSuppression != 0, type);
    return new cv::Ptr<cv::AgastFeatureDetector>(ptr);
}

CVAPI(void) features2d_Ptr_AgastFeatureDetector_delete(cv::Ptr<cv::AgastFeatureDetector> *ptr)
{
    delete ptr;
}

CVAPI(cv::AgastFeatureDetector*) features2d_Ptr_AgastFeatureDetector_get(cv::Ptr<cv::AgastFeatureDetector> *ptr)
{
    return ptr->get();
}


CVAPI(void) features2d_AgastFeatureDetector_setThreshold(cv::AgastFeatureDetector *obj, int val)
{
    obj->setThreshold(val);
}
CVAPI(int) features2d_AgastFeatureDetector_getThreshold(cv::AgastFeatureDetector *obj)
{
    return obj->getThreshold();
}

CVAPI(void) features2d_AgastFeatureDetector_setNonmaxSuppression(cv::AgastFeatureDetector *obj, int val)
{
    obj->setNonmaxSuppression(val != 0);
}
CVAPI(int) features2d_AgastFeatureDetector_getNonmaxSuppression(cv::AgastFeatureDetector *obj)
{
    return obj->getNonmaxSuppression() ? 1 : 0;
}

CVAPI(void) features2d_AgastFeatureDetector_setType(cv::AgastFeatureDetector *obj, int val)
{
    obj->setType(val);
}
CVAPI(int) features2d_AgastFeatureDetector_getType(cv::AgastFeatureDetector *obj)
{
    return obj->getType();
}

#endif