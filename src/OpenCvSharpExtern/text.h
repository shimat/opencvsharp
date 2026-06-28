#pragma once

#ifndef NO_CONTRIB
#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// OCRTesseract

CVAPI(ExceptionStatus) text_OCRTesseract_run1(
    cv::text::OCRTesseract *obj,
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

CVAPI(ExceptionStatus) text_OCRTesseract_run2(
    cv::text::OCRTesseract *obj,
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

/*CVAPI(ExceptionStatus) text_OCRTesseract_run3(
    cv::Ptr<cv::text::OCRTesseract>* obj, 
    cv::_InputArray *image, 
    int min_confidence, 
    int component_level, 
    std::string *dst)
{
    return cvTry([&] {
    const auto result = (*obj)->run(*image, min_confidence, component_level);
    dst->assign(result);
    });
}*/

/*CVAPI(ExceptionStatus) text_OCRTesseract_run4(
    cv::Ptr<cv::text::OCRTesseract>* obj, 
    cv::_InputArray *image,
    cv::_InputArray *mask, 
    int min_confidence, 
    int component_level,
    std::string *dst)
{
    return cvTry([&] {
    const auto result = (*obj)->run(*image, *mask, min_confidence, component_level);
    dst->assign(result);
    });
}*/

CVAPI(ExceptionStatus) text_OCRTesseract_setWhiteList(
    cv::text::OCRTesseract* obj,
    const char *char_whitelist)
{
    return cvTry([&] {
    obj->setWhiteList(char_whitelist);
    });
}

CVAPI(ExceptionStatus) text_OCRTesseract_create(
    const char* datapath,
    const char* language,
    const char* char_whitelist, 
    int oem, 
    int psmode,
    cv::Ptr<cv::text::OCRTesseract> **returnValue)
{
    return cvTry([&] {
    const auto result = cv::text::OCRTesseract::create(datapath, language, char_whitelist, oem, psmode);
    *returnValue = clone(result);
    });
}

CVAPI(ExceptionStatus) text_Ptr_OCRTesseract_get(
    cv::Ptr<cv::text::OCRTesseract> *ptr, cv::text::OCRTesseract **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) text_Ptr_OCRTesseract_delete(
    cv::Ptr<cv::text::OCRTesseract> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

#pragma region swt_text_detection.hpp

CVAPI(ExceptionStatus) text_detectTextSWT(
    cv::_InputArray *input, std::vector<cv::Rect> *result, int dark_on_light, cv::_OutputArray *draw, cv::_OutputArray *chainBBs)
{
    return cvTry([&] {
    cv::text::detectTextSWT(*input, *result, dark_on_light != 0, entity(draw), entity(chainBBs));
    });    
}

#pragma endregion

#endif // _WINRT_DLL
#endif // NO_CONTRIB
