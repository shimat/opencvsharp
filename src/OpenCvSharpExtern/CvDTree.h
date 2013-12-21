/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVDTREE_H_
#define _CVDTREE_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

// CvDTreeParams
CVAPI(CvDTreeParams*) CvDTreeParams_construct_default()
{
	return new CvDTreeParams();
}
CVAPI(CvDTreeParams*) CvDTreeParams_construct( int _max_depth, int _min_sample_count, float _regression_accuracy, bool _use_surrogates,
                   int _max_categories, int _cv_folds, bool _use_1se_rule, bool _truncate_pruned_tree, const float* _priors )
{
	return new CvDTreeParams(_max_depth, _min_sample_count, _regression_accuracy, _use_surrogates, _max_categories, _cv_folds, _use_1se_rule, _truncate_pruned_tree, _priors);
}
CVAPI(void) CvDTreeParams_destruct(CvDTreeParams* p)
{
	delete p;
}

CVAPI(int) CvDTreeParams_max_categories_get(CvDTreeParams* p)
{
	return p->max_categories;
}
CVAPI(void) CvDTreeParams_max_categories_set(CvDTreeParams* p, int value)
{
	p->max_categories = value;
}
CVAPI(int) CvDTreeParams_max_depth_get(CvDTreeParams* p)
{
	return p->max_depth;
}
CVAPI(void) CvDTreeParams_max_depth_set(CvDTreeParams* p, int value)
{
	p->max_depth = value;
}
CVAPI(int) CvDTreeParams_min_sample_count_get(CvDTreeParams* p)
{
	return p->min_sample_count;
}
CVAPI(void) CvDTreeParams_min_sample_count_set(CvDTreeParams* p, int value)
{
	p->min_sample_count = value;
}
CVAPI(int) CvDTreeParams_cv_folds_get(CvDTreeParams* p)
{
	return p->cv_folds;
}
CVAPI(void) CvDTreeParams_cv_folds_set(CvDTreeParams* p, int value)
{
	p->cv_folds = value;
}
CVAPI(bool) CvDTreeParams_use_surrogates_get(CvDTreeParams* p)
{
	return p->use_surrogates;
}
CVAPI(void) CvDTreeParams_use_surrogates_set(CvDTreeParams* p, bool value)
{
	p->use_surrogates = value;
}
CVAPI(bool) CvDTreeParams_use_1se_rule_get(CvDTreeParams* p)
{
	return p->use_1se_rule;
}
CVAPI(void) CvDTreeParams_use_1se_rule_set(CvDTreeParams* p, bool value)
{
	p->use_1se_rule = value;
}
CVAPI(bool) CvDTreeParams_truncate_pruned_tree_get(CvDTreeParams* p)
{
	return p->truncate_pruned_tree;
}
CVAPI(void) CvDTreeParams_truncate_pruned_tree_set(CvDTreeParams* p, bool value)
{
	p->truncate_pruned_tree = value;
}
CVAPI(float) CvDTreeParams_regression_accuracy_get(CvDTreeParams* p)
{
	return p->regression_accuracy;
}
CVAPI(void) CvDTreeParams_regression_accuracy_set(CvDTreeParams* p, float value)
{
	p->regression_accuracy = value;
}
CVAPI(const float*) CvDTreeParams_priors_get(CvDTreeParams* p)
{
	return p->priors;
}
CVAPI(void) CvDTreeParams_priors_set(CvDTreeParams* p, const float* value)
{
	p->priors = value;
}


// CvDTreeTrainData
CVAPI(int) CvDTreeTrainData_sizeof()
{
	return sizeof(CvDTreeTrainData);
}

CVAPI(CvDTreeTrainData*) CvDTreeTrainData_construct_default()
{
	return new CvDTreeTrainData();
}
CVAPI(CvDTreeTrainData*) CvDTreeTrainData_construct_training( const CvMat* _train_data, int _tflag, const CvMat* _responses, 
	const CvMat* _var_idx, const CvMat* _sample_idx, const CvMat* _var_type, const CvMat* _missing_mask, 
	const CvDTreeParams* _params, bool _shared, bool _add_labels )
{
	return new CvDTreeTrainData(_train_data, _tflag, _responses, _var_idx, _sample_idx, _var_type, _missing_mask, *_params, _shared, _add_labels);
}
CVAPI(void) CvDTreeTrainData_destruct(CvDTreeTrainData* obj)
{
	delete obj;
}

CVAPI(void) CvDTreeTrainData_set_data(CvDTreeTrainData* obj, const CvMat* _train_data, int _tflag, const CvMat* _responses, 
	const CvMat* _var_idx, const CvMat* _sample_idx, const CvMat* _var_type, const CvMat* _missing_mask,
    const CvDTreeParams* _param, bool _shared, bool _add_labels, bool _update_data )
{
	obj->set_data(_train_data, _tflag, _responses, _var_idx, _sample_idx, _var_type, _missing_mask, *_param, _shared, _add_labels);
}
CVAPI(void) CvDTreeTrainData_get_vectors(CvDTreeTrainData* obj, const CvMat* _subsample_idx, float* values, uchar* missing, float* responses, bool get_class_idx )
{
	return obj->get_vectors(_subsample_idx, values, missing, responses, get_class_idx);
}
CVAPI(CvDTreeNode*) CvDTreeTrainData_subsample_data(CvDTreeTrainData* obj, const CvMat* _subsample_idx )
{
	return obj->subsample_data(_subsample_idx);
}
CVAPI(void) CvDTreeTrainData_write_params(CvDTreeTrainData* obj, CvFileStorage* fs )
{
	obj->write_params(fs);
}
CVAPI(void) CvDTreeTrainData_read_params(CvDTreeTrainData* obj, CvFileStorage* fs, CvFileNode* node )
{
	obj->read_params(fs, node);
}
CVAPI(void) CvDTreeTrainData_clear(CvDTreeTrainData* obj)
{
	obj->clear();
}
CVAPI(int) CvDTreeTrainData_get_num_classes(CvDTreeTrainData* obj) 
{
	return obj->get_num_classes();
}
CVAPI(int) CvDTreeTrainData_get_var_type(CvDTreeTrainData* obj, int vi)
{
	return obj->get_var_type(vi);
}
CVAPI(int) CvDTreeTrainData_get_work_var_count(CvDTreeTrainData* obj) 
{
	return obj->get_work_var_count();
}
CVAPI(const int*) CvDTreeTrainData_get_class_labels(CvDTreeTrainData* obj, CvDTreeNode* n, int* labels_buf )
{
	return obj->get_class_labels(n, labels_buf);
}
CVAPI(const float*) CvDTreeTrainData_get_ord_responses(CvDTreeTrainData* obj, CvDTreeNode* n, float* values_buf, int* sample_indices_buf )
{
	return obj->get_ord_responses(n, values_buf, sample_indices_buf);
}
CVAPI(const int*) CvDTreeTrainData_get_cv_labels(CvDTreeTrainData* obj, CvDTreeNode* n, int* labels_buf )
{
	return obj->get_cv_labels(n, labels_buf);
}
CVAPI(const int*) CvDTreeTrainData_get_cat_var_data(CvDTreeTrainData* obj, CvDTreeNode* n, int vi, int* cat_values_buf )
{
	return obj->get_cat_var_data(n, vi, cat_values_buf);
}
CVAPI(void) CvDTreeTrainData_get_ord_var_data(CvDTreeTrainData* obj, CvDTreeNode* n, int vi, 
		float* ord_values_buf, int* sorted_indices_buf, const float** ord_values, const int** sorted_indices, int* sample_indices_buf)
{
	return obj->get_ord_var_data(n, vi, ord_values_buf, sorted_indices_buf, ord_values, sorted_indices, sample_indices_buf);
}
CVAPI(int) CvDTreeTrainData_get_child_buf_idx(CvDTreeTrainData* obj, CvDTreeNode* n )
{
	return obj->get_child_buf_idx(n);
}

CVAPI(bool) CvDTreeTrainData_set_params(CvDTreeTrainData* obj, const CvDTreeParams* params )
{
	return obj->set_params(*params);
}
CVAPI(CvDTreeNode*) CvDTreeTrainData_new_node(CvDTreeTrainData* obj, CvDTreeNode* parent, int count, int storage_idx, int offset )
{
	return obj->new_node(parent, count, storage_idx, offset);
}
CVAPI(CvDTreeSplit*) CvDTreeTrainData_new_split_ord(CvDTreeTrainData* obj, int vi, float cmp_val, int split_point, int inversed, float quality )
{
	return obj->new_split_ord(vi, cmp_val, split_point, inversed, quality);
}
CVAPI(CvDTreeSplit*) CvDTreeTrainData_new_split_cat(CvDTreeTrainData* obj, int vi, float quality )
{
	return obj->new_split_cat(vi, quality);
}
CVAPI(void) CvDTreeTrainData_free_node_data(CvDTreeTrainData* obj, CvDTreeNode* node )
{
	obj->free_node_data(node);
}
CVAPI(void) CvDTreeTrainData_free_train_data(CvDTreeTrainData* obj)
{
	obj->free_train_data();
}
CVAPI(void) CvDTreeTrainData_free_node(CvDTreeTrainData* obj, CvDTreeNode* node )
{
	obj->free_node(node);
}
    ////////////////////////////////////

CVAPI(int) CvDTreeTrainData_sample_count(CvDTreeTrainData* obj)
{
	return obj->sample_count;
}
CVAPI(int) CvDTreeTrainData_var_all(CvDTreeTrainData* obj)
{
	return obj->var_all;
}
CVAPI(int) CvDTreeTrainData_var_count(CvDTreeTrainData* obj)
{
	return obj->var_count;
}
CVAPI(int) CvDTreeTrainData_max_c_count(CvDTreeTrainData* obj)
{
	return obj->max_c_count;
}
CVAPI(int) CvDTreeTrainData_ord_var_count(CvDTreeTrainData* obj)
{
	return obj->ord_var_count;
}
CVAPI(int) CvDTreeTrainData_cat_var_count(CvDTreeTrainData* obj)
{
	return obj->cat_var_count;
}
CVAPI(bool) CvDTreeTrainData_have_labels(CvDTreeTrainData* obj)
{
	return obj->have_labels;
}
CVAPI(bool) CvDTreeTrainData_have_priors(CvDTreeTrainData* obj)
{
	return obj->have_priors;
}
CVAPI(bool) CvDTreeTrainData_is_classifier(CvDTreeTrainData* obj)
{
	return obj->is_classifier;
}
CVAPI(int) CvDTreeTrainData_buf_count(CvDTreeTrainData* obj)
{
	return obj->buf_count;
}
CVAPI(int) CvDTreeTrainData_buf_size(CvDTreeTrainData* obj)
{
	return obj->buf_size;
}
CVAPI(bool) CvDTreeTrainData_shared(CvDTreeTrainData* obj)
{
	return obj->shared;
}
CVAPI(CvMat*) CvDTreeTrainData_cat_count(CvDTreeTrainData* obj)
{
	return obj->cat_count;
}
CVAPI(CvMat*) CvDTreeTrainData_cat_ofs(CvDTreeTrainData* obj)
{
	return obj->cat_ofs;
}
CVAPI(CvMat*) CvDTreeTrainData_cat_map(CvDTreeTrainData* obj)
{
	return obj->cat_map;
}
CVAPI(CvMat*) CvDTreeTrainData_counts(CvDTreeTrainData* obj)
{
	return obj->counts;
}
CVAPI(CvMat*) CvDTreeTrainData_buf(CvDTreeTrainData* obj)
{
	return obj->buf;
}
CVAPI(CvMat*) CvDTreeTrainData_direction(CvDTreeTrainData* obj)
{
	return obj->direction;
}
CVAPI(CvMat*) CvDTreeTrainData_split_buf(CvDTreeTrainData* obj)
{
	return obj->split_buf;
}
CVAPI(CvMat*) CvDTreeTrainData_var_idx(CvDTreeTrainData* obj)
{
	return obj->var_idx;
}
CVAPI(CvMat*) CvDTreeTrainData_var_type(CvDTreeTrainData* obj)
{
	return obj->var_type;
}
CVAPI(CvMat*) CvDTreeTrainData_priors(CvDTreeTrainData* obj)
{
	return obj->priors;
}
CVAPI(CvMat*) CvDTreeTrainData_priors_mult(CvDTreeTrainData* obj)
{
	return obj->priors_mult;
}
CVAPI(void) CvDTreeTrainData_params(CvDTreeTrainData* obj, CvDTreeParams* p)
{
	*p = obj->params;
}
CVAPI(CvMemStorage*) CvDTreeTrainData_tree_storage(CvDTreeTrainData* obj)
{
	return obj->tree_storage;
}
CVAPI(CvMemStorage*) CvDTreeTrainData_temp_storage(CvDTreeTrainData* obj)
{
	return obj->temp_storage;
}
CVAPI(CvDTreeNode*) CvDTreeTrainData_data_root(CvDTreeTrainData* obj)
{
	return obj->data_root;
}
CVAPI(CvSet*) CvDTreeTrainData_node_heap(CvDTreeTrainData* obj)
{
	return obj->node_heap;
}
CVAPI(CvSet*) CvDTreeTrainData_split_heap(CvDTreeTrainData* obj)
{
	return obj->split_heap;
}
CVAPI(CvSet*) CvDTreeTrainData_cv_heap(CvDTreeTrainData* obj)
{
	return obj->cv_heap;
}
CVAPI(CvSet*) CvDTreeTrainData_nv_heap(CvDTreeTrainData* obj)
{
	return obj->nv_heap;
}
CVAPI(uint64) CvDTreeTrainData_rng(CvDTreeTrainData* obj)
{
	return obj->rng->state;
}



// CvDTree	
CVAPI(int) CvDTree_sizeof()
{
	return sizeof(CvDTree);
}

CVAPI(CvDTree*) CvDTree_construct()
{
	return new CvDTree();
}
CVAPI(void) CvDTree_destruct(CvDTree* obj)
{
	delete obj;
}

CVAPI(bool) CvDTree_train1(CvDTree* obj, const CvMat* _train_data, int _tflag, const CvMat* _responses, 
	const CvMat* _var_idx, const CvMat* _sample_idx, const CvMat* _var_type, const CvMat* _missing_mask, CvDTreeParams* params )
{
	return obj->train(_train_data, _tflag, _responses, _var_idx, _sample_idx, _var_type, _missing_mask, *params);
}
CVAPI(bool) CvDTree_train2(CvDTree* obj, CvDTreeTrainData* _train_data, const CvMat* _subsample_idx )
{
	return obj->train(_train_data, _subsample_idx);
}
CVAPI(CvDTreeNode*) CvDTree_predict(CvDTree* obj, const CvMat* _sample, const CvMat* _missing_data_mask, bool preprocessed_input )
{
	return obj->predict(_sample, _missing_data_mask, preprocessed_input);
}

CVAPI(const CvMat*) CvDTree_get_var_importance(CvDTree* obj)
{
	return obj->get_var_importance();
}
CVAPI(const CvDTreeNode*) CvDTree_get_root(CvDTree* obj)
{
	return obj->get_root();
}
CVAPI(int) CvDTree_get_pruned_tree_idx(CvDTree* obj)
{
	return obj->get_pruned_tree_idx();
}
CVAPI(CvDTreeTrainData*) CvDTree_get_data(CvDTree* obj)
{
	return obj->get_data();
}

CVAPI(void) CvDTree_clear(CvDTree* obj)
{
	obj->clear();
}
CVAPI(void) CvDTree_read1(CvDTree* obj, CvFileStorage* fs, CvFileNode* node)
{
	obj->read(fs, node);
}
CVAPI(void) CvDTree_read2(CvDTree* obj, CvFileStorage* fs, CvFileNode* node, CvDTreeTrainData* data)
{
	obj->read(fs, node, data);
}
CVAPI(void) CvDTree_write1(CvDTree* obj, CvFileStorage* fs, const char* name)
{
	obj->write(fs, name);
}
CVAPI(void) CvDTree_write2(CvDTree* obj, CvFileStorage* fs)
{
	obj->write(fs);
}

#endif
