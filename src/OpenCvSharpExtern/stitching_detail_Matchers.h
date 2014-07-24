#ifndef _CPP_STITCHING_DETAIL_MATCHERS_H_
#define _CPP_STITCHING_DETAIL_MATCHERS_H_

#include "include_opencv.h"
using namespace cv::detail;

void extractImageFeatures(
    const ImageFeatures &f,
    int *img_idx, 
    cv::Size *img_size, 
    std::vector<cv::KeyPoint> *keypoints, 
    cv::Mat *descriptors)
{
    *img_idx = f.img_idx;
    *img_size = f.img_size;
    std::copy(f.keypoints.begin(), f.keypoints.end(), std::back_inserter(*keypoints));
    f.descriptors.copyTo(*descriptors);
}

// ImageFeatures

CVAPI(int) stitching_ImageFeatures_img_idx(ImageFeatures *obj)
{
    return obj->img_idx;
}
CVAPI(CvSize) stitching_ImageFeatures_img_size(ImageFeatures *obj)
{
    return obj->img_size;
}
CVAPI(int64) stitching_ImageFeatures_keypoints_size(ImageFeatures *obj)
{
    return static_cast<int64>(obj->keypoints.size());
}
CVAPI(void) stitching_ImageFeatures_keypoints_copy(ImageFeatures *obj, cv::KeyPoint* outArray)
{
    for (size_t i = 0; i < obj->keypoints.size(); i++)
    {
        outArray[i] = obj->keypoints[i];
    }
}
CVAPI(void) stitching_ImageFeatures_descriptors(ImageFeatures *obj, cv::Mat *outMat)
{
    (obj->descriptors).copyTo(*outMat);
}


// SurfFeaturesFinder

CVAPI(SurfFeaturesFinder*) stitching_SurfFeaturesFinder_new(
    double hess_thresh, int num_octaves, int num_layers, int num_octaves_descr, int num_layers_descr)
{
    return new SurfFeaturesFinder(hess_thresh, num_octaves, num_layers, num_octaves_descr, num_layers_descr);
}
CVAPI(void) stitching_SurfFeaturesFinder_delete(SurfFeaturesFinder* obj)
{
    delete obj;
}

CVAPI(void) stitching_SurfFeaturesFinder_run1(
    SurfFeaturesFinder* obj, cv::Mat *image, 
    int *img_idx, cv::Size *img_size, std::vector<cv::KeyPoint> *keypoints, cv::Mat *descriptors)
{
    ImageFeatures features;
    (*obj)(*image, features);
    extractImageFeatures(features, img_idx, img_size, keypoints, descriptors);
}
CVAPI(void) stitching_SurfFeaturesFinder_run2(
    SurfFeaturesFinder* obj, cv::Mat *image, cv::Rect *rois, int roisSize,
    int *img_idx, cv::Size *img_size, std::vector<cv::KeyPoint> *keypoints, cv::Mat *descriptors)
{
    std::vector<cv::Rect> roisVec(rois, rois + roisSize);
    ImageFeatures features;
    (*obj)(*image, features, roisVec);
    extractImageFeatures(features, img_idx, img_size, keypoints, descriptors);
}
CVAPI(void) stitching_SurfFeaturesFinder_collectGarbage(SurfFeaturesFinder* obj)
{
    obj->collectGarbage();
}


// OrbFeaturesFinder

CVAPI(OrbFeaturesFinder*) stitching_OrbFeaturesFinder_new(
    CvSize grid_size, int nfeatures, float scaleFactor, int nlevels)
{
    return new OrbFeaturesFinder(grid_size, nfeatures, scaleFactor, nlevels);
}
CVAPI(void) stitching_OrbFeaturesFinder_delete(OrbFeaturesFinder* obj)
{
    delete obj;
}

CVAPI(void) stitching_OrbFeaturesFinder_run1(
    OrbFeaturesFinder* obj, cv::Mat *image, 
    int *img_idx, cv::Size *img_size, std::vector<cv::KeyPoint> *keypoints, cv::Mat *descriptors)
{
    ImageFeatures features;
    (*obj)(*image, features);
    extractImageFeatures(features, img_idx, img_size, keypoints, descriptors);
}
CVAPI(void) stitching_OrbFeaturesFinder_run2(
    OrbFeaturesFinder* obj, cv::Mat *image, cv::Rect *rois, int roisSize,
    int *img_idx, cv::Size *img_size, std::vector<cv::KeyPoint> *keypoints, cv::Mat *descriptors)
{
    std::vector<cv::Rect> roisVec(rois, rois + roisSize);
    ImageFeatures features;
    (*obj)(*image, features, roisVec);
    extractImageFeatures(features, img_idx, img_size, keypoints, descriptors);
}
CVAPI(void) stitching_OrbFeaturesFinder_collectGarbage(OrbFeaturesFinder* obj)
{
    obj->collectGarbage();
}



#endif