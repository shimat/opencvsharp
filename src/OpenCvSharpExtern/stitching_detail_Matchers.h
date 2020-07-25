#ifndef _CPP_STITCHING_DETAIL_MATCHERS_H_
#define _CPP_STITCHING_DETAIL_MATCHERS_H_

#include "include_opencv.h"

/** @brief Structure containing image keypoints and descriptors. */
extern "C" 
{
    struct CV_EXPORTS_W_SIMPLE MyImageFeatures
    {
        int img_idx;
        MyCvSize img_size;
        std::vector<cv::KeyPoint> *keypoints;
        cv::Mat *descriptors;
    };
}

CVAPI(ExceptionStatus) stitching_computeImageFeatures1(
    cv::Feature2D *featuresFinder,
    cv::Mat **images,
    int imagesLength,
    MyImageFeatures **features,
    cv::Mat **masks)
{
    BEGIN_WRAP

    // Do not free Feature2D
    const cv::Ptr<cv::Feature2D> featuresFinderPtr(featuresFinder, [](cv::Feature2D*){});

    std::vector<cv::Mat> imagesVec(imagesLength);
    for (int i = 0; i < imagesLength; i++)
    {
        imagesVec[i] = *images[i];
    }

    auto masksArrays = cv::noArray();
    std::vector<cv::Mat> masksVec(imagesLength);
    if (masks != nullptr)
    {
        for (int i = 0; i < imagesLength; i++)
        {
            masksVec[i] = *masks[i];
        }
        masksArrays = masksVec;
    }

    std::vector<cv::detail::ImageFeatures> rawFeatures;
    cv::detail::computeImageFeatures(featuresFinderPtr, imagesVec, rawFeatures, masksArrays);

    for (size_t i = 0; i < rawFeatures.size(); i++)
    {
        const auto &src = rawFeatures[i];
        auto dst = features[i];
        dst->img_idx = src.img_idx;
        dst->img_size = c(src.img_size);
        std::copy(src.keypoints.begin(), src.keypoints.end(), std::back_inserter(*dst->keypoints));
        src.descriptors.copyTo(*dst->descriptors);
    }

    END_WRAP  
}

CVAPI(ExceptionStatus) stitching_computeImageFeatures2(
    cv::Feature2D *featuresFinder,
    cv::_InputArray *image,
    MyImageFeatures *features,
    cv::_InputArray *mask)
{
    BEGIN_WRAP

    // Do not free Feature2D
    const cv::Ptr<cv::Feature2D> featuresFinderPtr(featuresFinder, [](cv::Feature2D*){});
    
    cv::detail::ImageFeatures rawFeature;
    cv::detail::computeImageFeatures(featuresFinderPtr, *image, rawFeature, entity(mask));

    features->img_idx = rawFeature.img_idx;
    features->img_size = c(rawFeature.img_size);
    std::copy(rawFeature.keypoints.begin(), rawFeature.keypoints.end(), std::back_inserter(*features->keypoints));
    rawFeature.descriptors.copyTo(*features->descriptors); 

    END_WRAP  
}

/*
CVAPI(ExceptionStatus) Hoge()
{
        cv::detail::AffineBestOf2NearestMatcher 
}
*/

/*
CVAPI(ExceptionStatus) stitching_Stitcher_create(int mode, cv::Ptr<cv::Stitcher> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::Stitcher::create(static_cast<cv::Stitcher::Mode>(mode));
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Ptr_Stitcher_delete(cv::Ptr<cv::Stitcher> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Ptr_Stitcher_get(cv::Ptr<cv::Stitcher> *obj, cv::Stitcher **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}
*/
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