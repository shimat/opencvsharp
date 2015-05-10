#ifndef _CPP_ML_CVBOOST_H_
#define _CPP_ML_CVBOOST_H_

#include "include_opencv.h"

// Boost

CVAPI(cv::Boost*) ml_Boost_new()
{
	return new cv::Boost();
}    
CVAPI(cv::Boost*) ml_Boost_new_CvMat( 
    CvMat *trainData, int tflag, CvMat *responses, CvMat *varIdx,  CvMat *sampleIdx, 
    CvMat *varType, CvMat *missingMask, cv::BoostParams *params )
{
    cv::BoostParams p = (params == NULL) ? cv::BoostParams() : *params;
	return new cv::Boost(
        trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, p);
}
CVAPI(cv::Boost*) ml_Boost_new_Mat( 
    cv::Mat *trainData, int tflag, cv::Mat *responses, cv::Mat *varIdx, cv::Mat *sampleIdx, 
    cv::Mat *varType, cv::Mat *missingMask, cv::BoostParams *params )
{
    cv::BoostParams p = (params == NULL) ? cv::BoostParams() : *params;
	return new cv::Boost(
        *trainData, tflag, *responses, entity(varIdx), entity(sampleIdx), 
        entity(varType), entity(missingMask), p);
}
CVAPI(void) ml_Boost_delete(cv::Boost* obj)
{
	delete obj;
}

CVAPI(int) ml_Boost_train_CvMat( 
    cv::Boost *obj, CvMat *trainData, int tflag, CvMat *responses, CvMat *varIdx, 
    CvMat *sampleIdx, CvMat *varType,  CvMat *missingMask, cv::BoostParams *params, int update)
{
    cv::BoostParams p = (params == NULL) ? cv::BoostParams() : *params;
	bool ret = obj->train(
        trainData, tflag, responses, varIdx, sampleIdx, varType, missingMask, p, update != 0);
    return ret ? 1 : 0; 
}
CVAPI(int) ml_Boost_train_Mat( 
    cv::Boost *obj, cv::Mat *trainData, int tflag, cv::Mat *responses, cv::Mat *varIdx, 
    cv::Mat *sampleIdx, cv::Mat *varType,  cv::Mat *missingMask, cv::BoostParams *params, int update)
{
    cv::BoostParams p = (params == NULL) ? cv::BoostParams() : *params;
	bool ret = obj->train(
        *trainData, tflag, *responses, entity(varIdx), entity(sampleIdx), entity(varType), 
        entity(missingMask), p, update != 0);
    return ret ? 1 : 0; 
}

CVAPI(float) ml_Boost_predict_CvMat( 
    cv::Boost *obj, CvMat *sample, CvMat *missing, CvMat *weakResponses, CvSlice slice, 
    int rawMode, int returnSum) 
{
	return obj->predict(sample, missing, weakResponses, slice, rawMode != 0, returnSum != 0);
}
CVAPI(float) ml_Boost_predict_Mat( 
    cv::Boost *obj, cv::Mat *sample, cv::Mat *missing, CvSlice slice, 
    int rawMode, int returnSum) 
{
	return obj->predict(*sample, entity(missing), slice, rawMode != 0, returnSum != 0);
}

CVAPI(void) ml_Boost_prune(cv::Boost* obj, CvSlice slice)
{
	obj->prune(slice);
}

CVAPI(void) ml_Boost_clear(cv::Boost* obj)
{
	obj->clear();
}

CVAPI(void) ml_Boost_write(cv::Boost* obj, CvFileStorage* storage, const char* name)
{
	obj->write(storage, name);
}
CVAPI(void) ml_Boost_read(cv::Boost* obj, CvFileStorage* storage, CvFileNode* node)
{
	obj->read(storage, node);
}

CVAPI(CvSeq*) ml_Boost_get_weak_predictors(cv::Boost* obj)
{
	return obj->get_weak_predictors();
}
CVAPI(CvMat*) ml_Boost_get_weights(cv::Boost* obj)
{
	return obj->get_weights();
}
CVAPI(CvMat*) ml_Boost_get_subtree_weights(cv::Boost* obj)
{
	return obj->get_subtree_weights();
}
CVAPI(CvMat*) ml_Boost_get_weak_response(cv::Boost* obj)
{
	return obj->get_weak_response();
}
CVAPI(CvBoostParams*) ml_Boost_get_params(cv::Boost* obj)
{
	return const_cast<CvBoostParams*>(&(obj->get_params()));
}


// BoostParams
CVAPI(cv::BoostParams*) ml_BoostParams_new1()
{
	return new cv::BoostParams();
}
CVAPI(cv::BoostParams*) ml_BoostParams_new2( 
    int boostType, int weakCount, double weightTrimRate, int maxDepth, 
    int useSurrogates, const float* priors )
{
	return new cv::BoostParams(
        boostType, weakCount, weightTrimRate, maxDepth, useSurrogates != 0, priors);
}
CVAPI(void) ml_BoostParams_delete(cv::BoostParams *obj)
{
	delete obj;
}

CVAPI(int*) ml_BoostParams_boost_type(cv::BoostParams *obj)
{
	return &(obj->boost_type);
}
CVAPI(int*) ml_BoostParams_weak_count(cv::BoostParams *obj)
{
	return &(obj->weak_count);
}
CVAPI(int*) ml_BoostParams_split_criteria_get(cv::BoostParams *obj)
{
	return &(obj->split_criteria);
}
CVAPI(double*) ml_BoostParams_weight_trim_rate_get(CvBoostParams *obj)
{
	return &(obj->weight_trim_rate);
}

#endif
