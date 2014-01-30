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

CVAPI(void) core_Mat_release(cv::Mat *obj)
{
	obj->release();
}
CVAPI(void) core_Mat_delete(cv::Mat *obj)
{
	delete obj;
}
#pragma endregion

#pragma region Functions
CVAPI(cv::Mat*) core_Mat_adjustROI(cv::Mat *obj, int dtop, int dbottom, int dleft, int dright)
{
	cv::Mat ret = obj->adjustROI(dtop, dbottom, dleft, dright);
	return new cv::Mat(ret);
}

CVAPI(void) core_Mat_assignTo1(cv::Mat *obj, cv::Mat *m)
{
	obj->assignTo(*m);
}
CVAPI(void) core_Mat_assignTo2(cv::Mat *obj, cv::Mat *m, int type)
{
	obj->assignTo(*m, type);
}

CVAPI(int) core_Mat_channels(cv::Mat *obj)
{
	return obj->channels();
}

CVAPI(int) core_Mat_checkVector1(cv::Mat *obj, int elemChannels)
{
	return obj->checkVector(elemChannels);
}
CVAPI(int) core_Mat_checkVector2(cv::Mat *obj, int elemChannels, int depth)
{
	return obj->checkVector(elemChannels, depth);
}
CVAPI(int) core_Mat_checkVector3(cv::Mat *obj, int elemChannels, int depth, int requireContinuous)
{
	return obj->checkVector(elemChannels, depth, requireContinuous != 0);
}

CVAPI(cv::Mat*) core_Mat_clone(cv::Mat *obj)
{
	cv::Mat ret = obj->clone();
	return new cv::Mat(ret);
}
#pragma endregion

#endif