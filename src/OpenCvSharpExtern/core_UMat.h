#pragma once

#include "include_opencv.h"

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#pragma region Init & Release

CVAPI(ExceptionStatus) core_UMat_new1(const cv::UMatUsageFlags usageFlags, cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(usageFlags);
    });
}
CVAPI(ExceptionStatus) core_UMat_new2(
    const int rows,
    const int cols,
    const int type,
    const cv::UMatUsageFlags usageFlags,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(rows, cols, type, usageFlags);
    });
}
/*
CVAPI(ExceptionStatus) core_UMat_new3(
    cv::Size size,
    int type,
    cv::UMatUsageFlags usageFlags,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(size, type, usageFlags);
    });
}
*/
CVAPI(ExceptionStatus) core_UMat_new3(
    const int rows,
    const int cols,
    const int type,
    const interop::Scalar s,
    const cv::UMatUsageFlags usageFlags,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(rows, cols, type, cpp(s), usageFlags);
    });
}
/*
CVAPI(ExceptionStatus) core_UMat_new5(
    cv::Size size,
    int type,
    interop::Scalar s,
    cv::UMatUsageFlags usageFlags,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(size, type, cpp(s), usageFlags);
    });
}
*/
CVAPI(ExceptionStatus) core_UMat_new4(
    const int ndims,
    const int* sizes,
    const int type,
    const cv::UMatUsageFlags usageFlags,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(ndims, sizes, type, usageFlags);
    });
}
CVAPI(ExceptionStatus) core_UMat_new5(
    const int ndims,
    const int* sizes,
    const int type,
    const interop::Scalar s,
    cv::UMatUsageFlags usageFlags,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(ndims, sizes, type, cpp(s), usageFlags);
    });
}
CVAPI(ExceptionStatus) core_UMat_new6(cv::UMat* umat, cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(*umat);
    });
}
CVAPI(ExceptionStatus) core_UMat_new7(
    cv::UMat* umat,
    const interop::Range rowRange,
    const interop::Range colRange,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(*umat, cpp(rowRange), cpp(colRange));
    });
}
CVAPI(ExceptionStatus) core_UMat_new8(
    cv::UMat* umat,
    const interop::Rect roi,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(*umat, cpp(roi));
    });
}
CVAPI(ExceptionStatus) core_UMat_new9(
    cv::UMat* umat,
    cv::Range* ranges,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(*umat, ranges);
    });
}
/*
CVAPI(ExceptionStatus) core_UMat_new12(
    cv::UMat* umat,
    std::vector<cv::Range>& ranges,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(*umat, ranges);
    });
}
*/

CVAPI(ExceptionStatus) core_UMat_delete(cv::UMat* self)
{
    return cvTry([&] {
        delete self;
    });
}

#pragma endregion

#pragma region Functions

CVAPI(ExceptionStatus) core_UMat_getMat(
    cv::UMat* self,
    cv::AccessFlag accessFlag,
    cv::Mat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Mat(self->getMat(accessFlag));
    });
}

CVAPI(ExceptionStatus) core_UMat_row(
    cv::UMat* self,
    int y,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(self->row(y));
    });
}

CVAPI(ExceptionStatus) core_UMat_col(
    cv::UMat* self,
    int x,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(self->col(x));
    });
}

CVAPI(ExceptionStatus) core_UMat_rowRange(
    cv::UMat* self,
    int startRow,
    int endRow,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(self->rowRange(startRow, endRow));
    });
}

CVAPI(ExceptionStatus) core_UMat_colRange(
    cv::UMat* self,
    int startCol,
    int endCol,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::UMat(self->colRange(startCol, endCol));
    });
}

CVAPI(ExceptionStatus) core_UMat_diag(
    cv::UMat* self,
    int d,
    cv::UMat** returnValue)
{
    return cvTry([&] {
        const auto ret = self->diag(d);
    *returnValue = new cv::UMat(ret);
    });
}
CVAPI(ExceptionStatus) core_UMat_diag_static(cv::UMat* self, cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto ret = cv::UMat::diag(*self);
    *returnValue = new cv::UMat(ret);
    });
}

CVAPI(ExceptionStatus) core_UMat_clone(cv::UMat* self, cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto ret = self->clone();
    *returnValue = new cv::UMat(ret);
    });
}

CVAPI(ExceptionStatus) core_UMat_copyTo1(cv::UMat* self, const interop::OutputArrayProxy* m)
{
    return cvTry([&] {
    self->copyTo(OutProxy(*m));
    });
}
CVAPI(ExceptionStatus) core_UMat_copyTo2(
    cv::UMat* self,
    const interop::OutputArrayProxy* m,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
    self->copyTo(OutProxy(*m), InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) core_UMat_copyTo_toUMat1(cv::UMat* self, cv::UMat* m)
{
    return cvTry([&] {
    self->copyTo(*m);
    });
}
CVAPI(ExceptionStatus) core_UMat_copyTo_toUMat2(
    cv::UMat* self,
    cv::UMat* m,
    const interop::InputArrayProxy* mask)
{
    return cvTry([&] {
    self->copyTo(*m, InProxy(*mask));
    });
}

CVAPI(ExceptionStatus) core_UMat_convertTo(
    cv::UMat* self,
    const interop::OutputArrayProxy* m,
    int rtype,
    double alpha,
    double beta)
{
    return cvTry([&] {
    self->convertTo(OutProxy(*m), rtype, alpha, beta);
    });
}

CVAPI(ExceptionStatus) core_UMat_assignTo(
    cv::UMat* self,
    cv::UMat* m,
    int type)
{
    return cvTry([&] {
    self->assignTo(*m, type);
    });
}

CVAPI(ExceptionStatus) core_UMat_setTo_Scalar(
    cv::UMat* self,
    interop::Scalar value,
    cv::UMat* mask)
{
    return cvTry([&] {
    if (mask == nullptr)
        self->setTo(cpp(value));
    else
        self->setTo(cpp(value), entity(mask));
    });
}
CVAPI(ExceptionStatus) core_UMat_setTo_InputArray(
    cv::UMat* self,
    const interop::InputArrayProxy* value,
    cv::UMat* mask)
{
    return cvTry([&] {
    self->setTo(InProxy(*value), entity(mask));
    });
}

CVAPI(ExceptionStatus) core_UMat_reshape1(
    cv::UMat* self,
    int cn,
    int rows,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto ret = self->reshape(cn, rows);
    *returnValue = new cv::UMat(ret);
    });
}
CVAPI(ExceptionStatus) core_UMat_reshape2(
    cv::UMat* self,
    int cn,
    int newndims,
    const int* newsz,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto ret = self->reshape(cn, newndims, newsz);
    *returnValue = new cv::UMat(ret);
    });
}

CVAPI(ExceptionStatus) core_UMat_t(cv::UMat* self, cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto expr = self->t();
    *returnValue = new cv::UMat(expr);
    });
}

CVAPI(ExceptionStatus) core_UMat_inv(
    cv::UMat* self,
    int method,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto ret = self->inv(method);
    *returnValue = new cv::UMat(ret);
    });
}

CVAPI(ExceptionStatus) core_UMat_mul(
    cv::UMat* self,
    const interop::InputArrayProxy* m,
    double scale,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto ret = self->mul(InProxy(*m), scale);
    *returnValue = new cv::UMat(ret);
    });
}

CVAPI(ExceptionStatus) core_UMat_dot(
    cv::UMat* self,
    const interop::InputArrayProxy* m,
    double* returnValue)
{
    return cvTry([&] {
    *returnValue = self->dot(InProxy(*m));
    });
}

CVAPI(ExceptionStatus) core_UMat_zeros1(
    int rows,
    int cols,
    int type,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto expr = cv::UMat::zeros(rows, cols, type);
    *returnValue = new cv::UMat(expr);
    });
}
CVAPI(ExceptionStatus) core_UMat_zeros2(
    int ndims,
    const int* sz,
    int type,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto expr = cv::UMat::zeros(ndims, sz, type);
    *returnValue = new cv::UMat(expr);
    });
}

CVAPI(ExceptionStatus) core_UMat_ones1(
    int rows,
    int cols,
    int type,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto ret = cv::UMat::ones(rows, cols, type);
    *returnValue = new cv::UMat(ret);
    });
}
CVAPI(ExceptionStatus) core_UMat_ones2(
    int ndims,
    const int* sz,
    int type,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    cv::UMat ret = cv::UMat::ones(ndims, sz, type);
    *returnValue = new cv::UMat(ret);
    });
}

CVAPI(ExceptionStatus) core_UMat_eye(
    int rows,
    int cols,
    int type,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto eye = cv::UMat::eye(rows, cols, type);
    *returnValue = new cv::UMat(eye);
    });
}

CVAPI(ExceptionStatus) core_UMat_create1(
    cv::UMat* self,
    int rows,
    int cols,
    int type,
    cv::UMatUsageFlags usageFlags)
{
    return cvTry([&] {
    self->create(rows, cols, type, usageFlags);
    });
}
CVAPI(ExceptionStatus) core_UMat_create2(
    cv::UMat* self,
    int ndims,
    const int* sizes,
    int type,
    cv::UMatUsageFlags usageFlags)
{
    return cvTry([&] {
    self->create(ndims, sizes, type, usageFlags);
    });
}

CVAPI(ExceptionStatus) core_UMat_locateROI(
    cv::UMat* self,
    interop::Size* wholeSize,
    interop::Point* ofs)
{
    return cvTry([&] {
    cv::Size wholeSize2;
    cv::Point ofs2;
    self->locateROI(wholeSize2, ofs2);
    *wholeSize = c(cv::Size(wholeSize2.width, wholeSize2.height));
    *ofs = c(cv::Point(ofs2.x, ofs2.y));
    });
}

CVAPI(ExceptionStatus) core_UMat_adjustROI(
    cv::UMat* self,
    int dtop,
    int dbottom,
    int dleft,
    int dright,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const auto ret = self->adjustROI(dtop, dbottom, dleft, dright);
    *returnValue = new cv::UMat(ret);
    });
}

CVAPI(ExceptionStatus) core_UMat_subMat1(
    cv::UMat* self,
    int rowStart,
    int rowEnd,
    int colStart,
    int colEnd,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    const cv::Range rowRange(rowStart, rowEnd);
    const cv::Range colRange(colStart, colEnd);
    const auto ret = (*self)(rowRange, colRange);
    *returnValue = new cv::UMat(ret);
    });
}
CVAPI(ExceptionStatus) core_UMat_subMat2(
    cv::UMat* self,
    int nRanges,
    interop::Range* ranges,
    cv::UMat** returnValue)
{
    return cvTry([&] {
    std::vector<cv::Range> rangesVec(nRanges);
    for (auto i = 0; i < nRanges; i++)
    {
        rangesVec[i] = (cpp(ranges[i]));
    }
    const auto ret = (*self)(&rangesVec[0]);
    *returnValue = new cv::UMat(ret);
    });
}

CVAPI(ExceptionStatus) core_UMat_isContinuous(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->isContinuous() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_UMat_isSubmatrix(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->isSubmatrix() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_UMat_elemSize(cv::UMat* self, size_t* returnValue)
{
    return cvTry([&] {
    *returnValue = self->elemSize();
    });
}
CVAPI(ExceptionStatus) core_UMat_elemSize1(cv::UMat* self, size_t* returnValue)
{
    return cvTry([&] {
    *returnValue = self->elemSize1();
    });
}

CVAPI(ExceptionStatus) core_UMat_type(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->type();
    });
}

CVAPI(ExceptionStatus) core_UMat_depth(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->depth();
    });
}

CVAPI(ExceptionStatus) core_UMat_channels(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->channels();
    });
}

CVAPI(ExceptionStatus) core_UMat_step1(
    cv::UMat* self,
    int i,
    size_t* returnValue)
{
    return cvTry([&] {
    *returnValue = self->step1(i);
    });
}

CVAPI(ExceptionStatus) core_UMat_empty(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->empty() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_UMat_total(cv::UMat* self, size_t* returnValue)
{
    return cvTry([&] {
    *returnValue = self->total();
    });
}

CVAPI(ExceptionStatus) core_UMat_checkVector(
    cv::UMat* self,
    int elemChannels,
    int depth,
    int requireContinuous,
    int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->checkVector(elemChannels, depth, requireContinuous != 0);
    });
}

//does this replace Ptr?
CVAPI(ExceptionStatus) core_UMat_handle(
    cv::UMat* self,
    cv::AccessFlag accessFlag,
    void** returnValue)
{
    return cvTry([&] {
    *returnValue = self->handle(accessFlag);
    });
}

CVAPI(ExceptionStatus) core_UMat_flags(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->flags;
    });
}

CVAPI(ExceptionStatus) core_UMat_dims(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->dims;
    });
}

CVAPI(ExceptionStatus) core_UMat_rows(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->rows;
    });
}
CVAPI(ExceptionStatus) core_UMat_cols(cv::UMat* self, int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->cols;
    });
}

CVAPI(ExceptionStatus) core_UMat_size(cv::UMat* self, interop::Size* returnValue)
{
    return cvTry([&] {
    // See core_Mat_size: avoid OpenCV 5's dims <= 2 assert for multi-dimensional matrices.
    if (self->dims > 2)
        *returnValue = c(cv::Size(self->size[1], self->size[0]));
    else
        *returnValue = c(self->size());
    });
}
CVAPI(ExceptionStatus) core_UMat_sizeAt(
    cv::UMat* self,
    int i,
    int* returnValue)
{
    return cvTry([&] {
    *returnValue = self->size[i];
    });
}

CVAPI(ExceptionStatus) core_UMat_step(cv::UMat* self, size_t* returnValue)
{
    return cvTry([&] {
    *returnValue = self->step;
    });
}
CVAPI(ExceptionStatus) core_UMat_stepAt(
    cv::UMat* self,
    int i,
    size_t* returnValue)
{
    return cvTry([&] {
    *returnValue = self->step[i];
    });
}

#pragma endregion
