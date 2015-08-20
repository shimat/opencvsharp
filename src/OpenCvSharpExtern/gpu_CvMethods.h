#ifndef _CPP_GPU_CVMETHODS_H_
#define _CPP_GPU_CVMETHODS_H_

#include "include_opencv.h"
using namespace cv::gpu;


//////////////////////////////// Filter Engine ////////////////////////////////

CVAPI(void) gpu_boxFilter(GpuMat *src, GpuMat *dst, int ddepth, cv::Size ksize, cv::Point anchor, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::boxFilter(*src, *dst, ddepth, ksize, anchor, stream0);
}

CVAPI(void) gpu_erode1(GpuMat *src, GpuMat *dst, cv::Mat *kernel, cv::Point anchor, int iterations)
{
    cv::gpu::erode(*src, *dst, *kernel, anchor, iterations);
}
CVAPI(void) gpu_erode2(
	GpuMat *src, GpuMat *dst, cv::Mat *kernel, GpuMat *buf,
	cv::Point anchor, int iterations, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::erode(*src, *dst, *kernel, *buf, anchor, iterations, stream0);
}

CVAPI(void) gpu_dilate1(GpuMat *src, GpuMat *dst, cv::Mat *kernel, cv::Point anchor, int iterations)
{
	cv::gpu::dilate(*src, *dst, *kernel, anchor, iterations);
}
CVAPI(void) gpu_dilate2(
	GpuMat *src, GpuMat *dst, cv::Mat *kernel, GpuMat *buf,
	cv::Point anchor, int iterations, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::dilate(*src, *dst, *kernel, *buf, anchor, iterations, stream0);
}

CVAPI(void) gpu_morphologyEx1(
    GpuMat *src, GpuMat *dst, int op, cv::Mat *kernel, cv::Point anchor, int iterations)
{
    cv::gpu::morphologyEx(*src, *dst, op, *kernel, anchor, iterations);
}
CVAPI(void) gpu_morphologyEx2(
	GpuMat *src, GpuMat *dst, int op, cv::Mat *kernel, GpuMat *buf1, GpuMat *buf2,
	cv::Point anchor, int iterations, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::morphologyEx(*src, *dst, op, *kernel, *buf1, *buf2, anchor, iterations, stream0);
}

CVAPI(void) gpu_filter2D(
	GpuMat *src, GpuMat *dst, int ddepth, cv::Mat *kernel, cv::Point anchor, int borderType, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::filter2D(*src, *dst, ddepth, *kernel, anchor, borderType, stream0);
}

CVAPI(void) gpu_sepFilter2D1(GpuMat *src, GpuMat *dst, int ddepth, cv::Mat *kernelX, cv::Mat *kernelY,
	cv::Point anchor, int rowBorderType, int columnBorderType)
{
	cv::gpu::sepFilter2D(*src, *dst, ddepth, *kernelX, *kernelY, anchor, rowBorderType, columnBorderType);
}
CVAPI(void) gpu_sepFilter2D2(GpuMat *src, GpuMat *dst, int ddepth, cv::Mat *kernelX, cv::Mat *kernelY,
	GpuMat *buf, cv::Point anchor, int rowBorderType, int columnBorderType, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::sepFilter2D(*src, *dst, ddepth, *kernelX, *kernelY, *buf, anchor, rowBorderType, columnBorderType, stream0);
}

CVAPI(void) gpu_Sobel1(GpuMat *src, GpuMat *dst, int ddepth, int dx, int dy, int ksize, double scale,
	int rowBorderType, int columnBorderType)
{
	cv::gpu::Sobel(*src, *dst, ddepth, dx, dy, ksize, scale, rowBorderType, columnBorderType);
}
CVAPI(void) gpu_Sobel2(GpuMat *src, GpuMat *dst, int ddepth, int dx, int dy, GpuMat *buf, int ksize, 
	double scale, int rowBorderType, int columnBorderType, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::Sobel(*src, *dst, ddepth, dx, dy, *buf, ksize, scale, rowBorderType, columnBorderType, stream0);
}

CVAPI(void) gpu_Scharr1(
	GpuMat *src, GpuMat *dst, int ddepth, int dx, int dy, double scale,	int rowBorderType, int columnBorderType)
{
	cv::gpu::Scharr(*src, *dst, ddepth, dx, dy, scale, rowBorderType, columnBorderType);
}
CVAPI(void) gpu_Scharr2(
	GpuMat *src, GpuMat *dst, int ddepth, int dx, int dy, GpuMat *buf, double scale,
	int rowBorderType, int columnBorderType, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::Scharr(*src, *dst, ddepth, dx, dy, *buf, scale, rowBorderType, columnBorderType, stream0);
}

CVAPI(void) gpu_GaussianBlur1(
	GpuMat *src, GpuMat *dst, cv::Size ksize, double sigma1, double sigma2,
	int rowBorderType, int columnBorderType)
{
	cv::gpu::GaussianBlur(*src, *dst, ksize, sigma1, sigma2, rowBorderType, columnBorderType);
}
CVAPI(void) gpu_GaussianBlur2(
	GpuMat *src, GpuMat *dst, cv::Size ksize, GpuMat *buf, double sigma1, double sigma2,
	int rowBorderType, int columnBorderType, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::GaussianBlur(*src, *dst, ksize, *buf, sigma1, sigma2, rowBorderType, columnBorderType, stream0);
}

CVAPI(void) gpu_Laplacian(
	GpuMat *src, GpuMat *dst, int ddepth, int ksize, double scale, int borderType, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::Laplacian(*src, *dst, ddepth, ksize, scale, borderType, stream0);
}







CVAPI(void) gpu_minMaxLoc1(
	GpuMat *src, double *minVal, double *maxVal, cv::Point *minLoc, cv::Point *maxLoc,
	GpuMat *mask)
{
	cv::gpu::minMaxLoc(*src, minVal, maxVal, minLoc, maxLoc, entity(mask));
}

CVAPI(void) gpu_minMaxLoc2(
	GpuMat *src, double *minVal, double *maxVal, cv::Point *minLoc, cv::Point *maxLoc,
	GpuMat *mask, GpuMat *valbuf, GpuMat *locbuf)
{
    GpuMat mask0 = entity(mask);
    cv::gpu::minMaxLoc(*src, minVal, maxVal, minLoc, maxLoc, *valbuf, *locbuf, mask0);
}

CVAPI(void) gpu_matchTemplate1(
	GpuMat *image, GpuMat *templ, GpuMat *result, int method, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::matchTemplate(*image, *templ, *result, method, stream0);
}

CVAPI(void) gpu_matchTemplate2(
	GpuMat *image, GpuMat *templ, GpuMat *result, int method, MatchTemplateBuf *buf, Stream *stream)
{
    Stream stream0 = entity(stream);
    cv::gpu::matchTemplate(*image, *templ, *result, method, *buf, stream0);
}

#endif
