#pragma once

#ifndef NO_FEATURES

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region Feature2D

CVAPI(ExceptionStatus) features_Feature2D_detect_Mat1(
    cv::Feature2D *detector,
    cv::Mat *image,
    std::vector<cv::KeyPoint> *keypoints,
    cv::Mat *mask)
{
    return cvTry([&] {
    detector->detect(*image, *keypoints, entity(mask));
    });
}

CVAPI(ExceptionStatus) features_Feature2D_detect_Mat2(
    cv::Feature2D *detector,
    cv::Mat **images,
    int imageLength,
    std::vector<std::vector<cv::KeyPoint> > *keypoints,
    cv::Mat **mask)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) features_Feature2D_detect_InputArray(
    cv::Feature2D *obj,
    const interop::InputArrayProxy* image,
    std::vector<cv::KeyPoint> *keypoints,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
    obj->detect(InProxy(*image), *keypoints, InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) features_Feature2D_compute1(
    cv::Feature2D *obj,
    const interop::InputArrayProxy* image,
    std::vector<cv::KeyPoint> *keypoints,
    const interop::OutputArrayProxy* descriptors)
{
    return cvTry([&] {
    obj->compute(InProxy(*image), *keypoints, OutProxy(*descriptors));
    });
}

CVAPI(ExceptionStatus) features_Feature2D_compute2(
    cv::Feature2D *detector,
    cv::Mat **images,
    int imageLength,
    std::vector<std::vector<cv::KeyPoint> > *keypoints,
    cv::Mat **descriptors,
    int descriptorsLength)
{
    return cvTry([&] {
    std::vector<cv::Mat> imageVec(imageLength);
    std::vector<cv::Mat> descriptorsVec(descriptorsLength);

    for (auto i = 0; i < imageLength; i++)
        imageVec.push_back(*images[i]);
    for (auto i = 0; i < descriptorsLength; i++)
        descriptorsVec.push_back(*descriptors[i]);

    detector->compute(imageVec, *keypoints, descriptorsVec);
    });
}

CVAPI(ExceptionStatus) features_Feature2D_detectAndCompute(
    cv::Feature2D *detector,
    const interop::InputArrayProxy* image,
    const interop::InputArrayProxy* mask,
    std::vector<cv::KeyPoint> *keypoints,
    const interop::OutputArrayProxy* descriptors,
    int useProvidedKeypoints)
{
    return cvTry([&] {
    detector->detectAndCompute(InProxy(*image), InProxy(*mask), *keypoints, OutProxy(*descriptors), useProvidedKeypoints != 0);
    });
}

CVAPI(ExceptionStatus) features_Feature2D_descriptorSize(cv::Feature2D *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->descriptorSize();
    });
}
CVAPI(ExceptionStatus) features_Feature2D_descriptorType(cv::Feature2D *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->descriptorType();
    });
}
CVAPI(ExceptionStatus) features_Feature2D_defaultNorm(cv::Feature2D *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->defaultNorm();
    });
}
CVAPI(ExceptionStatus) features_Feature2D_empty(cv::Feature2D *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->empty() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) features_Feature2D_write(cv::Feature2D *obj, const char *fileName)
{
    return cvTry([&] {
    const cv::String fileNameString(fileName);
    obj->write(fileNameString);
    });
}

CVAPI(ExceptionStatus) features_Feature2D_read(cv::Feature2D *obj, const char *fileName)
{
    return cvTry([&] {
    obj->read(fileName);
    });
}

CVAPI(ExceptionStatus) features_Feature2D_getDefaultName(cv::Feature2D *obj, std::string *returnValue)
{
    return cvTry([&] {
    returnValue->assign(obj->getDefaultName());
    });
}

#pragma endregion

#pragma region SIFT

CVAPI(ExceptionStatus) features_SIFT_create(
    int nfeatures,
    int nOctaveLayers,
    double contrastThreshold,
    double edgeThreshold,
    double sigma,
    cv::Ptr<cv::SIFT> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::SIFT::create(
        nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) features_Ptr_SIFT_delete(cv::Ptr<cv::SIFT> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

#pragma endregion


#pragma region ORB

CVAPI(ExceptionStatus) features_ORB_create(
    int nFeatures,
    float scaleFactor,
    int nlevels,
    int edgeThreshold,
    int firstLevel,
    int wtaK,
    int scoreType,
    int patchSize,
    int fastThreshold,
    cv::Ptr<cv::ORB> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ORB::create(
        nFeatures, scaleFactor, nlevels, edgeThreshold, firstLevel, wtaK, static_cast<cv::ORB::ScoreType>(scoreType), patchSize, fastThreshold);
    *returnValue = clone(ptr);
    });
}
CVAPI(ExceptionStatus) features_Ptr_ORB_delete(cv::Ptr<cv::ORB> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) features_ORB_setMaxFeatures(cv::ORB *obj, int val)
{
    return cvTry([&] {
    obj->setMaxFeatures(val);
    });
}
CVAPI(ExceptionStatus) features_ORB_getMaxFeatures(cv::ORB *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxFeatures();
    });
}

CVAPI(ExceptionStatus) features_ORB_setScaleFactor(cv::ORB *obj, double val)
{
    return cvTry([&] {
    obj->setScaleFactor(val);
    });
}
CVAPI(ExceptionStatus) features_ORB_getScaleFactor(cv::ORB *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getScaleFactor();
    });
}

CVAPI(ExceptionStatus) features_ORB_setNLevels(cv::ORB *obj, int val)
{
    return cvTry([&] {
    obj->setNLevels(val);
    });
}
CVAPI(ExceptionStatus) features_ORB_getNLevels(cv::ORB *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNLevels();
    });
}

CVAPI(ExceptionStatus) features_ORB_setEdgeThreshold(cv::ORB *obj, int val)
{
    return cvTry([&] {
    obj->setEdgeThreshold(val);
    });
}
CVAPI(ExceptionStatus) features_ORB_getEdgeThreshold(cv::ORB *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getEdgeThreshold();
    });
}

CVAPI(ExceptionStatus) features_ORB_setFirstLevel(cv::ORB *obj, int val)
{
    return cvTry([&] {
    obj->setFirstLevel(val);
    });
}
CVAPI(ExceptionStatus) features_ORB_getFirstLevel(cv::ORB *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getFirstLevel();
    });
}

CVAPI(ExceptionStatus) features_ORB_setWTA_K(cv::ORB *obj, int val)
{
    return cvTry([&] {
    obj->setWTA_K(val);
    });
}
CVAPI(ExceptionStatus) features_ORB_getWTA_K(cv::ORB *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getWTA_K();
    });
}

CVAPI(ExceptionStatus) features_ORB_setScoreType(cv::ORB *obj, int val)
{
    return cvTry([&] {
    obj->setScoreType(static_cast<cv::ORB::ScoreType>(val));
    });
}
CVAPI(ExceptionStatus) features_ORB_getScoreType(cv::ORB *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = static_cast<int>(obj->getScoreType());
    });
}

CVAPI(ExceptionStatus) features_ORB_setPatchSize(cv::ORB *obj, int val)
{
    return cvTry([&] {
    obj->setPatchSize(val);
    });
}
CVAPI(ExceptionStatus) features_ORB_getPatchSize(cv::ORB *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getPatchSize();
    });
}

CVAPI(ExceptionStatus) features_ORB_setFastThreshold(cv::ORB *obj, int val)
{
    return cvTry([&] {
    obj->setFastThreshold(val);
    });
}
CVAPI(ExceptionStatus) features_ORB_getFastThreshold(cv::ORB *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getFastThreshold();
    });
}

#pragma endregion

#pragma region MSER

CVAPI(ExceptionStatus) features_MSER_create(
    int delta,
    int minArea,
    int maxArea,
    double maxVariation,
    double minDiversity,
    int maxEvolution,
    double areaThreshold,
    double minMargin,
    int edgeBlurSize,
    cv::Ptr<cv::MSER> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::MSER::create(delta, minArea, maxArea, maxVariation, minDiversity, maxEvolution,
        areaThreshold, minMargin, edgeBlurSize);
    *returnValue = clone(ptr);
    });
}
CVAPI(ExceptionStatus) features_Ptr_MSER_delete(cv::Ptr<cv::MSER> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) features_MSER_detectRegions(
    cv::MSER *obj,
    const interop::InputArrayProxy* image,
    std::vector<std::vector<cv::Point> > *msers,
    std::vector<cv::Rect> *bboxes)
{
    return cvTry([&] {
    obj->detectRegions(InProxy(*image), *msers, *bboxes);
    });
}

CVAPI(ExceptionStatus) features_MSER_setDelta(cv::MSER *obj, int delta)
{
    return cvTry([&] {
    obj->setDelta(delta);
    });
}
CVAPI(ExceptionStatus) features_MSER_getDelta(cv::MSER *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getDelta();
    });
}

CVAPI(ExceptionStatus) features_MSER_setMinArea(cv::MSER *obj, int minArea)
{
    return cvTry([&] {
    obj->setMinArea(minArea);
    });
}
CVAPI(ExceptionStatus) features_MSER_getMinArea(cv::MSER *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMinArea();
    });
}

CVAPI(ExceptionStatus) features_MSER_setMaxArea(cv::MSER *obj, int maxArea)
{
    return cvTry([&] {
    obj->setMaxArea(maxArea);
    });
}
CVAPI(ExceptionStatus) features_MSER_getMaxArea(cv::MSER *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxArea();
    });
}

CVAPI(ExceptionStatus) features_MSER_setPass2Only(cv::MSER *obj, int f)
{
    return cvTry([&] {
    obj->setPass2Only(f != 0);
    });
}
CVAPI(ExceptionStatus) features_MSER_getPass2Only(cv::MSER *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getPass2Only() ? 1 : 0;
    });
}

#pragma endregion

#pragma region FastFeatureDetector

CVAPI(ExceptionStatus) features_FAST1(
    const interop::InputArrayProxy* image,
    std::vector<cv::KeyPoint> *keypoints,
    int threshold,
    int nonmaxSupression)
{
    return cvTry([&] {
    cv::FAST(InProxy(*image), *keypoints, threshold, nonmaxSupression != 0);
    });
}

CVAPI(ExceptionStatus) features_FAST2(
    const interop::InputArrayProxy* image,
    std::vector<cv::KeyPoint> *keypoints,
    int threshold,
    int nonmaxSupression,
    int type)
{
    return cvTry([&] {
    cv::FAST(InProxy(*image), *keypoints, threshold, nonmaxSupression != 0, static_cast<cv::FastFeatureDetector::DetectorType>(type));
    });
}


CVAPI(ExceptionStatus) features_FastFeatureDetector_create(
    int threshold,
    int nonmaxSuppression,
    cv::Ptr<cv::FastFeatureDetector> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::FastFeatureDetector::create(threshold, nonmaxSuppression != 0);
    *returnValue = clone(ptr);
    });
}
CVAPI(ExceptionStatus) features_Ptr_FastFeatureDetector_delete(cv::Ptr<cv::FastFeatureDetector> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) features_FastFeatureDetector_setThreshold(cv::FastFeatureDetector *obj, int threshold)
{
    return cvTry([&] {
    obj->setThreshold(threshold);
    });
}
CVAPI(ExceptionStatus) features_FastFeatureDetector_getThreshold(cv::FastFeatureDetector *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getThreshold();
    });
}

CVAPI(ExceptionStatus) features_FastFeatureDetector_setNonmaxSuppression(cv::FastFeatureDetector *obj, int f)
{
    return cvTry([&] {
    obj->setNonmaxSuppression(f != 0);
    });
}
CVAPI(ExceptionStatus) features_FastFeatureDetector_getNonmaxSuppression(cv::FastFeatureDetector *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNonmaxSuppression() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) features_FastFeatureDetector_setType(cv::FastFeatureDetector *obj, int type)
{
    return cvTry([&] {
    obj->setType(static_cast<cv::FastFeatureDetector::DetectorType>(type));
    });
}
CVAPI(ExceptionStatus) features_FastFeatureDetector_getType(cv::FastFeatureDetector *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = static_cast<int>(obj->getType());
    });
}

#pragma endregion


#pragma region GFTTDetector

CVAPI(ExceptionStatus) features_GFTTDetector_create(
    int maxCorners,
    double qualityLevel,
    double minDistance,
    int blockSize,
    int useHarrisDetector,
    double k,
    cv::Ptr<cv::GFTTDetector> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::GFTTDetector::create(
        maxCorners, qualityLevel, minDistance,
        blockSize, useHarrisDetector != 0, k);
    *returnValue = clone(ptr);
    });
}
CVAPI(ExceptionStatus) features_Ptr_GFTTDetector_delete(cv::Ptr<cv::GFTTDetector> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) features_GFTTDetector_setMaxFeatures(cv::GFTTDetector *obj, int maxFeatures)
{
    return cvTry([&] {
    obj->setMaxFeatures(maxFeatures);
    });
}
CVAPI(ExceptionStatus) features_GFTTDetector_getMaxFeatures(cv::GFTTDetector *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxFeatures();
    });
}

CVAPI(ExceptionStatus) features_GFTTDetector_setQualityLevel(cv::GFTTDetector *obj, double qlevel)
{
    return cvTry([&] {
    obj->setQualityLevel(qlevel);
    });
}
CVAPI(ExceptionStatus) features_GFTTDetector_getQualityLevel(cv::GFTTDetector *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getQualityLevel();
    });
}

CVAPI(ExceptionStatus) features_GFTTDetector_setMinDistance(cv::GFTTDetector *obj, double minDistance)
{
    return cvTry([&] {
    obj->setMinDistance(minDistance);
    });
}
CVAPI(ExceptionStatus) features_GFTTDetector_getMinDistance(cv::GFTTDetector *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMinDistance();
    });
}

CVAPI(ExceptionStatus) features_GFTTDetector_setBlockSize(cv::GFTTDetector *obj, int blockSize)
{
    return cvTry([&] {
    obj->setBlockSize(blockSize);
    });
}
CVAPI(ExceptionStatus) features_GFTTDetector_getBlockSize(cv::GFTTDetector *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getBlockSize();
    });
}

CVAPI(ExceptionStatus) features_GFTTDetector_setHarrisDetector(cv::GFTTDetector *obj, int val)
{
    return cvTry([&] {
    obj->setHarrisDetector(val != 0);
    });
}
CVAPI(ExceptionStatus) features_GFTTDetector_getHarrisDetector(cv::GFTTDetector *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getHarrisDetector() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) features_GFTTDetector_setK(cv::GFTTDetector *obj, double k)
{
    return cvTry([&] {
    obj->setK(k);
    });
}
CVAPI(ExceptionStatus) features_GFTTDetector_getK(cv::GFTTDetector *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getK();
    });
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

CVAPI(ExceptionStatus) features_SimpleBlobDetector_create(
    SimpleBlobDetector_Params *p, cv::Ptr<cv::SimpleBlobDetector> **returnValue)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) features_Ptr_SimpleBlobDetector_delete(cv::Ptr<cv::SimpleBlobDetector> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

#pragma endregion



CVAPI(ExceptionStatus) features_Ptr_Feature2D_get(cv::Ptr<cv::Feature2D> *obj, cv::Feature2D **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}


#pragma region AffineFeature

CVAPI(ExceptionStatus) features_AffineFeature_create(
    cv::Ptr<cv::Feature2D> *backend,
    int maxTilt,
    int minTilt,
    float tiltStep,
    float rotateStepBase,
    cv::Ptr<cv::AffineFeature> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::AffineFeature::create(*backend, maxTilt, minTilt, tiltStep, rotateStepBase);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) features_AffineFeature_setViewParams(
    cv::AffineFeature *obj,
    float *tilts,
    int tiltsLength,
    float *rolls,
    int rollsLength)
{
    return cvTry([&] {
    const std::vector<float> tiltsVec(tilts, tilts + tiltsLength);
    const std::vector<float> rollsVec(rolls, rolls + rollsLength);
    obj->setViewParams(tiltsVec, rollsVec);
    });
}

CVAPI(ExceptionStatus) features_AffineFeature_getViewParams(
    cv::AffineFeature *obj,
    std::vector<float> *tilts,
    std::vector<float> *rolls)
{
    return cvTry([&] {
    obj->getViewParams(*tilts, *rolls);
    });
}

CVAPI(ExceptionStatus) features_Ptr_AffineFeature_delete(cv::Ptr<cv::AffineFeature> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

#pragma endregion


#ifdef HAVE_OPENCV_DNN

#pragma region DISK

CVAPI(ExceptionStatus) features_DISK_create(
    const char *modelPath,
    int maxKeypoints,
    float scoreThreshold,
    interop::Size imageSize,
    int backendId,
    int targetId,
    cv::Ptr<cv::DISK> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::DISK::create(cv::String(modelPath), maxKeypoints, scoreThreshold, cpp(imageSize), backendId, targetId);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) features_DISK_create_buffer(
    const uchar *bufferModel,
    size_t bufferModelLength,
    int maxKeypoints,
    float scoreThreshold,
    interop::Size imageSize,
    int backendId,
    int targetId,
    cv::Ptr<cv::DISK> **returnValue)
{
    return cvTry([&] {
    const std::vector<uchar> buf(bufferModel, bufferModel + bufferModelLength);
    const auto ptr = cv::DISK::create(buf, maxKeypoints, scoreThreshold, cpp(imageSize), backendId, targetId);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) features_DISK_setMaxKeypoints(cv::DISK *obj, int maxKeypoints)
{
    return cvTry([&] {
    obj->setMaxKeypoints(maxKeypoints);
    });
}
CVAPI(ExceptionStatus) features_DISK_getMaxKeypoints(cv::DISK *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMaxKeypoints();
    });
}
CVAPI(ExceptionStatus) features_DISK_setScoreThreshold(cv::DISK *obj, float threshold)
{
    return cvTry([&] {
    obj->setScoreThreshold(threshold);
    });
}
CVAPI(ExceptionStatus) features_DISK_getScoreThreshold(cv::DISK *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getScoreThreshold();
    });
}
CVAPI(ExceptionStatus) features_DISK_setImageSize(cv::DISK *obj, interop::Size size)
{
    return cvTry([&] {
    obj->setImageSize(cpp(size));
    });
}
CVAPI(ExceptionStatus) features_DISK_getImageSize(cv::DISK *obj, interop::Size *returnValue)
{
    return cvTry([&] {
    *returnValue = c(obj->getImageSize());
    });
}

CVAPI(ExceptionStatus) features_Ptr_DISK_delete(cv::Ptr<cv::DISK> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

#pragma endregion


#pragma region ALIKED

CVAPI(ExceptionStatus) features_ALIKED_create(
    const char *modelPath,
    interop::Size inputSize,
    int normalizeDescriptors,
    int engine,
    int backend,
    int target,
    cv::Ptr<cv::ALIKED> **returnValue)
{
    return cvTry([&] {
    cv::ALIKED::Params params;
    params.inputSize = cpp(inputSize);
    params.normalizeDescriptors = normalizeDescriptors != 0;
    params.engine = engine;
    params.backend = backend;
    params.target = target;
    const auto ptr = cv::ALIKED::create(cv::String(modelPath), params);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) features_ALIKED_create_buffer(
    const uchar *modelData,
    size_t modelDataLength,
    interop::Size inputSize,
    int normalizeDescriptors,
    int engine,
    int backend,
    int target,
    cv::Ptr<cv::ALIKED> **returnValue)
{
    return cvTry([&] {
    const std::vector<uchar> buf(modelData, modelData + modelDataLength);
    cv::ALIKED::Params params;
    params.inputSize = cpp(inputSize);
    params.normalizeDescriptors = normalizeDescriptors != 0;
    params.engine = engine;
    params.backend = backend;
    params.target = target;
    const auto ptr = cv::ALIKED::create(buf, params);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) features_Ptr_ALIKED_delete(cv::Ptr<cv::ALIKED> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

#pragma endregion

#endif // HAVE_OPENCV_DNN

#endif // NO_FEATURES
