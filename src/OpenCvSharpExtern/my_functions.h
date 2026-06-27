// Additional functions

#pragma once

#ifdef _WIN32
#pragma warning(disable: 4996) 
#endif

#include <opencv2/opencv.hpp>


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


#ifdef _WIN32
#include <Windows.h>

// Windows narrow file APIs (fopen) interpret paths in the active code page, so OpenCV cannot open
// UTF-8 / non-ANSI file names. These helpers let the path-taking entry points do their own I/O via
// wide (UTF-16) streams on Windows, combined with OpenCV's in-memory decode/encode APIs. Fixes opencv #4242.
static std::wstring utf8ToWide(const char *utf8)
{
    if (utf8 == nullptr || utf8[0] == '\0')
        return std::wstring();
    const int len = MultiByteToWideChar(CP_UTF8, 0, utf8, -1, nullptr, 0);
    if (len <= 1)
        return std::wstring();
    std::wstring wide(static_cast<size_t>(len - 1), L'\0');
    MultiByteToWideChar(CP_UTF8, 0, utf8, -1, &wide[0], len);
    return wide;
}

// True if the UTF-8 path can be represented losslessly in the process active code page (so OpenCV's
// narrow file APIs can open it directly, preserving streaming). 'acp' receives the narrow path.
// Returns false only for paths with characters the code page cannot represent (those previously
// failed on Windows and now need the wide path).
static bool pathRoundTripsAcp(const char *utf8, std::string &acp)
{
    if (utf8 == nullptr || utf8[0] == '\0') { acp.clear(); return true; }
    // A UTF-8 active code page (Windows 10 1903+) opens UTF-8 narrow paths directly.
    if (GetACP() == CP_UTF8) { acp = utf8; return true; }
    // Pure ASCII is representable in every code page.
    bool ascii = true;
    for (const char *p = utf8; *p != '\0'; ++p)
        if (static_cast<unsigned char>(*p) >= 0x80) { ascii = false; break; }
    if (ascii) { acp = utf8; return true; }

    const std::wstring wide = utf8ToWide(utf8);
    if (wide.empty()) return false;
    BOOL usedDefault = FALSE;
    const int len = WideCharToMultiByte(CP_ACP, WC_NO_BEST_FIT_CHARS, wide.c_str(), -1, nullptr, 0, nullptr, &usedDefault);
    if (len <= 0) return false; // e.g. flag unsupported by the code page -> treat as non-representable
    std::string buf(static_cast<size_t>(len - 1), '\0');
    WideCharToMultiByte(CP_ACP, WC_NO_BEST_FIT_CHARS, wide.c_str(), -1, len > 1 ? &buf[0] : nullptr, len, nullptr, &usedDefault);
    if (usedDefault) return false; // a character could not be represented in the code page
    acp = std::move(buf);
    return true;
}

// Reads the whole file at a UTF-8 path. Returns false if it could not be opened.
static bool readAllBytesWide(const char *utf8Path, std::vector<uchar> &out)
{
    std::ifstream file(utf8ToWide(utf8Path), std::ios::binary | std::ios::ate);
    if (!file)
        return false;
    const std::streamsize size = file.tellg();
    file.seekg(0, std::ios::beg);
    out.resize(static_cast<size_t>(size < 0 ? 0 : size));
    if (size > 0)
        file.read(reinterpret_cast<char*>(out.data()), size);
    return true;
}

// Writes bytes to a UTF-8 path. Returns false on failure.
static bool writeAllBytesWide(const char *utf8Path, const uchar *data, size_t size)
{
    std::ofstream file(utf8ToWide(utf8Path), std::ios::binary);
    if (!file)
        return false;
    if (size > 0)
        file.write(reinterpret_cast<const char*>(data), static_cast<std::streamsize>(size));
    return file.good();
}
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
static cv::UMat entity(cv::UMat* obj)
{
    return (obj != nullptr) ? *obj : cv::UMat();
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

template <typename T>
static void copyFromVectorToArray(std::vector<std::vector<T> >* src, T** dst)
{
    for (size_t i = 0; i < src->size(); ++i)
    {
        const auto& srcI = src->at(i);
        const auto dstI = dst[i];
        for (size_t j = 0; j < srcI.size(); ++j)
        {
            dstI[j] = srcI[j];
        }
    }
}