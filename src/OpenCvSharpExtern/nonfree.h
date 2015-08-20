#ifndef _CPP_NONFREE_H_
#define _CPP_NONFREE_H_

#include "include_opencv.h"

CVAPI(int) nonfree_initModule_nonfree()
{
	return cv::initModule_nonfree() ? 1 : 0;
}

#pragma region SIFT

CVAPI(cv::SIFT*) nonfree_SIFT_new(int nfeatures, int nOctaveLayers,
	double contrastThreshold, double edgeThreshold,	double sigma)
{
	return new cv::SIFT(nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma);
}
CVAPI(void) nonfree_SIFT_delete(cv::SIFT *obj)
{
	delete obj;
}

CVAPI(cv::Ptr<cv::SIFT>*) nonfree_SIFT_createAlgorithm(const char *name)
{
    cv::Ptr<cv::SIFT> al = cv::Algorithm::create<cv::SIFT>(name);
    return al.empty() ? NULL : clone( al );
}

CVAPI(cv::SIFT*) nonfree_Ptr_SIFT_obj(cv::Ptr<cv::SIFT> *ptr)
{
    return ptr->obj;
}
CVAPI(void) nonfree_Ptr_SIFT_delete(cv::Ptr<cv::SIFT> *ptr)
{
	delete ptr;
}

CVAPI(int) nonfree_SIFT_descriptorSize(cv::SIFT *obj)
{
	return obj->descriptorSize();
}
CVAPI(int) nonfree_SIFT_descriptorType(cv::SIFT *obj)
{
	return obj->descriptorType();
}

CVAPI(void) nonfree_SIFT_run1(cv::SIFT *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints)
{
	(*obj)(*img, entity(mask), *keypoints);
}
/*
CVAPI(void) nonfree_SIFT_run2_vector(cv::SIFT *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints, std::vector<float > *descriptors,
	int useProvidedKeypoints)
{
	(*obj)(*img, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}*/
CVAPI(void) nonfree_SIFT_run2_OutputArray(cv::SIFT *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors,
	int useProvidedKeypoints)
{
	(*obj)(*img, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}
CVAPI(cv::AlgorithmInfo*) nonfree_SIFT_info(cv::SIFT *obj)
{
	return obj->info();
}

CVAPI(void) nonfree_SIFT_buildGaussianPyramid(cv::SIFT *obj, cv::Mat *base, std::vector<cv::Mat> *pyr, int nOctaves)
{	
	obj->buildGaussianPyramid(*base, *pyr, nOctaves);
}
CVAPI(void) nonfree_SIFT_buildDoGPyramid(cv::SIFT *obj, cv::Mat **pyr, int pyrLength, std::vector<cv::Mat> *dogPyr)
{
	std::vector<cv::Mat> pyrVec(pyrLength);
	for (int i = 0; i < pyrLength; i++)
		pyrVec[i] = *pyr[i];
	obj->buildDoGPyramid(pyrVec, *dogPyr);
}
CVAPI(void) nonfree_SIFT_findScaleSpaceExtrema(cv::SIFT *obj, cv::Mat **gaussPyr, int gaussPyrLength,
	cv::Mat **dogPyr, int dogPyrLength, std::vector<cv::KeyPoint> *keypoints)
{
	std::vector<cv::Mat> gaussPyrVec(gaussPyrLength);
	for (int i = 0; i < gaussPyrLength; i++)
		gaussPyrVec[i] = *gaussPyr[i];
	std::vector<cv::Mat> dogPyrVec(dogPyrLength);
	for (int i = 0; i < dogPyrLength; i++)
		dogPyrVec[i] = *dogPyr[i];
	obj->findScaleSpaceExtrema(gaussPyrVec, dogPyrVec, *keypoints);
}

#pragma endregion

#pragma region SURF

CVAPI(cv::SURF*) nonfree_SURF_new1()
{
	return new cv::SURF();
}
CVAPI(cv::SURF*) nonfree_SURF_new2(double hessianThreshold, int nOctaves,
	int nOctaveLayers, int extended, int upright)
{
	return new cv::SURF(hessianThreshold, nOctaves, nOctaveLayers, extended != 0, upright != 0);
}
CVAPI(void) nonfree_SURF_delete(cv::SURF *obj)
{
	delete obj;
}

CVAPI(cv::Ptr<cv::SURF>*) nonfree_SURF_createAlgorithm(const char *name)
{
    cv::Ptr<cv::SURF> al = cv::Algorithm::create<cv::SURF>(name);
    return al.empty() ? NULL : clone( al );
}

CVAPI(cv::SURF*) nonfree_Ptr_SURF_obj(cv::Ptr<cv::SURF> *ptr)
{
    return ptr->obj;
}
CVAPI(void) nonfree_Ptr_SURF_delete(cv::Ptr<cv::SURF> *ptr)
{
	delete ptr;
}

CVAPI(int) nonfree_SURF_descriptorSize(cv::SURF *obj)
{
	return obj->descriptorSize();
}
CVAPI(int) nonfree_SURF_descriptorType(cv::SURF *obj)
{
	return obj->descriptorType();
}

CVAPI(void) nonfree_SURF_run1(cv::SURF *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints)
{
	(*obj)(*img, entity(mask), *keypoints);
}
CVAPI(void) nonfree_SURF_run2_vector(cv::SURF *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints, std::vector<float > *descriptors,
	int useProvidedKeypoints)
{
	(*obj)(*img, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}
CVAPI(void) nonfree_SURF_run2_OutputArray(cv::SURF *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors,
	int useProvidedKeypoints)
{
	(*obj)(*img, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}
CVAPI(cv::AlgorithmInfo*) nonfree_SURF_info(cv::SURF *obj)
{
	return obj->info();
}

CVAPI(double) nonfree_SURF_hessianThreshold_get(cv::SURF *obj)
{
	return obj->hessianThreshold;
}
CVAPI(int) nonfree_SURF_nOctaves_get(cv::SURF *obj)
{
	return obj->nOctaves;
}
CVAPI(int) nonfree_SURF_nOctaveLayers_get(cv::SURF *obj)
{
	return obj->nOctaveLayers;
}
CVAPI(int) nonfree_SURF_extended_get(cv::SURF *obj)
{
	return obj->extended ? 1 : 0;
}
CVAPI(int) nonfree_SURF_upright_get(cv::SURF *obj)
{
	return obj->upright ? 1 : 0;
}

CVAPI(void) nonfree_SURF_hessianThreshold_set(cv::SURF *obj, double value)
{
	obj->hessianThreshold = value;
}
CVAPI(void) nonfree_SURF_nOctaves_set(cv::SURF *obj, int value)
{
	obj->nOctaves = value;
}
CVAPI(void) nonfree_SURF_nOctaveLayers_set(cv::SURF *obj, int value)
{
	obj->nOctaveLayers = value;
}
CVAPI(void) nonfree_SURF_extended_set(cv::SURF *obj, int value)
{
	obj->extended = (value != 0);
}
CVAPI(void) nonfree_SURF_upright_set(cv::SURF *obj, int value)
{
	obj->upright = (value != 0);
}

#pragma endregion

#endif