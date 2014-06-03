#ifndef _CPP_CORE_SPARSEMAT_H_
#define _CPP_CORE_SPARSEMAT_H_

#include "include_opencv.h"

CVAPI(uint64) core_SparseMat_sizeof()
{
	return sizeof(cv::SparseMat);
}

CVAPI(cv::SparseMat*) core_SparseMat_new1()
{
	return new cv::SparseMat();
}
CVAPI(cv::SparseMat*) core_SparseMat_new2(int dims, const int *sizes, int type)
{
	return new cv::SparseMat(dims, sizes, type);
}
CVAPI(cv::SparseMat*) core_SparseMat_new3(cv::Mat *m)
{
	return new cv::SparseMat(*m);
}
CVAPI(cv::SparseMat*) core_SparseMat_new4(const CvSparseMat* m)
{
	return new cv::SparseMat(m);
}

CVAPI(void) core_SparseMat_delete(cv::SparseMat *obj)
{
	delete obj;
}


CVAPI(void) core_SparseMat_operatorAssign_SparseMat(cv::SparseMat *obj, cv::SparseMat *m)
{
	*obj = *m;
}
CVAPI(void) core_SparseMat_operatorAssign_Mat(cv::SparseMat *obj, cv::Mat *m)
{
	*obj = *m;
}

CVAPI(cv::SparseMat*) core_SparseMat_clone(cv::SparseMat *obj)
{
	cv::SparseMat sm = obj->clone();
	return new cv::SparseMat(sm);
}
CVAPI(void) core_SparseMat_copyTo_SparseMat(cv::SparseMat *obj, cv::SparseMat *m)
{
	obj->copyTo(*m);
}
CVAPI(void) core_SparseMat_copyTo_Mat(cv::SparseMat *obj, cv::Mat *m)
{
	obj->copyTo(*m);
}
CVAPI(void) core_SparseMat_convertTo_SparseMat(cv::SparseMat *obj, cv::SparseMat *m, int rtype, double alpha)
{
	obj->convertTo(*m, rtype, alpha);
}
CVAPI(void) core_SparseMat_convertTo_Mat(cv::SparseMat *obj, cv::Mat *m, int rtype, double alpha = 1, double beta = 0)
{
	obj->convertTo(*m, rtype, alpha, beta);
}
CVAPI(void) core_SparseMat_assignTo(cv::SparseMat *obj, cv::SparseMat *m, int type = -1)
{
	obj->assignTo(*m, type);
}

CVAPI(void) core_SparseMat_create(cv::SparseMat *obj, int dims, const int* sizes, int type)
{
	obj->create(dims, sizes, type);
}
CVAPI(void) core_SparseMat_clear(cv::SparseMat *obj)
{
	obj->clear();
}
CVAPI(void) core_SparseMat_addref(cv::SparseMat *obj)
{
	obj->addref();
}
CVAPI(void) core_SparseMat_release(cv::SparseMat *obj)
{
	obj->release();
}

CVAPI(CvSparseMat*) core_SparseMat_operator_CvSparseMat(cv::SparseMat *obj)
{
	return (CvSparseMat*)(*obj);
}

CVAPI(int) core_SparseMat_elemSize(cv::SparseMat *obj)
{
	return static_cast<int>(obj->elemSize());
}
CVAPI(int) core_SparseMat_elemSize1(cv::SparseMat *obj)
{
	return static_cast<int>(obj->elemSize1());
}

CVAPI(int) core_SparseMat_type(cv::SparseMat *obj)
{
	return obj->type();
}
CVAPI(int) core_SparseMat_depth(cv::SparseMat *obj)
{
	return obj->depth();
}
CVAPI(int) core_SparseMat_channels(cv::SparseMat *obj)
{
	return obj->channels();
}

CVAPI(const int*) core_SparseMat_size1(cv::SparseMat *obj)
{
	return obj->size();
}
CVAPI(int) core_SparseMat_size2(cv::SparseMat *obj, int i)
{
	return obj->size(i);
}
CVAPI(int) core_SparseMat_dims(cv::SparseMat *obj)
{
	return obj->dims();
}
CVAPI(size_t) core_SparseMat_nzcount(cv::SparseMat *obj)
{
	return obj->nzcount();
}

CVAPI(size_t) core_SparseMat_hash_1d(cv::SparseMat *obj, int i0)
{
	return obj->hash(i0);
}
CVAPI(size_t) core_SparseMat_hash_2d(cv::SparseMat *obj, int i0, int i1)
{
	return obj->hash(i0, i1);
}
CVAPI(size_t) core_SparseMat_hash_3d(cv::SparseMat *obj, int i0, int i1, int i2)
{
	return obj->hash(i0, i1, i2);
}
CVAPI(size_t) core_SparseMat_hash_nd(cv::SparseMat *obj, const int* idx)
{
	return obj->hash(idx);
}

CVAPI(uchar*) core_SparseMat_ptr_1d(cv::SparseMat *obj, int i0, int createMissing, uint64* hashval)
{
    if (hashval == NULL)
        return obj->ptr(i0, createMissing != 0);    
    size_t hashval0 = static_cast<size_t>(*hashval);
	return obj->ptr(i0, createMissing != 0, &hashval0);
}
CVAPI(uchar*) core_SparseMat_ptr_2d(cv::SparseMat *obj, int i0, int i1, int createMissing, uint64* hashval)
{
	if (hashval == NULL)
        return obj->ptr(i0, i1, createMissing != 0);    
    size_t hashval0 = static_cast<size_t>(*hashval);
	return obj->ptr(i0, i1, createMissing != 0, &hashval0);
}
CVAPI(uchar*) core_SparseMat_ptr_3d(cv::SparseMat *obj, int i0, int i1, int i2, int createMissing, uint64* hashval)
{
	if (hashval == NULL)
        return obj->ptr(i0, i1, i2, createMissing != 0);    
    size_t hashval0 = static_cast<size_t>(*hashval);
	return obj->ptr(i0, i1, i2, createMissing != 0, &hashval0);
}
CVAPI(uchar*) core_SparseMat_ptr_nd(cv::SparseMat *obj, const int* idx, int createMissing, uint64* hashval)
{
	if (hashval == NULL)
        return obj->ptr(idx, createMissing != 0);    
    size_t hashval0 = static_cast<size_t>(*hashval);
	return obj->ptr(idx, createMissing != 0, &hashval0);
}

#endif