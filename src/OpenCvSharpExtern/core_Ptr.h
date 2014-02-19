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

#endif