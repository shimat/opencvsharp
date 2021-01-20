#pragma once

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) text_TextDetector_detect(cv::text::TextDetector *obj, cv::_InputArray *inputImage, std::vector<cv::Rect> *Bbox, std::vector<float> *confidence)
{
    BEGIN_WRAP
    obj->detect(*inputImage, *Bbox, *confidence);
    END_WRAP
}

CVAPI(ExceptionStatus) text_TextDetectorCNN_detect(cv::text::TextDetectorCNN *obj, cv::_InputArray *inputImage, std::vector<cv::Rect> *Bbox, std::vector<float> *confidence)
{
    BEGIN_WRAP
    obj->detect(*inputImage, *Bbox, *confidence);
    END_WRAP
}

CVAPI(ExceptionStatus) text_TextDetectorCNN_create1(
    const char *modelArchFilename, const char *modelWeightsFilename, MyCvSize *detectionSizes, int detectionSizesLength,
    cv::Ptr<cv::text::TextDetectorCNN> **returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Size> detectionSizesVec;
    if (detectionSizes != nullptr)
    {
        detectionSizesVec.resize(detectionSizesLength);
        for (int i = 0; i < detectionSizesLength; i++)
            detectionSizesVec[i] = cpp(detectionSizes[i]);
    }

    const auto ptr = cv::text::TextDetectorCNN::create(modelArchFilename, modelWeightsFilename, detectionSizesVec);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) text_TextDetectorCNN_create2(
    const char *modelArchFilename, const char *modelWeightsFilename, cv::Ptr<cv::text::TextDetectorCNN> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::text::TextDetectorCNN::create(modelArchFilename, modelWeightsFilename);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) text_Ptr_TextDetectorCNN_delete(cv::Ptr<cv::text::TextDetectorCNN> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) text_Ptr_TextDetectorCNN_get(cv::Ptr<cv::text::TextDetectorCNN>* obj, cv::text::TextDetectorCNN **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

#endif // !#ifndef _WINRT_DLL
