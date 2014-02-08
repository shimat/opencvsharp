/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_PTR_H_
#define _CPP_CORE_PTR_H_

#include "include_opencv.h"

CVAPI(void) core_Ptr_FeatureDetector_delete(cv::Ptr<cv::FeatureDetector>* obj)
{
	delete obj;
}

#endif