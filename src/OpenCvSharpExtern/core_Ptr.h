/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_PTR_H_
#define _CPP_CORE_PTR_H_

#include "include_opencv.h"

CVAPI(cv::FeatureDetector*) core_Ptr_FeatureDetector_obj(cv::Ptr<cv::FeatureDetector>* ptr)
{
	return ptr->obj;
}
CVAPI(void) core_Ptr_FeatureDetector_delete(cv::Ptr<cv::FeatureDetector>* ptr)
{
	delete ptr;
}

CVAPI(cv::Feature2D*) core_Ptr_Feature2D_obj(cv::Ptr<cv::Feature2D>* ptr)
{
	return ptr->obj;
}
CVAPI(void) core_Ptr_Feature2D_delete(cv::Ptr<cv::Feature2D>* ptr)
{
	delete ptr;
}

CVAPI(cv::DescriptorMatcher*) core_Ptr_DescriptorMatcher_obj(cv::Ptr<cv::DescriptorMatcher>* ptr)
{
	return ptr->obj;
}
CVAPI(void) core_Ptr_DescriptorMatcher_delete(cv::Ptr<cv::DescriptorMatcher>* ptr)
{
	delete ptr;
}

#endif