#pragma once

#include "include_opencv.h"
#include <opencv2/videoio/registry.hpp>

#ifndef NO_VIDEOIO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile


#pragma region IStreamReader

// Bridges a managed IStreamReader implementation to cv::IStreamReader via two C-style callbacks.
// The managed side is responsible for keeping the callback delegates alive for as long as the
// owning cv::VideoCapture may still invoke them.
class ManagedStreamReader final : public cv::IStreamReader
{
public:
    using ReadCallback = long long(*)(void* userData, unsigned char* buffer, long long size);
    using SeekCallback = long long(*)(void* userData, long long offset, int origin);

    ManagedStreamReader(const ReadCallback readCallback, const SeekCallback seekCallback, void* userData)
        : readCallback_(readCallback), seekCallback_(seekCallback), userData_(userData)
    {
    }

    long long read(char* buffer, const long long size) override
    {
        return readCallback_(userData_, reinterpret_cast<unsigned char*>(buffer), size);
    }

    long long seek(const long long offset, const int origin) override
    {
        return seekCallback_(userData_, offset, origin);
    }

private:
    ReadCallback readCallback_;
    SeekCallback seekCallback_;
    void* userData_;
};

#pragma endregion

#pragma region VideoIORegistry

CVAPI(ExceptionStatus) videoio_registry_getBackendName(int api, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(cv::videoio_registry::getBackendName(static_cast<cv::VideoCaptureAPIs>(api)));
    });
}

CVAPI(ExceptionStatus) videoio_registry_getBackends(std::vector<int> *returnValue)
{
    return cvTry([&] {
        const auto backends = cv::videoio_registry::getBackends();
        returnValue->assign(backends.begin(), backends.end());
    });
}

CVAPI(ExceptionStatus) videoio_registry_getCameraBackends(std::vector<int> *returnValue)
{
    return cvTry([&] {
        const auto backends = cv::videoio_registry::getCameraBackends();
        returnValue->assign(backends.begin(), backends.end());
    });
}

CVAPI(ExceptionStatus) videoio_registry_getStreamBackends(std::vector<int> *returnValue)
{
    return cvTry([&] {
        const auto backends = cv::videoio_registry::getStreamBackends();
        returnValue->assign(backends.begin(), backends.end());
    });
}

CVAPI(ExceptionStatus) videoio_registry_getStreamBufferedBackends(std::vector<int> *returnValue)
{
    return cvTry([&] {
        const auto backends = cv::videoio_registry::getStreamBufferedBackends();
        returnValue->assign(backends.begin(), backends.end());
    });
}

CVAPI(ExceptionStatus) videoio_registry_getWriterBackends(std::vector<int> *returnValue)
{
    return cvTry([&] {
        const auto backends = cv::videoio_registry::getWriterBackends();
        returnValue->assign(backends.begin(), backends.end());
    });
}

CVAPI(ExceptionStatus) videoio_registry_hasBackend(int api, int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::videoio_registry::hasBackend(static_cast<cv::VideoCaptureAPIs>(api)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_registry_isBackendBuiltIn(int api, int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::videoio_registry::isBackendBuiltIn(static_cast<cv::VideoCaptureAPIs>(api)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_registry_getCameraBackendPluginVersion(
    int api, int *versionAbi, int *versionApi, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(cv::videoio_registry::getCameraBackendPluginVersion(
            static_cast<cv::VideoCaptureAPIs>(api), *versionAbi, *versionApi));
    });
}

CVAPI(ExceptionStatus) videoio_registry_getStreamBackendPluginVersion(
    int api, int *versionAbi, int *versionApi, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(cv::videoio_registry::getStreamBackendPluginVersion(
            static_cast<cv::VideoCaptureAPIs>(api), *versionAbi, *versionApi));
    });
}

CVAPI(ExceptionStatus) videoio_registry_getStreamBufferedBackendPluginVersion(
    int api, int *versionAbi, int *versionApi, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(cv::videoio_registry::getStreamBufferedBackendPluginVersion(
            static_cast<cv::VideoCaptureAPIs>(api), *versionAbi, *versionApi));
    });
}

CVAPI(ExceptionStatus) videoio_registry_getWriterBackendPluginVersion(
    int api, int *versionAbi, int *versionApi, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(cv::videoio_registry::getWriterBackendPluginVersion(
            static_cast<cv::VideoCaptureAPIs>(api), *versionAbi, *versionApi));
    });
}

#pragma endregion

#pragma region VideoCapture

CVAPI(ExceptionStatus) videoio_VideoCapture_new1(cv::VideoCapture **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::VideoCapture;
    });
}
CVAPI(ExceptionStatus) videoio_VideoCapture_new2(
    const char *filename,
    int apiPreference,
    cv::VideoCapture **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::VideoCapture(filename, apiPreference);
    });
}
CVAPI(ExceptionStatus) videoio_VideoCapture_new3(
    int device,
    int apiPreference,
    cv::VideoCapture **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::VideoCapture(device, apiPreference);
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_new4(
    const char* filename,
    int apiPreference,
    int* params,
    int paramsLength,
    cv::VideoCapture** returnValue)
{
    return cvTry([&] {
        std::string filenameStr(filename);
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        * returnValue = new cv::VideoCapture(filenameStr, apiPreference, paramsVec);
    });
}
CVAPI(ExceptionStatus) videoio_VideoCapture_new5(
    int device,
    int apiPreference,
    int* params,
    int paramsLength,
    cv::VideoCapture** returnValue)
{
    return cvTry([&] {
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        * returnValue = new cv::VideoCapture(device, apiPreference, paramsVec);
    });
}


CVAPI(ExceptionStatus) videoio_VideoCapture_new6(
    ManagedStreamReader::ReadCallback readCallback,
    ManagedStreamReader::SeekCallback seekCallback,
    void* userData,
    int apiPreference,
    int* params,
    int paramsLength,
    cv::VideoCapture** returnValue)
{
    return cvTry([&] {
        const cv::Ptr<cv::IStreamReader> reader = cv::makePtr<ManagedStreamReader>(readCallback, seekCallback, userData);
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        *returnValue = new cv::VideoCapture(reader, apiPreference, paramsVec);
    });
}


CVAPI(ExceptionStatus) videoio_VideoCapture_delete(cv::VideoCapture *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


CVAPI(ExceptionStatus) videoio_VideoCapture_open1(
    cv::VideoCapture *obj,
    const char *filename,
    int apiPreference,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->open(filename, apiPreference) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_open2(
    cv::VideoCapture *obj,
    int device,
    int apiPreference,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->open(device, apiPreference) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_open3(
    cv::VideoCapture *obj,
    ManagedStreamReader::ReadCallback readCallback,
    ManagedStreamReader::SeekCallback seekCallback,
    void* userData,
    int apiPreference,
    int* params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
        const cv::Ptr<cv::IStreamReader> reader = cv::makePtr<ManagedStreamReader>(readCallback, seekCallback, userData);
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        *returnValue = obj->open(reader, apiPreference, paramsVec) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_open4(
    cv::VideoCapture *obj,
    const char *filename,
    int apiPreference,
    int* params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        *returnValue = obj->open(std::string(filename), apiPreference, paramsVec) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_isOpened(cv::VideoCapture *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isOpened() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_release(cv::VideoCapture *obj)
{
    return cvTry([&] {
        obj->release();
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_grab(cv::VideoCapture *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->grab() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_retrieve_OutputArray(
    cv::VideoCapture *obj,
    const interop::OutputArrayProxy* image,
    int flag,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->retrieve(OutProxy(*image), flag) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_retrieve_Mat(
    cv::VideoCapture *obj,
    cv::Mat *image,
    int flag,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->retrieve(*image, flag) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_operatorRightShift_Mat(cv::VideoCapture *obj, cv::Mat *image)
{
    return cvTry([&] {
        (*obj) >> (*image);
    });
}
/*CVAPI(ExceptionStatus) videoio_VideoCapture_operatorRightShift_UMat(cv::VideoCapture *obj, cv::UMat *image)
{
    return cvTry([&] {
        (*obj) >> (*image);
    });
}*/

CVAPI(ExceptionStatus) videoio_VideoCapture_read_OutputArray(
    cv::VideoCapture *obj,
    const interop::OutputArrayProxy* image,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->read(OutProxy(*image)) ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) videoio_VideoCapture_read_Mat(
    cv::VideoCapture *obj,
    cv::Mat *image,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->read(*image) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_set(
    cv::VideoCapture *obj,
    int propId,
    double value,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->set(propId, value) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_get(
    cv::VideoCapture *obj,
    int propId,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get(propId);
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_getBackendName(cv::VideoCapture *obj, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(obj->getBackendName());
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_setExceptionMode(cv::VideoCapture *obj, int enable)
{
    return cvTry([&] {
        obj->setExceptionMode(enable != 0);
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_getExceptionMode(cv::VideoCapture *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getExceptionMode() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoCapture_waitAny(
    cv::VideoCapture** streams,
    const size_t streamsSize,
    std::vector<int> *readyIndex,
    const int64 timeoutNs,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<cv::VideoCapture> streamsVec(streamsSize);
        for (size_t i = 0; i < streamsSize; i++)
            streamsVec[i] = *streams[i];

        *returnValue = cv::VideoCapture::waitAny(streamsVec, *readyIndex, timeoutNs) ? 1 : 0;
    });
}

#pragma endregion

#pragma region VideoWriter

CVAPI(ExceptionStatus) videoio_VideoWriter_new1(cv::VideoWriter **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::VideoWriter;
    });
}
CVAPI(ExceptionStatus) videoio_VideoWriter_new2(
    const char *filename,
    int fourcc,
    double fps,
    interop::Size frameSize,
    int isColor,
    cv::VideoWriter **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::VideoWriter(filename, fourcc, fps, cpp(frameSize), isColor != 0);
    });
}
CVAPI(ExceptionStatus) videoio_VideoWriter_new3(
    const char *filename,
    int apiPreference,
    int fourcc,
    double fps,
    interop::Size frameSize,
    int isColor,
    cv::VideoWriter **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::VideoWriter(filename, apiPreference, fourcc, fps, cpp(frameSize), isColor != 0);
    });
}
CVAPI(ExceptionStatus) videoio_VideoWriter_new4(
    const char* filename,
    int fourcc,
    double fps,
    interop::Size frameSize,
    int* params,
    int paramsLength,
    cv::VideoWriter** returnValue)
{
    return cvTry([&] {
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        * returnValue = new cv::VideoWriter(filename, fourcc, fps, cpp(frameSize), paramsVec);
    });
}
CVAPI(ExceptionStatus) videoio_VideoWriter_new5(
    const char* filename,
    int apiPreference,
    int fourcc,
    double fps,
    interop::Size frameSize,
    int* params,
    int paramsLength,
    cv::VideoWriter** returnValue)
{
    return cvTry([&] {
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        * returnValue = new cv::VideoWriter(filename, apiPreference, fourcc, fps, cpp(frameSize), paramsVec);
    });
}

CVAPI(ExceptionStatus) videoio_VideoWriter_delete(cv::VideoWriter *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) videoio_VideoWriter_open1(
    cv::VideoWriter *obj,
    const char *filename,
    int fourcc,
    double fps,
    interop::Size frameSize,
    int isColor,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->open(filename, fourcc, fps, cpp(frameSize), isColor != 0) ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) videoio_VideoWriter_open2(
    cv::VideoWriter *obj,
    const char *filename,
    int apiPreference,
    int fourcc,
    double fps,
    interop::Size frameSize,
    int isColor,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->open(filename, apiPreference, fourcc, fps, cpp(frameSize), isColor != 0) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoWriter_open4(
    cv::VideoWriter *obj,
    const char* filename,
    int apiPreference,
    int fourcc,
    double fps,
    interop::Size frameSize,
    int* params,
    int paramsLength,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<int> paramsVec;
        paramsVec.assign(params, params + paramsLength);
        *returnValue = obj->open(filename, apiPreference, fourcc, fps, cpp(frameSize), paramsVec) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoWriter_isOpened(cv::VideoWriter *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isOpened() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoWriter_release(cv::VideoWriter *obj)
{
    return cvTry([&] {
        obj->release();
    });
}

/*CVAPI(ExceptionStatus) videoio_VideoWriter_OperatorLeftShift(cv::VideoWriter *obj, cv::Mat *image)
{
    return cvTry([&] {
        (*obj) << (*image);
    });
}*/

CVAPI(ExceptionStatus) videoio_VideoWriter_write(cv::VideoWriter *obj, const interop::InputArrayProxy* image, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->write(InProxy(*image)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoWriter_set(
    cv::VideoWriter *obj,
    int propId,
    double value,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->set(propId, value) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) videoio_VideoWriter_get(
    cv::VideoWriter *obj,
    int propId,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get(propId);
    });
}

CVAPI(ExceptionStatus) videoio_VideoWriter_fourcc(
    char c1,
    char c2,
    char c3,
    char c4,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::VideoWriter::fourcc(c1, c2, c3, c4);
    });
}

CVAPI(ExceptionStatus) videoio_VideoWriter_getBackendName(cv::VideoWriter *obj, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(obj->getBackendName());
    });
}

#pragma endregion

#endif // NO_VIDEOIO
