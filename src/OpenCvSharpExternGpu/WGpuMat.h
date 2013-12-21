/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _GPU_WGpuMat_H_
#define _GPU_WGpuMat_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/core/core.hpp>
#include <opencv2/gpu/gpu.hpp>

using namespace cv::gpu;


#pragma region Init and Disposal
CVAPI(int) GpuMat_sizeof()
{
	return sizeof(GpuMat);
}
CVAPI(void) GpuMat_delete(GpuMat* obj)
{
	delete obj;
}
CVAPI(GpuMat*) GpuMat_new1()
{
	return new GpuMat();
}
CVAPI(GpuMat*) GpuMat_new2(int rows, int cols, int type)
{
	return new GpuMat(rows, cols, type);
}
CVAPI(GpuMat*) GpuMat_new3(int rows, int cols, int type, void* data, unsigned int step)
{
	return new GpuMat(rows, cols, type, data, step);
}
CVAPI(GpuMat*) GpuMat_new4(const cv::Mat* mat)
{
	return new GpuMat(*mat);
}
CVAPI(GpuMat*) GpuMat_new5(const GpuMat* gpumat)
{
	return new GpuMat(*gpumat);
}
CVAPI(GpuMat*) GpuMat_new6(CvSize size, int type)
{
	return new GpuMat((cv::Size)size, type);
}
CVAPI(GpuMat*) GpuMat_new7(CvSize size, int type, void* data, unsigned int step)
{
	return new GpuMat((cv::Size)size, type, data, step);
}
CVAPI(GpuMat*) GpuMat_new8(int rows, int cols, int type, CvScalar s)
{
	return new GpuMat(rows, cols, type, s);
}
CVAPI(GpuMat*) GpuMat_new9(const GpuMat* m, CvSlice rowRange, CvSlice colRange)
{
	return new GpuMat(*m, (cv::Range)rowRange, (cv::Range)colRange);
}
CVAPI(GpuMat*) GpuMat_new10(const GpuMat* m, CvRect roi)
{
	return new GpuMat(*m, (cv::Rect)roi);
}
CVAPI(GpuMat*) GpuMat_new11(CvSize size, int type, CvScalar s)
{
	return new GpuMat((cv::Size)size, type, s);
}
#pragma endregion

#pragma region Fields
CVAPI(int) GpuMat_flags(const GpuMat* obj)
{
	return obj->flags;
}
CVAPI(int) GpuMat_rows(const GpuMat* obj)
{
	return obj->rows;
}
CVAPI(int) GpuMat_cols(const GpuMat* obj)
{
	return obj->cols;
}
CVAPI(unsigned int) GpuMat_step(const GpuMat* obj)
{
	return (unsigned int)obj->step;
}
CVAPI(uchar*) GpuMat_data(const GpuMat* obj)
{
	return obj->data;
}
CVAPI(int*) GpuMat_refcount(const GpuMat* obj)
{
	return obj->refcount;
}
CVAPI(uchar*) GpuMat_datastart(const GpuMat* obj)
{
	return obj->datastart;
}
CVAPI(uchar*) GpuMat_dataend(const GpuMat* obj)
{
	return obj->dataend;
}
#pragma endregion

#pragma region Operators
CVAPI(void) GpuMat_opAssign1(GpuMat* src, GpuMat* m)
{
	*src = *m;
}
/*CVAPI(void) GpuMat_opAssign2(GpuMat* src, cv::Mat* m)
{
	*src = *m;
}*/

CVAPI(void) GpuMat_opRange1(GpuMat* src, CvRect roi, GpuMat* dst)
{
	*dst = (*src)(roi);
}
CVAPI(void) GpuMat_opRange2(GpuMat* src, CvSlice rowRange, CvSlice colRange, GpuMat* dst)
{
	*dst = (*src)(rowRange, colRange);
}
/*
CVAPI(void) GpuMat_opComplement(const GpuMat* src, GpuMat* dst)
{
	*dst = ~(*src); 
}
CVAPI(void) GpuMat_opOr(const GpuMat* src1, const GpuMat* src2, GpuMat* dst)
{
	*dst = (*src1) | (*src2);
}
CVAPI(void) GpuMat_opAnd(const GpuMat* src1, const GpuMat* src2, GpuMat* dst)
{
	*dst = (*src1) & (*src2);
}
CVAPI(void) GpuMat_opXor(const GpuMat* src1, const GpuMat* src2, GpuMat* dst)
{
	*dst = (*src1) ^ (*src2);
}
*/
#pragma endregion

#pragma region Methods
CVAPI(void) GpuMat_opGpuMat(cv::Mat* mat, GpuMat* gpumat)
{
	*gpumat = (GpuMat)(*mat);
}
CVAPI(void) GpuMat_upload1(GpuMat* obj, const cv::Mat* m)
{
	obj->upload(*m);
}
/*CVAPI(void) GpuMat_upload2(GpuMat* obj, const CudaMem* m, Stream* stream)
{
	obj->upload(*m, *stream);
}*/
CVAPI(void) GpuMat_opMat(GpuMat* gpumat, cv::Mat* mat)
{
	*mat = (cv::Mat)(*gpumat);
}
CVAPI(void) GpuMat_download1(const GpuMat* obj, cv::Mat* m)
{
	obj->download(*m);
}
/*CVAPI(void) GpuMat_download2(const GpuMat* obj, CudaMem* m, Stream* stream)
{
	obj->download(*m, *stream);
}*/

CVAPI(void) GpuMat_row(const GpuMat* obj, int y, GpuMat* outValue)
{
	*outValue = obj->row(y);
}
CVAPI(void) GpuMat_col(const GpuMat* obj, int x, GpuMat* outValue)
{
	*outValue = obj->col(x);
}
CVAPI(void) GpuMat_rowRange(const GpuMat* obj, int startrow, int endrow, GpuMat* outValue)
{
	*outValue = obj->rowRange(startrow, endrow);
}
CVAPI(void) GpuMat_colRange(const GpuMat* obj, int startcol, int endcol, GpuMat* outValue)
{
	*outValue = obj->colRange(startcol, endcol);
}
CVAPI(void) GpuMat_clone(const GpuMat* obj, GpuMat* outValue)
{
	*outValue = obj->clone();
}
CVAPI(void) GpuMat_copyTo1(GpuMat* obj, GpuMat* m)
{
	obj->copyTo(*m);
}
CVAPI(void) GpuMat_copyTo2(GpuMat* obj, GpuMat* m, GpuMat* mask)
{
	obj->copyTo(*m, *mask);
}
CVAPI(void) GpuMat_convertTo(GpuMat* obj, GpuMat* m, int rtype, double alpha, double beta) 
{
	obj->convertTo(*m, rtype, alpha, beta);
}
CVAPI(void) GpuMat_assignTo(GpuMat* obj, GpuMat* m, int type)
{
	obj->assignTo(*m, type);
}
CVAPI(void) GpuMat_setTo(GpuMat* obj, CvScalar s, GpuMat* mask, GpuMat* dst)
{
	if(mask == NULL)
		*dst = obj->setTo(s);
	else
		*dst = obj->setTo(s, *mask);
}
CVAPI(void) GpuMat_reshape(GpuMat* obj, int cn, int rows, GpuMat* outValue)
{
	obj->reshape(cn, rows);
}

CVAPI(void) GpuMat_create1(GpuMat* obj, int rows, int cols, int type)
{
	obj->create(rows, cols, type);
}
CVAPI(void) GpuMat_create2(GpuMat* obj, CvSize size, int type)
{
	obj->create((cv::Size)size, type);
}
CVAPI(void) GpuMat_release(GpuMat* obj)
{
	obj->release();
}
CVAPI(void) GpuMat_swap(GpuMat* obj, GpuMat* mat)
{
	obj->swap(*mat);
}
CVAPI(void) GpuMat_locateROI(GpuMat* obj, CvSize* wholeSize, CvPoint* ofs)
{
	cv::Size _wholeSize;
	cv::Point _ofs;
	obj->locateROI(_wholeSize, _ofs);
	*wholeSize = (CvSize)_wholeSize;
	*ofs = (CvPoint)_ofs;
}
CVAPI(void) GpuMat_adjustROI(GpuMat* obj, int dtop, int dbottom, int dleft, int dright, GpuMat* dst)
{
	*dst = obj->adjustROI(dtop, dbottom, dleft, dright);
}

/*
CVAPI(void) GpuMat_t(const GpuMat* src, GpuMat* dst)
{
	*dst = src->t();
}*/

CVAPI(bool) GpuMat_isContinuous(const GpuMat* obj)
{
	return obj->isContinuous();
}
CVAPI(unsigned int) GpuMat_elemSize(const GpuMat* obj)
{
	return (unsigned int)obj->elemSize();
}
CVAPI(unsigned int) GpuMat_elemSize1(const GpuMat* obj)
{
	return (unsigned int)obj->elemSize1();
}
CVAPI(int) GpuMat_type(const GpuMat* obj)
{
	return obj->type();
}
CVAPI(int) GpuMat_depth(const GpuMat* obj)
{
	return obj->depth();
}
CVAPI(int) GpuMat_channels(const GpuMat* obj)
{
	return obj->channels();
}
CVAPI(unsigned int) GpuMat_step1(const GpuMat* obj)
{
	return (unsigned int)obj->step1();
}
CVAPI(CvSize) GpuMat_size(const GpuMat* obj)
{
	return (CvSize)obj->size();
}
CVAPI(bool) GpuMat_empty(const GpuMat* obj)
{
	return obj->empty();
}

CVAPI(const uchar*) GpuMat_ptr(const GpuMat* obj, int y)
{
	return obj->ptr(y);
}

/*
    MatExpr_<MatExpr_Op4_<Mat, Mat, double, char, Mat, MatOp_MulDiv_<Mat> >, Mat>
    // per-element matrix multiplication by means of matrix expressions
    mul(const Mat& m, double scale=1) const;
    MatExpr_<MatExpr_Op4_<Mat, Mat, double, char, Mat, MatOp_MulDiv_<Mat> >, Mat>
    mul(const MatExpr_<MatExpr_Op2_<Mat, double, Mat, MatOp_Scale_<Mat> >, Mat>& m, double scale=1) const;
    MatExpr_<MatExpr_Op4_<Mat, Mat, double, char, Mat, MatOp_MulDiv_<Mat> >, Mat>    
    mul(const MatExpr_<MatExpr_Op2_<Mat, double, Mat, MatOp_DivRS_<Mat> >, Mat>& m, double scale=1) const;
 */   
#pragma endregion

#endif