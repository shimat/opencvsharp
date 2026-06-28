#pragma once

#ifndef NO_STITCHING

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) stitching_computeImageFeatures1(
    cv::Feature2D *featuresFinder,
    cv::Mat **images,
    int imagesLength,
    std::vector<cv::detail::ImageFeatures> *featuresVec,
    cv::Mat **masks)
{
    return cvTry([&] {

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
    cv::detail::computeImageFeatures(featuresFinderPtr, imagesVec, *featuresVec, masksArrays);
    
    });  
}

CVAPI(ExceptionStatus) stitching_computeImageFeatures2(
    cv::Feature2D *featuresFinder,
    cv::_InputArray *image,
    detail_ImageFeatures *features,
    cv::_InputArray *mask)
{
    return cvTry([&] {

    // Do not free Feature2D
    const cv::Ptr<cv::Feature2D> featuresFinderPtr(featuresFinder, [](cv::Feature2D*){});
    
    cv::detail::ImageFeatures rawFeature;
    cv::detail::computeImageFeatures(featuresFinderPtr, *image, rawFeature, entity(mask));

    features->img_idx = rawFeature.img_idx;
    features->img_size = c(rawFeature.img_size);
    std::copy(rawFeature.keypoints.begin(), rawFeature.keypoints.end(), std::back_inserter(*features->keypoints));
    rawFeature.descriptors.copyTo(*features->descriptors); 

    });  
}


// FeaturesMatcher

CVAPI(ExceptionStatus) stitching_FeaturesMatcher_apply(
    cv::detail::FeaturesMatcher* obj,
    detail_ImageFeatures *features1,
    detail_ImageFeatures *features2,
    int *out_src_img_idx, 
    int *out_dst_img_idx,
    std::vector<cv::DMatch> *out_matches, 
    std::vector<uchar> *out_inliers_mask,
    int *out_num_inliers,
    cv::Mat *out_H,
    double *out_confidence)
{
    return cvTry([&] {
    cv::detail::ImageFeatures features1Cpp{
        features1->img_idx,
        cpp(features1->img_size),
        *features1->keypoints,
        cv::UMat()
    };
    cv::detail::ImageFeatures features2Cpp{
        features2->img_idx,
        cpp(features2->img_size),
        *features2->keypoints,
        cv::UMat()
    };
    features1->descriptors->copyTo(features1Cpp.descriptors);
    features2->descriptors->copyTo(features2Cpp.descriptors);

    cv::detail::MatchesInfo result;
    (*obj)(features1Cpp, features2Cpp, result);

    *out_src_img_idx = result.src_img_idx;
    *out_dst_img_idx = result.dst_img_idx;
    std::copy(result.matches.begin(), result.matches.end(), std::back_inserter(*out_matches));
    std::copy(result.inliers_mask.begin(), result.inliers_mask.end(), std::back_inserter(*out_inliers_mask));
    *out_num_inliers = result.num_inliers;
    result.H.copyTo(*out_H);
    *out_confidence = result.confidence;
    });
}

CVAPI(ExceptionStatus) stitching_FeaturesMatcher_apply2(
    cv::detail::FeaturesMatcher* obj,
    detail_ImageFeatures* features, int featuresSize,
    cv::Mat *mask,
    std::vector<int> *out_src_img_idx,
    std::vector<int> *out_dst_img_idx,
    std::vector< std::vector<cv::DMatch> > *out_matches,
    std::vector< std::vector<uchar> > *out_inliers_mask,
    std::vector<int> *out_num_inliers,
    std::vector<cv::Mat> *out_H,
    std::vector<double> *out_confidence)
{
    return cvTry([&] {
    std::vector<cv::detail::ImageFeatures> featuresVec(featuresSize);
    for (int i = 0; i < featuresSize; i++)
    {
        cv::detail::ImageFeatures featuresCpp {
            features[i].img_idx,
            cpp(features[i].img_size),
            *features[i].keypoints,
            cv::UMat() };
        features[i].descriptors->copyTo(featuresCpp.descriptors);
        featuresVec.push_back(featuresCpp);
    }

    cv::UMat maskU;
    if (mask != nullptr)
    {
        mask->copyTo(maskU);
    }

    std::vector<cv::detail::MatchesInfo> pairwise_matches;
    (*obj)(featuresVec, pairwise_matches, maskU);

    out_src_img_idx->reserve(pairwise_matches.size());
    out_dst_img_idx->reserve(pairwise_matches.size());
    out_matches->reserve(pairwise_matches.size());
    out_inliers_mask->reserve(pairwise_matches.size());
    out_num_inliers->reserve(pairwise_matches.size());
    out_H->reserve(pairwise_matches.size());
    out_confidence->reserve(pairwise_matches.size());
    for (const auto &m : pairwise_matches)
    {
        out_src_img_idx->push_back(m.src_img_idx);
        out_dst_img_idx->push_back(m.dst_img_idx);
        out_num_inliers->push_back(m.num_inliers);
        out_matches->push_back(m.matches);
        out_inliers_mask->push_back(m.inliers_mask);
        out_H->push_back(m.H);
        out_confidence->push_back(m.confidence);
    }

    });
}

CVAPI(ExceptionStatus) stitching_FeaturesMatcher_isThreadSafe(
    cv::detail::FeaturesMatcher* obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->isThreadSafe() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) stitching_FeaturesMatcher_collectGarbage(
    cv::detail::FeaturesMatcher* obj)
{
    return cvTry([&] {
    obj->collectGarbage();
    });
}


// BestOf2NearestMatcher

CVAPI(ExceptionStatus) stitching_BestOf2NearestMatcher_new(
    int try_use_gpu, float match_conf, int num_matches_thresh1,int num_matches_thresh2,
    cv::detail::BestOf2NearestMatcher **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::detail::BestOf2NearestMatcher(
        try_use_gpu != 0, match_conf, num_matches_thresh1, num_matches_thresh2);
    });    
}

CVAPI(ExceptionStatus) stitching_BestOf2NearestMatcher_delete(cv::detail::BestOf2NearestMatcher* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_BestOf2NearestMatcher_collectGarbage(
    cv::detail::BestOf2NearestMatcher* obj)
{
    return cvTry([&] {
    obj->collectGarbage();
    });
}


// AffineBestOf2NearestMatcher

CVAPI(ExceptionStatus) stitching_AffineBestOf2NearestMatcher_new(
    int full_affine, int try_use_gpu, float match_conf, int num_matches_thresh1,
    cv::detail::AffineBestOf2NearestMatcher** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::detail::AffineBestOf2NearestMatcher(
        full_affine != 0, try_use_gpu != 0, match_conf, num_matches_thresh1);
    });
}

CVAPI(ExceptionStatus) stitching_AffineBestOf2NearestMatcher_delete(
    cv::detail::AffineBestOf2NearestMatcher* obj)
{
    return cvTry([&] {
    delete obj;
    });
}

#endif // NO_STITCHING
