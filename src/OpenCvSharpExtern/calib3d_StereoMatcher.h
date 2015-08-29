#ifndef _CPP_CALIB3D_STEREOMATCHER_H_
#define _CPP_CALIB3D_STEREOMATCHER_H_

#include "include_opencv.h"


#pragma region StereoMatcher

CVAPI(void) calib3d_StereoMatcher_compute(
	cv::Ptr<cv::StereoMatcher> *obj, cv::_InputArray *left, cv::_InputArray *right, cv::_OutputArray *disparity)
{
	(*obj)->compute(*left, *right, *disparity);
}

CVAPI(int) calib3d_StereoMatcher_getMinDisparity(cv::Ptr<cv::StereoMatcher> *obj)
{
	return (*obj)->getMinDisparity();
}
CVAPI(void) calib3d_StereoMatcher_setMinDisparity(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
	(*obj)->setMinDisparity(value);
}

CVAPI(int) calib3d_StereoMatcher_getNumDisparities(cv::Ptr<cv::StereoMatcher> *obj)
{
	return (*obj)->getNumDisparities();
}
CVAPI(void) calib3d_StereoMatcher_setNumDisparities(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
	(*obj)->setNumDisparities(value);
}

CVAPI(int) calib3d_StereoMatcher_getBlockSize(cv::Ptr<cv::StereoMatcher> *obj)
{
	return (*obj)->getBlockSize();
}
CVAPI(void) calib3d_StereoMatcher_setBlockSize(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
	(*obj)->setBlockSize(value);
}

CVAPI(int) calib3d_StereoMatcher_getSpeckleWindowSize(cv::Ptr<cv::StereoMatcher> *obj)
{
	return (*obj)->getSpeckleWindowSize();
}
CVAPI(void) calib3d_StereoMatcher_setSpeckleWindowSize(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
	(*obj)->setSpeckleWindowSize(value);
}

CVAPI(int) calib3d_StereoMatcher_getSpeckleRange(cv::Ptr<cv::StereoMatcher> *obj)
{
	return (*obj)->getSpeckleRange();
}
CVAPI(void) calib3d_StereoMatcher_setSpeckleRange(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
	(*obj)->setSpeckleRange(value);
}

CVAPI(int) calib3d_StereoMatcher_getDisp12MaxDiff(cv::Ptr<cv::StereoMatcher> *obj)
{
	return (*obj)->getDisp12MaxDiff();
}
CVAPI(void) calib3d_StereoMatcher_setDisp12MaxDiff(cv::Ptr<cv::StereoMatcher> *obj, int value)
{
	(*obj)->setDisp12MaxDiff(value);
}

#pragma endregion

#pragma region StereoBM

CVAPI(void) calib3d_Ptr_StereoBM_delete(cv::Ptr<cv::StereoBM> *obj)
{
	delete obj;
}

CVAPI(cv::Ptr<cv::StereoBM>*) calib3d_StereoBM_create(int numDisparities, int blockSize)
{
	cv::Ptr<cv::StereoBM> obj = cv::StereoBM::create(numDisparities, blockSize);
	return new cv::Ptr<cv::StereoBM>(obj);
}

CVAPI(int) calib3d_StereoBM_getPreFilterType(cv::Ptr<cv::StereoBM> *obj)
{
	return (*obj)->getPreFilterType();
}
CVAPI(void) calib3d_StereoBM_setPreFilterType(cv::Ptr<cv::StereoBM> *obj, int value)
{
	(*obj)->setPreFilterType(value);
}

CVAPI(int) calib3d_StereoBM_getPreFilterSize(cv::Ptr<cv::StereoBM> *obj)
{
	return (*obj)->getPreFilterSize();
}
CVAPI(void) calib3d_StereoBM_setPreFilterSize(cv::Ptr<cv::StereoBM> *obj, int value)
{
	(*obj)->setPreFilterSize(value);
}

CVAPI(int) calib3d_StereoBM_getPreFilterCap(cv::Ptr<cv::StereoBM> *obj)
{
	return (*obj)->getPreFilterCap();
}
CVAPI(void) calib3d_StereoBM_setPreFilterCap(cv::Ptr<cv::StereoBM> *obj, int value)
{
	(*obj)->setPreFilterCap(value);
}

CVAPI(int) calib3d_StereoBM_getTextureThreshold(cv::Ptr<cv::StereoBM> *obj)
{
	return (*obj)->getTextureThreshold();
}
CVAPI(void) calib3d_StereoBM_setTextureThreshold(cv::Ptr<cv::StereoBM> *obj, int value)
{
	(*obj)->setTextureThreshold(value);
}

CVAPI(int) calib3d_StereoBM_getUniquenessRatio(cv::Ptr<cv::StereoBM> *obj)
{
	return (*obj)->getUniquenessRatio();
}
CVAPI(void) calib3d_StereoBM_setUniquenessRatio(cv::Ptr<cv::StereoBM> *obj, int value)
{
	(*obj)->setUniquenessRatio(value);
}

CVAPI(int) calib3d_StereoBM_getSmallerBlockSize(cv::Ptr<cv::StereoBM> *obj)
{
	return (*obj)->getSmallerBlockSize();
}
CVAPI(void) calib3d_StereoBM_setSmallerBlockSize(cv::Ptr<cv::StereoBM> *obj, int value)
{
	(*obj)->setSmallerBlockSize(value);
}

CVAPI(MyCvRect) calib3d_StereoBM_getROI1(cv::Ptr<cv::StereoBM> *obj)
{
	return c((*obj)->getROI1());
}
CVAPI(void) calib3d_StereoBM_setROI1(cv::Ptr<cv::StereoBM> *obj, MyCvRect value)
{
	(*obj)->setROI1(cpp(value));
}

CVAPI(MyCvRect) calib3d_StereoBM_getROI2(cv::Ptr<cv::StereoBM> *obj)
{
	return c((*obj)->getROI2());
}
CVAPI(void) calib3d_StereoBM_setROI2(cv::Ptr<cv::StereoBM> *obj, MyCvRect value)
{
	(*obj)->setROI2(cpp(value));
}

#pragma endregion

#pragma region StereoSGBM

CVAPI(void) calib3d_Ptr_StereoSGBM_delete(cv::Ptr<cv::StereoSGBM> *obj)
{
	delete obj;
}

CVAPI(cv::Ptr<cv::StereoSGBM>*) calib3d_StereoSGBM_create(
	int minDisparity, int numDisparities, int blockSize,
	int P1, int P2, int disp12MaxDiff,
	int preFilterCap, int uniquenessRatio,
	int speckleWindowSize, int speckleRange, int mode)
{
	cv::Ptr<cv::StereoSGBM> obj = cv::StereoSGBM::create(
		minDisparity, numDisparities, blockSize,
		P1, P2, disp12MaxDiff,
		preFilterCap, uniquenessRatio,
		speckleWindowSize, speckleRange, mode);
	return new cv::Ptr<cv::StereoSGBM>(obj);
}

CVAPI(int) calib3d_StereoSGBM_getPreFilterCap(cv::Ptr<cv::StereoSGBM> *obj)
{
	return (*obj)->getPreFilterCap();
}
CVAPI(void) calib3d_StereoSGBM_setPreFilterCap(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
	(*obj)->setPreFilterCap(value);
}

CVAPI(int) calib3d_StereoSGBM_getUniquenessRatio(cv::Ptr<cv::StereoSGBM> *obj)
{
	return (*obj)->getUniquenessRatio();
}
CVAPI(void) calib3d_StereoSGBM_setUniquenessRatio(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
	(*obj)->setUniquenessRatio(value);
}

CVAPI(int) calib3d_StereoSGBM_getP1(cv::Ptr<cv::StereoSGBM> *obj)
{
	return (*obj)->getP1();
}
CVAPI(void) calib3d_StereoSGBM_setP1(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
	(*obj)->setP1(value);
}

CVAPI(int) calib3d_StereoSGBM_getP2(cv::Ptr<cv::StereoSGBM> *obj)
{
	return (*obj)->getP2();
}
CVAPI(void) calib3d_StereoSGBM_setP2(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
	(*obj)->setP2(value);
}

CVAPI(int) calib3d_StereoSGBM_getMode(cv::Ptr<cv::StereoSGBM> *obj)
{
	return (*obj)->getMode();
}
CVAPI(void) calib3d_StereoSGBM_setMode(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
	(*obj)->setMode(value);
}

#pragma endregion

#endif