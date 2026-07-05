#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_LDA_new1(int num_components, cv::LDA **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::LDA(num_components);
    });
}

CVAPI(ExceptionStatus) core_LDA_new2(
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* labels,
    int num_components,
    cv::LDA **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::LDA(InProxy(*src), InProxy(*labels), num_components);
    });
}

CVAPI(ExceptionStatus) core_LDA_delete(cv::LDA *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) core_LDA_save_String(cv::LDA *obj, const char *filename)
{
    return cvTry([&] {
        obj->save(filename);
    });
}

CVAPI(ExceptionStatus) core_LDA_load_String(cv::LDA *obj, const char *filename)
{
    return cvTry([&] {
        obj->load(filename);
    });
}

CVAPI(ExceptionStatus) core_LDA_save_FileStorage(cv::LDA *obj, cv::FileStorage *fs)
{
    return cvTry([&] {
        obj->save(*fs);
    });
}

CVAPI(ExceptionStatus) core_LDA_load_FileStorage(cv::LDA *obj, cv::FileStorage *node)
{
    return cvTry([&] {
        obj->load(*node);
    });
}

CVAPI(ExceptionStatus) core_LDA_compute(
    cv::LDA *obj,
    const interop::InputArrayProxy* src,
    const interop::InputArrayProxy* labels)
{
    return cvTry([&] {
        obj->compute(InProxy(*src), InProxy(*labels));
    });
}

CVAPI(ExceptionStatus) core_LDA_project(
    cv::LDA *obj,
    const interop::InputArrayProxy* src,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto mat = obj->project(InProxy(*src));
        *returnValue = new cv::Mat(mat);
    });
}

CVAPI(ExceptionStatus) core_LDA_reconstruct(
    cv::LDA *obj,
    const interop::InputArrayProxy* src,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto mat = obj->reconstruct(InProxy(*src));
        *returnValue = new cv::Mat(mat);
    });
}

CVAPI(ExceptionStatus) core_LDA_eigenvectors(cv::LDA *obj, cv::Mat **returnValue)
{ 
    return cvTry([&] {
        const auto mat = obj->eigenvectors();
        *returnValue = new cv::Mat(mat);
    });
}

CVAPI(ExceptionStatus) core_LDA_eigenvalues(cv::LDA *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto mat = obj->eigenvalues();
        *returnValue = new cv::Mat(mat);
    });
}

CVAPI(ExceptionStatus) core_LDA_subspaceProject(
    const interop::InputArrayProxy* W,
    const interop::InputArrayProxy* mean,
    const interop::InputArrayProxy* src,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto mat = cv::LDA::subspaceProject(InProxy(*W), InProxy(*mean), InProxy(*src));
        *returnValue = new cv::Mat(mat);
    });
}
CVAPI(ExceptionStatus) core_LDA_subspaceReconstruct(
    const interop::InputArrayProxy* W,
    const interop::InputArrayProxy* mean,
    const interop::InputArrayProxy* src,
    cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto mat = cv::LDA::subspaceReconstruct(InProxy(*W), InProxy(*mean), InProxy(*src));
        *returnValue = new cv::Mat(mat);
    });
}
