#ifndef _CPP_CORE_OUTPUTARRAY_H_
#define _CPP_CORE_OUTPUTARRAY_H_

#include "include_opencv.h"

CVAPI(cv::_OutputArray*) core_OutputArray_new_byMat(cv::Mat *mat)
{
	cv::_OutputArray ia(*mat);
	return new cv::_OutputArray(ia);
}

CVAPI(cv::_OutputArray*) core_OutputArray_new_byGpuMat(cv::cuda::GpuMat *gm)
{
	cv::_OutputArray ia(*gm);
	return new cv::_OutputArray(ia);
}

CVAPI(cv::_OutputArray*) core_OutputArray_new_byScalar(MyCvScalar scalar)
{
    cv::Scalar scalarVal(cpp(scalar));
    cv::_OutputArray ia(scalarVal);
    return new cv::_OutputArray(ia);
}

CVAPI(void) core_OutputArray_delete(cv::_OutputArray *oa)
{
	delete oa;
}

CVAPI(cv::Mat*) core_OutputArray_getMat(cv::_OutputArray *oa)
{
	cv::Mat &mat = oa->getMatRef();
	return new cv::Mat(mat);
}

CVAPI(MyCvScalar) core_OutputArray_getScalar(cv::_OutputArray *oa)
{
    cv::Mat &mat = oa->getMatRef();
    cv::Scalar scalar = mat.at<cv::Scalar>(0);
    return c(scalar);
}

#endif