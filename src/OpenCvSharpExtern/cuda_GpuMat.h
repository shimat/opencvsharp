#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile


#include "include_opencv.h"
#include <opencv2/core/cuda.hpp>

#pragma region Init and Disposal

CVAPI(ExceptionStatus) cuda_GpuMat_delete(cv::cuda::GpuMat *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new1(cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new2(int rows, int cols, int type, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(rows, cols, type);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new3(int rows, int cols, int type, void *data, uint64_t step, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(rows, cols, type, data, static_cast<size_t>(step));
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new4(cv::Mat *mat, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(*mat);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new5(cv::cuda::GpuMat *gpumat, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(*gpumat);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new6(MyCvSize size, int type, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(cv::Size(size.width, size.height), type);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new7(MyCvSize size, int type, void *data, uint64_t step, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(cv::Size(size.width, size.height), type, data, static_cast<size_t>(step));
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new8(int rows, int cols, int type, MyCvScalar s, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(rows, cols, type, cpp(s));
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new9(cv::cuda::GpuMat *m, MyCvSlice rowRange, MyCvSlice colRange, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(*m, cpp(rowRange), cpp(colRange));
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new10(cv::cuda::GpuMat *m, MyCvRect roi, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(*m, cpp(roi));
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_new11(MyCvSize size, int type, MyCvScalar s, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::cuda::GpuMat(cv::Size(size.width, size.height), type, cpp(s));
    END_WRAP
}
#pragma endregion

#pragma region Fields
CVAPI(ExceptionStatus) cuda_GpuMat_flags(cv::cuda::GpuMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->flags;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_rows(cv::cuda::GpuMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->rows;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_cols(cv::cuda::GpuMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->cols;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_step(cv::cuda::GpuMat *obj, uint64_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<uint64_t>(obj->step);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_data(cv::cuda::GpuMat *obj, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->data;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_refcount(cv::cuda::GpuMat *obj, int **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->refcount;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_datastart(cv::cuda::GpuMat *obj, uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->datastart;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_dataend(cv::cuda::GpuMat *obj, const uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->dataend;
    END_WRAP
}
#pragma endregion

#pragma region Operators
CVAPI(ExceptionStatus) cuda_GpuMat_opAssign(cv::cuda::GpuMat *left, cv::cuda::GpuMat *right)
{
    BEGIN_WRAP
    *left = *right;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_opRange1(cv::cuda::GpuMat *src, MyCvRect roi, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto gm = (*src)(cpp(roi));
    *returnValue = new cv::cuda::GpuMat(gm);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_opRange2(cv::cuda::GpuMat *src, MyCvSlice rowRange, MyCvSlice colRange, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto gm = (*src)(cpp(rowRange), cpp(colRange));
    *returnValue = new cv::cuda::GpuMat(gm);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_opToMat(cv::cuda::GpuMat *src, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto m = cv::Mat(*src);
    *returnValue = new cv::Mat(m);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_opToGpuMat(cv::Mat *src, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto gm = cv::cuda::GpuMat(*src);
    *returnValue = new cv::cuda::GpuMat(gm);
    END_WRAP
}
#pragma endregion

#pragma region Methods

CVAPI(ExceptionStatus) cuda_GpuMat_upload(cv::cuda::GpuMat *obj, cv::_InputArray *m)
{
    BEGIN_WRAP
    obj->upload(*m);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_upload_stream(cv::cuda::GpuMat *obj, cv::_InputArray *m, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    obj->upload(*m, *stream);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_download(cv::cuda::GpuMat *obj, cv::_OutputArray *m)
{
    BEGIN_WRAP
    obj->download(*m);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_download_stream(cv::cuda::GpuMat *obj, cv::_OutputArray *m, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    obj->download(*m, *stream);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_row(cv::cuda::GpuMat *obj, int y, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->row(y);
    *returnValue = new cv::cuda::GpuMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_col(cv::cuda::GpuMat *obj, int x, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->col(x);
    *returnValue = new cv::cuda::GpuMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_rowRange(cv::cuda::GpuMat *obj, int startrow, int endrow, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->rowRange(startrow, endrow);
    *returnValue = new cv::cuda::GpuMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_colRange(cv::cuda::GpuMat *obj, int startcol, int endcol, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->colRange(startcol, endcol);
    *returnValue = new cv::cuda::GpuMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_clone(cv::cuda::GpuMat *obj, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->clone();
    *returnValue = new cv::cuda::GpuMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_copyTo1(cv::cuda::GpuMat *obj, cv::cuda::GpuMat *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    if (stream == nullptr)
        obj->copyTo(*dst);
    else
        obj->copyTo(*dst, *stream);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_copyTo_mask1(cv::cuda::GpuMat *obj, cv::cuda::GpuMat *dst, cv::cuda::GpuMat *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    if (stream == nullptr)
        obj->copyTo(*dst, *mask);
    else
        obj->copyTo(*dst, *mask, *stream);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_copyTo2(cv::cuda::GpuMat *obj, cv::_OutputArray *dst, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    if (stream == nullptr)
        obj->copyTo(*dst);
    else
        obj->copyTo(*dst, *stream);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_copyTo_mask2(cv::cuda::GpuMat *obj, cv::_OutputArray *dst, cv::_InputArray *mask, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    if (stream == nullptr)
        obj->copyTo(*dst, *mask);
    else
        obj->copyTo(*dst, *mask, *stream);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_convertTo1(cv::cuda::GpuMat *obj, cv::cuda::GpuMat *dst, int rtype, double alpha, double beta, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    if (stream == nullptr)
        obj->convertTo(*dst, rtype, alpha, beta);
    else
        obj->convertTo(*dst, rtype, alpha, beta, *stream);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_convertTo2(cv::cuda::GpuMat *obj, cv::_OutputArray *dst, int rtype, double alpha, double beta, cv::cuda::Stream *stream)
{
    BEGIN_WRAP
    if (stream == nullptr)
        obj->convertTo(*dst, rtype, alpha, beta);
    else
        obj->convertTo(*dst, rtype, alpha, beta, *stream);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_assignTo(cv::cuda::GpuMat *obj, cv::cuda::GpuMat *m, int type)
{
    BEGIN_WRAP
    obj->assignTo(*m, type);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_setTo(cv::cuda::GpuMat *obj, MyCvScalar s, cv::_InputArray *mask, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    cv::cuda::GpuMat gm = (mask == nullptr) ? obj->setTo(cpp(s)) : obj->setTo(cpp(s), *mask);
    *returnValue = new cv::cuda::GpuMat(gm);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_setTo_stream(cv::cuda::GpuMat *obj, MyCvScalar s, cv::_InputArray *mask, cv::cuda::Stream *stream, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    cv::cuda::GpuMat gm = (mask == nullptr) ? obj->setTo(cpp(s), *stream) : obj->setTo(cpp(s), *mask, *stream);
    *returnValue = new cv::cuda::GpuMat(gm);
    END_WRAP
}


CVAPI(ExceptionStatus) cuda_GpuMat_reshape(cv::cuda::GpuMat *obj, int cn, int rows, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->reshape(cn, rows);
    *returnValue = new cv::cuda::GpuMat(ret);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_create1(cv::cuda::GpuMat *obj, int rows, int cols, int type)
{
    BEGIN_WRAP
    obj->create(rows, cols, type);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_create2(cv::cuda::GpuMat *obj, MyCvSize size, int type)
{
    BEGIN_WRAP
    obj->create(cv::Size(size.width, size.height), type);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_release(cv::cuda::GpuMat *obj)
{
    BEGIN_WRAP
    obj->release();
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_swap(cv::cuda::GpuMat *obj, cv::cuda::GpuMat *mat)
{
    BEGIN_WRAP
    obj->swap(*mat);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_locateROI(cv::cuda::GpuMat *obj, MyCvSize *wholeSize, MyCvPoint *ofs)
{
    BEGIN_WRAP
    cv::Size _wholeSize;
    cv::Point _ofs;
    obj->locateROI(_wholeSize, _ofs);
    *wholeSize = c(cv::Size(_wholeSize.width, _wholeSize.height));
    *ofs = c(cv::Point(_ofs.x, _ofs.y));
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_adjustROI(cv::cuda::GpuMat *obj, int dtop, int dbottom, int dleft, int dright, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto gm = obj->adjustROI(dtop, dbottom, dleft, dright);
    *returnValue = new cv::cuda::GpuMat(gm);
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_isContinuous(cv::cuda::GpuMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isContinuous() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) cuda_GpuMat_elemSize(cv::cuda::GpuMat *obj, uint64_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<uint64_t>(obj->elemSize());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_elemSize1(cv::cuda::GpuMat *obj, uint64_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<uint64_t>(obj->elemSize1());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_type(cv::cuda::GpuMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->type();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_depth(cv::cuda::GpuMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->depth();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_channels(cv::cuda::GpuMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->channels();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_step1(cv::cuda::GpuMat *obj, uint64_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<uint64_t>(obj->step1());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_size(cv::cuda::GpuMat *obj, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->size());
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_empty(cv::cuda::GpuMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_ptr(const cv::cuda::GpuMat *obj, int y, const uchar **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->ptr(y);
    END_WRAP
}

#pragma endregion

//! Creates continuous GPU matrix
CVAPI(ExceptionStatus) cuda_createContinuous1(int rows, int cols, int type, cv::cuda::GpuMat *gm)
{
    BEGIN_WRAP
    cv::cuda::createContinuous(rows, cols, type, *gm);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_createContinuous2(int rows, int cols, int type, cv::cuda::GpuMat **returnValue)
{
    BEGIN_WRAP
    const auto gm = cv::cuda::createContinuous(rows, cols, type);
    *returnValue = new cv::cuda::GpuMat(gm);
    END_WRAP
}

//! Ensures that size of the given matrix is not less than (rows, cols) size
//! and matrix type is match specified one too
CVAPI(ExceptionStatus) cuda_ensureSizeIsEnough(int rows, int cols, int type, cv::_OutputArray *m)
{
    BEGIN_WRAP
    cv::cuda::ensureSizeIsEnough(rows, cols, type, *m);
    END_WRAP
}
#pragma region GpuMat Stream Overloads




CVAPI(ExceptionStatus) cuda_GpuMat_cudaPtr(cv::cuda::GpuMat *obj, void **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->cudaPtr();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_updateContinuityFlag(cv::cuda::GpuMat *obj)
{
    BEGIN_WRAP
    obj->updateContinuityFlag();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_defaultAllocator(cv::cuda::GpuMat::Allocator **returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::GpuMat::defaultAllocator();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_getStdAllocator(cv::cuda::GpuMat::Allocator **returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::cuda::GpuMat::getStdAllocator();
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_setDefaultAllocator(cv::cuda::GpuMat::Allocator *allocator)
{
    BEGIN_WRAP
    cv::cuda::GpuMat::setDefaultAllocator(allocator);
    END_WRAP
}

CVAPI(ExceptionStatus) cuda_GpuMat_copyTo_OutputArray(cv::cuda::GpuMat *obj, cv::_OutputArray *dst)
{
    BEGIN_WRAP
    obj->copyTo(*dst);
    END_WRAP
}

#pragma endregion


