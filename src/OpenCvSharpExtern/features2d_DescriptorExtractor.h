
/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_FEATURES2D_DESCRIPTREXTRACTOR_H_
#define _CPP_FEATURES2D_DESCRIPTREXTRACTOR_H_

#include "include_opencv.h"

CVAPI(void) features2d_DescriptorExtractor_delete(cv::DescriptorExtractor *obj)
{
    delete obj;
}

CVAPI(void) features2d_DescriptorExtractor_compute1(
    cv::DescriptorExtractor *obj, cv::Mat *image, std::vector<cv::KeyPoint> *keypoint, cv::Mat *descriptors)
{
    obj->compute(*image, *keypoint, *descriptors);
}
CVAPI(void) features2d_DescriptorExtractor_compute2(
    cv::DescriptorExtractor *obj, 
    cv::Mat **images, int imagesSize,
    std::vector<std::vector<cv::KeyPoint> > *keypoints, 
    cv::Mat **descriptors, int descriptorsSize)
{
    std::vector<cv::Mat> imagesVec(imagesSize);
    std::vector<cv::Mat> descriptorsVec(descriptorsSize);
    for (int i = 0; i < imagesSize; i++)
        imagesVec[i] = *images[i];
    for (int i = 0; i < descriptorsSize; i++)
        descriptorsVec[i] = *descriptors[i];

    obj->compute(imagesVec, *keypoints, descriptorsVec);
}

CVAPI(int) features2d_DescriptorExtractor_descriptorSize(cv::DescriptorExtractor *obj)
{
    return obj->descriptorSize();
}

CVAPI(int) features2d_DescriptorExtractor_descriptorType(cv::DescriptorExtractor *obj)
{
    return obj->descriptorType();
}

CVAPI(int) features2d_DescriptorExtractor_empty(cv::DescriptorExtractor *obj)
{
    return obj->empty() ? 1 : 0;
}


CVAPI(cv::AlgorithmInfo*) features2d_DescriptorExtractor_info(cv::DescriptorExtractor *obj)
{
    return obj->info();
}

CVAPI(cv::Ptr<cv::DescriptorExtractor>*) features2d_DescriptorExtractor_create(const char *descriptorExtractorType)
{
    return clone( cv::DescriptorExtractor::create(descriptorExtractorType) );
}

#endif