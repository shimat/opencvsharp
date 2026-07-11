#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile


#include "include_opencv.h"

#pragma region BriefDescriptorExtractor

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_create(
    int bytes, int useOrientation, cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::BriefDescriptorExtractor::create(bytes, useOrientation != 0);
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

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_setDescriptorSize(cv::xfeatures2d::BriefDescriptorExtractor *obj, int bytes)
{
    return cvTry([&] {
        obj->setDescriptorSize(bytes);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_getDescriptorSize(cv::xfeatures2d::BriefDescriptorExtractor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDescriptorSize();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_setUseOrientation(cv::xfeatures2d::BriefDescriptorExtractor *obj, int useOrientation)
{
    return cvTry([&] {
        obj->setUseOrientation(useOrientation != 0);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_getUseOrientation(cv::xfeatures2d::BriefDescriptorExtractor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getUseOrientation() ? 1 : 0;
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

CVAPI(ExceptionStatus) xfeatures2d_FREAK_setOrientationNormalized(cv::xfeatures2d::FREAK *obj, int val)
{
    return cvTry([&] {
        obj->setOrientationNormalized(val != 0);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_FREAK_getOrientationNormalized(cv::xfeatures2d::FREAK *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getOrientationNormalized() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_FREAK_setScaleNormalized(cv::xfeatures2d::FREAK *obj, int val)
{
    return cvTry([&] {
        obj->setScaleNormalized(val != 0);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_FREAK_getScaleNormalized(cv::xfeatures2d::FREAK *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getScaleNormalized() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_FREAK_setPatternScale(cv::xfeatures2d::FREAK *obj, double val)
{
    return cvTry([&] {
        obj->setPatternScale(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_FREAK_getPatternScale(cv::xfeatures2d::FREAK *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getPatternScale();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_FREAK_setNOctaves(cv::xfeatures2d::FREAK *obj, int val)
{
    return cvTry([&] {
        obj->setNOctaves(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_FREAK_getNOctaves(cv::xfeatures2d::FREAK *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNOctaves();
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

CVAPI(ExceptionStatus) xfeatures2d_StarDetector_setMaxSize(cv::xfeatures2d::StarDetector *obj, int val)
{
    return cvTry([&] {
        obj->setMaxSize(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_StarDetector_getMaxSize(cv::xfeatures2d::StarDetector *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMaxSize();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_StarDetector_setResponseThreshold(cv::xfeatures2d::StarDetector *obj, int val)
{
    return cvTry([&] {
        obj->setResponseThreshold(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_StarDetector_getResponseThreshold(cv::xfeatures2d::StarDetector *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getResponseThreshold();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_StarDetector_setLineThresholdProjected(cv::xfeatures2d::StarDetector *obj, int val)
{
    return cvTry([&] {
        obj->setLineThresholdProjected(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_StarDetector_getLineThresholdProjected(cv::xfeatures2d::StarDetector *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getLineThresholdProjected();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_StarDetector_setLineThresholdBinarized(cv::xfeatures2d::StarDetector *obj, int val)
{
    return cvTry([&] {
        obj->setLineThresholdBinarized(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_StarDetector_getLineThresholdBinarized(cv::xfeatures2d::StarDetector *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getLineThresholdBinarized();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_StarDetector_setSuppressNonmaxSize(cv::xfeatures2d::StarDetector *obj, int val)
{
    return cvTry([&] {
        obj->setSuppressNonmaxSize(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_StarDetector_getSuppressNonmaxSize(cv::xfeatures2d::StarDetector *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSuppressNonmaxSize();
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

CVAPI(ExceptionStatus) xfeatures2d_LUCID_setLucidKernel(cv::xfeatures2d::LUCID *obj, int val)
{
    return cvTry([&] {
        obj->setLucidKernel(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_LUCID_getLucidKernel(cv::xfeatures2d::LUCID *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getLucidKernel();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_LUCID_setBlurKernel(cv::xfeatures2d::LUCID *obj, int val)
{
    return cvTry([&] {
        obj->setBlurKernel(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_LUCID_getBlurKernel(cv::xfeatures2d::LUCID *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getBlurKernel();
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

CVAPI(ExceptionStatus) xfeatures2d_LATCH_setBytes(cv::xfeatures2d::LATCH *obj, int val)
{
    return cvTry([&] {
        obj->setBytes(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_LATCH_getBytes(cv::xfeatures2d::LATCH *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getBytes();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_LATCH_setRotationInvariance(cv::xfeatures2d::LATCH *obj, int val)
{
    return cvTry([&] {
        obj->setRotationInvariance(val != 0);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_LATCH_getRotationInvariance(cv::xfeatures2d::LATCH *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRotationInvariance() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_LATCH_setHalfSSDsize(cv::xfeatures2d::LATCH *obj, int val)
{
    return cvTry([&] {
        obj->setHalfSSDsize(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_LATCH_getHalfSSDsize(cv::xfeatures2d::LATCH *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getHalfSSDsize();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_LATCH_setSigma(cv::xfeatures2d::LATCH *obj, double val)
{
    return cvTry([&] {
        obj->setSigma(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_LATCH_getSigma(cv::xfeatures2d::LATCH *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getSigma();
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
