#ifndef _CPP_XFEATURES2D_H_
#define _CPP_XFEATURES2D_H_

#include "include_opencv.h"

#pragma region BriefDescriptorExtractor

CVAPI(cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor>*) xfeatures2d_BriefDescriptorExtractor_create(int bytes)
{
    const auto ptr = cv::xfeatures2d::BriefDescriptorExtractor::create(bytes);
    return new cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_BriefDescriptorExtractor_delete(cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj)
{
    delete obj;
}

CVAPI(void) xfeatures2d_BriefDescriptorExtractor_read(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj, cv::FileNode *fn)
{
    obj->get()->read(*fn);
}
CVAPI(void) xfeatures2d_BriefDescriptorExtractor_write(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj, cv::FileStorage *fs)
{
    obj->get()->write(*fs);
}

CVAPI(int) xfeatures2d_BriefDescriptorExtractor_descriptorSize(cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj)
{
    return obj->get()->descriptorSize();
}
CVAPI(int) xfeatures2d_BriefDescriptorExtractor_descriptorType(cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor> *obj)
{
    return obj->get()->descriptorType();
}

CVAPI(cv::xfeatures2d::BriefDescriptorExtractor*) xfeatures2d_Ptr_BriefDescriptorExtractor_get(
    cv::Ptr<cv::xfeatures2d::BriefDescriptorExtractor>* ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region FREAK

CVAPI(cv::Ptr<cv::xfeatures2d::FREAK>*) xfeatures2d_FREAK_create(int orientationNormalized,
    int scaleNormalized, float patternScale, int nOctaves,
    int *selectedPairs, int selectedPairsLength)
{
    std::vector<int> selectedPairsVec;
    if (selectedPairs != NULL)
        selectedPairsVec = std::vector<int>(selectedPairs, selectedPairs + selectedPairsLength);
    const auto ptr = cv::xfeatures2d::FREAK::create(orientationNormalized != 0, scaleNormalized != 0,
        patternScale, nOctaves, selectedPairsVec);
    return new cv::Ptr<cv::xfeatures2d::FREAK>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_FREAK_delete(cv::Ptr<cv::xfeatures2d::FREAK> *ptr)
{
    delete ptr;
}

CVAPI(cv::xfeatures2d::FREAK*) xfeatures2d_Ptr_FREAK_get(cv::Ptr<cv::xfeatures2d::FREAK> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region StarDetector

CVAPI(cv::Ptr<cv::xfeatures2d::StarDetector>*) xfeatures2d_StarDetector_create(int maxSize, int responseThreshold,
    int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize)
{
    const auto ptr = cv::xfeatures2d::StarDetector::create(
        maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);
    return new cv::Ptr<cv::xfeatures2d::StarDetector>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_StarDetector_delete(cv::Ptr<cv::xfeatures2d::StarDetector> *ptr)
{
    delete ptr;
}

CVAPI(cv::xfeatures2d::StarDetector*) xfeatures2d_Ptr_StarDetector_get(cv::Ptr<cv::xfeatures2d::StarDetector> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region LUCID

CVAPI(cv::Ptr<cv::xfeatures2d::LUCID>*) xfeatures2d_LUCID_create(const int lucid_kernel = 1, const int blur_kernel = 2)
{
    const auto ptr = cv::xfeatures2d::LUCID::create(lucid_kernel, blur_kernel);
    return new cv::Ptr<cv::xfeatures2d::LUCID>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_LUCID_delete(cv::Ptr<cv::xfeatures2d::LUCID> *ptr)
{
    delete ptr;
}

CVAPI(cv::xfeatures2d::LUCID*) xfeatures2d_Ptr_LUCID_get(cv::Ptr<cv::xfeatures2d::LUCID> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region LATCH

CVAPI(cv::Ptr<cv::xfeatures2d::LATCH>*) xfeatures2d_LATCH_create(int bytes, int rotationInvariance, int half_ssd_size, double sigma)
{
    const auto ptr = cv::xfeatures2d::LATCH::create(bytes, rotationInvariance != 0, half_ssd_size, sigma);
    return new cv::Ptr<cv::xfeatures2d::LATCH>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_LATCH_delete(cv::Ptr<cv::xfeatures2d::LATCH> *ptr)
{
    delete ptr;
}

CVAPI(cv::xfeatures2d::LATCH*) xfeatures2d_Ptr_LATCH_get(cv::Ptr<cv::xfeatures2d::LATCH> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region SIFT

CVAPI(cv::Ptr<cv::xfeatures2d::SIFT>*) xfeatures2d_SIFT_create(
    int nfeatures, int nOctaveLayers,
    double contrastThreshold, double edgeThreshold, double sigma)
{
    const auto ptr = cv::xfeatures2d::SIFT::create(
        nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma);
    return new cv::Ptr<cv::xfeatures2d::SIFT>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_SIFT_delete(cv::Ptr<cv::xfeatures2d::SIFT> *ptr)
{
    delete ptr;
}

CVAPI(cv::xfeatures2d::SIFT*) xfeatures2d_Ptr_SIFT_get(cv::Ptr<cv::xfeatures2d::SIFT> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region SURF

CVAPI(cv::Ptr<cv::xfeatures2d::SURF>*) xfeatures2d_SURF_create(double hessianThreshold, int nOctaves,
    int nOctaveLayers, int extended, int upright)
{
    const auto ptr = cv::xfeatures2d::SURF::create(
        hessianThreshold, nOctaves, nOctaveLayers, extended != 0, upright != 0);
    return new cv::Ptr<cv::xfeatures2d::SURF>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_SURF_delete(cv::Ptr<cv::xfeatures2d::SURF> *ptr)
{
    delete ptr;
}

CVAPI(cv::xfeatures2d::SURF*) xfeatures2d_Ptr_SURF_get(cv::Ptr<cv::xfeatures2d::SURF> *ptr)
{
    return ptr->get();
}

CVAPI(double) xfeatures2d_SURF_getHessianThreshold(cv::xfeatures2d::SURF *obj)
{
    return obj->getHessianThreshold();
}
CVAPI(int) xfeatures2d_SURF_getNOctaves(cv::xfeatures2d::SURF *obj)
{
    return obj->getNOctaves();
}
CVAPI(int) xfeatures2d_SURF_getNOctaveLayers(cv::xfeatures2d::SURF *obj)
{
    return obj->getNOctaveLayers();
}
CVAPI(int) xfeatures2d_SURF_getExtended(cv::xfeatures2d::SURF *obj)
{
    return obj->getExtended() ? 1 : 0;
}
CVAPI(int) xfeatures2d_SURF_getUpright(cv::xfeatures2d::SURF *obj)
{
    return obj->getUpright() ? 1 : 0;
}

CVAPI(void) xfeatures2d_SURF_setHessianThreshold(cv::xfeatures2d::SURF *obj, double value)
{
    obj->setHessianThreshold(value);
}
CVAPI(void) xfeatures2d_SURF_setNOctaves(cv::xfeatures2d::SURF *obj, int value)
{
    obj->setNOctaves(value);
}
CVAPI(void) xfeatures2d_SURF_setNOctaveLayers(cv::xfeatures2d::SURF *obj, int value)
{
    obj->setNOctaveLayers(value);
}
CVAPI(void) xfeatures2d_SURF_setExtended(cv::xfeatures2d::SURF *obj, int value)
{
    obj->setExtended(value != 0);
}
CVAPI(void) xfeatures2d_SURF_setUpright(cv::xfeatures2d::SURF *obj, int value)
{
    obj->setUpright(value != 0);
}

#pragma endregion

#endif