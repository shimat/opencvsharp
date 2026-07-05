#pragma once

#ifndef NO_CONTRIB
#ifndef _WINRT_DLL

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_new1(cv::dnn_superres::DnnSuperResImpl** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn_superres::DnnSuperResImpl;
    });
}
CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_new2(
    const char* algo,
    int scale,
    cv::dnn_superres::DnnSuperResImpl** returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::dnn_superres::DnnSuperResImpl(algo, scale);
    });
}


CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_delete(cv::dnn_superres::DnnSuperResImpl* obj)
{
    return cvTry([&] {
        delete obj;
    });
}


CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_readModel1(cv::dnn_superres::DnnSuperResImpl* obj, const char *path)
{
    return cvTry([&] {
        obj->readModel(path);
    });
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_readModel2(
    cv::dnn_superres::DnnSuperResImpl* obj,
    const char* weights,
    const char *definition)
{
    return cvTry([&] {
        obj->readModel(weights, definition);
    });
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_setModel(
    cv::dnn_superres::DnnSuperResImpl* obj,
    const char* algo,
    int scale)
{
    return cvTry([&] {
        obj->setModel(algo, scale);
    });
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_setPreferableBackend(cv::dnn_superres::DnnSuperResImpl* obj, int backendId)
{
    return cvTry([&] {
        obj->setPreferableBackend(backendId);
    });
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_setPreferableTarget(cv::dnn_superres::DnnSuperResImpl* obj, int targetId)
{
    return cvTry([&] {
        obj->setPreferableTarget(targetId);
    });
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_upsample(
    cv::dnn_superres::DnnSuperResImpl* obj,
    const interop::InputArrayProxy* img,
    const interop::OutputArrayProxy* result)
{
    return cvTry([&] {
        obj->upsample(InProxy(*img), OutProxy(*result));
    });
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_upsampleMultioutput(
    cv::dnn_superres::DnnSuperResImpl* obj,
    const interop::InputArrayProxy* img,
    std::vector<cv::Mat> *imgs_new,
    const int* scale_factors,
    int scale_factors_size,
    const char **node_names,
    int node_names_size)
{
    return cvTry([&] {

        const std::vector<int> scale_factors_vec(scale_factors, scale_factors + scale_factors_size);
        std::vector<cv::String> node_names_vec(node_names_size);
        for (int i = 0; i < node_names_size; i++)
        {
            node_names_vec[i].assign(cv::String(node_names[i]));
        }

        obj->upsampleMultioutput(InProxy(*img), *imgs_new, scale_factors_vec, node_names_vec);
    });
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_getScale(cv::dnn_superres::DnnSuperResImpl* obj, int* returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getScale();
    });
}

CVAPI(ExceptionStatus) dnn_superres_DnnSuperResImpl_getAlgorithm(cv::dnn_superres::DnnSuperResImpl* obj, std::string* returnValue)
{
    return cvTry([&] {
        returnValue->assign(obj->getAlgorithm());
    });
}

#endif //!_WINRT_DLL
#endif //!NO_CONTRIB
