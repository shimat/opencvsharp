#ifndef _INCLUDE_OPENCV_H_
#define _INCLUDE_OPENCV_H_

#ifdef _MSC_VER
#pragma warning(push)
#pragma warning(disable: 4251)
#pragma warning(disable: 4996)
#endif
#include <opencv2/opencv.hpp>
#include <opencv2/legacy/legacy.hpp>
#include <opencv2/nonfree/nonfree.hpp>
#include <opencv2/superres/superres.hpp>
#ifdef _MSC_VER
#pragma warning(pop)
#endif

typedef unsigned int uint32;
typedef unsigned short uint16;


#include <vector>
#include <algorithm>
#include <iterator>
#include <fstream>
#include <iostream>
#include <cstdio>
#include <cstring>
#include <cstdlib>

#ifdef _WIN32
#include <Windows.h>
static int p(const char *msg)
{
	return MessageBoxA(NULL, msg, "MessageBox", MB_OK);
}
#undef min
#undef max
#endif
#include <sstream>
template <typename T>
static int p(T obj)
{
	std::stringstream ss;
	ss << obj;
	return p(ss.str().c_str());
}


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

template <typename T>
static inline cv::Ptr<T> *clone(cv::Ptr<T> &ptr)
{
    return new cv::Ptr<T>( ptr.obj );
}

#endif
