#pragma once

#ifndef NO_FLANN

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

// cv::flann::Index

CVAPI(ExceptionStatus) flann_Index_new(
    const interop::InputArrayProxy* features,
    cv::flann::IndexParams* params,
    cvflann::flann_distance_t distType,
    cv::flann::Index **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::flann::Index(InProxy(*features), *params, distType);
    });
}

CVAPI(ExceptionStatus) flann_Index_delete(cv::flann::Index* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) flann_Index_knnSearch1(
    cv::flann::Index* obj,
    float* queries,
    int queries_length,
    int* indices,
    float* dists,
    int knn,
    cv::flann::SearchParams* params)
{
    return cvTry([&] {
        const std::vector<float> queries_vec(queries, queries + queries_length);
        std::vector<int> indices_vec(knn);
        std::vector<float> dists_vec(knn);
        obj->knnSearch(queries_vec, indices_vec, dists_vec, knn, *params);
        memcpy(indices, &indices_vec[0], sizeof(int) * knn);
        memcpy(dists, &dists_vec[0], sizeof(float) * knn);
    });
}
CVAPI(ExceptionStatus) flann_Index_knnSearch2(
    cv::flann::Index* obj,
    cv::Mat* queries,
    cv::Mat* indices,
    cv::Mat* dists,
    int knn,
    cv::flann::SearchParams* params)
{
    return cvTry([&] {
        obj->knnSearch(*queries, *indices, *dists, knn, *params);
    });
}
CVAPI(ExceptionStatus) flann_Index_knnSearch3(
    cv::flann::Index* obj,
    cv::Mat* queries,
    int* indices,
    float* dists,
    int knn,
    cv::flann::SearchParams* params)
{
    return cvTry([&] {
        cv::Mat indices_mat(1, knn, CV_32SC1);
        cv::Mat dists_mat(1, knn, CV_32FC1);
        obj->knnSearch(*queries, indices_mat, dists_mat, knn, *params);
        memcpy(indices, indices_mat.ptr<int>(0), sizeof(int) * knn);
        memcpy(dists, dists_mat.ptr<float>(0), sizeof(float) * knn);
    });
}

CVAPI(ExceptionStatus) flann_Index_radiusSearch1(
    cv::flann::Index* obj,
    float* queries,
    int queries_length,
    int* indices,
    int indices_length,
    float* dists,
    int dists_length,
    double radius,
    int maxResults,
    cv::flann::SearchParams* params)
{
    return cvTry([&] {
        const std::vector<float> queries_vec(queries, queries + queries_length);
        std::vector<int> indices_vec(indices_length);
        std::vector<float> dists_vec(dists_length);
        obj->radiusSearch(queries_vec, indices_vec, dists_vec, radius, maxResults, *params);
        memcpy(indices, &indices_vec[0], sizeof(int) * indices_length);
        memcpy(dists, &dists_vec[0], sizeof(float) * dists_length);
    });
}
CVAPI(ExceptionStatus) flann_Index_radiusSearch2(
    cv::flann::Index* obj,
    cv::Mat* queries,
    cv::Mat* indices,
    cv::Mat* dists,
    double radius,
    int maxResults,
    cv::flann::SearchParams* params)
{
    return cvTry([&] {
        obj->radiusSearch(*queries, *indices, *dists, radius, maxResults, *params);
    });
}
CVAPI(ExceptionStatus) flann_Index_radiusSearch3(
    cv::flann::Index* obj,
    cv::Mat* queries,
    int* indices,
    int indices_length,
    float* dists,
    int dists_length,
    double radius,
    int maxResults,
    cv::flann::SearchParams* params)
{
    return cvTry([&] {
        cv::Mat indices_mat(1, indices_length, CV_32SC1);
        cv::Mat dists_mat(1, dists_length, CV_32FC1);
        obj->radiusSearch(*queries, indices_mat, dists_mat, radius, maxResults, *params);
        memcpy(indices, indices_mat.ptr<int>(0), sizeof(int) * indices_length);
        memcpy(dists, dists_mat.ptr<float>(0), sizeof(float) * dists_length);
    });
}

CVAPI(ExceptionStatus) flann_Index_save(cv::flann::Index* obj, const char* filename)
{
    return cvTry([&] {
        obj->save(filename);
    });
}

#endif // NO_FLANN
