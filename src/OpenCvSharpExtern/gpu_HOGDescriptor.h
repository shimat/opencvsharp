#ifndef _CPP_GPU_WHOGDESCRIPTOR_H_
#define _CPP_GPU_WHOGDESCRIPTOR_H_

#include "include_opencv.h"
using namespace cv::gpu;


#pragma region Init & Disposal
CVAPI(HOGDescriptor*) gpu_HOGDescriptor_new( CvSize win_size, CvSize block_size, CvSize block_stride, CvSize cell_size, 
	int nbins, double winSigma, double threshold_L2Hys, bool gamma_correction, int nlevels)
{
	return new HOGDescriptor(win_size, block_size, block_stride, cell_size, nbins, winSigma, threshold_L2Hys, gamma_correction, nlevels);
}
CVAPI(void) gpu_HOGDescriptor_delete(HOGDescriptor* obj)
{
	delete obj;
}
#pragma endregion


#pragma region Methods
CVAPI(uint64) gpu_HOGDescriptor_getDescriptorSize(const HOGDescriptor* obj)
{
	return (uint64)obj->getDescriptorSize();
}
CVAPI(uint64) gpu_HOGDescriptor_getBlockHistogramSize(const HOGDescriptor* obj)
{
	return (uint64)obj->getBlockHistogramSize();
}
/*
CVAPI(int) gpu_HOGDescriptor_checkDetectorSize(const HOGDescriptor* obj)
{
	return obj->checkDetectorSize() ? 1 : 0;
}
CVAPI(double) gpu_HOGDescriptor_getWinSigma(const HOGDescriptor* obj)
{
	return obj->getWinSigma();
}
*/

CVAPI(void) gpu_HOGDescriptor_setSVMDetector(cv::HOGDescriptor* obj, std::vector<float>* svmdetector)
{
	obj->setSVMDetector(*svmdetector);
}

CVAPI(void) gpu_HOGDescriptor_detect(HOGDescriptor* obj, GpuMat* img, std::vector<cv::Point>* found_locations,
								 double hit_threshold, CvSize win_stride, CvSize padding)
{
	obj->detect(*img, *found_locations, hit_threshold, win_stride, padding);
}

CVAPI(void) gpu_HOGDescriptor_detectMultiScale(HOGDescriptor* obj, GpuMat* img, std::vector<cv::Rect>* found_locations,
										   double hit_threshold, CvSize win_stride, CvSize padding, double scale, int group_threshold)
{
	obj->detectMultiScale(*img, *found_locations, hit_threshold, win_stride, padding, scale, group_threshold);
}

CVAPI(void) gpu_HOGDescriptor_getDescriptors(HOGDescriptor* obj, const GpuMat* img, CvSize win_stride, GpuMat* descriptors, int descr_format)
{
	obj->getDescriptors(*img, win_stride, *descriptors, descr_format);
}
#pragma endregion


#pragma region Fields
CVAPI(CvSize) gpu_HOGDescriptor_win_size_get(HOGDescriptor* obj)
{
	return obj->win_size;
}
CVAPI(CvSize) gpu_HOGDescriptor_block_size_get(HOGDescriptor* obj)
{
	return obj->block_size;
}
CVAPI(CvSize) gpu_HOGDescriptor_block_stride_get(HOGDescriptor* obj)
{
	return obj->block_stride;
}
CVAPI(CvSize) gpu_HOGDescriptor_cell_size_get(HOGDescriptor* obj)
{
	return obj->win_size;
}
CVAPI(int) gpu_HOGDescriptor_nbins_get(HOGDescriptor* obj)
{
	return obj->nbins;
}
CVAPI(double) gpu_HOGDescriptor_win_sigma_get(HOGDescriptor* obj)
{
	return obj->win_sigma;
}
CVAPI(double) gpu_HOGDescriptor_threshold_L2hys_get(HOGDescriptor* obj)
{
	return obj->threshold_L2hys;
}
CVAPI(int) gpu_HOGDescriptor_nlevels_get(HOGDescriptor* obj)
{
	return obj->nlevels;
}
CVAPI(int) gpu_HOGDescriptor_gamma_correction_get(HOGDescriptor* obj)
{
	return obj->gamma_correction ? 1 : 0;
}


CVAPI(void) gpu_HOGDescriptor_win_size_set(HOGDescriptor* obj, CvSize value)
{
	obj->win_size = value;
}
CVAPI(void) gpu_HOGDescriptor_block_size_set(HOGDescriptor* obj, CvSize value)
{
	obj->block_size = value;
}
CVAPI(void) gpu_HOGDescriptor_block_stride_set(HOGDescriptor* obj, CvSize value)
{
	obj->block_stride = value;
}
CVAPI(void) gpu_HOGDescriptor_cell_size_set(HOGDescriptor* obj, CvSize value)
{
	obj->cell_size = value;
}
CVAPI(void) gpu_HOGDescriptor_nbins_set(HOGDescriptor* obj, int value)
{
	obj->nbins = value;
}
CVAPI(void) gpu_HOGDescriptor_win_sigma_set(HOGDescriptor* obj, double value)
{
	obj->win_sigma = value;
}
CVAPI(void) gpu_HOGDescriptor_threshold_L2hys_set(HOGDescriptor* obj, double value)
{
	obj->threshold_L2hys = value;
}
CVAPI(void) gpu_HOGDescriptor_nlevels_set(HOGDescriptor* obj, int value)
{
	obj->nlevels = value;
}
CVAPI(void) gpu_HOGDescriptor_gamma_correction_set(HOGDescriptor* obj, int value)
{
	obj->gamma_correction = (value != 0);
}
#pragma endregion

#endif