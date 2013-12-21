/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WMAT_H_
#define _CPP_WMAT_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/core/core.hpp>


#pragma region Init and Disposal
CVAPI(int) Mat_sizeof()
{
	return sizeof(cv::Mat);
}
CVAPI(void) Mat_delete(cv::Mat* obj)
{
	delete obj;
}
CVAPI(cv::Mat*) Mat_new1()
{
	return new cv::Mat();
}
CVAPI(cv::Mat*) Mat_new2(int rows, int cols, int type)
{
	return new cv::Mat(rows, cols, type);
}
CVAPI(cv::Mat*) Mat_new3(int rows, int cols, int type, CvScalar s)
{
	return new cv::Mat(rows, cols, type, s);
}
CVAPI(cv::Mat*) Mat_new4(int rows, int cols, int type, void* data, size_t step)
{
	return new cv::Mat(rows, cols, type, data, step);
}
CVAPI(cv::Mat*) Mat_new5(const cv::Mat* m, CvSlice rowRange, CvSlice colRange)
{
	return new cv::Mat(*m, (cv::Range)rowRange, (cv::Range)colRange);
}
CVAPI(cv::Mat*) Mat_new6(const cv::Mat* m, CvRect roi)
{
	return new cv::Mat(*m, (cv::Rect)roi);
}
CVAPI(cv::Mat*) Mat_new7(const CvMat* m, bool copyData)
{
	return new cv::Mat(m, copyData);
}
CVAPI(cv::Mat*) Mat_new8(const IplImage* img, bool copyData)
{
	return new cv::Mat(img, copyData);
}
CVAPI(cv::Mat*) Mat_new9(uchar* vec, int vecSize, int depthType, int elemSize, bool copyData)
{
	cv::Mat* mat = new cv::Mat();
	if( !copyData )
    {
        mat->rows = vecSize;
        mat->cols = 1;
        mat->step = elemSize;
        mat->data = mat->datastart = vec;
        mat->dataend = mat->datastart + mat->rows*mat->step;
    }
    else
	{
		cv::Mat(vecSize, 1, depthType, vec).copyTo(*mat);
	}
	return mat;
}
#pragma endregion

#pragma region Fields
CVAPI(int) Mat_flags(const cv::Mat* obj)
{
	return obj->flags;
}
CVAPI(int) Mat_rows(const cv::Mat* obj)
{
	return obj->rows;
}
CVAPI(int) Mat_cols(const cv::Mat* obj)
{
	return obj->cols;
}
CVAPI(size_t) Mat_step(const cv::Mat* obj)
{
	return obj->step;
}
CVAPI(uchar*) Mat_data(const cv::Mat* obj)
{
	return obj->data;
}
CVAPI(int*) Mat_refcount(const cv::Mat* obj)
{
	return obj->refcount;
}
CVAPI(uchar*) Mat_datastart(const cv::Mat* obj)
{
	return obj->datastart;
}
CVAPI(uchar*) Mat_dataend(const cv::Mat* obj)
{
	return obj->dataend;
}
#pragma endregion

#pragma region Operators
CVAPI(void) Mat_opUnaryMinus(cv::Mat* src, cv::Mat* dst)
{
	cv::Mat m = *src;
	*dst = -m;
}
CVAPI(void) Mat_opBinaryPlus1(cv::Mat* src1, cv::Mat* src2, cv::Mat* dst)
{
	*dst = (*src1) + (*src2);
}
CVAPI(void) Mat_opBinaryPlus2(cv::Mat* src1, cv::Scalar src2, cv::Mat* dst)
{
	*dst = (*src1) + src2;
}
CVAPI(void) Mat_opBinaryMinus1(cv::Mat* src1, cv::Mat* src2, cv::Mat* dst)
{
	*dst = (*src1) - (*src2);
}
CVAPI(void) Mat_opBinaryMinus2(cv::Mat* src1, cv::Scalar src2, cv::Mat* dst)
{
	*dst = (*src1) - src2;
}
CVAPI(void) Mat_opBinaryMultiply(cv::Mat* src1, cv::Mat* src2, cv::Mat* dst)
{
	*dst = (*src1) * (*src2);
}
CVAPI(void) Mat_opBinaryDivide(cv::Mat* src1, cv::Mat* src2, cv::Mat* dst)
{
	*dst = (*src1) / (*src2);
}

CVAPI(void) Mat_opRange1(cv::Mat* src, CvRect roi, cv::Mat* dst)
{
	*dst = (*src)(roi);
}
CVAPI(void) Mat_opRange2(cv::Mat* src, CvSlice rowRange, CvSlice colRange, cv::Mat* dst)
{
	*dst = (*src)(rowRange, colRange);
}

CVAPI(void) Mat_opCvMat(cv::Mat* obj, CvMat* value)
{
	CvMat mat = (CvMat)(*obj);
	*value = mat;
}
CVAPI(void) Mat_opIplImage(cv::Mat* obj, IplImage* value)
{
	IplImage ipl = (IplImage)(*obj);
	*value = ipl;
}
#pragma endregion

#pragma region Methods
CVAPI(void) Mat_row(cv::Mat* obj, int y, cv::Mat* outValue)
{
	*outValue = obj->row(y);
}
CVAPI(void) Mat_col(cv::Mat* obj, int x, cv::Mat* outValue)
{
	*outValue = obj->col(x);
}
CVAPI(void) Mat_rowRange(cv::Mat* obj, int startrow, int endrow, cv::Mat* outValue)
{
	*outValue = obj->rowRange(startrow, endrow);
}
CVAPI(void) Mat_colRange(cv::Mat* obj, int startcol, int endcol, cv::Mat* outValue)
{
	*outValue = obj->colRange(startcol, endcol);
}
CVAPI(void) Mat_diag1(cv::Mat* obj, int d, cv::Mat* outValue)
{
	*outValue = obj->diag(d);
}
CVAPI(void) Mat_diag2(cv::Mat* d, cv::Mat* outValue)
{
	*outValue = cv::Mat::diag(*d);
}
CVAPI(void) Mat_clone(cv::Mat* obj, cv::Mat* outValue)
{
	*outValue = obj->clone();
}
CVAPI(void) Mat_copyTo1(cv::Mat* obj, cv::Mat* m)
{
	obj->copyTo(*m);
}
CVAPI(void) Mat_copyTo2(cv::Mat* obj, cv::Mat* m, cv::Mat* mask)
{
	obj->copyTo(*m, *mask);
}
CVAPI(void) Mat_convertTo(cv::Mat* obj, cv::Mat* m, int rtype, double alpha, double beta) 
{
	obj->convertTo(*m, rtype, alpha, beta);
}
CVAPI(void) Mat_assignTo(cv::Mat* obj, cv::Mat* m, int type)
{
	obj->assignTo(*m, type);
}
CVAPI(void) Mat_setTo(cv::Mat* obj, cv::Mat* value, cv::Mat* mask, cv::Mat* dst)
{
	if(mask == NULL)
		*dst = obj->setTo(*value);
	else
		*dst = obj->setTo(*value, *mask);
}
CVAPI(void) Mat_reshape(cv::Mat* obj, int cn, int rows, cv::Mat* outValue)
{
	obj->reshape(cn, rows);
}
CVAPI(void) Mat_cross(cv::Mat* obj, cv::Mat* m, cv::Mat* outValue)
{
	*outValue = obj->cross(*m);
}
CVAPI(double) Mat_dot(cv::Mat* obj, cv::Mat* m)
{
	return obj->dot(*m);
}

CVAPI(void) Mat_zeros(int rows, int cols, int type, cv::Mat* outValue)
{
	*outValue = cv::Mat::zeros(rows, cols, type);
}
CVAPI(void) Mat_ones(int rows, int cols, int type, cv::Mat* outValue)
{
	*outValue = cv::Mat::ones(rows, cols, type);
}
CVAPI(void) Mat_eye(int rows, int cols, int type, cv::Mat* outValue)
{
	*outValue = cv::Mat::eye(rows, cols, type);
}

CVAPI(void) Mat_create(cv::Mat* obj, int rows, int cols, int type)
{
	obj->create(rows, cols, type);
}
CVAPI(void) Mat_locateROI(cv::Mat* obj, CvSize* wholeSize, CvPoint* ofs)
{
	cv::Size _wholeSize;
	cv::Point _ofs;
	obj->locateROI(_wholeSize, _ofs);
	*wholeSize = (CvSize)_wholeSize;
	*ofs = (CvPoint)_ofs;
}
CVAPI(void) Mat_adjustROI(cv::Mat* obj, int dtop, int dbottom, int dleft, int dright, cv::Mat* dst)
{
	*dst = obj->adjustROI(dtop, dbottom, dleft, dright);
}


CVAPI(void) Mat_t(cv::Mat* src, cv::Mat* dst)
{
	*dst = src->t();
}

CVAPI(void) Mat_inv(cv::Mat* src, int method, cv::Mat* dst)
{
	*dst = src->inv(method);
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