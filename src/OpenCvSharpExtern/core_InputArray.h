#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(ExceptionStatus) core_InputArray_new_byMat(cv::Mat *mat, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::_InputArray(*mat);
    });
}

CVAPI(ExceptionStatus) core_InputArray_new_byUMat(cv::UMat* mat, cv::_InputArray** returnValue)
{
    return cvTry([&] {
        * returnValue = new cv::_InputArray(*mat);
    });
}

CVAPI(ExceptionStatus) core_InputArray_new_byMatExpr(cv::MatExpr *expr, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::_InputArray(*expr);
    });
}

CVAPI(ExceptionStatus) core_InputArray_new_byScalar(interop::Scalar s, cv::Scalar **handle, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *handle = new cv::Scalar(s.val[0], s.val[1], s.val[2], s.val[3]);
        *returnValue = new cv::_InputArray(**handle);
    });
}

CVAPI(ExceptionStatus) core_InputArray_new_byDouble(double *handle, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::_InputArray(*handle);
    });
}

#pragma region new_byVec

CVAPI(ExceptionStatus) core_InputArray_new_byVecb(uchar *vec, int n, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::_InputArray(vec, n);
    });
}
CVAPI(ExceptionStatus) core_InputArray_new_byVecs(short *vec, int n, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::_InputArray(vec, n);
    });
}
CVAPI(ExceptionStatus) core_InputArray_new_byVecw(ushort *vec, int n, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::_InputArray(vec, n);
    });
}
CVAPI(ExceptionStatus) core_InputArray_new_byVeci(int *vec, int n, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::_InputArray(vec, n);
    });
}
CVAPI(ExceptionStatus) core_InputArray_new_byVecf(float *vec, int n, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::_InputArray(vec, n);
    });
}
CVAPI(ExceptionStatus) core_InputArray_new_byVecd(double *vec, int n, cv::_InputArray **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::_InputArray(vec, n);
    });
}

#pragma endregion 

CVAPI(ExceptionStatus) core_InputArray_delete(cv::_InputArray *ia)
{
    return cvTry([&] {
        delete ia;
    });
}
CVAPI(ExceptionStatus) core_InputArray_delete_withScalar(cv::_InputArray *ia, cv::Scalar *handle)
{
    return cvTry([&] {
        delete ia;
        delete handle;
    });
}

CVAPI(ExceptionStatus) core_InputArray_getMat(cv::_InputArray *ia, int idx, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(ia->getMat(idx));
    });
}
/*CVAPI(ExceptionStatus) core_InputArray_getMat_(cv::_InputArray *ia, int idx, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(ia->getMat_(idx));
    });
}*/

CVAPI(ExceptionStatus) core_InputArray_getUMat(cv::_InputArray* ia, int idx, cv::UMat** returnValue)
{
    return cvTry([&] {
        * returnValue = new cv::UMat(ia->getUMat(idx));
    });
    
}

CVAPI(ExceptionStatus) core_InputArray_getMatVector(cv::_InputArray *ia, std::vector<cv::Mat> *mv)
{
    return cvTry([&] {
        ia->getMatVector(*mv);
    });
}
/*CVAPI(void) core_InputArray_getUMatVector(cv::_InputArray *ia, std::vector<cv::UMat> *umv)
{
    ia->getUMatVector(*umv);
}*/

CVAPI(ExceptionStatus) core_InputArray_getFlags(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->getFlags();
    });
}
CVAPI(ExceptionStatus) core_InputArray_getObj(cv::_InputArray *ia, void **returnValue)
{
    return cvTry([&] {
        *returnValue = ia->getObj();
    });
}
CVAPI(ExceptionStatus) core_InputArray_getSz(cv::_InputArray *ia, interop::Size *returnValue)
{
    return cvTry([&] {
        *returnValue = c(ia->getSz());
    });
}

CVAPI(ExceptionStatus) core_InputArray_kind(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->kind();
    });
}
CVAPI(ExceptionStatus) core_InputArray_dims(cv::_InputArray *ia, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->dims(i);
    });
}
CVAPI(ExceptionStatus) core_InputArray_cols(cv::_InputArray *ia, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->cols(i);
    });
}
CVAPI(ExceptionStatus) core_InputArray_rows(cv::_InputArray *ia, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->rows(i);
    });
}

CVAPI(ExceptionStatus) core_InputArray_size(cv::_InputArray *ia, int i, interop::Size *returnValue)
{
    return cvTry([&] {
        *returnValue = c(ia->size(i));
    });
}

CVAPI(ExceptionStatus) core_InputArray_sizend(cv::_InputArray *ia, int* sz, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->sizend(sz, i);
    });
}

CVAPI(ExceptionStatus) core_InputArray_sameSize(cv::_InputArray *self, cv::_InputArray * target, int *returnValue)
{
    return cvTry([&] {
        *returnValue = self->sameSize(*target) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_InputArray_total(cv::_InputArray *ia, int i, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->total(i);
    });
}
CVAPI(ExceptionStatus) core_InputArray_type(cv::_InputArray *ia, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->type(i);
    });
}
CVAPI(ExceptionStatus) core_InputArray_depth(cv::_InputArray *ia, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->depth(i);
    });
}
CVAPI(ExceptionStatus) core_InputArray_channels(cv::_InputArray *ia, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->channels(i);
    });
}

CVAPI(ExceptionStatus) core_InputArray_isContinuous(cv::_InputArray *ia, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->isContinuous(i) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_InputArray_isSubmatrix(cv::_InputArray *ia, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->isSubmatrix(i) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_InputArray_empty(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->empty() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) core_InputArray_copyTo1(cv::_InputArray *ia, cv::_OutputArray *arr)
{
    return cvTry([&] {
        ia->copyTo(*arr);
    });
}
CVAPI(ExceptionStatus) core_InputArray_copyTo2(cv::_InputArray *ia, cv::_OutputArray *arr, cv::_InputArray *mask)
{
    return cvTry([&] {
        ia->copyTo(*arr, *mask);
    });
}

CVAPI(ExceptionStatus) core_InputArray_offset(cv::_InputArray *ia, int i, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->offset(i);
    });
}
CVAPI(ExceptionStatus) core_InputArray_step(cv::_InputArray *ia, int i, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->step(i);
    });
}
CVAPI(ExceptionStatus) core_InputArray_isMat(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->isMat() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_InputArray_isUMat(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->isUMat() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_InputArray_isMatVector(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->isMatVector() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_InputArray_isUMatVector(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->isUMatVector() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_InputArray_isMatx(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->isMatx() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_InputArray_isVector(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->isVector() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) core_InputArray_isGpuMatVector(cv::_InputArray *ia, int *returnValue)
{
    return cvTry([&] {
        *returnValue = ia->isGpuMatVector() ? 1 : 0;
    });
}
