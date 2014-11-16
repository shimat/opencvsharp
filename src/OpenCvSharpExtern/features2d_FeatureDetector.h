#if WIN32
#pragma once
#endif

#ifndef _CPP_FEATURES2DFEATUREDETECTOR_H_
#define _CPP_FEATURES2DFEATUREDETECTOR_H_

#include "include_opencv.h"

#pragma region Feature2D

CVAPI(cv::Feature2D*) features2d_Ptr_Feature2D_get(cv::Ptr<cv::Feature2D>* ptr)
{
	return ptr->get();
}
CVAPI(void) features2d_Ptr_Feature2D_delete(cv::Ptr<cv::Feature2D>* ptr)
{
	delete ptr;
}

CVAPI(cv::AlgorithmInfo*) features2d_Feature2D_info(cv::FeatureDetector *obj)
{
	return obj->info();
}

CVAPI(void) features2d_Feature2D_detect_Mat1(
	cv::Feature2D *detector, cv::Mat *image, std::vector<cv::KeyPoint> *keypoints,
	cv::Mat *mask)
{
	detector->detect(*image, *keypoints, entity(mask));
}

CVAPI(void) features2d_Feature2D_detect_Mat2(
	cv::Feature2D *detector, cv::Mat **images, int imageLength,
	std::vector<std::vector<cv::KeyPoint> > *keypoints, cv::Mat **mask)
{
	std::vector<cv::Mat> imageVec(imageLength);
	std::vector<cv::Mat> maskVec;
	
	for (int i = 0; i < imageLength; i++)
		imageVec.push_back(*images[i]);
	
	if (mask != NULL)
	{
		maskVec.reserve(imageLength);
		for (int i = 0; i < imageLength; i++)
			maskVec.push_back(*mask[i]);
	}

	detector->detect(imageVec, *keypoints, maskVec);
}

CVAPI(void) features2d_Feature2D_detect_InputArray(
	cv::Feature2D *obj, cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::Mat *mask)
{
	obj->detect(*image, *keypoints, entity(mask));
}

CVAPI(void) features2d_Feature2D_compute1(cv::Feature2D *obj,
	cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors)
{
	obj->compute(*image, *keypoints, *descriptors);
}

CVAPI(void) features2d_Feature2D_compute2(
	cv::Feature2D *detector, cv::Mat **images, int imageLength,
	std::vector<std::vector<cv::KeyPoint> > *keypoints, cv::Mat **descriptors, int descriptorsLength)
{
	std::vector<cv::Mat> imageVec(imageLength);
	std::vector<cv::Mat> descriptorsVec(descriptorsLength);
	
	for (int i = 0; i < imageLength; i++)
		imageVec.push_back(*images[i]);
	for (int i = 0; i < descriptorsLength; i++)
		descriptorsVec.push_back(*descriptors[i]);

	detector->compute(imageVec, *keypoints, descriptorsVec);
}

CVAPI(int) features2d_Feature2D_descriptorSize(cv::Ptr<cv::Feature2D> *obj)
{
	return obj->get()->descriptorSize();
}
CVAPI(int) features2d_Feature2D_descriptorType(cv::Ptr<cv::Feature2D> *obj)
{
	return obj->get()->descriptorType();
}
CVAPI(int) features2d_Feature2D_defaultNorm(cv::Ptr<cv::Feature2D> *obj)
{
	return obj->get()->defaultNorm();
}
CVAPI(int) features2d_Feature2D_empty(cv::Ptr<cv::Feature2D> *obj)
{
	return obj->get()->empty() ? 1 : 0;
}

#pragma endregion

#pragma region BRISK

CVAPI(cv::Ptr<cv::BRISK>*) features2d_BRISK_create1(int thresh, int octaves, float patternScale)
{
	cv::Ptr<cv::BRISK> ptr = cv::BRISK::create(thresh, octaves, patternScale);
	return new cv::Ptr<cv::BRISK>(ptr);
}
CVAPI(cv::Ptr<cv::BRISK>*) features2d_BRISK_create2(
	float *radiusList, int radiusListLength, int *numberList, int numberListLength,
	float dMax, float dMin, 
	int *indexChange, int indexChangeLength)
{
	std::vector<float> radiusListVec(radiusList, radiusList + radiusListLength);
	std::vector<int> numberListVec(numberList, numberList + numberListLength);
	std::vector<int> indexChangeVec;
	if (indexChange == NULL)
		indexChangeVec = std::vector<int>(indexChange, indexChange + indexChangeLength);
	else
		indexChangeVec = std::vector<int>();

	cv::Ptr<cv::BRISK> ptr = cv::BRISK::create(radiusListVec, numberListVec, dMax, dMin, indexChangeVec);
	return new cv::Ptr<cv::BRISK>(ptr);
}

CVAPI(void) features2d_Ptr_BRISK_delete(cv::Ptr<cv::BRISK> *ptr)
{
	delete ptr;
}

CVAPI(cv::AlgorithmInfo*) features2d_BRISK_info(cv::BRISK *obj)
{
	return obj->info();
}

CVAPI(cv::BRISK*) features2d_Ptr_BRISK_get(cv::Ptr<cv::BRISK> *ptr)
{
    return ptr->get();
}

#pragma endregion

#pragma region ORB

CVAPI(cv::Ptr<cv::ORB>*) features2d_ORB_new(
	int nFeatures, float scaleFactor, int nlevels, int edgeThreshold,
	int firstLevel, int wtaK, int scoreType, int patchSize)
{
	cv::Ptr<cv::ORB> ptr = cv::ORB::create(nFeatures, scaleFactor, nlevels, edgeThreshold,
		firstLevel, wtaK, scoreType, patchSize);
	return new cv::Ptr<cv::ORB>(ptr);
}
CVAPI(void) features2d_Ptr_ORB_delete(cv::Ptr<cv::ORB> *ptr)
{
	delete ptr;
}

CVAPI(cv::ORB*) features2d_Ptr_ORB_get(cv::Ptr<cv::ORB> *ptr)
{
	return ptr->get();
}
CVAPI(cv::AlgorithmInfo*) features2d_ORB_info(cv::ORB *obj)
{
	return obj->info();
}


#pragma endregion

#pragma region MSER
CVAPI(cv::Ptr<cv::MSER>*) features2d_MSER_create(int delta, int minArea, int maxArea,
          double maxVariation, double minDiversity, int maxEvolution, 
		  double areaThreshold, double minMargin, int edgeBlurSize )
{
	cv::Ptr<cv::MSER> ptr = cv::MSER::create(delta, minArea, maxArea, maxVariation, minDiversity, maxEvolution,
		areaThreshold, minMargin, edgeBlurSize);
	return new cv::Ptr<cv::MSER>(ptr);
}
CVAPI(void) features2d_Ptr_MSER_delete(cv::Ptr<cv::MSER> *ptr)
{
	delete ptr;
}

CVAPI(void) features2d_MSER_detectRegions(
	cv::MSER *obj, cv::_InputArray *image,
	std::vector<std::vector<cv::Point> > *msers, 
	std::vector<cv::Rect> *bboxes)
{
	obj->detectRegions(*image, *msers, *bboxes);
}
CVAPI(cv::AlgorithmInfo*) features2d_MSER_info(cv::MSER *obj)
{
	return obj->info();
}

CVAPI(cv::MSER*) features2d_Ptr_MSER_get(cv::Ptr<cv::MSER> *ptr)
{
    return ptr->get();
}

CVAPI(void) features2d_MSER_setDelta(cv::MSER *obj, int delta)
{
	obj->setDelta(delta);
}
CVAPI(int) features2d_MSER_getDelta(cv::MSER *obj)
{
	return obj->getDelta();
}

CVAPI(void) features2d_MSER_setMinArea(cv::MSER *obj, int minArea)
{
	obj->setMinArea(minArea);
}
CVAPI(int) features2d_MSER_getMinArea(cv::MSER *obj)
{
	return obj->getMinArea();
}

CVAPI(void) features2d_MSER_setMaxArea(cv::MSER *obj, int maxArea)
{
	obj->setMaxArea(maxArea);
}
CVAPI(int) features2d_MSER_getMaxArea(cv::MSER *obj)
{
	return obj->getMaxArea();
}

CVAPI(void) features2d_MSER_setPass2Only(cv::MSER *obj, int f)
{
	obj->setPass2Only(f != 0);
}
CVAPI(int) features2d_MSER_getPass2Only(cv::MSER *obj)
{
	return obj->getPass2Only() ? 1 : 0;
}

#pragma endregion

#pragma region FastFeatureDetector
CVAPI(cv::Ptr<cv::FastFeatureDetector>*) features2d_FastFeatureDetector_create(
	int threshold, int nonmaxSuppression)
{
	cv::Ptr<cv::FastFeatureDetector> ptr = cv::FastFeatureDetector::create(threshold, nonmaxSuppression != 0);
	return new cv::Ptr<cv::FastFeatureDetector>(ptr);
}
CVAPI(void) features2d_Ptr_FastFeatureDetector_delete(cv::Ptr<cv::FastFeatureDetector> *ptr)
{
	delete ptr;
}

CVAPI(cv::AlgorithmInfo*) features2d_FastFeatureDetector_info(cv::FastFeatureDetector *obj)
{
	return obj->info();
}

CVAPI(cv::FastFeatureDetector*) features2d_Ptr_FastFeatureDetector_get(cv::Ptr<cv::FastFeatureDetector> *ptr)
{
    return ptr->get();
}

CVAPI(void) features2d_FastFeatureDetector_setThreshold(cv::FastFeatureDetector *obj, int threshold)
{
	obj->setThreshold(threshold);
}
CVAPI(int) features2d_FastFeatureDetector_getThreshold(cv::FastFeatureDetector *obj)
{
	return obj->getThreshold();
}

CVAPI(void) features2d_FastFeatureDetector_setNonmaxSuppression(cv::FastFeatureDetector *obj, int f)
{
	obj->setNonmaxSuppression(f != 0);
}
CVAPI(int) features2d_FastFeatureDetector_getNonmaxSuppression(cv::FastFeatureDetector *obj)
{
	return obj->getNonmaxSuppression() ? 1 : 0;
}

CVAPI(void) features2d_FastFeatureDetector_setType(cv::FastFeatureDetector *obj, int type)
{
	obj->setType(type);
}
CVAPI(int) features2d_FastFeatureDetector_getType(cv::FastFeatureDetector *obj)
{
	return obj->getType();
}

#pragma endregion

#pragma region GFTTDetector

CVAPI(cv::Ptr<cv::GFTTDetector>*) features2d_GFTTDetector_create(
	int maxCorners, double qualityLevel, double minDistance,
	int blockSize, int useHarrisDetector, double k)
{
	cv::Ptr<cv::GFTTDetector> ptr = cv::GFTTDetector::create(
		maxCorners, qualityLevel, minDistance,
		blockSize, useHarrisDetector != 0, k);
	return new cv::Ptr<cv::GFTTDetector>(ptr);
}
CVAPI(void) features2d_Ptr_GFTTDetector_delete(cv::Ptr<cv::GFTTDetector> *ptr)
{
	delete ptr;
}

CVAPI(cv::AlgorithmInfo*) features2d_GFTTDetector_info(cv::GFTTDetector *obj)
{
	return obj->info();
}
CVAPI(cv::GFTTDetector*) features2d_Ptr_GFTTDetector_get(cv::Ptr<cv::GFTTDetector> *ptr)
{
    return ptr->get();
}

CVAPI(void) features2d_GFTTDetector_setMaxFeatures(cv::GFTTDetector *obj, int maxFeatures)
{
	obj->setMaxFeatures(maxFeatures);
}
CVAPI(int) features2d_GFTTDetector_getMaxFeatures(cv::GFTTDetector *obj)
{
	return obj->getMaxFeatures();
}

CVAPI(void) features2d_GFTTDetector_setQualityLevel(cv::GFTTDetector *obj, double qlevel)
{
	obj->setQualityLevel(qlevel);
}
CVAPI(double) features2d_GFTTDetector_getQualityLevel(cv::GFTTDetector *obj)
{
	return obj->getQualityLevel();
}

CVAPI(void) features2d_GFTTDetector_setMinDistance(cv::GFTTDetector *obj, double minDistance)
{
	obj->setMinDistance(minDistance);
}
CVAPI(double) features2d_GFTTDetector_getMinDistance(cv::GFTTDetector *obj)
{
	return obj->getMinDistance();
}

CVAPI(void) features2d_GFTTDetector_setBlockSize(cv::GFTTDetector *obj, int blockSize)
{
	obj->setBlockSize(blockSize);
}
CVAPI(int) features2d_GFTTDetector_getBlockSize(cv::GFTTDetector *obj)
{
	return obj->getBlockSize();
}

CVAPI(void) features2d_GFTTDetector_setHarrisDetector(cv::GFTTDetector *obj, int val)
{
	obj->setHarrisDetector(val != 0);
}
CVAPI(int) features2d_GFTTDetector_getHarrisDetector(cv::GFTTDetector *obj)
{
	return obj->getHarrisDetector() ? 1 : 0;
}

CVAPI(void) features2d_GFTTDetector_setK(cv::GFTTDetector *obj, double k)
{
	obj->setK(k);
}
CVAPI(double) features2d_GFTTDetector_getK(cv::GFTTDetector *obj)
{
	return obj->getK();
}

#pragma endregion

#pragma region SimpleBlobDetector

struct SimpleBlobDetector_Params
{
	float thresholdStep;
	float minThreshold;
	float maxThreshold;
	uint32 minRepeatability; // size_t
	float minDistBetweenBlobs;

	int filterByColor;
	uchar blobColor;

	int filterByArea;
	float minArea, maxArea;

	int filterByCircularity;
	float minCircularity, maxCircularity;

	int filterByInertia;
	float minInertiaRatio, maxInertiaRatio;

	int filterByConvexity;
	float minConvexity, maxConvexity;
};

CVAPI(cv::Ptr<cv::SimpleBlobDetector>*) features2d_SimpleBlobDetector_create(
	SimpleBlobDetector_Params *p)
{
	cv::SimpleBlobDetector::Params p2;
	if (p != NULL)
	{
		p2.thresholdStep = p->thresholdStep;
		p2.minThreshold = p->minThreshold;
		p2.maxThreshold = p->maxThreshold;
		p2.minRepeatability = (size_t)p->minRepeatability;
		p2.minDistBetweenBlobs = p->minDistBetweenBlobs;
		p2.filterByColor = p->filterByColor != 0;
		p2.blobColor = p->blobColor;
		p2.filterByArea = p->filterByArea != 0;
		p2.minArea = p->minArea;
		p2.maxArea = p->maxArea;
		p2.filterByCircularity = p->filterByCircularity != 0;
		p2.minCircularity = p->minCircularity;
		p2.maxCircularity = p->maxCircularity;
		p2.filterByInertia = p->filterByInertia != 0;
		p2.minInertiaRatio = p->minInertiaRatio;
		p2.maxInertiaRatio = p->maxInertiaRatio;
		p2.filterByConvexity = p->filterByConvexity != 0;
		p2.minConvexity = p->minConvexity;
		p2.maxConvexity = p->maxConvexity;
	}
	cv::Ptr<cv::SimpleBlobDetector> ptr = cv::SimpleBlobDetector::create(p2);
	return new cv::Ptr<cv::SimpleBlobDetector>(ptr);
}
CVAPI(void) features2d_Ptr_SimpleBlobDetector_delete(cv::Ptr<cv::SimpleBlobDetector> *ptr)
{
	delete ptr;
}

CVAPI(cv::SimpleBlobDetector*) features2d_Ptr_SimpleBlobDetector_get(cv::Ptr<cv::SimpleBlobDetector> *ptr)
{
    return ptr->get();
}

#pragma endregion

/*
#pragma region DenseFeatureDetector

CVAPI(cv::DenseFeatureDetector*) features2d_DenseFeatureDetector_new(
	float initFeatureScale, int featureScaleLevels, float featureScaleMul,
    int initXyStep, int initImgBound, int varyXyStepWithScale, int varyImgBoundWithScale)
{
	return new cv::DenseFeatureDetector(initFeatureScale, featureScaleLevels, 
		featureScaleMul, initXyStep, initImgBound, varyXyStepWithScale != 0, varyImgBoundWithScale != 0);
}
CVAPI(void) features2d_DenseFeatureDetector_delete(cv::DenseFeatureDetector *obj)
{
	delete obj;
}
CVAPI(cv::AlgorithmInfo*) features2d_DenseFeatureDetector_info(cv::DenseFeatureDetector *obj)
{
	return obj->info();
}

CVAPI(cv::DenseFeatureDetector*) features2d_Ptr_DenseFeatureDetector_get(cv::Ptr<cv::DenseFeatureDetector> *ptr)
{
    return ptr->get();
}
CVAPI(void) features2d_Ptr_DenseFeatureDetector_delete(cv::Ptr<cv::DenseFeatureDetector> *ptr)
{
    delete ptr;
}

#pragma endregion
*/
#endif