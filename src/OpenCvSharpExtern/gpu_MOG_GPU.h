#ifndef _CPP_GPU_MOGGPU_H_
#define _CPP_GPU_MOGGPU_H_

#include "include_opencv.h"
using namespace cv::gpu;


#pragma region MOG_GPU

CVAPI(void) gpu_MOG_GPU_delete(MOG_GPU *obj)
{
	delete obj;
}
CVAPI(MOG_GPU*) gpu_MOG_GPU_new(int nmixtures)
{
	return new MOG_GPU(nmixtures);
}

CVAPI(void) gpu_MOG_GPU_initialize(MOG_GPU *obj, CvSize frameSize, int frameType)
{
	obj->initialize(frameSize, frameType);
}

CVAPI(void) gpu_MOG_GPU_operator(MOG_GPU *obj, GpuMat *frame, GpuMat *fgmask, float learningRate, Stream *stream)
{
    Stream stream0 = entity(stream);
    (*obj)(*frame, *fgmask, learningRate, stream0);
}

CVAPI(void) gpu_MOG_GPU_getBackgroundImage(MOG_GPU *obj, GpuMat *backgroundImage, Stream *stream)
{
    Stream stream0 = entity(stream);
    obj->getBackgroundImage(*backgroundImage, stream0);
}

CVAPI(void) gpu_MOG_GPU_release(MOG_GPU *obj)
{
	obj->release();
}


CVAPI(int*) gpu_MOG_GPU_history(MOG_GPU *obj)
{
	return &(obj->history);
}

CVAPI(float*) gpu_MOG_GPU_varThreshold(MOG_GPU *obj)
{
	return &(obj->varThreshold);
}

CVAPI(float*) gpu_MOG_GPU_backgroundRatio(MOG_GPU *obj)
{
	return &(obj->backgroundRatio);
}

CVAPI(float*) gpu_MOG_GPU_noiseSigma(MOG_GPU *obj)
{
	return &(obj->noiseSigma);
}

#pragma endregion


#pragma region MOG2_GPU

CVAPI(void) gpu_MOG2_GPU_delete(MOG2_GPU *obj)
{
	delete obj;
}
CVAPI(MOG2_GPU*) gpu_MOG2_GPU_new(int nmixtures)
{
	return new MOG2_GPU(nmixtures);
}


CVAPI(void) gpu_MOG2_GPU_initialize(MOG2_GPU *obj, CvSize frameSize, int frameType)
{
	obj->initialize(frameSize, frameType);
}

CVAPI(void) gpu_MOG2_GPU_operator(MOG2_GPU *obj, GpuMat *frame, GpuMat *fgmask, float learningRate, Stream *stream)
{
    Stream stream0 = entity(stream);
    (*obj)(*frame, *fgmask, learningRate, stream0);
}

CVAPI(void) gpu_MOG2_GPU_getBackgroundImage(MOG2_GPU *obj, GpuMat *backgroundImage, Stream *stream)
{
    Stream stream0 = entity(stream);
    obj->getBackgroundImage(*backgroundImage, stream0);
}

CVAPI(void) gpu_MOG2_GPU_release(MOG2_GPU *obj)
{
	obj->release();
}

CVAPI(int*) gpu_MOG2_GPU_history(MOG2_GPU *obj)
{
	return &(obj->history);
}

CVAPI(float*) gpu_MOG2_GPU_varThreshold(MOG2_GPU *obj)
{
	return &(obj->varThreshold);
}

CVAPI(float*) gpu_MOG2_GPU_backgroundRatio(MOG2_GPU *obj)
{
	return &(obj->backgroundRatio);
}

CVAPI(float*) gpu_MOG2_GPU_varThresholdGen(MOG2_GPU *obj)
{
	return &(obj->varThresholdGen);
}

CVAPI(float*) gpu_MOG2_GPU_fVarInit(MOG2_GPU *obj)
{
	return &(obj->fVarInit);
}
CVAPI(float*) gpu_MOG2_GPU_fVarMin(MOG2_GPU *obj)
{
	return &(obj->fVarMin);
}
CVAPI(float*) gpu_MOG2_GPU_fVarMax(MOG2_GPU *obj)
{
	return &(obj->fVarMax);
}

CVAPI(float*) gpu_MOG2_GPU_fCT(MOG2_GPU *obj)
{
	return &(obj->fCT);
}

CVAPI(int) gpu_MOG2_GPU_bShadowDetection_get(MOG2_GPU *obj)
{
	return obj->bShadowDetection ? 1 : 0;
}
CVAPI(void) gpu_MOG2_GPU_bShadowDetection_set(MOG2_GPU *obj, int value)
{
	obj->bShadowDetection = (value != 0);
}

CVAPI(unsigned char*) gpu_MOG2_GPU_nShadowDetection(MOG2_GPU *obj)
{
	return &(obj->nShadowDetection);
}

CVAPI(float*) gpu_MOG2_GPU_fTau(MOG2_GPU *obj)
{
	return &(obj->fTau);
}

#pragma endregion

#endif
