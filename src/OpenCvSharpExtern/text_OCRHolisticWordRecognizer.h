#pragma once

#ifndef NO_CONTRIB
#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) text_Ptr_OCRHolisticWordRecognizer_delete(cv::Ptr<cv::text::OCRHolisticWordRecognizer>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) text_Ptr_OCRHolisticWordRecognizer_get(
    cv::Ptr<cv::text::OCRHolisticWordRecognizer>* ptr, cv::text::OCRHolisticWordRecognizer** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) text_OCRHolisticWordRecognizer_create(
    const char* archFilename, const char* weightsFilename, const char* wordsFilename,
    cv::Ptr<cv::text::OCRHolisticWordRecognizer>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::OCRHolisticWordRecognizer::create(
            std::string(archFilename), std::string(weightsFilename), std::string(wordsFilename));
        *returnValue = new cv::Ptr<cv::text::OCRHolisticWordRecognizer>(ptr);
    });
}

CVAPI(ExceptionStatus) text_OCRHolisticWordRecognizer_run1(
    cv::text::OCRHolisticWordRecognizer *obj,
    cv::Mat *image,
    std::string *output_text,
    std::vector<cv::Rect> *component_rects,
    std::vector<std::string> *component_texts,
    std::vector<float> *component_confidences,
    int component_level)
{
    return cvTry([&] {
        obj->run(*image, *output_text, component_rects, component_texts, component_confidences, component_level);
    });
}

CVAPI(ExceptionStatus) text_OCRHolisticWordRecognizer_run2(
    cv::text::OCRHolisticWordRecognizer *obj,
    cv::Mat *image,
    cv::Mat *mask,
    std::string *output_text,
    std::vector<cv::Rect> *component_rects,
    std::vector<std::string> *component_texts,
    std::vector<float> *component_confidences,
    int component_level)
{
    return cvTry([&] {
        obj->run(*image, *mask, *output_text, component_rects, component_texts, component_confidences, component_level);
    });
}

#endif // _WINRT_DLL
#endif // NO_CONTRIB
