#pragma once

#ifndef NO_FEATURES

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region DescriptorMatcher
CVAPI(ExceptionStatus) features_DescriptorMatcher_add(cv::DescriptorMatcher *obj, cv::Mat **descriptors, int descriptorLength)
{
    return cvTry([&] {
    std::vector<cv::Mat> descriptorsVec(descriptorLength);
    for (int i = 0; i < descriptorLength; i++)    
        descriptorsVec[i] = *descriptors[i];
    obj->add(descriptorsVec);
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_getTrainDescriptors(cv::DescriptorMatcher *obj, std::vector<cv::Mat> *dst)
{
    return cvTry([&] {
    *dst = obj->getTrainDescriptors();
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_clear(cv::DescriptorMatcher *obj)
{
    return cvTry([&] {
    obj->clear();
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_empty(cv::DescriptorMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->empty() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) features_DescriptorMatcher_isMaskSupported(cv::DescriptorMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->isMaskSupported() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_train(cv::DescriptorMatcher *obj)
{
    return cvTry([&] {
    obj->train();
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_match1(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, 
    cv::Mat *trainDescriptors, std::vector<cv::DMatch> *matches, cv::Mat *mask)
{
    return cvTry([&] {
    obj->match(*queryDescriptors, *trainDescriptors, *matches, entity(mask));
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_knnMatch1(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors,
    cv::Mat *trainDescriptors, std::vector<std::vector<cv::DMatch> > *matches, int k,
    cv::Mat *mask, int compactResult)
{
    return cvTry([&] {
    obj->knnMatch(*queryDescriptors, *trainDescriptors, *matches, k, entity(mask), compactResult != 0);
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_radiusMatch1(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, 
    cv::Mat *trainDescriptors, std::vector<std::vector<cv::DMatch> > *matches, float maxDistance,
    cv::Mat *mask, int compactResult)
{
    return cvTry([&] {
    obj->radiusMatch(*queryDescriptors, *trainDescriptors, *matches, maxDistance, entity(mask), compactResult != 0);
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_match2(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, std::vector<cv::DMatch> *matches,
    cv::Mat **masks, int masksSize)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_knnMatch2(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, std::vector<std::vector<cv::DMatch> > *matches, 
    int k, cv::Mat **masks, int masksSize, int compactResult)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_radiusMatch2(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, std::vector<std::vector<cv::DMatch> > *matches, 
    float maxDistance, cv::Mat **masks, int masksSize, int compactResult)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) features_DescriptorMatcher_create(
    const char *descriptorMatcherType, cv::Ptr<cv::DescriptorMatcher> **returnValue)
{
    return cvTry([&] {
    const cv::Ptr<cv::DescriptorMatcher> ret = cv::DescriptorMatcher::create(descriptorMatcherType);
    *returnValue = new cv::Ptr<cv::DescriptorMatcher>(ret);
    });
}

CVAPI(ExceptionStatus) features_Ptr_DescriptorMatcher_get(
    cv::Ptr<cv::DescriptorMatcher> *ptr, cv::DescriptorMatcher **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}
CVAPI(ExceptionStatus) features_Ptr_DescriptorMatcher_delete(cv::Ptr<cv::DescriptorMatcher> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

#pragma endregion

#pragma region BFMatcher

CVAPI(ExceptionStatus) features_BFMatcher_new(int normType, int crossCheck, cv::BFMatcher **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::BFMatcher(normType, crossCheck != 0);
    });
}

CVAPI(ExceptionStatus) features_BFMatcher_delete(cv::BFMatcher *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) features_BFMatcher_isMaskSupported(cv::BFMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->isMaskSupported() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) features_Ptr_BFMatcher_get(cv::Ptr<cv::BFMatcher> *ptr, cv::BFMatcher **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) features_Ptr_BFMatcher_delete(cv::Ptr<cv::BFMatcher> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

#pragma endregion

#pragma region FlannBasedMatcher

CVAPI(ExceptionStatus) features_FlannBasedMatcher_new(
    cv::Ptr<cv::flann::IndexParams> *indexParams, cv::Ptr<cv::flann::SearchParams> *searchParams, cv::FlannBasedMatcher **returnValue)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) features_FlannBasedMatcher_delete(cv::FlannBasedMatcher *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) features_FlannBasedMatcher_add(
    cv::FlannBasedMatcher *obj, cv::Mat **descriptors, int descriptorsSize)
{
    return cvTry([&] {
    std::vector<cv::Mat> descriptorsVal(descriptorsSize);
    for (int i = 0; i < descriptorsSize; i++)
    {
        descriptorsVal[i] = *(descriptors[i]);
    }
    obj->add(descriptorsVal);
    });
}

CVAPI(ExceptionStatus) features_FlannBasedMatcher_clear(cv::FlannBasedMatcher *obj)
{
    return cvTry([&] {
    obj->clear();
    });
}

CVAPI(ExceptionStatus) features_FlannBasedMatcher_train(cv::FlannBasedMatcher *obj)
{
    return cvTry([&] {
    obj->train();
    });
}

CVAPI(ExceptionStatus) features_FlannBasedMatcher_isMaskSupported(cv::FlannBasedMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->isMaskSupported() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) features_Ptr_FlannBasedMatcher_get(
    cv::Ptr<cv::FlannBasedMatcher> *ptr, cv::FlannBasedMatcher **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) features_Ptr_FlannBasedMatcher_delete(cv::Ptr<cv::FlannBasedMatcher> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

#pragma endregion


#ifdef HAVE_OPENCV_DNN

#pragma region LightGlueMatcher

CVAPI(ExceptionStatus) features_LightGlueMatcher_create(
    const char *modelPath, float scoreThreshold, int backend, int target,
    cv::Ptr<cv::LightGlueMatcher> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::LightGlueMatcher::create(cv::String(modelPath), scoreThreshold, backend, target);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) features_LightGlueMatcher_create_buffer(
    const uchar *modelData, size_t modelDataLength, float scoreThreshold, int backend, int target,
    cv::Ptr<cv::LightGlueMatcher> **returnValue)
{
    return cvTry([&] {
    const std::vector<uchar> buf(modelData, modelData + modelDataLength);
    const auto ptr = cv::LightGlueMatcher::create(buf, scoreThreshold, backend, target);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) features_LightGlueMatcher_setPairInfo(
    cv::LightGlueMatcher *obj, cv::_InputArray *queryKpts, cv::_InputArray *trainKpts,
    interop::Size queryImageSize, interop::Size trainImageSize)
{
    return cvTry([&] {
    obj->setPairInfo(*queryKpts, *trainKpts, cpp(queryImageSize), cpp(trainImageSize));
    });
}

CVAPI(ExceptionStatus) features_LightGlueMatcher_clearPairInfo(cv::LightGlueMatcher *obj)
{
    return cvTry([&] {
    obj->clearPairInfo();
    });
}

CVAPI(ExceptionStatus) features_Ptr_LightGlueMatcher_get(
    cv::Ptr<cv::LightGlueMatcher> *ptr, cv::LightGlueMatcher **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) features_Ptr_LightGlueMatcher_delete(cv::Ptr<cv::LightGlueMatcher> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

#pragma endregion

#endif // HAVE_OPENCV_DNN

#endif // NO_FEATURES
