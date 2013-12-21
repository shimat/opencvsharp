/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVANN_MLP_H_
#define _CVANN_MLP_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

// CvANN_MLP_TrainParams
CVAPI(CvANN_MLP_TrainParams*) CvANN_MLP_TrainParams_construct_default()
{
	return new CvANN_MLP_TrainParams();
}
CVAPI(CvANN_MLP_TrainParams*) CvANN_MLP_TrainParams_construct( 
	CvTermCriteria term_crit, int train_method, double param1, double param2 )
{
	return new CvANN_MLP_TrainParams(term_crit, train_method, param1, param2);
}
CVAPI(void) CvANN_MLP_TrainParams_destruct(CvANN_MLP_TrainParams* obj)
{
	delete obj;
}


// CvANN_MLP
CVAPI(int) CvANN_MLP_sizeof()
{
	return sizeof(CvANN_MLP);
}

CVAPI(CvANN_MLP*) CvANN_MLP_construct_default()
{
	return new CvANN_MLP();
}
CVAPI(CvANN_MLP*) CvANN_MLP_construct_training(const CvMat* _layer_sizes, int _activ_func, double _f_param1, double _f_param2 )
{
	return new CvANN_MLP(_layer_sizes, _activ_func, _f_param1, _f_param2);
}
CVAPI(void) CvANN_MLP_destruct(CvANN_MLP* obj)
{
	delete obj;
}

CVAPI(int) CvANN_MLP_train(CvANN_MLP* obj, const CvMat* _inputs, const CvMat* _outputs, const CvMat* _sample_weights, 
				const CvMat* _sample_idx, CvANN_MLP_TrainParams _params, int flags )
{
	return obj->train(_inputs, _outputs, _sample_weights, _sample_idx, _params, flags);
}
CVAPI(float) CvANN_MLP_predict(CvANN_MLP* obj, const CvMat* _inputs, CvMat* _outputs )
{
	return obj->predict(_inputs, _outputs);
}
CVAPI(void) CvANN_MLP_create(CvANN_MLP* obj, const CvMat* _layer_sizes, int _activ_func, double _f_param1, double _f_param2 )
{
	obj->create(_layer_sizes, _activ_func, _f_param1, _f_param2);
}

CVAPI(void) CvANN_MLP_clear(CvANN_MLP* obj)
{
	obj->clear();
}

CVAPI(void) CvANN_MLP_read(CvANN_MLP* obj, CvFileStorage* fs, CvFileNode* node )
{
	obj->read(fs, node);
}
CVAPI(void) CvANN_MLP_write(CvANN_MLP* obj, CvFileStorage* storage, const char* name )
{
	obj->write(storage, name);
}

CVAPI(int)  CvANN_MLP_get_layer_count(CvANN_MLP* obj) 
{ 
	return obj->get_layer_count();
}
CVAPI(const CvMat*)  CvANN_MLP_get_layer_sizes(CvANN_MLP* obj)
{ 
	return obj->get_layer_sizes();
}
CVAPI(double*) CvANN_MLP_get_weights(CvANN_MLP* obj, int layer)
{
	return obj->get_weights(layer);
}

#endif
