#ifndef _CPP_CORE_INPUTARRAY_H_
#define _CPP_CORE_INPUTARRAY_H_

#include "include_opencv.h"

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(cv::_InputArray*) core_InputArray_new_byMat(cv::Mat *mat)
{
    return new cv::_InputArray(*mat);
}

CVAPI(cv::_InputArray*) core_InputArray_new_byMatExpr(cv::MatExpr *expr)
{
    return new cv::_InputArray(*expr);
}

CVAPI(cv::_InputArray*) core_InputArray_new_byScalar(MyCvScalar val)
{
	cv::Scalar scalar = cpp(val);
	return new cv::_InputArray(scalar);
}

CVAPI(cv::_InputArray*) core_InputArray_new_byDouble(double val)
{
    return new cv::_InputArray(val);
}

CVAPI(cv::_InputArray*) core_InputArray_new_byGpuMat(cv::cuda::GpuMat *gm)
{
    return new cv::_InputArray(*gm);
}

CVAPI(cv::_InputArray*) core_InputArray_new_byVectorOfMat(std::vector<cv::Mat> *vector)
{
    return new cv::_InputArray(*vector);
}

CVAPI(void) core_InputArray_delete(cv::_InputArray *ia)
{
    delete ia;
}

CVAPI(cv::Mat*) core_InputArray_getMat(cv::_InputArray *ia, int idx)
{
	return new cv::Mat(ia->getMat(idx));
}
CVAPI(cv::Mat*) core_InputArray_getMat_(cv::_InputArray *ia, int idx)
{
	return new cv::Mat(ia->getMat_(idx));
}
CVAPI(cv::UMat*) core_InputArray_getUMat(cv::_InputArray *ia, int idx)
{
	return new cv::UMat(ia->getUMat(idx));
}
CVAPI(void) core_InputArray_getMatVector(cv::_InputArray *ia, std::vector<cv::Mat> *mv)
{
	ia->getMatVector(*mv);
}
CVAPI(void) core_InputArray_getUMatVector(cv::_InputArray *ia, std::vector<cv::UMat> *umv)
{
	ia->getUMatVector(*umv);
}
CVAPI(void) core_InputArray_getGpuMatVector(cv::_InputArray *ia, std::vector<cv::cuda::GpuMat> *gpumv)
{
	ia->getGpuMatVector(*gpumv);
}
CVAPI(cv::cuda::GpuMat*) core_InputArray_getGpuMat(cv::_InputArray *ia)
{
	return new cv::cuda::GpuMat(ia->getGpuMat());
}
//CVAPI(cv::ogl::Buffer*) core_InputArray_getOGlBuffer(cv::_InputArray *ia)
//{
//	return new cv::ogl::Buffer(ia->getOGlBuffer());
//}

CVAPI(int) core_InputArray_getFlags(cv::_InputArray *ia)
{
	return ia->getFlags();
}
CVAPI(void*) core_InputArray_getObj(cv::_InputArray *ia)
{
	return ia->getObj();
}
CVAPI(MyCvSize) core_InputArray_getSz(cv::_InputArray *ia)
{
	return c(ia->getSz());
}

CVAPI(int) core_InputArray_kind(cv::_InputArray *ia)
{
	return ia->kind();
}
CVAPI(int) core_InputArray_dims(cv::_InputArray *ia, int i)
{
	return ia->dims(i);
}
CVAPI(int) core_InputArray_cols(cv::_InputArray *ia, int i)
{
	return ia->cols();
}
CVAPI(int) core_InputArray_rows(cv::_InputArray *ia, int i)
{
	return ia->rows();
}
CVAPI(MyCvSize) core_InputArray_size(cv::_InputArray *ia, int i)
{
	return c(ia->size(i));
}
CVAPI(int) core_InputArray_sizend(cv::_InputArray *ia, int* sz, int i)
{
	return ia->sizend(sz, i);
}
CVAPI(int) core_InputArray_sameSize(cv::_InputArray *self, cv::_InputArray * target)
{
	return self->sameSize(*target) ? 1 : 0;
}
CVAPI(size_t) core_InputArray_total(cv::_InputArray *ia, int i)
{
	return ia->total(i);
}
CVAPI(int) core_InputArray_type(cv::_InputArray *ia, int i)
{
	return ia->type(i);
}
CVAPI(int) core_InputArray_depth(cv::_InputArray *ia, int i)
{
	return ia->depth(i);
}
CVAPI(int) core_InputArray_channels(cv::_InputArray *ia, int i)
{
	return ia->channels(i);
}
CVAPI(int) core_InputArray_isContinuous(cv::_InputArray *ia, int i)
{
	return ia->isContinuous(i) ? 1 : 0;
}
CVAPI(int) core_InputArray_isSubmatrix(cv::_InputArray *ia, int i)
{
	return ia->isSubmatrix(i) ? 1 : 0;
}
CVAPI(int) core_InputArray_empty(cv::_InputArray *ia)
{
	return ia->empty() ? 1 : 0;
}
CVAPI(void) core_InputArray_copyTo1(cv::_InputArray *ia, cv::_OutputArray *arr)
{
	ia->copyTo(*arr);
}
CVAPI(void) core_InputArray_copyTo2(cv::_InputArray *ia, cv::_OutputArray *arr, cv::_InputArray *mask)
{
	ia->copyTo(*arr, *mask);
}
CVAPI(size_t) core_InputArray_offset(cv::_InputArray *ia, int i)
{
	return ia->offset(i);
}
CVAPI(size_t) core_InputArray_step(cv::_InputArray *ia, int i)
{
	return ia->step(i);
}
CVAPI(int) core_InputArray_isMat(cv::_InputArray *ia)
{
	return ia->isMat() ? 1 : 0;
}
CVAPI(int) core_InputArray_isUMat(cv::_InputArray *ia)
{
	return ia->isUMat() ? 1 : 0;
}
CVAPI(int) core_InputArray_isMatVector(cv::_InputArray *ia)
{
	return ia->isMatVector() ? 1 : 0;
}
CVAPI(int) core_InputArray_isUMatVector(cv::_InputArray *ia)
{
	return ia->isUMatVector() ? 1 : 0;
}
CVAPI(int) core_InputArray_isMatx(cv::_InputArray *ia)
{
	return ia->isMatx() ? 1 : 0;
}
CVAPI(int) core_InputArray_isVector(cv::_InputArray *ia)
{
	return ia->isVector() ? 1 : 0;
}
CVAPI(int) core_InputArray_isGpuMatVector(cv::_InputArray *ia)
{
	return ia->isGpuMatVector() ? 1 : 0;
}

#endif