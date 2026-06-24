#pragma once

#ifndef NO_FEATURES

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) features_ANNIndex_create(int dim, int distType, cv::Ptr<cv::ANNIndex> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ANNIndex::create(dim, static_cast<cv::ANNIndex::Distance>(distType));
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) features_Ptr_ANNIndex_get(cv::Ptr<cv::ANNIndex> *ptr, cv::ANNIndex **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) features_Ptr_ANNIndex_delete(cv::Ptr<cv::ANNIndex> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) features_ANNIndex_addItems(cv::ANNIndex *obj, cv::_InputArray *features)
{
    BEGIN_WRAP
    obj->addItems(*features);
    END_WRAP
}

CVAPI(ExceptionStatus) features_ANNIndex_build(cv::ANNIndex *obj, int trees)
{
    BEGIN_WRAP
    obj->build(trees);
    END_WRAP
}

CVAPI(ExceptionStatus) features_ANNIndex_knnSearch(
    cv::ANNIndex *obj, cv::_InputArray *query, cv::_OutputArray *indices, cv::_OutputArray *dists, int knn, int search_k)
{
    BEGIN_WRAP
    obj->knnSearch(*query, *indices, *dists, knn, search_k);
    END_WRAP
}

CVAPI(ExceptionStatus) features_ANNIndex_save(cv::ANNIndex *obj, const char *filename, int prefault)
{
    BEGIN_WRAP
    obj->save(cv::String(filename), prefault != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features_ANNIndex_load(cv::ANNIndex *obj, const char *filename, int prefault)
{
    BEGIN_WRAP
    obj->load(cv::String(filename), prefault != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) features_ANNIndex_getTreeNumber(cv::ANNIndex *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getTreeNumber();
    END_WRAP
}

CVAPI(ExceptionStatus) features_ANNIndex_getItemNumber(cv::ANNIndex *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getItemNumber();
    END_WRAP
}

CVAPI(ExceptionStatus) features_ANNIndex_setOnDiskBuild(cv::ANNIndex *obj, const char *filename, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->setOnDiskBuild(cv::String(filename)) ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) features_ANNIndex_setSeed(cv::ANNIndex *obj, int seed)
{
    BEGIN_WRAP
    obj->setSeed(seed);
    END_WRAP
}

#endif // NO_FEATURES
