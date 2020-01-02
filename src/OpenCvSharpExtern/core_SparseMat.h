#ifndef _CPP_CORE_SPARSEMAT_H_
#define _CPP_CORE_SPARSEMAT_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_SparseMat_new1(cv::SparseMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::SparseMat;
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_new2(int dims, const int *sizes, int type, cv::SparseMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::SparseMat(dims, sizes, type);
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_new3(cv::Mat *m, cv::SparseMat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::SparseMat(*m);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_delete(cv::SparseMat *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


CVAPI(ExceptionStatus) core_SparseMat_operatorAssign_SparseMat(cv::SparseMat *obj, cv::SparseMat *m)
{
    BEGIN_WRAP
    *obj = *m;
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_operatorAssign_Mat(cv::SparseMat *obj, cv::Mat *m)
{
    BEGIN_WRAP
    *obj = *m;
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_clone(cv::SparseMat *obj, cv::SparseMat **returnValue)
{
    BEGIN_WRAP
    const auto sm = obj->clone();
    *returnValue = new cv::SparseMat(sm);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_copyTo_SparseMat(cv::SparseMat *obj, cv::SparseMat *m)
{
    BEGIN_WRAP
    obj->copyTo(*m);
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_copyTo_Mat(cv::SparseMat *obj, cv::Mat *m)
{
    BEGIN_WRAP
    obj->copyTo(*m);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_convertTo_SparseMat(cv::SparseMat *obj, cv::SparseMat *m, int rtype, double alpha)
{
    BEGIN_WRAP
    obj->convertTo(*m, rtype, alpha);
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_convertTo_Mat(cv::SparseMat *obj, cv::Mat *m, int rtype, double alpha = 1, double beta = 0)
{
    BEGIN_WRAP
    obj->convertTo(*m, rtype, alpha, beta);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_assignTo(cv::SparseMat *obj, cv::SparseMat *m, int type = -1)
{
    BEGIN_WRAP
    obj->assignTo(*m, type);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_create(cv::SparseMat *obj, int dims, const int* sizes, int type)
{
    BEGIN_WRAP
    obj->create(dims, sizes, type);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_clear(cv::SparseMat *obj)
{
    BEGIN_WRAP
    obj->clear();
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_addref(cv::SparseMat *obj)
{
    BEGIN_WRAP
    obj->addref();
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_release(cv::SparseMat *obj)
{
    BEGIN_WRAP
    obj->release();
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_elemSize(cv::SparseMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->elemSize());
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_elemSize1(cv::SparseMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->elemSize1());
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_type(cv::SparseMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->type();
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_depth(cv::SparseMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->depth();
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_channels(cv::SparseMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->channels();
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_size1(cv::SparseMat *obj, const int **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->size();
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_size2(cv::SparseMat *obj, int i, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->size(i);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_dims(cv::SparseMat *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->dims();
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_nzcount(cv::SparseMat *obj, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->nzcount();
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_hash_1d(cv::SparseMat *obj, int i0, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->hash(i0);
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_hash_2d(cv::SparseMat *obj, int i0, int i1, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->hash(i0, i1);
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_hash_3d(cv::SparseMat *obj, int i0, int i1, int i2, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->hash(i0, i1, i2);
    END_WRAP
}
CVAPI(ExceptionStatus) core_SparseMat_hash_nd(cv::SparseMat *obj, const int* idx, size_t *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->hash(idx);
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_ptr_1d(cv::SparseMat *obj, int i0, int createMissing, uint64* hashVal, uchar **returnValue)
{
    BEGIN_WRAP
    if (hashVal == nullptr)
    {
        *returnValue = obj->ptr(i0, createMissing != 0);
    }else
    {
        auto hashVal0 = static_cast<size_t>(*hashVal);
        *returnValue = obj->ptr(i0, createMissing != 0, &hashVal0);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_ptr_2d(cv::SparseMat *obj, int i0, int i1, int createMissing, uint64* hashVal, uchar **returnValue)
{
    BEGIN_WRAP
    if (hashVal == nullptr)
    {
        *returnValue = obj->ptr(i0, i1, createMissing != 0);
    }
    else
    {
        auto hashVal0 = static_cast<size_t>(*hashVal);
        *returnValue = obj->ptr(i0, i1, createMissing != 0, &hashVal0);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_ptr_3d(cv::SparseMat *obj, int i0, int i1, int i2, int createMissing, uint64* hashVal, uchar **returnValue)
{
    BEGIN_WRAP
    if (hashVal == nullptr)
    {
        *returnValue = obj->ptr(i0, i1, i2, createMissing != 0);
    }
    else
    {
        auto hashVal0 = static_cast<size_t>(*hashVal);
        *returnValue = obj->ptr(i0, i1, i2, createMissing != 0, &hashVal0);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) core_SparseMat_ptr_nd(cv::SparseMat *obj, const int* idx, int createMissing, uint64* hashVal, uchar **returnValue)
{
    BEGIN_WRAP
    if (hashVal == nullptr)
    {
        *returnValue = obj->ptr(idx, createMissing != 0);
    }
    else
    {
        auto hashVal0 = static_cast<size_t>(*hashVal);
        *returnValue = obj->ptr(idx, createMissing != 0, &hashVal0);
    }
    END_WRAP
}

#endif