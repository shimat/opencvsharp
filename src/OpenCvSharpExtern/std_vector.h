/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WVECTOR_H_
#define _CPP_WVECTOR_H_

#include "include_opencv.h"

using namespace std;

#pragma region uchar
CVAPI(vector<uchar>*) vector_uchar_new1()
{
	return new vector<uchar>;
}
CVAPI(vector<uchar>*) vector_uchar_new2(uint size)
{
	return new vector<uchar>(size);
}
CVAPI(vector<uchar>*) vector_uchar_new3(uchar* data, uint data_length)
{
	return new vector<uchar>(data, data + data_length);
}
CVAPI(size_t) vector_uchar_getSize(vector<uchar>* vector)
{
	return vector->size();
}
CVAPI(uchar*) vector_uchar_getPointer(vector<uchar>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_uchar_delete(vector<uchar>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region float
CVAPI(vector<float>*) vector_float_new1()
{
	return new vector<float>;
}
CVAPI(vector<float>*) vector_float_new2(uint size)
{
	return new vector<float>(size);
}
CVAPI(vector<float>*) vector_float_new3(float* data, uint data_length)
{
	return new vector<float>(data, data + data_length);
}
CVAPI(size_t) vector_float_getSize(vector<float>* vector)
{
	return vector->size();
}
CVAPI(float*) vector_float_getPointer(vector<float>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_float_delete(vector<float>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Vec2f
CVAPI(vector<cv::Vec2f>*) vector_Vec2f_new1()
{
	return new vector<cv::Vec2f>;
}
CVAPI(vector<cv::Vec2f>*) vector_Vec2f_new2(uint size)
{
	return new vector<cv::Vec2f>(size);
}
CVAPI(vector<cv::Vec2f>*) vector_Vec2f_new3(cv::Vec2f* data, uint data_length)
{
	vector<cv::Vec2f>* vec = new vector<cv::Vec2f>(data_length);
	for (uint i = 0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_Vec2f_getSize(vector<cv::Vec2f>* vector)
{
	return vector->size();
}
CVAPI(cv::Vec2f*) vector_Vec2f_getPointer(vector<cv::Vec2f>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_Vec2f_delete(vector<cv::Vec2f>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Vec3f
CVAPI(vector<cv::Vec3f>*) vector_Vec3f_new1()
{
	return new vector<cv::Vec3f>;
}
CVAPI(vector<cv::Vec3f>*) vector_Vec3f_new2(size_t size)
{
	return new vector<cv::Vec3f>(size);
}
CVAPI(vector<cv::Vec3f>*) vector_Vec3f_new3(cv::Vec3f* data, size_t data_length)
{
	vector<cv::Vec3f>* vec = new vector<cv::Vec3f>(data_length);
	for(size_t i=0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_Vec3f_getSize(vector<cv::Vec3f>* vector)
{
	return vector->size();
}
CVAPI(cv::Vec3f*) vector_Vec3f_getPointer(vector<cv::Vec3f>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_Vec3f_delete(vector<cv::Vec3f>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Vec4i
CVAPI(vector<cv::Vec4i>*) vector_Vec4i_new1()
{
	return new vector<cv::Vec4i>;
}
CVAPI(vector<cv::Vec4i>*) vector_Vec4i_new2(uint size)
{
	return new vector<cv::Vec4i>(size);
}
CVAPI(vector<cv::Vec4i>*) vector_Vec4i_new3(cv::Vec4i* data, uint data_length)
{
	vector<cv::Vec4i>* vec = new vector<cv::Vec4i>(data_length);
	for (uint i = 0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_Vec4i_getSize(vector<cv::Vec4i>* vector)
{
	return vector->size();
}
CVAPI(cv::Vec4i*) vector_Vec4i_getPointer(vector<cv::Vec4i>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_Vec4i_delete(vector<cv::Vec4i>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Point2i
CVAPI(vector<cv::Point>*) vector_Point2i_new1()
{
	return new vector<cv::Point>;
}
CVAPI(vector<cv::Point>*) vector_Point2i_new2(uint size)
{
	return new vector<cv::Point>(size);
}
CVAPI(vector<cv::Point>*) vector_Point2i_new3(CvPoint* data, uint data_length)
{
	vector<cv::Point>* vec = new vector<cv::Point>(data_length);
	for (uint i = 0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_Point2i_getSize(vector<cv::Point>* vector)
{
	return vector->size();
}
CVAPI(cv::Point*) vector_Point2i_getPointer(vector<cv::Point>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_Point2i_delete(vector<cv::Point>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Point2f
CVAPI(vector<cv::Point2f>*) vector_Point2f_new1()
{
	return new vector<cv::Point2f>;
}
CVAPI(vector<cv::Point2f>*) vector_Point2f_new2(uint size)
{
	return new vector<cv::Point2f>(size);
}
CVAPI(vector<cv::Point2f>*) vector_Point2f_new3(CvPoint2D32f* data, uint data_length)
{
	vector<cv::Point2f>* vec = new vector<cv::Point2f>(data_length);
	for (uint i = 0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_cvPoint_getSize(vector<cv::Point2f>* vector)
{
	return vector->size();
}
CVAPI(cv::Point2f*) vector_cvPoint_getPointer(vector<cv::Point2f>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_cvPoint_delete(vector<cv::Point2f>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Rect
CVAPI(vector<cv::Rect>*) vector_Rect_new1()
{
	return new vector<cv::Rect>;
}
CVAPI(vector<cv::Rect>*) vector_Rect_new2(uint size)
{
	return new vector<cv::Rect>(size);
}
CVAPI(vector<cv::Rect>*) vector_Rect_new3(CvRect* data, size data_length)
{
	vector<cv::Rect>* vec = new vector<cv::Rect>(data_length);
	for (size i = 0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size) vector_Rect_getSize(vector<cv::Rect>* vector)
{
	return vector->size();
}
CVAPI(cv::Rect*) vector_Rect_getPointer(vector<cv::Rect> *xvector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_Rect_delete(vector<cv::Rect> *vector)
{	
	//vector->~vector();
	delete vector;
}

#pragma endregion

#pragma region cv::KeyPoint
CVAPI(vector<cv::KeyPoint>*) vector_KeyPoint_new1()
{
	return new vector<cv::KeyPoint>;
}
CVAPI(vector<cv::KeyPoint>*) vector_KeyPoint_new2(size size)
{
	return new vector<cv::KeyPoint>(size);
}
CVAPI(vector<cv::KeyPoint>*) vector_KeyPoint_new3(cv::KeyPoint *data, size data_length)
{
	vector<cv::KeyPoint>* vec = new vector<cv::KeyPoint>(data_length);
	for(size_t i=0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_KeyPoint_getSize(vector<cv::KeyPoint>* vector)
{
	return vector->size();
}
CVAPI(cv::KeyPoint*) vector_KeyPoint_getPointer(vector<cv::KeyPoint>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_KeyPoint_delete(vector<cv::KeyPoint>* vector)
{	
	//vector->~vector();
	delete vector;
}
#pragma endregion

#endif