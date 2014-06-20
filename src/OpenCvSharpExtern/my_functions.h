// Additional functions

#ifndef _MY_FUNCTIONS_H_
#define _MY_FUNCTIONS_H_

#include <opencv2/opencv.hpp>


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
static inline cv::gpu::GpuMat entity(cv::gpu::GpuMat *obj)
{
	return (obj != NULL) ? *obj : cv::gpu::GpuMat();
}

template <typename T>
static inline cv::Ptr<T> *clone(cv::Ptr<T> &ptr)
{
    return new cv::Ptr<T>(ptr);
}
template <typename T>
static inline cv::Ptr<T> *wrap(T *ptr)
{
    return new cv::Ptr<T>(ptr);
}

static inline void copyString(const std::string &src, char *dst, int dstLength)
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
    std::memcpy(&bytes[0], (uchar*)obj, size);

    auto fp = fopen(outFile.c_str(), "w");
    for (auto it = bytes.begin(); it != bytes.end(); it++)
    {
        std::fprintf(fp, "%x,", (int)*it);
    }
    fclose(fp);
}

#endif