#ifndef _CPP_FEATURES2D_BOW_H_
#define _CPP_FEATURES2D_BOW_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// BOWTrainer

CVAPI(ExceptionStatus) features2d_BOWTrainer_add(cv::BOWTrainer *obj, cv::Mat *descriptors)
{
    BEGIN_WRAP
    obj->add(*descriptors);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWTrainer_getDescriptors(cv::BOWTrainer *obj, std::vector<cv::Mat> *descriptors)
{
    BEGIN_WRAP
    const std::vector<cv::Mat> d = obj->getDescriptors();
    std::copy(d.begin(), d.end(), std::back_inserter(*descriptors));
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWTrainer_descriptorsCount(cv::BOWTrainer *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->descriptorsCount();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWTrainer_clear(cv::BOWTrainer *obj)
{
    BEGIN_WRAP
    obj->clear();
    END_WRAP
}


// BOWKMeansTrainer

CVAPI(ExceptionStatus) features2d_BOWKMeansTrainer_new(
    int clusterCount, MyCvTermCriteria termcrit, int attempts, int flags, cv::BOWKMeansTrainer **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::BOWKMeansTrainer(clusterCount, cpp(termcrit), attempts, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWKMeansTrainer_delete(cv::BOWKMeansTrainer *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWKMeansTrainer_cluster1(cv::BOWKMeansTrainer *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    cv::Mat m = obj->cluster();
    *returnValue = new cv::Mat(m);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_BOWKMeansTrainer_cluster2(cv::BOWKMeansTrainer *obj, cv::Mat *descriptors, cv::Mat **returnValue)
{
    BEGIN_WRAP
    cv::Mat m = obj->cluster(*descriptors);
    *returnValue = new cv::Mat(m);
    END_WRAP
}

// BOWImgDescriptorExtractor

static void DescriptorExtractorDeleter(cv::DescriptorExtractor *p) { }
static void DescriptorMatcherDeleter(cv::DescriptorMatcher *p) { }

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_new1_Ptr(
    cv::Ptr<cv::DescriptorExtractor> *dextractor, cv::Ptr<cv::DescriptorMatcher> *dmatcher, cv::BOWImgDescriptorExtractor **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::BOWImgDescriptorExtractor(*dextractor, *dmatcher);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_new2_Ptr(
    cv::Ptr<cv::DescriptorMatcher> *dmatcher, cv::BOWImgDescriptorExtractor **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::BOWImgDescriptorExtractor(*dmatcher);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_new1_RawPtr(
    cv::DescriptorExtractor *dextractor, cv::DescriptorMatcher *dmatcher, cv::BOWImgDescriptorExtractor **returnValue)
{
    BEGIN_WRAP
    // do not delete dextractor and dmatcher
    cv::Ptr<cv::DescriptorExtractor> dextractorPtr(dextractor, DescriptorExtractorDeleter);
    cv::Ptr<cv::DescriptorMatcher> dmatcherPtr(dmatcher, DescriptorMatcherDeleter);
    *returnValue = new cv::BOWImgDescriptorExtractor(dextractorPtr, dmatcherPtr);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_new2_RawPtr(
    cv::DescriptorMatcher *dmatcher, cv::BOWImgDescriptorExtractor **returnValue)
{
    BEGIN_WRAP
    // do not delete dmatcher
    cv::Ptr<cv::DescriptorMatcher> dmatcherPtr(dmatcher, DescriptorMatcherDeleter);
    *returnValue = new cv::BOWImgDescriptorExtractor(dmatcherPtr);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_delete(cv::BOWImgDescriptorExtractor *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_setVocabulary(cv::BOWImgDescriptorExtractor *obj, cv::Mat *vocabulary)
{
    BEGIN_WRAP
    obj->setVocabulary(*vocabulary);
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_getVocabulary(cv::BOWImgDescriptorExtractor *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    cv::Mat m = obj->getVocabulary();
    *returnValue = new cv::Mat(m);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_compute11(
    cv::BOWImgDescriptorExtractor *obj, cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *imgDescriptor, 
    std::vector<std::vector<int> >* pointIdxsOfClusters, cv::Mat* descriptors)
{
    BEGIN_WRAP
    obj->compute(*image, *keypoints, *imgDescriptor, pointIdxsOfClusters, descriptors);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_compute12(
    cv::BOWImgDescriptorExtractor *obj, cv::_InputArray *keypointDescriptors, 
    cv::_OutputArray *imgDescriptor,     std::vector<std::vector<int> >* pointIdxsOfClusters)
{
    BEGIN_WRAP
    obj->compute(*keypointDescriptors, *imgDescriptor, pointIdxsOfClusters);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_compute2(
    cv::BOWImgDescriptorExtractor *obj, cv::Mat *image, std::vector<cv::KeyPoint> *keypoints, cv::Mat *imgDescriptor)
{
    BEGIN_WRAP
    obj->compute2(*image, *keypoints, *imgDescriptor);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_descriptorSize(cv::BOWImgDescriptorExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->descriptorSize();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BOWImgDescriptorExtractor_descriptorType(cv::BOWImgDescriptorExtractor *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->descriptorType();
    END_WRAP
}

#endif
