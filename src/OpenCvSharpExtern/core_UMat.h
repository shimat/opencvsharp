#pragma once

#include "include_opencv.h"

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#pragma region Init & Release

CVAPI(ExceptionStatus) core_UMat_new1(const cv::UMatUsageFlags usageFlags, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(usageFlags);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_new2(const int rows, const int cols, const int type, const cv::UMatUsageFlags usageFlags, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(rows, cols, type, usageFlags);
    END_WRAP
}
/*
CVAPI(ExceptionStatus) core_UMat_new3(cv::Size size, int type, cv::UMatUsageFlags usageFlags, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(size, type, usageFlags);
    END_WRAP
}
*/
CVAPI(ExceptionStatus) core_UMat_new3(
    const int rows, const int cols, const int type, const MyCvScalar s, const cv::UMatUsageFlags usageFlags, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(rows, cols, type, cpp(s), usageFlags);
    END_WRAP
}
/*
CVAPI(ExceptionStatus) core_UMat_new5(cv::Size size, int type, MyCvScalar s, cv::UMatUsageFlags usageFlags, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(size, type, cpp(s), usageFlags);
    END_WRAP
}
*/
CVAPI(ExceptionStatus) core_UMat_new4(
    const int ndims, const int* sizes, const int type, const cv::UMatUsageFlags usageFlags, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(ndims, sizes, type, usageFlags);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_new5(
    const int ndims, const int* sizes, const int type, const MyCvScalar s, cv::UMatUsageFlags usageFlags, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(ndims, sizes, type, cpp(s), usageFlags);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_new6(cv::UMat* umat, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(*umat);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_new7(cv::UMat* umat, const MyCvSlice rowRange, const MyCvSlice colRange, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(*umat, cpp(rowRange), cpp(colRange));
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_new8(cv::UMat* umat, const MyCvRect roi, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(*umat, cpp(roi));
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_new9(cv::UMat* umat, cv::Range* ranges, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(*umat, ranges);
    END_WRAP
}
/*
CVAPI(ExceptionStatus) core_UMat_new12(cv::UMat* umat, std::vector<cv::Range>& ranges, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(*umat, ranges);
    END_WRAP
}
*/

CVAPI(ExceptionStatus) core_UMat_delete(cv::UMat* self)
{
    BEGIN_WRAP
        delete self;
    END_WRAP
}

#pragma endregion

#pragma region Functions

CVAPI(ExceptionStatus) core_UMat_getMat(cv::UMat* self, cv::AccessFlag accessFlag, cv::Mat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(self->getMat(accessFlag));
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_row(cv::UMat* self, int y, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(self->row(y));
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_col(cv::UMat* self, int x, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(self->col(x));
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_rowRange(cv::UMat* self, int startRow, int endRow, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(self->rowRange(startRow, endRow));
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_colRange(cv::UMat* self, int startCol, int endCol, cv::UMat** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::UMat(self->colRange(startCol, endCol));
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_diag(cv::UMat* self, int d, cv::UMat** returnValue)
{
    BEGIN_WRAP
        const auto ret = self->diag(d);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_diag_static(cv::UMat* self, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::UMat::diag(*self);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_clone(cv::UMat* self, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto ret = self->clone();
    *returnValue = new cv::UMat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_copyTo1(cv::UMat* self, cv::_OutputArray* m)
{
    BEGIN_WRAP
    self->copyTo(*m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_copyTo2(cv::UMat* self, cv::_OutputArray* m, cv::_InputArray* mask)
{
    BEGIN_WRAP
    self->copyTo(*m, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_copyTo_toUMat1(cv::UMat* self, cv::UMat* m)
{
    BEGIN_WRAP
    self->copyTo(*m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_copyTo_toUMat2(cv::UMat* self, cv::UMat* m, cv::_InputArray* mask)
{
    BEGIN_WRAP
    self->copyTo(*m, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_convertTo(cv::UMat* self, cv::_OutputArray* m, int rtype, double alpha, double beta)
{
    BEGIN_WRAP
    self->convertTo(*m, rtype, alpha, beta);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_assignTo(cv::UMat* self, cv::UMat* m, int type)
{
    BEGIN_WRAP
    self->assignTo(*m, type);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_setTo_Scalar(cv::UMat* self, MyCvScalar value, cv::UMat* mask)
{
    BEGIN_WRAP
    if (mask == nullptr)
        self->setTo(cpp(value));
    else
        self->setTo(cpp(value), entity(mask));
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_setTo_InputArray(cv::UMat* self, cv::_InputArray* value, cv::UMat* mask)
{
    BEGIN_WRAP
    self->setTo(*value, entity(mask));
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_reshape1(cv::UMat* self, int cn, int rows, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto ret = self->reshape(cn, rows);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_reshape2(cv::UMat* self, int cn, int newndims, const int* newsz, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto ret = self->reshape(cn, newndims, newsz);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_t(cv::UMat* self, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto expr = self->t();
    *returnValue = new cv::UMat(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_inv(cv::UMat* self, int method, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto ret = self->inv(method);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_mul(cv::UMat* self, cv::_InputArray* m, double scale, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto ret = self->mul(*m, scale);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_dot(cv::UMat* self, cv::_InputArray* m, double* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->dot(*m);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_zeros1(int rows, int cols, int type, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto expr = cv::UMat::zeros(rows, cols, type);
    *returnValue = new cv::UMat(expr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_zeros2(int ndims, const int* sz, int type, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto expr = cv::UMat::zeros(ndims, sz, type);
    *returnValue = new cv::UMat(expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_ones1(int rows, int cols, int type, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto ret = cv::UMat::ones(rows, cols, type);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_ones2(int ndims, const int* sz, int type, cv::UMat** returnValue)
{
    BEGIN_WRAP
    cv::UMat ret = cv::UMat::ones(ndims, sz, type);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_eye(int rows, int cols, int type, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto eye = cv::UMat::eye(rows, cols, type);
    *returnValue = new cv::UMat(eye);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_create1(cv::UMat* self, int rows, int cols, int type, cv::UMatUsageFlags usageFlags)
{
    BEGIN_WRAP
    self->create(rows, cols, type, usageFlags);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_create2(cv::UMat* self, int ndims, const int* sizes, int type, cv::UMatUsageFlags usageFlags)
{
    BEGIN_WRAP
    self->create(ndims, sizes, type, usageFlags);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_locateROI(cv::UMat* self, MyCvSize* wholeSize, MyCvPoint* ofs)
{
    BEGIN_WRAP
    cv::Size wholeSize2;
    cv::Point ofs2;
    self->locateROI(wholeSize2, ofs2);
    *wholeSize = c(cv::Size(wholeSize2.width, wholeSize2.height));
    *ofs = c(cv::Point(ofs2.x, ofs2.y));
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_adjustROI(cv::UMat* self, int dtop, int dbottom, int dleft, int dright, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const auto ret = self->adjustROI(dtop, dbottom, dleft, dright);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_subMat1(cv::UMat* self, int rowStart, int rowEnd, int colStart, int colEnd, cv::UMat** returnValue)
{
    BEGIN_WRAP
    const cv::Range rowRange(rowStart, rowEnd);
    const cv::Range colRange(colStart, colEnd);
    const auto ret = (*self)(rowRange, colRange);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_subMat2(cv::UMat* self, int nRanges, MyCvSlice* ranges, cv::UMat** returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Range> rangesVec(nRanges);
    for (auto i = 0; i < nRanges; i++)
    {
        rangesVec[i] = (cpp(ranges[i]));
    }
    const auto ret = (*self)(&rangesVec[0]);
    *returnValue = new cv::UMat(ret);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_isContinuous(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->isContinuous() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_isSubmatrix(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->isSubmatrix() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_elemSize(cv::UMat* self, size_t* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->elemSize();
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_elemSize1(cv::UMat* self, size_t* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->elemSize1();
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_type(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->type();
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_depth(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->depth();
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_channels(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->channels();
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_step1(cv::UMat* self, int i, size_t* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->step1(i);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_empty(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_total(cv::UMat* self, size_t* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->total();
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_checkVector(cv::UMat* self, int elemChannels, int depth, int requireContinuous, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->checkVector(elemChannels, depth, requireContinuous != 0);
    END_WRAP
}

//does this replace Ptr?
CVAPI(ExceptionStatus) core_UMat_handle(cv::UMat* self, cv::AccessFlag accessFlag, void** returnValue)
{
    BEGIN_WRAP
    *returnValue = self->handle(accessFlag);
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_flags(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->flags;
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_dims(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->dims;
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_rows(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->rows;
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_cols(cv::UMat* self, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->cols;
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_size(cv::UMat* self, MyCvSize* returnValue)
{
    BEGIN_WRAP
    *returnValue = c(self->size());
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_sizeAt(cv::UMat* self, int i, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->size[i];
    END_WRAP
}

CVAPI(ExceptionStatus) core_UMat_step(cv::UMat* self, size_t* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->step;
    END_WRAP
}
CVAPI(ExceptionStatus) core_UMat_stepAt(cv::UMat* self, int i, size_t* returnValue)
{
    BEGIN_WRAP
    *returnValue = self->step[i];
    END_WRAP
}

#pragma endregion
