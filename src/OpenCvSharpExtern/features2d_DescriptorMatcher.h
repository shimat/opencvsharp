#ifndef _CPP_FEATURES2D_DESCRIPTROMATCHER_H_
#define _CPP_FEATURES2D_DESCRIPTROMATCHER_H_

#include "include_opencv.h"

#pragma region DescriptorMatcher
CVAPI(void) features2d_DescriptorMatcher_add(cv::DescriptorMatcher *obj, cv::Mat **descriptors, int descriptorLength)
{
	std::vector<cv::Mat> descriptorsVec(descriptorLength);
	for (int i = 0; i < descriptorLength; i++)	
		descriptorsVec[i] = *descriptors[i];
	obj->add(descriptorsVec);
}
CVAPI(void) features2d_DescriptorMatcher_getTrainDescriptors(cv::DescriptorMatcher *obj, std::vector<cv::Mat> *dst)
{
	*dst = obj->getTrainDescriptors();
}
CVAPI(void) features2d_DescriptorMatcher_clear(cv::DescriptorMatcher *obj)
{
	obj->clear();
}
CVAPI(int) features2d_DescriptorMatcher_empty(cv::DescriptorMatcher *obj)
{
	return obj->empty() ? 1 : 0;
}
CVAPI(int) features2d_DescriptorMatcher_isMaskSupported(cv::DescriptorMatcher *obj)
{
	return obj->isMaskSupported() ? 1 : 0;
}

CVAPI(void) features2d_DescriptorMatcher_train(cv::DescriptorMatcher *obj)
{
	obj->train();
}

CVAPI(void) features2d_DescriptorMatcher_match1(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, 
	cv::Mat *trainDescriptors, std::vector<cv::DMatch> *matches, cv::Mat *mask)
{
    obj->match(*queryDescriptors, *trainDescriptors, *matches, entity(mask));
}
CVAPI(void) features2d_DescriptorMatcher_knnMatch1(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors,
	cv::Mat *trainDescriptors, std::vector<std::vector<cv::DMatch> > *matches, int k,
	cv::Mat *mask, int compactResult)
{
	obj->knnMatch(*queryDescriptors, *trainDescriptors, *matches, k, entity(mask), compactResult != 0);
}
CVAPI(void) features2d_DescriptorMatcher_radiusMatch1(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, 
	cv::Mat *trainDescriptors, std::vector<std::vector<cv::DMatch> > *matches, float maxDistance,
	cv::Mat *mask, int compactResult)
{
	obj->radiusMatch(*queryDescriptors, *trainDescriptors, *matches, maxDistance, entity(mask), compactResult != 0);
}

CVAPI(void) features2d_DescriptorMatcher_match2(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, std::vector<cv::DMatch> *matches,
    cv::Mat **masks, int masksSize)
{
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
}
CVAPI(void) features2d_DescriptorMatcher_knnMatch2(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, std::vector<std::vector<cv::DMatch> > *matches, 
    int k, cv::Mat **masks, int masksSize, int compactResult)
{
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
}
CVAPI(void) features2d_DescriptorMatcher_radiusMatch2(
    cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, std::vector<std::vector<cv::DMatch> > *matches, 
    float maxDistance, cv::Mat **masks, int masksSize, int compactResult)
{
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
}

CVAPI(cv::Ptr<cv::DescriptorMatcher>*) features2d_DescriptorMatcher_create(const char *descriptorMatcherType)
{
	cv::Ptr<cv::DescriptorMatcher> ret = cv::DescriptorMatcher::create(descriptorMatcherType);
	return new cv::Ptr<cv::DescriptorMatcher>(ret);
}

CVAPI(cv::DescriptorMatcher*) features2d_Ptr_DescriptorMatcher_obj(cv::Ptr<cv::DescriptorMatcher> *ptr)
{
	return ptr->obj;
}
CVAPI(void) features2d_Ptr_DescriptorMatcher_delete(cv::Ptr<cv::DescriptorMatcher> *ptr)
{
	delete ptr;
}

CVAPI(cv::AlgorithmInfo*) features2d_DescriptorMatcher_info(cv::DescriptorMatcher *obj)
{
	return obj->info();
}

#pragma endregion

#pragma region BFMatcher
CVAPI(cv::BFMatcher*) features2d_BFMatcher_new(int normType, int crossCheck)
{
	return new cv::BFMatcher(normType, crossCheck != 0);
}
CVAPI(void) features2d_BFMatcher_delete(cv::BFMatcher *obj)
{
	delete obj;
}

CVAPI(int) features2d_BFMatcher_isMaskSupported(cv::BFMatcher *obj)
{
	return obj->isMaskSupported() ? 1 : 0;
}

CVAPI(cv::AlgorithmInfo*) features2d_BFMatcher_info(cv::BFMatcher *obj)
{
	return obj->info();
}

CVAPI(cv::BFMatcher*) features2d_Ptr_BFMatcher_obj(cv::Ptr<cv::BFMatcher> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_BFMatcher_delete(cv::Ptr<cv::BFMatcher> *ptr)
{
    delete ptr;
}

#pragma endregion

#pragma region FlannBasedMatcher
CVAPI(cv::FlannBasedMatcher*) features2d_FlannBasedMatcher_new(
    cv::flann::IndexParams *indexParams, cv::flann::SearchParams *searchParams)
{
    cv::Ptr<cv::flann::IndexParams> indexParamsPtr;
    cv::Ptr<cv::flann::SearchParams> searchParamsPtr;
    if (indexParams == NULL)
    {
        indexParamsPtr = new cv::flann::KDTreeIndexParams();
    }
    else
    {
        indexParamsPtr = indexParams;
        indexParamsPtr.addref();
    }
    if (searchParams == NULL)
    {
        searchParamsPtr = new cv::flann::SearchParams();
    }
    else
    {
        searchParamsPtr = searchParams;
        searchParamsPtr.addref();
    }
    return new cv::FlannBasedMatcher(indexParamsPtr, searchParamsPtr);
}
CVAPI(void) features2d_FlannBasedMatcher_delete(cv::FlannBasedMatcher *obj)
{
    delete obj;
}

CVAPI(void) features2d_FlannBasedMatcher_add(
    cv::FlannBasedMatcher *obj, cv::Mat **descriptors, int descriptorsSize)
{
    std::vector<cv::Mat> descriptorsVal(descriptorsSize);
    for (int i = 0; i < descriptorsSize; i++)
    {
        descriptorsVal[i] = *(descriptors[i]);
    }
    return obj->add(descriptorsVal);
}
CVAPI(void) features2d_FlannBasedMatcher_clear(cv::FlannBasedMatcher *obj)
{
    return obj->clear();
}
CVAPI(void) features2d_FlannBasedMatcher_train(cv::FlannBasedMatcher *obj)
{
    return obj->train();
}
CVAPI(int) features2d_FlannBasedMatcher_isMaskSupported(cv::FlannBasedMatcher *obj)
{
    return obj->isMaskSupported() ? 1 : 0;
}

CVAPI(cv::AlgorithmInfo*) features2d_FlannBasedMatcher_info(cv::FlannBasedMatcher *obj)
{
    return obj->info();
}

CVAPI(cv::FlannBasedMatcher*) features2d_Ptr_FlannBasedMatcher_obj(cv::Ptr<cv::FlannBasedMatcher> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_FlannBasedMatcher_delete(cv::Ptr<cv::FlannBasedMatcher> *ptr)
{
    delete ptr;
}

#pragma endregion

#endif