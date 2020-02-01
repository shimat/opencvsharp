#ifndef _CPP_FLANN_INDEXPARAMS_H_
#define _CPP_FLANN_INDEXPARAMS_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


// cv::flann::IndexParams

CVAPI(ExceptionStatus) flann_Ptr_IndexParams_new(cv::Ptr<cv::flann::IndexParams> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::flann::IndexParams>(new cv::flann::IndexParams);
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_IndexParams_get(
    cv::Ptr<cv::flann::IndexParams> *ptr, cv::flann::IndexParams **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_IndexParams_delete(cv::Ptr<cv::flann::IndexParams> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) flann_IndexParams_getString(
    cv::flann::IndexParams *obj, const char *key, const char *defaultVal, std::string *returnValue)
{
    BEGIN_WRAP
    returnValue->assign(obj->getString(key, defaultVal));
    END_WRAP
}
CVAPI(ExceptionStatus) flann_IndexParams_getInt(cv::flann::IndexParams* obj, const char* key, int defaultVal, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getInt(key, defaultVal);
    END_WRAP
}
CVAPI(ExceptionStatus) flann_IndexParams_getDouble(cv::flann::IndexParams* obj, const char* key, double defaultVal, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDouble(key, defaultVal);
    END_WRAP
}

CVAPI(ExceptionStatus) flann_IndexParams_setString(cv::flann::IndexParams* obj, const char* key, const char* value)
{
    BEGIN_WRAP
    obj->setString(key, value);
    END_WRAP
}
CVAPI(ExceptionStatus) flann_IndexParams_setInt(cv::flann::IndexParams* obj, const char* key, int value)
{
    BEGIN_WRAP
    obj->setInt(key, value);
    END_WRAP
}
CVAPI(ExceptionStatus) flann_IndexParams_setDouble(cv::flann::IndexParams* obj, const char* key, double value)
{
    BEGIN_WRAP
    obj->setDouble(key, value);
    END_WRAP
}
CVAPI(ExceptionStatus) flann_IndexParams_setFloat(cv::flann::IndexParams* obj, const char* key, float value)
{
    BEGIN_WRAP
    obj->setFloat(key, value);
    END_WRAP
}
CVAPI(ExceptionStatus) flann_IndexParams_setBool(cv::flann::IndexParams* obj, const char* key, int value)
{
    BEGIN_WRAP
    obj->setBool(key, (value != 0));
    END_WRAP
}
CVAPI(ExceptionStatus) flann_IndexParams_setAlgorithm(cv::flann::IndexParams* obj, int value)
{
    BEGIN_WRAP
    obj->setAlgorithm(value);
    END_WRAP
}


// cv::flann::LinearIndexParams

CVAPI(ExceptionStatus) flann_Ptr_LinearIndexParams_new(cv::Ptr<cv::flann::LinearIndexParams> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::flann::LinearIndexParams>(new cv::flann::LinearIndexParams);
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_LinearIndexParams_get(
    cv::Ptr<cv::flann::LinearIndexParams> *ptr, cv::flann::LinearIndexParams **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_LinearIndexParams_delete(cv::Ptr<cv::flann::LinearIndexParams> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


// cv::flann::KDTreeIndexParams

CVAPI(ExceptionStatus) flann_Ptr_KDTreeIndexParams_new(int trees, cv::Ptr<cv::flann::KDTreeIndexParams> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::flann::KDTreeIndexParams>(new cv::flann::KDTreeIndexParams(trees));
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_KDTreeIndexParams_get(
    cv::Ptr<cv::flann::KDTreeIndexParams> *ptr, cv::flann::KDTreeIndexParams **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_KDTreeIndexParams_delete(cv::Ptr<cv::flann::KDTreeIndexParams> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


// cv::flann::KMeansIndexParams

CVAPI(ExceptionStatus) flann_Ptr_KMeansIndexParams_new(
    int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index, cv::Ptr<cv::flann::KMeansIndexParams> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::flann::KMeansIndexParams>(new cv::flann::KMeansIndexParams(branching, iterations, centers_init, cb_index));
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_KMeansIndexParams_get(
    cv::Ptr<cv::flann::KMeansIndexParams> *ptr, cv::flann::KMeansIndexParams **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_KMeansIndexParams_delete(cv::Ptr<cv::flann::KMeansIndexParams> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


// cv::flann::LshIndexParams

CVAPI(ExceptionStatus) flann_Ptr_LshIndexParams_new(
    int table_number, int key_size, int multi_probe_level, cv::Ptr<cv::flann::LshIndexParams> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::flann::LshIndexParams>(new cv::flann::LshIndexParams(table_number, key_size, multi_probe_level));
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_LshIndexParams_get(
    cv::Ptr<cv::flann::LshIndexParams> *ptr, cv::flann::LshIndexParams **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_LshIndexParams_delete(cv::Ptr<cv::flann::LshIndexParams> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


// cv::flann::CompositeIndexParams

CVAPI(ExceptionStatus) flann_Ptr_CompositeIndexParams_new(
    int trees, int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index, cv::Ptr<cv::flann::CompositeIndexParams> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::flann::CompositeIndexParams>(new cv::flann::CompositeIndexParams(trees, branching, iterations, centers_init, cb_index));
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_CompositeIndexParams_get(
    cv::Ptr<cv::flann::CompositeIndexParams> *ptr, cv::flann::CompositeIndexParams **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_CompositeIndexParams_delete(cv::Ptr<cv::flann::CompositeIndexParams> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


// cv::flann::AutotunedIndexParams

CVAPI(ExceptionStatus) flann_Ptr_AutotunedIndexParams_new(
    float target_precision, float build_weight, float memory_weight, float sample_fraction, cv::Ptr<cv::flann::AutotunedIndexParams> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::flann::AutotunedIndexParams>(new cv::flann::AutotunedIndexParams(target_precision, build_weight, memory_weight, sample_fraction));
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_AutotunedIndexParams_get(
    cv::Ptr<cv::flann::AutotunedIndexParams> *ptr, cv::flann::AutotunedIndexParams **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_AutotunedIndexParams_delete(cv::Ptr<cv::flann::AutotunedIndexParams> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


// cv::flann::SavedIndexParams

CVAPI(ExceptionStatus) flann_Ptr_SavedIndexParams_new(const char* filename, cv::Ptr<cv::flann::SavedIndexParams> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::flann::SavedIndexParams>(new cv::flann::SavedIndexParams(filename));
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_SavedIndexParams_get(
    cv::Ptr<cv::flann::SavedIndexParams> *ptr, cv::flann::SavedIndexParams **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_SavedIndexParams_delete(cv::Ptr<cv::flann::SavedIndexParams> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}


// cv::flann::SearchParams

CVAPI(ExceptionStatus) flann_Ptr_SearchParams_new(int checks, float eps, int sorted, cv::Ptr<cv::flann::SearchParams> **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Ptr<cv::flann::SearchParams>(new cv::flann::SearchParams(checks, eps, (sorted != 0)));
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_SearchParams_get(
    cv::Ptr<cv::flann::SearchParams> *ptr, cv::flann::SearchParams **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) flann_Ptr_SearchParams_delete(cv::Ptr<cv::flann::SearchParams> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

#endif