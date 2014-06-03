#ifndef _CPP_StereoBM_GPU_H_
#define _CPP_StereoBM_GPU_H_

#include "include_opencv.h"

CVAPI(cv::gpu::StereoBM_GPU*) gpu_StereoBM_GPU_new1()
{
	return new cv::gpu::StereoBM_GPU();
}
CVAPI(cv::gpu::StereoBM_GPU*) gpu_StereoBM_GPU_new2(int preset, int ndisparities, int winSize)
{
	return new cv::gpu::StereoBM_GPU(preset, ndisparities, winSize);
}
CVAPI(void) gpu_StereoBM_GPU_delete(cv::gpu::StereoBM_GPU* obj)
{
	delete obj;
}

CVAPI(void) gpu_StereoBM_GPU_run1(
    cv::gpu::StereoBM_GPU* obj, cv::gpu::GpuMat* left, cv::gpu::GpuMat* right, cv::gpu::GpuMat* disparity)
{
	(*obj)(*left, *right, *disparity);
}
CVAPI(void) gpu_StereoBM_GPU_run2(
    cv::gpu::StereoBM_GPU* obj, cv::gpu::GpuMat* left, cv::gpu::GpuMat* right, cv::gpu::GpuMat* disparity, cv::gpu::Stream* stream)
{
	(*obj)(*left, *right, *disparity, *stream);
}

CVAPI(int) gpu_StereoBM_GPU_checkIfGpuCallReasonable()
{
	return cv::gpu::StereoBM_GPU::checkIfGpuCallReasonable() ? 1 : 0;
}

CVAPI(int*) gpu_StereoBM_GPU_preset(cv::gpu::StereoBM_GPU* obj)
{
	return &(obj->preset);
}
CVAPI(int*) gpu_StereoBM_GPU_ndisp(cv::gpu::StereoBM_GPU* obj)
{
	return &(obj->ndisp);
}
CVAPI(int*) gpu_StereoBM_GPU_winSize(cv::gpu::StereoBM_GPU* obj)
{
	return &(obj->winSize);
}
CVAPI(float*) gpu_StereoBM_GPU_avergeTexThreshold(cv::gpu::StereoBM_GPU* obj)
{
	return &(obj->avergeTexThreshold);
}

#endif