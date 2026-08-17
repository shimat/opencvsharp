#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#ifndef _WINRT_DLL

#pragma region FaceDetectorYN

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_create(
    cv::String* model,
    cv::String* config,
    interop::Size* inputSize,
    float scoreThreshold,
    float nmsThreshold,
    int topK,
    int backendId,
    int targetId,
    cv::Ptr<cv::FaceDetectorYN>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::FaceDetectorYN::create(
            *model, *config, cpp(*inputSize),
            scoreThreshold, nmsThreshold, topK,
            backendId, targetId);
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_create_buffer(
    cv::String* framework,
    std::vector<uchar>* bufferModel,
    std::vector<uchar>* bufferConfig,
    const interop::Size inputSize,
    float scoreThreshold,
    float nmsThreshold,
    int topK,
    int backendId,
    int targetId,
    cv::Ptr<cv::FaceDetectorYN>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::FaceDetectorYN::create(
            *framework, *bufferModel, *bufferConfig, cpp(inputSize),
            scoreThreshold, nmsThreshold, topK,
            backendId, targetId);
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) objdetect_Ptr_FaceDetectorYN_delete(cv::Ptr<cv::FaceDetectorYN>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) objdetect_Ptr_FaceDetectorYN_get(cv::Ptr<cv::FaceDetectorYN>* ptr, cv::FaceDetectorYN** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_setInputSize(
    cv::FaceDetectorYN* obj,
    const interop::Size inputSize)
{
    return cvTry([&] {
        obj->setInputSize(cpp(inputSize));
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_getInputSize(
    cv::FaceDetectorYN* obj,
    interop::Size* returnValue)
{
    return cvTry([&] {
        *returnValue = c(obj->getInputSize());
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_setScoreThreshold(
    cv::FaceDetectorYN* obj,
    float scoreThreshold)
{
    return cvTry([&] {
        obj->setScoreThreshold(scoreThreshold);
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_getScoreThreshold(
    cv::FaceDetectorYN* obj,
    float* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getScoreThreshold();
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_setNMSThreshold(
    cv::FaceDetectorYN* obj,
    float nmsThreshold)
{
    return cvTry([&] {
        obj->setNMSThreshold(nmsThreshold);
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_getNMSThreshold(
    cv::FaceDetectorYN* obj,
    float* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNMSThreshold();
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_setTopK(
    cv::FaceDetectorYN* obj,
    int topK)
{
    return cvTry([&] {
        obj->setTopK(topK);
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_getTopK(
    cv::FaceDetectorYN* obj,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getTopK();
    });
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_detect(
    cv::FaceDetectorYN* obj,
    const interop::InputArrayProxy* image,
    const interop::OutputArrayProxy* faces,
    int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->detect(InProxy(*image), OutProxy(*faces));
    });
}

#pragma endregion

#endif

#endif // NO_OBJDETECT
