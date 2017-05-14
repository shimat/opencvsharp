#ifndef _CPP_FLANN_INDEXPARAMS_H_
#define _CPP_FLANN_INDEXPARAMS_H_

#include "include_opencv.h"


// cv::flann::IndexParams
CVAPI(cv::flann::IndexParams*) flann_IndexParams_new()
{
    return new cv::flann::IndexParams;
}
CVAPI(void) flann_IndexParams_delete(cv::flann::IndexParams *obj)
{
    delete obj;
}

CVAPI(cv::Ptr<cv::flann::IndexParams>*) flann_Ptr_IndexParams_new()
{
    return new cv::Ptr<cv::flann::IndexParams>(new cv::flann::IndexParams);
}
CVAPI(cv::flann::IndexParams*) flann_Ptr_IndexParams_get(
    cv::Ptr<cv::flann::IndexParams> *ptr)
{
    return ptr->get();
}
CVAPI(void) flann_Ptr_IndexParams_delete(cv::Ptr<cv::flann::IndexParams> *obj)
{
    delete obj;
}

CVAPI(void) flann_IndexParams_getString(cv::flann::IndexParams *obj, const char *key, const char *defaultVal, char *result)
{
    std::string defaultVal_;
    if (defaultVal == NULL)
        defaultVal_ = std::string(key);
    else
        defaultVal_ = std::string();
    std::string result_ = obj->getString(key, defaultVal_);
    std::strcpy(result, result_.c_str());
}
CVAPI(int) flann_IndexParams_getInt(cv::flann::IndexParams* obj, const char* key, int defaultVal)
{
    return obj->getInt(key, defaultVal);
}
CVAPI(double) flann_IndexParams_getDouble(cv::flann::IndexParams* obj, const char* key, double defaultVal)
{
    return obj->getDouble(key, defaultVal);
}

CVAPI(void) flann_IndexParams_setString(cv::flann::IndexParams* obj, const char* key, const char* value)
{
    obj->setString(key, value);
}
CVAPI(void) flann_IndexParams_setInt(cv::flann::IndexParams* obj, const char* key, int value)
{
    obj->setInt(key, value);
}
CVAPI(void) flann_IndexParams_setDouble(cv::flann::IndexParams* obj, const char* key, double value)
{
    obj->setDouble(key, value);
}
CVAPI(void) flann_IndexParams_setFloat(cv::flann::IndexParams* obj, const char* key, float value)
{
    obj->setFloat(key, value);
}
CVAPI(void) flann_IndexParams_setBool(cv::flann::IndexParams* obj, const char* key, int value)
{
    obj->setBool(key, (value != 0));
}
CVAPI(void) flann_IndexParams_setAlgorithm(cv::flann::IndexParams* obj, int value)
{
    obj->setAlgorithm(value);
}


// cv::flann::LinearIndexParams
CVAPI(cv::flann::LinearIndexParams*) flann_LinearIndexParams_new()
{
    return new cv::flann::LinearIndexParams();
}
CVAPI(void) flann_LinearIndexParams_delete(cv::flann::LinearIndexParams* obj)
{
    delete obj;
}
CVAPI(cv::Ptr<cv::flann::LinearIndexParams>*) flann_Ptr_LinearIndexParams_new()
{
    return new cv::Ptr<cv::flann::LinearIndexParams>(new cv::flann::LinearIndexParams);
}
CVAPI(cv::flann::LinearIndexParams*) flann_Ptr_LinearIndexParams_get(
    cv::Ptr<cv::flann::LinearIndexParams> *ptr)
{
    return ptr->get();
}
CVAPI(void) flann_Ptr_LinearIndexParams_delete(cv::Ptr<cv::flann::LinearIndexParams> *obj)
{
    delete obj;
}

// cv::flann::KDTreeIndexParams
CVAPI(cv::flann::KDTreeIndexParams*) flann_KDTreeIndexParams_new(int trees)
{
    return new cv::flann::KDTreeIndexParams(trees);
}
CVAPI(void) flann_KDTreeIndexParams_delete(cv::flann::KDTreeIndexParams* obj)
{
    delete obj;
}
CVAPI(cv::Ptr<cv::flann::KDTreeIndexParams>*) flann_Ptr_KDTreeIndexParams_new(int trees)
{
    return new cv::Ptr<cv::flann::KDTreeIndexParams>(new cv::flann::KDTreeIndexParams(trees));
}
CVAPI(cv::flann::KDTreeIndexParams*) flann_Ptr_KDTreeIndexParams_get(
    cv::Ptr<cv::flann::KDTreeIndexParams> *ptr)
{
    return ptr->get();
}
CVAPI(void) flann_Ptr_KDTreeIndexParams_delete(cv::Ptr<cv::flann::KDTreeIndexParams> *obj)
{
    delete obj;
}

// cv::flann::KMeansIndexParams
CVAPI(cv::flann::KMeansIndexParams*) flann_KMeansIndexParams_new(int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index)
{
    return new cv::flann::KMeansIndexParams(branching, iterations, centers_init, cb_index);
}
CVAPI(void) flann_KMeansIndexParams_delete(cv::flann::KMeansIndexParams* obj)
{
    delete obj;
}
CVAPI(cv::Ptr<cv::flann::KMeansIndexParams>*) flann_Ptr_KMeansIndexParams_new(int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index)
{
    return new cv::Ptr<cv::flann::KMeansIndexParams>(new cv::flann::KMeansIndexParams(branching, iterations, centers_init, cb_index));
}
CVAPI(cv::flann::KMeansIndexParams*) flann_Ptr_KMeansIndexParams_get(
    cv::Ptr<cv::flann::KMeansIndexParams> *ptr)
{
    return ptr->get();
}
CVAPI(void) flann_Ptr_KMeansIndexParams_delete(cv::Ptr<cv::flann::KMeansIndexParams> *obj)
{
    delete obj;
}

// cv::flann::LshIndexParams
CVAPI(cv::flann::LshIndexParams*) flann_LshIndexParams_new(int table_number, int key_size, int multi_probe_level)
{
    return new cv::flann::LshIndexParams(table_number, key_size, multi_probe_level);
}
CVAPI(void) flann_LshIndexParams_delete(cv::flann::LshIndexParams* obj)
{
    delete obj;
}
CVAPI(cv::Ptr<cv::flann::LshIndexParams>*) flann_Ptr_LshIndexParams_new(int table_number, int key_size, int multi_probe_level)
{
    return new cv::Ptr<cv::flann::LshIndexParams>(new cv::flann::LshIndexParams(table_number, key_size, multi_probe_level));
}
CVAPI(cv::flann::LshIndexParams*) flann_Ptr_LshIndexParams_get(
    cv::Ptr<cv::flann::LshIndexParams> *ptr)
{
    return ptr->get();
}
CVAPI(void) flann_Ptr_LshIndexParams_delete(cv::Ptr<cv::flann::LshIndexParams> *obj)
{
    delete obj;
}

// cv::flann::CompositeIndexParams
CVAPI(cv::flann::CompositeIndexParams*) flann_CompositeIndexParams_new(int trees, int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index)
{
    return new cv::flann::CompositeIndexParams(trees, branching, iterations, centers_init, cb_index);
}
CVAPI(void) flann_CompositeIndexParams_delete(cv::flann::CompositeIndexParams* obj)
{
    delete obj;
}
CVAPI(cv::Ptr<cv::flann::CompositeIndexParams>*) flann_Ptr_CompositeIndexParams_new(int trees, int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index)
{
    return new cv::Ptr<cv::flann::CompositeIndexParams>(new cv::flann::CompositeIndexParams(trees, branching, iterations, centers_init, cb_index));
}
CVAPI(cv::flann::CompositeIndexParams*) flann_Ptr_CompositeIndexParams_get(
    cv::Ptr<cv::flann::CompositeIndexParams> *ptr)
{
    return ptr->get();
}
CVAPI(void) flann_Ptr_CompositeIndexParams_delete(cv::Ptr<cv::flann::CompositeIndexParams> *obj)
{
    delete obj;
}

// cv::flann::AutotunedIndexParams
CVAPI(cv::flann::AutotunedIndexParams*) flann_AutotunedIndexParams_new(float target_precision, float build_weight, float memory_weight, float sample_fraction)
{
    return new cv::flann::AutotunedIndexParams(target_precision, build_weight, memory_weight, sample_fraction);
}
CVAPI(void) flann_AutotunedIndexParams_delete(cv::flann::AutotunedIndexParams* obj)
{
    delete obj;
}
CVAPI(cv::Ptr<cv::flann::AutotunedIndexParams>*) flann_Ptr_AutotunedIndexParams_new(float target_precision, float build_weight, float memory_weight, float sample_fraction)
{
    return new cv::Ptr<cv::flann::AutotunedIndexParams>(new cv::flann::AutotunedIndexParams(target_precision, build_weight, memory_weight, sample_fraction));
}
CVAPI(cv::flann::AutotunedIndexParams*) flann_Ptr_AutotunedIndexParams_get(
    cv::Ptr<cv::flann::AutotunedIndexParams> *ptr)
{
    return ptr->get();
}
CVAPI(void) flann_Ptr_AutotunedIndexParams_delete(cv::Ptr<cv::flann::AutotunedIndexParams> *obj)
{
    delete obj;
}

// cv::flann::SavedIndexParams
CVAPI(cv::flann::SavedIndexParams*) flann_SavedIndexParams_new(const char* filename)
{
    return new cv::flann::SavedIndexParams(filename);
}
CVAPI(void) flann_SavedIndexParams_delete(cv::flann::SavedIndexParams* obj)
{
    delete obj;
}
CVAPI(cv::Ptr<cv::flann::SavedIndexParams>*) flann_Ptr_SavedIndexParams_new(const char* filename)
{
    return new cv::Ptr<cv::flann::SavedIndexParams>(new cv::flann::SavedIndexParams(filename));
}
CVAPI(cv::flann::SavedIndexParams*) flann_Ptr_SavedIndexParams_get(
    cv::Ptr<cv::flann::SavedIndexParams> *ptr)
{
    return ptr->get();
}
CVAPI(void) flann_Ptr_SavedIndexParams_delete(cv::Ptr<cv::flann::SavedIndexParams> *obj)
{
    delete obj;
}

// cv::flann::SearchParams
CVAPI(cv::flann::SearchParams*) flann_SearchParams_new(int checks, float eps, int sorted)
{
    return new cv::flann::SearchParams(checks, eps, (sorted != 0));
}
CVAPI(void) flann_SearchParams_delete(cv::flann::SearchParams* obj)
{
    delete obj;
}
CVAPI(cv::Ptr<cv::flann::SearchParams>*) flann_Ptr_SearchParams_new(int checks, float eps, int sorted)
{
    return new cv::Ptr<cv::flann::SearchParams>(new cv::flann::SearchParams(checks, eps, (sorted != 0)));
}
CVAPI(cv::flann::SearchParams*) flann_Ptr_SearchParams_get(
    cv::Ptr<cv::flann::SearchParams> *ptr)
{
    return ptr->get();
}
CVAPI(void) flann_Ptr_SearchParams_delete(cv::Ptr<cv::flann::SearchParams> *obj)
{
    delete obj;
}

#endif