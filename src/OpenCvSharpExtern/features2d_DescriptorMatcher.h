#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region DescriptorMatcher
CVAPI(ExceptionStatus) features2d_DescriptorMatcher_add(cv::DescriptorMatcher *obj, cv::Mat **descriptors, int descriptorLength)
{
    BEGIN_WRAP
    std::vector<cv::Mat> descriptorsVec(descriptorLength);
    for (int i = 0; i < descriptorLength; i++)    
        descriptorsVec[i] = *descriptors[i];
    obj->add(descriptorsVec);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_getTrainDescriptors(cv::DescriptorMatcher *obj, std::vector<cv::Mat> *dst)
{
    BEGIN_WRAP
    *dst = obj->getTrainDescriptors();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_clear(cv::DescriptorMatcher *obj)
{
    BEGIN_WRAP
    obj->clear();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_empty(cv::DescriptorMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->empty() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_DescriptorMatcher_isMaskSupported(cv::DescriptorMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isMaskSupported() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_train(cv::DescriptorMatcher *obj)
{
    BEGIN_WRAP
    obj->train();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_match1(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, 
    cv::Mat *trainDescriptors, std::vector<cv::DMatch> *matches, cv::Mat *mask)
{
    BEGIN_WRAP
    obj->match(*queryDescriptors, *trainDescriptors, *matches, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_knnMatch1(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors,
    cv::Mat *trainDescriptors, std::vector<std::vector<cv::DMatch> > *matches, int k,
    cv::Mat *mask, int compactResult)
{
    BEGIN_WRAP
    obj->knnMatch(*queryDescriptors, *trainDescriptors, *matches, k, entity(mask), compactResult != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_radiusMatch1(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, 
    cv::Mat *trainDescriptors, std::vector<std::vector<cv::DMatch> > *matches, float maxDistance,
    cv::Mat *mask, int compactResult)
{
    BEGIN_WRAP
    obj->radiusMatch(*queryDescriptors, *trainDescriptors, *matches, maxDistance, entity(mask), compactResult != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_match2(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, std::vector<cv::DMatch> *matches,
    cv::Mat **masks, int masksSize)
{
    BEGIN_WRAP
    std::vector<cv::Mat> masksVal;
    if (masksSize != 0)
    {
        masksVal = std::vector<cv::Mat>(masksSize);
        for (int i = 0; i < masksSize; i++)
        {
            masksVal[i] = *(masks[i]);
        }
    }
    obj->match(*queryDescriptors, *matches, masksVal);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_knnMatch2(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, std::vector<std::vector<cv::DMatch> > *matches, 
    int k, cv::Mat **masks, int masksSize, int compactResult)
{
    BEGIN_WRAP
    std::vector<cv::Mat> masksVal;
    if (masksSize != 0)
    {
        masksVal = std::vector<cv::Mat>(masksSize);
        for (int i = 0; i < masksSize; i++)
        {
            masksVal[i] = *(masks[i]);
        }
    }
    obj->knnMatch(*queryDescriptors, *matches, k, masksVal, compactResult != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_radiusMatch2(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, std::vector<std::vector<cv::DMatch> > *matches, 
    float maxDistance, cv::Mat **masks, int masksSize, int compactResult)
{
    BEGIN_WRAP
    std::vector<cv::Mat> masksVal;
    if (masksSize != 0)
    {
        masksVal = std::vector<cv::Mat>(masksSize);
        for (int i = 0; i < masksSize; i++)
        {
            masksVal[i] = *(masks[i]);
        }
    }
    obj->radiusMatch(*queryDescriptors, *matches, maxDistance, masksVal, compactResult != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_DescriptorMatcher_create(
    const char *descriptorMatcherType, cv::Ptr<cv::DescriptorMatcher> **returnValue)
{
    BEGIN_WRAP
    const cv::Ptr<cv::DescriptorMatcher> ret = cv::DescriptorMatcher::create(descriptorMatcherType);
    *returnValue = new cv::Ptr<cv::DescriptorMatcher>(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_DescriptorMatcher_get(
    cv::Ptr<cv::DescriptorMatcher> *ptr, cv::DescriptorMatcher **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}
CVAPI(ExceptionStatus) features2d_Ptr_DescriptorMatcher_delete(cv::Ptr<cv::DescriptorMatcher> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

#pragma endregion

#pragma region BFMatcher

CVAPI(ExceptionStatus) features2d_BFMatcher_new(int normType, int crossCheck, cv::BFMatcher **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::BFMatcher(normType, crossCheck != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BFMatcher_delete(cv::BFMatcher *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_BFMatcher_isMaskSupported(cv::BFMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isMaskSupported() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_BFMatcher_get(cv::Ptr<cv::BFMatcher> *ptr, cv::BFMatcher **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_BFMatcher_delete(cv::Ptr<cv::BFMatcher> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

#pragma endregion

#pragma region FlannBasedMatcher

CVAPI(ExceptionStatus) features2d_FlannBasedMatcher_new(
    cv::Ptr<cv::flann::IndexParams> *indexParams, cv::Ptr<cv::flann::SearchParams> *searchParams, cv::FlannBasedMatcher **returnValue)
{
    BEGIN_WRAP
    cv::Ptr<cv::flann::IndexParams> indexParamsPtr;
    cv::Ptr<cv::flann::SearchParams> searchParamsPtr;
    if (indexParams == nullptr)
        indexParamsPtr = cv::makePtr<cv::flann::KDTreeIndexParams>();
    else
        indexParamsPtr = *indexParams;
    
    if (searchParams == nullptr)
        searchParamsPtr = cv::makePtr<cv::flann::SearchParams>();
    else    
        searchParamsPtr = *searchParams;
    
    *returnValue = new cv::FlannBasedMatcher(indexParamsPtr, searchParamsPtr);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_FlannBasedMatcher_delete(cv::FlannBasedMatcher *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_FlannBasedMatcher_add(
    cv::FlannBasedMatcher *obj, cv::Mat **descriptors, int descriptorsSize)
{
    BEGIN_WRAP
    std::vector<cv::Mat> descriptorsVal(descriptorsSize);
    for (int i = 0; i < descriptorsSize; i++)
    {
        descriptorsVal[i] = *(descriptors[i]);
    }
    obj->add(descriptorsVal);
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_FlannBasedMatcher_clear(cv::FlannBasedMatcher *obj)
{
    BEGIN_WRAP
    obj->clear();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_FlannBasedMatcher_train(cv::FlannBasedMatcher *obj)
{
    BEGIN_WRAP
    obj->train();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_FlannBasedMatcher_isMaskSupported(cv::FlannBasedMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isMaskSupported() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_FlannBasedMatcher_get(
    cv::Ptr<cv::FlannBasedMatcher> *ptr, cv::FlannBasedMatcher **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) features2d_Ptr_FlannBasedMatcher_delete(cv::Ptr<cv::FlannBasedMatcher> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

#pragma endregion
