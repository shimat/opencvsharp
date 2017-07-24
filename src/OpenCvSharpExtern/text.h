#ifndef _CPP_TEXT_H_
#define _CPP_TEXT_H_

#include "include_opencv.h"
using namespace cv::text;

// BaseOCR

CVAPI(void) text_BaseOCR_run1(
	BaseOCR *obj,
	cv::Mat *image, 
	std::string *output_text, 
	std::vector<cv::Rect>* component_rects,
	std::vector<std::string>* component_texts, 
	std::vector<float>* component_confidences,
	int component_level)
{
	obj->run(*image, *output_text, component_rects, component_texts, component_confidences, component_level);
}

CVAPI(void) text_BaseOCR_run2(
	BaseOCR *obj, 
	cv::Mat *image,
	cv::Mat *mask, 
	std::string *output_text, 
	std::vector<cv::Rect>* component_rects,
	std::vector<std::string>* component_texts,
	std::vector<float>* component_confidences,
	int component_level)
{
	obj->run(*image, *mask, *output_text, component_rects, component_texts, component_confidences, component_level);
}

// OCRTesseract

CVAPI(void) text_OCRTesseract_run1(
	OCRTesseract *obj,
	cv::Mat *image,
	std::string *output_text,
	std::vector<cv::Rect>* component_rects,
	std::vector<std::string>* component_texts,
	std::vector<float>* component_confidences,
	int component_level)
{
	obj->run(*image, *output_text, component_rects, component_texts, component_confidences, component_level);

}

CVAPI(void) text_OCRTesseract_run2(
	OCRTesseract *obj,
	cv::Mat *image,
	cv::Mat *mask,
	std::string *output_text,
	std::vector<cv::Rect>* component_rects,
	std::vector<std::string>* component_texts,
	std::vector<float>* component_confidences,
	int component_level)
{
	obj->run(*image, *mask, *output_text, component_rects, component_texts, component_confidences, component_level);
}

// aliases for scripting
CVAPI(void) text_OCRTesseract_run3(
	OCRTesseract *obj, 
	cv::_InputArray *image, 
	int min_confidence, 
	int component_level, 
	std::string *dst)
{
	cv::String result = obj->run(*image, min_confidence, component_level);
	dst->assign(result);
}

CVAPI(void) text_OCRTesseract_run4(
	OCRTesseract *obj, 
	cv::_InputArray *image,
	cv::_InputArray *mask, 
	int min_confidence, 
	int component_level,
	std::string *dst)
{
	cv::String result = obj->run(*image, *mask, min_confidence, component_level);
	dst->assign(result);
}

CVAPI(void) text_OCRTesseract_setWhiteList(
	OCRTesseract *obj,
	const char *char_whitelist)
{
	obj->setWhiteList(char_whitelist);
}

CVAPI(cv::Ptr<OCRTesseract>*) text_OCRTesseract_create(
	const char* datapath,
	const char* language,
	const char* char_whitelist, 
	int oem, 
	int psmode)
{
	cv::Ptr<OCRTesseract> result = OCRTesseract::create(datapath, language, char_whitelist, oem, psmode);
	return clone(result);
}

CVAPI(void) text_Ptr_OCRTesseract_delete(
    cv::Ptr<OCRTesseract> *obj)
{
    delete obj;
}

CVAPI(OCRTesseract*) text_OCRTesseract_get(
    cv::Ptr<OCRTesseract> *obj)
{
    return obj->get();
}

#endif