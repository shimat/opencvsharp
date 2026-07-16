#pragma once

#ifndef NO_CONTRIB
#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// OCRHMMDecoder::ClassifierCallback

CVAPI(ExceptionStatus) text_Ptr_OCRHMMDecoder_ClassifierCallback_delete(cv::Ptr<cv::text::OCRHMMDecoder::ClassifierCallback>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) text_Ptr_OCRHMMDecoder_ClassifierCallback_get(
    cv::Ptr<cv::text::OCRHMMDecoder::ClassifierCallback>* ptr, cv::text::OCRHMMDecoder::ClassifierCallback** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) text_loadOCRHMMClassifierNM(const char* filename, cv::Ptr<cv::text::OCRHMMDecoder::ClassifierCallback>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::loadOCRHMMClassifierNM(cv::String(filename));
        *returnValue = new cv::Ptr<cv::text::OCRHMMDecoder::ClassifierCallback>(ptr);
    });
}

CVAPI(ExceptionStatus) text_loadOCRHMMClassifierCNN(const char* filename, cv::Ptr<cv::text::OCRHMMDecoder::ClassifierCallback>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::loadOCRHMMClassifierCNN(cv::String(filename));
        *returnValue = new cv::Ptr<cv::text::OCRHMMDecoder::ClassifierCallback>(ptr);
    });
}

CVAPI(ExceptionStatus) text_loadOCRHMMClassifier(const char* filename, int classifier, cv::Ptr<cv::text::OCRHMMDecoder::ClassifierCallback>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::loadOCRHMMClassifier(cv::String(filename), classifier);
        *returnValue = new cv::Ptr<cv::text::OCRHMMDecoder::ClassifierCallback>(ptr);
    });
}

// OCRHMMDecoder

CVAPI(ExceptionStatus) text_Ptr_OCRHMMDecoder_delete(cv::Ptr<cv::text::OCRHMMDecoder>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) text_Ptr_OCRHMMDecoder_get(cv::Ptr<cv::text::OCRHMMDecoder>* ptr, cv::text::OCRHMMDecoder** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) text_OCRHMMDecoder_create_callback(
    cv::Ptr<cv::text::OCRHMMDecoder::ClassifierCallback>* classifier,
    const char* vocabulary,
    const interop::InputArrayProxy* transitionProbabilitiesTable,
    const interop::InputArrayProxy* emissionProbabilitiesTable,
    int mode,
    cv::Ptr<cv::text::OCRHMMDecoder>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::OCRHMMDecoder::create(
            *classifier, cv::String(vocabulary), InProxy(*transitionProbabilitiesTable), InProxy(*emissionProbabilitiesTable), mode);
        *returnValue = new cv::Ptr<cv::text::OCRHMMDecoder>(ptr);
    });
}

CVAPI(ExceptionStatus) text_OCRHMMDecoder_create_file(
    const char* filename,
    const char* vocabulary,
    const interop::InputArrayProxy* transitionProbabilitiesTable,
    const interop::InputArrayProxy* emissionProbabilitiesTable,
    int mode,
    int classifier,
    cv::Ptr<cv::text::OCRHMMDecoder>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::text::OCRHMMDecoder::create(
            cv::String(filename), cv::String(vocabulary), InProxy(*transitionProbabilitiesTable), InProxy(*emissionProbabilitiesTable), mode, classifier);
        *returnValue = new cv::Ptr<cv::text::OCRHMMDecoder>(ptr);
    });
}

CVAPI(ExceptionStatus) text_OCRHMMDecoder_run1(
    cv::text::OCRHMMDecoder *obj,
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

CVAPI(ExceptionStatus) text_OCRHMMDecoder_run2(
    cv::text::OCRHMMDecoder *obj,
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

// createOCRHMMTransitionsTable

CVAPI(ExceptionStatus) text_createOCRHMMTransitionsTable(
    const char* vocabulary, std::vector<std::string>* lexicon, cv::Mat** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(cv::text::createOCRHMMTransitionsTable(cv::String(vocabulary), *lexicon));
    });
}

#endif // _WINRT_DLL
#endif // NO_CONTRIB
