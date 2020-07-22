#ifndef _CPP_FEATURES2DFEATUREDETECTOR_H_
#define _CPP_FEATURES2DFEATUREDETECTOR_H_

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable CppInconsistentNaming

#include "include_opencv.h"

#pragma region Feature2D

/*CVAPI(ExceptionStatus) features2d_Ptr_Feature2D_get(cv::Ptr<cv::Feature2D>* ptr, cv::Feature2D **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}*/
/*CVAPI(ExceptionStatus) features2d_Ptr_Feature2D_delete(cv::Ptr<cv::Feature2D>* ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}*/

CVAPI(ExceptionStatus) features2d_Feature2D_detect_Mat1(
    cv::Feature2D *detector,
    cv::Mat *image,
    std::vector<cv::KeyPoint> *keypoints,
    cv::Mat *mask)
{
    BEGIN_WRAP
    detector->detect(*image, *keypoints, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_detect_Mat2(
    cv::Feature2D *detector,
    cv::Mat **images, int imageLength,
    std::vector<std::vector<cv::KeyPoint> > *keypoints, 
    cv::Mat **mask)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imageVec(imageLength);
    std::vector<cv::Mat> maskVec;
    
    for (auto i = 0; i < imageLength; i++)
        imageVec.push_back(*images[i]);
    
    if (mask != nullptr)
    {
        maskVec.reserve(imageLength);
        for (auto i = 0; i < imageLength; i++)
            maskVec.push_back(*mask[i]);
    }

    detector->detect(imageVec, *keypoints, maskVec);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_detect_InputArray(
    cv::Feature2D *obj, cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::Mat *mask)
{
    BEGIN_WRAP
    obj->detect(*image, *keypoints, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_compute1(
    cv::Feature2D *obj,
    cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors)
{
    BEGIN_WRAP
    obj->compute(*image, *keypoints, *descriptors);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_compute2(
    cv::Feature2D *detector, cv::Mat **images, int imageLength,
    std::vector<std::vector<cv::KeyPoint> > *keypoints, cv::Mat **descriptors, int descriptorsLength)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imageVec(imageLength);
    std::vector<cv::Mat> descriptorsVec(descriptorsLength);
    
    for (auto i = 0; i < imageLength; i++)
        imageVec.push_back(*images[i]);
    for (auto i = 0; i < descriptorsLength; i++)
        descriptorsVec.push_back(*descriptors[i]);

    detector->compute(imageVec, *keypoints, descriptorsVec);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_detectAndCompute(
    cv::Feature2D *detector, cv::_InputArray *image, cv::_InputArray *mask, 
    std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors, int useProvidedKeypoints)
{
    BEGIN_WRAP
    detector->detectAndCompute(entity(image), entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_descriptorSize(cv::Feature2D *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->descriptorSize();
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Feature2D_descriptorType(cv::Feature2D *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->descriptorType();
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Feature2D_defaultNorm(cv::Feature2D *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->defaultNorm();
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Feature2D_empty(cv::Feature2D *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_write(cv::Feature2D *obj, const char *fileName)
{
    BEGIN_WRAP
    const cv::String fileNameString(fileName);
    obj->write(fileNameString);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_read(cv::Feature2D *obj, const char *fileName)
{
    BEGIN_WRAP
    obj->read(fileName);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Feature2D_getDefaultName(cv::Feature2D *obj, std::string *returnValue)
{
    BEGIN_WRAP
    returnValue->assign(obj->getDefaultName());
    END_WRAP
}

#pragma endregion

#pragma region SIFT

CVAPI(ExceptionStatus) features2d_SIFT_create(
    int nfeatures, int nOctaveLayers,
    double contrastThreshold, double edgeThreshold, double sigma, 
    cv::Ptr<cv::SIFT> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::SIFT::create(
        nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_SIFT_delete(cv::Ptr<cv::SIFT> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_SIFT_get(cv::Ptr<cv::SIFT> *ptr, cv::SIFT **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region BRISK

CVAPI(ExceptionStatus) features2d_BRISK_create1(
    int thresh, int octaves, float patternScale, cv::Ptr<cv::BRISK> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::BRISK::create(thresh, octaves, patternScale);
    *returnValue = clone(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_BRISK_create2(
    float *radiusList, int radiusListLength, 
    int *numberList, int numberListLength,
    float dMax, float dMin,
    int *indexChange, int indexChangeLength, 
    cv::Ptr<cv::BRISK> **returnValue)
{
    BEGIN_WRAP
    const std::vector<float> radiusListVec(radiusList, radiusList + radiusListLength);
    const std::vector<int> numberListVec(numberList, numberList + numberListLength);
    std::vector<int> indexChangeVec;
    if (indexChange != nullptr)
        indexChangeVec = std::vector<int>(indexChange, indexChange + indexChangeLength);

    const auto ptr = cv::BRISK::create(radiusListVec, numberListVec, dMax, dMin, indexChangeVec);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BRISK_create3(
    int thresh, int octaves, 
    float *radiusList, int radiusListLength,
    int *numberList, int numberListLength,
    float dMax, float dMin,
    int *indexChange, int indexChangeLength, 
    cv::Ptr<cv::BRISK> **returnValue)
{
    BEGIN_WRAP
    const std::vector<float> radiusListVec(radiusList, radiusList + radiusListLength);
    const std::vector<int> numberListVec(numberList, numberList + numberListLength);
    std::vector<int> indexChangeVec;
    if (indexChange != nullptr)
        indexChangeVec = std::vector<int>(indexChange, indexChange + indexChangeLength);

    const auto ptr = cv::BRISK::create(thresh, octaves, radiusListVec, numberListVec, dMax, dMin, indexChangeVec);
    *returnValue = clone(ptr);
    END_WRAP  
}

CVAPI(ExceptionStatus) features2d_Ptr_BRISK_delete(cv::Ptr<cv::BRISK> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_BRISK_get(cv::Ptr<cv::BRISK> *ptr, cv::BRISK **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region ORB

CVAPI(ExceptionStatus) features2d_ORB_create(
    int nFeatures, float scaleFactor, int nlevels, int edgeThreshold,
    int firstLevel, int wtaK, int scoreType, int patchSize, int fastThreshold,
    cv::Ptr<cv::ORB> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ORB::create(
        nFeatures, scaleFactor, nlevels, edgeThreshold, firstLevel, wtaK, static_cast<cv::ORB::ScoreType>(scoreType), patchSize, fastThreshold);
    *returnValue = clone(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Ptr_ORB_delete(cv::Ptr<cv::ORB> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_ORB_get(cv::Ptr<cv::ORB> *ptr, cv::ORB **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


CVAPI(ExceptionStatus) features2d_ORB_setMaxFeatures(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxFeatures(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_ORB_getMaxFeatures(cv::ORB *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxFeatures();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_ORB_setScaleFactor(cv::ORB *obj, double val)
{
    BEGIN_WRAP
    obj->setScaleFactor(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_ORB_getScaleFactor(cv::ORB *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getScaleFactor();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_ORB_setNLevels(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setNLevels(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_ORB_getNLevels(cv::ORB *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNLevels();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_ORB_setEdgeThreshold(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setEdgeThreshold(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_ORB_getEdgeThreshold(cv::ORB *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getEdgeThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_ORB_setFirstLevel(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setFirstLevel(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_ORB_getFirstLevel(cv::ORB *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getFirstLevel();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_ORB_setWTA_K(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setWTA_K(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_ORB_getWTA_K(cv::ORB *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getWTA_K();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_ORB_setScoreType(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setScoreType(static_cast<cv::ORB::ScoreType>(val));
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_ORB_getScoreType(cv::ORB *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->getScoreType());
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_ORB_setPatchSize(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setPatchSize(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_ORB_getPatchSize(cv::ORB *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getPatchSize();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_ORB_setFastThreshold(cv::ORB *obj, int val)
{
    BEGIN_WRAP
    obj->setFastThreshold(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_ORB_getFastThreshold(cv::ORB *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getFastThreshold();
    END_WRAP
}

#pragma endregion

#pragma region MSER

CVAPI(ExceptionStatus) features2d_MSER_create(int delta, int minArea, int maxArea,
    double maxVariation, double minDiversity, int maxEvolution,
    double areaThreshold, double minMargin, int edgeBlurSize,
    cv::Ptr<cv::MSER> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::MSER::create(delta, minArea, maxArea, maxVariation, minDiversity, maxEvolution,
        areaThreshold, minMargin, edgeBlurSize);
    *returnValue = clone(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Ptr_MSER_delete(cv::Ptr<cv::MSER> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_MSER_detectRegions(
    cv::MSER *obj,
    cv::_InputArray *image,
    std::vector<std::vector<cv::Point> > *msers,
    std::vector<cv::Rect> *bboxes)
{
    BEGIN_WRAP
    obj->detectRegions(*image, *msers, *bboxes);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_MSER_get(cv::Ptr<cv::MSER> *ptr, cv::MSER **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_MSER_setDelta(cv::MSER *obj, int delta)
{
    BEGIN_WRAP
    obj->setDelta(delta);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_MSER_getDelta(cv::MSER *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDelta();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_MSER_setMinArea(cv::MSER *obj, int minArea)
{
    BEGIN_WRAP
    obj->setMinArea(minArea);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_MSER_getMinArea(cv::MSER *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinArea();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_MSER_setMaxArea(cv::MSER *obj, int maxArea)
{
    BEGIN_WRAP
    obj->setMaxArea(maxArea);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_MSER_getMaxArea(cv::MSER *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxArea();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_MSER_setPass2Only(cv::MSER *obj, int f)
{
    BEGIN_WRAP
    obj->setPass2Only(f != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_MSER_getPass2Only(cv::MSER *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getPass2Only() ? 1 : 0;
    END_WRAP
}

#pragma endregion

#pragma region FastFeatureDetector

CVAPI(ExceptionStatus) features2d_FAST1(cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, int threshold, int nonmaxSupression)
{
    BEGIN_WRAP
    cv::FAST(*image, *keypoints, threshold, nonmaxSupression != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_FAST2(cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, int threshold, int nonmaxSupression, int type)
{
    BEGIN_WRAP
    cv::FAST(*image, *keypoints, threshold, nonmaxSupression != 0, static_cast<cv::FastFeatureDetector::DetectorType>(type));
    END_WRAP
}


CVAPI(ExceptionStatus) features2d_FastFeatureDetector_create(
    int threshold, int nonmaxSuppression, cv::Ptr<cv::FastFeatureDetector> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::FastFeatureDetector::create(threshold, nonmaxSuppression != 0);
    *returnValue = clone(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Ptr_FastFeatureDetector_delete(cv::Ptr<cv::FastFeatureDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_FastFeatureDetector_get(cv::Ptr<cv::FastFeatureDetector> *ptr, cv::FastFeatureDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_FastFeatureDetector_setThreshold(cv::FastFeatureDetector *obj, int threshold)
{
    BEGIN_WRAP
    obj->setThreshold(threshold);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_FastFeatureDetector_getThreshold(cv::FastFeatureDetector *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_FastFeatureDetector_setNonmaxSuppression(cv::FastFeatureDetector *obj, int f)
{
    BEGIN_WRAP
    obj->setNonmaxSuppression(f != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_FastFeatureDetector_getNonmaxSuppression(cv::FastFeatureDetector *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNonmaxSuppression() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_FastFeatureDetector_setType(cv::FastFeatureDetector *obj, int type)
{
    BEGIN_WRAP
    obj->setType(static_cast<cv::FastFeatureDetector::DetectorType>(type));
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_FastFeatureDetector_getType(cv::FastFeatureDetector *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->getType());
    END_WRAP
}

#pragma endregion

#pragma region

CVAPI(ExceptionStatus) features2d_AGAST(
    cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints,
    int threshold, int nonmaxSuppression, int type)
{
    BEGIN_WRAP
    cv::AGAST(
        entity(image),
        *keypoints,
        threshold,
        nonmaxSuppression != 0, 
        static_cast<cv::AgastFeatureDetector::DetectorType>(type));
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AgastFeatureDetector_create(
    int threshold, int nonmaxSuppression, int type, cv::Ptr<cv::AgastFeatureDetector> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::AgastFeatureDetector::create(
        threshold, nonmaxSuppression != 0, static_cast<cv::AgastFeatureDetector::DetectorType>(type));
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_AgastFeatureDetector_delete(cv::Ptr<cv::AgastFeatureDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_AgastFeatureDetector_get(cv::Ptr<cv::AgastFeatureDetector> *ptr, cv::AgastFeatureDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AgastFeatureDetector_setThreshold(cv::AgastFeatureDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setThreshold(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AgastFeatureDetector_getThreshold(cv::AgastFeatureDetector *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AgastFeatureDetector_setNonmaxSuppression(cv::AgastFeatureDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setNonmaxSuppression(val != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AgastFeatureDetector_getNonmaxSuppression(cv::AgastFeatureDetector *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNonmaxSuppression() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AgastFeatureDetector_setType(cv::AgastFeatureDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setType(static_cast<cv::AgastFeatureDetector::DetectorType>(val));
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AgastFeatureDetector_getType(cv::AgastFeatureDetector *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->getType());
    END_WRAP
}

#pragma endregion

#pragma region GFTTDetector

CVAPI(ExceptionStatus) features2d_GFTTDetector_create(
    int maxCorners, double qualityLevel, double minDistance,
    int blockSize, int useHarrisDetector, double k,
    cv::Ptr<cv::GFTTDetector> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::GFTTDetector::create(
        maxCorners, qualityLevel, minDistance,
        blockSize, useHarrisDetector != 0, k);
    *returnValue = clone(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Ptr_GFTTDetector_delete(cv::Ptr<cv::GFTTDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_GFTTDetector_get(cv::Ptr<cv::GFTTDetector> *ptr, cv::GFTTDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue =  ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_GFTTDetector_setMaxFeatures(cv::GFTTDetector *obj, int maxFeatures)
{
    BEGIN_WRAP
    obj->setMaxFeatures(maxFeatures);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_GFTTDetector_getMaxFeatures(cv::GFTTDetector *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxFeatures();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_GFTTDetector_setQualityLevel(cv::GFTTDetector *obj, double qlevel)
{
    BEGIN_WRAP
    obj->setQualityLevel(qlevel);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_GFTTDetector_getQualityLevel(cv::GFTTDetector *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getQualityLevel();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_GFTTDetector_setMinDistance(cv::GFTTDetector *obj, double minDistance)
{
    BEGIN_WRAP
    obj->setMinDistance(minDistance);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_GFTTDetector_getMinDistance(cv::GFTTDetector *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinDistance();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_GFTTDetector_setBlockSize(cv::GFTTDetector *obj, int blockSize)
{
    BEGIN_WRAP
    obj->setBlockSize(blockSize);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_GFTTDetector_getBlockSize(cv::GFTTDetector *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getBlockSize();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_GFTTDetector_setHarrisDetector(cv::GFTTDetector *obj, int val)
{
    BEGIN_WRAP
    obj->setHarrisDetector(val != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_GFTTDetector_getHarrisDetector(cv::GFTTDetector *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getHarrisDetector() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_GFTTDetector_setK(cv::GFTTDetector *obj, double k)
{
    BEGIN_WRAP
    obj->setK(k);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_GFTTDetector_getK(cv::GFTTDetector *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getK();
    END_WRAP
}

#pragma endregion

#pragma region SimbpleBlobDetector

struct SimpleBlobDetector_Params
{
    float thresholdStep;
    float minThreshold;
    float maxThreshold;
    uint32_t minRepeatability; // size_t
    float minDistBetweenBlobs;

    int filterByColor;
    uchar blobColor;

    int filterByArea;
    float minArea, maxArea;

    int filterByCircularity;
    float minCircularity, maxCircularity;

    int filterByInertia;
    float minInertiaRatio, maxInertiaRatio;

    int filterByConvexity;
    float minConvexity, maxConvexity;
};

CVAPI(ExceptionStatus) features2d_SimpleBlobDetector_create(
    SimpleBlobDetector_Params *p, cv::Ptr<cv::SimpleBlobDetector> **returnValue)
{
    BEGIN_WRAP
    cv::SimpleBlobDetector::Params p2;
    if (p != nullptr)
    {
        p2.thresholdStep = p->thresholdStep;
        p2.minThreshold = p->minThreshold;
        p2.maxThreshold = p->maxThreshold;
        p2.minRepeatability = static_cast<size_t>(p->minRepeatability);
        p2.minDistBetweenBlobs = p->minDistBetweenBlobs;
        p2.filterByColor = p->filterByColor != 0;
        p2.blobColor = p->blobColor;
        p2.filterByArea = p->filterByArea != 0;
        p2.minArea = p->minArea;
        p2.maxArea = p->maxArea;
        p2.filterByCircularity = p->filterByCircularity != 0;
        p2.minCircularity = p->minCircularity;
        p2.maxCircularity = p->maxCircularity;
        p2.filterByInertia = p->filterByInertia != 0;
        p2.minInertiaRatio = p->minInertiaRatio;
        p2.maxInertiaRatio = p->maxInertiaRatio;
        p2.filterByConvexity = p->filterByConvexity != 0;
        p2.minConvexity = p->minConvexity;
        p2.maxConvexity = p->maxConvexity;
    }
    const auto ptr = cv::SimpleBlobDetector::create(p2);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_SimpleBlobDetector_delete(cv::Ptr<cv::SimpleBlobDetector> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_SimpleBlobDetector_get(
    cv::Ptr<cv::SimpleBlobDetector> *ptr, cv::SimpleBlobDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

#pragma endregion

#pragma region KAZE

CVAPI(ExceptionStatus) features2d_KAZE_create(
    int extended, int upright, float threshold,
    int nOctaves, int nOctaveLayers, int diffusivity,
    cv::Ptr<cv::KAZE> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::KAZE::create(
        extended != 0, upright != 0, threshold,
        nOctaves, nOctaveLayers, static_cast<cv::KAZE::DiffusivityType>(diffusivity));
    *returnValue = clone(ptr);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Ptr_KAZE_delete(cv::Ptr<cv::KAZE> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_KAZE_get(cv::Ptr<cv::KAZE> *ptr, cv::KAZE **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KAZE_setDiffusivity(cv::KAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setDiffusivity(static_cast<cv::KAZE::DiffusivityType>(val));
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_KAZE_getDiffusivity(cv::KAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->getDiffusivity());
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KAZE_setExtended(cv::KAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setExtended(val != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_KAZE_getExtended(cv::KAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getExtended() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KAZE_setNOctaveLayers(cv::KAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setNOctaveLayers(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_KAZE_getNOctaveLayers(cv::KAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNOctaveLayers();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KAZE_setNOctaves(cv::KAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setNOctaves(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_KAZE_getNOctaves(cv::KAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNOctaves();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KAZE_setThreshold(cv::KAZE *obj, double val)
{
    BEGIN_WRAP
    obj->setThreshold(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_KAZE_getThreshold(cv::KAZE *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_KAZE_setUpright(cv::KAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setUpright(val != 0);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_KAZE_getUpright(cv::KAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getUpright() ? 1 : 0;
    END_WRAP
}

#pragma endregion

#pragma region AKAZE

CVAPI(ExceptionStatus) features2d_AKAZE_create(
    int descriptor_type, int descriptor_size, int descriptor_channels,
    float threshold, int nOctaves, int nOctaveLayers, int diffusivity,
    cv::Ptr<cv::AKAZE> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::AKAZE::create(
        static_cast<cv::AKAZE::DescriptorType>(descriptor_type), descriptor_size, descriptor_channels,
        threshold, nOctaves, nOctaveLayers, static_cast<cv::KAZE::DiffusivityType>(diffusivity));
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_AKAZE_delete(cv::Ptr<cv::AKAZE> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_AKAZE_get(cv::Ptr<cv::AKAZE> *ptr, cv::AKAZE **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AKAZE_setDescriptorType(cv::AKAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setDescriptorType(static_cast<cv::AKAZE::DescriptorType>(val));
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AKAZE_getDescriptorType(cv::AKAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->getDescriptorType());
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AKAZE_setDescriptorSize(cv::AKAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setDescriptorSize(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AKAZE_getDescriptorSize(cv::AKAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDescriptorSize();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AKAZE_setDescriptorChannels(cv::AKAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setDescriptorChannels(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AKAZE_getDescriptorChannels(cv::AKAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDescriptorChannels();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AKAZE_setThreshold(cv::AKAZE *obj, double val)
{
    BEGIN_WRAP
    obj->setThreshold(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AKAZE_getThreshold(cv::AKAZE *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getThreshold();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AKAZE_setNOctaves(cv::AKAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setNOctaves(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AKAZE_getNOctaves(cv::AKAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNOctaves();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AKAZE_setNOctaveLayers(cv::AKAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setNOctaveLayers(val);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AKAZE_getNOctaveLayers(cv::AKAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNOctaveLayers();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_AKAZE_setDiffusivity(cv::AKAZE *obj, int val)
{
    BEGIN_WRAP
    obj->setDiffusivity(static_cast<cv::KAZE::DiffusivityType>(val));
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_AKAZE_getDiffusivity(cv::AKAZE *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->getDiffusivity());
    END_WRAP
}

#pragma endregion 

#endif