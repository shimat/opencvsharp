/*
 * (C) 2008-2010 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CPP_WCVMAT_H_
#define _CPP_WCVMAT_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/opencv.hpp>

#pragma region Init & Disposal
CVAPI(int) MatND_sizeof()
{
	return sizeof(cv::MatND);
}

CVAPI(void) MatND_delete(cv::MatND* obj)
{
	delete obj;
}

CVAPI(cv::MatND*) MatND_new1()
{
	return new cv::MatND();
}
#pragma endregion

#pragma region Fields
CVAPI(int) MatND_flags_get(cv::MatND* src)
{
	return src->flags;
}
CVAPI(int) MatND_dims_get(cv::MatND* src)
{
	return src->dims;
}

CVAPI(int*) MatND_refcount_get(cv::MatND* src)
{
	return src->refcount;
}
CVAPI(uchar*) MatND_data_get(cv::MatND* src)
{
	return src->data;
}
CVAPI(uchar*) MatND_datastart_get(cv::MatND* src)
{
	return src->datastart;
}
CVAPI(uchar*) MatND_dataend_get(cv::MatND* src)
{
	return src->dataend;
}

// ‚Æ‚è‚ ‚¦‚¸]—ˆ‚Æ“¯‚¶Žè–@‚Å‚µ‚Ì‚®
CVAPI(int*) MatND_size_get(cv::MatND* src)
{
	return src->size.p;
}
CVAPI(size_t*) MatND_step_get(cv::MatND* src)
{
	return src->step.p;
}

#pragma endregion

#pragma region Operators
CVAPI(void) MatND_opRange(cv::MatND* src, const cv::Range* ranges, cv::MatND* dst)
{
	*dst = (*src)(ranges);
}

CVAPI(void) MatND_opMat(cv::MatND* src, cv::Mat* dst)
{
	*dst = (cv::Mat)(*src);
}
CVAPI(void) MatND_opCvMatND(cv::MatND* src, CvMatND* dst)
{
	*dst = (CvMatND)(*src);
}
#pragma endregion

#pragma region Methods
CVAPI(void) MatND_copyTo1(cv::MatND* src, cv::MatND* m)
{
	src->copyTo(*m);
}
CVAPI(void) MatND_copyTo2(cv::MatND* src, cv::MatND* m, cv::MatND* mask)
{
	src->copyTo(*m, *mask);
}

CVAPI(void) MatND_convertTo(cv::Mat* src, cv::Mat* m, int rtype, double alpha, double beta)
{
	src->convertTo(*m, rtype, alpha, beta);
}

CVAPI(void) MatND_setTo(cv::MatND* src, CvScalar s, cv::MatND* mask, cv::MatND* dst)
{
	if(mask == NULL)
		*dst = src->setTo(s, *mask);
	else
		*dst = src->setTo(s, *mask);
}

CVAPI(void) MatND_reshape(cv::MatND* src, int _newcn, int _newndims, const int* _newsz, cv::MatND* dst)
{
	*dst = src->reshape(_newcn, _newndims, _newsz);
}

CVAPI(uchar*) MatND_ptr1(cv::MatND* src, int i0)
{
	return src->ptr(i0);
}
CVAPI(uchar*) MatND_ptr2(cv::MatND* src, int i0, int i1)
{
	return src->ptr(i0, i1);
}
CVAPI(uchar*) MatND_ptr3(cv::MatND* src, int i0, int i1, int i2)
{
	return src->ptr(i0, i1, i2);
}
CVAPI(uchar*) MatND_ptr4(cv::MatND* src, const int* idx)
{
	return src->ptr(idx);
}

#pragma endregion

#endif