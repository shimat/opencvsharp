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

CVAPI(ExceptionStatus) core_Mat_copyTo_toMat1(cv::Mat *self, cv::Mat *m)
{
    BEGIN_WRAP
    self->copyTo(*m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_copyTo_toMat2(cv::Mat *self, cv::Mat *m, cv::_InputArray *mask)
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

CVAPI(ExceptionStatus) core_Mat_pop_back(cv::Mat *obj, size_t nelems)
{
    BEGIN_WRAP
    obj->pop_back(nelems);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_locateROI(cv::Mat *self, MyCvSize *wholeSize, MyCvPoint *ofs)
{
    BEGIN_WRAP
    cv::Size wholeSize2;
    cv::Point ofs2;
    self->locateROI(wholeSize2, ofs2);
    *wholeSize = c(cv::Size(wholeSize2.width, wholeSize2.height));
    *ofs = c(cv::Point(ofs2.x, ofs2.y));
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_adjustROI(cv::Mat *self, int dtop, int dbottom, int dleft, int dright, cv::Mat** returnValue)
{
    BEGIN_WRAP
    const auto ret = self->adjustROI(dtop, dbottom, dleft, dright);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_subMat1(cv::Mat *self, int rowStart, int rowEnd, int colStart, int colEnd, cv::Mat** returnValue)
{
    BEGIN_WRAP
    const cv::Range rowRange(rowStart, rowEnd);
    const cv::Range colRange(colStart, colEnd);
    const auto ret = (*self)(rowRange, colRange);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_subMat2(cv::Mat *self, int nRanges, MyCvSlice *ranges, cv::Mat** returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Range> rangesVec(nRanges);
    for (auto i = 0; i < nRanges; i++)
    {
        rangesVec[i] = (cpp(ranges[i]));
    }
    const auto ret = (*self)(&rangesVec[0]);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_isContinuous(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->isContinuous() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_isSubmatrix(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->isSubmatrix() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_elemSize(cv::Mat *self, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->elemSize();
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_elemSize1(cv::Mat *self, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->elemSize1();
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_type(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->type();
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_depth(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->depth();
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_channels(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->channels();
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_step1(cv::Mat *self, int i, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->step1(i);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_empty(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_total1(cv::Mat *self, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->total();
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_total2(cv::Mat *self, int startDim, int endDim, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->total(startDim, endDim);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_checkVector(cv::Mat *self, int elemChannels, int depth, int requireContinuous, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->checkVector(elemChannels, depth, requireContinuous != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_ptr1d(cv::Mat *self, int i0, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = self->ptr(i0);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_ptr2d(cv::Mat *self, int i0, int i1, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = self->ptr(i0, i1);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_ptr3d(cv::Mat *self, int i0, int i1, int i2, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = self->ptr(i0, i1, i2);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_ptrnd(cv::Mat *self, int *idx, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = self->ptr(idx);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_flags(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->flags;
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_dims(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->dims;
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_rows(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->rows;
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_cols(cv::Mat *self, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->cols;
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_data(cv::Mat *self, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = self->data;
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_datastart(cv::Mat *self, const uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = self->datastart;
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_dataend(cv::Mat *self, const uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = self->dataend;
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_datalimit(cv::Mat *self, const uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = self->datalimit;
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_size(cv::Mat *self, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(self->size());
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_sizeAt(cv::Mat *self, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->size[i];
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_step(cv::Mat *self, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->step;
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_stepAt(cv::Mat *self, int i, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->step[i];
    END_WRAP
}
      
CVAPI(ExceptionStatus) core_abs_Mat(cv::Mat *m, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::abs(*m);
    *returnValue = new cv::MatExpr(ret);
    END_WRAP
}

/*CVAPI(ExceptionStatus) core_Mat_assignment_FromMat(cv::Mat *self, cv::Mat *newMat)
{
    BEGIN_WRAP
    *self = *newMat;
    END_WRAP
}*/
/*CVAPI(ExceptionStatus) core_Mat_assignment_FromScalar(cv::Mat *self, MyCvScalar scalar)
{
    BEGIN_WRAP
    *self = cpp(scalar);
    END_WRAP
}*/

#pragma endregion

#pragma region getMatData/setMatData

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

CVAPI(ExceptionStatus) core_Mat_push_back_Mat(cv::Mat *self, cv::Mat *m)
{
    BEGIN_WRAP
    self->push_back(*m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_char(cv::Mat *self, char v)
{
    BEGIN_WRAP
    self->push_back(v);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_uchar(cv::Mat *self, uchar v)
{
    BEGIN_WRAP
    self->push_back(v);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_short(cv::Mat *self, short v)
{
    BEGIN_WRAP
    self->push_back(v);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_ushort(cv::Mat *self, ushort v)
{
    BEGIN_WRAP
    self->push_back(v);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_int(cv::Mat *self, int v)
{
    BEGIN_WRAP
    self->push_back(v);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_float(cv::Mat *self, float v)
{
    BEGIN_WRAP
    self->push_back(v);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_double(cv::Mat *self, double v)
{
    BEGIN_WRAP
    self->push_back(v);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_push_back_Vec2b(cv::Mat *self, CvVec2b v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec2b(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3b(cv::Mat *self, CvVec3b v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec3b(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4b(cv::Mat *self, CvVec4b v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec4b(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6b(cv::Mat *self, CvVec6b v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec6b(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2s(cv::Mat *self, CvVec2s v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec2s(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3s(cv::Mat *self, CvVec3s v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec3s(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4s(cv::Mat *self, CvVec4s v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec4s(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6s(cv::Mat *self, CvVec6s v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec6s(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2w(cv::Mat *self, CvVec2w v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec2w(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3w(cv::Mat *self, CvVec3w v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec3w(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4w(cv::Mat *self, CvVec4w v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec4w(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6w(cv::Mat *self, CvVec6w v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec6w(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2i(cv::Mat *self, CvVec2i v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec2i(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3i(cv::Mat *self, CvVec3i v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec3i(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4i(cv::Mat *self, CvVec4i v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec4i(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6i(cv::Mat *self, CvVec6i v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec6i(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2f(cv::Mat *self, CvVec2f v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec2f(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3f(cv::Mat *self, CvVec3f v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec3f(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4f(cv::Mat *self, CvVec4f v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec4f(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6f(cv::Mat *self, CvVec6f v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec6f(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec2d(cv::Mat *self, CvVec2d v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec2d(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec3d(cv::Mat *self, CvVec3d v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec3d(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec4d(cv::Mat *self, CvVec4d v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec4d(v.val));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Vec6d(cv::Mat *self, CvVec6d v)
{
    BEGIN_WRAP
    self->push_back(cv::Vec6d(v.val));
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_push_back_Point(cv::Mat *self, MyCvPoint v)
{
    BEGIN_WRAP
    self->push_back(cv::Point(v.x, v.y));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point2f(cv::Mat *self, MyCvPoint2D32f v)
{
    BEGIN_WRAP
    self->push_back(cv::Point2f(v.x, v.y));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point2d(cv::Mat *self, MyCvPoint2D64f v)
{
    BEGIN_WRAP
    self->push_back(cv::Point2d(v.x, v.y));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point3i(cv::Mat *self, MyCvPoint3D32i v)
{
    BEGIN_WRAP
    self->push_back(cv::Point3i(v.x, v.y, v.z));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point3f(cv::Mat *self, MyCvPoint3D32f v)
{
    BEGIN_WRAP
    self->push_back(cv::Point3f(v.x, v.y, v.z));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Point3d(cv::Mat *self, MyCvPoint3D64f v)
{
    BEGIN_WRAP
    self->push_back(cv::Point3d(v.x, v.y, v.z));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Size(cv::Mat *self, MyCvSize v)
{
    BEGIN_WRAP
    self->push_back(cv::Size(v.width, v.height));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Size2f(cv::Mat *self, MyCvSize2D32f v)
{
    BEGIN_WRAP
    self->push_back(cv::Size2f(v.width, v.height));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Size2d(cv::Mat *self, MyCvSize2D64f v)
{
    BEGIN_WRAP
    self->push_back(cv::Size2d(v.width, v.height));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Rect(cv::Mat *self, MyCvRect v)
{
    BEGIN_WRAP
    self->push_back(cv::Rect(v.x, v.y, v.width, v.height));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Rect2f(cv::Mat *self, MyCvRect2D32f v)
{
    BEGIN_WRAP
    self->push_back(cv::Rect2f(v.x, v.y, v.width, v.height));
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_push_back_Rect2d(cv::Mat *self, MyCvRect2D64f v)
{
    BEGIN_WRAP
    self->push_back(cv::Rect2d(v.x, v.y, v.width, v.height));
    END_WRAP
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
    BEGIN_WRAP
    const Functor<Mat_foreach_uchar, uchar> functor(proc);
    m->forEach<uchar>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2b(cv::Mat *m, Mat_foreach_Vec2b proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec2b, cv::Vec2b> functor(proc);
    m->forEach<cv::Vec2b>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3b(cv::Mat *m, Mat_foreach_Vec3b proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec3b, cv::Vec3b> functor(proc);
    m->forEach<cv::Vec3b>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4b(cv::Mat *m, Mat_foreach_Vec4b proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec4b, cv::Vec4b> functor(proc);
    m->forEach<cv::Vec4b>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6b(cv::Mat *m, Mat_foreach_Vec6b proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec6b, cv::Vec6b> functor(proc);
    m->forEach<cv::Vec6b>(functor);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_forEach_short(cv::Mat *m, Mat_foreach_short proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_short, short> functor(proc);
    m->forEach<short>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2s(cv::Mat *m, Mat_foreach_Vec2s proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec2s, cv::Vec2s> functor(proc);
    m->forEach<cv::Vec2s>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3s(cv::Mat *m, Mat_foreach_Vec3s proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec3s, cv::Vec3s> functor(proc);
    m->forEach<cv::Vec3s>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4s(cv::Mat *m, Mat_foreach_Vec4s proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec4s, cv::Vec4s> functor(proc);
    m->forEach<cv::Vec4s>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6s(cv::Mat *m, Mat_foreach_Vec6s proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec6s, cv::Vec6s> functor(proc);
    m->forEach<cv::Vec6s>(functor);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_forEach_int(cv::Mat *m, Mat_foreach_int proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_int, int> functor(proc);
    m->forEach<int>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2i(cv::Mat *m, Mat_foreach_Vec2i proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec2i, cv::Vec2i> functor(proc);
    m->forEach<cv::Vec2i>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3i(cv::Mat *m, Mat_foreach_Vec3i proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec3i, cv::Vec3i> functor(proc);
    m->forEach<cv::Vec3i>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4i(cv::Mat *m, Mat_foreach_Vec4i proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec4i, cv::Vec4i> functor(proc);
    m->forEach<cv::Vec4i>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6i(cv::Mat *m, Mat_foreach_Vec6i proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec6i, cv::Vec6i> functor(proc);
    m->forEach<cv::Vec6i>(functor);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_forEach_float(cv::Mat *m, Mat_foreach_float proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_float, float> functor(proc);
    m->forEach<float>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2f(cv::Mat *m, Mat_foreach_Vec2f proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec2f, cv::Vec2f> functor(proc);
    m->forEach<cv::Vec2f>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3f(cv::Mat *m, Mat_foreach_Vec3f proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec3f, cv::Vec3f> functor(proc);
    m->forEach<cv::Vec3f>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4f(cv::Mat *m, Mat_foreach_Vec4f proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec4f, cv::Vec4f> functor(proc);
    m->forEach<cv::Vec4f>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6f(cv::Mat *m, Mat_foreach_Vec6f proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec6f, cv::Vec6f> functor(proc);
    m->forEach<cv::Vec6f>(functor);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_forEach_double(cv::Mat *m, Mat_foreach_double proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_double, double> functor(proc);
    m->forEach<double>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec2d(cv::Mat *m, Mat_foreach_Vec2d proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec2d, cv::Vec2d> functor(proc);
    m->forEach<cv::Vec2d>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec3d(cv::Mat *m, Mat_foreach_Vec3d proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec3d, cv::Vec3d> functor(proc);
    m->forEach<cv::Vec3d>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec4d(cv::Mat *m, Mat_foreach_Vec4d proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec4d, cv::Vec4d> functor(proc);
    m->forEach<cv::Vec4d>(functor);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_forEach_Vec6d(cv::Mat *m, Mat_foreach_Vec6d proc)
{
    BEGIN_WRAP
    const Functor<Mat_foreach_Vec6d, cv::Vec6d> functor(proc);
    m->forEach<cv::Vec6d>(functor);
    END_WRAP
}
#pragma endregion

#pragma region Operators

CVAPI(ExceptionStatus) core_Mat_operatorUnaryMinus(cv::Mat *mat, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = -(*mat);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_operatorAdd_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) + (*b);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorAdd_MatScalar(cv::Mat *a, MyCvScalar s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) + cpp(s);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorAdd_ScalarMat(MyCvScalar s, cv::Mat *a, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = cpp(s) + (*a); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_operatorMinus_Mat(cv::Mat *a, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = -(*a);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorSubtract_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) - (*b);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorSubtract_MatScalar(cv::Mat *a, MyCvScalar s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) - cpp(s);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorSubtract_ScalarMat(MyCvScalar s, cv::Mat *a, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = cpp(s) - (*a); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_operatorMultiply_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) * (*b);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorMultiply_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) * s;
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorMultiply_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = s * (*a); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_operatorDivide_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) / (*b);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorDivide_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) / s;
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorDivide_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = s / (*a); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_operatorAnd_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) & (*b);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorAnd_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) & s;
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorAnd_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = s & (*a); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_operatorOr_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) | (*b);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorOr_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) | s;
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorOr_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = s | (*a); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_operatorXor_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) ^ (*b);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorXor_MatDouble(cv::Mat *a, double s, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) ^ s;
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorXor_DoubleMat(double s, cv::Mat *a, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = s ^ (*a); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_Mat_operatorNot(cv::Mat *a, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = ~(*a);
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}


// Comparison Operators

// <
CVAPI(ExceptionStatus) core_Mat_operatorLT_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) < (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorLT_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = a < (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorLT_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) < b; 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
// <=
CVAPI(ExceptionStatus) core_Mat_operatorLE_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) <= (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorLE_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = a <= (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorLE_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) <= b; 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
// >
CVAPI(ExceptionStatus) core_Mat_operatorGT_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) > (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorGT_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = a > (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorGT_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) > b; 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
// >=
CVAPI(ExceptionStatus) core_Mat_operatorGE_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) >= (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorGE_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = a >= (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorGE_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) >= b; 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
// ==
CVAPI(ExceptionStatus) core_Mat_operatorEQ_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) == (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorEQ_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = a == (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorEQ_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) == b; 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
// !=
CVAPI(ExceptionStatus) core_Mat_operatorNE_MatMat(cv::Mat *a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) != (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorNE_DoubleMat(double a, cv::Mat *b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = a != (*b); 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_Mat_operatorNE_MatDouble(cv::Mat *a, double b, cv::MatExpr **returnValue)
{
    BEGIN_WRAP
    const auto expr = (*a) != b; 
    *returnValue = new cv::MatExpr(expr);
    END_WRAP
}

#pragma endregion

#endif