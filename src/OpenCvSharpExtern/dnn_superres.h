#pragma once

#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_new1(
    cv::dnn_superres::DnnSuperResImpl** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn_superres::DnnSuperResImpl;
    END_WRAP
}
CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_new2(
    const char* algo, int scale, cv::dnn_superres::DnnSuperResImpl** returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::dnn_superres::DnnSuperResImpl(algo, scale);
    END_WRAP
}


CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_delete(cv::dnn_superres::DnnSuperResImpl* obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_readModel1(
    cv::dnn_superres::DnnSuperResImpl* obj, const char *path)
{
    BEGIN_WRAP
    obj->readModel(path);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_readModel2(
    cv::dnn_superres::DnnSuperResImpl* obj, const char* weights, const char *definition)
{
    BEGIN_WRAP
    obj->readModel(weights, definition);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_setModel(
    cv::dnn_superres::DnnSuperResImpl* obj, const char* algo, int scale)
{
    BEGIN_WRAP
    obj->setModel(algo, scale);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_setPreferableBackend(
    cv::dnn_superres::DnnSuperResImpl* obj, int backendId)
{
    BEGIN_WRAP
    obj->setPreferableBackend(backendId);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_setPreferableTarget(
    cv::dnn_superres::DnnSuperResImpl* obj, int targetId)
{
    BEGIN_WRAP
    obj->setPreferableTarget(targetId);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_upsample(
    cv::dnn_superres::DnnSuperResImpl* obj, cv::_InputArray *img, cv::_OutputArray *result)
{
    BEGIN_WRAP
    obj->upsample(*img, *result);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_upsampleMultioutput(
    cv::dnn_superres::DnnSuperResImpl* obj, cv::_InputArray *img, std::vector<cv::Mat> *imgs_new, 
    const int* scale_factors, int scale_factors_size,
    const char **node_names, int node_names_size)
{
    BEGIN_WRAP

    const std::vector<int> scale_factors_vec(scale_factors, scale_factors + scale_factors_size);
    std::vector<cv::String> node_names_vec(node_names_size);
    for (int i = 0; i < node_names_size; i++)
    {
        node_names_vec[i].assign(cv::String(node_names[i]));
    }

    obj->upsampleMultioutput(*img, *imgs_new, scale_factors_vec, node_names_vec);
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_getScale(
    cv::dnn_superres::DnnSuperResImpl* obj, int* returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getScale();
    END_WRAP
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_getAlgorithm(
    cv::dnn_superres::DnnSuperResImpl* obj, std::string* returnValue)
{
    BEGIN_WRAP
    returnValue->assign(obj->getAlgorithm());
    END_WRAP
}

#endif
