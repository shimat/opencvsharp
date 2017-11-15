#ifndef _CPP_IMG_HASH_H_
#define _CPP_IMG_HASH_H_

#include "include_opencv.h"


CVAPI(void) img_hash_ImgHashBase_compute(cv::img_hash::ImgHashBase *obj, cv::_InputArray *inputArr, cv::_OutputArray *outputArr)
{
	obj->compute(*inputArr, *outputArr);
}

CVAPI(double) img_hash_ImgHashBase_compare(cv::img_hash::ImgHashBase *obj, cv::_InputArray *hashOne, cv::_InputArray *hashTwo)
{
	return obj->compare(*hashOne, *hashTwo);
}

// PHash

CVAPI(cv::Ptr<cv::img_hash::PHash>*) img_hash_PHash_create()
{
	const auto ptr = cv::img_hash::PHash::create();
	return clone(ptr);
}

CVAPI(void) img_hash_Ptr_PHash_delete(cv::Ptr<cv::img_hash::PHash> *ptr)
{
	delete ptr;
}

CVAPI(cv::img_hash::PHash*) img_hash_Ptr_PHash_get(cv::Ptr<cv::img_hash::PHash> *ptr)
{
	return ptr->get();
}

#endif