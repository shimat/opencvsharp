#ifndef _CPP_CORE_OUTPUTARRAY_H_
#define _CPP_CORE_OUTPUTARRAY_H_

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_OutputArray_new_byMat(cv::Mat *mat, cv::_OutputArray **returnValue)
{
    BEGIN_WRAP
    cv::_OutputArray ia(*mat);
    *returnValue = new cv::_OutputArray(ia);
    END_WRAP
}

/*CVAPI(cv::_OutputArray*) core_OutputArray_new_byGpuMat(cv::cuda::GpuMat *gm)
{
    cv::_OutputArray ia(*gm);
    return new cv::_OutputArray(ia);
}*/

CVAPI(ExceptionStatus) core_OutputArray_new_byScalar(MyCvScalar scalar, cv::_OutputArray **returnValue)
{
    BEGIN_WRAP
    cv::Scalar scalarVal(cpp(scalar));
    cv::_OutputArray ia(scalarVal);
    *returnValue = new cv::_OutputArray(ia);
    END_WRAP
}

CVAPI(ExceptionStatus) core_OutputArray_new_byVectorOfMat(std::vector<cv::Mat> *vector, cv::_OutputArray **returnValue)
{
    BEGIN_WRAP
    cv::_OutputArray ia(*vector);
    *returnValue = new cv::_OutputArray(ia);
    END_WRAP
}

CVAPI(ExceptionStatus) core_OutputArray_delete(cv::_OutputArray *oa)
{
    BEGIN_WRAP
    delete oa;
    END_WRAP
}

CVAPI(ExceptionStatus) core_OutputArray_getMat(cv::_OutputArray *oa, cv::Mat **returnValue)
{
    BEGIN_WRAP
    cv::Mat &mat = oa->getMatRef();
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) core_OutputArray_getScalar(cv::_OutputArray *oa, MyCvScalar *returnValue)
{
    BEGIN_WRAP
    cv::Mat &mat = oa->getMatRef();
    cv::Scalar scalar = mat.at<cv::Scalar>(0);
    *returnValue = c(scalar);
    END_WRAP
}

CVAPI(ExceptionStatus) core_OutputArray_getVectorOfMat(cv::_OutputArray *oa, std::vector<cv::Mat*> *vector)
{
    BEGIN_WRAP
    std::vector<cv::Mat> temp;
    oa->getMatVector(temp);

    vector->resize(temp.size());
    for (size_t i = 0; i < temp.size(); i++)
    {
        (*vector)[i] = new cv::Mat(temp[i]);
    }
    END_WRAP
}

#endif