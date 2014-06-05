#ifndef _CPP_ML_CVRTREES_H_
#define _CPP_ML_CVRTREES_H_

#include "include_opencv.h"

// CvRTParams
CVAPI(CvRTParams*) ml_CvRTParams_new1()
{
	return new CvRTParams();
}
CVAPI(CvRTParams*) ml_CvRTParams_new2(
    int maxDepth, 
    int minSampleCount,
    float regressionAccuracy, 
    int useSurrogates,
    int maxCategories, 
    const float* priors, 
    int calcVarImportance,
    int nactiveVars,
    int maxNumOfTreesInTheForest,
    float forestAccuracy, 
    int termcritType )
{
	return new CvRTParams(
        maxDepth,
        minSampleCount,
        regressionAccuracy,
        useSurrogates != 0,
        maxCategories,
        priors,
        calcVarImportance != 0,
        nactiveVars,
        maxNumOfTreesInTheForest,
        forestAccuracy,
        termcritType);
}
CVAPI(void) ml_CvRTParams_delete(CvRTParams* obj)
{
	delete obj;
}

CVAPI(int) ml_CvRTParams_calc_var_importance_get(CvRTParams* obj)
{
	return obj->calc_var_importance ? 1 : 0;
}
CVAPI(void) ml_CvRTParams_calc_var_importance_set(CvRTParams* obj, int value)
{
	obj->calc_var_importance = (value != 0);
}
CVAPI(int) ml_CvRTParams_nactive_vars_get(CvRTParams* obj)
{
	return obj->nactive_vars;
}
CVAPI(void) ml_CvRTParams_nactive_vars_set(CvRTParams* obj, int value)
{
	obj->nactive_vars = value;
}
CVAPI(CvTermCriteria) ml_CvRTParams_term_crit_get(CvRTParams* obj)
{
	return obj->term_crit;
}
CVAPI(void) ml_CvRTParams_term_crit_set(CvRTParams* obj, CvTermCriteria value)
{
	obj->term_crit = value;
}


// CvRTrees

CVAPI(CvRTrees*) ml_CvRTrees_new()
{
	 return new CvRTrees();
}
CVAPI(void) ml_CvRTrees_delete(CvRTrees *obj)
{
	delete obj;
}

CVAPI(int) ml_CvRTrees_train_CvMat(
    CvRTrees *obj, CvMat *trainData, int tflag, CvMat *responses, CvMat *varIdx,
    CvMat *sampleIdx, CvMat *varType, CvMat *missingMask, CvRTParams* params )
{
	return obj->train(
        trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, *params) ? 1 : 0;
}
CVAPI(int) ml_CvRTrees_train_Mat(
    CvRTrees *obj, cv::Mat *trainData, int tflag, cv::Mat *responses, cv::Mat *varIdx,
    cv::Mat *sampleIdx, cv::Mat *varType, cv::Mat *missingMask, CvRTParams* params)
{
    return obj->train(
        *trainData, tflag, *responses, entity(varIdx), entity(sampleIdx), 
        entity(varType), entity(missingMask), *params) ? 1 : 0;
}
CVAPI(int) ml_CvRTrees_train_MLData(CvRTrees *obj, CvMLData *data, CvRTParams *params)
{
    return obj->train(data, *params) ? 1 : 0;
}

CVAPI(float) ml_CvRTrees_predict_CvMat(CvRTrees *obj, CvMat *sample, CvMat *missing)
{
	return obj->predict(sample, missing);
}
CVAPI(float) ml_CvRTrees_predict_Mat(CvRTrees *obj, cv::Mat *sample, cv::Mat *missing)
{
    return obj->predict(*sample, entity(missing));
}

CVAPI(float) ml_CvRTrees_predict_prob_CvMat(CvRTrees *obj, CvMat *sample, CvMat *missing)
{
    return obj->predict_prob(sample, missing);
}
CVAPI(float) ml_CvRTrees_predict_prob_Mat(CvRTrees *obj, cv::Mat *sample, cv::Mat *missing)
{
    return obj->predict_prob(*sample, entity(missing));
}

CVAPI(void) ml_CvRTrees_clear(CvRTrees *obj)
{
	obj->clear();
}

CVAPI(cv::Mat*) ml_CvRTrees_getVarImportance(CvRTrees *obj)
{
    cv::Mat mat = obj->getVarImportance();
    return new cv::Mat(mat);
}
CVAPI(float) ml_CvRTrees_get_proximity(
    CvRTrees *obj, CvMat *sample1, CvMat *sample2, CvMat *missing1, CvMat *missing2 )
{
	return obj->get_proximity(sample1, sample2, missing1, missing2);
}

CVAPI(void) ml_CvRTrees_read(CvRTrees *obj, CvFileStorage* fs, CvFileNode* node)
{
	obj->read(fs, node);
}
CVAPI(void) ml_CvRTrees_write(CvRTrees *obj, CvFileStorage* fs, const char* name)
{
	obj->write(fs, name);
}

CVAPI(CvMat*) ml_CvRTrees_get_active_var_mask(CvRTrees *obj)
{
	return obj->get_active_var_mask();
}
CVAPI(CvRNG*) ml_CvRTrees_get_rng(CvRTrees *obj)
{
	return obj->get_rng();
}

CVAPI(int) ml_CvRTrees_get_tree_count(CvRTrees *obj)
{
	return obj->get_tree_count();
}
CVAPI(CvForestTree*) ml_CvRTrees_get_tree(CvRTrees *obj, int i)
{
	return obj->get_tree(i);
}


// CvForestTree

CVAPI(CvForestTree*) ml_CvForestTree_new()
{
	return new CvForestTree();
}
CVAPI(void) ml_CvForestTree_delete(CvForestTree* obj)
{
	delete obj;
}
CVAPI(int) ml_CvForestTree_train(CvForestTree* obj, CvDTreeTrainData* _train_data, const CvMat *_subsample_idx, CvRTrees *forest)
{
	return obj->train(_train_data, _subsample_idx, forest) ? 1 : 0;
}

CVAPI(int) ml_CvForestTree_get_var_count(CvForestTree* obj)
{
	return obj->get_var_count();
}
CVAPI(void) ml_CvForestTree_read(CvForestTree* obj, CvFileStorage* fs, CvFileNode* node, CvRTrees *forest, CvDTreeTrainData* _data)
{
	obj->read(fs, node, forest, _data);
}

#endif
