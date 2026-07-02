#pragma once

#ifndef NO_CONTRIB
#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) text_TextDetector_detect(
    cv::Ptr<cv::text::TextDetector>* obj,
    const interop::InputArrayProxy* inputImage,
    std::vector<cv::Rect> *Bbox,
    std::vector<float> *confidence)
{
    return cvTry([&] {
    (*obj)->detect(InProxy(*inputImage), *Bbox, *confidence);
    });
}

CVAPI(ExceptionStatus) text_TextDetectorCNN_detect(
    cv::Ptr<cv::text::TextDetectorCNN>* obj,
    const interop::InputArrayProxy* inputImage,
    std::vector<cv::Rect> *Bbox,
    std::vector<float> *confidence)
{
    return cvTry([&] {
    (*obj)->detect(InProxy(*inputImage), *Bbox, *confidence);
    });
}

CVAPI(ExceptionStatus) text_TextDetectorCNN_create1(
    const char *modelArchFilename,
    const char *modelWeightsFilename,
    interop::Size *detectionSizes,
    int detectionSizesLength,
    cv::Ptr<cv::text::TextDetectorCNN> **returnValue)
{
    return cvTry([&] {
    std::vector<cv::Size> detectionSizesVec;
    if (detectionSizes != nullptr)
    {
        detectionSizesVec.resize(detectionSizesLength);
        for (int i = 0; i < detectionSizesLength; i++)
            detectionSizesVec[i] = cpp(detectionSizes[i]);
    }

    const auto ptr = cv::text::TextDetectorCNN::create(modelArchFilename, modelWeightsFilename, detectionSizesVec);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) text_TextDetectorCNN_create2(
    const char *modelArchFilename,
    const char *modelWeightsFilename,
    cv::Ptr<cv::text::TextDetectorCNN> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::text::TextDetectorCNN::create(modelArchFilename, modelWeightsFilename);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) text_Ptr_TextDetectorCNN_delete(cv::Ptr<cv::text::TextDetectorCNN> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}


#endif // _WINRT_DLL
#endif // NO_CONTRIB
