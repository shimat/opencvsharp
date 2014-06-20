#ifndef _CPP_PHOTO_H_
#define _CPP_PHOTO_H_

#include "include_opencv.h"

CVAPI(void) photo_inpaint(cv::_InputArray *src, cv::_InputArray *inpaintMask,
	cv::_OutputArray *dst, double inpaintRadius, int flags)
{
	cv::inpaint(*src, *inpaintMask, *dst, inpaintRadius, flags); 
}

CVAPI(void) photo_fastNlMeansDenoising(cv::_InputArray *src, cv::_OutputArray *dst, float h,
	int templateWindowSize, int searchWindowSize)
{
	cv::fastNlMeansDenoising(*src, *dst, h, templateWindowSize, searchWindowSize);
}

CVAPI(void) photo_fastNlMeansDenoisingColored(cv::_InputArray *src, cv::_OutputArray *dst,
	float h, float hColor, int templateWindowSize, int searchWindowSize)
{
	cv::fastNlMeansDenoisingColored(*src, *dst, h, hColor, templateWindowSize, searchWindowSize);
}

CVAPI(void) photo_fastNlMeansDenoisingMulti(cv::_InputArray ** srcImgs, int srcImgsLength, 
	cv::_OutputArray *dst, int imgToDenoiseIndex, int temporalWindowSize,
	float h, int templateWindowSize, int searchWindowSize)
{
	std::vector<cv::_InputArray> srcImgsVec(srcImgsLength);
	for (int i = 0; i < srcImgsLength; i++)	
		srcImgsVec[i] = *srcImgs[i];
	cv::fastNlMeansDenoisingMulti(srcImgsVec, *dst, imgToDenoiseIndex, temporalWindowSize, h, templateWindowSize, searchWindowSize);
}

CVAPI(void) photo_fastNlMeansDenoisingColoredMulti(cv::_InputArray **srcImgs, int srcImgsLength, 
	cv::_OutputArray *dst, int imgToDenoiseIndex, int temporalWindowSize,
	float h, float hColor, int templateWindowSize, int searchWindowSize)
{
	std::vector<cv::_InputArray> srcImgsVec(srcImgsLength);
	for (int i = 0; i < srcImgsLength; i++)
		srcImgsVec[i] = *srcImgs[i];
	cv::fastNlMeansDenoisingColoredMulti(srcImgsVec, *dst, imgToDenoiseIndex, temporalWindowSize, h, hColor, templateWindowSize, searchWindowSize);
}

#endif