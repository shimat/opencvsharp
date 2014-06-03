#ifndef _CPP_ML_CVERTREES_H_
#define _CPP_ML_CVERTREES_H_

#include "include_opencv.h"

CVAPI(CvERTrees*) ml_CvERTrees_new()
{
	return new CvERTrees();
}  
CVAPI(void) ml_CvERTrees_delete(CvERTrees* obj)
{
	delete obj;
}

CVAPI(int) ml_CvERTrees_train1(
    CvERTrees* obj, CvMat* trainData, int tflag, CvMat* responses,
	CvMat* varIdx, CvMat* sampleIdx, CvMat* varType, CvMat* missingMask, CvRTParams* params)
{
    return obj->train(
        trainData, tflag, responses, varIdx, sampleIdx, varType,
        missingMask, *params) ? 1 : 0;
}

CVAPI(int) ml_CvERTrees_train2(CvERTrees* obj, CvMLData* data, CvRTParams* params)
{
	return obj->train(data, *params) ? 1 : 0;
}

class CvERTreesEx : public CvERTrees
{
public:
    virtual bool grow_forest(const CvTermCriteria termCrit)
	{
        return CvRTrees::grow_forest(termCrit);
	}
};

CVAPI(int) ml_CvERTrees_grow_forest(CvERTrees* obj, const CvTermCriteria termCrit)
{
	CvERTreesEx* ex = reinterpret_cast<CvERTreesEx*>(obj);
    return ex->grow_forest(termCrit) ? 1 : 0;
}

#endif