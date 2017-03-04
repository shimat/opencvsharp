#ifndef _CPP_XFEATURES2D_H_
#define _CPP_XFEATURES2D_H_

#include "include_opencv.h"
using namespace cv::xfeatures2d;

#pragma region BriefDescriptorExtractor

CVAPI(cv::Ptr<BriefDescriptorExtractor>*) xfeatures2d_BriefDescriptorExtractor_create(int bytes)
{
    cv::Ptr<BriefDescriptorExtractor> ptr = BriefDescriptorExtractor::create(bytes);
    return new cv::Ptr<BriefDescriptorExtractor>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_BriefDescriptorExtractor_delete(cv::Ptr<BriefDescriptorExtractor> *obj)
{
    delete obj;
}

CVAPI(void) xfeatures2d_BriefDescriptorExtractor_read(
    cv::Ptr<BriefDescriptorExtractor> *obj, cv::FileNode *fn)
{
    obj->get()->read(*fn);
}
CVAPI(void) xfeatures2d_BriefDescriptorExtractor_write(
    cv::Ptr<BriefDescriptorExtractor> *obj, cv::FileStorage *fs)
{
    obj->get()->write(*fs);
}

CVAPI(int) xfeatures2d_BriefDescriptorExtractor_descriptorSize(cv::Ptr<BriefDescriptorExtractor> *obj)
{
    return obj->get()->descriptorSize();
}
CVAPI(int) xfeatures2d_BriefDescriptorExtractor_descriptorType(cv::Ptr<BriefDescriptorExtractor> *obj)
{
    return obj->get()->descriptorType();
}

CVAPI(BriefDescriptorExtractor*) xfeatures2d_Ptr_BriefDescriptorExtractor_get(
    cv::Ptr<BriefDescriptorExtractor>* ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region FREAK

CVAPI(cv::Ptr<FREAK>*) xfeatures2d_FREAK_create(int orientationNormalized,
    int scaleNormalized, float patternScale, int nOctaves,
    int *selectedPairs, int selectedPairsLength)
{
    std::vector<int> selectedPairsVec;
    if (selectedPairs != NULL)
        selectedPairsVec = std::vector<int>(selectedPairs, selectedPairs + selectedPairsLength);
    cv::Ptr<FREAK> ptr = FREAK::create(orientationNormalized != 0, scaleNormalized != 0,
        patternScale, nOctaves, selectedPairsVec);
    return new cv::Ptr<FREAK>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_FREAK_delete(cv::Ptr<FREAK> *ptr)
{
    delete ptr;
}

CVAPI(FREAK*) xfeatures2d_Ptr_FREAK_get(cv::Ptr<FREAK> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region StarDetector

CVAPI(cv::Ptr<StarDetector>*) xfeatures2d_StarDetector_create(int maxSize, int responseThreshold,
    int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize)
{
    cv::Ptr<StarDetector> ptr = StarDetector::create(
        maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);
    return new cv::Ptr<StarDetector>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_StarDetector_delete(cv::Ptr<StarDetector> *ptr)
{
    delete ptr;
}

CVAPI(StarDetector*) xfeatures2d_Ptr_StarDetector_get(cv::Ptr<StarDetector> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region SIFT

CVAPI(cv::Ptr<SIFT>*) xfeatures2d_SIFT_create(
    int nfeatures, int nOctaveLayers,
    double contrastThreshold, double edgeThreshold, double sigma)
{
    cv::Ptr<SIFT> ptr = SIFT::create(
        nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma);
    return new cv::Ptr<SIFT>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_SIFT_delete(cv::Ptr<SIFT> *ptr)
{
    delete ptr;
}

CVAPI(SIFT*) xfeatures2d_Ptr_SIFT_get(cv::Ptr<SIFT> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region SURF

CVAPI(cv::Ptr<SURF>*) xfeatures2d_SURF_create(double hessianThreshold, int nOctaves,
    int nOctaveLayers, int extended, int upright)
{
    cv::Ptr<SURF> ptr = SURF::create(
        hessianThreshold, nOctaves, nOctaveLayers, extended != 0, upright != 0);
    return new cv::Ptr<SURF>(ptr);
}
CVAPI(void) xfeatures2d_Ptr_SURF_delete(cv::Ptr<SURF> *ptr)
{
    delete ptr;
}

CVAPI(SURF*) xfeatures2d_Ptr_SURF_get(cv::Ptr<SURF> *ptr)
{
    return ptr->get();
}

CVAPI(double) xfeatures2d_SURF_getHessianThreshold(SURF *obj)
{
    return obj->getHessianThreshold();
}
CVAPI(int) xfeatures2d_SURF_getNOctaves(SURF *obj)
{
    return obj->getNOctaves();
}
CVAPI(int) xfeatures2d_SURF_getNOctaveLayers(SURF *obj)
{
    return obj->getNOctaveLayers();
}
CVAPI(int) xfeatures2d_SURF_getExtended(SURF *obj)
{
    return obj->getExtended() ? 1 : 0;
}
CVAPI(int) xfeatures2d_SURF_getUpright(SURF *obj)
{
    return obj->getUpright() ? 1 : 0;
}

CVAPI(void) xfeatures2d_SURF_setHessianThreshold(SURF *obj, double value)
{
    obj->setHessianThreshold(value);
}
CVAPI(void) xfeatures2d_SURF_setNOctaves(SURF *obj, int value)
{
    obj->setNOctaves(value);
}
CVAPI(void) xfeatures2d_SURF_setNOctaveLayers(SURF *obj, int value)
{
    obj->setNOctaveLayers(value);
}
CVAPI(void) xfeatures2d_SURF_setExtended(SURF *obj, int value)
{
    obj->setExtended(value != 0);
}
CVAPI(void) xfeatures2d_SURF_setUpright(SURF *obj, int value)
{
    obj->setUpright(value != 0);
}

#pragma endregion

#endif