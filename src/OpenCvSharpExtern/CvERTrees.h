/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

#ifndef _CVERTREES_H_
#define _CVERTREES_H_

#ifdef _MSC_VER
#pragma warning(disable: 4251)
#endif
#include <opencv2/ml/ml.hpp>

CVAPI(int) CvERTrees_sizeof()
{
	return sizeof(CvERTrees);
}

CVAPI(CvERTrees*) CvERTrees_construct()
{
	return new CvERTrees();
}  
CVAPI(void) CvERTrees_destruct(CvERTrees* obj)
{
	delete obj;
}

CVAPI(bool) CvERTrees_train1(CvERTrees* obj, const CvMat* _train_data, int _tflag, const CvMat* _responses, 
							const CvMat* _var_idx, const CvMat* _sample_idx, const CvMat* _var_type, const CvMat* _missing_mask, CvRTParams* params)
{
	return obj->train(_train_data, _tflag, _responses, _var_idx, _sample_idx, _var_type, _missing_mask, *params);
}

CVAPI(bool) CvERTrees_train2(CvERTrees* obj, CvMLData* data, CvRTParams* params)
{
	return obj->train(data, *params);
}

class CvERTreesEx : public CvERTrees
{
public:
    virtual bool grow_forest( const CvTermCriteria term_crit )
	{
		return CvRTrees::grow_forest(term_crit);
	}
};

CVAPI(bool) CvERTrees_grow_forest(CvERTrees* obj, const CvTermCriteria term_crit)
{
	CvERTreesEx* ex = reinterpret_cast<CvERTreesEx*>(obj);
	return ex->grow_forest(term_crit);
}

#endif