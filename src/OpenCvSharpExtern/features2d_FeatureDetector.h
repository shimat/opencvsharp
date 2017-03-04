#ifndef _CPP_FEATURES2DFEATUREDETECTOR_H_
#define _CPP_FEATURES2DFEATUREDETECTOR_H_

#include "include_opencv.h"

#pragma region Feature2D

CVAPI(cv::Feature2D*) features2d_Ptr_Feature2D_get(cv::Ptr<cv::Feature2D>* ptr)
{
    return ptr->get();
}
CVAPI(void) features2d_Ptr_Feature2D_delete(cv::Ptr<cv::Feature2D>* ptr)
{
    delete ptr;
}

CVAPI(void) features2d_Feature2D_detect_Mat1(
    cv::Feature2D *detector, cv::Mat *image, std::vector<cv::KeyPoint> *keypoints,
    cv::Mat *mask)
{
    detector->detect(*image, *keypoints, entity(mask));
}

CVAPI(void) features2d_Feature2D_detect_Mat2(
    cv::Feature2D *detector, cv::Mat **images, int imageLength,
    std::vector<std::vector<cv::KeyPoint> > *keypoints, cv::Mat **mask)
{
    std::vector<cv::Mat> imageVec(imageLength);
    std::vector<cv::Mat> maskVec;
    
    for (int i = 0; i < imageLength; i++)
        imageVec.push_back(*images[i]);
    
    if (mask != NULL)
    {
        maskVec.reserve(imageLength);
        for (int i = 0; i < imageLength; i++)
            maskVec.push_back(*mask[i]);
    }

    detector->detect(imageVec, *keypoints, maskVec);
}

CVAPI(void) features2d_Feature2D_detect_InputArray(
    cv::Feature2D *obj, cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::Mat *mask)
{
    obj->detect(*image, *keypoints, entity(mask));
}

CVAPI(void) features2d_Feature2D_compute1(cv::Feature2D *obj,
    cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors)
{
    obj->compute(*image, *keypoints, *descriptors);
}

CVAPI(void) features2d_Feature2D_compute2(
    cv::Feature2D *detector, cv::Mat **images, int imageLength,
    std::vector<std::vector<cv::KeyPoint> > *keypoints, cv::Mat **descriptors, int descriptorsLength)
{
    std::vector<cv::Mat> imageVec(imageLength);
    std::vector<cv::Mat> descriptorsVec(descriptorsLength);
    
    for (int i = 0; i < imageLength; i++)
        imageVec.push_back(*images[i]);
    for (int i = 0; i < descriptorsLength; i++)
        descriptorsVec.push_back(*descriptors[i]);

    detector->compute(imageVec, *keypoints, descriptorsVec);
}

CVAPI(void) features2d_Feature2D_detectAndCompute(
    cv::Feature2D *detector, cv::_InputArray *image, cv::_InputArray *mask, 
    std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors, int useProvidedKeypoints)
{
    detector->detectAndCompute(entity(image), entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}

CVAPI(int) features2d_Feature2D_descriptorSize(cv::Ptr<cv::Feature2D> *obj)
{
    return obj->get()->descriptorSize();
}
CVAPI(int) features2d_Feature2D_descriptorType(cv::Ptr<cv::Feature2D> *obj)
{
    return obj->get()->descriptorType();
}
CVAPI(int) features2d_Feature2D_defaultNorm(cv::Ptr<cv::Feature2D> *obj)
{
    return obj->get()->defaultNorm();
}
CVAPI(int) features2d_Feature2D_empty(cv::Ptr<cv::Feature2D> *obj)
{
    return obj->get()->empty() ? 1 : 0;
}

#pragma endregion

/*
#pragma region DenseFeatureDetector

CVAPI(cv::DenseFeatureDetector*) features2d_DenseFeatureDetector_new(
    float initFeatureScale, int featureScaleLevels, float featureScaleMul,
    int initXyStep, int initImgBound, int varyXyStepWithScale, int varyImgBoundWithScale)
{
    return new cv::DenseFeatureDetector(initFeatureScale, featureScaleLevels, 
        featureScaleMul, initXyStep, initImgBound, varyXyStepWithScale != 0, varyImgBoundWithScale != 0);
}
CVAPI(void) features2d_DenseFeatureDetector_delete(cv::DenseFeatureDetector *obj)
{
    delete obj;
}

CVAPI(cv::DenseFeatureDetector*) features2d_Ptr_DenseFeatureDetector_get(cv::Ptr<cv::DenseFeatureDetector> *ptr)
{
    return ptr->get();
}
CVAPI(void) features2d_Ptr_DenseFeatureDetector_delete(cv::Ptr<cv::DenseFeatureDetector> *ptr)
{
    delete ptr;
}

#pragma endregion
*/
#endif