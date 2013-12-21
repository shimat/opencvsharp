/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVSVM_H_
#define _CVSVM_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>


CVAPI(void) CvSVMParams_construct_default(CvSVMParams* p)
{
	*p = CvSVMParams();
}
CVAPI(void) CvSVMParams_construct(CvSVMParams* p, int _svm_type, int _kernel_type, double _degree, double _gamma, double _coef0,  
								   double _C, double _nu, double _p, CvMat* _class_weights, CvTermCriteria _term_crit )
{
	*p = CvSVMParams(_svm_type, _kernel_type, _degree, _gamma, _coef0, _C, _nu, _p, _class_weights, _term_crit);
}



CVAPI(int) CvSVM_sizeof()
{
	return sizeof(CvSVM);
}


CVAPI(CvSVM*) CvSVM_construct_default()
{
	return new CvSVM();
}
CVAPI(CvSVM*) CvSVM_construct_training( const CvMat* _train_data, const CvMat* _responses, const CvMat* _var_idx, const CvMat* _sample_idx, CvSVMParams _params )
{
	return new CvSVM(_train_data, _responses, _var_idx, _sample_idx, _params);
}
CVAPI(void) CvSVM_destruct(CvSVM* model)
{
	delete model;
}



CVAPI(void) CvSVM_get_default_grid(CvParamGrid* grid, int param_id)
{
	*grid = CvSVM::get_default_grid(param_id);
}
CVAPI(bool) CvParamGrid_check(CvParamGrid grid)
{
	return grid.check();
}


CVAPI(bool) CvSVM_train(CvSVM* model, const CvMat* _train_data, const CvMat* _responses, const CvMat* _var_idx, const CvMat* _sample_idx, CvSVMParams _params )
{
	return model->train(_train_data, _responses, _var_idx, _sample_idx, _params);
}
CVAPI(bool) CvSVM_train_auto(CvSVM* model, const CvMat* _train_data, const CvMat* _responses, const CvMat* _var_idx, const CvMat* _sample_idx, CvSVMParams _params,
   int k_fold, CvParamGrid C_grid, CvParamGrid gamma_grid, CvParamGrid p_grid, CvParamGrid nu_grid, CvParamGrid coef_grid, CvParamGrid degree_grid )
{
	return model->train_auto(_train_data, _responses, _var_idx, _sample_idx, _params, k_fold, C_grid, gamma_grid, p_grid, nu_grid, coef_grid, degree_grid);
}
CVAPI(float) CvSVM_predict(CvSVM* model, const CvMat* _sample )
{
	return model->predict(_sample);
}
CVAPI(const float*) CvSVM_get_support_vector(CvSVM* model, int i)
{
	return model->get_support_vector(i);
}
CVAPI(int) CvSVM_get_support_vector_count(CvSVM* model)
{
	return model->get_support_vector_count();
}
CVAPI(int) CvSVM_get_var_count(CvSVM* model)
{
	return model->get_var_count();
}
CVAPI(void) CvSVM_get_params(CvSVM* model, CvSVMParams* p) 
{ 
	*p = model->get_params(); 
}


CVAPI(void) CvSVM_clear( CvSVM* model )
{
	model->clear();
}
CVAPI(void) CvSVM_write( CvSVM* model, CvFileStorage* storage, const char* name )
{
	model->write(storage, name);
}
CVAPI(void) CvSVM_read( CvSVM* model, CvFileStorage* storage, CvFileNode* node )
{
	model->read(storage, node);
}

#endif
