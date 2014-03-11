/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CALIB3D_H_
#define _CPP_CALIB3D_H_

#include "include_opencv.h"


CVAPI(void) imgproc_solvePnP(cv::_InputArray* objectPoints, cv::_InputArray* imagePoints, cv::_InputArray* cameraMatrix, cv::_InputArray* distCoeffs,
	cv::_OutputArray* rvec, cv::_OutputArray* tvec, int useExtrinsicGuess)
{
	cv::solvePnP(*objectPoints, *imagePoints, *cameraMatrix, entity(distCoeffs), *rvec, *tvec, useExtrinsicGuess != 0);
}


#pragma region StereoBM

CVAPI(cv::StereoBM*) calib3d_StereoBM_new1()
{
	return new cv::StereoBM();
}
CVAPI(cv::StereoBM*) calib3d_StereoBM_new2(int preset, int ndisparities, int SADWindowSize)
{
	return new cv::StereoBM(preset, ndisparities, SADWindowSize);
}
CVAPI(void) calib3d_StereoBM_init(cv::StereoBM *obj, int preset, int ndisparities, int SADWindowSize)
{
	obj->init(preset, ndisparities, SADWindowSize);
}
CVAPI(void) calib3d_StereoBM_delete(cv::StereoBM* obj)
{
	delete obj;
}

CVAPI(void) calib3d_StereoBM_compute(cv::StereoBM* obj, cv::_InputArray* left, cv::_InputArray* right, 
									 cv::_OutputArray* disp, int disptype)
{
	(*obj)(*left, *right, *disp, disptype);
}

#pragma endregion

#pragma region StereoSGBM

CVAPI(void) calib3d_StereoSGBM_delete(cv::StereoSGBM* obj)
{
	delete obj;
}
CVAPI(cv::StereoSGBM*) calib3d_StereoSGBM_new1()
{
	return new cv::StereoSGBM();
}
CVAPI(cv::StereoSGBM*) calib3d_StereoSGBM_new2(int minDisparity, int numDisparities, int SADWindowSize, int P1, int P2, int disp12MaxDiff, int preFilterCap, int uniquenessRatio, int speckleWindowSize, int speckleRange, bool fullDP)
{
	return new cv::StereoSGBM(minDisparity, numDisparities, SADWindowSize, P1, P2, disp12MaxDiff, preFilterCap, uniquenessRatio, speckleWindowSize, speckleRange, fullDP);
}

CVAPI(void) calib3d_StereoSGBM_compute(cv::StereoSGBM* obj, cv::_InputArray* left, cv::_InputArray* right, cv::_OutputArray* disp)
{
	(*obj)(*left, *right, *disp);
}


CVAPI(int) calib3d_StereoSGBM_minDisparity_get(const cv::StereoSGBM* obj)
{
	return obj->minDisparity;
}
CVAPI(void) calib3d_StereoSGBM_minDisparity_set(cv::StereoSGBM* obj, int value)
{
	obj->minDisparity = value;
}
CVAPI(int) calib3d_StereoSGBM_numberOfDisparities_get(const cv::StereoSGBM* obj)
{
	return obj->numberOfDisparities;
}
CVAPI(void) calib3d_StereoSGBM_numberOfDisparities_set(cv::StereoSGBM* obj, int value)
{
	obj->numberOfDisparities = value;
}
CVAPI(int) calib3d_StereoSGBM_SADWindowSize_get(const cv::StereoSGBM* obj)
{
	return obj->SADWindowSize;
}
CVAPI(void) calib3d_StereoSGBM_SADWindowSize_set(cv::StereoSGBM* obj, int value)
{
	obj->SADWindowSize = value;
}
CVAPI(int) calib3d_StereoSGBM_preFilterCap_get(const cv::StereoSGBM* obj)
{
	return obj->preFilterCap;
}
CVAPI(void) calib3d_StereoSGBM_preFilterCap_set(cv::StereoSGBM* obj, int value)
{
	obj->preFilterCap = value;
}
CVAPI(int) calib3d_StereoSGBM_uniquenessRatio_get(const cv::StereoSGBM* obj)
{
	return obj->uniquenessRatio;
}
CVAPI(void) calib3d_StereoSGBM_uniquenessRatio_set(cv::StereoSGBM* obj, int value)
{
	obj->uniquenessRatio = value;
}
CVAPI(int) calib3d_StereoSGBM_P1_get(const cv::StereoSGBM* obj)
{
	return obj->P1;
}
CVAPI(void) calib3d_StereoSGBM_P1_set(cv::StereoSGBM* obj, int value)
{
	obj->P1 = value;
}
CVAPI(int) calib3d_StereoSGBM_P2_get(const cv::StereoSGBM* obj)
{
	return obj->P2;
}
CVAPI(void) calib3d_StereoSGBM_P2_set(cv::StereoSGBM* obj, int value)
{
	obj->P2 = value;
}
CVAPI(int) calib3d_StereoSGBM_speckleWindowSize_get(const cv::StereoSGBM* obj)
{
	return obj->speckleWindowSize;
}
CVAPI(void) calib3d_StereoSGBM_speckleWindowSize_set(cv::StereoSGBM* obj, int value)
{
	obj->speckleWindowSize = value;
}
CVAPI(int) calib3d_StereoSGBM_speckleRange_get(const cv::StereoSGBM* obj)
{
	return obj->speckleRange;
}
CVAPI(void) calib3d_StereoSGBM_speckleRange_set(cv::StereoSGBM* obj, int value)
{
	obj->speckleRange = value;
}
CVAPI(int) calib3d_StereoSGBM_disp12MaxDiff_get(const cv::StereoSGBM* obj)
{
	return obj->disp12MaxDiff;
}
CVAPI(void) calib3d_StereoSGBM_disp12MaxDiff_set(cv::StereoSGBM* obj, int value)
{
	obj->disp12MaxDiff = value;
}
CVAPI(int) calib3d_StereoSGBM_fullDP_get(const cv::StereoSGBM* obj)
{
	return obj->fullDP ? 1 : 0;
}
CVAPI(void) calib3d_StereoSGBM_fullDP_set(cv::StereoSGBM* obj, int value)
{
	obj->fullDP = (value != 0);
}
#pragma endregion

#endif