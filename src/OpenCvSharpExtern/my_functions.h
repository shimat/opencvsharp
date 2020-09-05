// Additional functions

#ifndef _MY_FUNCTIONS_H_
#define _MY_FUNCTIONS_H_

#ifdef _WIN32
#pragma warning(disable: 4996) 
#endif

#include <opencv2/opencv.hpp>
#include "my_types.h"


#ifdef _WIN32
#ifdef _DEBUG
#include <Windows.h>

// MP! Added: To provide WinRT version of MessageBox handling.
#ifdef _WINRT_DLL
void StringConvert(const std::string from, std::wstring& to);
void StringConvert(const std::wstring from, std::string& to);
#endif

static int p(const char *msg, const char caption[] = "MessageBox")
{
#ifdef _WINRT_DLL
    std::wstring wmsg;
    std::wstring wcaption;
    StringConvert(msg, wmsg);
    StringConvert(caption, wcaption);

    Windows::UI::Popups::MessageDialog(ref new Platform::String(wmsg.c_str()), ref new Platform::String(wcaption.c_str())).ShowAsync();
    return MB_OK;
#else
    return MessageBoxA(nullptr, msg, caption, MB_OK);
#endif
}

template <typename T>
static int p(T obj, const std::string &caption = "MessageBox")
{
    std::stringstream ss;
    ss << obj;
    return p(ss.str().c_str(), caption.c_str());
}
#endif
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


// catch all exception
enum class ExceptionStatus : int { NotOccurred = 0, Occurred = 1 };

#if defined WIN32 || defined _WIN32
#define BEGIN_WRAP
#define END_WRAP return ExceptionStatus::NotOccurred;
#else
#define BEGIN_WRAP try{
#define END_WRAP return ExceptionStatus::NotOccurred;}catch(std::exception){return ExceptionStatus::Occurred;}
#endif


static cv::_InputArray entity(cv::_InputArray *obj)
{
    return (obj != nullptr) ? *obj : static_cast<cv::_InputArray>(cv::noArray());
}
static cv::_OutputArray entity(cv::_OutputArray *obj)
{
    return (obj != nullptr) ? *obj : static_cast<cv::_OutputArray>(cv::noArray());
}
static cv::_InputOutputArray entity(cv::_InputOutputArray *obj)
{
    return (obj != nullptr) ? *obj : cv::noArray();
}
static cv::Mat entity(cv::Mat *obj)
{
    return (obj != nullptr) ? *obj : cv::Mat();
}
static cv::SparseMat entity(cv::SparseMat *obj)
{
    return (obj != nullptr) ? *obj : cv::SparseMat();
}

template <typename T>
static cv::Ptr<T> *clone(const cv::Ptr<T> &ptr)
{
    return new cv::Ptr<T>(ptr);
}

static void copyString(const char *src, char *dst, int dstLength)
{
    const auto length = static_cast<size_t>(std::max(0, dstLength - 1));
    if (strlen(src) == 0)
        std::strncpy(dst, "", length);
    else
        std::strncpy(dst, src, length);
}
static void copyString(const std::string &src, char *dst, int dstLength)
{
    const auto length = static_cast<size_t>(std::max(0, dstLength - 1));
    if (src.empty())
        std::strncpy(dst, "", length);
    else
        std::strncpy(dst, src.c_str(), length);
}

template <typename T>
static void dump(T *obj, const std::string &outFile)
{
    const int size = sizeof(T);
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
    const cv::Mat **inPtr, const int size, std::vector<cv::Mat> &outVec)
{
    outVec.resize(size);
    for (int i = 0; i < size; i++)
    {
        outVec[i] = *inPtr[i];
    }
}

static void toVec(
    cv::Mat **inPtr, const int size, std::vector<cv::Mat> &outVec)
{
    outVec.resize(size);
    for (int i = 0; i < size; i++)
    {
        outVec[i] = *inPtr[i];
    }
}

template <typename TIn, typename TOut>
static void toVec(
    const TIn **inPtr, const int size1, const int *size2, std::vector<std::vector<TOut> > &outVec)
{
    outVec.resize(size1);
    for (int i = 0; i < size1; i++)
    {
        int size = size2[i];
        const TIn *p = inPtr[i];
        std::vector<TOut> v(p, p + size);
        outVec[i] = v;
    }
}

#endif