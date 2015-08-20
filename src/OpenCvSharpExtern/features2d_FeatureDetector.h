#ifndef _CPP_FEATURES2DFEATUREDETECTOR_H_
#define _CPP_FEATURES2DFEATUREDETECTOR_H_

#include "include_opencv.h"

#pragma region FeatureDetector

CVAPI(void) features2d_FeatureDetector_detect1(cv::FeatureDetector *detector, cv::Mat *image, std::vector<cv::KeyPoint> *keypoints, cv::Mat *mask)
{
	detector->detect(*image, *keypoints, entity(mask));
}

CVAPI(void) features2d_FeatureDetector_detect2(cv::FeatureDetector *detector, cv::Mat **images, int imageLength, std::vector<std::vector<cv::KeyPoint> > *keypoints, cv::Mat **mask)
{
	std::vector<cv::Mat> imageVec(imageLength);
	std::vector<cv::Mat> maskVec;
	{
		for (int i = 0; i < imageLength; i++)
			imageVec.push_back(*images[i]);		
	}
	if (mask != NULL)
	{
		maskVec.reserve(imageLength);
		for (int i = 0; i < imageLength; i++)
			maskVec.push_back(*mask[i]);
	}

	detector->detect(imageVec, *keypoints, maskVec);
}

CVAPI(int) features2d_FeatureDetector_empty(cv::FeatureDetector *detector)
{
	return detector->empty();
}

CVAPI(cv::Ptr<cv::FeatureDetector>*) features2d_FeatureDetector_create(const char *detectorType)
{
	return clone( cv::FeatureDetector::create(detectorType) );
}

CVAPI(cv::FeatureDetector*) features2d_Ptr_FeatureDetector_obj(cv::Ptr<cv::FeatureDetector>* ptr)
{
	return ptr->obj;
}
CVAPI(void) features2d_Ptr_FeatureDetector_delete(cv::Ptr<cv::FeatureDetector>* ptr)
{
	delete ptr;
}

CVAPI(cv::AlgorithmInfo*) features2d_FeatureDetector_info(cv::FeatureDetector *obj)
{
	return obj->info();
}

#pragma endregion

#pragma region Feature2D
CVAPI(void) features2d_Feature2D_compute(cv::Feature2D *obj,
	cv::Mat *image, std::vector<cv::KeyPoint> *keypoints, cv::Mat *descriptors)
{
	obj->compute(*image, *keypoints, *descriptors);
}

CVAPI(cv::Ptr<cv::Feature2D>*) features2d_Feature2D_create(const char *name)
{
	return clone( cv::Feature2D::create(name) );
}

CVAPI(cv::Feature2D*) features2d_Ptr_Feature2D_obj(cv::Ptr<cv::Feature2D>* ptr)
{
	return ptr->obj;
}
CVAPI(void) features2d_Ptr_Feature2D_delete(cv::Ptr<cv::Feature2D>* ptr)
{
	delete ptr;
}

#pragma endregion

#pragma region BRISK

CVAPI(cv::BRISK*) features2d_BRISK_new(int thresh, int octaves, float patternScale)
{
	return new cv::BRISK(thresh, octaves, patternScale);
}
CVAPI(void) features2d_BRISK_delete(cv::BRISK *obj)
{
	delete obj;
}

CVAPI(int) features2d_BRISK_descriptorSize(cv::BRISK *obj)
{
	return obj->descriptorSize();
}
CVAPI(int) features2d_BRISK_descriptorType(cv::BRISK *obj)
{
	return obj->descriptorType();
}

CVAPI(void) features2d_BRISK_run1(cv::BRISK *obj, cv::_InputArray *image, cv::_InputArray *mask, 
	std::vector<cv::KeyPoint> *keypoints)
{
	(*obj)(*image, entity(mask), *keypoints);
}
CVAPI(void) features2d_BRISK_run2(cv::BRISK *obj, cv::_InputArray *image, cv::_InputArray *mask, 
	std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors, int useProvidedKeypoints)
{
	(*obj)(*image, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}

CVAPI(cv::AlgorithmInfo*) features2d_BRISK_info(cv::BRISK *obj)
{
	return obj->info();
}

CVAPI(cv::BRISK*) features2d_Ptr_BRISK_obj(cv::Ptr<cv::BRISK> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_BRISK_delete(cv::Ptr<cv::BRISK> *ptr)
{
    delete ptr;
}
#pragma endregion

#pragma region ORB

CVAPI(cv::ORB*) features2d_ORB_new(int nFeatures, float scaleFactor, int nlevels, int edgeThreshold,
	int firstLevel, int wtaK, int scoreType, int patchSize)
{
	return new cv::ORB(nFeatures, scaleFactor, nlevels, edgeThreshold,
		firstLevel, wtaK, scoreType, patchSize);
}
CVAPI(void) features2d_ORB_delete(cv::ORB *obj)
{
	delete obj;
}

CVAPI(int) features2d_ORB_descriptorSize(cv::ORB *obj)
{
	return obj->descriptorSize();
}
CVAPI(int) features2d_ORB_descriptorType(cv::ORB *obj)
{
	return obj->descriptorType();
}

CVAPI(void) features2d_ORB_run1(cv::ORB *obj, cv::_InputArray *image, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints)
{
	(*obj)(*image, entity(mask), *keypoints);
}
CVAPI(void) features2d_ORB_run2(cv::ORB *obj, cv::_InputArray *image, cv::_InputArray *mask,
	std::vector<cv::KeyPoint> *keypoints, cv::_OutputArray *descriptors, int useProvidedKeypoints)
{
	(*obj)(*image, entity(mask), *keypoints, *descriptors, useProvidedKeypoints != 0);
}

CVAPI(cv::AlgorithmInfo*) features2d_ORB_info(cv::ORB *obj)
{
	return obj->info();
}

CVAPI(cv::ORB*) features2d_Ptr_ORB_obj(cv::Ptr<cv::ORB> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_ORB_delete(cv::Ptr<cv::ORB> *ptr)
{
    delete ptr;
}
#pragma endregion

#pragma region FREAK
CVAPI(cv::FREAK*) features2d_FREAK_new(int orientationNormalized,
	int scaleNormalized, float patternScale, int nOctaves,
	int *selectedPairs, int selectedPairsLength)
{
	std::vector<int> selectedPairsVec;
	if (selectedPairs != NULL)
		selectedPairsVec = std::vector<int>(selectedPairs, selectedPairs + selectedPairsLength);
	return new cv::FREAK(orientationNormalized != 0, scaleNormalized != 0,
		patternScale, nOctaves, selectedPairsVec);
}
CVAPI(void) features2d_FREAK_delete(cv::FREAK *obj)
{
	delete obj;
}
CVAPI(int) features2d_FREAK_descriptorSize(cv::FREAK *obj)
{
	return obj->descriptorSize();
}
CVAPI(int) features2d_FREAK_descriptorType(cv::FREAK *obj)
{
	return obj->descriptorType();
}

CVAPI(void) features2d_FREAK_selectPairs(cv::FREAK *obj, cv::Mat **images, int imagesLength,
	std::vector<std::vector<cv::KeyPoint> > *keypoints,
	double corrThresh, int verbose, std::vector<int> *out)
{
	std::vector<cv::Mat> imagesVec(imagesLength);
	for (int i = 0; i < imagesLength; i++)	
		imagesVec[i] = *(images[i]);	
	
	std::vector<int> ret = obj->selectPairs(imagesVec, *keypoints, corrThresh, verbose != 0);
	std::copy(ret.begin(), ret.end(), out->begin());
}

CVAPI(cv::AlgorithmInfo*) features2d_FREAK_info(cv::FREAK *obj)
{
	return obj->info();
}

CVAPI(cv::FREAK*) features2d_Ptr_FREAK_obj(cv::Ptr<cv::FREAK> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_FREAK_delete(cv::Ptr<cv::FREAK> *ptr)
{
    delete ptr;
}

#pragma endregion

#pragma region MSER
CVAPI(cv::MSER*) features2d_MSER_new(int delta, int minArea, int maxArea,
          double maxVariation, double minDiversity, int maxEvolution, 
		  double areaThreshold, double minMargin, int edgeBlurSize )
{
	return new cv::MSER(delta, minArea, maxArea, maxVariation, minDiversity, maxEvolution, 
		areaThreshold, minMargin, edgeBlurSize);
}
CVAPI(void) features2d_MSER_delete(cv::MSER *obj)
{
	delete obj;
}
CVAPI(void) features2d_MSER_detect(cv::MSER *obj, cv::Mat *image, 
								   std::vector<std::vector<cv::Point> > **msers, cv::Mat *mask )
{
	*msers = new std::vector<std::vector<cv::Point> >;
	(*obj)(*image, **msers, entity(mask));
}
CVAPI(cv::AlgorithmInfo*) features2d_MSER_info(cv::MSER *obj)
{
	return obj->info();
}

CVAPI(cv::MSER*) features2d_Ptr_MSER_obj(cv::Ptr<cv::MSER> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_MSER_delete(cv::Ptr<cv::MSER> *ptr)
{
    delete ptr;
}
#pragma endregion

#pragma region StarDetector
CVAPI(cv::StarDetector*) features2d_StarDetector_new(int maxSize, int responseThreshold,
	int lineThresholdProjected,	int lineThresholdBinarized,	int suppressNonmaxSize)
{
	return new cv::StarDetector(maxSize, responseThreshold, lineThresholdProjected, lineThresholdBinarized, suppressNonmaxSize);
}
CVAPI(void) features2d_StarDetector_delete(cv::StarDetector *obj)
{
	delete obj;
}
CVAPI(void) features2d_StarDetector_detect(cv::StarDetector *obj, cv::Mat *image,
	std::vector<cv::KeyPoint> **keypoints)
{
	*keypoints = new std::vector<cv::KeyPoint>;
	(*obj)(*image, **keypoints);
}
CVAPI(cv::AlgorithmInfo*) features2d_StarDetector_info(cv::StarDetector *obj)
{
	return obj->info();
}

CVAPI(cv::StarDetector*) features2d_Ptr_StarDetector_obj(cv::Ptr<cv::StarDetector> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_StarDetector_delete(cv::Ptr<cv::StarDetector> *ptr)
{
    delete ptr;
}
#pragma endregion

#pragma region FastFeatureDetector
CVAPI(cv::FastFeatureDetector*) features2d_FastFeatureDetector_new(int threshold, int nonmaxSuppression)
{
	return new cv::FastFeatureDetector(threshold, nonmaxSuppression != 0);
}
CVAPI(void) features2d_FastFeatureDetector_delete(cv::FastFeatureDetector *obj)
{
	delete obj;
}
CVAPI(cv::AlgorithmInfo*) features2d_FastFeatureDetector_info(cv::FastFeatureDetector *obj)
{
	return obj->info();
}

CVAPI(cv::FastFeatureDetector*) features2d_Ptr_FastFeatureDetector_obj(cv::Ptr<cv::FastFeatureDetector> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_FastFeatureDetector_delete(cv::Ptr<cv::FastFeatureDetector> *ptr)
{
    delete ptr;
}
#pragma endregion

#pragma region GFTTDetector
CVAPI(cv::GFTTDetector*) features2d_GFTTDetector_new(int maxCorners, double qualityLevel, double minDistance,
	int blockSize, int useHarrisDetector, double k)
{
	return new cv::GFTTDetector(maxCorners, qualityLevel, minDistance,
		blockSize, useHarrisDetector != 0, k);
}
CVAPI(void) features2d_GFTTDetector_delete(cv::GFTTDetector *obj)
{
	delete obj;
}
CVAPI(cv::AlgorithmInfo*) features2d_GFTTDetector_info(cv::GFTTDetector *obj)
{
	return obj->info();
}

CVAPI(cv::GFTTDetector*) features2d_Ptr_GFTTDetector_obj(cv::Ptr<cv::GFTTDetector> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_GFTTDetector_delete(cv::Ptr<cv::GFTTDetector> *ptr)
{
    delete ptr;
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

CVAPI(cv::SimpleBlobDetector*) features2d_SimpleBlobDetector_new(
	SimpleBlobDetector_Params *p)
{
	cv::SimpleBlobDetector::Params p2;
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
	return new cv::SimpleBlobDetector(p2);
}
CVAPI(void) features2d_SimpleBlobDetector_delete(cv::SimpleBlobDetector* obj)
{
	delete obj;
}

CVAPI(cv::SimpleBlobDetector*) features2d_Ptr_SimpleBlobDetector_obj(cv::Ptr<cv::SimpleBlobDetector> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_SimpleBlobDetector_delete(cv::Ptr<cv::SimpleBlobDetector> *ptr)
{
    delete ptr;
}
#pragma endregion

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

CVAPI(cv::DenseFeatureDetector*) features2d_Ptr_DenseFeatureDetector_obj(cv::Ptr<cv::DenseFeatureDetector> *ptr)
{
    return ptr->obj;
}
CVAPI(void) features2d_Ptr_DenseFeatureDetector_delete(cv::Ptr<cv::DenseFeatureDetector> *ptr)
{
    delete ptr;
}

#pragma endregion

#endif