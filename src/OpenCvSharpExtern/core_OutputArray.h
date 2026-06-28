#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(ExceptionStatus) core_OutputArray_new_byMat(cv::Mat *mat, cv::_OutputArray **returnValue)
{
    return cvTry([&] {
    const cv::_OutputArray ia(*mat);
    *returnValue = new cv::_OutputArray(ia);
    });
}

/*CVAPI(cv::_OutputArray*) core_OutputArray_new_byGpuMat(cv::cuda::GpuMat *gm)
{
    cv::_OutputArray ia(*gm);
    return new cv::_OutputArray(ia);
}*/

CVAPI(ExceptionStatus) core_OutputArray_new_byUMat(cv::UMat* mat, cv::_OutputArray** returnValue)
{
    return cvTry([&] {
        const cv::_OutputArray ia(*mat);
    *returnValue = new cv::_OutputArray(ia);
    });
}

CVAPI(ExceptionStatus) core_OutputArray_new_byScalar(interop::Scalar scalar, cv::_OutputArray **returnValue)
{
    return cvTry([&] {
    cv::Scalar scalarVal(cpp(scalar));
    const cv::_OutputArray ia(scalarVal);
    *returnValue = new cv::_OutputArray(ia);
    });
}

CVAPI(ExceptionStatus) core_OutputArray_new_byVectorOfMat(std::vector<cv::Mat> *vector, cv::_OutputArray **returnValue)
{
    return cvTry([&] {
    const cv::_OutputArray ia(*vector);
    *returnValue = new cv::_OutputArray(ia);
    });
}

CVAPI(ExceptionStatus) core_OutputArray_delete(cv::_OutputArray *oa)
{
    return cvTry([&] {
    delete oa;
    });
}

CVAPI(ExceptionStatus) core_OutputArray_getMat(cv::_OutputArray *oa, cv::Mat **returnValue)
{
    return cvTry([&] {
    auto& mat = oa->getMatRef();
    *returnValue = new cv::Mat(mat);
    });
}

CVAPI(ExceptionStatus) core_OutputArray_getScalar(cv::_OutputArray *oa, interop::Scalar *returnValue)
{
    return cvTry([&] {
    cv::Mat &mat = oa->getMatRef();
    const auto scalar = mat.at<cv::Scalar>(0);
    *returnValue = c(scalar);
    });
}

CVAPI(ExceptionStatus) core_OutputArray_getVectorOfMat(cv::_OutputArray *oa, std::vector<cv::Mat*> *vector)
{
    return cvTry([&] {
    std::vector<cv::Mat> temp;
    oa->getMatVector(temp);

    vector->resize(temp.size());
    for (size_t i = 0; i < temp.size(); i++)
    {
        (*vector)[i] = new cv::Mat(temp[i]);
    }
    });
}
