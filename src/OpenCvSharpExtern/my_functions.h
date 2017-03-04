// Additional functions

#ifndef _MY_FUNCTIONS_H_
#define _MY_FUNCTIONS_H_

#include <opencv2/opencv.hpp>
#include "my_types.h"

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



#if defined WIN32 || defined _WIN32
#  define CV_CDECL __cdecl
#  define CV_STDCALL __stdcall
#else
#  define CV_CDECL
#  define CV_STDCALL
#endif

#ifndef CVAPI
#  define CVAPI(rettype) CV_EXTERN_C CV_EXPORTS rettype CV_CDECL
#endif



static cv::_InputArray entity(cv::_InputArray *obj)
{
    return (obj != NULL) ? *obj : static_cast<cv::_InputArray>(cv::noArray());
}
static cv::_OutputArray entity(cv::_OutputArray *obj)
{
    return (obj != NULL) ? *obj : static_cast<cv::_OutputArray>(cv::noArray());
}
static cv::_InputOutputArray entity(cv::_InputOutputArray *obj)
{
    return (obj != NULL) ? *obj : cv::noArray();
}
static cv::Mat entity(cv::Mat *obj)
{
    return (obj != NULL) ? *obj : cv::Mat();
}
static cv::SparseMat entity(cv::SparseMat *obj)
{
    return (obj != NULL) ? *obj : cv::SparseMat();
}
static cv::cuda::GpuMat entity(cv::cuda::GpuMat *obj)
{
    return (obj != NULL) ? *obj : cv::cuda::GpuMat();
}
static cv::cuda::Stream entity(cv::cuda::Stream *obj)
{
    return (obj != NULL) ? *obj : cv::cuda::Stream::Null();
}

template <typename T>
static cv::Ptr<T> *clone(const cv::Ptr<T> &ptr)
{
    return new cv::Ptr<T>(ptr);
}

static void copyString(const char *src, char *dst, int dstLength)
{
    if (strlen(src) == 0)
        std::strncpy(dst, "", dstLength - 1);
    else
        std::strncpy(dst, src, dstLength - 1);
}
static void copyString(const std::string &src, char *dst, int dstLength)
{
    if (src.empty())
        std::strncpy(dst, "", dstLength - 1);
    else
        std::strncpy(dst, src.c_str(), dstLength - 1);
}
static void copyString(const cv::String &src, char *dst, int dstLength)
{
    if (src.empty())
        std::strncpy(dst, "", dstLength - 1);
    else
        std::strncpy(dst, src.c_str(), dstLength - 1);
}

template <typename T>
static void dump(T *obj, const std::string &outFile)
{
    int size = sizeof(T);
    std::vector<uchar> bytes(size);
    std::memcpy(&bytes[0], reinterpret_cast<uchar*>(obj), size);
    
    FILE *fp = fopen(outFile.c_str(), "w");
    for (std::vector<uchar>::iterator it = bytes.begin(); it != bytes.end(); ++it)
    {
        std::fprintf(fp, "%x,", static_cast<int>(*it));
    }
    fclose(fp);
}

static void toVec(
    cv::Mat **inPtr, int size, std::vector<cv::Mat> &outVec)
{
    outVec.resize(size);
    for (int i = 0; i < size; i++)
    {
        outVec[i] = *inPtr[i];
    }
}

template <typename TIn, typename TOut>
static void toVec(
    TIn **inPtr, int size1, const int *size2, std::vector<std::vector<TOut> > &outVec)
{
    outVec.resize(size1);
    for (int i = 0; i < size1; i++)
    {
        int size = size2[i];
        TIn *p = inPtr[i];
        std::vector<TOut> v(p, p + size);
        /*std::vector<cv::Rect> v(size);
        for (int j = 0; j < size; j++)
        {
            v[j] = inPtr[i][j];
        }*/
        outVec[i] = v;
    }
}

#endif