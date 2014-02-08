/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_CALIB3D_H_
#define _CPP_CORE_CALIB3D_H_

#include "include_opencv.h"


CVAPI(void) imgproc_solvePnP(cv::_InputArray* objectPoints, cv::_InputArray* imagePoints, cv::_InputArray* cameraMatrix, cv::_InputArray* distCoeffs,
	cv::_OutputArray* rvec, cv::_OutputArray* tvec, int useExtrinsicGuess)
{
	cv::InputArray distCoeffsVal = (distCoeffs != NULL) ? *distCoeffs : cv::noArray();
	cv::solvePnP(*objectPoints, *imagePoints, *cameraMatrix, distCoeffsVal, *rvec, *tvec, useExtrinsicGuess != 0);
}

#endif