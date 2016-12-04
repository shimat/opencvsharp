#ifndef _CPP_FEATURES2D_KEY_POINTS_FILTER_H_
#define _CPP_FEATURES2D_KEY_POINTS_FILTER_H_

#include "include_opencv.h"


CVAPI(void) features2d_KeyPointsFilter_runByImageBorder(
    std::vector<cv::KeyPoint> *keypoints, MyCvSize imageSize, int borderSize)
{
    cv::KeyPointsFilter::runByImageBorder(*keypoints, cpp(imageSize), borderSize);
}

CVAPI(void) features2d_KeyPointsFilter_runByKeypointSize(
    std::vector<cv::KeyPoint> *keypoints, float minSize, float maxSize)
{
    cv::KeyPointsFilter::runByKeypointSize(*keypoints, minSize, maxSize);
}
CVAPI(void) features2d_KeyPointsFilter_runByPixelsMask(
    std::vector<cv::KeyPoint> *keypoints, cv::Mat *mask)
{
    cv::KeyPointsFilter::runByPixelsMask(*keypoints, *mask);
}

CVAPI(void) features2d_KeyPointsFilter_removeDuplicated(
    std::vector<cv::KeyPoint> *keypoints)
{
    cv::KeyPointsFilter::removeDuplicated(*keypoints);
}

CVAPI(void) features2d_KeyPointsFilter_retainBest(
    std::vector<cv::KeyPoint> *keypoints, int npoints)
{
    cv::KeyPointsFilter::retainBest(*keypoints, npoints);
}

#endif