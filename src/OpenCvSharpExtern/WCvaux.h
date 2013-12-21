/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WCVAUX_H_
#define _CPP_WCVAUX_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#pragma warning(disable: 4996)
#endif
#include <opencv2/features2d/features2d.hpp>


CVAPI(void) cv_FAST( cv::Mat* image, std::vector<cv::KeyPoint>* keypoints, int threshold, bool nonmax_supression )
{
	cv::FAST(*image, *keypoints, threshold, nonmax_supression);
}

#endif