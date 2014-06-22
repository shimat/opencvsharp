#if WIN32
#pragma once
#endif

#ifndef _CPP_GPU_CVMETHODS_H_
#define _CPP_GPU_CVMETHODS_H_

#include "include_opencv.h"
using namespace cv::gpu;


CVAPI(void) gpu_minMaxLoc1(
	GpuMat *src, double *minVal, double *maxVal, cv::Point *minLoc, cv::Point *maxLoc,
	GpuMat *mask)
{
	minMaxLoc(*src, minVal, maxVal, minLoc, maxLoc, entity(mask));
}

CVAPI(void) gpu_minMaxLoc2(
	GpuMat *src, double *minVal, double *maxVal, cv::Point *minLoc, cv::Point *maxLoc,
	GpuMat *mask, GpuMat *valbuf, GpuMat *locbuf)
{
	minMaxLoc(*src, minVal, maxVal, minLoc, maxLoc, *valbuf, *locbuf, entity(mask));
}

CVAPI(void) gpu_matchTemplate1(
	GpuMat *image, GpuMat *templ, GpuMat *result, int method, Stream *stream)
{
	matchTemplate(*image, *templ, *result, method, entity(stream));
}

CVAPI(void) gpu_matchTemplate2(
	GpuMat *image, GpuMat *templ, GpuMat *result, int method, MatchTemplateBuf *buf, Stream *stream)
{
	matchTemplate(*image, *templ, *result, method, *buf, entity(stream));
}

#endif
