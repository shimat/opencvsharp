/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WVECTOR_H_
#define _CPP_WVECTOR_H_

#include <vector>

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/opencv.hpp>

using namespace std;

#pragma region uchar
CVAPI(vector<uchar>*) vector_uchar_new1()
{
	return new vector<uchar>;
}
CVAPI(vector<uchar>*) vector_uchar_new2(size_t size)
{
	return new vector<uchar>(size);
}
CVAPI(vector<uchar>*) vector_uchar_new3(uchar* data, size_t data_length)
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
CVAPI(vector<float>*) vector_float_new2(size_t size)
{
	return new vector<float>(size);
}
CVAPI(vector<float>*) vector_float_new3(float* data, size_t data_length)
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
CVAPI(vector<cv::Vec2f>*) vector_cvVec2f_new1()
{
	return new vector<cv::Vec2f>;
}
CVAPI(vector<cv::Vec2f>*) vector_cvVec2f_new2(size_t size)
{
	return new vector<cv::Vec2f>(size);
}
CVAPI(vector<cv::Vec2f>*) vector_cvVec2f_new3(cv::Vec2f* data, size_t data_length)
{
	vector<cv::Vec2f>* vec = new vector<cv::Vec2f>(data_length);
	for(size_t i=0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_cvVec2f_getSize(vector<cv::Vec2f>* vector)
{
	return vector->size();
}
CVAPI(cv::Vec2f*) vector_cvVec2f_getPointer(vector<cv::Vec2f>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_cvVec2f_delete(vector<cv::Vec2f>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Vec3f
CVAPI(vector<cv::Vec3f>*) vector_cvVec3f_new1()
{
	return new vector<cv::Vec3f>;
}
CVAPI(vector<cv::Vec3f>*) vector_cvVec3f_new2(size_t size)
{
	return new vector<cv::Vec3f>(size);
}
CVAPI(vector<cv::Vec3f>*) vector_cvVec3f_new3(cv::Vec3f* data, size_t data_length)
{
	vector<cv::Vec3f>* vec = new vector<cv::Vec3f>(data_length);
	for(size_t i=0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_cvVec3f_getSize(vector<cv::Vec3f>* vector)
{
	return vector->size();
}
CVAPI(cv::Vec3f*) vector_cvVec3f_getPointer(vector<cv::Vec3f>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_cvVec3f_delete(vector<cv::Vec3f>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Vec4i
CVAPI(vector<cv::Vec4i>*) vector_cvVec4i_new1()
{
	return new vector<cv::Vec4i>;
}
CVAPI(vector<cv::Vec4i>*) vector_cvVec4i_new2(size_t size)
{
	return new vector<cv::Vec4i>(size);
}
CVAPI(vector<cv::Vec4i>*) vector_cvVec4i_new3(cv::Vec4i* data, size_t data_length)
{
	vector<cv::Vec4i>* vec = new vector<cv::Vec4i>(data_length);
	for(size_t i=0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_cvVec4i_getSize(vector<cv::Vec4i>* vector)
{
	return vector->size();
}
CVAPI(cv::Vec4i*) vector_cvVec4i_getPointer(vector<cv::Vec4i>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_cvVec4i_delete(vector<cv::Vec4i>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Point
CVAPI(vector<cv::Point>*) vector_cvPoint_new1()
{
	return new vector<cv::Point>;
}
CVAPI(vector<cv::Point>*) vector_cvPoint_new2(size_t size)
{
	return new vector<cv::Point>(size);
}
CVAPI(vector<cv::Point>*) vector_cvPoint_new3(CvPoint* data, size_t data_length)
{
	vector<cv::Point>* vec = new vector<cv::Point>(data_length);
	for(size_t i=0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_cvPoint_getSize(vector<cv::Point>* vector)
{
	return vector->size();
}
CVAPI(cv::Point*) vector_cvPoint_getPointer(vector<cv::Point>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_cvPoint_delete(vector<cv::Point>* vector)
{
	delete vector;
}
#pragma endregion

#pragma region cv::Rect
CVAPI(vector<cv::Rect>*) vector_cvRect_new1()
{
	return new vector<cv::Rect>;
}
CVAPI(vector<cv::Rect>*) vector_cvRect_new2(size_t size)
{
	return new vector<cv::Rect>(size);
}
CVAPI(vector<cv::Rect>*) vector_cvRect_new3(CvRect* data, size_t data_length)
{
	vector<cv::Rect>* vec = new vector<cv::Rect>(data_length);
	for(size_t i=0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_cvRect_getSize(vector<cv::Rect>* vector)
{
	return vector->size();
}
CVAPI(cv::Rect*) vector_cvRect_getPointer(vector<cv::Rect>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_cvRect_delete(vector<cv::Rect>* vector)
{	
	//vector->~vector();
	delete vector;
}

#pragma endregion

#pragma region cv::KeyPoint
CVAPI(vector<cv::KeyPoint>*) vector_cvKeyPoint_new1()
{
	return new vector<cv::KeyPoint>;
}
CVAPI(vector<cv::KeyPoint>*) vector_cvKeyPoint_new2(size_t size)
{
	return new vector<cv::KeyPoint>(size);
}
CVAPI(vector<cv::KeyPoint>*) vector_cvKeyPoint_new3(cv::KeyPoint* data, size_t data_length)
{
	vector<cv::KeyPoint>* vec = new vector<cv::KeyPoint>(data_length);
	for(size_t i=0; i<data_length; i++)
	{
		vec->push_back(data[i]);
	}
	return vec;
}
CVAPI(size_t) vector_cvKeyPoint_getSize(vector<cv::KeyPoint>* vector)
{
	return vector->size();
}
CVAPI(cv::KeyPoint*) vector_cvKeyPoint_getPointer(vector<cv::KeyPoint>* vector)
{
	return &(vector->at(0));
}
CVAPI(void) vector_cvKeyPoint_delete(vector<cv::KeyPoint>* vector)
{	
	//vector->~vector();
	delete vector;
}
#pragma endregion

#endif