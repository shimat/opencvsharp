#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_SparseMat_new1(cv::SparseMat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::SparseMat;
    });
}
CVAPI(ExceptionStatus) core_SparseMat_new2(int dims, const int *sizes, int type, cv::SparseMat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::SparseMat(dims, sizes, type);
    });
}
CVAPI(ExceptionStatus) core_SparseMat_new3(cv::Mat *m, cv::SparseMat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::SparseMat(*m);
    });
}

CVAPI(ExceptionStatus) core_SparseMat_delete(cv::SparseMat *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


CVAPI(ExceptionStatus) core_SparseMat_operatorAssign_SparseMat(cv::SparseMat *obj, cv::SparseMat *m)
{
    return cvTry([&] {
        *obj = *m;
    });
}
CVAPI(ExceptionStatus) core_SparseMat_operatorAssign_Mat(cv::SparseMat *obj, cv::Mat *m)
{
    return cvTry([&] {
        *obj = *m;
    });
}

CVAPI(ExceptionStatus) core_SparseMat_clone(cv::SparseMat *obj, cv::SparseMat **returnValue)
{
    return cvTry([&] {
        const auto sm = obj->clone();
        *returnValue = new cv::SparseMat(sm);
    });
}

CVAPI(ExceptionStatus) core_SparseMat_copyTo_SparseMat(cv::SparseMat *obj, cv::SparseMat *m)
{
    return cvTry([&] {
        obj->copyTo(*m);
    });
}
CVAPI(ExceptionStatus) core_SparseMat_copyTo_Mat(cv::SparseMat *obj, cv::Mat *m)
{
    return cvTry([&] {
        obj->copyTo(*m);
    });
}

CVAPI(ExceptionStatus) core_SparseMat_convertTo_SparseMat(cv::SparseMat *obj, cv::SparseMat *m, int rtype, double alpha)
{
    return cvTry([&] {
        obj->convertTo(*m, rtype, alpha);
    });
}
CVAPI(ExceptionStatus) core_SparseMat_convertTo_Mat(cv::SparseMat *obj, cv::Mat *m, int rtype, double alpha = 1, double beta = 0)
{
    return cvTry([&] {
        obj->convertTo(*m, rtype, alpha, beta);
    });
}

CVAPI(ExceptionStatus) core_SparseMat_assignTo(cv::SparseMat *obj, cv::SparseMat *m, int type = -1)
{
    return cvTry([&] {
        obj->assignTo(*m, type);
    });
}

CVAPI(ExceptionStatus) core_SparseMat_create(cv::SparseMat *obj, int dims, const int* sizes, int type)
{
    return cvTry([&] {
        obj->create(dims, sizes, type);
    });
}

CVAPI(ExceptionStatus) core_SparseMat_clear(cv::SparseMat *obj)
{
    return cvTry([&] {
        obj->clear();
    });
}

CVAPI(ExceptionStatus) core_SparseMat_addref(cv::SparseMat *obj)
{
    return cvTry([&] {
        obj->addref();
    });
}

CVAPI(ExceptionStatus) core_SparseMat_release(cv::SparseMat *obj)
{
    return cvTry([&] {
        obj->release();
    });
}

CVAPI(ExceptionStatus) core_SparseMat_elemSize(cv::SparseMat *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->elemSize());
    });
}
CVAPI(ExceptionStatus) core_SparseMat_elemSize1(cv::SparseMat *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->elemSize1());
    });
}

CVAPI(ExceptionStatus) core_SparseMat_type(cv::SparseMat *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->type();
    });
}

CVAPI(ExceptionStatus) core_SparseMat_depth(cv::SparseMat *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->depth();
    });
}

CVAPI(ExceptionStatus) core_SparseMat_channels(cv::SparseMat *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->channels();
    });
}

CVAPI(ExceptionStatus) core_SparseMat_size1(cv::SparseMat *obj, const int **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->size();
    });
}
CVAPI(ExceptionStatus) core_SparseMat_size2(cv::SparseMat *obj, int i, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->size(i);
    });
}

CVAPI(ExceptionStatus) core_SparseMat_dims(cv::SparseMat *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->dims();
    });
}

CVAPI(ExceptionStatus) core_SparseMat_nzcount(cv::SparseMat *obj, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->nzcount();
    });
}

CVAPI(ExceptionStatus) core_SparseMat_hash_1d(cv::SparseMat *obj, int i0, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->hash(i0);
    });
}
CVAPI(ExceptionStatus) core_SparseMat_hash_2d(cv::SparseMat *obj, int i0, int i1, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->hash(i0, i1);
    });
}
CVAPI(ExceptionStatus) core_SparseMat_hash_3d(cv::SparseMat *obj, int i0, int i1, int i2, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->hash(i0, i1, i2);
    });
}
CVAPI(ExceptionStatus) core_SparseMat_hash_nd(cv::SparseMat *obj, const int* idx, size_t *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->hash(idx);
    });
}

CVAPI(ExceptionStatus) core_SparseMat_ptr_1d(cv::SparseMat *obj, int i0, int createMissing, uint64* hashVal, uchar **returnValue)
{
    return cvTry([&] {
        if (hashVal == nullptr)
        {
            *returnValue = obj->ptr(i0, createMissing != 0);
        }else
        {
            auto hashVal0 = static_cast<size_t>(*hashVal);
            *returnValue = obj->ptr(i0, createMissing != 0, &hashVal0);
        }
    });
}

CVAPI(ExceptionStatus) core_SparseMat_ptr_2d(cv::SparseMat *obj, int i0, int i1, int createMissing, uint64* hashVal, uchar **returnValue)
{
    return cvTry([&] {
        if (hashVal == nullptr)
        {
            *returnValue = obj->ptr(i0, i1, createMissing != 0);
        }
        else
        {
            auto hashVal0 = static_cast<size_t>(*hashVal);
            *returnValue = obj->ptr(i0, i1, createMissing != 0, &hashVal0);
        }
    });
}

CVAPI(ExceptionStatus) core_SparseMat_ptr_3d(cv::SparseMat *obj, int i0, int i1, int i2, int createMissing, uint64* hashVal, uchar **returnValue)
{
    return cvTry([&] {
        if (hashVal == nullptr)
        {
            *returnValue = obj->ptr(i0, i1, i2, createMissing != 0);
        }
        else
        {
            auto hashVal0 = static_cast<size_t>(*hashVal);
            *returnValue = obj->ptr(i0, i1, i2, createMissing != 0, &hashVal0);
        }
    });
}

CVAPI(ExceptionStatus) core_SparseMat_ptr_nd(cv::SparseMat *obj, const int* idx, int createMissing, uint64* hashVal, uchar **returnValue)
{
    return cvTry([&] {
        if (hashVal == nullptr)
        {
            *returnValue = obj->ptr(idx, createMissing != 0);
        }
        else
        {
            auto hashVal0 = static_cast<size_t>(*hashVal);
            *returnValue = obj->ptr(idx, createMissing != 0, &hashVal0);
        }
    });
}

// Copies the indices and values of every stored (non-zero) element into caller-provided buffers.
// outIndices must hold nzcount()*dims ints, outValues must hold nzcount()*elemSize bytes.
CVAPI(ExceptionStatus) core_SparseMat_getNodes(cv::SparseMat *obj, int dims, int *outIndices, uchar *outValues, size_t elemSize)
{
    return cvTry([&] {
        const cv::SparseMat *cobj = obj;
        cv::SparseMatConstIterator it = cobj->begin();
        cv::SparseMatConstIterator it_end = cobj->end();
        for (int i = 0; it != it_end; ++it, ++i)
        {
            const cv::SparseMat::Node *node = it.node();
            for (int d = 0; d < dims; d++)
                outIndices[static_cast<size_t>(i) * dims + d] = node->idx[d];
            std::memcpy(outValues + static_cast<size_t>(i) * elemSize, it.ptr, elemSize);
        }
    });
}

// Removes the stored element at idx (no-op if absent). idx has length dims.
CVAPI(ExceptionStatus) core_SparseMat_erase_nd(cv::SparseMat *obj, const int *idx, uint64 *hashVal)
{
    return cvTry([&] {
        if (hashVal == nullptr)
        {
            obj->erase(idx);
        }
        else
        {
            auto hashVal0 = static_cast<size_t>(*hashVal);
            obj->erase(idx, &hashVal0);
        }
    });
}
