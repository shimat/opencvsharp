#ifndef _INCLUDE_OPENCV_H_
#define _INCLUDE_OPENCV_H_

#include <opencv2/opencv.hpp>
#include <opencv2/legacy/legacy.hpp>
typedef unsigned int uint32;
typedef unsigned short uint16;

#include <vector>
#include <algorithm>
#include <iterator>
#include <fstream>
#include <iostream>

#if 1

#ifdef _WIN32
#include <Windows.h>
#include <sstream>
static int p(const char* msg)
{
	return MessageBoxA(NULL, msg, "MessageBox", MB_OK);
}
#undef min
#undef max
#endif
template <typename T>
static int p(T obj)
{
	std::stringstream ss;
	ss << obj;
	return p(ss.str().c_str());
}
#endif

static inline cv::_InputArray entity(cv::_InputArray *obj)
{
	return (obj != NULL) ? *obj : cv::noArray();
}
static inline cv::_OutputArray entity(cv::_OutputArray *obj)
{
	return (obj != NULL) ? *obj : cv::noArray();
}
static inline cv::Mat entity(cv::Mat *obj)
{
	return (obj != NULL) ? *obj : cv::Mat();
}

#endif
