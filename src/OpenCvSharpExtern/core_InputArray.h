#ifndef _CPP_CORE_INPUTARRAY_H_
#define _CPP_CORE_INPUTARRAY_H_

#include "include_opencv.h"

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(ExceptionStatus) core_InputArray_new_byMat(cv::Mat *mat, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(*mat);
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_new_byMatExpr(cv::MatExpr *expr, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(*expr);
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_new_byScalar(MyCvScalar s, cv::Scalar **handle, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *handle = new cv::Scalar(s.val[0], s.val[1], s.val[2], s.val[3]);
    *returnValue = new cv::_InputArray(**handle);
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_new_byDouble(double *handle, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(*handle);
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_new_byVectorOfMat(std::vector<cv::Mat> *vector, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(*vector);
    END_WRAP
}

#pragma region new_byVec

CVAPI(ExceptionStatus) core_InputArray_new_byVecb(uchar *vec, int n, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(vec, n);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_new_byVecs(short *vec, int n, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(vec, n);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_new_byVecw(ushort *vec, int n, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(vec, n);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_new_byVeci(int *vec, int n, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(vec, n);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_new_byVecf(float *vec, int n, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(vec, n);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_new_byVecd(double *vec, int n, cv::_InputArray **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::_InputArray(vec, n);
    END_WRAP
}

#pragma endregion 

CVAPI(ExceptionStatus) core_InputArray_delete(cv::_InputArray *ia)
{
    BEGIN_WRAP
    delete ia;
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_delete_withScalar(cv::_InputArray *ia, cv::Scalar *handle)
{
    BEGIN_WRAP
    delete ia;
    delete handle;
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_getMat(cv::_InputArray *ia, int idx, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(ia->getMat(idx));
    END_WRAP
}
/*CVAPI(ExceptionStatus) core_InputArray_getMat_(cv::_InputArray *ia, int idx, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(ia->getMat_(idx));
    END_WRAP
}*/
/*CVAPI(cv::UMat*) core_InputArray_getUMat(cv::_InputArray *ia, int idx)
{
    return new cv::UMat(ia->getUMat(idx));
}*/
CVAPI(ExceptionStatus) core_InputArray_getMatVector(cv::_InputArray *ia, std::vector<cv::Mat> *mv)
{
    BEGIN_WRAP
    ia->getMatVector(*mv);
    END_WRAP
}
/*CVAPI(void) core_InputArray_getUMatVector(cv::_InputArray *ia, std::vector<cv::UMat> *umv)
{
    ia->getUMatVector(*umv);
}*/

CVAPI(ExceptionStatus) core_InputArray_getFlags(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->getFlags();
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_getObj(cv::_InputArray *ia, void **returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->getObj();
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_getSz(cv::_InputArray *ia, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(ia->getSz());
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_kind(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->kind();
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_dims(cv::_InputArray *ia, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->dims(i);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_cols(cv::_InputArray *ia, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->cols(i);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_rows(cv::_InputArray *ia, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->rows(i);
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_size(cv::_InputArray *ia, int i, MyCvSize *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(ia->size(i));
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_sizend(cv::_InputArray *ia, int* sz, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->sizend(sz, i);
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_sameSize(cv::_InputArray *self, cv::_InputArray * target, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = self->sameSize(*target) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_total(cv::_InputArray *ia, int i, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->total(i);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_type(cv::_InputArray *ia, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->type(i);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_depth(cv::_InputArray *ia, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->depth(i);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_channels(cv::_InputArray *ia, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->channels(i);
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_isContinuous(cv::_InputArray *ia, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->isContinuous(i) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_isSubmatrix(cv::_InputArray *ia, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->isSubmatrix(i) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_empty(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_copyTo1(cv::_InputArray *ia, cv::_OutputArray *arr)
{
    BEGIN_WRAP
    ia->copyTo(*arr);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_copyTo2(cv::_InputArray *ia, cv::_OutputArray *arr, cv::_InputArray *mask)
{
    BEGIN_WRAP
    ia->copyTo(*arr, *mask);
    END_WRAP
}

CVAPI(ExceptionStatus) core_InputArray_offset(cv::_InputArray *ia, int i, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->offset(i);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_step(cv::_InputArray *ia, int i, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->step(i);
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_isMat(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->isMat() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_isUMat(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->isUMat() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_isMatVector(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->isMatVector() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_isUMatVector(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->isUMatVector() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_isMatx(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->isMatx() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_isVector(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->isVector() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) core_InputArray_isGpuMatVector(cv::_InputArray *ia, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = ia->isGpuMatVector() ? 1 : 0;
    END_WRAP
}

#endif