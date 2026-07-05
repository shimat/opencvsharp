#pragma once

#include "include_opencv.h"

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

CVAPI(ExceptionStatus) core_PCA_new1(cv::PCA **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::PCA;
    });
}
CVAPI(ExceptionStatus) core_PCA_new2(
    const interop::InputArrayProxy* data,
    const interop::InputArrayProxy* mean,
    int flags,
    int maxComponents,
    cv::PCA **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::PCA(InProxy(*data), InProxy(*mean), flags, maxComponents);
    });
}
CVAPI(ExceptionStatus) core_PCA_new3(
    const interop::InputArrayProxy* data,
    const interop::InputArrayProxy* mean,
    int flags,
    double retainedVariance,
    cv::PCA **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::PCA(InProxy(*data), InProxy(*mean), flags, retainedVariance);
    });
}

CVAPI(ExceptionStatus) core_PCA_delete(cv::PCA *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

//! operator that performs PCA. The previously stored data, if any, is released
CVAPI(ExceptionStatus) core_PCA_operatorThis(
    cv::PCA *obj,
    const interop::InputArrayProxy* data,
    const interop::InputArrayProxy* mean,
    int flags,
    int maxComponents)
{
    return cvTry([&] {
        (*obj)(InProxy(*data), InProxy(*mean), flags, maxComponents);
    });
}

CVAPI(ExceptionStatus) core_PCA_computeVar(
    cv::PCA *obj,
    const interop::InputArrayProxy* data,
    const interop::InputArrayProxy* mean,
    int flags,
    double retainedVariance)
{
    return cvTry([&] {
        (*obj)(InProxy(*data), InProxy(*mean), flags, retainedVariance);
    });
}

//! projects vector from the original space to the principal components subspace
CVAPI(ExceptionStatus) core_PCA_project1(
    cv::PCA *obj,
    const interop::InputArrayProxy* vec,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto ret = obj->project(InProxy(*vec));
        *returnValue = new cv::Mat(ret);
    });
}

//! projects vector from the original space to the principal components subspace
CVAPI(ExceptionStatus) core_PCA_project2(
    cv::PCA *obj,
    const interop::InputArrayProxy* vec,
    const interop::OutputArrayProxy* result)
{
    return cvTry([&] {
        obj->project(InProxy(*vec), OutProxy(*result));
    });
}

//! reconstructs the original vector from the projection
CVAPI(ExceptionStatus) core_PCA_backProject1(
    cv::PCA *obj,
    const interop::InputArrayProxy* vec,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto ret = obj->backProject(InProxy(*vec));
        *returnValue = new cv::Mat(ret);
    });
}

//! reconstructs the original vector from the projection
CVAPI(ExceptionStatus) core_PCA_backProject2(
    cv::PCA *obj,
    const interop::InputArrayProxy* vec,
    const interop::OutputArrayProxy* result)
{
    return cvTry([&] {
        obj->backProject(InProxy(*vec), OutProxy(*result));
    });
}

//!< eigenvectors of the covariation matrix
CVAPI(ExceptionStatus) core_PCA_eigenvectors(cv::PCA *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->eigenvectors);
    });
}

//!< eigenvalues of the covariation matrix
CVAPI(ExceptionStatus) core_PCA_eigenvalues(cv::PCA *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->eigenvalues);
    });
}

//!< mean value subtracted before the projection and added after the back projection
CVAPI(ExceptionStatus) core_PCA_mean(cv::PCA *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->mean);
    });
}

CVAPI(ExceptionStatus) core_PCA_write(cv::PCA *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
        obj->write(*fs);
    });    
}

CVAPI(ExceptionStatus) core_PCA_read(cv::PCA *obj, cv::FileNode *fn)
{
    return cvTry([&] {
        obj->read(*fn);
    });
}
