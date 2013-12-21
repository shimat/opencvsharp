/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _GPU_WStereoBM_GPU_H_
#define _GPU_WStereoBM_GPU_H_

#ifdef _MSC_VER
//#pragma warning(disable: 4251)
#endif
#include <opencv2/core/core.hpp>
#include <opencv2/gpu/gpu.hpp>

using namespace cv::gpu;

CVAPI(int) StereoBM_GPU_sizeof()
{
	return (int)sizeof(StereoBM_GPU);
}

CVAPI(StereoBM_GPU*) StereoBM_GPU_new1()
{
	return new StereoBM_GPU();
}
CVAPI(StereoBM_GPU*) StereoBM_GPU_new2(int preset, int ndisparities, int winSize)
{
	return new StereoBM_GPU(preset, ndisparities, winSize);
}
CVAPI(void) StereoBM_GPU_delete(StereoBM_GPU* obj)
{
	delete obj;
}

CVAPI(void) StereoBM_GPU_run1(StereoBM_GPU* obj, const GpuMat* left, const GpuMat* right, GpuMat* disparity)
{
	(*obj)(*left, *right, *disparity);
}
CVAPI(void) StereoBM_GPU_run2(StereoBM_GPU* obj, const GpuMat* left, const GpuMat* right, GpuMat* disparity, Stream* stream)
{
	(*obj)(*left, *right, *disparity, *stream);
}

CVAPI(int) StereoBM_GPU_checkIfGpuCallReasonable()
{
	return StereoBM_GPU::checkIfGpuCallReasonable() ? 1 : 0;
}

CVAPI(int*) StereoBM_GPU_preset(StereoBM_GPU* obj)
{
	return &(obj->preset);
}
CVAPI(int*) StereoBM_GPU_ndisp(StereoBM_GPU* obj)
{
	return &(obj->ndisp);
}
CVAPI(int*) StereoBM_GPU_winSize(StereoBM_GPU* obj)
{
	return &(obj->winSize);
}
CVAPI(float*) StereoBM_GPU_avergeTexThreshold(StereoBM_GPU* obj)
{
	return &(obj->avergeTexThreshold);
}

#endif