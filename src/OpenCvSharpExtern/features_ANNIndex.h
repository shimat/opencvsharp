#pragma once

#ifndef NO_FEATURES

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) features_ANNIndex_create(
    int dim,
    int distType,
    cv::Ptr<cv::ANNIndex> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::ANNIndex::create(dim, static_cast<cv::ANNIndex::Distance>(distType));
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) features_Ptr_ANNIndex_get(cv::Ptr<cv::ANNIndex> *ptr, cv::ANNIndex **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) features_Ptr_ANNIndex_delete(cv::Ptr<cv::ANNIndex> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) features_ANNIndex_addItems(cv::ANNIndex *obj, const interop::InputArrayProxy* features)
{
    return cvTry([&] {
    obj->addItems(InProxy(*features));
    });
}

CVAPI(ExceptionStatus) features_ANNIndex_build(cv::ANNIndex *obj, int trees)
{
    return cvTry([&] {
    obj->build(trees);
    });
}

CVAPI(ExceptionStatus) features_ANNIndex_knnSearch(
    cv::ANNIndex *obj,
    const interop::InputArrayProxy* query,
    const interop::OutputArrayProxy* indices,
    const interop::OutputArrayProxy* dists,
    int knn,
    int search_k)
{
    return cvTry([&] {
    obj->knnSearch(InProxy(*query), OutProxy(*indices), OutProxy(*dists), knn, search_k);
    });
}

CVAPI(ExceptionStatus) features_ANNIndex_save(
    cv::ANNIndex *obj,
    const char *filename,
    int prefault)
{
    return cvTry([&] {
    obj->save(cv::String(filename), prefault != 0);
    });
}

CVAPI(ExceptionStatus) features_ANNIndex_load(
    cv::ANNIndex *obj,
    const char *filename,
    int prefault)
{
    return cvTry([&] {
    obj->load(cv::String(filename), prefault != 0);
    });
}

CVAPI(ExceptionStatus) features_ANNIndex_getTreeNumber(cv::ANNIndex *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getTreeNumber();
    });
}

CVAPI(ExceptionStatus) features_ANNIndex_getItemNumber(cv::ANNIndex *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getItemNumber();
    });
}

CVAPI(ExceptionStatus) features_ANNIndex_setOnDiskBuild(
    cv::ANNIndex *obj,
    const char *filename,
    int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->setOnDiskBuild(cv::String(filename)) ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) features_ANNIndex_setSeed(cv::ANNIndex *obj, int seed)
{
    return cvTry([&] {
    obj->setSeed(seed);
    });
}

#endif // NO_FEATURES
