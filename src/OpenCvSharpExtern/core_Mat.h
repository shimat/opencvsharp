/*
* (C) 2008-2014 Schima
* This code is licenced under the LGPL.
*/

#ifndef _CPP_CORE_MAT_H_
#define _CPP_CORE_MAT_H_

#include "include_opencv.h"


#pragma region Init & Release
CVAPI(uint64) core_Mat_sizeof()
{
	return sizeof(cv::Mat);
}

CVAPI(cv::Mat*) core_Mat_new1()
{
	return new cv::Mat();
}
CVAPI(cv::Mat*) core_Mat_new2(int rows, int cols, int type)
{
	return new cv::Mat(rows, cols, type); 
}
CVAPI(cv::Mat*) core_Mat_new3(int rows, int cols, int type, CvScalar scalar)
{
	return new cv::Mat(rows, cols, type, scalar);
}
CVAPI(cv::Mat*) core_Mat_new4(cv::Mat *mat, CvSlice rowRange, CvSlice colRange)
{
	return new cv::Mat(*mat, rowRange, colRange);
}
CVAPI(cv::Mat*) core_Mat_new5(cv::Mat *mat, CvSlice rowRange)
{
	return new cv::Mat(*mat, rowRange);
}
CVAPI(cv::Mat*) core_Mat_new6(cv::Mat *mat, CvRect roi)
{
	return new cv::Mat(*mat, roi);
}

CVAPI(void) core_Mat_release(cv::Mat *self)
{
	self->release();
}
CVAPI(void) core_Mat_delete(cv::Mat *self)
{
	delete self;
}
#pragma endregion

#pragma region Functions
CVAPI(cv::Mat*) core_Mat_adjustROI(cv::Mat *self, int dtop, int dbottom, int dleft, int dright)
{
	cv::Mat ret = self->adjustROI(dtop, dbottom, dleft, dright);
	return new cv::Mat(ret);
}

CVAPI(void) core_Mat_assignTo1(cv::Mat *self, cv::Mat *m)
{
	self->assignTo(*m);
}
CVAPI(void) core_Mat_assignTo2(cv::Mat *self, cv::Mat *m, int type)
{
	self->assignTo(*m, type);
}

CVAPI(int) core_Mat_channels(cv::Mat *self)
{
	return self->channels();
}

CVAPI(int) core_Mat_checkVector1(cv::Mat *self, int elemChannels)
{
	return self->checkVector(elemChannels);
}
CVAPI(int) core_Mat_checkVector2(cv::Mat *self, int elemChannels, int depth)
{
	return self->checkVector(elemChannels, depth);
}
CVAPI(int) core_Mat_checkVector3(cv::Mat *self, int elemChannels, int depth, int requireContinuous)
{
	return self->checkVector(elemChannels, depth, requireContinuous != 0);
}

CVAPI(cv::Mat*) core_Mat_clone(cv::Mat *self)
{
	cv::Mat ret = self->clone();
	return new cv::Mat(ret);
}

CVAPI(cv::Mat*) core_Mat_col(cv::Mat *self, int x)
{
	cv::Mat ret = self->col(x);
	return new cv::Mat(ret);
}

CVAPI(int) core_Mat_cols(cv::Mat *self)
{
	return self->cols;
}

CVAPI(cv::Mat*) core_Mat_colRange(cv::Mat *self, int startCol, int endCol)
{ 
	cv::Mat ret = self->colRange(startCol, endCol);
    return new cv::Mat(ret);
}


CVAPI(int) core_Mat_dims(cv::Mat *self)
{
	return self->dims;
}

CVAPI(void) core_Mat_convertTo1(cv::Mat *self, cv::Mat *m, int rtype)
{
	self->convertTo(*m, rtype);
}
CVAPI(void) core_Mat_convertTo2(cv::Mat *self, cv::Mat *m, int rtype, double alpha)
{
	self->convertTo(*m, rtype, alpha);
}
CVAPI(void) core_Mat_convertTo3(cv::Mat *self, cv::Mat *m, int rtype, double alpha, double beta)
{
	self->convertTo(*m, rtype, alpha, beta);
}

CVAPI(void) core_Mat_copyTo(cv::Mat *self, cv::Mat *m, cv::Mat *mask)
{
	cv::Mat &maskMat = (mask == NULL) ? cv::Mat() : *mask;
	self->copyTo(*m, maskMat);
}


CVAPI(void) core_Mat_create1(cv::Mat *self, int rows, int cols, int type)
{
	self->create(rows, cols, type);
}
CVAPI(void) core_Mat_create2(cv::Mat *self, int ndims, const int *sizes, int type)
{
	self->create(ndims, sizes, type);
}

CVAPI(cv::Mat*) core_Mat_cross(cv::Mat *self, cv::Mat *m)
{
	cv::Mat ret = self->cross(*m);
    return new cv::Mat(ret);
}


CVAPI(uchar*) core_Mat_data(cv::Mat *self)
{
	return self->data;
}
CVAPI(uchar*) core_Mat_datastart(cv::Mat *self)
{
	return self->datastart;
}
CVAPI(uchar*) core_Mat_dataend(cv::Mat *self)
{
	return self->dataend;
}

CVAPI(int) core_Mat_depth(cv::Mat *self)
{
	return self->depth();
}

     
CVAPI(cv::Mat*) core_Mat_diag1(cv::Mat *self)
{
	cv::Mat ret = self->diag();
    return new cv::Mat(ret);
}
CVAPI(cv::Mat*) core_Mat_diag2(cv::Mat *self, int d)
{
	cv::Mat ret = self->diag(d);
    return new cv::Mat(ret);
}

CVAPI(double) core_Mat_dot(cv::Mat *self, cv::Mat *m)
{
	return self->dot(*m);
}

CVAPI(int64) core_Mat_elemSize(cv::Mat *self)
{
	return self->elemSize();
}

CVAPI(int64) core_Mat_elemSize1(cv::Mat *self)
{
	return self->elemSize1();
}

CVAPI(int) core_Mat_empty(cv::Mat *self)
{
	return self->empty() ? 1 : 0;
}

CVAPI(cv::MatExpr*) core_Mat_eye(int rows, int cols, int type)
{	
	cv::MatExpr eye = cv::Mat::eye(rows, cols, type);
	cv::MatExpr *ret = new cv::MatExpr(eye);
	return ret;
}

CVAPI(cv::Mat*) core_Mat_inv1(cv::Mat *self)
{
	cv::Mat ret = self->inv();
    return new cv::Mat(ret);
}
CVAPI(cv::Mat*) core_Mat_inv2(cv::Mat *self, int method)
{
	cv::Mat ret = self->inv(method);
    return new cv::Mat(ret);
}

CVAPI(int) core_Mat_isContinuous(cv::Mat *self)
{
	return self->isContinuous() ? 1 : 0;
}

CVAPI(int) core_Mat_isSubmatrix(cv::Mat *self)
{
	return self->isSubmatrix() ? 1 : 0;
}

CVAPI(void) core_Mat_locateROI(cv::Mat *self, CvSize *wholeSize, CvPoint *ofs)
{
	cv::Size wholeSize2;
	cv::Point ofs2;
	self->locateROI(wholeSize2, ofs2);
	*wholeSize = cvSize(wholeSize2.width, wholeSize2.height);
	*ofs = cvPoint(ofs2.x, ofs2.y);
}
 

CVAPI(cv::MatExpr*) core_Mat_mul1(cv::Mat *self, cv::Mat *m)
{
	cv::MatExpr ret = self->mul(*m);
	return new cv::MatExpr(ret);
}
CVAPI(cv::MatExpr*) core_Mat_mul2(cv::Mat *self, cv::Mat *m, double scale)
{
	cv::MatExpr ret = self->mul(*m, scale);
	return new cv::MatExpr(ret);
}

CVAPI(cv::MatExpr*) core_Mat_ones1(int rows, int cols, int type)
{
	cv::MatExpr ret = cv::Mat::ones(rows, cols, type);
	return new cv::MatExpr(ret);
}
CVAPI(cv::MatExpr*) core_Mat_ones2(int ndims, const int *sz, int type)
{
	//cv::MatExpr ret = cv::Mat::ones(ndims, sz, type);
	//return new cv::MatExpr(ret);
	return NULL;
}

CVAPI(void) core_Mat_push_back(cv::Mat *self, cv::Mat *m)
{
	self->push_back(*m);
}

CVAPI(cv::Mat*) core_Mat_reshape1(cv::Mat *self, int cn)
{
	cv::Mat ret = self->reshape(cn);
	return new cv::Mat(ret);
}
CVAPI(cv::Mat*) core_Mat_reshape2(cv::Mat *self, int cn, int rows)
{
	cv::Mat ret = self->reshape(cn, rows);
	return new cv::Mat(ret);
}
CVAPI(cv::Mat*) core_Mat_reshape3(cv::Mat *self, int cn, int newndims, const int* newsz)
{
	cv::Mat ret = self->reshape(cn, newndims, newsz);
	return new cv::Mat(ret);
}

CVAPI(cv::Mat*) core_Mat_row(cv::Mat *self, int y)
{
	cv::Mat ret = self->row(y);
	return new cv::Mat(ret);
}

CVAPI(cv::Mat*) core_Mat_rowRange(cv::Mat *self, int startRow, int endRow)
{
	cv::Mat ret = self->rowRange(startRow, endRow);
	return new cv::Mat(ret);
}

CVAPI(int) core_Mat_rows(cv::Mat *self)
{
	return self->rows;
}

CVAPI(cv::Mat*) core_Mat_setTo1(cv::Mat *self, CvScalar value, cv::Mat *mask)
{
	cv::InputArray maskMat = (mask == NULL) ? cv::noArray() : *mask;
	cv::Mat ret = self->setTo((cv::Scalar)value, maskMat);
	return new cv::Mat(ret);
}
CVAPI(cv::Mat*) core_Mat_setTo2(cv::Mat *self, cv::Mat *value, cv::Mat *mask)
{
	cv::InputArray maskMat = (mask == NULL) ? cv::noArray() : *mask;
	cv::Mat ret = self->setTo(*value, maskMat);
	return new cv::Mat(ret);
}

CVAPI(CvSize) core_Mat_size(cv::Mat *self)
{
	CvSize size = self->size();
	return size;
}
CVAPI(int) core_Mat_sizeAt(cv::Mat *self, int i)
{
	int size = self->size[i];
	return size;
}

CVAPI(int64) core_Mat_step11(cv::Mat *self)
{
	return self->step1();
}
CVAPI(int64) core_Mat_step12(cv::Mat *self, int i)
{
	return self->step1(i);
}

CVAPI(int64) core_Mat_step(cv::Mat *self)
{
	return self->step;
}
CVAPI(int64) core_Mat_stepAt(cv::Mat *self, int i)
{
	return self->step[i];
}

CVAPI(cv::Mat*) core_Mat_subMat1(cv::Mat *self, int rowStart, int rowEnd, int colStart, int colEnd)
{
	cv::Range rowRange(rowStart, rowEnd);
	cv::Range colRange(colStart, colEnd);
	cv::Mat ret = (*self)(rowRange, colRange);
	return new cv::Mat(ret);
}
CVAPI(cv::Mat*) core_Mat_subMat2(cv::Mat *self, int nRanges, CvSlice *ranges)
{
	std::vector<cv::Range> rangesVec;
	for (int i = 0; i < nRanges; i++)
	{
		rangesVec.push_back(ranges[i]);
	}
	cv::Mat ret = (*self)(&rangesVec[0]);
	return new cv::Mat(ret);
}

CVAPI(cv::MatExpr*) core_Mat_t(cv::Mat *self)
{
	cv::MatExpr expr = self->t();
	return new cv::MatExpr(expr);
}

CVAPI(int64) core_Mat_total(cv::Mat *self)
{
	return self->total();
}

CVAPI(int) core_Mat_type(cv::Mat *self)
{
	return self->type();
}

CVAPI(cv::MatExpr*) core_Mat_zeros1(int rows, int cols, int type)
{
	cv::MatExpr expr = cv::Mat::zeros(rows, cols, type);
	return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_zeros2(int ndims, const int *sz, int type)
{
	//cv::MatExpr expr = cv::Mat::zeros(ndims, sz, type);
	//return new cv::MatExpr(expr);
	return NULL; 
}

CVAPI(char*) core_Mat_dump(cv::Mat *self)
{
	std::stringstream s;
	s << *self;
	std::string str = s.str();

	const char *src = str.c_str();
	char *dst = new char[str.length() + 1];
	std::memcpy(dst, src, str.length() + 1);
	return dst;
}
CVAPI(void) core_Mat_dump_delete(char *buf)
{
	delete [] buf;
}

CVAPI(uchar*) core_Mat_ptr1d(cv::Mat *self, int i0)
{
	return self->ptr(i0);
}
CVAPI(uchar*) core_Mat_ptr2d(cv::Mat *self, int i0, int i1)
{
	return self->ptr(i0, i1);
}
CVAPI(uchar*) core_Mat_ptr3d(cv::Mat *self, int i0, int i1, int i2)
{
	return self->ptr(i0, i1, i2);
}
CVAPI(uchar*) core_Mat_ptrnd(cv::Mat *self, int *idx)
{
	return self->ptr(idx);
}
        
/*
        // javadoc:Mat::put(row,col,data)
CVAPI(int) core_Mat_Put(int row, int col, float[] data)
        {
        }

        // javadoc:Mat::put(row,col,data)
CVAPI(int) core_Mat_Put(int row, int col, int[] data)
        {

        }

        // javadoc:Mat::put(row,col,data)
CVAPI(int) core_Mat_Put(int row, int col, short[] data)
        {

        }

        // javadoc:Mat::put(row,col,data)
CVAPI(int) core_Mat_Put(int row, int col, byte[] data)
        {

        }

        // javadoc:Mat::get(row,col,data)
CVAPI(int) core_Mat_Get(int row, int col, byte[] data)
        {

        }

        // javadoc:Mat::get(row,col,data)
CVAPI(int) core_Mat_Get(int row, int col, short[] data)
        {

        }

        // javadoc:Mat::get(row,col,data)
CVAPI(int) core_Mat_Get(int row, int col, int[] data)
        {

        }

        // javadoc:Mat::get(row,col,data)
CVAPI(int) core_Mat_Get(int row, int col, float[] data)
        {

        }

        // javadoc:Mat::get(row,col,data)
CVAPI(int) core_Mat_Get(int row, int col, double[] data)
        {

        }

        // javadoc:Mat::get(row,col)
CVAPI(double[]) Get(int row, int col)
        {
            
            //return nGet(ptr, row, col);
        }

*/
#pragma endregion

#endif