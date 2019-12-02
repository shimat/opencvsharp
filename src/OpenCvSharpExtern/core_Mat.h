#ifndef _CPP_CORE_MAT_H_
#define _CPP_CORE_MAT_H_

#include "include_opencv.h"

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#pragma region Init & Release
CVAPI(uint64) core_Mat_sizeof()
{
    return sizeof(cv::Mat);
}

CVAPI(ExceptionStatus) core_Mat_new1(cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat;
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new2(int rows, int cols, int type, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(rows, cols, type); 
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new3(int rows, int cols, int type, MyCvScalar scalar, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(rows, cols, type, cpp(scalar));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new4(cv::Mat *mat, MyCvSlice rowRange, MyCvSlice colRange, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(*mat, cpp(rowRange), cpp(colRange));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new5(cv::Mat *mat, cv::Range rowRange, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(*mat, rowRange);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new6(cv::Mat *mat, cv::Range *ranges, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(*mat, ranges);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new7(cv::Mat *mat, MyCvRect roi, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(*mat, cpp(roi));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new8(int rows, int cols, int type, void* data, size_t step, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(rows, cols, type, data, step);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new9(int ndims, const int* sizes, int type, void* data, const size_t* steps, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(ndims, sizes, type, data, steps);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new10(int ndims, int* sizes, int type, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(ndims, sizes, type);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new11(int ndims, int* sizes, int type, MyCvScalar s, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(ndims, sizes, type, cpp(s));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_new12(cv::Mat *mat, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(*mat);
    END_WRAP
}

/*CVAPI(ExceptionStatus) core_Mat_release(cv::Mat *self)
{
    BEGIN_WRAP
    self->release();
    END_WRAP
}*/
CVAPI(ExceptionStatus) core_Mat_delete(cv::Mat *self)
{
    BEGIN_WRAP
    delete self;
    END_WRAP
}

#pragma endregion

#pragma region Functions

CVAPI(ExceptionStatus) core_Mat_row(cv::Mat *self, int y, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(self->row(y));
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_col(cv::Mat *self, int x, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(self->col(x));
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_rowRange(cv::Mat *self, int startRow, int endRow, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(self->rowRange(startRow, endRow));
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_colRange(cv::Mat *self, int startCol, int endCol, cv::Mat **returnValue)
{ 
    BEGIN_WRAP
    *returnValue = new cv::Mat(self->colRange(startCol, endCol));
    END_WRAP
}
     
CVAPI(ExceptionStatus) core_Mat_diag(cv::Mat *self, int d, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->diag(d);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_diag_static(cv::Mat *self, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::Mat::diag(*self);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_clone(cv::Mat *self, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->clone();
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_copyTo1(cv::Mat *self, cv::_OutputArray *m)
{
    BEGIN_WRAP
    self->copyTo(*m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_copyTo2(cv::Mat *self, cv::_OutputArray *m, cv::_InputArray *mask)
{
    BEGIN_WRAP
    self->copyTo(*m, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_convertTo(cv::Mat *self, cv::_OutputArray *m, int rtype, double alpha, double beta)
{
    BEGIN_WRAP
    self->convertTo(*m, rtype, alpha, beta);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_assignTo(cv::Mat *self, cv::Mat *m, int type)
{
    BEGIN_WRAP
    self->assignTo(*m, type);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_setTo_Scalar(cv::Mat *self, MyCvScalar value, cv::Mat *mask)
{
    BEGIN_WRAP
    if (mask == nullptr)
        self->setTo(cpp(value));
    else 
        self->setTo(cpp(value), entity(mask));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_setTo_InputArray(cv::Mat *self, cv::_InputArray *value, cv::Mat *mask)
{
    BEGIN_WRAP
    self->setTo(*value, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_reshape1(cv::Mat *self, int cn, int rows, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->reshape(cn, rows);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_reshape2(cv::Mat *self, int cn, int newndims, const int* newsz, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->reshape(cn, newndims, newsz);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_t(cv::Mat *self, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = self->t();
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_inv(cv::Mat *self, int method, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->inv(method);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_mul(cv::Mat *self, cv::_InputArray *m, double scale, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->mul(*m, scale);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_cross(cv::Mat *self, cv::_InputArray *m, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = self->cross(*m);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_dot(cv::Mat *self, cv::_InputArray *m, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->dot(*m);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_zeros1(int rows, int cols, int type, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = cv::Mat::zeros(rows, cols, type);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_zeros2(int ndims, const int *sz, int type, cv::MatExpr **returnValue) 
{
    BEGIN_WRAP
    const auto expr = cv::Mat::zeros(ndims, sz, type);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_ones1(int rows, int cols, int type, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::Mat::ones(rows, cols, type);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_ones2(int ndims, const int *sz, int type, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    cv::MatExpr ret = cv::Mat::ones(ndims, sz, type);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_eye(int rows, int cols, int type, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto eye = cv::Mat::eye(rows, cols, type);
    *returnValue = new cv::MatExpr(eye);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_create1(cv::Mat *self, int rows, int cols, int type)
{
    BEGIN_WRAP
    self->create(rows, cols, type);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_create2(cv::Mat *self, int ndims, const int *sizes, int type)
{
    BEGIN_WRAP
    self->create(ndims, sizes, type);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_reserve(cv::Mat *self, size_t sz)
{
    BEGIN_WRAP
    self->reserve(sz);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_reserveBuffer(cv::Mat *self, size_t sz)
{
    BEGIN_WRAP
    self->reserveBuffer(sz);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_resize1(cv::Mat *obj, size_t sz)
{
    BEGIN_WRAP
    obj->resize(sz);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_resize2(cv::Mat *obj, size_t sz, MyCvScalar s)
{
    BEGIN_WRAP
    obj->resize(sz, cpp(s));
    END_WRAP
}



CVAPI(cv::Mat*) core_Mat_adjustROI(cv::Mat *self, int dtop, int dbottom, int dleft, int dright)
{
    const auto ret = self->adjustROI(dtop, dbottom, dleft, dright);
    return new cv::Mat(ret);
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


CVAPI(int) core_Mat_cols(cv::Mat *self)
{
    return self->cols;
}

CVAPI(int) core_Mat_dims(cv::Mat *self)
{
    return self->dims;
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




CVAPI(int) core_Mat_rows(cv::Mat *self)
{
    return self->rows;
}

CVAPI(MyCvSize) core_Mat_size(cv::Mat *self)
{
    return c(self->size());
}
CVAPI(int) core_Mat_sizeAt(cv::Mat *self, int i)
{
    const auto size = self->size[i];
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
    const cv::Range rowRange(rowStart, rowEnd);
    const cv::Range colRange(colStart, colEnd);
    const auto ret = (*self)(rowRange, colRange);
    return new cv::Mat(ret);
}
CVAPI(cv::Mat*) core_Mat_subMat2(cv::Mat *self, int nRanges, MyCvSlice *ranges)
{
    std::vector<cv::Range> rangesVec(nRanges);
    for (auto i = 0; i < nRanges; i++)
    {
        rangesVec[i] = (cpp(ranges[i]));
    }
    const auto ret = (*self)(&rangesVec[0]);
    return new cv::Mat(ret);
}

CVAPI(uint64) core_Mat_total(cv::Mat *self)
{
    return self->total();
}

CVAPI(int) core_Mat_type(cv::Mat *self)
{
    return self->type();
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

CVAPI(void) core_Mat_pop_back(cv::Mat *obj, size_t nelems)
{
    obj->pop_back(nelems);
}
      
CVAPI(cv::MatExpr*) core_abs_Mat(cv::Mat *m)
{
    const auto ret = cv::abs(*m);
    return new cv::MatExpr(ret);
}

#pragma endregion

#pragma region Operators

CVAPI(void) core_Mat_assignment_FromMat(cv::Mat *self, cv::Mat *newMat)
{
    *self = *newMat;
}
CVAPI(void) core_Mat_assignment_FromScalar(cv::Mat *self, MyCvScalar scalar)
{
    *self = cpp(scalar);
}

CVAPI(cv::MatExpr*) core_Mat_operatorUnaryMinus(cv::Mat *mat)
{
    const auto expr = -(*mat);
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorAdd_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) + (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorAdd_MatScalar(cv::Mat *a, MyCvScalar s)
{
    const auto expr = (*a) + cpp(s);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorAdd_ScalarMat(MyCvScalar s, cv::Mat *a)
{
    const auto expr = cpp(s) + (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorMinus_Mat(cv::Mat *a)
{
    const auto expr = -(*a);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorSubtract_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) - (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorSubtract_MatScalar(cv::Mat *a, MyCvScalar s)
{
    const auto expr = (*a) - cpp(s);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorSubtract_ScalarMat(MyCvScalar s, cv::Mat *a)
{
    const auto expr = cpp(s) - (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorMultiply_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) * (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorMultiply_MatDouble(cv::Mat *a, double s)
{
    const auto expr = (*a) * s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorMultiply_DoubleMat(double s, cv::Mat *a)
{
    const auto expr = s * (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorDivide_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) / (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorDivide_MatDouble(cv::Mat *a, double s)
{
    const auto expr = (*a) / s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorDivide_DoubleMat(double s, cv::Mat *a)
{
    const auto expr = s / (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorAnd_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) & (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorAnd_MatDouble(cv::Mat *a, double s)
{
    const auto expr = (*a) & s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorAnd_DoubleMat(double s, cv::Mat *a)
{
    const auto expr = s & (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorOr_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) | (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorOr_MatDouble(cv::Mat *a, double s)
{
    const auto expr = (*a) | s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorOr_DoubleMat(double s, cv::Mat *a)
{
    const auto expr = s | (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorXor_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) ^ (*b);
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorXor_MatDouble(cv::Mat *a, double s)
{
    const auto expr = (*a) ^ s;
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorXor_DoubleMat(double s, cv::Mat *a)
{
    const auto expr = s ^ (*a); 
    return new cv::MatExpr(expr);
}

CVAPI(cv::MatExpr*) core_Mat_operatorNot(cv::Mat *a)
{
    const auto expr = ~(*a);
    return new cv::MatExpr(expr);
}


// Comparison Operators

// <
CVAPI(cv::MatExpr*) core_Mat_operatorLT_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) < (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorLT_DoubleMat(double a, cv::Mat *b)
{
    const auto expr = a < (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorLT_MatDouble(cv::Mat *a, double b)
{
    const auto expr = (*a) < b; 
    return new cv::MatExpr(expr);
}
// <=
CVAPI(cv::MatExpr*) core_Mat_operatorLE_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) <= (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorLE_DoubleMat(double a, cv::Mat *b)
{
    const auto expr = a <= (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorLE_MatDouble(cv::Mat *a, double b)
{
    const auto expr = (*a) <= b; 
    return new cv::MatExpr(expr);
}
// >
CVAPI(cv::MatExpr*) core_Mat_operatorGT_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) > (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorGT_DoubleMat(double a, cv::Mat *b)
{
    const auto expr = a > (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorGT_MatDouble(cv::Mat *a, double b)
{
    const auto expr = (*a) > b; 
    return new cv::MatExpr(expr);
}
// >=
CVAPI(cv::MatExpr*) core_Mat_operatorGE_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) >= (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorGE_DoubleMat(double a, cv::Mat *b)
{
    const auto expr = a >= (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorGE_MatDouble(cv::Mat *a, double b)
{
    const auto expr = (*a) >= b; 
    return new cv::MatExpr(expr);
}
// ==
CVAPI(cv::MatExpr*) core_Mat_operatorEQ_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) == (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorEQ_DoubleMat(double a, cv::Mat *b)
{
    const auto expr = a == (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorEQ_MatDouble(cv::Mat *a, double b)
{
    const auto expr = (*a) == b; 
    return new cv::MatExpr(expr);
}
// !=
CVAPI(cv::MatExpr*) core_Mat_operatorNE_MatMat(cv::Mat *a, cv::Mat *b)
{
    const auto expr = (*a) != (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorNE_DoubleMat(double a, cv::Mat *b)
{
    const auto expr = a != (*b); 
    return new cv::MatExpr(expr);
}
CVAPI(cv::MatExpr*) core_Mat_operatorNE_MatDouble(cv::Mat *a, double b)
{
    const auto expr = (*a) != b; 
    return new cv::MatExpr(expr);
}

#pragma endregion


#pragma region nSet/nGet

static bool internal_Mat_set(cv::Mat *m, uchar *buff)
{
    if (!m) return false;
    if (!buff) return false;
    if (m->dims != 2) return false;

    const size_t bytesToCopy = static_cast<size_t>(m->rows) * m->cols * m->elemSize();

    if (m->isContinuous())
    {
        memcpy(m->ptr(0, 0), buff, bytesToCopy);
    }
    else 
    {
        // row by row
        const size_t bytesInRow = m->cols * m->elemSize();     
        for (int row = 0; row < m->rows; row++)
        {
            uchar *matData = m->ptr(row, 0);
            memcpy(matData, buff, bytesInRow);
            buff += bytesInRow;
        }
    }

    return true;
}

static bool internal_Mat_get(cv::Mat *m, uchar *buff)
{
    if (!m) return false;
    if (!buff) return false;
    if (m->dims != 2) return false;

    const size_t bytesToCopy = static_cast<size_t>(m->rows) * m->cols * m->elemSize();

    if (m->isContinuous())
    {
        memcpy(buff, m->ptr(0, 0), bytesToCopy);
    }
    else 
    {
        // row by row
        const size_t bytesInRow = m->cols * m->elemSize();
        for (int row = 0; row < m->rows; row++)
        {
            const uchar *matData = m->ptr(row, 0);
            memcpy(buff, matData, bytesInRow);
            buff += bytesInRow;
        }
    }

    return true;
}

// unlike other nPut()-s this one (with double[]) should convert input values to correct type
template<typename T>
static void internal_set_item(cv::Mat *mat, int r, int c, double *src, int &count)
{
    T *dst = reinterpret_cast<T*>(mat->ptr(r, c));
    for (auto ch = 0; ch < mat->channels() && count > 0; count--, ch++, src++, dst++)
        *dst = cv::saturate_cast<T>(*src);
}

CVAPI(ExceptionStatus) core_Mat_setMatData(cv::Mat *obj, uchar *vals, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = internal_Mat_set(obj, vals) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_getMatData(cv::Mat *obj, uchar *vals, int *returnValue)
{    
    BEGIN_WRAP
    *returnValue = internal_Mat_get(obj, vals) ? 1 : 0;
    END_WRAP
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
    const Functor<Mat_foreach_uchar, uchar> functor(proc);
    m->forEach<uchar>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2b(cv::Mat *m, Mat_foreach_Vec2b proc)
{
    const Functor<Mat_foreach_Vec2b, cv::Vec2b> functor(proc);
    m->forEach<cv::Vec2b>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3b(cv::Mat *m, Mat_foreach_Vec3b proc)
{
    const Functor<Mat_foreach_Vec3b, cv::Vec3b> functor(proc);
    m->forEach<cv::Vec3b>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4b(cv::Mat *m, Mat_foreach_Vec4b proc)
{
    const Functor<Mat_foreach_Vec4b, cv::Vec4b> functor(proc);
    m->forEach<cv::Vec4b>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6b(cv::Mat *m, Mat_foreach_Vec6b proc)
{
    const Functor<Mat_foreach_Vec6b, cv::Vec6b> functor(proc);
    m->forEach<cv::Vec6b>(functor);
}

CVAPI(void) core_Mat_forEach_short(cv::Mat *m, Mat_foreach_short proc)
{
    const Functor<Mat_foreach_short, short> functor(proc);
    m->forEach<short>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2s(cv::Mat *m, Mat_foreach_Vec2s proc)
{
    const Functor<Mat_foreach_Vec2s, cv::Vec2s> functor(proc);
    m->forEach<cv::Vec2s>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3s(cv::Mat *m, Mat_foreach_Vec3s proc)
{
    const Functor<Mat_foreach_Vec3s, cv::Vec3s> functor(proc);
    m->forEach<cv::Vec3s>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4s(cv::Mat *m, Mat_foreach_Vec4s proc)
{
    const Functor<Mat_foreach_Vec4s, cv::Vec4s> functor(proc);
    m->forEach<cv::Vec4s>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6s(cv::Mat *m, Mat_foreach_Vec6s proc)
{
    const Functor<Mat_foreach_Vec6s, cv::Vec6s> functor(proc);
    m->forEach<cv::Vec6s>(functor);
}

CVAPI(void) core_Mat_forEach_int(cv::Mat *m, Mat_foreach_int proc)
{
    const Functor<Mat_foreach_int, int> functor(proc);
    m->forEach<int>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2i(cv::Mat *m, Mat_foreach_Vec2i proc)
{
    const Functor<Mat_foreach_Vec2i, cv::Vec2i> functor(proc);
    m->forEach<cv::Vec2i>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3i(cv::Mat *m, Mat_foreach_Vec3i proc)
{
    const Functor<Mat_foreach_Vec3i, cv::Vec3i> functor(proc);
    m->forEach<cv::Vec3i>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4i(cv::Mat *m, Mat_foreach_Vec4i proc)
{
    const Functor<Mat_foreach_Vec4i, cv::Vec4i> functor(proc);
    m->forEach<cv::Vec4i>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6i(cv::Mat *m, Mat_foreach_Vec6i proc)
{
    const Functor<Mat_foreach_Vec6i, cv::Vec6i> functor(proc);
    m->forEach<cv::Vec6i>(functor);
}

CVAPI(void) core_Mat_forEach_float(cv::Mat *m, Mat_foreach_float proc)
{
    const Functor<Mat_foreach_float, float> functor(proc);
    m->forEach<float>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2f(cv::Mat *m, Mat_foreach_Vec2f proc)
{
    const Functor<Mat_foreach_Vec2f, cv::Vec2f> functor(proc);
    m->forEach<cv::Vec2f>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3f(cv::Mat *m, Mat_foreach_Vec3f proc)
{
    const Functor<Mat_foreach_Vec3f, cv::Vec3f> functor(proc);
    m->forEach<cv::Vec3f>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4f(cv::Mat *m, Mat_foreach_Vec4f proc)
{
    const Functor<Mat_foreach_Vec4f, cv::Vec4f> functor(proc);
    m->forEach<cv::Vec4f>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6f(cv::Mat *m, Mat_foreach_Vec6f proc)
{
    const Functor<Mat_foreach_Vec6f, cv::Vec6f> functor(proc);
    m->forEach<cv::Vec6f>(functor);
}


CVAPI(void) core_Mat_forEach_double(cv::Mat *m, Mat_foreach_double proc)
{
    const Functor<Mat_foreach_double, double> functor(proc);
    m->forEach<double>(functor);
}
CVAPI(void) core_Mat_forEach_Vec2d(cv::Mat *m, Mat_foreach_Vec2d proc)
{
    const Functor<Mat_foreach_Vec2d, cv::Vec2d> functor(proc);
    m->forEach<cv::Vec2d>(functor);
}
CVAPI(void) core_Mat_forEach_Vec3d(cv::Mat *m, Mat_foreach_Vec3d proc)
{
    const Functor<Mat_foreach_Vec3d, cv::Vec3d> functor(proc);
    m->forEach<cv::Vec3d>(functor);
}
CVAPI(void) core_Mat_forEach_Vec4d(cv::Mat *m, Mat_foreach_Vec4d proc)
{
    const Functor<Mat_foreach_Vec4d, cv::Vec4d> functor(proc);
    m->forEach<cv::Vec4d>(functor);
}
CVAPI(void) core_Mat_forEach_Vec6d(cv::Mat *m, Mat_foreach_Vec6d proc)
{
    const Functor<Mat_foreach_Vec6d, cv::Vec6d> functor(proc);
    m->forEach<cv::Vec6d>(functor);
}
#pragma endregion

#endif