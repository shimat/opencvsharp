/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVBOOST_H_
#define _CVBOOST_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

// CvBoost
CVAPI(int) CvBoost_sizeof()
{
	return sizeof(CvBoost);
}

CVAPI(CvBoost*) CvBoost_construct_default()
{
	return new CvBoost();
}    
CVAPI(CvBoost*) CvBoost_construct_training( const CvMat* _train_data, int _tflag, const CvMat* _responses, 
			const CvMat* _var_idx,  const CvMat* _sample_idx, const CvMat* _var_type,
             const CvMat* _missing_mask, CvBoostParams* params )
{
	return new CvBoost(_train_data, _tflag, _responses, _var_idx, _sample_idx, _var_type, _missing_mask, *params);
}
CVAPI(void) CvBoost_destruct(CvBoost* obj)
{
	delete obj;
}

CVAPI(bool) CvBoost_train( CvBoost* obj, const CvMat* _train_data, int _tflag, const CvMat* _responses, 
						  const CvMat* _var_idx, const CvMat* _sample_idx, const CvMat* _var_type, 
						  const CvMat* _missing_mask, CvBoostParams* params, bool update )
{
	return obj->train(_train_data, _tflag, _responses, _var_idx, _sample_idx, _var_type, _missing_mask, *params, update);
}
CVAPI(float) CvBoost_predict( CvBoost* obj, const CvMat* _sample, const CvMat* _missing, 
							 CvMat* weak_responses, CvSlice slice, bool raw_mode) 
{
	return obj->predict(_sample, _missing, weak_responses, slice, raw_mode);
}

CVAPI(void) CvBoost_prune( CvBoost* obj, CvSlice slice )
{
	obj->prune(slice);
}

CVAPI(void) CvBoost_clear(CvBoost* obj)
{
	obj->clear();
}

CVAPI(void) CvBoost_write( CvBoost* obj, CvFileStorage* storage, const char* name )
{
	obj->write(storage, name);
}
CVAPI(void) CvBoost_read( CvBoost* obj, CvFileStorage* storage, CvFileNode* node )
{
	obj->read(storage, node);
}

CVAPI(CvSeq*) CvBoost_get_weak_predictors(CvBoost* obj)
{
	return obj->get_weak_predictors();
}
CVAPI(CvMat*) CvBoost_get_weights(CvBoost* obj)
{
	return obj->get_weights();
}
CVAPI(CvMat*) CvBoost_get_subtree_weights(CvBoost* obj)
{
	return obj->get_subtree_weights();
}
CVAPI(CvMat*) CvBoost_get_weak_response(CvBoost* obj)
{
	return obj->get_weak_response();
}
CVAPI(CvBoostParams*) CvBoost_get_params(CvBoost* obj)
{
	return const_cast<CvBoostParams*>(&(obj->get_params()));
}


// CvBoostTree
CVAPI(int) CvBoostTree_sizeof()
{
	return sizeof(CvBoostTree);
}
CVAPI(CvBoostTree*) CvBoostTree_construct()
{
	return new CvBoostTree();
}
CVAPI(void) CvBoostTree_destruct(CvBoostTree* obj)
{
	delete obj;
}
CVAPI(bool) CvBoostTree_train( CvBoostTree* obj, CvDTreeTrainData* _train_data, const CvMat* subsample_idx, CvBoost* ensemble )
{
	return obj->train(_train_data, subsample_idx, ensemble);
}
CVAPI(void) CvBoostTree_scale( CvBoostTree* obj, double s )
{
	obj->scale(s);
}
CVAPI(void) CvBoostTree_read( CvBoostTree* obj, CvFileStorage* fs, CvFileNode* node, CvBoost* ensemble, CvDTreeTrainData* _data )
{
	obj->read(fs, node, ensemble, _data);
}
CVAPI(void) CvBoostTree_clear(CvBoostTree* obj)
{
	obj->clear();
}



// CvBoostParams
CVAPI(int) CvBoostParams_sizeof()
{
	return sizeof(CvBoostParams);
}
CVAPI(CvBoostParams*) CvBoostParams_construct_default()
{
	return new CvBoostParams();
}
CVAPI(CvBoostParams*) CvBoostParams_construct( int boost_type, int weak_count, double weight_trim_rate,
                   int max_depth, bool use_surrogates, const float* priors )
{
	return new CvBoostParams(boost_type, weak_count, weight_trim_rate, max_depth, use_surrogates, priors);
}
CVAPI(void) CvBoostParams_destruct(CvBoostParams* obj)
{
	delete obj;
}

CVAPI(int) CvBoostParams_boost_type_get(CvBoostParams* obj)
{
	return obj->boost_type;
}
CVAPI(void) CvBoostParams_boost_type_set(CvBoostParams* obj, int value)
{
	obj->boost_type = value;
}
CVAPI(int) CvBoostParams_weak_count_get(CvBoostParams* obj)
{
	return obj->weak_count;
}
CVAPI(void) CvBoostParams_weak_count_set(CvBoostParams* obj, int value)
{
	obj->weak_count = value;
}
CVAPI(int) CvBoostParams_split_criteria_get(CvBoostParams* obj)
{
	return obj->split_criteria;
}
CVAPI(void) CvBoostParams_split_criteria_set(CvBoostParams* obj, int value)
{
	obj->split_criteria = value;
}
CVAPI(double) CvBoostParams_weight_trim_rate_get(CvBoostParams* obj)
{
	return obj->weight_trim_rate;
}
CVAPI(void) CvBoostParams_weight_trim_rate_set(CvBoostParams* obj, double value)
{
	obj->weight_trim_rate = value;
}

#endif
