#pragma once

#ifndef NO_FLANN

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


// cv::flann::IndexParams

CVAPI(ExceptionStatus) flann_Ptr_IndexParams_new(cv::Ptr<cv::flann::IndexParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::IndexParams>(new cv::flann::IndexParams);
    });
}

CVAPI(ExceptionStatus) flann_Ptr_IndexParams_get(
    cv::Ptr<cv::flann::IndexParams> *ptr, cv::flann::IndexParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_IndexParams_delete(cv::Ptr<cv::flann::IndexParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) flann_IndexParams_getString(
    cv::flann::IndexParams *obj, const char *key, const char *defaultVal, std::string *returnValue)
{
    return cvTry([&] {
        returnValue->assign(obj->getString(key, defaultVal));
    });
}
CVAPI(ExceptionStatus) flann_IndexParams_getInt(cv::flann::IndexParams* obj, const char* key, int defaultVal, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getInt(key, defaultVal);
    });
}
CVAPI(ExceptionStatus) flann_IndexParams_getDouble(cv::flann::IndexParams* obj, const char* key, double defaultVal, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getDouble(key, defaultVal);
    });
}

CVAPI(ExceptionStatus) flann_IndexParams_setString(cv::flann::IndexParams* obj, const char* key, const char* value)
{
    return cvTry([&] {
        obj->setString(key, value);
    });
}
CVAPI(ExceptionStatus) flann_IndexParams_setInt(cv::flann::IndexParams* obj, const char* key, int value)
{
    return cvTry([&] {
        obj->setInt(key, value);
    });
}
CVAPI(ExceptionStatus) flann_IndexParams_setDouble(cv::flann::IndexParams* obj, const char* key, double value)
{
    return cvTry([&] {
        obj->setDouble(key, value);
    });
}
CVAPI(ExceptionStatus) flann_IndexParams_setFloat(cv::flann::IndexParams* obj, const char* key, float value)
{
    return cvTry([&] {
        obj->setFloat(key, value);
    });
}
CVAPI(ExceptionStatus) flann_IndexParams_setBool(cv::flann::IndexParams* obj, const char* key, int value)
{
    return cvTry([&] {
        obj->setBool(key, (value != 0));
    });
}
CVAPI(ExceptionStatus) flann_IndexParams_setAlgorithm(cv::flann::IndexParams* obj, int value)
{
    return cvTry([&] {
        obj->setAlgorithm(value);
    });
}


// cv::flann::LinearIndexParams

CVAPI(ExceptionStatus) flann_Ptr_LinearIndexParams_new(cv::Ptr<cv::flann::LinearIndexParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::LinearIndexParams>(new cv::flann::LinearIndexParams);
    });
}

CVAPI(ExceptionStatus) flann_Ptr_LinearIndexParams_get(
    cv::Ptr<cv::flann::LinearIndexParams> *ptr, cv::flann::LinearIndexParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_LinearIndexParams_delete(cv::Ptr<cv::flann::LinearIndexParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// cv::flann::KDTreeIndexParams

CVAPI(ExceptionStatus) flann_Ptr_KDTreeIndexParams_new(int trees, cv::Ptr<cv::flann::KDTreeIndexParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::KDTreeIndexParams>(new cv::flann::KDTreeIndexParams(trees));
    });
}

CVAPI(ExceptionStatus) flann_Ptr_KDTreeIndexParams_get(
    cv::Ptr<cv::flann::KDTreeIndexParams> *ptr, cv::flann::KDTreeIndexParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_KDTreeIndexParams_delete(cv::Ptr<cv::flann::KDTreeIndexParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// cv::flann::KMeansIndexParams

CVAPI(ExceptionStatus) flann_Ptr_KMeansIndexParams_new(
    int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index, cv::Ptr<cv::flann::KMeansIndexParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::KMeansIndexParams>(new cv::flann::KMeansIndexParams(branching, iterations, centers_init, cb_index));
    });
}

CVAPI(ExceptionStatus) flann_Ptr_KMeansIndexParams_get(
    cv::Ptr<cv::flann::KMeansIndexParams> *ptr, cv::flann::KMeansIndexParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_KMeansIndexParams_delete(cv::Ptr<cv::flann::KMeansIndexParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// cv::flann::HierarchicalClusteringIndexParams

CVAPI(ExceptionStatus) flann_Ptr_HierarchicalClusteringIndexParams_new(
    int branching, cvflann::flann_centers_init_t centers_init, int trees, int leaf_size,
    cv::Ptr<cv::flann::HierarchicalClusteringIndexParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::HierarchicalClusteringIndexParams>(
            new cv::flann::HierarchicalClusteringIndexParams(branching, centers_init, trees, leaf_size));
    });
}

CVAPI(ExceptionStatus) flann_Ptr_HierarchicalClusteringIndexParams_get(
    cv::Ptr<cv::flann::HierarchicalClusteringIndexParams> *ptr, cv::flann::HierarchicalClusteringIndexParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_HierarchicalClusteringIndexParams_delete(cv::Ptr<cv::flann::HierarchicalClusteringIndexParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// cv::flann::LshIndexParams

CVAPI(ExceptionStatus) flann_Ptr_LshIndexParams_new(
    int table_number, int key_size, int multi_probe_level, cv::Ptr<cv::flann::LshIndexParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::LshIndexParams>(new cv::flann::LshIndexParams(table_number, key_size, multi_probe_level));
    });
}

CVAPI(ExceptionStatus) flann_Ptr_LshIndexParams_get(
    cv::Ptr<cv::flann::LshIndexParams> *ptr, cv::flann::LshIndexParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_LshIndexParams_delete(cv::Ptr<cv::flann::LshIndexParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// cv::flann::CompositeIndexParams

CVAPI(ExceptionStatus) flann_Ptr_CompositeIndexParams_new(
    int trees, int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index, cv::Ptr<cv::flann::CompositeIndexParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::CompositeIndexParams>(new cv::flann::CompositeIndexParams(trees, branching, iterations, centers_init, cb_index));
    });
}

CVAPI(ExceptionStatus) flann_Ptr_CompositeIndexParams_get(
    cv::Ptr<cv::flann::CompositeIndexParams> *ptr, cv::flann::CompositeIndexParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_CompositeIndexParams_delete(cv::Ptr<cv::flann::CompositeIndexParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// cv::flann::AutotunedIndexParams

CVAPI(ExceptionStatus) flann_Ptr_AutotunedIndexParams_new(
    float target_precision, float build_weight, float memory_weight, float sample_fraction, cv::Ptr<cv::flann::AutotunedIndexParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::AutotunedIndexParams>(new cv::flann::AutotunedIndexParams(target_precision, build_weight, memory_weight, sample_fraction));
    });
}

CVAPI(ExceptionStatus) flann_Ptr_AutotunedIndexParams_get(
    cv::Ptr<cv::flann::AutotunedIndexParams> *ptr, cv::flann::AutotunedIndexParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_AutotunedIndexParams_delete(cv::Ptr<cv::flann::AutotunedIndexParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// cv::flann::SavedIndexParams

CVAPI(ExceptionStatus) flann_Ptr_SavedIndexParams_new(const char* filename, cv::Ptr<cv::flann::SavedIndexParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::SavedIndexParams>(new cv::flann::SavedIndexParams(filename));
    });
}

CVAPI(ExceptionStatus) flann_Ptr_SavedIndexParams_get(
    cv::Ptr<cv::flann::SavedIndexParams> *ptr, cv::flann::SavedIndexParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_SavedIndexParams_delete(cv::Ptr<cv::flann::SavedIndexParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}


// cv::flann::SearchParams

CVAPI(ExceptionStatus) flann_Ptr_SearchParams_new(int checks, float eps, int sorted, cv::Ptr<cv::flann::SearchParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::SearchParams>(new cv::flann::SearchParams(checks, eps, (sorted != 0)));
    });
}

CVAPI(ExceptionStatus) flann_Ptr_SearchParams_new2(
    int checks, float eps, int sorted, int explore_all_trees, cv::Ptr<cv::flann::SearchParams> **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Ptr<cv::flann::SearchParams>(
            new cv::flann::SearchParams(checks, eps, (sorted != 0), (explore_all_trees != 0)));
    });
}

CVAPI(ExceptionStatus) flann_Ptr_SearchParams_get(
    cv::Ptr<cv::flann::SearchParams> *ptr, cv::flann::SearchParams **returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) flann_Ptr_SearchParams_delete(cv::Ptr<cv::flann::SearchParams> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

#endif // NO_FLANN
