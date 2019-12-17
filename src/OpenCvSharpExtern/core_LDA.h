#ifndef _CPP_CORE_LDA_H_
#define _CPP_CORE_LDA_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_LDA_new1(int num_components, cv::LDA **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::LDA(num_components);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_new2(cv::_InputArray *src, cv::_InputArray *labels, int num_components, cv::LDA **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::LDA(*src, *labels, num_components);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_delete(cv::LDA *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_save_String(cv::LDA *obj, const char *filename)
{
    BEGIN_WRAP
    obj->save(filename);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_load_String(cv::LDA *obj, const char *filename)
{
    BEGIN_WRAP
    obj->load(filename);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_save_FileStorage(cv::LDA *obj, cv::FileStorage *fs)
{
    BEGIN_WRAP
    obj->save(*fs);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_load_FileStorage(cv::LDA *obj, cv::FileStorage *node)
{
    BEGIN_WRAP
    obj->load(*node);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_compute(cv::LDA *obj, cv::_InputArray *src, cv::_InputArray *labels)
{
    BEGIN_WRAP
    obj->compute(*src, *labels);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_project(cv::LDA *obj, cv::_InputArray *src, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = obj->project(*src);
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_reconstruct(cv::LDA *obj, cv::_InputArray *src, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = obj->reconstruct(*src);
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_eigenvectors(cv::LDA *obj, cv::Mat **returnValue)
{ 
    BEGIN_WRAP
    const auto mat = obj->eigenvectors();
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_eigenvalues(cv::LDA *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = obj->eigenvalues();
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

CVAPI(ExceptionStatus) core_LDA_subspaceProject(cv::_InputArray *W, cv::_InputArray *mean, cv::_InputArray *src, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = cv::LDA::subspaceProject(*W, *mean, *src);
    *returnValue = new cv::Mat(mat);
    END_WRAP
}
CVAPI(ExceptionStatus) core_LDA_subspaceReconstruct(cv::_InputArray *W, cv::_InputArray *mean, cv::_InputArray *src, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto mat = cv::LDA::subspaceReconstruct(*W, *mean, *src);
    *returnValue = new cv::Mat(mat);
    END_WRAP
}

#endif