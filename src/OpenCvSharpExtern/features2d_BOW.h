#ifndef _CPP_FEATURES2D_BOW_H_
#define _CPP_FEATURES2D_BOW_H_

#include "include_opencv.h"

// BOWTrainer

CVAPI(void) features2d_BOWTrainer_add(cv::BOWTrainer *obj, cv::Mat *descriptors)
{
    obj->add(*descriptors);
}

CVAPI(void) features2d_BOWTrainer_getDescriptors(cv::BOWTrainer *obj, std::vector<cv::Mat> *descriptors)
{
    const std::vector<cv::Mat> d = obj->getDescriptors();
    std::copy(d.begin(), d.end(), std::back_inserter(*descriptors));
}

CVAPI(int) features2d_BOWTrainer_descriptorsCount(cv::BOWTrainer *obj)
{
    return obj->descriptorsCount();
}

CVAPI(void) features2d_BOWTrainer_clear(cv::BOWTrainer *obj)
{
    obj->clear();
}


// BOWKMeansTrainer

CVAPI(cv::BOWKMeansTrainer*) features2d_BOWKMeansTrainer_new(
    int clusterCount, MyCvTermCriteria termcrit, int attempts, int flags)
{
    return new cv::BOWKMeansTrainer(clusterCount, cpp(termcrit), attempts, flags);
}

CVAPI(void) features2d_BOWKMeansTrainer_delete(cv::BOWKMeansTrainer *obj)
{
    delete obj;
}

CVAPI(cv::Mat*) features2d_BOWKMeansTrainer_cluster1(cv::BOWKMeansTrainer *obj)
{
    cv::Mat m = obj->cluster();
    return new cv::Mat(m);
}
CVAPI(cv::Mat*) features2d_BOWKMeansTrainer_cluster2(cv::BOWKMeansTrainer *obj, cv::Mat *descriptors)
{
    cv::Mat m = obj->cluster(*descriptors);
    return new cv::Mat(m);
}

// BOWImgDescriptorExtractor

static void DescriptorExtractorDeleter(cv::DescriptorExtractor *p) { }
static void DescriptorMatcherDeleter(cv::DescriptorMatcher *p) { }

CVAPI(cv::BOWImgDescriptorExtractor*) features2d_BOWImgDescriptorExtractor_new1_Ptr(
    cv::Ptr<cv::DescriptorExtractor> *dextractor, cv::Ptr<cv::DescriptorMatcher> *dmatcher)
{
    return new cv::BOWImgDescriptorExtractor(*dextractor, *dmatcher);
}
CVAPI(cv::BOWImgDescriptorExtractor*) features2d_BOWImgDescriptorExtractor_new2_Ptr(
    cv::Ptr<cv::DescriptorMatcher> *dmatcher)
{
    return new cv::BOWImgDescriptorExtractor(*dmatcher);
}

CVAPI(cv::BOWImgDescriptorExtractor*) features2d_BOWImgDescriptorExtractor_new1_RawPtr(
    cv::DescriptorExtractor *dextractor, cv::DescriptorMatcher *dmatcher)
{
    // do not delete dextractor and dmatcher
    cv::Ptr<cv::DescriptorExtractor> dextractorPtr(dextractor, DescriptorExtractorDeleter);
    cv::Ptr<cv::DescriptorMatcher> dmatcherPtr(dmatcher, DescriptorMatcherDeleter);
    return new cv::BOWImgDescriptorExtractor(dextractorPtr, dmatcherPtr);
}

CVAPI(cv::BOWImgDescriptorExtractor*) features2d_BOWImgDescriptorExtractor_new2_RawPtr(
    cv::DescriptorMatcher *dmatcher)
{
    // do not delete dmatcher
    cv::Ptr<cv::DescriptorMatcher> dmatcherPtr(dmatcher, DescriptorMatcherDeleter);
    return new cv::BOWImgDescriptorExtractor(dmatcherPtr);
}

CVAPI(void) features2d_BOWImgDescriptorExtractor_delete(cv::BOWImgDescriptorExtractor *obj)
{
    delete obj;
}

CVAPI(void) features2d_BOWImgDescriptorExtractor_setVocabulary(cv::BOWImgDescriptorExtractor *obj, cv::Mat *vocabulary)
{
    obj->setVocabulary(*vocabulary);
}
CVAPI(cv::Mat*) features2d_BOWImgDescriptorExtractor_getVocabulary(cv::BOWImgDescriptorExtractor *obj)
{
    cv::Mat m = obj->getVocabulary();
    return new cv::Mat(m);
}

CVAPI(void) features2d_BOWImgDescriptorExtractor_compute11(
    cv::BOWImgDescriptorExtractor *obj, cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *imgDescriptor, 
        std::vector<std::vector<int> >* pointIdxsOfClusters, cv::Mat* descriptors)
{
    obj->compute(*image, *keypoints, *imgDescriptor, pointIdxsOfClusters, descriptors);
}

CVAPI(void) features2d_BOWImgDescriptorExtractor_compute12(
    cv::BOWImgDescriptorExtractor *obj, cv::_InputArray *keypointDescriptors, 
    cv::_OutputArray *imgDescriptor,     std::vector<std::vector<int> >* pointIdxsOfClusters)
{
    obj->compute(*keypointDescriptors, *imgDescriptor, pointIdxsOfClusters);
}

CVAPI(void) features2d_BOWImgDescriptorExtractor_compute2(
    cv::BOWImgDescriptorExtractor *obj, cv::Mat *image, std::vector<cv::KeyPoint> *keypoints, cv::Mat *imgDescriptor)
{
    obj->compute2(*image, *keypoints, *imgDescriptor);
}

CVAPI(int) features2d_BOWImgDescriptorExtractor_descriptorSize(cv::BOWImgDescriptorExtractor *obj)
{
    return obj->descriptorSize();
}

CVAPI(int) features2d_BOWImgDescriptorExtractor_descriptorType(cv::BOWImgDescriptorExtractor *obj)
{
    return obj->descriptorType();
}

#endif
