#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region PCTSignatures

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_create1(
    int initSampleCount, int initSeedCount, int pointDistribution,
    cv::Ptr<cv::xfeatures2d::PCTSignatures> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::PCTSignatures::create(initSampleCount, initSeedCount, pointDistribution);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_create2(
    cv::Point2f *initSamplingPoints, int initSamplingPointsLength, int initSeedCount,
    cv::Ptr<cv::xfeatures2d::PCTSignatures> **returnValue)
{
    return cvTry([&] {
        const std::vector<cv::Point2f> pointsVec(initSamplingPoints, initSamplingPoints + initSamplingPointsLength);
        const auto ptr = cv::xfeatures2d::PCTSignatures::create(pointsVec, initSeedCount);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_create3(
    cv::Point2f *initSamplingPoints, int initSamplingPointsLength,
    int *initClusterSeedIndexes, int initClusterSeedIndexesLength,
    cv::Ptr<cv::xfeatures2d::PCTSignatures> **returnValue)
{
    return cvTry([&] {
        const std::vector<cv::Point2f> pointsVec(initSamplingPoints, initSamplingPoints + initSamplingPointsLength);
        const std::vector<int> seedsVec(initClusterSeedIndexes, initClusterSeedIndexes + initClusterSeedIndexesLength);
        const auto ptr = cv::xfeatures2d::PCTSignatures::create(pointsVec, seedsVec);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_PCTSignatures_delete(cv::Ptr<cv::xfeatures2d::PCTSignatures> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_PCTSignatures_get(
    cv::Ptr<cv::xfeatures2d::PCTSignatures> *obj, cv::xfeatures2d::PCTSignatures **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_computeSignature(
    cv::xfeatures2d::PCTSignatures *obj, const interop::InputArrayProxy *image, const interop::OutputArrayProxy *signature)
{
    return cvTry([&] {
        obj->computeSignature(InProxy(*image), OutProxy(*signature));
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_computeSignatures(
    cv::xfeatures2d::PCTSignatures *obj, cv::Mat **images, int imagesLength, std::vector<cv::Mat> *signatures)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesVec(imagesLength);
        for (int i = 0; i < imagesLength; i++)
            imagesVec[i] = *images[i];
        obj->computeSignatures(imagesVec, *signatures);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_drawSignature(
    const interop::InputArrayProxy *source, const interop::InputArrayProxy *signature, const interop::OutputArrayProxy *result,
    float radiusToShorterSideRatio, int borderThickness)
{
    return cvTry([&] {
        cv::xfeatures2d::PCTSignatures::drawSignature(
            InProxy(*source), InProxy(*signature), OutProxy(*result), radiusToShorterSideRatio, borderThickness);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_generateInitPoints(
    std::vector<cv::Point2f> *initPoints, int count, int pointDistribution)
{
    return cvTry([&] {
        cv::xfeatures2d::PCTSignatures::generateInitPoints(*initPoints, count, pointDistribution);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getSampleCount(cv::xfeatures2d::PCTSignatures *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getSampleCount(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setGrayscaleBits(cv::xfeatures2d::PCTSignatures *obj, int val)
{
    return cvTry([&] { obj->setGrayscaleBits(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getGrayscaleBits(cv::xfeatures2d::PCTSignatures *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getGrayscaleBits(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWindowRadius(cv::xfeatures2d::PCTSignatures *obj, int val)
{
    return cvTry([&] { obj->setWindowRadius(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getWindowRadius(cv::xfeatures2d::PCTSignatures *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getWindowRadius(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWeightX(cv::xfeatures2d::PCTSignatures *obj, float val)
{
    return cvTry([&] { obj->setWeightX(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getWeightX(cv::xfeatures2d::PCTSignatures *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getWeightX(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWeightY(cv::xfeatures2d::PCTSignatures *obj, float val)
{
    return cvTry([&] { obj->setWeightY(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getWeightY(cv::xfeatures2d::PCTSignatures *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getWeightY(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWeightL(cv::xfeatures2d::PCTSignatures *obj, float val)
{
    return cvTry([&] { obj->setWeightL(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getWeightL(cv::xfeatures2d::PCTSignatures *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getWeightL(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWeightA(cv::xfeatures2d::PCTSignatures *obj, float val)
{
    return cvTry([&] { obj->setWeightA(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getWeightA(cv::xfeatures2d::PCTSignatures *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getWeightA(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWeightB(cv::xfeatures2d::PCTSignatures *obj, float val)
{
    return cvTry([&] { obj->setWeightB(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getWeightB(cv::xfeatures2d::PCTSignatures *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getWeightB(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWeightContrast(cv::xfeatures2d::PCTSignatures *obj, float val)
{
    return cvTry([&] { obj->setWeightContrast(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getWeightContrast(cv::xfeatures2d::PCTSignatures *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getWeightContrast(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWeightEntropy(cv::xfeatures2d::PCTSignatures *obj, float val)
{
    return cvTry([&] { obj->setWeightEntropy(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getWeightEntropy(cv::xfeatures2d::PCTSignatures *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getWeightEntropy(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getSamplingPoints(
    cv::xfeatures2d::PCTSignatures *obj, std::vector<cv::Point2f> *returnValue)
{
    return cvTry([&] { *returnValue = obj->getSamplingPoints(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWeight(cv::xfeatures2d::PCTSignatures *obj, int idx, float value)
{
    return cvTry([&] { obj->setWeight(idx, value); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setWeights(cv::xfeatures2d::PCTSignatures *obj, float *weights, int weightsLength)
{
    return cvTry([&] {
        const std::vector<float> weightsVec(weights, weights + weightsLength);
        obj->setWeights(weightsVec);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setTranslation(cv::xfeatures2d::PCTSignatures *obj, int idx, float value)
{
    return cvTry([&] { obj->setTranslation(idx, value); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setTranslations(cv::xfeatures2d::PCTSignatures *obj, float *translations, int translationsLength)
{
    return cvTry([&] {
        const std::vector<float> translationsVec(translations, translations + translationsLength);
        obj->setTranslations(translationsVec);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setSamplingPoints(
    cv::xfeatures2d::PCTSignatures *obj, cv::Point2f *samplingPoints, int samplingPointsLength)
{
    return cvTry([&] {
        const std::vector<cv::Point2f> pointsVec(samplingPoints, samplingPoints + samplingPointsLength);
        obj->setSamplingPoints(pointsVec);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getInitSeedIndexes(
    cv::xfeatures2d::PCTSignatures *obj, std::vector<int> *returnValue)
{
    return cvTry([&] { *returnValue = obj->getInitSeedIndexes(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setInitSeedIndexes(
    cv::xfeatures2d::PCTSignatures *obj, int *initSeedIndexes, int initSeedIndexesLength)
{
    return cvTry([&] {
        const std::vector<int> seedsVec(initSeedIndexes, initSeedIndexes + initSeedIndexesLength);
        obj->setInitSeedIndexes(seedsVec);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getInitSeedCount(cv::xfeatures2d::PCTSignatures *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getInitSeedCount(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setIterationCount(cv::xfeatures2d::PCTSignatures *obj, int val)
{
    return cvTry([&] { obj->setIterationCount(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getIterationCount(cv::xfeatures2d::PCTSignatures *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getIterationCount(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setMaxClustersCount(cv::xfeatures2d::PCTSignatures *obj, int val)
{
    return cvTry([&] { obj->setMaxClustersCount(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getMaxClustersCount(cv::xfeatures2d::PCTSignatures *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getMaxClustersCount(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setClusterMinSize(cv::xfeatures2d::PCTSignatures *obj, int val)
{
    return cvTry([&] { obj->setClusterMinSize(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getClusterMinSize(cv::xfeatures2d::PCTSignatures *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getClusterMinSize(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setJoiningDistance(cv::xfeatures2d::PCTSignatures *obj, float val)
{
    return cvTry([&] { obj->setJoiningDistance(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getJoiningDistance(cv::xfeatures2d::PCTSignatures *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getJoiningDistance(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setDropThreshold(cv::xfeatures2d::PCTSignatures *obj, float val)
{
    return cvTry([&] { obj->setDropThreshold(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getDropThreshold(cv::xfeatures2d::PCTSignatures *obj, float *returnValue)
{
    return cvTry([&] { *returnValue = obj->getDropThreshold(); });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_setDistanceFunction(cv::xfeatures2d::PCTSignatures *obj, int val)
{
    return cvTry([&] { obj->setDistanceFunction(val); });
}
CVAPI(ExceptionStatus) xfeatures2d_PCTSignatures_getDistanceFunction(cv::xfeatures2d::PCTSignatures *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getDistanceFunction(); });
}

#pragma endregion

#pragma region PCTSignaturesSQFD

CVAPI(ExceptionStatus) xfeatures2d_PCTSignaturesSQFD_create(
    int distanceFunction, int similarityFunction, float similarityParameter,
    cv::Ptr<cv::xfeatures2d::PCTSignaturesSQFD> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::PCTSignaturesSQFD::create(distanceFunction, similarityFunction, similarityParameter);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_PCTSignaturesSQFD_delete(cv::Ptr<cv::xfeatures2d::PCTSignaturesSQFD> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_PCTSignaturesSQFD_get(
    cv::Ptr<cv::xfeatures2d::PCTSignaturesSQFD> *obj, cv::xfeatures2d::PCTSignaturesSQFD **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignaturesSQFD_computeQuadraticFormDistance(
    cv::xfeatures2d::PCTSignaturesSQFD *obj, const interop::InputArrayProxy *signature0, const interop::InputArrayProxy *signature1,
    float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->computeQuadraticFormDistance(InProxy(*signature0), InProxy(*signature1));
    });
}

CVAPI(ExceptionStatus) xfeatures2d_PCTSignaturesSQFD_computeQuadraticFormDistances(
    cv::xfeatures2d::PCTSignaturesSQFD *obj, cv::Mat *sourceSignature,
    cv::Mat **imageSignatures, int imageSignaturesLength, std::vector<float> *distances)
{
    return cvTry([&] {
        std::vector<cv::Mat> imageSignaturesVec(imageSignaturesLength);
        for (int i = 0; i < imageSignaturesLength; i++)
            imageSignaturesVec[i] = *imageSignatures[i];
        obj->computeQuadraticFormDistances(*sourceSignature, imageSignaturesVec, *distances);
    });
}

#pragma endregion

#endif // NO_CONTRIB
