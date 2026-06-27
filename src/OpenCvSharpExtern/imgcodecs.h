#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// Path handling on Windows (opencv #4242): OpenCV's narrow fopen interprets paths in the active code
// page, so non-ANSI names fail. We keep behaviour identical for paths the code page CAN represent
// (call cv::imread/imwrite directly -> streaming, full codec parity); only paths it cannot represent
// take the wide route below. Reads are decoded from a memory-mapped view (the OS demand-pages, so peak
// memory stays close to cv::imread instead of slurping the whole file); writes encode in memory then
// write via a wide stream. Non-Windows keeps the plain OpenCV calls (UTF-8 paths already work there).

#ifdef _WIN32
// The C++ decode work, kept in its own function so the SEH guard below has no objects to unwind (C2712).
static bool imgcodecs_decodeImpl(const void *data, int size, int flags, cv::Mat *out)
{
    const cv::Mat src(1, size, CV_8UC1, const_cast<void*>(data));
    *out = cv::imdecode(src, flags);
    return true;
}
static bool imgcodecs_decodeMultiImpl(const void *data, int size, int flags, std::vector<cv::Mat> *mats)
{
    const cv::Mat src(1, size, CV_8UC1, const_cast<void*>(data));
    return cv::imdecodemulti(src, flags, *mats);
}
// Touching a mapped view can raise EXCEPTION_IN_PAGE_ERROR (file truncated / network read fails mid
// decode). Guard it as SEH and let the caller fall back. No C++ unwinding objects here (MSVC C2712).
static bool imgcodecs_decodeGuarded(const void *data, int size, int flags, cv::Mat *out)
{
    __try { return imgcodecs_decodeImpl(data, size, flags, out); }
    __except (GetExceptionCode() == EXCEPTION_IN_PAGE_ERROR ? EXCEPTION_EXECUTE_HANDLER : EXCEPTION_CONTINUE_SEARCH)
    { return false; }
}
static bool imgcodecs_decodeMultiGuarded(const void *data, int size, int flags, std::vector<cv::Mat> *mats)
{
    __try { return imgcodecs_decodeMultiImpl(data, size, flags, mats); }
    __except (GetExceptionCode() == EXCEPTION_IN_PAGE_ERROR ? EXCEPTION_EXECUTE_HANDLER : EXCEPTION_CONTINUE_SEARCH)
    { return false; }
}

// Maps the wide-path file and runs 'decode' over the view; on a 0-byte file, mapping failure, an SEH
// fault, or a file larger than a single Mat can hold, falls back to reading the whole file.
template <typename TDecodeGuarded, typename TDecodeBuf>
static bool imgcodecs_withWideFile(const char *utf8, TDecodeGuarded decodeGuarded, TDecodeBuf decodeBuf)
{
    const std::wstring wide = utf8ToWide(utf8);
    HANDLE hFile = CreateFileW(wide.c_str(), GENERIC_READ, FILE_SHARE_READ, nullptr, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, nullptr);
    if (hFile != INVALID_HANDLE_VALUE)
    {
        LARGE_INTEGER sz;
        if (GetFileSizeEx(hFile, &sz) && sz.QuadPart > 0 && sz.QuadPart <= 0x7fffffffLL)
        {
            HANDLE hMap = CreateFileMappingW(hFile, nullptr, PAGE_READONLY, 0, 0, nullptr);
            if (hMap != nullptr)
            {
                void *view = MapViewOfFile(hMap, FILE_MAP_READ, 0, 0, 0);
                if (view != nullptr)
                {
                    const bool ok = decodeGuarded(view, static_cast<int>(sz.QuadPart));
                    UnmapViewOfFile(view);
                    CloseHandle(hMap);
                    CloseHandle(hFile);
                    if (ok) return true; // decoded over the mapping (no SEH fault)
                    // SEH fault -> fall through to the slurp fallback below
                    std::vector<uchar> buf;
                    return readAllBytesWide(utf8, buf) && !buf.empty() && decodeBuf(buf);
                }
                CloseHandle(hMap);
            }
        }
        CloseHandle(hFile);
    }
    std::vector<uchar> buf;
    return readAllBytesWide(utf8, buf) && !buf.empty() && decodeBuf(buf);
}
#endif

CVAPI(ExceptionStatus) imgcodecs_imread(const char *filename, int flags, cv::Mat **returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    std::string acp;
    cv::Mat ret;
    if (pathRoundTripsAcp(filename, acp))
    {
        ret = cv::imread(acp, flags);
    }
    else
    {
        imgcodecs_withWideFile(filename,
            [&](const void *d, int n) { return imgcodecs_decodeGuarded(d, n, flags, &ret); },
            [&](const std::vector<uchar> &b) { ret = cv::imdecode(b, flags); return true; });
    }
    *returnValue = new cv::Mat(ret);
#else
    const auto ret = cv::imread(filename, flags);
    *returnValue = new cv::Mat(ret);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) imgcodecs_imreadmulti(const char *filename, std::vector<cv::Mat> *mats, int flags, int *returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    std::string acp;
    if (pathRoundTripsAcp(filename, acp))
    {
        *returnValue = cv::imreadmulti(acp, *mats, flags) ? 1 : 0;
    }
    else
    {
        const bool ok = imgcodecs_withWideFile(filename,
            [&](const void *d, int n) { return imgcodecs_decodeMultiGuarded(d, n, flags, mats); },
            [&](const std::vector<uchar> &b) { return cv::imdecodemulti(b, flags, *mats); });
        *returnValue = ok ? 1 : 0;
    }
#else
    *returnValue = cv::imreadmulti(filename, *mats, flags) ? 1 : 0;
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) imgcodecs_imwrite(const char *filename, cv::Mat *img, int *params, int paramsLength, int *returnValue)
{
    BEGIN_WRAP
    std::vector<int> paramsVec;
    paramsVec.assign(params, params + paramsLength);
#ifdef _WIN32
    std::string acp;
    if (pathRoundTripsAcp(filename, acp))
    {
        *returnValue = cv::imwrite(acp, *img, paramsVec) ? 1 : 0;
    }
    else
    {
        const std::string fn(filename ? filename : "");
        const auto dot = fn.find_last_of('.');
        std::vector<uchar> buf;
        *returnValue = (dot != std::string::npos && cv::imencode(fn.substr(dot), *img, buf, paramsVec)
            && writeAllBytesWide(filename, buf.data(), buf.size())) ? 1 : 0;
    }
#else
    *returnValue = cv::imwrite(filename, *img, paramsVec) ? 1 : 0;
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) imgcodecs_imwrite_multi(const char *filename, std::vector<cv::Mat> *img, int *params, int paramsLength, int *returnValue)
{
    BEGIN_WRAP
    std::vector<int> paramsVec;
    paramsVec.assign(params, params + paramsLength);
#ifdef _WIN32
    std::string acp;
    if (pathRoundTripsAcp(filename, acp))
    {
        *returnValue = cv::imwrite(acp, *img, paramsVec) ? 1 : 0;
    }
    else
    {
        const std::string fn(filename ? filename : "");
        const auto dot = fn.find_last_of('.');
        std::vector<uchar> buf;
        *returnValue = (dot != std::string::npos && cv::imencodemulti(fn.substr(dot), *img, buf, paramsVec)
            && writeAllBytesWide(filename, buf.data(), buf.size())) ? 1 : 0;
    }
#else
    *returnValue = cv::imwrite(filename, *img, paramsVec) ? 1 : 0;
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) imgcodecs_imdecode_Mat(cv::Mat *buf, int flags, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::imdecode(*buf, flags);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) imgcodecs_imdecode_vector(uchar *buf, int bufLength, int flags, cv::Mat **returnValue)
{
    BEGIN_WRAP
    //const std::vector<uchar> bufVec(buf, buf + bufLength);
    const cv::Mat bufMat(1, bufLength, CV_8UC1, buf, cv::Mat::AUTO_STEP);
    const auto ret = cv::imdecode(bufMat, flags);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) imgcodecs_imdecode_InputArray(cv::_InputArray *buf, int flags, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::imdecode(*buf, flags);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) imgcodecs_imencode_vector(
    const char *ext, cv::_InputArray *img,
    std::vector<uchar> *buf, int *params, int paramsLength, int *returnValue)
{
    BEGIN_WRAP
    std::vector<int> paramsVec;
    if (params != nullptr)
        paramsVec = std::vector<int>(params, params + paramsLength);
    *returnValue = cv::imencode(ext, *img, *buf, paramsVec) ? 1 : 0;
    END_WRAP
}



CVAPI(ExceptionStatus) imgcodecs_haveImageReader(const char *filename, int *returnValue)
{
    BEGIN_WRAP
#ifdef _WIN32
    std::string acp;
    if (pathRoundTripsAcp(filename, acp))
    {
        *returnValue = cv::haveImageReader(acp) ? 1 : 0;
    }
    else
    {
        // No narrow path OpenCV can open; probe decodability over the wide-path file instead.
        cv::Mat probe;
        imgcodecs_withWideFile(filename,
            [&](const void *d, int n) { return imgcodecs_decodeGuarded(d, n, cv::IMREAD_UNCHANGED, &probe); },
            [&](const std::vector<uchar> &b) { probe = cv::imdecode(b, cv::IMREAD_UNCHANGED); return true; });
        *returnValue = probe.empty() ? 0 : 1;
    }
#else
    *returnValue = cv::haveImageReader(filename) ? 1 : 0;
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) imgcodecs_haveImageWriter(const char *filename, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::haveImageWriter(filename) ? 1 : 0;
    END_WRAP
}
