#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// Explicit instantiation of the cv::optflow::GPCForest<T> template at T = 5. Upstream OpenCV's own
// samples/tests universally hardcode GPCForest<5>, so this is the only instantiation OpenCvSharp
// exposes, as the non-generic managed type GPCForest5. The template is fully defined in
// sparse_matching_gpc.hpp, so instantiating it here compiles cleanly with no linking concerns.
using GPCForest5Native = cv::optflow::GPCForest<5>;

#pragma region GPCTrainingParams / GPCMatchingParams bridge structs

// Plain-C structs for marshaling GPCTrainingParams/GPCMatchingParams across the P/Invoke boundary.
// Bool fields use int (0/1) to match the blittable C# struct layout exactly.
struct CvGPCTrainingParams
{
    unsigned maxTreeDepth;
    int minNumberOfSamples;
    int descriptorType;
    int printProgress;
};

struct CvGPCMatchingParams
{
    int useOpenCL;
};

static cv::optflow::GPCTrainingParams gpcTrainingParamsFromBridge(const CvGPCTrainingParams &p)
{
    return cv::optflow::GPCTrainingParams(
        p.maxTreeDepth,
        p.minNumberOfSamples,
        static_cast<cv::optflow::GPCDescType>(p.descriptorType),
        p.printProgress != 0);
}

static cv::optflow::GPCMatchingParams gpcMatchingParamsFromBridge(const CvGPCMatchingParams &p)
{
    return cv::optflow::GPCMatchingParams(p.useOpenCL != 0);
}

#pragma endregion

#pragma region GPCTrainingSamples

CVAPI(ExceptionStatus) optflow_Ptr_GPCTrainingSamples_delete(cv::Ptr<cv::optflow::GPCTrainingSamples> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) optflow_Ptr_GPCTrainingSamples_get(
    cv::Ptr<cv::optflow::GPCTrainingSamples> *ptr, cv::optflow::GPCTrainingSamples **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) optflow_GPCTrainingSamples_create(
    cv::Mat **imagesFrom, int imagesFromSize,
    cv::Mat **imagesTo, int imagesToSize,
    cv::Mat **gt, int gtSize,
    int descriptorType,
    cv::Ptr<cv::optflow::GPCTrainingSamples> **returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesFromVec(imagesFromSize);
        for (auto i = 0; i < imagesFromSize; i++)
            imagesFromVec[i] = *imagesFrom[i];
        std::vector<cv::Mat> imagesToVec(imagesToSize);
        for (auto i = 0; i < imagesToSize; i++)
            imagesToVec[i] = *imagesTo[i];
        std::vector<cv::Mat> gtVec(gtSize);
        for (auto i = 0; i < gtSize; i++)
            gtVec[i] = *gt[i];

        const auto ptr = cv::optflow::GPCTrainingSamples::create(imagesFromVec, imagesToVec, gtVec, descriptorType);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) optflow_GPCTrainingSamples_size(cv::optflow::GPCTrainingSamples *obj, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->size();
    });
}

CVAPI(ExceptionStatus) optflow_GPCTrainingSamples_type(cv::optflow::GPCTrainingSamples *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->type();
    });
}

#pragma endregion

#pragma region GPCTree

CVAPI(ExceptionStatus) optflow_Ptr_GPCTree_delete(cv::Ptr<cv::optflow::GPCTree> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) optflow_Ptr_GPCTree_get(cv::Ptr<cv::optflow::GPCTree> *ptr, cv::optflow::GPCTree **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) optflow_createGPCTree(cv::Ptr<cv::optflow::GPCTree> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::optflow::GPCTree::create();
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) optflow_GPCTree_train(
    cv::optflow::GPCTree *obj, cv::optflow::GPCTrainingSamples *samples, CvGPCTrainingParams *trainingParams)
{
    return cvTry([&] {
        obj->train(*samples, gpcTrainingParamsFromBridge(*trainingParams));
    });
}

CVAPI(ExceptionStatus) optflow_GPCTree_getDescriptorType(cv::optflow::GPCTree *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDescriptorType();
    });
}

#pragma endregion

#pragma region GPCForest5

CVAPI(ExceptionStatus) optflow_Ptr_GPCForest5_delete(cv::Ptr<GPCForest5Native> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) optflow_Ptr_GPCForest5_get(cv::Ptr<GPCForest5Native> *ptr, GPCForest5Native **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) optflow_createGPCForest5(cv::Ptr<GPCForest5Native> **returnValue)
{
    return cvTry([&] {
        const auto ptr = GPCForest5Native::create();
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) optflow_GPCForest5_train(
    GPCForest5Native *obj, cv::optflow::GPCTrainingSamples *samples, CvGPCTrainingParams *trainingParams)
{
    return cvTry([&] {
        obj->train(*samples, gpcTrainingParamsFromBridge(*trainingParams));
    });
}

CVAPI(ExceptionStatus) optflow_GPCForest5_train_fromMats(
    GPCForest5Native *obj,
    cv::Mat **imagesFrom, int imagesFromSize,
    cv::Mat **imagesTo, int imagesToSize,
    cv::Mat **gt, int gtSize,
    CvGPCTrainingParams *trainingParams)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesFromVec(imagesFromSize);
        for (auto i = 0; i < imagesFromSize; i++)
            imagesFromVec[i] = *imagesFrom[i];
        std::vector<cv::Mat> imagesToVec(imagesToSize);
        for (auto i = 0; i < imagesToSize; i++)
            imagesToVec[i] = *imagesTo[i];
        std::vector<cv::Mat> gtVec(gtSize);
        for (auto i = 0; i < gtSize; i++)
            gtVec[i] = *gt[i];

        obj->train(imagesFromVec, imagesToVec, gtVec, gpcTrainingParamsFromBridge(*trainingParams));
    });
}

CVAPI(ExceptionStatus) optflow_GPCForest5_findCorrespondences(
    GPCForest5Native *obj,
    const interop::InputArrayProxy *imgFrom,
    const interop::InputArrayProxy *imgTo,
    std::vector<cv::Point> *pointsFrom,
    std::vector<cv::Point> *pointsTo,
    CvGPCMatchingParams *matchingParams)
{
    return cvTry([&] {
        std::vector<std::pair<cv::Point2i, cv::Point2i>> corr;
        obj->findCorrespondences(InProxy(*imgFrom), InProxy(*imgTo), corr, gpcMatchingParamsFromBridge(*matchingParams));

        pointsFrom->reserve(corr.size());
        pointsTo->reserve(corr.size());
        for (const auto &pr : corr)
        {
            pointsFrom->push_back(pr.first);
            pointsTo->push_back(pr.second);
        }
    });
}

#pragma endregion

#endif // NO_CONTRIB
