#ifndef _CPP_CORE_ALGORITHM_H_
#define _CPP_CORE_ALGORITHM_H_

#include "include_opencv.h"

CVAPI(cv::Algorithm*) core_Algorithm_new()
{
	return new cv::Algorithm();
}
CVAPI(void) core_Algorithm_delete(cv::Algorithm *obj)
{
	delete obj;
}

CVAPI(cv::Ptr<cv::Algorithm>*) core_Ptr_Algorithm_new(cv::Algorithm *rawPtr)
{
	return new cv::Ptr<cv::Algorithm>(rawPtr);
}
CVAPI(void) core_Ptr_Algorithm_delete(cv::Ptr<cv::Algorithm> *ptr)
{
	delete ptr;
}
CVAPI(cv::Algorithm*) core_Ptr_Algorithm_get(cv::Ptr<cv::Algorithm> *ptr)
{
	return ptr->get();
}

#endif