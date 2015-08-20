#ifndef _CPP_GPU_CASCADECLASSIFIERGPU_H_
#define _CPP_GPU_CASCADECLASSIFIERGPU_H_

#include "include_opencv.h"
using namespace cv::gpu;


CVAPI(void) gpu_CascadeClassifier_GPU_delete(CascadeClassifier_GPU *obj)
{
	delete obj;
}
CVAPI(CascadeClassifier_GPU*) gpu_CascadeClassifier_GPU_new1()
{
	return new CascadeClassifier_GPU();
}
CVAPI(CascadeClassifier_GPU*) gpu_CascadeClassifier_GPU_new2(const char *filename)
{
	return new CascadeClassifier_GPU(filename);
}


CVAPI(int) gpu_CascadeClassifier_GPU_empty(CascadeClassifier_GPU *obj)
{
	return obj->empty() ? 1 : 0;
}

CVAPI(int) gpu_CascadeClassifier_GPU_load(CascadeClassifier_GPU *obj, const char *filename)
{
	return obj->load(filename) ? 1 : 0;
}

CVAPI(void) gpu_CascadeClassifier_GPU_release(CascadeClassifier_GPU *obj)
{
	obj->release();
}


CVAPI(int) gpu_CascadeClassifier_GPU_detectMultiScale1(CascadeClassifier_GPU *obj, 
	GpuMat *image, GpuMat *objectsBuf, double scaleFactor, int minNeighbors, CvSize minSize)
{
	return obj->detectMultiScale(*image, *objectsBuf, scaleFactor, minNeighbors, minSize);
}

CVAPI(int) gpu_CascadeClassifier_GPU_detectMultiScale2(CascadeClassifier_GPU *obj, 
	GpuMat *image, GpuMat *objectsBuf, CvSize maxObjectSize, CvSize minSize, double scaleFactor, int minNeighbors)
{
	return obj->detectMultiScale(*image, *objectsBuf, maxObjectSize, minSize, scaleFactor, minNeighbors);
}


CVAPI(int) gpu_CascadeClassifier_GPU_findLargestObject_get(CascadeClassifier_GPU *obj)
{
	return obj->findLargestObject ? 1 : 0;
}
CVAPI(void) gpu_CascadeClassifier_GPU_findLargestObject_set(CascadeClassifier_GPU *obj, int value)
{
	obj->findLargestObject = (value != 0);
}

CVAPI(int) gpu_CascadeClassifier_GPU_visualizeInPlace_get(CascadeClassifier_GPU *obj)
{
	return obj->visualizeInPlace ? 1 : 0;
}
CVAPI(void) gpu_CascadeClassifier_GPU_visualizeInPlace_set(CascadeClassifier_GPU *obj, int value)
{
	obj->visualizeInPlace = (value != 0);
}

CVAPI(CvSize) gpu_CascadeClassifier_GPU_getClassifierSize(CascadeClassifier_GPU *obj)
{
	return obj->getClassifierSize();
}


#endif