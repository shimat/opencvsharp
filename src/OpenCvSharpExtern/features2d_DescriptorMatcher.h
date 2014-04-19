/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

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
CVAPI(void) features2d_DescriptorMatcher_match(cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, 
	cv::Mat *trainDescriptors, std::vector<cv::DMatch> *matches, cv::Mat *mask)
{
	obj->match(*queryDescriptors, *trainDescriptors, *matches, entity(mask));
}
CVAPI(void) features2d_DescriptorMatcher_knnMatch(cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors,
	cv::Mat *trainDescriptors, std::vector<std::vector<cv::DMatch> > *matches, int k,
	cv::Mat *mask, int compactResult)
{
	obj->knnMatch(*queryDescriptors, *trainDescriptors, *matches, k, entity(mask), compactResult != 0);
}
CVAPI(void) features2d_DescriptorMatcher_radiusMatch(cv::DescriptorMatcher *obj, cv::Mat *queryDescriptors, 
	cv::Mat *trainDescriptors, std::vector<std::vector<cv::DMatch> > *matches, float maxDistance,
	cv::Mat *mask, int compactResult)
{
	obj->radiusMatch(*queryDescriptors, *trainDescriptors, *matches, maxDistance, entity(mask), compactResult != 0);
}
/*
	CV_WRAP void match(const Mat& queryDescriptors, CV_OUT vector<DMatch>& matches,
		const vector<Mat>& masks = vector<Mat>());
	CV_WRAP void knnMatch(const Mat& queryDescriptors, CV_OUT vector<vector<DMatch> >& matches, int k,
		const vector<Mat>& masks = vector<Mat>(), bool compactResult = false);
	void radiusMatch(const Mat& queryDescriptors, vector<vector<DMatch> >& matches, float maxDistance,
		const vector<Mat>& masks = vector<Mat>(), bool compactResult = false);
*/

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

#endif