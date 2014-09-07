#if WIN32
#pragma once
#endif

#ifndef _CPP_XFEATURES2D_H_
#define _CPP_XFEATURES2D_H_

#include "include_opencv.h"
using namespace cv::xfeatures2d;

#pragma region BriefDescriptorExtractor

CVAPI(BriefDescriptorExtractor*) xfeatures2d_BriefDescriptorExtractor_new(int bytes)
{
	return new BriefDescriptorExtractor(bytes);
}
CVAPI(void) xfeatures2d_BriefDescriptorExtractor_delete(BriefDescriptorExtractor *obj)
{
	delete obj;
}

CVAPI(void) xfeatures2d_BriefDescriptorExtractor_read(
	BriefDescriptorExtractor *obj, cv::FileNode *fn)
{
	obj->read(*fn);
}
CVAPI(void) xfeatures2d_BriefDescriptorExtractor_write(
	BriefDescriptorExtractor *obj, cv::FileStorage *fs)
{
	obj->write(*fs);
}

CVAPI(int) xfeatures2d_BriefDescriptorExtractor_descriptorSize(BriefDescriptorExtractor *obj)
{
	return obj->descriptorSize();
}
CVAPI(int) xfeatures2d_BriefDescriptorExtractor_descriptorType(BriefDescriptorExtractor *obj)
{
	return obj->descriptorType();
}

CVAPI(BriefDescriptorExtractor*) xfeatures2d_Ptr_BriefDescriptorExtractor_get(
	cv::Ptr<BriefDescriptorExtractor>* ptr)
{
	return ptr->get();
}
CVAPI(void) xfeatures2d_Ptr_BriefDescriptorExtractor_delete(
	cv::Ptr<BriefDescriptorExtractor>* ptr)
{
	delete ptr;
}

#pragma endregion

#pragma region FREAK
CVAPI(FREAK*) xfeatures2d_FREAK_new(int orientationNormalized,
	int scaleNormalized, float patternScale, int nOctaves,
	int *selectedPairs, int selectedPairsLength)
{
	std::vector<int> selectedPairsVec;
	if (selectedPairs != NULL)
		selectedPairsVec = std::vector<int>(selectedPairs, selectedPairs + selectedPairsLength);
	return new FREAK(orientationNormalized != 0, scaleNormalized != 0,
		patternScale, nOctaves, selectedPairsVec);
}
CVAPI(void) xfeatures2d_FREAK_delete(FREAK *obj)
{
	delete obj;
}
CVAPI(int) xfeatures2d_FREAK_descriptorSize(FREAK *obj)
{
	return obj->descriptorSize();
}
CVAPI(int) xfeatures2d_FREAK_descriptorType(FREAK *obj)
{
	return obj->descriptorType();
}

CVAPI(void) xfeatures2d_FREAK_selectPairs(FREAK *obj, cv::Mat **images, int imagesLength,
	std::vector<std::vector<cv::KeyPoint> > *keypoints,
	double corrThresh, int verbose, std::vector<int> *out)
{
	std::vector<cv::Mat> imagesVec(imagesLength);
	for (int i = 0; i < imagesLength; i++)
		imagesVec[i] = *(images[i]);

	std::vector<int> ret = obj->selectPairs(imagesVec, *keypoints, corrThresh, verbose != 0);
	std::copy(ret.begin(), ret.end(), out->begin());
}

CVAPI(cv::AlgorithmInfo*) xfeatures2d_FREAK_info(FREAK *obj)
{
	return obj->info();
}

CVAPI(FREAK*) xfeatures2d_Ptr_FREAK_get(cv::Ptr<FREAK> *ptr)
{
	return ptr->get();
}
CVAPI(void) xfeatures2d_Ptr_FREAK_delete(cv::Ptr<FREAK> *ptr)
{
	delete ptr;
}

#pragma endregion

#pragma region StarDetector
CVAPI(StarDetector*) xfeatures2d_StarDetector_new(int maxSize, int responseThreshold,
	int lineThresholdProjected, int lineThresholdBinarized, int suppressNonmaxSize)
{
	return new StarDetector(maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);
}
CVAPI(void) xfeatures2d_StarDetector_delete(StarDetector *obj)
{
	delete obj;
}
CVAPI(void) xfeatures2d_StarDetector_detect(StarDetector *obj, cv::Mat *image,
	std::vector<cv::KeyPoint> **keypoints)
{
	*keypoints = new std::vector<cv::KeyPoint>;
	(*obj)(*image, **keypoints);
}
CVAPI(cv::AlgorithmInfo*) xfeatures2d_StarDetector_info(StarDetector *obj)
{
	return obj->info();
}

CVAPI(StarDetector*) xfeatures2d_Ptr_StarDetector_get(cv::Ptr<StarDetector> *ptr)
{
	return ptr->get();
}
CVAPI(void) xfeatures2d_Ptr_StarDetector_delete(cv::Ptr<StarDetector> *ptr)
{
	delete ptr;
}
#pragma endregion

#pragma region SIFT

CVAPI(SIFT*) xfeatures2d_SIFT_new(int nfeatures, int nOctaveLayers,
	double contrastThreshold, double edgeThreshold, double sigma)
{
	return new SIFT(nfeatures, nOctaveLayers, contrastThreshold, edgeThreshold, sigma);
}
CVAPI(void) xfeatures2d_SIFT_delete(SIFT *obj)
{
	delete obj;
}

CVAPI(cv::Ptr<SIFT>*) xfeatures2d_SIFT_createAlgorithm(const char *name)
{
	cv::Ptr<SIFT> al = cv::Algorithm::create<SIFT>(name);
	return al.empty() ? NULL : clone(al);
}

CVAPI(SIFT*) xfeatures2d_Ptr_SIFT_get(cv::Ptr<SIFT> *ptr)
{
	return ptr->get();
}
CVAPI(void) xfeatures2d_Ptr_SIFT_delete(cv::Ptr<SIFT> *ptr)
{
	delete ptr;
}

CVAPI(int) xfeatures2d_SIFT_descriptorSize(SIFT *obj)
{
	return obj->descriptorSize();
}
CVAPI(int) xfeatures2d_SIFT_descriptorType(SIFT *obj)
{
	return obj->descriptorType();
}

CVAPI(void) xfeatures2d_SIFT_run1(SIFT *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints)
{
	(*obj)(*img, entity(mask), *keypoints);
}
/*
CVAPI(void) xfeatures2d_SIFT_run2_vector(SIFT *obj, cv::_InputArray *img, cv::_InputArray *mask,
std::vector<cv::KeyPoint> *keypoints, std::vector<float > *descriptors,
int useProvidedKeypoints)
{
(*obj)(*img, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}*/
CVAPI(void) xfeatures2d_SIFT_run2_OutputArray(SIFT *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors,
	int useProvidedKeypoints)
{
	(*obj)(*img, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}
CVAPI(cv::AlgorithmInfo*) xfeatures2d_SIFT_info(SIFT *obj)
{
	return obj->info();
}

CVAPI(void) xfeatures2d_SIFT_buildGaussianPyramid(SIFT *obj, cv::Mat *base, std::vector<cv::Mat> *pyr, int nOctaves)
{
	obj->buildGaussianPyramid(*base, *pyr, nOctaves);
}
CVAPI(void) xfeatures2d_SIFT_buildDoGPyramid(SIFT *obj, cv::Mat **pyr, int pyrLength, std::vector<cv::Mat> *dogPyr)
{
	std::vector<cv::Mat> pyrVec(pyrLength);
	for (int i = 0; i < pyrLength; i++)
		pyrVec[i] = *pyr[i];
	obj->buildDoGPyramid(pyrVec, *dogPyr);
}
CVAPI(void) xfeatures2d_SIFT_findScaleSpaceExtrema(SIFT *obj, cv::Mat **gaussPyr, int gaussPyrLength,
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

CVAPI(SURF*) xfeatures2d_SURF_new1()
{
	return new SURF();
}
CVAPI(SURF*) xfeatures2d_SURF_new2(double hessianThreshold, int nOctaves,
	int nOctaveLayers, int extended, int upright)
{
	return new SURF(hessianThreshold, nOctaves, nOctaveLayers, extended != 0, upright != 0);
}
CVAPI(void) xfeatures2d_SURF_delete(SURF *obj)
{
	delete obj;
}

CVAPI(cv::Ptr<SURF>*) xfeatures2d_SURF_createAlgorithm(const char *name)
{
	cv::Ptr<SURF> al = cv::Algorithm::create<SURF>(name);
	return al.empty() ? NULL : clone(al);
}

CVAPI(SURF*) xfeatures2d_Ptr_SURF_get(cv::Ptr<SURF> *ptr)
{
	return ptr->get();
}
CVAPI(void) xfeatures2d_Ptr_SURF_delete(cv::Ptr<SURF> *ptr)
{
	delete ptr;
}

CVAPI(int) xfeatures2d_SURF_descriptorSize(SURF *obj)
{
	return obj->descriptorSize();
}
CVAPI(int) xfeatures2d_SURF_descriptorType(SURF *obj)
{
	return obj->descriptorType();
}

CVAPI(void) xfeatures2d_SURF_run1(SURF *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints)
{
	(*obj)(*img, entity(mask), *keypoints);
}
CVAPI(void) xfeatures2d_SURF_run2_vector(SURF *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints, std::vector<float > *descriptors,
	int useProvidedKeypoints)
{
	(*obj)(*img, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}
CVAPI(void) xfeatures2d_SURF_run2_OutputArray(SURF *obj, cv::_InputArray *img, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors,
	int useProvidedKeypoints)
{
	(*obj)(*img, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}
CVAPI(cv::AlgorithmInfo*) xfeatures2d_SURF_info(SURF *obj)
{
	return obj->info();
}

CVAPI(double) xfeatures2d_SURF_hessianThreshold_get(SURF *obj)
{
	return obj->hessianThreshold;
}
CVAPI(int) xfeatures2d_SURF_nOctaves_get(SURF *obj)
{
	return obj->nOctaves;
}
CVAPI(int) xfeatures2d_SURF_nOctaveLayers_get(SURF *obj)
{
	return obj->nOctaveLayers;
}
CVAPI(int) xfeatures2d_SURF_extended_get(SURF *obj)
{
	return obj->extended ? 1 : 0;
}
CVAPI(int) xfeatures2d_SURF_upright_get(SURF *obj)
{
	return obj->upright ? 1 : 0;
}

CVAPI(void) xfeatures2d_SURF_hessianThreshold_set(SURF *obj, double value)
{
	obj->hessianThreshold = value;
}
CVAPI(void) xfeatures2d_SURF_nOctaves_set(SURF *obj, int value)
{
	obj->nOctaves = value;
}
CVAPI(void) xfeatures2d_SURF_nOctaveLayers_set(SURF *obj, int value)
{
	obj->nOctaveLayers = value;
}
CVAPI(void) xfeatures2d_SURF_extended_set(SURF *obj, int value)
{
	obj->extended = (value != 0);
}
CVAPI(void) xfeatures2d_SURF_upright_set(SURF *obj, int value)
{
	obj->upright = (value != 0);
}

#pragma endregion

#endif