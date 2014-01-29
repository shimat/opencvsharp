/*
* (C) 2008-2014 Schima
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_MAT_H_
#define _CPP_CORE_MAT_H_

#include <opencv2/core/core.hpp>
#include <iostream>

#pragma region Init & Release
CVAPI(uint64) core_Mat_sizeof()
{
	return sizeof(cv::Mat);
}

CVAPI(cv::Mat*) core_Mat_new1()
{
	return new cv::Mat();
}
CVAPI(cv::Mat*) core_Mat_new2(int rows, int cols, int type)
{
	return new cv::Mat(rows, cols, type); CvScalar s;
}
CVAPI(cv::Mat*) core_Mat_new3(int rows, int cols, int type, CvScalar scalar)
{
	return new cv::Mat(rows, cols, type, scalar);
}
CVAPI(cv::Mat*) core_Mat_new4(cv::Mat *mat, CvSlice rowRange, CvSlice colRange)
{
	return new cv::Mat(*mat, rowRange, colRange);
}
CVAPI(cv::Mat*) core_Mat_new5(cv::Mat *mat, CvSlice rowRange)
{
	return new cv::Mat(*mat, rowRange);
}
CVAPI(cv::Mat*) core_Mat_new6(cv::Mat *mat, CvRect roi)
{
	return new cv::Mat(*mat, roi);
}

CVAPI(void) core_Mat_release(cv::Mat *mat)
{
	mat->release();
}
#pragma endregion

#pragma region Functions
CVAPI(cv::Mat*) core_Mat_adjustROI(cv::Mat *mat, int dtop, int dbottom, int dleft, int dright)
{
	cv::Mat ret = mat->adjustROI(dtop, dbottom, dleft, dright);
	return new cv::Mat(ret);
}
#pragma endregion

#endif