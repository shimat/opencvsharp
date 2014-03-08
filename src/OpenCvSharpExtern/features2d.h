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

CVAPI(void) features2d_FeatureDetector_detect2(cv::FeatureDetector *detector, cv::Mat **images, int imageLength, std::vector<std::vector<cv::KeyPoint>> *keypoints, cv::Mat **mask)
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


#endif