#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

// OpenCV 5 relocated BRISK / KAZE / AKAZE / AGAST(+AgastFeatureDetector) from the
// main features module into the contrib xfeatures2d module (cv::xfeatures2d).
#include "include_opencv.h"
#pragma region BRISK

CVAPI(ExceptionStatus) xfeatures2d_BRISK_create1(
    int thresh,
    int octaves,
    float patternScale,
    cv::Ptr<cv::xfeatures2d::BRISK> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::BRISK::create(thresh, octaves, patternScale);
        *returnValue = clone(ptr);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_BRISK_create2(
    float *radiusList,
    int radiusListLength,
    int *numberList,
    int numberListLength,
    float dMax,
    float dMin,
    int *indexChange,
    int indexChangeLength,
    cv::Ptr<cv::xfeatures2d::BRISK> **returnValue)
{
    return cvTry([&] {
        const std::vector<float> radiusListVec(radiusList, radiusList + radiusListLength);
        const std::vector<int> numberListVec(numberList, numberList + numberListLength);
        std::vector<int> indexChangeVec;
        if (indexChange != nullptr)
            indexChangeVec = std::vector<int>(indexChange, indexChange + indexChangeLength);

        const auto ptr = cv::xfeatures2d::BRISK::create(radiusListVec, numberListVec, dMax, dMin, indexChangeVec);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BRISK_create3(
    int thresh,
    int octaves,
    float *radiusList,
    int radiusListLength,
    int *numberList,
    int numberListLength,
    float dMax,
    float dMin,
    int *indexChange,
    int indexChangeLength,
    cv::Ptr<cv::xfeatures2d::BRISK> **returnValue)
{
    return cvTry([&] {
        const std::vector<float> radiusListVec(radiusList, radiusList + radiusListLength);
        const std::vector<int> numberListVec(numberList, numberList + numberListLength);
        std::vector<int> indexChangeVec;
        if (indexChange != nullptr)
            indexChangeVec = std::vector<int>(indexChange, indexChange + indexChangeLength);

        const auto ptr = cv::xfeatures2d::BRISK::create(thresh, octaves, radiusListVec, numberListVec, dMax, dMin, indexChangeVec);
        *returnValue = clone(ptr);
    });  
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_BRISK_delete(cv::Ptr<cv::xfeatures2d::BRISK> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

#pragma endregion
#pragma region

CVAPI(ExceptionStatus) xfeatures2d_AGAST(
    const interop::InputArrayProxy* image,
    std::vector<cv::KeyPoint> *keypoints,
    int threshold,
    int nonmaxSuppression,
    int type)
{
    return cvTry([&] {
        cv::xfeatures2d::AGAST(
            InProxy(*image),
            *keypoints,
            threshold,
            nonmaxSuppression != 0, 
            static_cast<cv::xfeatures2d::AgastFeatureDetector::DetectorType>(type));
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AgastFeatureDetector_create(
    int threshold,
    int nonmaxSuppression,
    int type,
    cv::Ptr<cv::xfeatures2d::AgastFeatureDetector> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::AgastFeatureDetector::create(
            threshold, nonmaxSuppression != 0, static_cast<cv::xfeatures2d::AgastFeatureDetector::DetectorType>(type));
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_AgastFeatureDetector_delete(cv::Ptr<cv::xfeatures2d::AgastFeatureDetector> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AgastFeatureDetector_setThreshold(cv::xfeatures2d::AgastFeatureDetector *obj, int val)
{
    return cvTry([&] {
        obj->setThreshold(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AgastFeatureDetector_getThreshold(cv::xfeatures2d::AgastFeatureDetector *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getThreshold();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AgastFeatureDetector_setNonmaxSuppression(cv::xfeatures2d::AgastFeatureDetector *obj, int val)
{
    return cvTry([&] {
        obj->setNonmaxSuppression(val != 0);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AgastFeatureDetector_getNonmaxSuppression(cv::xfeatures2d::AgastFeatureDetector *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNonmaxSuppression() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AgastFeatureDetector_setType(cv::xfeatures2d::AgastFeatureDetector *obj, int val)
{
    return cvTry([&] {
        obj->setType(static_cast<cv::xfeatures2d::AgastFeatureDetector::DetectorType>(val));
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AgastFeatureDetector_getType(cv::xfeatures2d::AgastFeatureDetector *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->getType());
    });
}

#pragma endregion
#pragma region KAZE

CVAPI(ExceptionStatus) xfeatures2d_KAZE_create(
    int extended,
    int upright,
    float threshold,
    int nOctaves,
    int nOctaveLayers,
    int diffusivity,
    cv::Ptr<cv::xfeatures2d::KAZE> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::KAZE::create(
            extended != 0, upright != 0, threshold,
            nOctaves, nOctaveLayers, static_cast<cv::xfeatures2d::KAZE::DiffusivityType>(diffusivity));
        *returnValue = clone(ptr);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_Ptr_KAZE_delete(cv::Ptr<cv::xfeatures2d::KAZE> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_KAZE_setDiffusivity(cv::xfeatures2d::KAZE *obj, int val)
{
    return cvTry([&] {
        obj->setDiffusivity(static_cast<cv::xfeatures2d::KAZE::DiffusivityType>(val));
    });
}
CVAPI(ExceptionStatus) xfeatures2d_KAZE_getDiffusivity(cv::xfeatures2d::KAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->getDiffusivity());
    });
}

CVAPI(ExceptionStatus) xfeatures2d_KAZE_setExtended(cv::xfeatures2d::KAZE *obj, int val)
{
    return cvTry([&] {
        obj->setExtended(val != 0);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_KAZE_getExtended(cv::xfeatures2d::KAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getExtended() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_KAZE_setNOctaveLayers(cv::xfeatures2d::KAZE *obj, int val)
{
    return cvTry([&] {
        obj->setNOctaveLayers(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_KAZE_getNOctaveLayers(cv::xfeatures2d::KAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNOctaveLayers();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_KAZE_setNOctaves(cv::xfeatures2d::KAZE *obj, int val)
{
    return cvTry([&] {
        obj->setNOctaves(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_KAZE_getNOctaves(cv::xfeatures2d::KAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNOctaves();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_KAZE_setThreshold(cv::xfeatures2d::KAZE *obj, double val)
{
    return cvTry([&] {
        obj->setThreshold(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_KAZE_getThreshold(cv::xfeatures2d::KAZE *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getThreshold();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_KAZE_setUpright(cv::xfeatures2d::KAZE *obj, int val)
{
    return cvTry([&] {
        obj->setUpright(val != 0);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_KAZE_getUpright(cv::xfeatures2d::KAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getUpright() ? 1 : 0;
    });
}

#pragma endregion

#pragma region AKAZE

CVAPI(ExceptionStatus) xfeatures2d_AKAZE_create(
    int descriptor_type,
    int descriptor_size,
    int descriptor_channels,
    float threshold,
    int nOctaves,
    int nOctaveLayers,
    int diffusivity,
    cv::Ptr<cv::xfeatures2d::AKAZE> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::AKAZE::create(
            static_cast<cv::xfeatures2d::AKAZE::DescriptorType>(descriptor_type), descriptor_size, descriptor_channels,
            threshold, nOctaves, nOctaveLayers, static_cast<cv::xfeatures2d::KAZE::DiffusivityType>(diffusivity));
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_AKAZE_delete(cv::Ptr<cv::xfeatures2d::AKAZE> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AKAZE_setDescriptorType(cv::xfeatures2d::AKAZE *obj, int val)
{
    return cvTry([&] {
        obj->setDescriptorType(static_cast<cv::xfeatures2d::AKAZE::DescriptorType>(val));
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AKAZE_getDescriptorType(cv::xfeatures2d::AKAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->getDescriptorType());
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AKAZE_setDescriptorSize(cv::xfeatures2d::AKAZE *obj, int val)
{
    return cvTry([&] {
        obj->setDescriptorSize(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AKAZE_getDescriptorSize(cv::xfeatures2d::AKAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDescriptorSize();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AKAZE_setDescriptorChannels(cv::xfeatures2d::AKAZE *obj, int val)
{
    return cvTry([&] {
        obj->setDescriptorChannels(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AKAZE_getDescriptorChannels(cv::xfeatures2d::AKAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDescriptorChannels();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AKAZE_setThreshold(cv::xfeatures2d::AKAZE *obj, double val)
{
    return cvTry([&] {
        obj->setThreshold(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AKAZE_getThreshold(cv::xfeatures2d::AKAZE *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getThreshold();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AKAZE_setNOctaves(cv::xfeatures2d::AKAZE *obj, int val)
{
    return cvTry([&] {
        obj->setNOctaves(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AKAZE_getNOctaves(cv::xfeatures2d::AKAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNOctaves();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AKAZE_setNOctaveLayers(cv::xfeatures2d::AKAZE *obj, int val)
{
    return cvTry([&] {
        obj->setNOctaveLayers(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AKAZE_getNOctaveLayers(cv::xfeatures2d::AKAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNOctaveLayers();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_AKAZE_setDiffusivity(cv::xfeatures2d::AKAZE *obj, int val)
{
    return cvTry([&] {
        obj->setDiffusivity(static_cast<cv::xfeatures2d::KAZE::DiffusivityType>(val));
    });
}
CVAPI(ExceptionStatus) xfeatures2d_AKAZE_getDiffusivity(cv::xfeatures2d::AKAZE *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->getDiffusivity());
    });
}

#pragma endregion
#endif // NO_CONTRIB
