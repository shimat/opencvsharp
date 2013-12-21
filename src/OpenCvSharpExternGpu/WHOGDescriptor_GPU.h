/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _GPU_WHOGDESCRIPTOR_H_
#define _GPU_WHOGDESCRIPTOR_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/core/core.hpp>
#include <opencv2/gpu/gpu.hpp>

using namespace cv::gpu;


#pragma region Init & Disposal
CVAPI(int) HOGDescriptor_sizeof()
{
	return sizeof(HOGDescriptor);
}
CVAPI(HOGDescriptor*) HOGDescriptor_new( CvSize win_size, CvSize block_size, CvSize block_stride, CvSize cell_size, 
	int nbins, double winSigma, double threshold_L2Hys, bool gamma_correction, int nlevels)
{
	return new HOGDescriptor(win_size, block_size, block_stride, cell_size, nbins, winSigma, threshold_L2Hys, gamma_correction, nlevels);
}
CVAPI(void) HOGDescriptor_delete(HOGDescriptor* obj)
{
	delete obj;
}
#pragma endregion


#pragma region Methods
CVAPI(uint64) HOGDescriptor_getDescriptorSize(const HOGDescriptor* obj)
{
	return (uint64)obj->getDescriptorSize();
}
CVAPI(uint64) HOGDescriptor_getBlockHistogramSize(const HOGDescriptor* obj)
{
	return (uint64)obj->getBlockHistogramSize();
}
/*
CVAPI(int) HOGDescriptor_checkDetectorSize(const HOGDescriptor* obj)
{
	return obj->checkDetectorSize() ? 1 : 0;
}
CVAPI(double) HOGDescriptor_getWinSigma(const HOGDescriptor* obj)
{
	return obj->getWinSigma();
}
*/

CVAPI(void) HOGDescriptor_setSVMDetector(cv::HOGDescriptor* obj, std::vector<float>* svmdetector)
{
	obj->setSVMDetector(*svmdetector);
}

CVAPI(void) HOGDescriptor_detect(HOGDescriptor* obj, GpuMat* img, std::vector<cv::Point>* found_locations, 
								 double hit_threshold, CvSize win_stride, CvSize padding)
{
	obj->detect(*img, *found_locations, hit_threshold, win_stride, padding);
}

CVAPI(void) HOGDescriptor_detectMultiScale(HOGDescriptor* obj, GpuMat* img, std::vector<cv::Rect>* found_locations, 
										   double hit_threshold, CvSize win_stride, CvSize padding, double scale, int group_threshold)
{
	obj->detectMultiScale(*img, *found_locations, hit_threshold, win_stride, padding, scale, group_threshold);
}

CVAPI(void) HOGDescriptor_getDescriptors(HOGDescriptor* obj, const GpuMat* img, CvSize win_stride, GpuMat* descriptors, int descr_format)
{
	obj->getDescriptors(*img, win_stride, *descriptors, descr_format);
}
#pragma endregion


#pragma region Fields
CVAPI(CvSize) HOGDescriptor_win_size_get(HOGDescriptor* obj)
{
	return obj->win_size;
}
CVAPI(CvSize) HOGDescriptor_block_size_get(HOGDescriptor* obj)
{
	return obj->block_size;
}
CVAPI(CvSize) HOGDescriptor_block_stride_get(HOGDescriptor* obj)
{
	return obj->block_stride;
}
CVAPI(CvSize) HOGDescriptor_cell_size_get(HOGDescriptor* obj)
{
	return obj->win_size;
}
CVAPI(int) HOGDescriptor_nbins_get(HOGDescriptor* obj)
{
	return obj->nbins;
}
CVAPI(double) HOGDescriptor_win_sigma_get(HOGDescriptor* obj)
{
	return obj->win_sigma;
}
CVAPI(double) HOGDescriptor_threshold_L2hys_get(HOGDescriptor* obj)
{
	return obj->threshold_L2hys;
}
CVAPI(int) HOGDescriptor_nlevels_get(HOGDescriptor* obj)
{
	return obj->nlevels;
}
CVAPI(int) HOGDescriptor_gamma_correction_get(HOGDescriptor* obj)
{
	return obj->gamma_correction ? 1 : 0;
}


CVAPI(void) HOGDescriptor_win_size_set(HOGDescriptor* obj, CvSize value)
{
	obj->win_size = value;
}
CVAPI(void) HOGDescriptor_block_size_set(HOGDescriptor* obj, CvSize value)
{
	obj->block_size = value;
}
CVAPI(void) HOGDescriptor_block_stride_set(HOGDescriptor* obj, CvSize value)
{
	obj->block_stride = value;
}
CVAPI(void) HOGDescriptor_cell_size_set(HOGDescriptor* obj, CvSize value)
{
	obj->cell_size = value;
}
CVAPI(void) HOGDescriptor_nbins_set(HOGDescriptor* obj, int value)
{
	obj->nbins = value;
}
CVAPI(void) HOGDescriptor_win_sigma_set(HOGDescriptor* obj, double value)
{
	obj->win_sigma = value;
}
CVAPI(void) HOGDescriptor_threshold_L2hys_set(HOGDescriptor* obj, double value)
{
	obj->threshold_L2hys = value;
}
CVAPI(void) HOGDescriptor_nlevels_set(HOGDescriptor* obj, int value)
{
	obj->nlevels = value;
}
CVAPI(void) HOGDescriptor_gamma_correction_set(HOGDescriptor* obj, int value)
{
	obj->gamma_correction = (value != 0);
}
#pragma endregion

#endif