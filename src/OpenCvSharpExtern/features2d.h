#ifndef _CPP_FEATURES2D_H_
#define _CPP_FEATURES2D_H_

#include "include_opencv.h"


CVAPI(void) features2d_drawKeypoints(cv::Mat* image, cv::KeyPoint *keypoints, int keypointsLength,
    cv::Mat *outImage, CvScalar color, int flags)
{
    std::vector<cv::KeyPoint> keypointsVec(keypoints, keypoints + keypointsLength);
    cv::drawKeypoints(*image, keypointsVec, *outImage, color, flags);
}


CVAPI(void) features2d_drawMatches1(cv::Mat *img1, cv::KeyPoint *keypoints1, int keypoints1Length,
    cv::Mat *img2, cv::KeyPoint *keypoints2, int keypoints2Length,
    cv::DMatch *matches1to2, int matches1to2Length, cv::Mat *outImg,
    CvScalar matchColor, CvScalar singlePointColor,
    char *matchesMask, int matchesMaskLength, int flags)
{
    std::vector<cv::KeyPoint> keypoints1Vec(keypoints1, keypoints1 + keypoints1Length);
    std::vector<cv::KeyPoint> keypoints2Vec(keypoints2, keypoints2 + keypoints2Length);
    std::vector<cv::DMatch> matches1to2Vec(matches1to2, matches1to2 + matches1to2Length);
    std::vector<char> matchesMaskVec;
    if (matchesMask != NULL)
        matchesMaskVec = std::vector<char>(matchesMask, matchesMask + matchesMaskLength);
    cv::drawMatches(*img1, keypoints1Vec, *img2, keypoints2Vec, matches1to2Vec, *outImg,
        matchColor, singlePointColor, matchesMaskVec, flags);
}

CVAPI(void) features2d_drawMatches2(cv::Mat *img1, cv::KeyPoint *keypoints1, int keypoints1Length,
    cv::Mat *img2, cv::KeyPoint *keypoints2, int keypoints2Length,
    cv::DMatch **matches1to2, int matches1to2Size1, int *matches1to2Size2,
    cv::Mat *outImg, CvScalar matchColor, CvScalar singlePointColor,
    char **matchesMask, int matchesMaskSize1, int *matchesMaskSize2, int flags)
{
    std::vector<cv::KeyPoint> keypoints1Vec(keypoints1, keypoints1 + keypoints1Length);
    std::vector<cv::KeyPoint> keypoints2Vec(keypoints2, keypoints2 + keypoints2Length);
    std::vector<std::vector<cv::DMatch> > matches1to2Vec(matches1to2Size1);
    for (int i = 0; i < matches1to2Size1; i++)
    {
        cv::DMatch *p = matches1to2[i];
        matches1to2Vec[i] = std::vector<cv::DMatch>(p, p + matches1to2Size2[i]);
    }

    std::vector<std::vector<char> > matchesMaskVec;
    if (matchesMask != NULL)
    {
        matchesMaskVec = std::vector<std::vector<char> >(matchesMaskSize1);
        for (int i = 0; i < matchesMaskSize1; i++)
        {
            char *p = matchesMask[i];
            matchesMaskVec[i] = std::vector<char>(p, p + matchesMaskSize2[i]);
        }
    }

    cv::drawMatches(*img1, keypoints1Vec, *img2, keypoints2Vec, matches1to2Vec,
        *outImg, matchColor, singlePointColor, matchesMaskVec, flags);
}


CVAPI(void) features2d_evaluateFeatureDetector(
    cv::Mat *img1, cv::Mat *img2, cv::Mat *H1to2,
    std::vector<cv::KeyPoint> *keypoints1, std::vector<cv::KeyPoint> *keypoints2,
    float *repeatability, int *correspCount/*,
    const Ptr<FeatureDetector>& fdetector = Ptr<FeatureDetector>()*/)
{
    cv::evaluateFeatureDetector(*img1, *img2, *H1to2, keypoints1, keypoints2,
        *repeatability, *correspCount);
}

CVAPI(void) features2d_computeRecallPrecisionCurve(
    cv::DMatch **matches1to2, int matches1to2Size1, int *matches1to2Size2,
    uchar **correctMatches1to2Mask, int correctMatches1to2MaskSize1, int *correctMatches1to2MaskSize2,
    std::vector<cv::Point2f> *recallPrecisionCurve)
{
    std::vector<std::vector<cv::DMatch> > matches1to2Vec;
    std::vector<std::vector<uchar> > correctMatches1to2MaskVec;
    for (int i = 0; i < matches1to2Size1; i++)
    {
        matches1to2Vec.push_back(
            std::vector<cv::DMatch>(matches1to2[i], matches1to2[i] + matches1to2Size2[i]));
    }
    for (int i = 0; i < correctMatches1to2MaskSize1; i++)
    {
        correctMatches1to2MaskVec.push_back(
            std::vector<uchar>(correctMatches1to2Mask[i], correctMatches1to2Mask[i] + correctMatches1to2MaskSize2[i]));
    }
    cv::computeRecallPrecisionCurve(
        matches1to2Vec, correctMatches1to2MaskVec, *recallPrecisionCurve);
}

CVAPI(float) features2d_getRecall(
    cv::Point2f *recallPrecisionCurve, int recallPrecisionCurveSize, float l_precision)
{
    std::vector<cv::Point2f> recallPrecisionCurveVec(
        recallPrecisionCurve, recallPrecisionCurve + recallPrecisionCurveSize);
    return cv::getRecall(recallPrecisionCurveVec, l_precision);
}

CVAPI(int) features2d_getNearestPoint(
    cv::Point2f *recallPrecisionCurve, int recallPrecisionCurveSize, float l_precision)
{
    std::vector<cv::Point2f> recallPrecisionCurveVec(
        recallPrecisionCurve, recallPrecisionCurve + recallPrecisionCurveSize);
    return cv::getNearestPoint(recallPrecisionCurveVec, l_precision);
}

#endif