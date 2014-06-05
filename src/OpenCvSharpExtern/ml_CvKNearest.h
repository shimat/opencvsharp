#ifndef _CPP_ML_KNEAREST_H_
#define _CPP_ML_KNEAREST_H_

#include "include_opencv.h"


CVAPI(CvKNearest*) ml_CvKNearest_new1()
{
	return new CvKNearest();
}
CVAPI(CvKNearest*) ml_CvKNearest_new2_CvMat(
    CvMat *trainData, CvMat *responses, CvMat *sampleIdx, bool isRegression, int maxK)
{
    return new CvKNearest(trainData, responses, sampleIdx, isRegression, maxK);
}
CVAPI(CvKNearest*) ml_CvKNearest_new2_Mat(
    cv::Mat *trainData, cv::Mat *responses, cv::Mat *sampleIdx, bool isRegression, int maxK)
{
    return new CvKNearest(*trainData, *responses, entity(sampleIdx), isRegression, maxK);
}
CVAPI(void) ml_CvKNearest_delete(CvKNearest *obj)
{
	delete obj;
}

CVAPI(int) ml_CvKNearest_train_CvMat(CvKNearest *obj, CvMat *trainData, CvMat *responses,
    CvMat *sampleIdx, int isRegression, int maxK, int updateBase)
{
    return obj->train(trainData, responses, sampleIdx, 
        isRegression != 0, maxK, updateBase != 0) ? 1 : 0;
}
CVAPI(int) ml_CvKNearest_train_Mat(CvKNearest *obj, cv::Mat *trainData, cv::Mat *responses,
    cv::Mat *sampleIdx, int isRegression, int maxK, int updateBase)
{
    return obj->train(*trainData, *responses, entity(sampleIdx),
        isRegression != 0, maxK, updateBase != 0) ? 1 : 0;
}
CVAPI(float) ml_CvKNearest_find_nearest_CvMat(
    CvKNearest *obj, CvMat *samples, int k, CvMat *results, const float** neighbors, 
    CvMat *neighborResponses, CvMat *dist)
{
	return obj->find_nearest(samples, k, results, neighbors, neighborResponses, dist);
}
CVAPI(float) ml_CvKNearest_find_nearest_Mat(
    CvKNearest *obj, cv::Mat *samples, int k, cv::Mat *results,
    cv::Mat *neighborResponses, cv::Mat *dists)
{
    return obj->find_nearest(*samples, k, *results, *neighborResponses, *dists);
}

CVAPI(void) ml_CvKNearest_clear(CvKNearest *obj)
{
	obj->clear();
}
CVAPI(int) ml_CvKNearest_get_max_k(CvKNearest *obj)
{
	return obj->get_max_k();
}
CVAPI(int) ml_CvKNearest_get_var_count(CvKNearest *obj)
{
	return obj->get_var_count();
}
CVAPI(int) ml_CvKNearest_get_sample_count(CvKNearest *obj) 
{
	return obj->get_sample_count();
}
CVAPI(int) ml_CvKNearest_is_regression(CvKNearest *obj)
{
	return obj->is_regression() ? 1 : 0;
}

#endif
