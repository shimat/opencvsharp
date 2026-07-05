#pragma once

#ifndef NO_CONTRIB

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// OpenCV 5 moved the bag-of-words classes (BOWTrainer / BOWKMeansTrainer /
// BOWImgDescriptorExtractor) out of the core features module and into the
// opencv_contrib xfeatures2d module (cv::xfeatures2d namespace). They are
// therefore unavailable in NO_CONTRIB (slim) builds.
#ifndef NO_CONTRIB

// BOWTrainer

CVAPI(ExceptionStatus) xfeatures2d_BOWTrainer_add(cv::xfeatures2d::BOWTrainer *obj, cv::Mat *descriptors)
{
    return cvTry([&] {
        obj->add(*descriptors);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWTrainer_getDescriptors(cv::xfeatures2d::BOWTrainer *obj, std::vector<cv::Mat> *descriptors)
{
    return cvTry([&] {
        const std::vector<cv::Mat> d = obj->getDescriptors();
        std::copy(d.begin(), d.end(), std::back_inserter(*descriptors));
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWTrainer_descriptorsCount(cv::xfeatures2d::BOWTrainer *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->descriptorsCount();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWTrainer_clear(cv::xfeatures2d::BOWTrainer *obj)
{
    return cvTry([&] {
        obj->clear();
    });
}


// BOWKMeansTrainer

CVAPI(ExceptionStatus) xfeatures2d_BOWKMeansTrainer_new(
    int clusterCount,
    interop::TermCriteria termcrit,
    int attempts,
    int flags,
    cv::xfeatures2d::BOWKMeansTrainer **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::xfeatures2d::BOWKMeansTrainer(clusterCount, cpp(termcrit), attempts, flags);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWKMeansTrainer_delete(cv::xfeatures2d::BOWKMeansTrainer *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWKMeansTrainer_cluster1(cv::xfeatures2d::BOWKMeansTrainer *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        const cv::Mat m = obj->cluster();
        *returnValue = new cv::Mat(m);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_BOWKMeansTrainer_cluster2(
    cv::xfeatures2d::BOWKMeansTrainer *obj,
    cv::Mat *descriptors,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const cv::Mat m = obj->cluster(*descriptors);
        *returnValue = new cv::Mat(m);
    });
}

// BOWImgDescriptorExtractor

static void DescriptorExtractorDeleter(cv::DescriptorExtractor *) { }
static void DescriptorMatcherDeleter(cv::DescriptorMatcher *) { }

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_new1_Ptr(
    cv::Ptr<cv::DescriptorExtractor> *dextractor,
    cv::Ptr<cv::DescriptorMatcher> *dmatcher,
    cv::xfeatures2d::BOWImgDescriptorExtractor **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::xfeatures2d::BOWImgDescriptorExtractor(*dextractor, *dmatcher);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_new2_Ptr(cv::Ptr<cv::DescriptorMatcher> *dmatcher, cv::xfeatures2d::BOWImgDescriptorExtractor **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::xfeatures2d::BOWImgDescriptorExtractor(*dmatcher);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_new1_RawPtr(
    cv::DescriptorExtractor *dextractor,
    cv::DescriptorMatcher *dmatcher,
    cv::xfeatures2d::BOWImgDescriptorExtractor **returnValue)
{
    return cvTry([&] {
        // do not delete dextractor and dmatcher
        const cv::Ptr<cv::DescriptorExtractor> dextractorPtr(dextractor, DescriptorExtractorDeleter);
        const cv::Ptr<cv::DescriptorMatcher> dmatcherPtr(dmatcher, DescriptorMatcherDeleter);
        *returnValue = new cv::xfeatures2d::BOWImgDescriptorExtractor(dextractorPtr, dmatcherPtr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_new2_RawPtr(cv::DescriptorMatcher *dmatcher, cv::xfeatures2d::BOWImgDescriptorExtractor **returnValue)
{
    return cvTry([&] {
        // do not delete dmatcher
        const cv::Ptr<cv::DescriptorMatcher> dmatcherPtr(dmatcher, DescriptorMatcherDeleter);
        *returnValue = new cv::xfeatures2d::BOWImgDescriptorExtractor(dmatcherPtr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_delete(cv::xfeatures2d::BOWImgDescriptorExtractor *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_setVocabulary(cv::xfeatures2d::BOWImgDescriptorExtractor *obj, cv::Mat *vocabulary)
{
    return cvTry([&] {
        obj->setVocabulary(*vocabulary);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_getVocabulary(cv::xfeatures2d::BOWImgDescriptorExtractor *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        cv::Mat m = obj->getVocabulary();
        *returnValue = new cv::Mat(m);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_compute11(
    cv::xfeatures2d::BOWImgDescriptorExtractor *obj,
    const interop::InputArrayProxy* image,
    std::vector<cv::KeyPoint> *keypoints,
    const interop::OutputArrayProxy* imgDescriptor,
    std::vector<std::vector<int> >* pointIdxsOfClusters,
    cv::Mat* descriptors)
{
    return cvTry([&] {
        obj->compute(InProxy(*image), *keypoints, OutProxy(*imgDescriptor), pointIdxsOfClusters, descriptors);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_compute12(
    cv::xfeatures2d::BOWImgDescriptorExtractor *obj,
    const interop::InputArrayProxy* keypointDescriptors,
    const interop::OutputArrayProxy* imgDescriptor,
    std::vector<std::vector<int> >* pointIdxsOfClusters)
{
    return cvTry([&] {
        obj->compute(InProxy(*keypointDescriptors), OutProxy(*imgDescriptor), pointIdxsOfClusters);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_compute2(
    cv::xfeatures2d::BOWImgDescriptorExtractor *obj,
    cv::Mat *image,
    std::vector<cv::KeyPoint> *keypoints,
    cv::Mat *imgDescriptor)
{
    return cvTry([&] {
        obj->compute2(*image, *keypoints, *imgDescriptor);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_descriptorSize(cv::xfeatures2d::BOWImgDescriptorExtractor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->descriptorSize();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BOWImgDescriptorExtractor_descriptorType(cv::xfeatures2d::BOWImgDescriptorExtractor *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->descriptorType();
    });
}

#endif // NO_CONTRIB

#endif // NO_CONTRIB
