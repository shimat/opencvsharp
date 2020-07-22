#ifndef _CPP_XFEATURES2D_H_
#define _CPP_XFEATURES2D_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region BriefDescriptorExtractor

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_create(
    int bytes, cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::xfeatures2d::BriefDescriptorExtractor::create(bytes);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_BriefDescriptorExtractor_delete(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_read(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj, cv::FileNode *fn)
{
    BEGIN_WRAP
    obj->get()->read(*fn);
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_write(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj, cv::FileStorage *fs)
{
    BEGIN_WRAP
    obj->get()->write(*fs);
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_descriptorSize(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get()->descriptorSize();
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_BriefDescriptorExtractor_descriptorType(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get()->descriptorType();
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_BriefDescriptorExtractor_get(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor>* ptr, cv::xfeatures2d::BriefDescriptorExtractor **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region FREAK

CVAPI(ExceptionStatus) xfeatures2d_FREAK_create(
    int orientationNormalized, int scaleNormalized, float patternScale, int nOctaves,
    int *selectedPairs, int selectedPairsLength, 
    cv::Ptr<cv::xfeatures2d::FREAK> **returnValue)
{
    BEGIN_WRAP
    std::vector<int> selectedPairsVec;
    if (selectedPairs != nullptr)
        selectedPairsVec = std::vector<int>(selectedPairs, selectedPairs + selectedPairsLength);
    const auto ptr = cv::xfeatures2d::FREAK::create(
        orientationNormalized != 0, scaleNormalized != 0, patternScale, nOctaves, selectedPairsVec);
    *returnValue = clone(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) xfeatures2d_Ptr_FREAK_delete(cv::Ptr<cv::xfeatures2d::FREAK> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_FREAK_get(cv::Ptr<cv::xfeatures2d::FREAK> *ptr, cv::xfeatures2d::FREAK **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region StarDetector

CVAPI(ExceptionStatus) xfeatures2d_StarDetector_create(
    int maxSize, int responseThreshold,
    int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize, 
    cv::Ptr<cv::xfeatures2d::StarDetector> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::xfeatures2d::StarDetector::create(
        maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_StarDetector_delete(cv::Ptr<cv::xfeatures2d::StarDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_StarDetector_get(cv::Ptr<cv::xfeatures2d::StarDetector> *ptr, cv::xfeatures2d::StarDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region LUCID

CVAPI(ExceptionStatus) xfeatures2d_LUCID_create(const int lucid_kernel, const int blur_kernel, cv::Ptr<cv::xfeatures2d::LUCID> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::xfeatures2d::LUCID::create(lucid_kernel, blur_kernel);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_LUCID_delete(cv::Ptr<cv::xfeatures2d::LUCID> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_LUCID_get(cv::Ptr<cv::xfeatures2d::LUCID> *ptr, cv::xfeatures2d::LUCID **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region LATCH

CVAPI(ExceptionStatus) xfeatures2d_LATCH_create(
    int bytes, int rotationInvariance, int half_ssd_size, double sigma, 
    cv::Ptr<cv::xfeatures2d::LATCH> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::xfeatures2d::LATCH::create(bytes, rotationInvariance != 0, half_ssd_size, sigma);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_LATCH_delete(cv::Ptr<cv::xfeatures2d::LATCH> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_LATCH_get(cv::Ptr<cv::xfeatures2d::LATCH> *ptr, cv::xfeatures2d::LATCH **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion


#pragma region SURF

CVAPI(ExceptionStatus) xfeatures2d_SURF_create(
    double hessianThreshold, int nOctaves,
    int nOctaveLayers, int extended, int upright, 
    cv::Ptr<cv::xfeatures2d::SURF> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::xfeatures2d::SURF::create(
        hessianThreshold, nOctaves, nOctaveLayers, extended != 0, upright != 0);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_SURF_delete(cv::Ptr<cv::xfeatures2d::SURF> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_SURF_get(cv::Ptr<cv::xfeatures2d::SURF> *ptr, cv::xfeatures2d::SURF **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_SURF_getHessianThreshold(cv::xfeatures2d::SURF *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getHessianThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_getNOctaves(cv::xfeatures2d::SURF *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNOctaves();
    END_WRAP
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_getNOctaveLayers(cv::xfeatures2d::SURF *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNOctaveLayers();
    END_WRAP
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_getExtended(cv::xfeatures2d::SURF *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getExtended() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_getUpright(cv::xfeatures2d::SURF *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getUpright() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) xfeatures2d_SURF_setHessianThreshold(cv::xfeatures2d::SURF *obj, double value)
{
    BEGIN_WRAP
    obj->setHessianThreshold(value);
    END_WRAP
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_setNOctaves(cv::xfeatures2d::SURF *obj, int value)
{
    BEGIN_WRAP
    obj->setNOctaves(value);
    END_WRAP
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_setNOctaveLayers(cv::xfeatures2d::SURF *obj, int value)
{
    BEGIN_WRAP
    obj->setNOctaveLayers(value);
    END_WRAP
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_setExtended(cv::xfeatures2d::SURF *obj, int value)
{
    BEGIN_WRAP
    obj->setExtended(value != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) xfeatures2d_SURF_setUpright(cv::xfeatures2d::SURF *obj, int value)
{
    BEGIN_WRAP
    obj->setUpright(value != 0);
    END_WRAP
}

#pragma endregion

#endif