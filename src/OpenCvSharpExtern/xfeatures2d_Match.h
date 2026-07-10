#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region matchGMS

CVAPI(ExceptionStatus) xfeatures2d_matchGMS(
    interop::Size size1, interop::Size size2,
    std::vector<cv::KeyPoint> *keypoints1, std::vector<cv::KeyPoint> *keypoints2,
    std::vector<cv::DMatch> *matches1to2,
    std::vector<cv::DMatch> *matchesGMS,
    int withRotation, int withScale, double thresholdFactor)
{
    return cvTry([&] {
        cv::xfeatures2d::matchGMS(
            cpp(size1), cpp(size2), *keypoints1, *keypoints2, *matches1to2, *matchesGMS,
            withRotation != 0, withScale != 0, thresholdFactor);
    });
}

#pragma endregion

#pragma region matchLOGOS

CVAPI(ExceptionStatus) xfeatures2d_matchLOGOS(
    std::vector<cv::KeyPoint> *keypoints1, std::vector<cv::KeyPoint> *keypoints2,
    std::vector<int> *nn1, std::vector<int> *nn2,
    std::vector<cv::DMatch> *matches1to2)
{
    return cvTry([&] {
        cv::xfeatures2d::matchLOGOS(*keypoints1, *keypoints2, *nn1, *nn2, *matches1to2);
    });
}

#pragma endregion

#endif // NO_CONTRIB
