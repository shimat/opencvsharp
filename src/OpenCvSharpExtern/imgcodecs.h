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

CVAPI(ExceptionStatus) imgcodecs_imread(
    const char *filename,
    int flags,
    cv::Mat **returnValue)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) imgcodecs_imreadmulti(
    const char *filename,
    std::vector<cv::Mat> *mats,
    int flags,
    int *returnValue)
{
    return cvTry([&] {
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
    });
}

// cv::imcount only scans the header (cheap) when given a real file path it can fopen, and it has no
// buffer overload. On Windows, if 'filename' can't be represented in the process ANSI code page,
// *acpOk is set to 0 and *returnValue to 0 without calling cv::imcount at all; the managed caller is
// expected to retry by copying the source file to an ASCII-safe temp path (plain managed File I/O
// handles arbitrary Unicode paths natively - no wide-path plumbing needed on this side) and calling
// this function again with that path.
CVAPI(ExceptionStatus) imgcodecs_imcount(
    const char *filename,
    int flags,
    int *acpOk,
    size_t *returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        std::string acp;
        if (pathRoundTripsAcp(filename, acp))
        {
            *acpOk = 1;
            *returnValue = cv::imcount(acp, flags);
        }
        else
        {
            *acpOk = 0;
            *returnValue = 0;
        }
#else
        *acpOk = 1;
        *returnValue = cv::imcount(filename, flags);
#endif
    });
}

CVAPI(ExceptionStatus) imgcodecs_imreadmulti_range(
    const char *filename,
    std::vector<cv::Mat> *mats,
    int start,
    int count,
    int flags,
    int *acpOk,
    int *returnValue)
{
    return cvTry([&] {
#ifdef _WIN32
        // On a non-representable path, do nothing and report acpOk=0; the managed caller retries by
        // copying the source to an ASCII-safe temp path (plain managed File I/O handles arbitrary
        // Unicode paths natively) and calling this function again with that path.
        std::string acp;
        if (pathRoundTripsAcp(filename, acp))
        {
            *acpOk = 1;
            *returnValue = cv::imreadmulti(acp, *mats, start, count, flags) ? 1 : 0;
        }
        else
        {
            *acpOk = 0;
            *returnValue = 0;
        }
#else
        *acpOk = 1;
        *returnValue = cv::imreadmulti(filename, *mats, start, count, flags) ? 1 : 0;
#endif
    });
}

// See imgcodecs_imreadmulti_range for the acpOk/managed-retry contract.
CVAPI(ExceptionStatus) imgcodecs_imreadWithMetadata(
    const char *filename,
    std::vector<int> *metadataTypes,
    std::vector<cv::Mat> *metadata,
    int flags,
    int *acpOk,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        cv::Mat ret;
#ifdef _WIN32
        std::string acp;
        if (pathRoundTripsAcp(filename, acp))
        {
            *acpOk = 1;
            ret = cv::imreadWithMetadata(acp, *metadataTypes, *metadata, flags);
        }
        else
        {
            *acpOk = 0;
        }
#else
        *acpOk = 1;
        ret = cv::imreadWithMetadata(filename, *metadataTypes, *metadata, flags);
#endif
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) imgcodecs_imwrite(
    const char *filename,
    cv::Mat *img,
    int *params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) imgcodecs_imwrite_multi(
    const char *filename,
    std::vector<cv::Mat> *img,
    int *params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) imgcodecs_imwriteWithMetadata(
    const char *filename,
    cv::Mat *img,
    int *metadataTypes,
    int metadataTypesLength,
    std::vector<cv::Mat> *metadata,
    int *params,
    int paramsLength,
    int *acpOk,
    int *returnValue)
{
    return cvTry([&] {
        const std::vector<int> metadataTypesVec(metadataTypes, metadataTypes + metadataTypesLength);
        const std::vector<int> paramsVec(params, params + paramsLength);
        cv::_InputArray metadataArr(*metadata);
#ifdef _WIN32
        // On a non-representable path, do nothing and report acpOk=0; the managed caller retries by
        // writing to an ASCII-safe temp path and moving it to the real destination (plain managed
        // File I/O handles arbitrary Unicode destination paths natively).
        std::string acp;
        if (pathRoundTripsAcp(filename, acp))
        {
            *acpOk = 1;
            *returnValue = cv::imwriteWithMetadata(acp, *img, metadataTypesVec, metadataArr, paramsVec) ? 1 : 0;
        }
        else
        {
            *acpOk = 0;
            *returnValue = 0;
        }
#else
        *acpOk = 1;
        *returnValue = cv::imwriteWithMetadata(filename, *img, metadataTypesVec, metadataArr, paramsVec) ? 1 : 0;
#endif
    });
}

CVAPI(ExceptionStatus) imgcodecs_imdecode_Mat(
    cv::Mat *buf,
    int flags,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto ret = cv::imdecode(*buf, flags);
        *returnValue = new cv::Mat(ret);
    });
}
CVAPI(ExceptionStatus) imgcodecs_imdecode_vector(
    uchar *buf,
    int bufLength,
    int flags,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        //const std::vector<uchar> bufVec(buf, buf + bufLength);
        const cv::Mat bufMat(1, bufLength, CV_8UC1, buf, cv::Mat::AUTO_STEP);
        const auto ret = cv::imdecode(bufMat, flags);
        *returnValue = new cv::Mat(ret);
    });
}
CVAPI(ExceptionStatus) imgcodecs_imdecode_InputArray(
    const interop::InputArrayProxy* buf,
    int flags,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto ret = cv::imdecode(InProxy(*buf), flags);
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) imgcodecs_imdecodemulti(
    const interop::InputArrayProxy* buf,
    int flags,
    std::vector<cv::Mat> *mats,
    interop::Range range,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::imdecodemulti(InProxy(*buf), flags, *mats, cpp(range)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) imgcodecs_imdecodeWithMetadata(
    const interop::InputArrayProxy* buf,
    std::vector<int> *metadataTypes,
    std::vector<cv::Mat> *metadata,
    int flags,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        cv::_OutputArray metadataArr(*metadata);
        const auto ret = cv::imdecodeWithMetadata(InProxy(*buf), *metadataTypes, metadataArr, flags);
        *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) imgcodecs_imencode_vector(
    const char *ext,
    const interop::InputArrayProxy* img,
    std::vector<uchar> *buf,
    int *params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<int> paramsVec;
        if (params != nullptr)
            paramsVec = std::vector<int>(params, params + paramsLength);
        *returnValue = cv::imencode(ext, InProxy(*img), *buf, paramsVec) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) imgcodecs_imencodeWithMetadata(
    const char *ext,
    const interop::InputArrayProxy* img,
    int *metadataTypes,
    int metadataTypesLength,
    std::vector<cv::Mat> *metadata,
    std::vector<uchar> *buf,
    int *params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
        const std::vector<int> metadataTypesVec(metadataTypes, metadataTypes + metadataTypesLength);
        std::vector<int> paramsVec;
        if (params != nullptr)
            paramsVec = std::vector<int>(params, params + paramsLength);
        cv::_InputArray metadataArr(*metadata);
        *returnValue = cv::imencodeWithMetadata(ext, InProxy(*img), metadataTypesVec, metadataArr, *buf, paramsVec) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) imgcodecs_imencodemulti(
    const char *ext,
    std::vector<cv::Mat> *imgs,
    std::vector<uchar> *buf,
    int *params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<int> paramsVec;
        if (params != nullptr)
            paramsVec = std::vector<int>(params, params + paramsLength);
        *returnValue = cv::imencodemulti(ext, *imgs, *buf, paramsVec) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) imgcodecs_haveImageReader(const char *filename, int *returnValue)
{
    return cvTry([&] {
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
    });
}

CVAPI(ExceptionStatus) imgcodecs_haveImageWriter(const char *filename, int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::haveImageWriter(filename) ? 1 : 0;
    });
}
