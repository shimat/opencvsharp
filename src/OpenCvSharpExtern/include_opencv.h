#ifndef _INCLUDE_OPENCV_H_
#define _INCLUDE_OPENCV_H_

#include <opencv2/opencv.hpp>
typedef unsigned int uint32;
typedef unsigned short uint16;

#if 0
#ifdef _WIN32
#include <Windows.h>
#include <sstream>
int p(const char* msg)
{
	return MessageBoxA(NULL, msg, "MessageBox", MB_OK);
}
template <typename T>
int p(T obj)
{
	std::stringstream ss;
	ss << obj;
	return p(ss.str().c_str());
}
#endif
#endif

static inline cv::InputArray entity(cv::_InputArray *obj)
{
	return (obj != NULL) ? *obj : cv::noArray();
}
static inline cv::OutputArray entity(cv::_OutputArray *obj)
{
	return (obj != NULL) ? *obj : cv::noArray();
}

#endif
