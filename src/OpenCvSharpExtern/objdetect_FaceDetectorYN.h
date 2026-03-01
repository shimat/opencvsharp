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
    CvSize* inputSize,
    float scoreThreshold,
    float nmsThreshold,
    int topK,
    int backendId,
    int targetId,
    cv::Ptr<cv::FaceDetectorYN>** returnValue)
{
    BEGIN_WRAP
    const auto p = cv::FaceDetectorYN::create(
        *model, *config, *inputSize,
        scoreThreshold, nmsThreshold, topK,
        backendId, targetId);
    *returnValue = clone(p);
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_Ptr_FaceDetectorYN_delete(cv::Ptr<cv::FaceDetectorYN>* ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_Ptr_FaceDetectorYN_get(
    cv::Ptr<cv::FaceDetectorYN>* ptr, cv::FaceDetectorYN** returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) objdetect_FaceDetectorYN_detect(
    cv::FaceDetectorYN* obj, cv::_InputArray* image, cv::_OutputArray* faces, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->detect(*image, *faces);
    END_WRAP
}

#pragma endregion

#endif

#endif // NO_OBJDETECT
