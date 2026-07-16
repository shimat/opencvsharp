#pragma once

#ifndef NO_CONTRIB
#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// OCRBeamSearchDecoder::ClassifierCallback

CVAPI(ExceptionStatus) text_Ptr_OCRBeamSearchDecoder_ClassifierCallback_delete(cv::Ptr<cv::text::OCRBeamSearchDecoder::ClassifierCallback>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) text_Ptr_OCRBeamSearchDecoder_ClassifierCallback_get(
    cv::Ptr<cv::text::OCRBeamSearchDecoder::ClassifierCallback>* ptr, cv::text::OCRBeamSearchDecoder::ClassifierCallback** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) text_loadOCRBeamSearchClassifierCNN(const char* filename, cv::Ptr<cv::text::OCRBeamSearchDecoder::ClassifierCallback>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::loadOCRBeamSearchClassifierCNN(cv::String(filename));
        *returnValue = new cv::Ptr<cv::text::OCRBeamSearchDecoder::ClassifierCallback>(ptr);
    });
}

// OCRBeamSearchDecoder

CVAPI(ExceptionStatus) text_Ptr_OCRBeamSearchDecoder_delete(cv::Ptr<cv::text::OCRBeamSearchDecoder>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) text_Ptr_OCRBeamSearchDecoder_get(cv::Ptr<cv::text::OCRBeamSearchDecoder>* ptr, cv::text::OCRBeamSearchDecoder** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) text_OCRBeamSearchDecoder_create_callback(
    cv::Ptr<cv::text::OCRBeamSearchDecoder::ClassifierCallback>* classifier,
    const char* vocabulary,
    const interop::InputArrayProxy* transitionProbabilitiesTable,
    const interop::InputArrayProxy* emissionProbabilitiesTable,
    int mode,
    int beamSize,
    cv::Ptr<cv::text::OCRBeamSearchDecoder>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::OCRBeamSearchDecoder::create(
            *classifier, std::string(vocabulary), InProxy(*transitionProbabilitiesTable), InProxy(*emissionProbabilitiesTable),
            static_cast<cv::text::decoder_mode>(mode), beamSize);
        *returnValue = new cv::Ptr<cv::text::OCRBeamSearchDecoder>(ptr);
    });
}

CVAPI(ExceptionStatus) text_OCRBeamSearchDecoder_create_file(
    const char* filename,
    const char* vocabulary,
    const interop::InputArrayProxy* transitionProbabilitiesTable,
    const interop::InputArrayProxy* emissionProbabilitiesTable,
    int mode,
    int beamSize,
    cv::Ptr<cv::text::OCRBeamSearchDecoder>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::OCRBeamSearchDecoder::create(
            cv::String(filename), cv::String(vocabulary), InProxy(*transitionProbabilitiesTable), InProxy(*emissionProbabilitiesTable),
            static_cast<cv::text::decoder_mode>(mode), beamSize);
        *returnValue = new cv::Ptr<cv::text::OCRBeamSearchDecoder>(ptr);
    });
}

CVAPI(ExceptionStatus) text_OCRBeamSearchDecoder_run1(
    cv::text::OCRBeamSearchDecoder *obj,
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

CVAPI(ExceptionStatus) text_OCRBeamSearchDecoder_run2(
    cv::text::OCRBeamSearchDecoder *obj,
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
