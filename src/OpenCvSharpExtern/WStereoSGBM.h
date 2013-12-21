/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WSTEREOSGBM_H_
#define _CPP_WSTEREOSGBM_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/opencv.hpp>

CVAPI(int) StereoSGBM_sizeof()
{
	return sizeof(cv::StereoSGBM);
}


CVAPI(void) StereoSGBM_delete(cv::StereoSGBM* obj)
{
	delete obj;
}
CVAPI(cv::StereoSGBM*) StereoSGBM_new1()
{
	return new cv::StereoSGBM();
}
CVAPI(cv::StereoSGBM*) StereoSGBM_new2(int minDisparity, int numDisparities, int SADWindowSize, int P1, int P2, int disp12MaxDiff, int preFilterCap, int uniquenessRatio, int speckleWindowSize, int speckleRange, bool fullDP)
{
	return new cv::StereoSGBM(minDisparity, numDisparities, SADWindowSize, P1, P2, disp12MaxDiff, preFilterCap, uniquenessRatio, speckleWindowSize, speckleRange, fullDP);
}

CVAPI(void) StereoSGBM_exec(cv::StereoSGBM* obj, cv::Mat* left, cv::Mat* right, cv::Mat* disp)
{
	(*obj)(*left, *right, *disp);
}


CVAPI(int) StereoSGBM_minDisparity_get(const cv::StereoSGBM* obj)
{
	return obj->minDisparity;
}
CVAPI(void) StereoSGBM_minDisparity_set(cv::StereoSGBM* obj, int value)
{
	obj->minDisparity = value;
}
CVAPI(int) StereoSGBM_numberOfDisparities_get(const cv::StereoSGBM* obj)
{
	return obj->numberOfDisparities;
}
CVAPI(void) StereoSGBM_numberOfDisparities_set(cv::StereoSGBM* obj, int value)
{
	obj->numberOfDisparities = value;
}
CVAPI(int) StereoSGBM_SADWindowSize_get(const cv::StereoSGBM* obj)
{
	return obj->SADWindowSize;
}
CVAPI(void) StereoSGBM_SADWindowSize_set(cv::StereoSGBM* obj, int value)
{
	obj->SADWindowSize = value;
}
CVAPI(int) StereoSGBM_preFilterCap_get(const cv::StereoSGBM* obj)
{
	return obj->preFilterCap;
}
CVAPI(void) StereoSGBM_preFilterCap_set(cv::StereoSGBM* obj, int value)
{
	obj->preFilterCap = value;
}
CVAPI(int) StereoSGBM_uniquenessRatio_get(const cv::StereoSGBM* obj)
{
	return obj->uniquenessRatio;
}
CVAPI(void) StereoSGBM_uniquenessRatio_set(cv::StereoSGBM* obj, int value)
{
	obj->uniquenessRatio = value;
}
CVAPI(int) StereoSGBM_P1_get(const cv::StereoSGBM* obj)
{
	return obj->P1;
}
CVAPI(void) StereoSGBM_P1_set(cv::StereoSGBM* obj, int value)
{
	obj->P1 = value;
}
CVAPI(int) StereoSGBM_P2_get(const cv::StereoSGBM* obj)
{
	return obj->P2;
}
CVAPI(void) StereoSGBM_P2_set(cv::StereoSGBM* obj, int value)
{
	obj->P2 = value;
}
CVAPI(int) StereoSGBM_speckleWindowSize_get(const cv::StereoSGBM* obj)
{
	return obj->speckleWindowSize;
}
CVAPI(void) StereoSGBM_speckleWindowSize_set(cv::StereoSGBM* obj, int value)
{
	obj->speckleWindowSize = value;
}
CVAPI(int) StereoSGBM_speckleRange_get(const cv::StereoSGBM* obj)
{
	return obj->speckleRange;
}
CVAPI(void) StereoSGBM_speckleRange_set(cv::StereoSGBM* obj, int value)
{
	obj->speckleRange = value;
}
CVAPI(int) StereoSGBM_disp12MaxDiff_get(const cv::StereoSGBM* obj)
{
	return obj->disp12MaxDiff;
}
CVAPI(void) StereoSGBM_disp12MaxDiff_set(cv::StereoSGBM* obj, int value)
{
	obj->disp12MaxDiff = value;
}
CVAPI(int) StereoSGBM_fullDP_get(const cv::StereoSGBM* obj)
{
	return obj->fullDP ? 1 : 0;
}
CVAPI(void) StereoSGBM_fullDP_set(cv::StereoSGBM* obj, int value)
{
	obj->fullDP = (value != 0);
}

#endif