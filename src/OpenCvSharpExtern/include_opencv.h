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
#include <sstream>
#include <iterator>
#include <fstream>
#include <iostream>
#include <cstdio>
#include <cstring>
#include <cstdlib>

#ifdef _WIN32
#include <Windows.h>
static int p(const char *msg, const char caption[] = "MessageBox")
{
	return MessageBoxA(NULL, msg, caption, MB_OK);
}

template <typename T>
static int p(T obj, const std::string &caption = "MessageBox")
{
	std::stringstream ss;
	ss << obj;
    return p(ss.str().c_str(), caption.c_str());
}
#undef min
#undef max
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

template <typename T>
static inline cv::Ptr<T> *clone(cv::Ptr<T> &ptr)
{
    ptr.addref();
    return new cv::Ptr<T>( ptr.obj );
}
template <typename T>
static inline cv::Ptr<T> *wrap(T *ptr)
{
    return new cv::Ptr<T>( ptr );
}

static inline void copyString(const std::string &src, char *dst, int dstLength)
{
	if(src.empty())	    
        std::strncpy(dst, "", dstLength - 1);    
    else    
        std::strncpy(dst, src.c_str(), dstLength - 1); 
}

template <typename T>
static void dump(T *obj, const std::string &outFile)
{
    int size = sizeof(T);
    std::vector<uchar> bytes(size);
    std::memcpy(&bytes[0], (uchar*)obj, size);

    auto fp = fopen(outFile.c_str(), "w");
    for (auto it = bytes.begin(); it != bytes.end(); it++)
    {
        std::fprintf(fp, "%x,", (int)*it);
    }
    fclose(fp);
}
#endif
