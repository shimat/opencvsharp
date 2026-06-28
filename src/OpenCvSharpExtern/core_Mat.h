#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#pragma region Init & Release
CVAPI(uint64) core_Mat_sizeof()
{
    return sizeof(cv::Mat);
}

CVAPI(ExceptionStatus) core_Mat_new1(cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat;
    });
}
CVAPI(ExceptionStatus) core_Mat_new2(int rows, int cols, int type, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(rows, cols, type); 
    });
}
CVAPI(ExceptionStatus) core_Mat_new3(int rows, int cols, int type, interop::Scalar scalar, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(rows, cols, type, cpp(scalar));
    });
}
CVAPI(ExceptionStatus) core_Mat_new4(cv::Mat *mat, interop::Range rowRange, interop::Range colRange, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(*mat, cpp(rowRange), cpp(colRange));
    });
}
CVAPI(ExceptionStatus) core_Mat_new5(cv::Mat *mat, cv::Range rowRange, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(*mat, rowRange);
    });
}
CVAPI(ExceptionStatus) core_Mat_new6(cv::Mat *mat, cv::Range *ranges, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(*mat, ranges);
    });
}
CVAPI(ExceptionStatus) core_Mat_new7(cv::Mat *mat, interop::Rect roi, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(*mat, cpp(roi));
    });
}
CVAPI(ExceptionStatus) core_Mat_new8(int rows, int cols, int type, void* data, size_t step, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(rows, cols, type, data, step);
    });
}
CVAPI(ExceptionStatus) core_Mat_new9(int ndims, const int* sizes, int type, void* data, const size_t* steps, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(ndims, sizes, type, data, steps);
    });
}
CVAPI(ExceptionStatus) core_Mat_new10(int ndims, int* sizes, int type, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(ndims, sizes, type);
    });
}
CVAPI(ExceptionStatus) core_Mat_new11(int ndims, int* sizes, int type, interop::Scalar s, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(ndims, sizes, type, cpp(s));
    });
}
CVAPI(ExceptionStatus) core_Mat_new12(cv::Mat *mat, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(*mat);
    });
}

/*CVAPI(ExceptionStatus) core_Mat_release(cv::Mat *self)
{
    return cvTry([&] {
    self->release();
    });
}*/
CVAPI(ExceptionStatus) core_Mat_delete(cv::Mat *self)
{
    return cvTry([&] {
    delete self;
    });
}

#pragma endregion

#pragma region Functions

CVAPI(ExceptionStatus) core_Mat_getUMat(cv::Mat* self, cv::AccessFlag accessFlags, cv::UMatUsageFlags usageFlags, cv::UMat** returnValue)
{
    return cvTry([&] {
        * returnValue = new cv::UMat(self->getUMat(accessFlags, usageFlags));
    });
}

CVAPI(ExceptionStatus) core_Mat_row(cv::Mat *self, int y, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(self->row(y));
    });
}

CVAPI(ExceptionStatus) core_Mat_col(cv::Mat *self, int x, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(self->col(x));
    });
}

CVAPI(ExceptionStatus) core_Mat_rowRange(cv::Mat *self, int startRow, int endRow, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(self->rowRange(startRow, endRow));
    });
}

CVAPI(ExceptionStatus) core_Mat_colRange(cv::Mat *self, int startCol, int endCol, cv::Mat **returnValue)
{ 
    return cvTry([&] {
    *returnValue = new cv::Mat(self->colRange(startCol, endCol));
    });
}
     
CVAPI(ExceptionStatus) core_Mat_diag(cv::Mat *self, int d, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = self->diag(d);
    *returnValue = new cv::Mat(ret);
    });
}
CVAPI(ExceptionStatus) core_Mat_diag_static(cv::Mat *self, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = cv::Mat::diag(*self);
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) core_Mat_clone(cv::Mat *self, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = self->clone();
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) core_Mat_copyTo1(cv::Mat *self, cv::_OutputArray *m)
{
    return cvTry([&] {
    self->copyTo(*m);
    });
}
CVAPI(ExceptionStatus) core_Mat_copyTo2(cv::Mat *self, cv::_OutputArray *m, cv::_InputArray *mask)
{
    return cvTry([&] {
    self->copyTo(*m, entity(mask));
    });
}

CVAPI(ExceptionStatus) core_Mat_copyTo_toMat1(cv::Mat *self, cv::Mat *m)
{
    return cvTry([&] {
    self->copyTo(*m);
    });
}
CVAPI(ExceptionStatus) core_Mat_copyTo_toMat2(cv::Mat *self, cv::Mat *m, cv::_InputArray *mask)
{
    return cvTry([&] {
    self->copyTo(*m, entity(mask));
    });
}

CVAPI(ExceptionStatus) core_Mat_convertTo(cv::Mat *self, cv::_OutputArray *m, int rtype, double alpha, double beta)
{
    return cvTry([&] {
    self->convertTo(*m, rtype, alpha, beta);
    });
}

CVAPI(ExceptionStatus) core_Mat_assignTo(cv::Mat *self, cv::Mat *m, int type)
{
    return cvTry([&] {
    self->assignTo(*m, type);
    });
}

CVAPI(ExceptionStatus) core_Mat_setTo_Scalar(cv::Mat *self, interop::Scalar value, cv::Mat *mask)
{
    return cvTry([&] {
    if (mask == nullptr)
        self->setTo(cpp(value));
    else 
        self->setTo(cpp(value), entity(mask));
    });
}
CVAPI(ExceptionStatus) core_Mat_setTo_InputArray(cv::Mat *self, cv::_InputArray *value, cv::Mat *mask)
{
    return cvTry([&] {
    self->setTo(*value, entity(mask));
    });
}

CVAPI(ExceptionStatus) core_Mat_reshape1(cv::Mat *self, int cn, int rows, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = self->reshape(cn, rows);
    *returnValue = new cv::Mat(ret);
    });
}
CVAPI(ExceptionStatus) core_Mat_reshape2(cv::Mat *self, int cn, int newndims, const int* newsz, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = self->reshape(cn, newndims, newsz);
    *returnValue = new cv::Mat(ret);
    });
}

// MatShape (OpenCV 5). The shape is marshaled as (ndims, sizes, layout, C):
//   ndims == -1 : empty shape, ndims == 0 : 0-D scalar, ndims > 0 : N-D shape.
static cv::MatShape buildMatShape(int ndims, const int* sizes, int layout, int C)
{
    if (ndims < 0)
        return {};
    if (ndims == 0)
        return cv::MatShape::scalar();
    return cv::MatShape(static_cast<size_t>(ndims), sizes, static_cast<cv::DataLayout>(layout), C);
}

CVAPI(ExceptionStatus) core_Mat_shape(cv::Mat *self, int *sizes, int *outNdims, int *outLayout, int *outC, int *outEmpty)
{
    return cvTry([&] {
    const cv::MatShape shape = self->shape();
    *outEmpty = shape.empty() ? 1 : 0;
    *outLayout = static_cast<int>(shape.layout);
    *outC = shape.C;
    if (shape.empty())
    {
        *outNdims = -1;
    }
    else
    {
        *outNdims = shape.dims;
        for (int i = 0; i < shape.dims && i < cv::MatShape::MAX_DIMS; i++)
            sizes[i] = shape[i];
    }
    });
}

CVAPI(ExceptionStatus) core_Mat_newFromMatShape(int ndims, const int *sizes, int layout, int C, int type, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(buildMatShape(ndims, sizes, layout, C), type);
    });
}

CVAPI(ExceptionStatus) core_Mat_newFromMatShapeScalar(int ndims, const int *sizes, int layout, int C, int type, interop::Scalar s, cv::Mat **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(buildMatShape(ndims, sizes, layout, C), type, cpp(s));
    });
}

CVAPI(ExceptionStatus) core_Mat_reshapeMatShape(cv::Mat *self, int cn, int ndims, const int *sizes, int layout, int C, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = self->reshape(cn, buildMatShape(ndims, sizes, layout, C));
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) core_Mat_zeros_MatShape(int ndims, const int *sizes, int layout, int C, int type, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = cv::Mat::zeros(buildMatShape(ndims, sizes, layout, C), type);
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_ones_MatShape(int ndims, const int *sizes, int layout, int C, int type, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = cv::Mat::ones(buildMatShape(ndims, sizes, layout, C), type);
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_t(cv::Mat *self, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = self->t();
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_inv(cv::Mat *self, int method, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto ret = self->inv(method);
    *returnValue = new cv::MatExpr(ret);
    });
}

CVAPI(ExceptionStatus) core_Mat_mul(cv::Mat *self, cv::_InputArray *m, double scale, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto ret = self->mul(*m, scale);
    *returnValue = new cv::MatExpr(ret);
    });
}

CVAPI(ExceptionStatus) core_Mat_cross(cv::Mat *self, cv::_InputArray *m, cv::Mat **returnValue)
{
    return cvTry([&] {
    const auto ret = self->cross(*m);
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) core_Mat_dot(cv::Mat *self, cv::_InputArray *m, double *returnValue)
{
    return cvTry([&] {
    *returnValue = self->dot(*m);
    });
}

CVAPI(ExceptionStatus) core_Mat_zeros1(int rows, int cols, int type, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = cv::Mat::zeros(rows, cols, type);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_zeros2(int ndims, const int *sz, int type, cv::MatExpr **returnValue) 
{
    return cvTry([&] {
    const auto expr = cv::Mat::zeros(ndims, sz, type);
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_ones1(int rows, int cols, int type, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto ret = cv::Mat::ones(rows, cols, type);
    *returnValue = new cv::MatExpr(ret);
    });
}
CVAPI(ExceptionStatus) core_Mat_ones2(int ndims, const int *sz, int type, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    auto ret = cv::Mat::ones(ndims, sz, type);
    *returnValue = new cv::MatExpr(ret);
    });
}

CVAPI(ExceptionStatus) core_Mat_eye(int rows, int cols, int type, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto eye = cv::Mat::eye(rows, cols, type);
    *returnValue = new cv::MatExpr(eye);
    });
}

CVAPI(ExceptionStatus) core_Mat_create1(cv::Mat *self, int rows, int cols, int type)
{
    return cvTry([&] {
    self->create(rows, cols, type);
    });
}
CVAPI(ExceptionStatus) core_Mat_create2(cv::Mat *self, int ndims, const int *sizes, int type)
{
    return cvTry([&] {
    self->create(ndims, sizes, type);
    });
}

CVAPI(ExceptionStatus) core_Mat_reserve(cv::Mat *self, size_t sz)
{
    return cvTry([&] {
    self->reserve(sz);
    });
}

CVAPI(ExceptionStatus) core_Mat_reserveBuffer(cv::Mat *self, size_t sz)
{
    return cvTry([&] {
    self->reserveBuffer(sz);
    });
}

CVAPI(ExceptionStatus) core_Mat_resize1(cv::Mat *obj, size_t sz)
{
    return cvTry([&] {
    obj->resize(sz);
    });
}
CVAPI(ExceptionStatus) core_Mat_resize2(cv::Mat *obj, size_t sz, interop::Scalar s)
{
    return cvTry([&] {
    obj->resize(sz, cpp(s));
    });
}

CVAPI(ExceptionStatus) core_Mat_pop_back(cv::Mat *obj, size_t nelems)
{
    return cvTry([&] {
    obj->pop_back(nelems);
    });
}

CVAPI(ExceptionStatus) core_Mat_locateROI(cv::Mat *self, interop::Size *wholeSize, interop::Point *ofs)
{
    return cvTry([&] {
    cv::Size wholeSize2;
    cv::Point ofs2;
    self->locateROI(wholeSize2, ofs2);
    *wholeSize = c(cv::Size(wholeSize2.width, wholeSize2.height));
    *ofs = c(cv::Point(ofs2.x, ofs2.y));
    });
}

CVAPI(ExceptionStatus) core_Mat_adjustROI(cv::Mat *self, int dtop, int dbottom, int dleft, int dright, cv::Mat** returnValue)
{
    return cvTry([&] {
    const auto ret = self->adjustROI(dtop, dbottom, dleft, dright);
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) core_Mat_subMat1(cv::Mat *self, int rowStart, int rowEnd, int colStart, int colEnd, cv::Mat** returnValue)
{
    return cvTry([&] {
    const cv::Range rowRange(rowStart, rowEnd);
    const cv::Range colRange(colStart, colEnd);
    const auto ret = (*self)(rowRange, colRange);
    *returnValue = new cv::Mat(ret);
    });
}
CVAPI(ExceptionStatus) core_Mat_subMat2(cv::Mat *self, int nRanges, interop::Range *ranges, cv::Mat** returnValue)
{
    return cvTry([&] {
    std::vector<cv::Range> rangesVec(nRanges);
    for (auto i = 0; i < nRanges; i++)
    {
        rangesVec[i] = (cpp(ranges[i]));
    }
    const auto ret = (*self)(&rangesVec[0]);
    *returnValue = new cv::Mat(ret);
    });
}

CVAPI(ExceptionStatus) core_Mat_isContinuous(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->isContinuous() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_Mat_isSubmatrix(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->isSubmatrix() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_Mat_elemSize(cv::Mat *self, size_t *returnValue)
{
    return cvTry([&] {
    *returnValue = self->elemSize();
    });
}
CVAPI(ExceptionStatus) core_Mat_elemSize1(cv::Mat *self, size_t *returnValue)
{
    return cvTry([&] {
    *returnValue = self->elemSize1();
    });
}

CVAPI(ExceptionStatus) core_Mat_type(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->type();
    });
}

CVAPI(ExceptionStatus) core_Mat_depth(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->depth();
    });
}

CVAPI(ExceptionStatus) core_Mat_channels(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->channels();
    });
}

CVAPI(ExceptionStatus) core_Mat_step1(cv::Mat *self, int i, size_t *returnValue)
{
    return cvTry([&] {
    *returnValue = self->step1(i);
    });
}

CVAPI(ExceptionStatus) core_Mat_empty(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->empty() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_Mat_total1(cv::Mat *self, size_t *returnValue)
{
    return cvTry([&] {
    *returnValue = self->total();
    });
}

CVAPI(ExceptionStatus) core_Mat_total2(cv::Mat *self, int startDim, int endDim, size_t *returnValue)
{
    return cvTry([&] {
    *returnValue = self->total(startDim, endDim);
    });
}

CVAPI(ExceptionStatus) core_Mat_checkVector(cv::Mat *self, int elemChannels, int depth, int requireContinuous, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->checkVector(elemChannels, depth, requireContinuous != 0);
    });
}

CVAPI(ExceptionStatus) core_Mat_ptr1d(cv::Mat *self, int i0, uchar **returnValue)
{
    return cvTry([&] {
    *returnValue = self->ptr(i0);
    });
}
CVAPI(ExceptionStatus) core_Mat_ptr2d(cv::Mat *self, int i0, int i1, uchar **returnValue)
{
    return cvTry([&] {
    *returnValue = self->ptr(i0, i1);
    });
}
CVAPI(ExceptionStatus) core_Mat_ptr3d(cv::Mat *self, int i0, int i1, int i2, uchar **returnValue)
{
    return cvTry([&] {
    *returnValue = self->ptr(i0, i1, i2);
    });
}
CVAPI(ExceptionStatus) core_Mat_ptrnd(cv::Mat *self, int *idx, uchar **returnValue)
{
    return cvTry([&] {
    *returnValue = self->ptr(idx);
    });
}

CVAPI(ExceptionStatus) core_Mat_flags(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->flags;
    });
}

CVAPI(ExceptionStatus) core_Mat_dims(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->dims;
    });
}

CVAPI(ExceptionStatus) core_Mat_rows(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->rows;
    });
}
CVAPI(ExceptionStatus) core_Mat_cols(cv::Mat *self, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->cols;
    });
}

CVAPI(ExceptionStatus) core_Mat_data(cv::Mat *self, uchar **returnValue)
{
    return cvTry([&] {
    *returnValue = self->data;
    });
}
CVAPI(ExceptionStatus) core_Mat_datastart(cv::Mat *self, const uchar **returnValue)
{
    return cvTry([&] {
    *returnValue = self->datastart;
    });
}
CVAPI(ExceptionStatus) core_Mat_dataend(cv::Mat *self, const uchar **returnValue)
{
    return cvTry([&] {
    *returnValue = self->dataend;
    });
}
CVAPI(ExceptionStatus) core_Mat_datalimit(cv::Mat *self, const uchar **returnValue)
{
    return cvTry([&] {
    *returnValue = self->datalimit;
    });
}

CVAPI(ExceptionStatus) core_Mat_size(cv::Mat *self, interop::Size *returnValue)
{
    return cvTry([&] {
    // OpenCV 5's MatSize::operator()() asserts dims <= 2, but OpenCvSharp historically
    // returns Size(size[1], size[0]) for multi-dimensional matrices (OpenCV 4 behavior).
    if (self->dims > 2)
        *returnValue = c(cv::Size(self->size[1], self->size[0]));
    else
        *returnValue = c(self->size());
    });
}
CVAPI(ExceptionStatus) core_Mat_sizeAt(cv::Mat *self, int i, int *returnValue)
{
    return cvTry([&] {
    *returnValue = self->size[i];
    });
}

CVAPI(ExceptionStatus) core_Mat_step(cv::Mat *self, size_t *returnValue)
{
    return cvTry([&] {
    *returnValue = self->step;
    });
}
CVAPI(ExceptionStatus) core_Mat_stepAt(cv::Mat *self, int i, size_t *returnValue)
{
    return cvTry([&] {
    *returnValue = self->step[i];
    });
}
      
CVAPI(ExceptionStatus) core_abs_Mat(cv::Mat *m, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto ret = cv::abs(*m);
    *returnValue = new cv::MatExpr(ret);
    });
}

/*CVAPI(ExceptionStatus) core_Mat_assignment_FromMat(cv::Mat *self, cv::Mat *newMat)
{
    return cvTry([&] {
    *self = *newMat;
    });
}*/
/*CVAPI(ExceptionStatus) core_Mat_assignment_FromScalar(cv::Mat *self, interop::Scalar scalar)
{
    return cvTry([&] {
    *self = cpp(scalar);
    });
}*/

#pragma endregion

#pragma region getMatData/setMatData

static bool internal_Mat_set(cv::Mat *m, uchar *buff)
{
    if (!m) return false;
    if (!buff) return false;
    // OpenCV 5 returns 1-dimensional matrices (dims==1, rows==1) where OpenCV 4 produced
    // Nx1 (2D) ones. The managed side sizes its buffer from rows*cols, which only matches
    // total() for dims 1 and 2, so we deliberately do not handle dims > 2 here.
    if (m->dims != 1 && m->dims != 2) return false;

    if (m->isContinuous())
    {
        memcpy(m->data, buff, m->total() * m->elemSize());
    }
    else
    {
        // row by row (2-dimensional, non-continuous)
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
    // See internal_Mat_set: handle 1- and 2-dimensional matrices only.
    if (m->dims != 1 && m->dims != 2) return false;

    if (m->isContinuous())
    {
        memcpy(buff, m->data, m->total() * m->elemSize());
    }
    else
    {
        // row by row (2-dimensional, non-continuous)
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
    return cvTry([&] {
    *returnValue = internal_Mat_set(obj, vals) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_Mat_getMatData(cv::Mat *obj, uchar *vals, int *returnValue)
{    
    return cvTry([&] {
    *returnValue = internal_Mat_get(obj, vals) ? 1 : 0;
    });
}

#pragma endregion

#pragma region push_back

CVAPI(ExceptionStatus) core_Mat_push_back_Mat(cv::Mat *self, cv::Mat *m)
{
    return cvTry([&] {
    self->push_back(*m);
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_char(cv::Mat *self, char v)
{
    return cvTry([&] {
    self->push_back(v);
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_uchar(cv::Mat *self, uchar v)
{
    return cvTry([&] {
    self->push_back(v);
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_short(cv::Mat *self, short v)
{
    return cvTry([&] {
    self->push_back(v);
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_ushort(cv::Mat *self, ushort v)
{
    return cvTry([&] {
    self->push_back(v);
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_int(cv::Mat *self, int v)
{
    return cvTry([&] {
    self->push_back(v);
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_float(cv::Mat *self, float v)
{
    return cvTry([&] {
    self->push_back(v);
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_double(cv::Mat *self, double v)
{
    return cvTry([&] {
    self->push_back(v);
    });
}

CVAPI(ExceptionStatus) core_Mat_push_back_Vec2b(cv::Mat *self, interop::Vec2b v)
{
    return cvTry([&] {
    self->push_back(cv::Vec2b(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3b(cv::Mat *self, interop::Vec3b v)
{
    return cvTry([&] {
    self->push_back(cv::Vec3b(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4b(cv::Mat *self, interop::Vec4b v)
{
    return cvTry([&] {
    self->push_back(cv::Vec4b(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6b(cv::Mat *self, interop::Vec6b v)
{
    return cvTry([&] {
    self->push_back(cv::Vec6b(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2s(cv::Mat *self, interop::Vec2s v)
{
    return cvTry([&] {
    self->push_back(cv::Vec2s(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3s(cv::Mat *self, interop::Vec3s v)
{
    return cvTry([&] {
    self->push_back(cv::Vec3s(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4s(cv::Mat *self, interop::Vec4s v)
{
    return cvTry([&] {
    self->push_back(cv::Vec4s(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6s(cv::Mat *self, interop::Vec6s v)
{
    return cvTry([&] {
    self->push_back(cv::Vec6s(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2w(cv::Mat *self, interop::Vec2w v)
{
    return cvTry([&] {
    self->push_back(cv::Vec2w(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3w(cv::Mat *self, interop::Vec3w v)
{
    return cvTry([&] {
    self->push_back(cv::Vec3w(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4w(cv::Mat *self, interop::Vec4w v)
{
    return cvTry([&] {
    self->push_back(cv::Vec4w(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6w(cv::Mat *self, interop::Vec6w v)
{
    return cvTry([&] {
    self->push_back(cv::Vec6w(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2i(cv::Mat *self, interop::Vec2i v)
{
    return cvTry([&] {
    self->push_back(cv::Vec2i(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3i(cv::Mat *self, interop::Vec3i v)
{
    return cvTry([&] {
    self->push_back(cv::Vec3i(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4i(cv::Mat *self, interop::Vec4i v)
{
    return cvTry([&] {
    self->push_back(cv::Vec4i(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6i(cv::Mat *self, interop::Vec6i v)
{
    return cvTry([&] {
    self->push_back(cv::Vec6i(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2f(cv::Mat *self, interop::Vec2f v)
{
    return cvTry([&] {
    self->push_back(cv::Vec2f(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3f(cv::Mat *self, interop::Vec3f v)
{
    return cvTry([&] {
    self->push_back(cv::Vec3f(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4f(cv::Mat *self, interop::Vec4f v)
{
    return cvTry([&] {
    self->push_back(cv::Vec4f(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6f(cv::Mat *self, interop::Vec6f v)
{
    return cvTry([&] {
    self->push_back(cv::Vec6f(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2d(cv::Mat *self, interop::Vec2d v)
{
    return cvTry([&] {
    self->push_back(cv::Vec2d(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3d(cv::Mat *self, interop::Vec3d v)
{
    return cvTry([&] {
    self->push_back(cv::Vec3d(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4d(cv::Mat *self, interop::Vec4d v)
{
    return cvTry([&] {
    self->push_back(cv::Vec4d(v.val));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6d(cv::Mat *self, interop::Vec6d v)
{
    return cvTry([&] {
    self->push_back(cv::Vec6d(v.val));
    });
}

CVAPI(ExceptionStatus) core_Mat_push_back_Point(cv::Mat *self, interop::Point v)
{
    return cvTry([&] {
    self->push_back(cv::Point(v.x, v.y));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point2f(cv::Mat *self, interop::Point2f v)
{
    return cvTry([&] {
    self->push_back(cv::Point2f(v.x, v.y));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point2d(cv::Mat *self, interop::Point2d v)
{
    return cvTry([&] {
    self->push_back(cv::Point2d(v.x, v.y));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point3i(cv::Mat *self, interop::Point3i v)
{
    return cvTry([&] {
    self->push_back(cv::Point3i(v.x, v.y, v.z));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point3f(cv::Mat *self, interop::Point3f v)
{
    return cvTry([&] {
    self->push_back(cv::Point3f(v.x, v.y, v.z));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point3d(cv::Mat *self, interop::Point3d v)
{
    return cvTry([&] {
    self->push_back(cv::Point3d(v.x, v.y, v.z));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Size(cv::Mat *self, interop::Size v)
{
    return cvTry([&] {
    self->push_back(cv::Size(v.width, v.height));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Size2f(cv::Mat *self, interop::Size2f v)
{
    return cvTry([&] {
    self->push_back(cv::Size2f(v.width, v.height));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Size2d(cv::Mat *self, interop::Size2d v)
{
    return cvTry([&] {
    self->push_back(cv::Size2d(v.width, v.height));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Rect(cv::Mat *self, interop::Rect v)
{
    return cvTry([&] {
    self->push_back(cv::Rect(v.x, v.y, v.width, v.height));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Rect2f(cv::Mat *self, interop::Rect2f v)
{
    return cvTry([&] {
    self->push_back(cv::Rect2f(v.x, v.y, v.width, v.height));
    });
}
CVAPI(ExceptionStatus) core_Mat_push_back_Rect2d(cv::Mat *self, interop::Rect2d v)
{
    return cvTry([&] {
    self->push_back(cv::Rect2d(v.x, v.y, v.width, v.height));
    });
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

CVAPI(ExceptionStatus) core_Mat_forEach_uchar(cv::Mat *m, Mat_foreach_uchar proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_uchar, uchar> functor(proc);
    m->forEach<uchar>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2b(cv::Mat *m, Mat_foreach_Vec2b proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec2b, cv::Vec2b> functor(proc);
    m->forEach<cv::Vec2b>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3b(cv::Mat *m, Mat_foreach_Vec3b proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec3b, cv::Vec3b> functor(proc);
    m->forEach<cv::Vec3b>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4b(cv::Mat *m, Mat_foreach_Vec4b proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec4b, cv::Vec4b> functor(proc);
    m->forEach<cv::Vec4b>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6b(cv::Mat *m, Mat_foreach_Vec6b proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec6b, cv::Vec6b> functor(proc);
    m->forEach<cv::Vec6b>(functor);
    });
}

CVAPI(ExceptionStatus) core_Mat_forEach_short(cv::Mat *m, Mat_foreach_short proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_short, short> functor(proc);
    m->forEach<short>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2s(cv::Mat *m, Mat_foreach_Vec2s proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec2s, cv::Vec2s> functor(proc);
    m->forEach<cv::Vec2s>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3s(cv::Mat *m, Mat_foreach_Vec3s proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec3s, cv::Vec3s> functor(proc);
    m->forEach<cv::Vec3s>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4s(cv::Mat *m, Mat_foreach_Vec4s proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec4s, cv::Vec4s> functor(proc);
    m->forEach<cv::Vec4s>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6s(cv::Mat *m, Mat_foreach_Vec6s proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec6s, cv::Vec6s> functor(proc);
    m->forEach<cv::Vec6s>(functor);
    });
}

CVAPI(ExceptionStatus) core_Mat_forEach_int(cv::Mat *m, Mat_foreach_int proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_int, int> functor(proc);
    m->forEach<int>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2i(cv::Mat *m, Mat_foreach_Vec2i proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec2i, cv::Vec2i> functor(proc);
    m->forEach<cv::Vec2i>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3i(cv::Mat *m, Mat_foreach_Vec3i proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec3i, cv::Vec3i> functor(proc);
    m->forEach<cv::Vec3i>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4i(cv::Mat *m, Mat_foreach_Vec4i proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec4i, cv::Vec4i> functor(proc);
    m->forEach<cv::Vec4i>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6i(cv::Mat *m, Mat_foreach_Vec6i proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec6i, cv::Vec6i> functor(proc);
    m->forEach<cv::Vec6i>(functor);
    });
}

CVAPI(ExceptionStatus) core_Mat_forEach_float(cv::Mat *m, Mat_foreach_float proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_float, float> functor(proc);
    m->forEach<float>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2f(cv::Mat *m, Mat_foreach_Vec2f proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec2f, cv::Vec2f> functor(proc);
    m->forEach<cv::Vec2f>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3f(cv::Mat *m, Mat_foreach_Vec3f proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec3f, cv::Vec3f> functor(proc);
    m->forEach<cv::Vec3f>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4f(cv::Mat *m, Mat_foreach_Vec4f proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec4f, cv::Vec4f> functor(proc);
    m->forEach<cv::Vec4f>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6f(cv::Mat *m, Mat_foreach_Vec6f proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec6f, cv::Vec6f> functor(proc);
    m->forEach<cv::Vec6f>(functor);
    });
}

CVAPI(ExceptionStatus) core_Mat_forEach_double(cv::Mat *m, Mat_foreach_double proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_double, double> functor(proc);
    m->forEach<double>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2d(cv::Mat *m, Mat_foreach_Vec2d proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec2d, cv::Vec2d> functor(proc);
    m->forEach<cv::Vec2d>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3d(cv::Mat *m, Mat_foreach_Vec3d proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec3d, cv::Vec3d> functor(proc);
    m->forEach<cv::Vec3d>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4d(cv::Mat *m, Mat_foreach_Vec4d proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec4d, cv::Vec4d> functor(proc);
    m->forEach<cv::Vec4d>(functor);
    });
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6d(cv::Mat *m, Mat_foreach_Vec6d proc)
{
    return cvTry([&] {
    const Functor<Mat_foreach_Vec6d, cv::Vec6d> functor(proc);
    m->forEach<cv::Vec6d>(functor);
    });
}
#pragma endregion

#pragma region Operators

CVAPI(ExceptionStatus) core_Mat_operatorUnaryMinus(cv::Mat *mat, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = -(*mat);
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_operatorAdd_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) + (*b);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorAdd_MatScalar(cv::Mat *a, interop::Scalar s, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) + cpp(s);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorAdd_ScalarMat(interop::Scalar s, cv::Mat *a, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = cpp(s) + (*a); 
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_operatorMinus_Mat(cv::Mat *a, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = -(*a);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorSubtract_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) - (*b);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorSubtract_MatScalar(cv::Mat *a, interop::Scalar s, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) - cpp(s);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorSubtract_ScalarMat(interop::Scalar s, cv::Mat *a, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = cpp(s) - (*a); 
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_operatorMultiply_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) * (*b);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorMultiply_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) * s;
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorMultiply_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = s * (*a); 
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_operatorDivide_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) / (*b);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorDivide_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) / s;
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorDivide_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = s / (*a); 
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_operatorAnd_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) & (*b);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorAnd_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) & s;
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorAnd_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = s & (*a); 
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_operatorOr_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) | (*b);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorOr_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) | s;
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorOr_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = s | (*a); 
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_operatorXor_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) ^ (*b);
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorXor_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) ^ s;
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorXor_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = s ^ (*a); 
    *returnValue = new cv::MatExpr(expr);
    });
}

CVAPI(ExceptionStatus) core_Mat_operatorNot(cv::Mat *a, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = ~(*a);
    *returnValue = new cv::MatExpr(expr);
    });
}


// Comparison Operators

// <
CVAPI(ExceptionStatus) core_Mat_operatorLT_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) < (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorLT_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = a < (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorLT_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) < b; 
    *returnValue = new cv::MatExpr(expr);
    });
}
// <=
CVAPI(ExceptionStatus) core_Mat_operatorLE_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) <= (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorLE_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = a <= (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorLE_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) <= b; 
    *returnValue = new cv::MatExpr(expr);
    });
}
// >
CVAPI(ExceptionStatus) core_Mat_operatorGT_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) > (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorGT_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = a > (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorGT_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) > b; 
    *returnValue = new cv::MatExpr(expr);
    });
}
// >=
CVAPI(ExceptionStatus) core_Mat_operatorGE_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) >= (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorGE_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = a >= (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorGE_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) >= b; 
    *returnValue = new cv::MatExpr(expr);
    });
}
// ==
CVAPI(ExceptionStatus) core_Mat_operatorEQ_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) == (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorEQ_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = a == (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorEQ_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) == b; 
    *returnValue = new cv::MatExpr(expr);
    });
}
// !=
CVAPI(ExceptionStatus) core_Mat_operatorNE_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) != (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorNE_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = a != (*b); 
    *returnValue = new cv::MatExpr(expr);
    });
}
CVAPI(ExceptionStatus) core_Mat_operatorNE_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    return cvTry([&] {
    const auto expr = (*a) != b; 
    *returnValue = new cv::MatExpr(expr);
    });
}

#pragma endregion
