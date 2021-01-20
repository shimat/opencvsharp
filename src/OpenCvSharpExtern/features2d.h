#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) features2d_drawKeypoints(cv::_InputArray *image, cv::KeyPoint *keypoints, int keypointsLength,
    cv::_InputOutputArray *outImage, MyCvScalar color, int flags)
{
    BEGIN_WRAP
    const std::vector<cv::KeyPoint> keypointsVec(keypoints, keypoints + keypointsLength);
    cv::drawKeypoints(*image, keypointsVec, *outImage, cpp(color), static_cast<cv::DrawMatchesFlags>(flags));
    END_WRAP
}


CVAPI(ExceptionStatus) features2d_drawMatches(cv::Mat *img1, cv::KeyPoint *keypoints1, int keypoints1Length,
    cv::Mat *img2, cv::KeyPoint *keypoints2, int keypoints2Length,
    cv::DMatch *matches1to2, int matches1to2Length, cv::Mat *outImg,
    MyCvScalar matchColor, MyCvScalar singlePointColor,
    char *matchesMask, int matchesMaskLength, int flags)
{
    BEGIN_WRAP
    const std::vector<cv::KeyPoint> keypoints1Vec(keypoints1, keypoints1 + keypoints1Length);
    const std::vector<cv::KeyPoint> keypoints2Vec(keypoints2, keypoints2 + keypoints2Length);
    const std::vector<cv::DMatch> matches1to2Vec(matches1to2, matches1to2 + matches1to2Length);
    std::vector<char> matchesMaskVec;
    if (matchesMask != nullptr)
        matchesMaskVec = std::vector<char>(matchesMask, matchesMask + matchesMaskLength);
    cv::drawMatches(*img1, keypoints1Vec, *img2, keypoints2Vec, matches1to2Vec, *outImg,
        cpp(matchColor), cpp(singlePointColor), matchesMaskVec, static_cast<cv::DrawMatchesFlags>(flags));
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_drawMatchesKnn(cv::Mat *img1, cv::KeyPoint *keypoints1, int keypoints1Length,
    cv::Mat *img2, cv::KeyPoint *keypoints2, int keypoints2Length,
    cv::DMatch **matches1to2, int matches1to2Size1, int *matches1to2Size2,
    cv::Mat *outImg, MyCvScalar matchColor, MyCvScalar singlePointColor,
    char **matchesMask, int matchesMaskSize1, int *matchesMaskSize2, int flags)
{
    BEGIN_WRAP
    const std::vector<cv::KeyPoint> keypoints1Vec(keypoints1, keypoints1 + keypoints1Length);
    const std::vector<cv::KeyPoint> keypoints2Vec(keypoints2, keypoints2 + keypoints2Length);
    std::vector<std::vector<cv::DMatch> > matches1to2Vec(matches1to2Size1);
    for (int i = 0; i < matches1to2Size1; i++)
    {
        cv::DMatch *p = matches1to2[i];
        matches1to2Vec[i] = std::vector<cv::DMatch>(p, p + matches1to2Size2[i]);
    }

    std::vector<std::vector<char> > matchesMaskVec;
    if (matchesMask != nullptr)
    {
        matchesMaskVec = std::vector<std::vector<char> >(matchesMaskSize1);
        for (int i = 0; i < matchesMaskSize1; i++)
        {
            char *p = matchesMask[i];
            matchesMaskVec[i] = std::vector<char>(p, p + matchesMaskSize2[i]);
        }
    }

    cv::drawMatches(*img1, keypoints1Vec, *img2, keypoints2Vec, matches1to2Vec,
        *outImg, cpp(matchColor), cpp(singlePointColor), matchesMaskVec, static_cast<cv::DrawMatchesFlags>(flags));
    END_WRAP
}


CVAPI(ExceptionStatus) features2d_evaluateFeatureDetector(
    cv::Mat *img1, cv::Mat *img2, cv::Mat *H1to2,
    std::vector<cv::KeyPoint> *keypoints1, std::vector<cv::KeyPoint> *keypoints2,
    float *repeatability, int *correspCount/*,
    const Ptr<FeatureDetector>& fdetector = Ptr<FeatureDetector>()*/)
{
    BEGIN_WRAP
    cv::evaluateFeatureDetector(
        *img1, *img2, *H1to2, keypoints1, keypoints2,
        *repeatability, *correspCount);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_computeRecallPrecisionCurve(
    cv::DMatch **matches1to2, int matches1to2Size1, int *matches1to2Size2,
    uchar **correctMatches1to2Mask, int correctMatches1to2MaskSize1, int *correctMatches1to2MaskSize2,
    std::vector<cv::Point2f> *recallPrecisionCurve)
{
    BEGIN_WRAP
    std::vector<std::vector<cv::DMatch> > matches1to2Vec;
    std::vector<std::vector<uchar> > correctMatches1to2MaskVec;
    matches1to2Vec.reserve(matches1to2Size1);
    for (int i = 0; i < matches1to2Size1; i++)
    {
        matches1to2Vec.emplace_back(matches1to2[i], matches1to2[i] + matches1to2Size2[i]);
    }
    correctMatches1to2MaskVec.reserve(correctMatches1to2MaskSize1);
    for (int i = 0; i < correctMatches1to2MaskSize1; i++)
    {
        correctMatches1to2MaskVec.emplace_back(correctMatches1to2Mask[i], correctMatches1to2Mask[i] + correctMatches1to2MaskSize2[i]);
    }
    cv::computeRecallPrecisionCurve(
        matches1to2Vec, correctMatches1to2MaskVec, *recallPrecisionCurve);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_getRecall(
    cv::Point2f *recallPrecisionCurve, int recallPrecisionCurveSize, float l_precision, float *returnValue)
{
    BEGIN_WRAP
    const std::vector<cv::Point2f> recallPrecisionCurveVec(
        recallPrecisionCurve, recallPrecisionCurve + recallPrecisionCurveSize);
    *returnValue = cv::getRecall(recallPrecisionCurveVec, l_precision);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_getNearestPoint(
    cv::Point2f *recallPrecisionCurve, int recallPrecisionCurveSize, float l_precision, int *returnValue)
{
    BEGIN_WRAP
    const std::vector<cv::Point2f> recallPrecisionCurveVec(
        recallPrecisionCurve, recallPrecisionCurve + recallPrecisionCurveSize);
    *returnValue = cv::getNearestPoint(recallPrecisionCurveVec, l_precision);
    END_WRAP
}


#pragma region KeyPointsFilter

CVAPI(ExceptionStatus) features2d_KeyPointsFilter_runByImageBorder(
    std::vector<cv::KeyPoint> *keypoints, MyCvSize imageSize, int borderSize)
{
    BEGIN_WRAP
    cv::KeyPointsFilter::runByImageBorder(*keypoints, cpp(imageSize), borderSize);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KeyPointsFilter_runByKeypointSize(
    std::vector<cv::KeyPoint> *keypoints, float minSize, float maxSize)
{
    BEGIN_WRAP
    cv::KeyPointsFilter::runByKeypointSize(*keypoints, minSize, maxSize);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KeyPointsFilter_runByPixelsMask(
    std::vector<cv::KeyPoint> *keypoints, cv::Mat *mask)
{
    BEGIN_WRAP
    cv::KeyPointsFilter::runByPixelsMask(*keypoints, *mask);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KeyPointsFilter_removeDuplicated(
    std::vector<cv::KeyPoint> *keypoints)
{
    BEGIN_WRAP
    cv::KeyPointsFilter::removeDuplicated(*keypoints);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KeyPointsFilter_removeDuplicatedSorted(
    std::vector<cv::KeyPoint> *keypoints)
{
    BEGIN_WRAP
    cv::KeyPointsFilter::removeDuplicatedSorted(*keypoints);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KeyPointsFilter_retainBest(
    std::vector<cv::KeyPoint> *keypoints, int nPoints)
{
    BEGIN_WRAP
    cv::KeyPointsFilter::retainBest(*keypoints, nPoints);
    END_WRAP
}

#pragma endregion
