#ifndef _CPP_GPU_GPUMAT_H_
#define _CPP_GPU_GPUMAT_H_

#include "include_opencv.h"
using namespace cv::gpu;


#pragma region Init and Disposal

CVAPI(void) gpu_GpuMat_delete(GpuMat *obj)
{
	delete obj;
}
CVAPI(GpuMat*) gpu_GpuMat_new1()
{
	return new GpuMat();
}
CVAPI(GpuMat*) gpu_GpuMat_new2(int rows, int cols, int type)
{
	return new GpuMat(rows, cols, type);
}
CVAPI(GpuMat*) gpu_GpuMat_new3(int rows, int cols, int type, void* data, uint64 step)
{
	return new GpuMat(rows, cols, type, data, static_cast<size_t>(step));
}
CVAPI(GpuMat*) gpu_GpuMat_new4(cv::Mat *mat)
{
	return new GpuMat(*mat);
}
CVAPI(GpuMat*) gpu_GpuMat_new5(GpuMat *gpumat)
{
	return new GpuMat(*gpumat);
}
CVAPI(GpuMat*) gpu_GpuMat_new6(CvSize size, int type)
{
	return new GpuMat((cv::Size)size, type);
}
CVAPI(GpuMat*) gpu_GpuMat_new7(CvSize size, int type, void* data, uint64 step)
{
	return new GpuMat((cv::Size)size, type, data, static_cast<size_t>(step));
}
CVAPI(GpuMat*) gpu_GpuMat_new8(int rows, int cols, int type, CvScalar s)
{
	return new GpuMat(rows, cols, type, s);
}
CVAPI(GpuMat*) gpu_GpuMat_new9(GpuMat *m, CvSlice rowRange, CvSlice colRange)
{
	return new GpuMat(*m, (cv::Range)rowRange, (cv::Range)colRange);
}
CVAPI(GpuMat*) gpu_GpuMat_new10(GpuMat *m, CvRect roi)
{
	return new GpuMat(*m, (cv::Rect)roi);
}
CVAPI(GpuMat*) gpu_GpuMat_new11(CvSize size, int type, CvScalar s)
{
	return new GpuMat((cv::Size)size, type, s);
}
#pragma endregion

#pragma region Fields
CVAPI(int) gpu_GpuMat_flags(GpuMat *obj)
{
	return obj->flags;
}
CVAPI(int) gpu_GpuMat_rows(GpuMat *obj)
{
	return obj->rows;
}
CVAPI(int) gpu_GpuMat_cols(GpuMat *obj)
{
	return obj->cols;
}
CVAPI(uint64) gpu_GpuMat_step(GpuMat *obj)
{
	return static_cast<uint64>(obj->step);
}
CVAPI(uchar*) gpu_GpuMat_data(GpuMat *obj)
{
	return obj->data;
}
CVAPI(int*) gpu_GpuMat_refcount(GpuMat *obj)
{
	return obj->refcount;
}
CVAPI(uchar*) gpu_GpuMat_datastart(GpuMat *obj)
{
	return obj->datastart;
}
CVAPI(uchar*) gpu_GpuMat_dataend(GpuMat *obj)
{
	return obj->dataend;
}
#pragma endregion

#pragma region Operators
CVAPI(void) gpu_GpuMat_opAssign(GpuMat *left, GpuMat *right)
{
	*left = *right;
}

CVAPI(GpuMat*) gpu_GpuMat_opRange1(GpuMat *src, CvRect roi)
{
	GpuMat gm = (*src)(roi);
	return new GpuMat(gm);
}
CVAPI(GpuMat*) gpu_GpuMat_opRange2(GpuMat *src, CvSlice rowRange, CvSlice colRange)
{
	GpuMat gm = (*src)(rowRange, colRange);
	return new GpuMat(gm);
}

CVAPI(cv::Mat*) gpu_GpuMat_opToMat(GpuMat *src)
{
	cv::Mat m = (cv::Mat)(*src);
	return new cv::Mat(m);
}
CVAPI(GpuMat*) gpu_GpuMat_opToGpuMat(cv::Mat *src)
{
	GpuMat gm = (GpuMat)(*src);
	return new GpuMat(gm);
}
#pragma endregion

#pragma region Methods

CVAPI(void) gpu_GpuMat_upload(GpuMat *obj, cv::Mat *m)
{
	obj->upload(*m);
}

CVAPI(void) gpu_GpuMat_download(GpuMat *obj, cv::Mat *m)
{
	obj->download(*m);
}

CVAPI(GpuMat*) gpu_GpuMat_row(GpuMat *obj, int y)
{
	GpuMat ret = obj->row(y);
	return new GpuMat(ret);
}
CVAPI(GpuMat*) gpu_GpuMat_col(GpuMat *obj, int x)
{
	GpuMat ret = obj->col(x);
	return new GpuMat(ret);
}
CVAPI(GpuMat*) gpu_GpuMat_rowRange(GpuMat *obj, int startrow, int endrow)
{
	GpuMat ret = obj->rowRange(startrow, endrow);
	return new GpuMat(ret);
}
CVAPI(GpuMat*) gpu_GpuMat_colRange(GpuMat *obj, int startcol, int endcol)
{
	GpuMat ret = obj->colRange(startcol, endcol);
	return new GpuMat(ret);
}
CVAPI(GpuMat*) gpu_GpuMat_clone(GpuMat *obj)
{
	GpuMat ret = obj->clone();
	return new GpuMat(ret);
}
CVAPI(void) gpu_GpuMat_copyTo1(GpuMat *obj, GpuMat *m)
{
	obj->copyTo(*m);
}
CVAPI(void) gpu_GpuMat_copyTo2(GpuMat *obj, GpuMat *m, GpuMat *mask)
{
	obj->copyTo(*m, *mask);
}
CVAPI(void) gpu_GpuMat_convertTo(GpuMat *obj, GpuMat *m, int rtype, double alpha, double beta)
{
	obj->convertTo(*m, rtype, alpha, beta);
}
CVAPI(void) gpu_GpuMat_assignTo(GpuMat *obj, GpuMat *m, int type)
{
	obj->assignTo(*m, type);
}
CVAPI(GpuMat*) gpu_GpuMat_setTo(GpuMat *obj, CvScalar s, GpuMat *mask)
{
	GpuMat gm = obj->setTo(s, entity(mask));
	return new GpuMat(gm);
}
CVAPI(GpuMat*) gpu_GpuMat_reshape(GpuMat *obj, int cn, int rows)
{
	GpuMat gm = obj->reshape(cn, rows);
	return new GpuMat(gm);
}

CVAPI(void) gpu_GpuMat_create1(GpuMat *obj, int rows, int cols, int type)
{
	obj->create(rows, cols, type);
}
CVAPI(void) gpu_GpuMat_create2(GpuMat *obj, CvSize size, int type)
{
	obj->create((cv::Size)size, type);
}
CVAPI(void) gpu_GpuMat_release(GpuMat *obj)
{
	obj->release();
}
CVAPI(void) gpu_GpuMat_swap(GpuMat *obj, GpuMat *mat)
{
	obj->swap(*mat);
}

CVAPI(void) gpu_GpuMat_locateROI(GpuMat *obj, CvSize *wholeSize, CvPoint *ofs)
{
	cv::Size _wholeSize;
	cv::Point _ofs;
	obj->locateROI(_wholeSize, _ofs);
	*wholeSize = (CvSize)_wholeSize;
	*ofs = (CvPoint)_ofs;
}

CVAPI(GpuMat*) gpu_GpuMat_adjustROI(GpuMat *obj, int dtop, int dbottom, int dleft, int dright)
{
	GpuMat gm = obj->adjustROI(dtop, dbottom, dleft, dright);
	return new GpuMat(gm);
}

CVAPI(int) gpu_GpuMat_isContinuous(GpuMat *obj)
{
	return obj->isContinuous() ? 1 : 0;
}

CVAPI(uint64) gpu_GpuMat_elemSize(GpuMat *obj)
{
	return static_cast<uint64>(obj->elemSize());
}
CVAPI(uint64) gpu_GpuMat_elemSize1(GpuMat *obj)
{
	return static_cast<uint64>(obj->elemSize1());
}

CVAPI(int) gpu_GpuMat_type(GpuMat *obj)
{
	return obj->type();
}
CVAPI(int) gpu_GpuMat_depth(GpuMat *obj)
{
	return obj->depth();
}
CVAPI(int) gpu_GpuMat_channels(GpuMat *obj)
{
	return obj->channels();
}
CVAPI(uint64) gpu_GpuMat_step1(GpuMat *obj)
{
	return static_cast<uint64>(obj->step1());
}
CVAPI(CvSize) gpu_GpuMat_size(GpuMat *obj)
{
	return (CvSize)obj->size();
}
CVAPI(int) gpu_GpuMat_empty(GpuMat *obj)
{
	return obj->empty() ? 1 : 0;
}

CVAPI(const uchar*) gpu_GpuMat_ptr(const GpuMat *obj, int y)
{
	return obj->ptr(y);
}

#pragma endregion

//! Creates continuous GPU matrix
CVAPI(void) gpu_createContinuous1(int rows, int cols, int type, GpuMat *gm)
{
	createContinuous(rows, cols, type, *gm);
}
CVAPI(GpuMat*) gpu_createContinuous2(int rows, int cols, int type)
{
	GpuMat gm = createContinuous(rows, cols, type);
	return new GpuMat(gm);
}

//! Ensures that size of the given matrix is not less than (rows, cols) size
//! and matrix type is match specified one too
CVAPI(void) gpu_ensureSizeIsEnough(int rows, int cols, int type, GpuMat *m)
{
	ensureSizeIsEnough(rows, cols, type, *m);
}

CVAPI(GpuMat*) gpu_allocMatFromBuf(int rows, int cols, int type, GpuMat *mat)
{
	GpuMat gm = allocMatFromBuf(rows, cols, type, *mat);
	return new GpuMat(gm);
}


#endif