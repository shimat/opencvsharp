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
CVAPI(cv::Mat*) core_Mat_new3(int rows, int cols, int type, MyCvScalar scalar)
{
    return new cv::Mat(rows, cols, type, cpp(scalar));
}
CVAPI(cv::Mat*) core_Mat_new4(cv::Mat *mat, cv::Range rowRange, cv::Range colRange)
{
    return new cv::Mat(*mat, rowRange, colRange);
}
CVAPI(cv::Mat*) core_Mat_new5(cv::Mat *mat, cv::Range rowRange)
{
    return new cv::Mat(*mat, rowRange);
}
CVAPI(cv::Mat*) core_Mat_new6(cv::Mat *mat, cv::Range *ranges)
{
    return new cv::Mat(*mat, ranges);
}
CVAPI(cv::Mat*) core_Mat_new7(cv::Mat *mat, MyCvRect roi)
{
    return new cv::Mat(*mat, cpp(roi));
}
CVAPI(cv::Mat*) core_Mat_new8(int rows, int cols, int type, void* data, size_t step)
{
    return new cv::Mat(rows, cols, type, data, step);
}
CVAPI(cv::Mat*) core_Mat_new9(int ndims, const int* sizes, int type, void* data, const size_t* steps)
{
    return new cv::Mat(ndims, sizes, type, data, steps);
}

CVAPI(cv::Mat*) core_Mat_new10(int ndims, int* sizes, int type)
{
    return new cv::Mat(ndims, sizes, type);
}
CVAPI(cv::Mat*) core_Mat_new11(int ndims, int* sizes, int type, MyCvScalar s)
{
    return new cv::Mat(ndims, sizes, type, cpp(s));
}

CVAPI(cv::Mat*) core_Mat_new_FromIplImage(IplImage *img, int copyData)
{
    cv::Size size(img->height, img->width);
    cv::Mat m(size, CV_MAKETYPE(img->depth, img->nChannels), img->imageData, img->widthStep);
    if (copyData)
        return new cv::Mat(m.clone());
    else
        return new cv::Mat(m);
}

CVAPI(cv::Mat*) core_Mat_new_FromCvMat(CvMat *mat, int copyData)
{
    cv::Size size(mat->rows, mat->cols);
    cv::Mat m(size, mat->type, (mat->data).ptr);
    if (copyData)
        return new cv::Mat(m.clone());
    else
        return new cv::Mat(m);
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

CVAPI(cv::Mat*) core_Mat_col_toMat(cv::Mat *self, int x)
{
    cv::Mat ret = self->col(x);
    return new cv::Mat(ret);
}
CVAPI(cv::MatExpr*) core_Mat_col_toMatExpr(cv::Mat *self, int x)
{
    cv::Mat ret = self->col(x);
    return new cv::MatExpr(ret);
}

CVAPI(int) core_Mat_cols(cv::Mat *self)
{
    return self->cols;
}

CVAPI(cv::Mat*) core_Mat_colRange_toMat(cv::Mat *self, int startCol, int endCol)
{ 
    cv::Mat ret = self->colRange(startCol, endCol);
    return new cv::Mat(ret);
}
CVAPI(cv::MatExpr*) core_Mat_colRange_toMatExpr(cv::Mat *self, int startCol, int endCol)
{
    cv::Mat ret = self->colRange(startCol, endCol);
    return new cv::MatExpr(ret);
}

CVAPI(int) core_Mat_dims(cv::Mat *self)
{
    return self->dims;
}

CVAPI(void) core_Mat_convertTo(cv::Mat *self, cv::Mat *m, int rtype, double alpha, double beta)
{
    self->convertTo(*m, rtype, alpha, beta);
}

CVAPI(void) core_Mat_copyTo(cv::Mat *self, cv::Mat *m, cv::Mat *mask)
{
    const cv::Mat &maskMat = (mask == NULL) ? cv::Mat() : *mask;
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
CVAPI(const uchar*) core_Mat_datastart(cv::Mat *self)
{
    return self->datastart;
}
CVAPI(const uchar*) core_Mat_dataend(cv::Mat *self)
{
    return self->dataend;
}
CVAPI(const uchar*) core_Mat_datalimit(cv::Mat *self)
{
    return self->datalimit;
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
CVAPI(cv::Mat*) core_Mat_diag3(cv::Mat *self)
{
    cv::Mat ret = cv::Mat::diag(*self);
    return new cv::Mat(ret);
}

CVAPI(double) core_Mat_dot(cv::Mat *self, cv::Mat *m)
{
    return self->dot(*m);
}

CVAPI(uint64) core_Mat_elemSize(cv::Mat *self)
{
    return self->elemSize();
}

CVAPI(uint64) core_Mat_elemSize1(cv::Mat *self)
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

CVAPI(void) core_Mat_locateROI(cv::Mat *self, MyCvSize *wholeSize, MyCvPoint *ofs)
{
    cv::Size wholeSize2;
    cv::Point ofs2;
    self->locateROI(wholeSize2, ofs2);
    *wholeSize = c(cv::Size(wholeSize2.width, wholeSize2.height));
    *ofs = c(cv::Point(ofs2.x, ofs2.y));
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

CVAPI(cv::Mat*) core_Mat_row_toMat(cv::Mat *self, int y)
{
    cv::Mat ret = self->row(y);
    return new cv::Mat(ret);
}
CVAPI(cv::MatExpr*) core_Mat_row_toMatExpr(cv::Mat *self, int y)
{
    cv::Mat ret = self->row(y);
    return new cv::MatExpr(ret);
}

CVAPI(cv::Mat*) core_Mat_rowRange_toMat(cv::Mat *self, int startRow, int endRow)
{
    cv::Mat ret = self->rowRange(startRow, endRow);
    return new cv::Mat(ret);
}
CVAPI(cv::MatExpr*) core_Mat_rowRange_toMatExpr(cv::Mat *self, int startRow, int endRow)
{
    cv::Mat ret = self->rowRange(startRow, endRow);
    return new cv::MatExpr(ret);
}

CVAPI(int) core_Mat_rows(cv::Mat *self)
{
    return self->rows;
}

CVAPI(cv::Mat*) core_Mat_setTo_Scalar(cv::Mat *self, MyCvScalar value, cv::Mat *mask)
{
    // crash
    // core_Mat_setTo_Scalar(cv::Mat *self, MyCvScalar value, cv::InputArray *mask)

    cv::Mat ret;
    if (mask == NULL)
        ret = self->setTo(cpp(value));
    else 
        ret = self->setTo(cpp(value), entity(mask));
    return new cv::Mat(ret);
}
CVAPI(cv::Mat*) core_Mat_setTo_InputArray(cv::Mat *self, cv::_InputArray *value, cv::Mat *mask)
{
    cv::Mat ret = self->setTo(*value, entity(mask));
    return new cv::Mat(ret);
}

CVAPI(MyCvSize) core_Mat_size(cv::Mat *self)
{
    return c(self->size());
}
CVAPI(int) core_Mat_sizeAt(cv::Mat *self, int i)
{
    int size = self->size[i];
    return size;
}

CVAPI(uint64) core_Mat_step11(cv::Mat *self)
{
    return self->step1();
}
CVAPI(uint64) core_Mat_step12(cv::Mat *self, int i)
{
    return self->step1(i);
}

CVAPI(uint64) core_Mat_step(cv::Mat *self)
{
    return self->step;
}
CVAPI(uint64) core_Mat_stepAt(cv::Mat *self, int i)
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
CVAPI(cv::Mat*) core_Mat_subMat2(cv::Mat *self, int nRanges, MyCvSlice *ranges)
{
    std::vector<cv::Range> rangesVec;
    for (int i = 0; i < nRanges; i++)
    {
        rangesVec.push_back(cpp(ranges[i]));
    }
    cv::Mat ret = (*self)(&rangesVec[0]);
    return new cv::Mat(ret);
}

CVAPI(cv::Mat*) core_Mat_t(cv::Mat *self)
{
    cv::Mat expr = self->t();
    return new cv::Mat(expr);
}

CVAPI(uint64) core_Mat_total(cv::Mat *self)
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
CVAPI(cv::MatExpr*) core_Mat_zeros2(int ndims, const int *sz, int type) // Not defined in .lib 
{
    //cv::MatExpr expr = cv::Mat::zeros(ndims, sz, type);
    //return new cv::MatExpr(expr);
    return NULL; 
}

CVAPI(char*) core_Mat_dump(cv::Mat *self, const char *format)
{
    std::stringstream s;    
    if (format == NULL)
        s << *self;
    else
        s << cv::format(*self, 0);
    std::string str = s.str();

    const char *src = str.c_str();
    char *dst = new char[str.length() + 1];
    std::memcpy(dst, src, str.length() + 1);
    return dst;
}
CVAPI(void) core_Mat_dump_delete(char *buf)
{
    delete[] buf;
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

CVAPI(void) core_Mat_reserve(cv::Mat *obj, size_t sz)
{
    obj->reserve(sz);
}
CVAPI(void) core_Mat_resize1(cv::Mat *obj, size_t sz)
{
    obj->resize(sz);
}
CVAPI(void) core_Mat_resize2(cv::Mat *obj, size_t sz, MyCvScalar s)
{
    obj->resize(sz, cpp(s));
}
CVAPI(void) core_Mat_pop_back(cv::Mat *obj, size_t nelems)
{
    obj->pop_back(nelems);
}
        
#pragma endregion

#pragma region Operators

CVAPI(void) core_Mat_assignment_FromMat(cv::Mat *self, cv::Mat *newMat)
{
    *self = *newMat;
}
CVAPI(void) core_Mat_assignment_FromMatExpr(cv::Mat *self, cv::MatExpr *newMatExpr)
{
    *self = *newMatExpr;
}
CVAPI(void) core_Mat_assignment_FromScalar(cv::Mat *self, MyCvScalar scalar)
{
    *self = cpp(scalar);
}

CVAPI(void) core_Mat_IplImage(cv::Mat *self, IplImage *outImage)
{
    *outImage = IplImage();
    IplImage inImage = (IplImage)(*self);
    memcpy(outImage, &inImage, sizeof(IplImage));
}
CVAPI(void) core_Mat_IplImage_alignment(cv::Mat *self, IplImage **outImage)
{
    // キャストの結果を参考に使う.
    // メモリ管理の問題から、直接は使わない.
    IplImage dummy = (IplImage)(*self);
    // alignmentをそろえる
    IplImage *img = cvCreateImage(cvSize(dummy.width, dummy.height), dummy.depth, dummy.nChannels);
    int height = img->height;
    size_t sstep = self->step;
    size_t dstep = img->widthStep;
    for (int i = 0; i < height; ++i)
    {
        char *dp = img->imageData + (dstep * i);
        char *sp = (char*)(self->data) + (sstep * i);
        memcpy(dp, sp, sstep);
    }
    *outImage = img;
}

CVAPI(void) core_Mat_CvMat(cv::Mat *self, CvMat *outMat)
{
    *outMat = CvMat();
    CvMat inMat = (CvMat)(*self);
    memcpy(outMat, &inMat, sizeof(CvMat));
}

CVAPI(cv::MatExpr*) core_Mat_operatorUnaryMinus(cv::Mat *mat)
{
    cv::MatExpr expr = -(*mat);
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorAdd_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) + (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorAdd_MatScalar(cv::Mat *a, MyCvScalar s)
{
    cv::MatExpr expr = (*a) + cpp(s);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorAdd_ScalarMat(MyCvScalar s, cv::Mat *a)
{
    cv::MatExpr expr = cpp(s) + (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorMinus_Mat(cv::Mat *a)
{
    cv::MatExpr expr = -(*a);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorSubtract_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) - (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorSubtract_MatScalar(cv::Mat *a, MyCvScalar s)
{
    cv::MatExpr expr = (*a) - cpp(s);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorSubtract_ScalarMat(MyCvScalar s, cv::Mat *a)
{
    cv::MatExpr expr = cpp(s) - (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorMultiply_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) * (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorMultiply_MatDouble(cv::Mat *a, double s)
{
    cv::MatExpr expr = (*a) * s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorMultiply_DoubleMat(double s, cv::Mat *a)
{
    cv::MatExpr expr = s * (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorDivide_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) / (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorDivide_MatDouble(cv::Mat *a, double s)
{
    cv::MatExpr expr = (*a) / s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorDivide_DoubleMat(double s, cv::Mat *a)
{
    cv::MatExpr expr = s / (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorAnd_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) & (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorAnd_MatDouble(cv::Mat *a, double s)
{
    cv::MatExpr expr = (*a) & s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorAnd_DoubleMat(double s, cv::Mat *a)
{
    cv::MatExpr expr = s & (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorOr_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) | (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorOr_MatDouble(cv::Mat *a, double s)
{
    cv::MatExpr expr = (*a) | s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorOr_DoubleMat(double s, cv::Mat *a)
{
    cv::MatExpr expr = s | (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorXor_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) ^ (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorXor_MatDouble(cv::Mat *a, double s)
{
    cv::MatExpr expr = (*a) ^ s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorXor_DoubleMat(double s, cv::Mat *a)
{
    cv::MatExpr expr = s ^ (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorNot(cv::Mat *a)
{
    cv::MatExpr expr = ~(*a);
    return new cv::MatExpr(expr);
}


// Comparison Operators

// <
CVAPI(cv::MatExpr*) core_Mat_operatorLT_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) < (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorLT_DoubleMat(double a, cv::Mat *b)
{
    cv::MatExpr expr = a < (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorLT_MatDouble(cv::Mat *a, double b)
{
    cv::MatExpr expr = (*a) < b; 
    return new cv::MatExpr(expr);
}
// <=
CVAPI(cv::MatExpr*) core_Mat_operatorLE_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) <= (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorLE_DoubleMat(double a, cv::Mat *b)
{
    cv::MatExpr expr = a <= (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorLE_MatDouble(cv::Mat *a, double b)
{
    cv::MatExpr expr = (*a) <= b; 
    return new cv::MatExpr(expr);
}
// >
CVAPI(cv::MatExpr*) core_Mat_operatorGT_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) > (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorGT_DoubleMat(double a, cv::Mat *b)
{
    cv::MatExpr expr = a > (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorGT_MatDouble(cv::Mat *a, double b)
{
    cv::MatExpr expr = (*a) > b; 
    return new cv::MatExpr(expr);
}
// >=
CVAPI(cv::MatExpr*) core_Mat_operatorGE_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) >= (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorGE_DoubleMat(double a, cv::Mat *b)
{
    cv::MatExpr expr = a >= (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorGE_MatDouble(cv::Mat *a, double b)
{
    cv::MatExpr expr = (*a) >= b; 
    return new cv::MatExpr(expr);
}
// ==
CVAPI(cv::MatExpr*) core_Mat_operatorEQ_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) == (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorEQ_DoubleMat(double a, cv::Mat *b)
{
    cv::MatExpr expr = a == (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorEQ_MatDouble(cv::Mat *a, double b)
{
    cv::MatExpr expr = (*a) == b; 
    return new cv::MatExpr(expr);
}
// !=
CVAPI(cv::MatExpr*) core_Mat_operatorNE_MatMat(cv::Mat *a, cv::Mat *b)
{
    cv::MatExpr expr = (*a) != (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorNE_DoubleMat(double a, cv::Mat *b)
{
    cv::MatExpr expr = a != (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorNE_MatDouble(cv::Mat *a, double b)
{
    cv::MatExpr expr = (*a) != b; 
    return new cv::MatExpr(expr);
}

#pragma endregion

CVAPI(cv::MatExpr*) core_abs_Mat(cv::Mat *m)
{
    cv::MatExpr ret = cv::abs(*m);
    return new cv::MatExpr(ret);
}

#pragma region nSet/nGet

template<typename T> 
static int internal_Mat_set(cv::Mat *m, int row, int col, char *buff, int count)
{
    if (!m) return 0;
    if (!buff) return 0;

    count *= sizeof(T);
    int rest = ((m->rows - row) * m->cols - col) * (int)m->elemSize();
    if (count>rest) 
        count = rest;
    int res = count;

    if (m->isContinuous())
    {
        memcpy(m->ptr(row, col), buff, count);
    }
    else 
    {
        // row by row
        int num = (m->cols - col) * (int)m->elemSize(); // 1st partial row
        if (count<num) 
            num = count;
        uchar* data = m->ptr(row++, col);
        while (count>0)
        {
            memcpy(data, buff, num);
            count -= num;
            buff += num;
            num = m->cols * (int)m->elemSize();
            if (count<num) num = count;
            data = m->ptr(row++, 0);
        }
    }
    return res;
}

template<typename T> 
static int internal_Mat_get(cv::Mat *m, int row, int col, char *buff, int count)
{
    if (!m) return 0;
    if (!buff) return 0;

    int bytesToCopy = count * sizeof(T);
    int bytesRestInMat = ((m->rows - row) * m->cols - col) * (int)m->elemSize();
    if (bytesToCopy > bytesRestInMat) 
        bytesToCopy = bytesRestInMat;
    int res = bytesToCopy;

    if (m->isContinuous())
    {
        memcpy(buff, m->ptr(row, col), bytesToCopy);
    }
    else 
    {
        // row by row
        int bytesInRow = (m->cols - col) * (int)m->elemSize(); // 1st partial row
        while (bytesToCopy > 0)
        {
            int len = std::min(bytesToCopy, bytesInRow);
            memcpy(buff, m->ptr(row, col), len);
            bytesToCopy -= len;
            buff += len;
            row++;
            col = 0;
            bytesInRow = m->cols * (int)m->elemSize();
        }
    }
    return res;
}

// unlike other nPut()-s this one (with double[]) should convert input values to correct type
template<typename T>
static void internal_set_item(cv::Mat *mat, int r, int c, double *src, int &count)
{
    T *dst = (T*)mat->ptr(r, c);
    for (int ch = 0; ch < mat->channels() && count > 0; count--, ch++, src++, dst++)
        *dst = cv::saturate_cast<T>(*src);
}


CVAPI(int) core_Mat_nSetB(cv::Mat *obj, int row, int col, uchar *vals, int valsLength)
{
    return internal_Mat_set<char>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetS(cv::Mat *obj, int row, int col, short *vals, int valsLength)
{
    return internal_Mat_set<short>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetI(cv::Mat *obj, int row, int col, int *vals, int valsLength)
{
    return internal_Mat_set<int>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetF(cv::Mat *obj, int row, int col, float *vals, int valsLength)
{
    return internal_Mat_set<float>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetD(cv::Mat *obj, int row, int col, double *vals, int valsLength)
{
    int rest = ((obj->rows - row) * obj->cols - col) * obj->channels();
    int count = valsLength;
    if (count > rest)
        count = rest;
    int res = count;
    double* src = vals;
    int r, c;
    for (c = col; c<obj->cols && count > 0; c++)
    {
        switch (obj->depth()) 
        {
        case CV_8U:  internal_set_item<uchar>(obj, row, c, src, count); break;
        case CV_8S:  internal_set_item<schar>(obj, row, c, src, count); break;
        case CV_16U: internal_set_item<ushort>(obj, row, c, src, count); break;
        case CV_16S: internal_set_item<short>(obj, row, c, src, count); break;
        case CV_32S: internal_set_item<int>(obj, row, c, src, count); break;
        case CV_32F: internal_set_item<float>(obj, row, c, src, count); break;
        case CV_64F: internal_set_item<double>(obj, row, c, src, count); break;
        }
    }
    for (r = row + 1; r < obj->rows && count > 0; r++)
    {
        for (c = 0; c < obj->cols && count > 0; c++)
        {
            switch (obj->depth())
            {
            case CV_8U:  internal_set_item<uchar>(obj, r, c, src, count); break;
            case CV_8S:  internal_set_item<schar>(obj, r, c, src, count); break;
            case CV_16U: internal_set_item<ushort>(obj, r, c, src, count); break;
            case CV_16S: internal_set_item<short>(obj, r, c, src, count); break;
            case CV_32S: internal_set_item<int>(obj, r, c, src, count); break;
            case CV_32F: internal_set_item<float>(obj, r, c, src, count); break;
            case CV_64F: internal_set_item<double>(obj, r, c, src, count); break;
            }
        }
    }
    return res;
}
CVAPI(int) core_Mat_nSetVec3b(cv::Mat *obj, int row, int col, cv::Vec3b *vals, int valsLength)
{
    return internal_Mat_set<cv::Vec3b>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetVec3d(cv::Mat *obj, int row, int col, cv::Vec3d *vals, int valsLength)
{
    return internal_Mat_set<cv::Vec3d>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetVec4f(cv::Mat *obj, int row, int col, cv::Vec4f *vals, int valsLength)
{
    return internal_Mat_set<cv::Vec4f>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetVec6f(cv::Mat *obj, int row, int col, cv::Vec6f *vals, int valsLength)
{
    return internal_Mat_set<cv::Vec6f>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetVec4i(cv::Mat *obj, int row, int col, cv::Vec4i *vals, int valsLength)
{
    return internal_Mat_set<cv::Vec4i>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetPoint(cv::Mat *obj, int row, int col, cv::Point *vals, int valsLength)
{
    return internal_Mat_set<cv::Point>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetPoint2f(cv::Mat *obj, int row, int col, cv::Point2f *vals, int valsLength)
{
    return internal_Mat_set<cv::Point2f>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetPoint2d(cv::Mat *obj, int row, int col, cv::Point2d *vals, int valsLength)
{
    return internal_Mat_set<cv::Point2d>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetPoint3i(cv::Mat *obj, int row, int col, cv::Point3i *vals, int valsLength)
{
    return internal_Mat_set<cv::Point3i>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetPoint3f(cv::Mat *obj, int row, int col, cv::Point3f *vals, int valsLength)
{
    return internal_Mat_set<cv::Point3f>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetPoint3d(cv::Mat *obj, int row, int col, cv::Point3d *vals, int valsLength)
{
    return internal_Mat_set<cv::Point3d>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nSetRect(cv::Mat *obj, int row, int col, cv::Rect *vals, int valsLength)
{
    return internal_Mat_set<cv::Rect>(obj, row, col, (char*)vals, valsLength);
}

CVAPI(int) core_Mat_nGetB(cv::Mat *obj, int row, int col, uchar *vals, int valsLength)
{
    return internal_Mat_get<char>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetS(cv::Mat *obj, int row, int col, short *vals, int valsLength)
{
    return internal_Mat_get<short>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetI(cv::Mat *obj, int row, int col, int *vals, int valsLength)
{
    return internal_Mat_get<int>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetF(cv::Mat *obj, int row, int col, float *vals, int valsLength)
{
    return internal_Mat_get<float>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetD(cv::Mat *obj, int row, int col, double *vals, int valsLength)
{
    return internal_Mat_get<double>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetVec3b(cv::Mat *obj, int row, int col, cv::Vec3b *vals, int valsLength)
{
    return internal_Mat_get<cv::Vec3b>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetVec3d(cv::Mat *obj, int row, int col, cv::Vec3d *vals, int valsLength)
{
    return internal_Mat_get<cv::Vec3d>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetVec4f(cv::Mat *obj, int row, int col, cv::Vec4f *vals, int valsLength)
{
    return internal_Mat_get<cv::Vec4f>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetVec6f(cv::Mat *obj, int row, int col, cv::Vec6f *vals, int valsLength)
{
    return internal_Mat_get<cv::Vec6f>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetVec4i(cv::Mat *obj, int row, int col, cv::Vec4i *vals, int valsLength)
{
    return internal_Mat_get<cv::Vec4i>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetPoint(cv::Mat *obj, int row, int col, cv::Point *vals, int valsLength)
{
    return internal_Mat_get<cv::Point>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetPoint2f(cv::Mat *obj, int row, int col, cv::Point2f *vals, int valsLength)
{
    return internal_Mat_get<cv::Point2f>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetPoint2d(cv::Mat *obj, int row, int col, cv::Point2d *vals, int valsLength)
{
    return internal_Mat_get<cv::Point2d>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetPoint3i(cv::Mat *obj, int row, int col, cv::Point3i *vals, int valsLength)
{
    return internal_Mat_get<cv::Point3i>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetPoint3f(cv::Mat *obj, int row, int col, cv::Point3f *vals, int valsLength)
{
    return internal_Mat_get<cv::Point3f>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetPoint3d(cv::Mat *obj, int row, int col, cv::Point3d *vals, int valsLength)
{
    return internal_Mat_get<cv::Point3d>(obj, row, col, (char*)vals, valsLength);
}
CVAPI(int) core_Mat_nGetRect(cv::Mat *obj, int row, int col, cv::Rect *vals, int valsLength)
{
    return internal_Mat_get<cv::Rect>(obj, row, col, (char*)vals, valsLength);
}

#pragma endregion

#pragma region push_back

CVAPI(void) core_Mat_push_back_Mat(cv::Mat *self, cv::Mat *m)
{
    self->push_back(*m);
}
CVAPI(void) core_Mat_push_back_char(cv::Mat *self, char v)
{
    self->push_back(v);
}
CVAPI(void) core_Mat_push_back_uchar(cv::Mat *self, uchar v)
{
    self->push_back(v);
}
CVAPI(void) core_Mat_push_back_short(cv::Mat *self, short v)
{
    self->push_back(v);
}
CVAPI(void) core_Mat_push_back_ushort(cv::Mat *self, ushort v)
{
    self->push_back(v);
}
CVAPI(void) core_Mat_push_back_int(cv::Mat *self, int v)
{
    self->push_back(v);
}
CVAPI(void) core_Mat_push_back_float(cv::Mat *self, float v)
{
    self->push_back(v);
}
CVAPI(void) core_Mat_push_back_double(cv::Mat *self, double v)
{
    self->push_back(v);
}

CVAPI(void) core_Mat_push_back_Vec2b(cv::Mat *self, CvVec2b v)
{
    self->push_back(cv::Vec2b(v.val));
}
CVAPI(void) core_Mat_push_back_Vec3b(cv::Mat *self, CvVec3b v)
{
    self->push_back(cv::Vec3b(v.val));
}
CVAPI(void) core_Mat_push_back_Vec4b(cv::Mat *self, CvVec4b v)
{
    self->push_back(cv::Vec4b(v.val));
}
CVAPI(void) core_Mat_push_back_Vec6b(cv::Mat *self, CvVec6b v)
{
    self->push_back(cv::Vec6b(v.val));
}
CVAPI(void) core_Mat_push_back_Vec2s(cv::Mat *self, CvVec2s v)
{
    self->push_back(cv::Vec2s(v.val));
}
CVAPI(void) core_Mat_push_back_Vec3s(cv::Mat *self, CvVec3s v)
{
    self->push_back(cv::Vec3s(v.val));
}
CVAPI(void) core_Mat_push_back_Vec4s(cv::Mat *self, CvVec4s v)
{
    self->push_back(cv::Vec4s(v.val));
}
CVAPI(void) core_Mat_push_back_Vec6s(cv::Mat *self, CvVec6s v)
{
    self->push_back(cv::Vec6s(v.val));
}
CVAPI(void) core_Mat_push_back_Vec2w(cv::Mat *self, CvVec2w v)
{
    self->push_back(cv::Vec2w(v.val));
}
CVAPI(void) core_Mat_push_back_Vec3w(cv::Mat *self, CvVec3w v)
{
    self->push_back(cv::Vec3w(v.val));
}
CVAPI(void) core_Mat_push_back_Vec4w(cv::Mat *self, CvVec4w v)
{
    self->push_back(cv::Vec4w(v.val));
}
CVAPI(void) core_Mat_push_back_Vec6w(cv::Mat *self, CvVec6w v)
{
    self->push_back(cv::Vec6w(v.val));
}
CVAPI(void) core_Mat_push_back_Vec2i(cv::Mat *self, CvVec2i v)
{
    self->push_back(cv::Vec2i(v.val));
}
CVAPI(void) core_Mat_push_back_Vec3i(cv::Mat *self, CvVec3i v)
{
    self->push_back(cv::Vec3i(v.val));
}
CVAPI(void) core_Mat_push_back_Vec4i(cv::Mat *self, CvVec4i v)
{
    self->push_back(cv::Vec4i(v.val));
}
CVAPI(void) core_Mat_push_back_Vec6i(cv::Mat *self, CvVec6i v)
{
    self->push_back(cv::Vec6i(v.val));
}
CVAPI(void) core_Mat_push_back_Vec2f(cv::Mat *self, CvVec2f v)
{
    self->push_back(cv::Vec2f(v.val));
}
CVAPI(void) core_Mat_push_back_Vec3f(cv::Mat *self, CvVec3f v)
{
    self->push_back(cv::Vec3f(v.val));
}
CVAPI(void) core_Mat_push_back_Vec4f(cv::Mat *self, CvVec4f v)
{
    self->push_back(cv::Vec4f(v.val));
}
CVAPI(void) core_Mat_push_back_Vec6f(cv::Mat *self, CvVec6f v)
{
    self->push_back(cv::Vec6f(v.val));
}
CVAPI(void) core_Mat_push_back_Vec2d(cv::Mat *self, CvVec2d v)
{
    self->push_back(cv::Vec2d(v.val));
}
CVAPI(void) core_Mat_push_back_Vec3d(cv::Mat *self, CvVec3d v)
{
    self->push_back(cv::Vec3d(v.val));
}
CVAPI(void) core_Mat_push_back_Vec4d(cv::Mat *self, CvVec4d v)
{
    self->push_back(cv::Vec4d(v.val));
}
CVAPI(void) core_Mat_push_back_Vec6d(cv::Mat *self, CvVec6d v)
{
    self->push_back(cv::Vec6d(v.val));
}

CVAPI(void) core_Mat_push_back_Point(cv::Mat *self, CvPoint v)
{
    self->push_back((cv::Point)v);
}
CVAPI(void) core_Mat_push_back_Point2f(cv::Mat *self, CvPoint2D32f v)
{
    self->push_back((cv::Point2f)v);
}
CVAPI(void) core_Mat_push_back_Point2d(cv::Mat *self, CvPoint2D64f v)
{
    self->push_back(cv::Point2d(v.x, v.y));
}
CVAPI(void) core_Mat_push_back_Point3i(cv::Mat *self, CvPoint3D v)
{
    self->push_back(cv::Point3i(v.x, v.y, v.z));
}
CVAPI(void) core_Mat_push_back_Point3f(cv::Mat *self, CvPoint3D32f v)
{
    self->push_back((cv::Point3f)v);
}
CVAPI(void) core_Mat_push_back_Point3d(cv::Mat *self, CvPoint3D64f v)
{
    self->push_back(cv::Point3d(v.x, v.y, v.z));
}
CVAPI(void) core_Mat_push_back_Size(cv::Mat *self, CvSize v)
{
    self->push_back((cv::Size)v);
}
CVAPI(void) core_Mat_push_back_Size2f(cv::Mat *self, CvSize2D32f v)
{
    self->push_back((cv::Size2f)v);
}
CVAPI(void) core_Mat_push_back_Rect(cv::Mat *self, CvRect v)
{
    self->push_back((cv::Rect)v);
}

#pragma endregion

#pragma region forEach
typedef void *(Mat_foreach_uchar)(uchar *value, const int *position);
typedef void *(Mat_foreach_Vec2b)(cv::Vec2b *value, const int *position);
typedef void *(Mat_foreach_Vec3b)(cv::Vec3b *value, const int *position);
typedef void *(Mat_foreach_Vec4b)(cv::Vec4b *value, const int *position);
typedef void *(Mat_foreach_Vec6b)(cv::Vec6b *value, const int *position);
typedef void *(Mat_foreach_short)(short *value, const int *position);
typedef void *(Mat_foreach_Vec2s)(cv::Vec2s *value, const int *position);
typedef void *(Mat_foreach_Vec3s)(cv::Vec3s *value, const int *position);
typedef void *(Mat_foreach_Vec4s)(cv::Vec4s *value, const int *position);
typedef void *(Mat_foreach_Vec6s)(cv::Vec6s *value, const int *position);
typedef void *(Mat_foreach_int)(int *value, const int *position);
typedef void *(Mat_foreach_Vec2i)(cv::Vec2i *value, const int *position);
typedef void *(Mat_foreach_Vec3i)(cv::Vec3i *value, const int *position);
typedef void *(Mat_foreach_Vec4i)(cv::Vec4i *value, const int *position);
typedef void *(Mat_foreach_Vec6i)(cv::Vec6i *value, const int *position);
typedef void *(Mat_foreach_float)(float *value, const int *position);
typedef void *(Mat_foreach_Vec2f)(cv::Vec2f *value, const int *position);
typedef void *(Mat_foreach_Vec3f)(cv::Vec3f *value, const int *position);
typedef void *(Mat_foreach_Vec4f)(cv::Vec4f *value, const int *position);
typedef void *(Mat_foreach_Vec6f)(cv::Vec6f *value, const int *position);
typedef void *(Mat_foreach_double)(double *value, const int *position);
typedef void *(Mat_foreach_Vec2d)(cv::Vec2d *value, const int *position);
typedef void *(Mat_foreach_Vec3d)(cv::Vec3d *value, const int *position);
typedef void *(Mat_foreach_Vec4d)(cv::Vec4d *value, const int *position);
typedef void *(Mat_foreach_Vec6d)(cv::Vec6d *value, const int *position);

template<typename TFunction, typename TElem>
struct Functor
{
    TFunction *proc;
    Functor(TFunction *_proc)
    {
        proc = _proc;
    }
    void operator()(TElem &value, const int *position) const
    {
        proc(&value, position);
    }
};

CVAPI(void) core_Mat_forEach_uchar(cv::Mat *m, Mat_foreach_uchar proc)
{
    Functor<Mat_foreach_uchar, uchar> functor(proc);
    m->forEach<uchar>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2b(cv::Mat *m, Mat_foreach_Vec2b proc)
{
    Functor<Mat_foreach_Vec2b, cv::Vec2b> functor(proc);
    m->forEach<cv::Vec2b>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3b(cv::Mat *m, Mat_foreach_Vec3b proc)
{
    Functor<Mat_foreach_Vec3b, cv::Vec3b> functor(proc);
    m->forEach<cv::Vec3b>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4b(cv::Mat *m, Mat_foreach_Vec4b proc)
{
    Functor<Mat_foreach_Vec4b, cv::Vec4b> functor(proc);
    m->forEach<cv::Vec4b>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6b(cv::Mat *m, Mat_foreach_Vec6b proc)
{
    Functor<Mat_foreach_Vec6b, cv::Vec6b> functor(proc);
    m->forEach<cv::Vec6b>(functor);
}

CVAPI(void) core_Mat_forEach_short(cv::Mat *m, Mat_foreach_short proc)
{
    Functor<Mat_foreach_short, short> functor(proc);
    m->forEach<short>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2s(cv::Mat *m, Mat_foreach_Vec2s proc)
{
    Functor<Mat_foreach_Vec2s, cv::Vec2s> functor(proc);
    m->forEach<cv::Vec2s>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3s(cv::Mat *m, Mat_foreach_Vec3s proc)
{
    Functor<Mat_foreach_Vec3s, cv::Vec3s> functor(proc);
    m->forEach<cv::Vec3s>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4s(cv::Mat *m, Mat_foreach_Vec4s proc)
{
    Functor<Mat_foreach_Vec4s, cv::Vec4s> functor(proc);
    m->forEach<cv::Vec4s>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6s(cv::Mat *m, Mat_foreach_Vec6s proc)
{
    Functor<Mat_foreach_Vec6s, cv::Vec6s> functor(proc);
    m->forEach<cv::Vec6s>(functor);
}

CVAPI(void) core_Mat_forEach_int(cv::Mat *m, Mat_foreach_int proc)
{
    Functor<Mat_foreach_int, int> functor(proc);
    m->forEach<int>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2i(cv::Mat *m, Mat_foreach_Vec2i proc)
{
    Functor<Mat_foreach_Vec2i, cv::Vec2i> functor(proc);
    m->forEach<cv::Vec2i>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3i(cv::Mat *m, Mat_foreach_Vec3i proc)
{
    Functor<Mat_foreach_Vec3i, cv::Vec3i> functor(proc);
    m->forEach<cv::Vec3i>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4i(cv::Mat *m, Mat_foreach_Vec4i proc)
{
    Functor<Mat_foreach_Vec4i, cv::Vec4i> functor(proc);
    m->forEach<cv::Vec4i>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6i(cv::Mat *m, Mat_foreach_Vec6i proc)
{
    Functor<Mat_foreach_Vec6i, cv::Vec6i> functor(proc);
    m->forEach<cv::Vec6i>(functor);
}

CVAPI(void) core_Mat_forEach_float(cv::Mat *m, Mat_foreach_float proc)
{
    Functor<Mat_foreach_float, float> functor(proc);
    m->forEach<float>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2f(cv::Mat *m, Mat_foreach_Vec2f proc)
{
    Functor<Mat_foreach_Vec2f, cv::Vec2f> functor(proc);
    m->forEach<cv::Vec2f>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3f(cv::Mat *m, Mat_foreach_Vec3f proc)
{
    Functor<Mat_foreach_Vec3f, cv::Vec3f> functor(proc);
    m->forEach<cv::Vec3f>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4f(cv::Mat *m, Mat_foreach_Vec4f proc)
{
    Functor<Mat_foreach_Vec4f, cv::Vec4f> functor(proc);
    m->forEach<cv::Vec4f>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6f(cv::Mat *m, Mat_foreach_Vec6f proc)
{
    Functor<Mat_foreach_Vec6f, cv::Vec6f> functor(proc);
    m->forEach<cv::Vec6f>(functor);
}


CVAPI(void) core_Mat_forEach_double(cv::Mat *m, Mat_foreach_double proc)
{
    Functor<Mat_foreach_double, double> functor(proc);
    m->forEach<double>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2d(cv::Mat *m, Mat_foreach_Vec2d proc)
{
    Functor<Mat_foreach_Vec2d, cv::Vec2d> functor(proc);
    m->forEach<cv::Vec2d>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3d(cv::Mat *m, Mat_foreach_Vec3d proc)
{
    Functor<Mat_foreach_Vec3d, cv::Vec3d> functor(proc);
    m->forEach<cv::Vec3d>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4d(cv::Mat *m, Mat_foreach_Vec4d proc)
{
    Functor<Mat_foreach_Vec4d, cv::Vec4d> functor(proc);
    m->forEach<cv::Vec4d>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6d(cv::Mat *m, Mat_foreach_Vec6d proc)
{
    Functor<Mat_foreach_Vec6d, cv::Vec6d> functor(proc);
    m->forEach<cv::Vec6d>(functor);
}
#pragma endregion

#endif