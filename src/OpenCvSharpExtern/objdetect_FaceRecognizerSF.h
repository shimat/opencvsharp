#pragma once

#ifndef NO_OBJDETECT

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#ifndef _WINRT_DLL

#pragma region FaceRecognizerSF

CVAPI(ExceptionStatus) objdetect_FaceRecognizerSF_create(
    cv::String* model,
    cv::String* config,
    int backendId,
    int targetId,
    cv::Ptr<cv::FaceRecognizerSF>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::FaceRecognizerSF::create(*model, *config, backendId, targetId);
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) objdetect_FaceRecognizerSF_create_buffer(
    cv::String* framework,
    std::vector<uchar>* bufferModel,
    std::vector<uchar>* bufferConfig,
    int backendId,
    int targetId,
    cv::Ptr<cv::FaceRecognizerSF>** returnValue)
{
    return cvTry([&] {
        const auto p = cv::FaceRecognizerSF::create(*framework, *bufferModel, *bufferConfig, backendId, targetId);
        *returnValue = clone(p);
    });
}

CVAPI(ExceptionStatus) objdetect_Ptr_FaceRecognizerSF_delete(cv::Ptr<cv::FaceRecognizerSF>* ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) objdetect_Ptr_FaceRecognizerSF_get(cv::Ptr<cv::FaceRecognizerSF>* ptr, cv::FaceRecognizerSF** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) objdetect_FaceRecognizerSF_alignCrop(
    const cv::FaceRecognizerSF* obj,
    const interop::InputArrayProxy* srcImg,
    const interop::InputArrayProxy* faceBox,
    const interop::OutputArrayProxy* alignedImg)
{
    return cvTry([&] {
        obj->alignCrop(InProxy(*srcImg), InProxy(*faceBox), OutProxy(*alignedImg));
    });
}

CVAPI(ExceptionStatus) objdetect_FaceRecognizerSF_feature(
    cv::FaceRecognizerSF* obj,
    const interop::InputArrayProxy* alignedImg,
    const interop::OutputArrayProxy* faceFeature)
{
    return cvTry([&] {
        obj->feature(InProxy(*alignedImg), OutProxy(*faceFeature));
    });
}

CVAPI(ExceptionStatus) objdetect_FaceRecognizerSF_match(
    const cv::FaceRecognizerSF* obj,
    const interop::InputArrayProxy* faceFeature1,
    const interop::InputArrayProxy* faceFeature2,
    int disType,
    double* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->match(InProxy(*faceFeature1), InProxy(*faceFeature2), disType);
    });
}

#pragma endregion

#endif

#endif // NO_OBJDETECT
