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


// AverageHash

CVAPI(cv::Ptr<cv::img_hash::AverageHash>*) img_hash_AverageHash_create()
{
	const auto ptr = cv::img_hash::AverageHash::create();
	return clone(ptr);
}

CVAPI(void) img_hash_Ptr_AverageHash_delete(cv::Ptr<cv::img_hash::AverageHash> *ptr)
{
	delete ptr;
}

CVAPI(cv::img_hash::AverageHash*) img_hash_Ptr_AverageHash_get(cv::Ptr<cv::img_hash::AverageHash> *ptr)
{
	return ptr->get();
}

// BlockMeanHash

CVAPI(cv::Ptr<cv::img_hash::BlockMeanHash>*) img_hash_BlockMeanHash_create(const int mode)
{
	const auto ptr = cv::img_hash::BlockMeanHash::create(mode);
	return clone(ptr);
}

CVAPI(void) img_hash_Ptr_BlockMeanHash_delete(cv::Ptr<cv::img_hash::BlockMeanHash> *ptr)
{
	delete ptr;
}

CVAPI(cv::img_hash::BlockMeanHash*) img_hash_Ptr_BlockMeanHash_get(cv::Ptr<cv::img_hash::BlockMeanHash> *ptr)
{
	return ptr->get();
}

CVAPI(void) img_hash_BlockMeanHash_setMode(cv::img_hash::BlockMeanHash *obj, const int mode)
{
	obj->setMode(mode);
}

CVAPI(void) img_hash_BlockMeanHash_getMean(cv::img_hash::BlockMeanHash *obj, std::vector<double> *outVec)
{
	const auto mean = obj->getMean();
	outVec->clear();
	outVec->assign(mean.begin(), mean.end());
}

// ColorMomentHash

CVAPI(cv::Ptr<cv::img_hash::ColorMomentHash>*) img_hash_ColorMomentHash_create()
{
	const auto ptr = cv::img_hash::ColorMomentHash::create();
	return clone(ptr);
}

CVAPI(void) img_hash_Ptr_ColorMomentHash_delete(cv::Ptr<cv::img_hash::ColorMomentHash> *ptr)
{
	delete ptr;
}

CVAPI(cv::img_hash::ColorMomentHash*) img_hash_Ptr_ColorMomentHash_get(cv::Ptr<cv::img_hash::ColorMomentHash> *ptr)
{
	return ptr->get();
}

// MarrHildrethHash

CVAPI(cv::Ptr<cv::img_hash::MarrHildrethHash>*) img_hash_MarrHildrethHash_create(const float alpha, const float scale)
{
	const auto ptr = cv::img_hash::MarrHildrethHash::create(alpha, scale);
	return clone(ptr);
}

CVAPI(void) img_hash_Ptr_MarrHildrethHash_delete(cv::Ptr<cv::img_hash::MarrHildrethHash> *ptr)
{
	delete ptr;
}

CVAPI(cv::img_hash::MarrHildrethHash*) img_hash_Ptr_MarrHildrethHash_get(cv::Ptr<cv::img_hash::MarrHildrethHash> *ptr)
{
	return ptr->get();
}

CVAPI(void) img_hash_MarrHildrethHash_setKernelParam(cv::img_hash::MarrHildrethHash *obj, const float alpha, const float scale)
{
	obj->setKernelParam(alpha, scale);
}

CVAPI(float) img_hash_MarrHildrethHash_getAlpha(cv::img_hash::MarrHildrethHash *obj)
{
	return obj->getAlpha();
}

CVAPI(float) img_hash_MarrHildrethHash_getScale(cv::img_hash::MarrHildrethHash *obj)
{
	return obj->getScale();
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