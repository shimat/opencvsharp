/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVRTREES_H_
#define _CVRTREES_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

// CvRTParams
CVAPI(CvRTParams*) CvRTParams_construct_default()
{
	return new CvRTParams();
}
CVAPI(CvRTParams*) CvRTParams_construct( int _max_depth, int _min_sample_count,
                float _regression_accuracy, bool _use_surrogates,
                int _max_categories, const float* _priors, bool _calc_var_importance,
                int _nactive_vars, int max_num_of_trees_in_the_forest,
                float forest_accuracy, int termcrit_type )
{
	return new CvRTParams(_max_depth, _min_sample_count, _regression_accuracy, _use_surrogates,
                _max_categories, _priors, _calc_var_importance, _nactive_vars, max_num_of_trees_in_the_forest,
                forest_accuracy, termcrit_type);
}
CVAPI(void) CvRTParams_destruct(CvRTParams* obj)
{
	delete obj;
}

CVAPI(bool) CvRTParams_calc_var_importance_get(CvRTParams* obj)
{
	return obj->calc_var_importance;
}
CVAPI(void) CvRTParams_calc_var_importance_set(CvRTParams* obj, bool value)
{
	obj->calc_var_importance = value;
}
CVAPI(int) CvRTParams_nactive_vars_get(CvRTParams* obj)
{
	return obj->nactive_vars;
}
CVAPI(void) CvRTParams_nactive_vars_set(CvRTParams* obj, int value)
{
	obj->nactive_vars = value;
}
CVAPI(CvTermCriteria) CvRTParams_term_crit_get(CvRTParams* obj)
{
	return obj->term_crit;
}
CVAPI(void) CvRTParams_term_crit_set(CvRTParams* obj, CvTermCriteria value)
{
	obj->term_crit = value;
}


// CvRTrees
CVAPI(int) CvRTrees_sizeof()
{
	return sizeof(CvRTrees);
}

CVAPI(void) CvRTrees_construct(CvRTrees* obj)
{
	 CvRTrees rt = CvRTrees();
	 memcpy(obj, &rt, sizeof(CvRTrees));
}
CVAPI(void) CvRTrees_destruct(CvRTrees* obj)
{
	delete obj;
}

CVAPI(bool) CvRTrees_train( CvRTrees* obj, const CvMat* _train_data, int _tflag, const CvMat* _responses, const CvMat* _var_idx,
                        const CvMat* _sample_idx, const CvMat* _var_type, const CvMat* _missing_mask, CvRTParams* params )
{
	return obj->train(_train_data, _tflag, _responses, _var_idx, _sample_idx, _var_type, _missing_mask, *params);
}
CVAPI(float) CvRTrees_predict( CvRTrees* obj, const CvMat* sample, const CvMat* missing )
{
	return obj->predict(sample, missing);
}
CVAPI(void) CvRTrees_clear(CvRTrees* obj)
{
	obj->clear();
}

CVAPI(const CvMat*) CvRTrees_get_var_importance(CvRTrees* obj)
{
	return obj->get_var_importance();
}
CVAPI(float) CvRTrees_get_proximity( CvRTrees* obj, const CvMat* sample1, const CvMat* sample2,
        const CvMat* missing1, const CvMat* missing2 )
{
	return obj->get_proximity(sample1, sample2, missing1, missing2);
}

CVAPI(void) CvRTrees_read( CvRTrees* obj, CvFileStorage* fs, CvFileNode* node )
{
	obj->read(fs, node);
}
CVAPI(void) CvRTrees_write( CvRTrees* obj, CvFileStorage* fs, const char* name )
{
	obj->write(fs, name);
}

CVAPI(CvMat*) CvRTrees_get_active_var_mask(CvRTrees* obj)
{
	return obj->get_active_var_mask();
}
CVAPI(CvRNG*) CvRTrees_get_rng(CvRTrees* obj)
{
	return obj->get_rng();
}

CVAPI(int) CvRTrees_get_tree_count(CvRTrees* obj)
{
	return obj->get_tree_count();
}
CVAPI(CvForestTree*) CvRTrees_get_tree(CvRTrees* obj, int i)
{
	return obj->get_tree(i);
}


// CvForestTree
CVAPI(int) CvForestTree_sizeof()
{
	return sizeof(CvForestTree);
}
CVAPI(CvForestTree*) CvForestTree_construct()
{
	return new CvForestTree();
}
CVAPI(void) CvForestTree_destruct(CvForestTree* obj)
{
	delete obj;
}
CVAPI(bool) CvForestTree_train( CvForestTree* obj, CvDTreeTrainData* _train_data, const CvMat* _subsample_idx, CvRTrees* forest )
{
	return obj->train(_train_data, _subsample_idx, forest);
}

CVAPI(int) CvForestTree_get_var_count(CvForestTree* obj)
{
	return obj->get_var_count();
}
CVAPI(void) CvForestTree_read( CvForestTree* obj, CvFileStorage* fs, CvFileNode* node, CvRTrees* forest, CvDTreeTrainData* _data )
{
	obj->read(fs, node, forest, _data);
}

#endif
