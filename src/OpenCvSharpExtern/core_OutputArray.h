#ifndef _CPP_CORE_OUTPUTARRAY_H_
#define _CPP_CORE_OUTPUTARRAY_H_

#include "include_opencv.h"

CVAPI(cv::_OutputArray*) core_OutputArray_new_byMat(cv::Mat *mat)
{
	cv::_OutputArray ia(*mat);
	return new cv::_OutputArray(ia);
}

CVAPI(cv::_OutputArray*) core_OutputArray_new_byGpuMat(cv::gpu::GpuMat *gm)
{
	cv::_OutputArray ia(*gm);
	return new cv::_OutputArray(ia);
}

CVAPI(cv::_OutputArray*) core_OutputArray_new_byScalar(CvScalar scalar)
{
    cv::Scalar scalarVal(scalar);
    cv::_OutputArray ia(scalarVal);
    return new cv::_OutputArray(ia);
}

CVAPI(cv::_OutputArray*) core_OutputArray_new_byVectorOfMat(std::vector<cv::Mat> *vector)
{
    cv::_OutputArray ia(*vector);
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

CVAPI(CvScalar) core_OutputArray_getScalar(cv::_OutputArray *oa)
{
    cv::Mat &mat = oa->getMatRef();
    cv::Scalar scalar = mat.at<cv::Scalar>(0);
    return scalar;
}

CVAPI(void) core_OutputArray_getVectorOfMat(cv::_OutputArray *oa, std::vector<cv::Mat*> *vector)
{
    std::vector<cv::Mat> temp;
    oa->getMatVector(temp);
    
    vector->resize(temp.size());
    for (size_t i = 0; i < temp.size(); i++)
    {
        (*vector)[i] = new cv::Mat(temp[i]);
    }
}


#endif