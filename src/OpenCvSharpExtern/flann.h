#ifndef _CPP_FLANN_H_
#define _CPP_FLANN_H_

#include "include_opencv.h"

// cv::flann::Index

CVAPI(cv::flann::Index*) flann_Index_new(
    cv::_InputArray *features, cv::flann::IndexParams* params, cvflann::flann_distance_t distType)
{
	return new cv::flann::Index(*features, *params, distType);
}
CVAPI(void) flann_Index_delete(cv::flann::Index* obj)
{
	delete obj;
}
CVAPI(void) flann_Index_knnSearch1(cv::flann::Index* obj, float* queries, int queries_length, int* indices, float* dists, int knn, cv::flann::SearchParams* params)
{
	std::vector<float> queries_vec(queries_length);
	std::vector<int> indices_vec(knn);
	std::vector<float> dists_vec(knn);
	memcpy(&queries_vec[0], queries, sizeof(float) * queries_length);
	obj->knnSearch(queries_vec, indices_vec, dists_vec, knn, *params);
	memcpy(indices, &indices_vec[0], sizeof(int) * knn);
	memcpy(dists, &dists_vec[0], sizeof(float) * knn);
}
CVAPI(void) flann_Index_knnSearch2(cv::flann::Index* obj, cv::Mat* queries, cv::Mat* indices, cv::Mat* dists, int knn, cv::flann::SearchParams* params)
{
	obj->knnSearch(*queries, *indices, *dists, knn, *params);
}
CVAPI(void) flann_Index_knnSearch3(cv::flann::Index* obj, cv::Mat* queries, int* indices, float* dists, int knn, cv::flann::SearchParams* params)
{
	cv::Mat indices_mat(1, knn, CV_32SC1);
	cv::Mat dists_mat(1, knn, CV_32FC1);
	obj->knnSearch(*queries, indices_mat, dists_mat, knn, *params);
	memcpy(indices, indices_mat.ptr<int>(0), sizeof(int) * knn);
	memcpy(dists, dists_mat.ptr<float>(0), sizeof(float) * knn);
}
CVAPI(void) flann_Index_radiusSearch1(cv::flann::Index* obj, float* queries, int queries_length, int* indices, int indices_length, float* dists, int dists_length, float radius, int maxResults, cv::flann::SearchParams* params)
{
	std::vector<float> queries_vec(queries_length);
	std::vector<int> indices_vec(indices_length);
	std::vector<float> dists_vec(dists_length);
	memcpy(&queries_vec[0], queries, sizeof(float) * queries_length);
	obj->radiusSearch(queries_vec, indices_vec, dists_vec, radius, maxResults, *params);
	memcpy(indices, &indices_vec[0], sizeof(int) * indices_length);
	memcpy(dists, &dists_vec[0], sizeof(float) * dists_length);
}
CVAPI(void) flann_Index_radiusSearch2(cv::flann::Index* obj, cv::Mat* queries, cv::Mat* indices, cv::Mat* dists, float radius, int maxResults, cv::flann::SearchParams* params)
{
	obj->radiusSearch(*queries, *indices, *dists, radius, maxResults, *params);
}
CVAPI(void) flann_Index_radiusSearch3(cv::flann::Index* obj, cv::Mat* queries, int* indices, int indices_length, float* dists, int dists_length, float radius, int maxResults, cv::flann::SearchParams* params)
{
	cv::Mat indices_mat(1, indices_length, CV_32SC1);
	cv::Mat dists_mat(1, dists_length, CV_32FC1);
	obj->radiusSearch(*queries, indices_mat, dists_mat, radius, maxResults, *params);
	memcpy(indices, indices_mat.ptr<int>(0), sizeof(int) * indices_length);
	memcpy(dists, dists_mat.ptr<float>(0), sizeof(float) * dists_length);
}
CVAPI(void) flann_Index_save(cv::flann::Index* obj, const char* filename)
{
	std::string _filename(filename);
	obj->save(_filename);
}
/*
CVAPI(int) flann_Index_veclen(cv::flann::Index* obj)
{
	return obj->veclen();
}
CVAPI(int) flann_Index_size(cv::flann::Index* obj)
{
	return obj->size();
}
//*/


// cv::flann::IndexParams
CVAPI(cv::flann::IndexParams*) flann_IndexParams_new()
{
	return new cv::flann::IndexParams;
}
CVAPI(void) flann_IndexParams_delete(cv::flann::IndexParams *obj)
{
	delete obj;
}
CVAPI(void) flann_IndexParams_getString(cv::flann::IndexParams *obj, const char *key, const char *defaultVal, char *result) 
{
	std::string defaultVal_;
	if(defaultVal == NULL)
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

// cv::flann::KDTreeIndexParams
CVAPI(cv::flann::KDTreeIndexParams*) flann_KDTreeIndexParams_new(int trees)
{
	return new cv::flann::KDTreeIndexParams(trees);
}
CVAPI(void) flann_KDTreeIndexParams_delete(cv::flann::KDTreeIndexParams* obj)
{
	delete obj;
}
/*
CVAPI(int*) flann_KDTreeIndexParams_trees(cv::flann::KDTreeIndexParams* obj)
{
	return &obj->trees;
}
//*/

// cv::flann::KMeansIndexParams
CVAPI(cv::flann::KMeansIndexParams*) flann_KMeansIndexParams_new(int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index)
{
	return new cv::flann::KMeansIndexParams(branching, iterations, centers_init, cb_index);
}
CVAPI(void) flann_KMeansIndexParams_delete(cv::flann::KMeansIndexParams* obj)
{
	delete obj;
}
/*
CVAPI(int*) flann_KMeansIndexParams_branching(cv::flann::KMeansIndexParams* obj)
{
	return &obj->branching;
}
CVAPI(int*) flann_KMeansIndexParams_iterations(cv::flann::KMeansIndexParams* obj)
{
	return &obj->iterations;
}
CVAPI(flann_centers_init_t*) flann_KMeansIndexParams_centers_init(cv::flann::KMeansIndexParams* obj)
{
	return &obj->centers_init;
}
CVAPI(float*) flann_KMeansIndexParams_cb_index(cv::flann::KMeansIndexParams* obj)
{
	return &obj->cb_index;
}
//*/

// cv::flann::CompositeIndexParams
CVAPI(cv::flann::CompositeIndexParams*) flann_CompositeIndexParams_new(int trees, int branching, int iterations, cvflann::flann_centers_init_t centers_init, float cb_index)
{
	return new cv::flann::CompositeIndexParams(trees, branching, iterations, centers_init, cb_index);
}
CVAPI(void) flann_CompositeIndexParams_delete(cv::flann::CompositeIndexParams* obj)
{
	delete obj;
}
/*
CVAPI(int*) flann_CompositeIndexParams_trees(cv::flann::CompositeIndexParams* obj)
{
	return &obj->trees;
}
CVAPI(int*) flann_CompositeIndexParams_branching(cv::flann::CompositeIndexParams* obj)
{
	return &obj->branching;
}
CVAPI(int*) flann_CompositeIndexParams_iterations(cv::flann::CompositeIndexParams* obj)
{
	return &obj->iterations;
}
CVAPI(flann_centers_init_t*) flann_CompositeIndexParams_centers_init(cv::flann::CompositeIndexParams* obj)
{
	return &obj->centers_init;
}
CVAPI(float*) flann_CompositeIndexParams_cb_index(cv::flann::CompositeIndexParams* obj)
{
	return &obj->cb_index;
}
*/
// cv::flann::AutotunedIndexParams
CVAPI(cv::flann::AutotunedIndexParams*) flann_AutotunedIndexParams_new(float target_precision = 0.9, float build_weight = 0.01, float memory_weight = 0, float sample_fraction = 0.1)
{
	return new cv::flann::AutotunedIndexParams(target_precision, build_weight, memory_weight, sample_fraction);
}
CVAPI(void) flann_AutotunedIndexParams_delete(cv::flann::AutotunedIndexParams* obj)
{
	delete obj;
}
/*
CVAPI(float*) flann_AutotunedIndexParams_target_precision(cv::flann::AutotunedIndexParams* obj)
{
	return &obj->target_precision;
}
CVAPI(float*) flann_AutotunedIndexParams_build_weight(cv::flann::AutotunedIndexParams* obj)
{
	return &obj->build_weight;
}
CVAPI(float*) flann_AutotunedIndexParams_memory_weight(cv::flann::AutotunedIndexParams* obj)
{
	return &obj->memory_weight;
}
CVAPI(float*) flann_AutotunedIndexParams_sample_fraction(cv::flann::AutotunedIndexParams* obj)
{
	return &obj->sample_fraction;
}
*/

// cv::flann::SavedIndexParams
CVAPI(cv::flann::SavedIndexParams*) flann_SavedIndexParams_new(const char* filename)
{
	return new cv::flann::SavedIndexParams(filename);
}
CVAPI(void) flann_SavedIndexParams_delete(cv::flann::SavedIndexParams* obj)
{
	delete obj;
}
/*
CVAPI(const char*) flann_SavedIndexParams_filename_get(cv::flann::SavedIndexParams* obj)
{
	return (obj->filename).c_str();
}
CVAPI(void) flann_SavedIndexParams_filename_set(cv::flann::SavedIndexParams* obj, const char* filename)
{
	obj->filename.assign(filename);
}
*/

// cv::flann::SearchParams
CVAPI(cv::flann::SearchParams*) flann_SearchParams_new(int checks, float eps, int sorted)
{
	return new cv::flann::SearchParams(checks, eps, (sorted != 0));
}
CVAPI(void) flann_SearchParams_delete(cv::flann::SearchParams* obj)
{
	delete obj;
}
/*
CVAPI(int) flann_hierarchicalClustering(Mat* features, Mat* centers, KMeansIndexParams* params)
{
	return cv::flann::hierarchicalClustering(*features, *centers, *params);
}
//*/

#endif