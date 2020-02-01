#ifndef _CPP_CORE_PCA_H_
#define _CPP_CORE_PCA_H_

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_PCA_new1(cv::PCA **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::PCA;
    END_WRAP
}
CVAPI(ExceptionStatus) core_PCA_new2(cv::_InputArray *data, cv::_InputArray *mean, int flags, int maxComponents, cv::PCA **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::PCA(*data, *mean, flags, maxComponents);
    END_WRAP
}
CVAPI(ExceptionStatus) core_PCA_new3(cv::_InputArray *data, cv::_InputArray *mean, int flags, double retainedVariance, cv::PCA **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::PCA(*data, *mean, flags, retainedVariance);
    END_WRAP
}

CVAPI(ExceptionStatus) core_PCA_delete(cv::PCA *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

//! operator that performs PCA. The previously stored data, if any, is released
CVAPI(ExceptionStatus) core_PCA_operatorThis(cv::PCA *obj, cv::_InputArray *data, cv::_InputArray *mean, int flags, int maxComponents)
{
    BEGIN_WRAP
    (*obj)(*data, *mean, flags, maxComponents);
    END_WRAP
}

CVAPI(ExceptionStatus) core_PCA_computeVar(cv::PCA *obj, cv::_InputArray *data, cv::_InputArray *mean, int flags, double retainedVariance)
{
    BEGIN_WRAP
    (*obj)(*data, *mean, flags, retainedVariance);
    END_WRAP
}

//! projects vector from the original space to the principal components subspace
CVAPI(ExceptionStatus) core_PCA_project1(cv::PCA *obj, cv::_InputArray *vec, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->project(*vec);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

//! projects vector from the original space to the principal components subspace
CVAPI(ExceptionStatus) core_PCA_project2(cv::PCA *obj, cv::_InputArray *vec, cv::_OutputArray *result)
{
    BEGIN_WRAP
    obj->project(*vec, *result);
    END_WRAP
}

//! reconstructs the original vector from the projection
CVAPI(ExceptionStatus) core_PCA_backProject1(cv::PCA *obj, cv::_InputArray *vec, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto ret = obj->backProject(*vec);
    *returnValue = new cv::Mat(ret);
    END_WRAP
}

//! reconstructs the original vector from the projection
CVAPI(ExceptionStatus) core_PCA_backProject2(cv::PCA *obj, cv::_InputArray *vec, cv::_OutputArray *result)
{
    BEGIN_WRAP
    obj->backProject(*vec, *result);
    END_WRAP
}

//!< eigenvectors of the covariation matrix
CVAPI(ExceptionStatus) core_PCA_eigenvectors(cv::PCA *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->eigenvectors);
    END_WRAP
}

//!< eigenvalues of the covariation matrix
CVAPI(ExceptionStatus) core_PCA_eigenvalues(cv::PCA *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->eigenvalues);
    END_WRAP
}

//!< mean value subtracted before the projection and added after the back projection
CVAPI(ExceptionStatus) core_PCA_mean(cv::PCA *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Mat(obj->mean);
    END_WRAP
}

CVAPI(ExceptionStatus) core_PCA_write(cv::PCA *obj, cv::FileStorage *fs)
{
    BEGIN_WRAP
    obj->write(*fs);
    END_WRAP    
}

CVAPI(ExceptionStatus) core_PCA_read(cv::PCA *obj, cv::FileNode *fn)
{
    BEGIN_WRAP
    obj->read(*fn);
    END_WRAP
}

#endif