#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

struct BinaryDescriptorParamsData
{
    int numOfOctaves;
    int widthOfBand;
    int reductionRatio;
    int ksize;
};

// BinaryDescriptor::EDLineDetector and EDLineParam are private nested implementation details in
// OpenCV's descriptor.hpp. They cannot be named by C++ callers and therefore are intentionally not
// part of the public OpenCvSharp surface.


CVAPI(ExceptionStatus) line_descriptor_LSDDetector_new1(
    cv::line_descriptor::LSDDetector** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::line_descriptor::LSDDetector;
    });
}

CVAPI(ExceptionStatus) line_descriptor_LSDDetector_new2(
    const double scale,
    const double sigma_scale,
    const double quant,
    const double ang_th,
    const double log_eps,
    const double density_th,
    const int n_bins,
    cv::line_descriptor::LSDDetector** returnValue)
{
    return cvTry([&] {
        cv::line_descriptor::LSDParam param;
        param.scale = scale;
        param.sigma_scale = sigma_scale;
        param.quant = quant;
        param.ang_th = ang_th;
        param.log_eps = log_eps;
        param.density_th = density_th;
        param.n_bins = n_bins;
        *returnValue = new cv::line_descriptor::LSDDetector(param);
    });
}

CVAPI(ExceptionStatus) line_descriptor_LSDDetector_delete(cv::line_descriptor::LSDDetector* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) line_descriptor_LSDDetector_detect1(
    cv::line_descriptor::LSDDetector* obj,
    cv::Mat* image, std::vector<cv::line_descriptor::KeyLine> *keypoints, int scale, int numOctaves, cv::Mat* mask)
{
    return cvTry([&] {
        obj->detect(*image, *keypoints, scale, numOctaves, entity(mask));    
    });
}

CVAPI(ExceptionStatus) line_descriptor_LSDDetector_detect2(
    cv::line_descriptor::LSDDetector* obj,
    cv::Mat **images, int32_t imagesSize,
    std::vector<std::vector<cv::line_descriptor::KeyLine> > *keylines, int scale, int numOctaves,
    cv::Mat** masks, int32_t masksSize)
{
    return cvTry([&] {
        // LSDDetector::detect(images, keylines, ..., masks) indexes both `keylines` and `masks`
        // by images.size() without resizing them itself, so both must be pre-sized here.
        std::vector<cv::Mat> imagesVec(imagesSize);
        std::vector<cv::Mat> masksVec(imagesSize);
        for (int i = 0; i < imagesSize; i++)
        {
            imagesVec[i] = *images[i];
        }
        const int maskCount = std::min(masksSize, imagesSize);
        for (int i = 0; i < maskCount; i++)
        {
            masksVec[i] = *masks[i];
        }

        keylines->resize(imagesSize);
        obj->detect(imagesVec, *keylines, scale, numOctaves, masksVec);

    });
}

#pragma region BinaryDescriptor

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_create(
    cv::line_descriptor::BinaryDescriptor::Params *params,
    cv::Ptr<cv::line_descriptor::BinaryDescriptor> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(params == nullptr
            ? cv::line_descriptor::BinaryDescriptor::createBinaryDescriptor()
            : cv::line_descriptor::BinaryDescriptor::createBinaryDescriptor(*params));
    });
}

CVAPI(ExceptionStatus) line_descriptor_Ptr_BinaryDescriptor_get(
    cv::Ptr<cv::line_descriptor::BinaryDescriptor> *obj,
    cv::line_descriptor::BinaryDescriptor **returnValue)
{
    return cvTry([&] { *returnValue = obj->get(); });
}

CVAPI(ExceptionStatus) line_descriptor_Ptr_BinaryDescriptor_delete(
    cv::Ptr<cv::line_descriptor::BinaryDescriptor> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_getNumOfOctaves(
    cv::line_descriptor::BinaryDescriptor *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getNumOfOctaves(); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_setNumOfOctaves(
    cv::line_descriptor::BinaryDescriptor *obj, const int value)
{
    return cvTry([&] { obj->setNumOfOctaves(value); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_getWidthOfBand(
    cv::line_descriptor::BinaryDescriptor *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getWidthOfBand(); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_setWidthOfBand(
    cv::line_descriptor::BinaryDescriptor *obj, const int value)
{
    return cvTry([&] { obj->setWidthOfBand(value); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_getReductionRatio(
    cv::line_descriptor::BinaryDescriptor *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->getReductionRatio(); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_setReductionRatio(
    cv::line_descriptor::BinaryDescriptor *obj, const int value)
{
    return cvTry([&] { obj->setReductionRatio(value); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_detect1(
    cv::line_descriptor::BinaryDescriptor *obj,
    cv::Mat *image,
    std::vector<cv::line_descriptor::KeyLine> *keyLines,
    cv::Mat *mask)
{
    return cvTry([&] { obj->detect(*image, *keyLines, entity(mask)); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_detect2(
    cv::line_descriptor::BinaryDescriptor *obj,
    cv::Mat **images,
    const int imagesLength,
    std::vector<std::vector<cv::line_descriptor::KeyLine>> *keyLines,
    cv::Mat **masks,
    const int masksLength)
{
    return cvTry([&] {
        std::vector<cv::Mat> imageVector(imagesLength);
        for (auto i = 0; i < imagesLength; i++)
            imageVector[i] = *images[i];
        std::vector<cv::Mat> maskVector(imagesLength);
        for (auto i = 0; i < masksLength; i++)
            maskVector[i] = *masks[i];
        keyLines->resize(imagesLength);
        obj->detect(imageVector, *keyLines, maskVector);
    });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_compute1(
    cv::line_descriptor::BinaryDescriptor *obj,
    cv::Mat *image,
    std::vector<cv::line_descriptor::KeyLine> *keyLines,
    cv::Mat *descriptors,
    const int returnFloatDescriptor)
{
    return cvTry([&] {
        obj->compute(*image, *keyLines, *descriptors, returnFloatDescriptor != 0);
    });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_compute2(
    cv::line_descriptor::BinaryDescriptor *obj,
    cv::Mat **images,
    const int imagesLength,
    cv::line_descriptor::KeyLine **keyLines,
    const int *keyLineSizes,
    const int keyLinesLength,
    std::vector<std::vector<cv::line_descriptor::KeyLine>> *outputKeyLines,
    std::vector<cv::Mat> *descriptors,
    const int returnFloatDescriptor)
{
    return cvTry([&] {
        std::vector<cv::Mat> imageVector(imagesLength);
        for (auto i = 0; i < imagesLength; i++)
            imageVector[i] = *images[i];
        std::vector<std::vector<cv::line_descriptor::KeyLine>> keyLineVector(keyLinesLength);
        for (auto i = 0; i < keyLinesLength; i++)
        {
            if (keyLineSizes[i] > 0)
                keyLineVector[i].assign(keyLines[i], keyLines[i] + keyLineSizes[i]);
        }
        descriptors->resize(imagesLength);
        obj->compute(imageVector, keyLineVector, *descriptors, returnFloatDescriptor != 0);
        *outputKeyLines = std::move(keyLineVector);
    });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_descriptorSize(
    cv::line_descriptor::BinaryDescriptor *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->descriptorSize(); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_descriptorType(
    cv::line_descriptor::BinaryDescriptor *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->descriptorType(); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_defaultNorm(
    cv::line_descriptor::BinaryDescriptor *obj, int *returnValue)
{
    return cvTry([&] { *returnValue = obj->defaultNorm(); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_Params_new(
    cv::line_descriptor::BinaryDescriptor::Params **returnValue)
{
    return cvTry([&] { *returnValue = new cv::line_descriptor::BinaryDescriptor::Params; });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_Params_delete(
    cv::line_descriptor::BinaryDescriptor::Params *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_Params_getAll(
    cv::line_descriptor::BinaryDescriptor::Params *obj,
    BinaryDescriptorParamsData *data)
{
    return cvTry([&] {
        data->numOfOctaves = obj->numOfOctave_;
        data->widthOfBand = obj->widthOfBand_;
        data->reductionRatio = obj->reductionRatio;
        data->ksize = obj->ksize_;
    });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_Params_setAll(
    cv::line_descriptor::BinaryDescriptor::Params *obj,
    const BinaryDescriptorParamsData data)
{
    return cvTry([&] {
        obj->numOfOctave_ = data.numOfOctaves;
        obj->widthOfBand_ = data.widthOfBand;
        obj->reductionRatio = data.reductionRatio;
        obj->ksize_ = data.ksize;
    });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_Params_read(
    cv::line_descriptor::BinaryDescriptor::Params *obj, cv::FileNode *node)
{
    return cvTry([&] { obj->read(*node); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptor_Params_write(
    cv::line_descriptor::BinaryDescriptor::Params *obj, cv::FileStorage *storage)
{
    return cvTry([&] { obj->write(*storage); });
}

#pragma endregion

#pragma region BinaryDescriptorMatcher

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptorMatcher_create(
    cv::Ptr<cv::line_descriptor::BinaryDescriptorMatcher> **returnValue)
{
    return cvTry([&] {
        *returnValue = clone(cv::line_descriptor::BinaryDescriptorMatcher::createBinaryDescriptorMatcher());
    });
}

CVAPI(ExceptionStatus) line_descriptor_Ptr_BinaryDescriptorMatcher_get(
    cv::Ptr<cv::line_descriptor::BinaryDescriptorMatcher> *obj,
    cv::line_descriptor::BinaryDescriptorMatcher **returnValue)
{
    return cvTry([&] { *returnValue = obj->get(); });
}

CVAPI(ExceptionStatus) line_descriptor_Ptr_BinaryDescriptorMatcher_delete(
    cv::Ptr<cv::line_descriptor::BinaryDescriptorMatcher> *obj)
{
    return cvTry([&] { delete obj; });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptorMatcher_match(
    cv::line_descriptor::BinaryDescriptorMatcher *obj,
    cv::Mat *query,
    cv::Mat *train,
    std::vector<cv::DMatch> *matches,
    cv::Mat *mask)
{
    return cvTry([&] { obj->match(*query, *train, *matches, entity(mask)); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptorMatcher_matchQuery(
    cv::line_descriptor::BinaryDescriptorMatcher *obj,
    cv::Mat *query,
    std::vector<cv::DMatch> *matches,
    cv::Mat **masks,
    const int masksLength)
{
    return cvTry([&] {
        std::vector<cv::Mat> maskVector(masksLength);
        for (auto i = 0; i < masksLength; i++)
            maskVector[i] = *masks[i];
        obj->match(*query, *matches, maskVector);
    });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptorMatcher_knnMatch(
    cv::line_descriptor::BinaryDescriptorMatcher *obj,
    cv::Mat *query,
    cv::Mat *train,
    std::vector<std::vector<cv::DMatch>> *matches,
    const int k,
    cv::Mat *mask,
    const int compactResult)
{
    return cvTry([&] {
        obj->knnMatch(*query, *train, *matches, k, entity(mask), compactResult != 0);
    });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptorMatcher_knnMatchQuery(
    cv::line_descriptor::BinaryDescriptorMatcher *obj,
    cv::Mat *query,
    std::vector<std::vector<cv::DMatch>> *matches,
    const int k,
    cv::Mat **masks,
    const int masksLength,
    const int compactResult)
{
    return cvTry([&] {
        std::vector<cv::Mat> maskVector(masksLength);
        for (auto i = 0; i < masksLength; i++)
            maskVector[i] = *masks[i];
        obj->knnMatch(*query, *matches, k, maskVector, compactResult != 0);
    });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptorMatcher_add(
    cv::line_descriptor::BinaryDescriptorMatcher *obj,
    cv::Mat **descriptors,
    const int descriptorsLength)
{
    return cvTry([&] {
        std::vector<cv::Mat> descriptorVector(descriptorsLength);
        for (auto i = 0; i < descriptorsLength; i++)
            descriptorVector[i] = *descriptors[i];
        obj->add(descriptorVector);
    });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptorMatcher_train(
    cv::line_descriptor::BinaryDescriptorMatcher *obj)
{
    return cvTry([&] { obj->train(); });
}

CVAPI(ExceptionStatus) line_descriptor_BinaryDescriptorMatcher_clear(
    cv::line_descriptor::BinaryDescriptorMatcher *obj)
{
    return cvTry([&] { obj->clear(); });
}

#pragma endregion

#pragma region Drawing

CVAPI(ExceptionStatus) line_descriptor_drawLineMatches(
    cv::Mat *image1,
    cv::line_descriptor::KeyLine *keyLines1,
    const int keyLines1Length,
    cv::Mat *image2,
    cv::line_descriptor::KeyLine *keyLines2,
    const int keyLines2Length,
    cv::DMatch *matches,
    const int matchesLength,
    cv::Mat *output,
    const interop::Scalar matchColor,
    const interop::Scalar singleLineColor,
    char *matchesMask,
    const int matchesMaskLength,
    const int flags)
{
    return cvTry([&] {
        std::vector<cv::line_descriptor::KeyLine> keyLineVector1;
        std::vector<cv::line_descriptor::KeyLine> keyLineVector2;
        std::vector<cv::DMatch> matchVector;
        std::vector<char> maskVector;
        if (keyLines1Length > 0)
            keyLineVector1.assign(keyLines1, keyLines1 + keyLines1Length);
        if (keyLines2Length > 0)
            keyLineVector2.assign(keyLines2, keyLines2 + keyLines2Length);
        if (matchesLength > 0)
            matchVector.assign(matches, matches + matchesLength);
        if (matchesMaskLength > 0)
            maskVector.assign(matchesMask, matchesMask + matchesMaskLength);
        cv::line_descriptor::drawLineMatches(
            *image1, keyLineVector1, *image2, keyLineVector2, matchVector, *output,
            cpp(matchColor), cpp(singleLineColor), maskVector, flags);
    });
}

CVAPI(ExceptionStatus) line_descriptor_drawKeylines(
    cv::Mat *image,
    cv::line_descriptor::KeyLine *keyLines,
    const int keyLinesLength,
    cv::Mat *output,
    const interop::Scalar color,
    const int flags)
{
    return cvTry([&] {
        std::vector<cv::line_descriptor::KeyLine> keyLineVector;
        if (keyLinesLength > 0)
            keyLineVector.assign(keyLines, keyLines + keyLinesLength);
        cv::line_descriptor::drawKeylines(*image, keyLineVector, *output, cpp(color), flags);
    });
}

#pragma endregion

#endif // NO_CONTRIB
