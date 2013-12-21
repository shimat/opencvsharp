/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVKNEAREST_H_
#define _CVKNEAREST_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

CVAPI(int) CvKNearest_sizeof()
{
	return sizeof(CvKNearest);
}


CVAPI(CvKNearest*) CvKNearest_construct_default()
{
	return new CvKNearest();
}
CVAPI(CvKNearest*) CvKNearest_construct_training(const CvMat* _train_data, const CvMat* _responses,
   const CvMat* _sample_idx, bool _is_regression, int max_k )
{
	return new CvKNearest(_train_data, _responses, _sample_idx, _is_regression, max_k);
}
CVAPI(void) CvKNearest_destruct(CvKNearest* obj)
{
	delete obj;
}


CVAPI(bool) CvKNearest_train(CvKNearest* obj, const CvMat* _train_data, const CvMat* _responses,
   const CvMat* _sample_idx, bool is_regression, int _max_k, bool _update_base )
{
	return obj->train(_train_data, _responses, _sample_idx, is_regression, _max_k, _update_base);
}
CVAPI(float) CvKNearest_find_nearest(CvKNearest* obj, const CvMat* _samples, int k, 
	CvMat* results, const float** neighbors, CvMat* neighbor_responses, CvMat* dist )
{
	return obj->find_nearest(_samples, k, results, neighbors, neighbor_responses, dist);
}

CVAPI(void) CvKNearest_clear(CvKNearest* obj)
{
	obj->clear();
}
CVAPI(int) CvKNearest_get_max_k(CvKNearest* obj)
{
	return obj->get_max_k();
}
CVAPI(int) CvKNearest_get_var_count(CvKNearest* obj)
{
	return obj->get_var_count();
}
CVAPI(int) CvKNearest_get_sample_count(CvKNearest* obj) 
{
	return obj->get_sample_count();
}
CVAPI(bool) CvKNearest_is_regression(CvKNearest* obj)
{
	return obj->is_regression();
}

#endif
