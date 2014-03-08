/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_FEATURES2D_H_
#define _CPP_FEATURES2D_H_

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
	cv::Ptr<cv::FeatureDetector> ret = cv::FeatureDetector::create(detectorType);
	return new cv::Ptr<cv::FeatureDetector>(ret);
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
	cv::Ptr<cv::Feature2D> ret = cv::Feature2D::create(name);
	return new cv::Ptr<cv::Feature2D>(ret);
}
#pragma endregion

#pragma region MSER
CVAPI(cv::MSER*) features2d_MSER_new(int delta, int min_area, int max_area,
          double max_variation, double min_diversity, int max_evolution, 
		  double area_threshold, double min_margin, int edge_blur_size )
{
	return new cv::MSER(delta, min_area, max_area);
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
#pragma endregion

CVAPI(void) features2d_FAST(cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, int threshold, int nonmaxSupression)
{
	cv::FAST(*image, *keypoints, threshold, nonmaxSupression != 0);
}

CVAPI(void) features2d_FASTX(cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, int threshold, int nonmaxSupression, int type)
{
	cv::FASTX(*image, *keypoints, threshold, nonmaxSupression != 0, type);
}

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
#pragma endregion


CVAPI(void) features2d_drawKeypoints(cv::Mat* image, cv::KeyPoint *keypoints, int keypointsLength,
	cv::Mat *outImage, CvScalar color, int flags)
{
	std::vector<cv::KeyPoint> keypointsVec(keypoints, keypoints + keypointsLength);
	cv::drawKeypoints(*image, keypointsVec, *outImage, color, flags);
}


CVAPI(void) features2d_drawMatches1(cv::Mat *img1, cv::KeyPoint *keypoints1, int keypoints1Length,
	cv::Mat *img2, cv::KeyPoint *keypoints2, int keypoints2Length,
	cv::DMatch *matches1to2, int matches1to2Length, cv::Mat *outImg,
	CvScalar matchColor, CvScalar singlePointColor,
	char *matchesMask, int matchesMaskLength, int flags)
{
	std::vector<cv::KeyPoint> keypoints1Vec(keypoints1, keypoints1 + keypoints1Length);
	std::vector<cv::KeyPoint> keypoints2Vec(keypoints2, keypoints2 + keypoints2Length);
	std::vector<cv::DMatch> matches1to2Vec(matches1to2, matches1to2 + matches1to2Length);
	std::vector<char> matchesMaskVec;
	if (matchesMask != NULL)
		matchesMaskVec = std::vector<char>(matchesMask, matchesMask + matchesMaskLength);
	cv::drawMatches(*img1, keypoints1Vec, *img2, keypoints2Vec, matches1to2Vec, *outImg,
		matchColor, singlePointColor, matchesMaskVec, flags);
}

CVAPI(void) features2d_drawMatches2(cv::Mat *img1, cv::KeyPoint *keypoints1, int keypoints1Length,
	cv::Mat *img2, cv::KeyPoint *keypoints2, int keypoints2Length,
	cv::DMatch **matches1to2, int matches1to2Size1, int *matches1to2Size2,
	cv::Mat *outImg, CvScalar matchColor, CvScalar singlePointColor,
	char **matchesMask, int matchesMaskSize1, int *matchesMaskSize2, int flags)
{
	std::vector<cv::KeyPoint> keypoints1Vec(keypoints1, keypoints1 + keypoints1Length);
	std::vector<cv::KeyPoint> keypoints2Vec(keypoints2, keypoints2 + keypoints2Length);
	std::vector<std::vector<cv::DMatch> > matches1to2Vec(matches1to2Size1);
	for (int i = 0; i < matches1to2Size1; i++)
	{
		cv::DMatch *p = matches1to2[i];
		matches1to2Vec[i] = std::vector<cv::DMatch>(p, p + matches1to2Size2[i]);
	}

	std::vector<std::vector<char> > matchesMaskVec;
	if (matchesMask != NULL)
	{
		matchesMaskVec = std::vector<std::vector<char> >(matchesMaskSize1);
		for (int i = 0; i < matchesMaskSize1; i++)
		{
			char *p = matchesMask[i];
			matchesMaskVec[i] = std::vector<char>(p, p + matchesMaskSize2[i]);
		}
	}

	cv::drawMatches(*img1, keypoints1Vec, *img2, keypoints2Vec, matches1to2Vec,
		*outImg, matchColor, singlePointColor, matchesMaskVec, flags);
}

#endif