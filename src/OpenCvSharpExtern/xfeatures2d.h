#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile


#include "include_opencv.h"

#pragma region BriefDescriptorExtractor

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_create(
    int bytes, cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::xfeatures2d::BriefDescriptorExtractor::create(bytes);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_BriefDescriptorExtractor_delete(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_BriefDescriptorExtractor_get(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj, cv::xfeatures2d::BriefDescriptorExtractor **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_read(
    cv::xfeatures2d::BriefDescriptorExtractor *obj, cv::FileNode *fn)
{
    return cvTry([&] {
    obj->read(*fn);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_write(
    cv::xfeatures2d::BriefDescriptorExtractor *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
    obj->write(*fs);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_descriptorSize(
    cv::xfeatures2d::BriefDescriptorExtractor *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->descriptorSize();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_descriptorType(
    cv::xfeatures2d::BriefDescriptorExtractor *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->descriptorType();
    });
}


#pragma endregion

#pragma region FREAK

CVAPI(ExceptionStatus) xfeatures2d_FREAK_create(
    int orientationNormalized, int scaleNormalized, float patternScale, int nOctaves,
    int *selectedPairs, int selectedPairsLength, 
    cv::Ptr<cv::xfeatures2d::FREAK> **returnValue)
{
    return cvTry([&] {
    std::vector<int> selectedPairsVec;
    if (selectedPairs != nullptr)
        selectedPairsVec = std::vector<int>(selectedPairs, selectedPairs + selectedPairsLength);
    const auto ptr = cv::xfeatures2d::FREAK::create(
        orientationNormalized != 0, scaleNormalized != 0, patternScale, nOctaves, selectedPairsVec);
    *returnValue = clone(ptr);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_Ptr_FREAK_delete(cv::Ptr<cv::xfeatures2d::FREAK> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_FREAK_get(cv::Ptr<cv::xfeatures2d::FREAK> *obj, cv::xfeatures2d::FREAK **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}


#pragma endregion

#pragma region StarDetector

CVAPI(ExceptionStatus) xfeatures2d_StarDetector_create(
    int maxSize, int responseThreshold,
    int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize, 
    cv::Ptr<cv::xfeatures2d::StarDetector> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::xfeatures2d::StarDetector::create(
        maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_StarDetector_delete(cv::Ptr<cv::xfeatures2d::StarDetector> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_StarDetector_get(cv::Ptr<cv::xfeatures2d::StarDetector> *obj, cv::xfeatures2d::StarDetector **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}


#pragma endregion

#pragma region LUCID

CVAPI(ExceptionStatus) xfeatures2d_LUCID_create(const int lucid_kernel, const int blur_kernel, cv::Ptr<cv::xfeatures2d::LUCID> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::xfeatures2d::LUCID::create(lucid_kernel, blur_kernel);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_LUCID_delete(cv::Ptr<cv::xfeatures2d::LUCID> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_LUCID_get(cv::Ptr<cv::xfeatures2d::LUCID> *obj, cv::xfeatures2d::LUCID **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}


#pragma endregion

#pragma region LATCH

CVAPI(ExceptionStatus) xfeatures2d_LATCH_create(
    int bytes, int rotationInvariance, int half_ssd_size, double sigma, 
    cv::Ptr<cv::xfeatures2d::LATCH> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::xfeatures2d::LATCH::create(bytes, rotationInvariance != 0, half_ssd_size, sigma);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_LATCH_delete(cv::Ptr<cv::xfeatures2d::LATCH> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_LATCH_get(cv::Ptr<cv::xfeatures2d::LATCH> *obj, cv::xfeatures2d::LATCH **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}


#pragma endregion


#pragma region SURF

CVAPI(ExceptionStatus) xfeatures2d_SURF_create(
    double hessianThreshold, int nOctaves,
    int nOctaveLayers, int extended, int upright, 
    cv::Ptr<cv::xfeatures2d::SURF> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::xfeatures2d::SURF::create(
        hessianThreshold, nOctaves, nOctaveLayers, extended != 0, upright != 0);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_SURF_delete(cv::Ptr<cv::xfeatures2d::SURF> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_SURF_get(cv::Ptr<cv::xfeatures2d::SURF> *obj, cv::xfeatures2d::SURF **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_SURF_getHessianThreshold(cv::xfeatures2d::SURF *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getHessianThreshold();
    });
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_getNOctaves(cv::xfeatures2d::SURF *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNOctaves();
    });
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_getNOctaveLayers(cv::xfeatures2d::SURF *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNOctaveLayers();
    });
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_getExtended(cv::xfeatures2d::SURF *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getExtended() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_getUpright(cv::xfeatures2d::SURF *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getUpright() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_SURF_setHessianThreshold(cv::xfeatures2d::SURF *obj, double value)
{
    return cvTry([&] {
    obj->setHessianThreshold(value);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_setNOctaves(cv::xfeatures2d::SURF *obj, int value)
{
    return cvTry([&] {
    obj->setNOctaves(value);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_setNOctaveLayers(cv::xfeatures2d::SURF *obj, int value)
{
    return cvTry([&] {
    obj->setNOctaveLayers(value);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_setExtended(cv::xfeatures2d::SURF *obj, int value)
{
    return cvTry([&] {
    obj->setExtended(value != 0);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_setUpright(cv::xfeatures2d::SURF *obj, int value)
{
    return cvTry([&] {
    obj->setUpright(value != 0);
    });
}

#pragma endregion

#endif // NO_CONTRIB
