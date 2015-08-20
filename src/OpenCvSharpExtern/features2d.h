#ifndef _CPP_FEATURES2D_H_
#define _CPP_FEATURES2D_H_

#include "include_opencv.h"


CVAPI(void) features2d_FAST(cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, int threshold, int nonmaxSupression)
{
	cv::FAST(*image, *keypoints, threshold, nonmaxSupression != 0);
}

CVAPI(void) features2d_FASTX(cv::_InputArray *image, std::vector<cv::KeyPoint> *keypoints, int threshold, int nonmaxSupression, int type)
{
	cv::FASTX(*image, *keypoints, threshold, nonmaxSupression != 0, type);
}


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