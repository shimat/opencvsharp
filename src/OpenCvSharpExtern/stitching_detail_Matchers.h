#ifndef _CPP_STITCHING_DETAIL_MATCHERS_H_
#define _CPP_STITCHING_DETAIL_MATCHERS_H_
/*
#include "include_opencv.h"

void extractImageFeatures(
    const cv::detail::ImageFeatures &f,
    int *img_idx, 
    cv::Size *img_size, 
    std::vector<cv::KeyPoint> *keypoints, 
    cv::Mat *descriptors)
{
    *img_idx = f.img_idx;
    *img_size = f.img_size;
    std::copy(f.keypoints.begin(), f.keypoints.end(), std::back_inserter(*keypoints));
    f.descriptors.copyTo(*descriptors);
}*/

// ImageFeatures

/*CVAPI(int) stitching_ImageFeatures_img_idx(cv::detail::ImageFeatures *obj)
{
    return obj->img_idx;
}*/
/*CVAPI(MyCvSize) stitching_ImageFeatures_img_size(cv::detail::ImageFeatures *obj)
{
    return c(obj->img_size);
}*/
/*CVAPI(int64) stitching_ImageFeatures_keypoints_size(cv::detail::ImageFeatures *obj)
{
    return static_cast<int64>(obj->keypoints.size());
}*/
/*CVAPI(void) stitching_ImageFeatures_keypoints_copy(cv::detail::ImageFeatures *obj, cv::KeyPoint* outArray)
{
    for (size_t i = 0; i < obj->keypoints.size(); i++)
    {
        outArray[i] = obj->keypoints[i];
    }
}*/
/*CVAPI(void) stitching_ImageFeatures_descriptors(cv::detail::ImageFeatures *obj, cv::Mat *outMat)
{
    (obj->descriptors).copyTo(*outMat);
}*/

#endif