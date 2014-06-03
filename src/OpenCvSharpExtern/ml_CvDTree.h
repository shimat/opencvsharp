#ifndef _CPP_ML_CVDTREE_H_
#define _CPP_ML_CVDTREE_H_

#include "include_opencv.h"

// CvDTreeParams
CVAPI(CvDTreeParams*) ml_CvDTreeParams_new1()
{
    return new CvDTreeParams();
}
CVAPI(CvDTreeParams*) ml_CvDTreeParams_new2(
    int maxDepth, int minSampleCount, float regressionAccuracy, int useSurrogates,
    int maxCategories, int cvFolds, int use1seRule, int truncatePrunedTree, float* priors)
{
    return new CvDTreeParams(
        maxDepth, minSampleCount, regressionAccuracy, useSurrogates != 0, 
        maxCategories, cvFolds, use1seRule != 0, truncatePrunedTree != 0, priors);
}
CVAPI(void) ml_CvDTreeParams_delete(CvDTreeParams *p)
{
	delete p;
}

CVAPI(int) ml_CvDTreeParams_max_categories_get(CvDTreeParams *p)
{
	return p->max_categories;
}
CVAPI(void) ml_CvDTreeParams_max_categories_set(CvDTreeParams *p, int value)
{
	p->max_categories = value;
}
CVAPI(int) ml_CvDTreeParams_max_depth_get(CvDTreeParams *p)
{
	return p->max_depth;
}
CVAPI(void) ml_CvDTreeParams_max_depth_set(CvDTreeParams *p, int value)
{
	p->max_depth = value;
}
CVAPI(int) ml_CvDTreeParams_min_sample_count_get(CvDTreeParams *p)
{
	return p->min_sample_count;
}
CVAPI(void) ml_CvDTreeParams_min_sample_count_set(CvDTreeParams *p, int value)
{
	p->min_sample_count = value;
}
CVAPI(int) ml_CvDTreeParams_cv_folds_get(CvDTreeParams *p)
{
	return p->cv_folds;
}
CVAPI(void) ml_CvDTreeParams_cv_folds_set(CvDTreeParams *p, int value)
{
	p->cv_folds = value;
}
CVAPI(int) ml_CvDTreeParams_use_surrogates_get(CvDTreeParams *p)
{
	return p->use_surrogates ? 1 : 0;
}
CVAPI(void) ml_CvDTreeParams_use_surrogates_set(CvDTreeParams *p, int value)
{
	p->use_surrogates = (value != 0);
}
CVAPI(int) ml_CvDTreeParams_use_1se_rule_get(CvDTreeParams *p)
{
	return p->use_1se_rule ? 1 : 0;
}
CVAPI(void) ml_CvDTreeParams_use_1se_rule_set(CvDTreeParams *p, int value)
{
	p->use_1se_rule = (value != 0);
}
CVAPI(int) ml_CvDTreeParams_truncate_pruned_tree_get(CvDTreeParams *p)
{
	return p->truncate_pruned_tree ? 1 : 0;
}
CVAPI(void) ml_CvDTreeParams_truncate_pruned_tree_set(CvDTreeParams *p, int value)
{
	p->truncate_pruned_tree = (value != 0);
}
CVAPI(float) ml_CvDTreeParams_regression_accuracy_get(CvDTreeParams *p)
{
	return p->regression_accuracy;
}
CVAPI(void) ml_CvDTreeParams_regression_accuracy_set(CvDTreeParams *p, float value)
{
	p->regression_accuracy = value;
}
CVAPI(const float*) CvDTreeParams_priors_get(CvDTreeParams *p)
{
	return p->priors;
}
CVAPI(void) ml_CvDTreeParams_priors_set(CvDTreeParams *p, float *value)
{
	p->priors = value;
}


// CvDTreeTrainData
CVAPI(CvDTreeTrainData*) ml_CvDTreeTrainData_new1()
{
	return new CvDTreeTrainData();
}
CVAPI(CvDTreeTrainData*) ml_CvDTreeTrainData_new2(
    CvMat *trainData, int tflag, CvMat *responses,
	CvMat *varIdx, CvMat *sampleIdx, CvMat *varType, CvMat *missingMask, 
    CvDTreeParams *params, int shared, int addLabels)
{
    return new CvDTreeTrainData(trainData, tflag, responses, varIdx, sampleIdx,
        varType, missingMask, *params, shared != 0, addLabels != 0);
}
CVAPI(void) ml_CvDTreeTrainData_delete (CvDTreeTrainData* obj)
{
	delete obj;
}

CVAPI(void) ml_CvDTreeTrainData_set_data(
    CvDTreeTrainData* obj, CvMat *trainData, int tflag, CvMat *responses,
    CvMat *varIdx, CvMat *sampleIdx, CvMat *varType, CvMat *missingMask,
    CvDTreeParams *param, int shared, int addLabels, int updateData)
{
    obj->set_data(trainData, tflag, responses, varIdx, sampleIdx, varType,
        missingMask, *param, shared != 0, addLabels != 0, updateData != 0);
}
CVAPI(void) ml_CvDTreeTrainData_get_vectors(
    CvDTreeTrainData* obj, CvMat *subsampleIdx, float* values, uchar* missing, 
    float* responses, int getClassIdx)
{
    return obj->get_vectors(subsampleIdx, values, missing, responses, getClassIdx != 0);
}
CVAPI(CvDTreeNode*) ml_CvDTreeTrainData_subsample_data(
    CvDTreeTrainData* obj, CvMat *subsampleIdx)
{
    return obj->subsample_data(subsampleIdx);
}
CVAPI(void) ml_CvDTreeTrainData_write_params(CvDTreeTrainData* obj, CvFileStorage* fs)
{
	obj->write_params(fs);
}
CVAPI(void) ml_CvDTreeTrainData_read_params(
    CvDTreeTrainData* obj, CvFileStorage* fs, CvFileNode* node)
{
	obj->read_params(fs, node);
}
CVAPI(void) ml_CvDTreeTrainData_clear(CvDTreeTrainData* obj)
{
	obj->clear();
}
CVAPI(int) ml_CvDTreeTrainData_get_num_classes(CvDTreeTrainData* obj) 
{
	return obj->get_num_classes();
}
CVAPI(int) ml_CvDTreeTrainData_get_var_type(CvDTreeTrainData* obj, int vi)
{
	return obj->get_var_type(vi);
}
CVAPI(int) ml_CvDTreeTrainData_get_work_var_count(CvDTreeTrainData* obj) 
{
	return obj->get_work_var_count();
}
CVAPI(const int*) ml_CvDTreeTrainData_get_class_labels(
    CvDTreeTrainData* obj, CvDTreeNode* n, int* labelsBuf )
{
    return obj->get_class_labels(n, labelsBuf);
}
CVAPI(const float*) ml_CvDTreeTrainData_get_ord_responses(
    CvDTreeTrainData* obj, CvDTreeNode* n, float* valuesBuf, int* sampleIndicesBuf )
{
    return obj->get_ord_responses(n, valuesBuf, sampleIndicesBuf);
}
CVAPI(const int*) ml_CvDTreeTrainData_get_cv_labels(
    CvDTreeTrainData* obj, CvDTreeNode* n, int* labelsBuf)
{
    return obj->get_cv_labels(n, labelsBuf);
}
CVAPI(const int*) ml_CvDTreeTrainData_get_cat_var_data(
    CvDTreeTrainData* obj, CvDTreeNode* n, int vi, int* catValuesBuf)
{
    return obj->get_cat_var_data(n, vi, catValuesBuf);
}
CVAPI(void) ml_CvDTreeTrainData_get_ord_var_data(CvDTreeTrainData* obj, CvDTreeNode* n, int vi, 
		float* ordValuesBuf, int* sortedIndicesBuf, const float** ordValues, 
        const int** sortedIndices, int* sampleIndicesBuf)
{
    return obj->get_ord_var_data(n, vi, ordValuesBuf, sortedIndicesBuf, ordValues, 
        sortedIndices, sampleIndicesBuf);
}
CVAPI(int) ml_CvDTreeTrainData_get_child_buf_idx(CvDTreeTrainData* obj, CvDTreeNode* n)
{
	return obj->get_child_buf_idx(n);
}

CVAPI(int) ml_CvDTreeTrainData_set_params(CvDTreeTrainData* obj, CvDTreeParams *params)
{
	return obj->set_params(*params) ? 1 : 0;
}
CVAPI(CvDTreeNode*) ml_CvDTreeTrainData_new_node(
    CvDTreeTrainData* obj, CvDTreeNode* parent, int count, int storageIdx, int offset )
{
    return obj->new_node(parent, count, storageIdx, offset);
}
CVAPI(CvDTreeSplit*) ml_CvDTreeTrainData_new_split_ord(
    CvDTreeTrainData* obj, int vi, float cmpVal, int splitPoint, int inversed, float quality )
{
    return obj->new_split_ord(vi, cmpVal, splitPoint, inversed, quality);
}
CVAPI(CvDTreeSplit*) ml_CvDTreeTrainData_new_split_cat(
    CvDTreeTrainData* obj, int vi, float quality )
{
	return obj->new_split_cat(vi, quality);
}
CVAPI(void) ml_CvDTreeTrainData_free_node_data(CvDTreeTrainData* obj, CvDTreeNode* node)
{
	obj->free_node_data(node);
}
CVAPI(void) ml_CvDTreeTrainData_free_train_data(CvDTreeTrainData* obj)
{
	obj->free_train_data();
}
CVAPI(void) ml_CvDTreeTrainData_free_node(CvDTreeTrainData* obj, CvDTreeNode* node)
{
	obj->free_node(node);
}
    ////////////////////////////////////

CVAPI(int) ml_CvDTreeTrainData_sample_count(CvDTreeTrainData* obj)
{
	return obj->sample_count;
}
CVAPI(int) ml_CvDTreeTrainData_var_all(CvDTreeTrainData* obj)
{
	return obj->var_all;
}
CVAPI(int) ml_CvDTreeTrainData_var_count(CvDTreeTrainData* obj)
{
	return obj->var_count;
}
CVAPI(int) ml_CvDTreeTrainData_max_c_count(CvDTreeTrainData* obj)
{
	return obj->max_c_count;
}
CVAPI(int) ml_CvDTreeTrainData_ord_var_count(CvDTreeTrainData* obj)
{
	return obj->ord_var_count;
}
CVAPI(int) ml_CvDTreeTrainData_cat_var_count(CvDTreeTrainData* obj)
{
	return obj->cat_var_count;
}
CVAPI(int) ml_CvDTreeTrainData_have_labels(CvDTreeTrainData* obj)
{
	return obj->have_labels ? 1 : 0;
}
CVAPI(int) ml_CvDTreeTrainData_have_priors(CvDTreeTrainData* obj)
{
	return obj->have_priors ? 1 : 0;
}
CVAPI(int) ml_CvDTreeTrainData_is_classifier(CvDTreeTrainData* obj)
{
	return obj->is_classifier ? 1 : 0;
}
CVAPI(int) ml_CvDTreeTrainData_buf_count(CvDTreeTrainData* obj)
{
	return obj->buf_count;
}
CVAPI(int) ml_CvDTreeTrainData_buf_size(CvDTreeTrainData* obj)
{
	return obj->buf_size;
}
CVAPI(int) ml_CvDTreeTrainData_shared(CvDTreeTrainData* obj)
{
	return obj->shared ? 1 : 0;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_cat_count(CvDTreeTrainData* obj)
{
	return obj->cat_count;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_cat_ofs(CvDTreeTrainData* obj)
{
	return obj->cat_ofs;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_cat_map(CvDTreeTrainData* obj)
{
	return obj->cat_map;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_counts(CvDTreeTrainData* obj)
{
	return obj->counts;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_buf(CvDTreeTrainData* obj)
{
	return obj->buf;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_direction(CvDTreeTrainData* obj)
{
	return obj->direction;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_split_buf(CvDTreeTrainData* obj)
{
	return obj->split_buf;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_var_idx(CvDTreeTrainData* obj)
{
	return obj->var_idx;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_var_type(CvDTreeTrainData* obj)
{
	return obj->var_type;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_priors(CvDTreeTrainData* obj)
{
	return obj->priors;
}
CVAPI(CvMat*) ml_CvDTreeTrainData_priors_mult(CvDTreeTrainData* obj)
{
	return obj->priors_mult;
}
CVAPI(void) ml_CvDTreeTrainData_params(CvDTreeTrainData* obj, CvDTreeParams *p)
{
	*p = obj->params;
}
CVAPI(CvMemStorage*) ml_CvDTreeTrainData_tree_storage(CvDTreeTrainData* obj)
{
	return obj->tree_storage;
}
CVAPI(CvMemStorage*) ml_CvDTreeTrainData_temp_storage(CvDTreeTrainData* obj)
{
	return obj->temp_storage;
}
CVAPI(CvDTreeNode*) ml_CvDTreeTrainData_data_root(CvDTreeTrainData* obj)
{
	return obj->data_root;
}
CVAPI(CvSet*) ml_CvDTreeTrainData_node_heap(CvDTreeTrainData* obj)
{
	return obj->node_heap;
}
CVAPI(CvSet*) ml_CvDTreeTrainData_split_heap(CvDTreeTrainData* obj)
{
	return obj->split_heap;
}
CVAPI(CvSet*) ml_CvDTreeTrainData_cv_heap(CvDTreeTrainData* obj)
{
	return obj->cv_heap;
}
CVAPI(CvSet*) ml_CvDTreeTrainData_nv_heap(CvDTreeTrainData* obj)
{
	return obj->nv_heap;
}
CVAPI(uint64) ml_CvDTreeTrainData_rng(CvDTreeTrainData* obj)
{
	return obj->rng->state;
}



// CvDTree	
CVAPI(CvDTree*) ml_CvDTree_new()
{
	return new CvDTree();
}
CVAPI(void) ml_CvDTree_destruct(CvDTree* obj)
{
	delete obj;
}

CVAPI(int) ml_CvDTree_train1(
    CvDTree* obj, CvMat *trainData, int tflag, CvMat *responses,
	CvMat *varIdx, CvMat *sampleIdx, CvMat *varType, CvMat *missingMask, 
    CvDTreeParams *params )
{
	bool ret = obj->train(
        trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, *params);
    return ret ? 1 : 0;
}
CVAPI(int) ml_CvDTree_train2(
    CvDTree* obj, CvDTreeTrainData* trainData, CvMat *subsampleIdx)
{
    return obj->train(trainData, subsampleIdx) ? 1 : 0;
}
CVAPI(int) ml_CvDTree_train3(
    CvDTree* obj, CvMLData* trainData, CvDTreeParams *params)
{
    return obj->train(trainData, *params) ? 1 : 0;
}
CVAPI(int) ml_CvDTree_train_Mat(
    CvDTree* obj, cv::Mat *trainData, int tflag, cv::Mat *responses,
    cv::Mat *varIdx, cv::Mat *sampleIdx, cv::Mat *varType,
    cv::Mat *missingDataMask, CvDTreeParams *params)
{
    return obj->train(*trainData, tflag, *responses, entity(varIdx), entity(sampleIdx),
        entity(varType), entity(missingDataMask), *params) ? 1 : 0;
}

CVAPI(CvDTreeNode*) ml_CvDTree_predict_CvMat(CvDTree* obj,
    CvMat *sample, CvMat *missingDataMask, int preprocessedInput)
{
    return obj->predict(sample, missingDataMask, preprocessedInput != 0);
}
CVAPI(CvDTreeNode*) ml_CvDTree_predict_Mat(CvDTree* obj,
    cv::Mat *sample, cv::Mat *missingDataMask, int preprocessedInput)
{
    return obj->predict(*sample, entity(missingDataMask), preprocessedInput != 0);
}

CVAPI(cv::Mat*) ml_CvDTree_getVarImportance(CvDTree* obj)
{
    cv::Mat mat = obj->getVarImportance();
    return new cv::Mat(mat);
}
CVAPI(const CvDTreeNode*) ml_CvDTree_get_root(CvDTree* obj)
{
	return obj->get_root();
}
CVAPI(int) ml_CvDTree_get_pruned_tree_idx(CvDTree* obj)
{
	return obj->get_pruned_tree_idx();
}
CVAPI(CvDTreeTrainData*) ml_CvDTree_get_data(CvDTree* obj)
{
	return obj->get_data();
}

CVAPI(void) ml_CvDTree_clear(CvDTree* obj)
{
	obj->clear();
}
CVAPI(void) ml_CvDTree_read1(CvDTree* obj, CvFileStorage* fs, CvFileNode* node)
{
	obj->read(fs, node);
}
CVAPI(void) ml_CvDTree_read2(CvDTree* obj, CvFileStorage* fs, CvFileNode* node, CvDTreeTrainData* data)
{
	obj->read(fs, node, data);
}
CVAPI(void) ml_CvDTree_write1(CvDTree* obj, CvFileStorage* fs, const char* name)
{
	obj->write(fs, name);
}
CVAPI(void) ml_CvDTree_write2(CvDTree* obj, CvFileStorage* fs)
{
	obj->write(fs);
}

#endif
