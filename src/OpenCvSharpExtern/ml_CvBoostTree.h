#ifndef _CPP_ML_CVBOOSTTREE_H_
#define _CPP_ML_CVBOOSTTREE_H_

#include "include_opencv.h"

CVAPI(CvBoostTree*) ml_CvBoostTree_new()
{
    return new CvBoostTree();
}
CVAPI(void) ml_CvBoostTree_delete(CvBoostTree *obj)
{
    delete obj;
}
CVAPI(int) ml_CvBoostTree_train(
    CvBoostTree *obj, CvDTreeTrainData* trainData, const CvMat *subsampleIdx, CvBoost* ensemble)
{
    return obj->train(trainData, subsampleIdx, ensemble) ? 1 : 0;
}
CVAPI(void) ml_CvBoostTree_scale(CvBoostTree *obj, double s)
{
    obj->scale(s);
}
CVAPI(void) ml_CvBoostTree_read(CvBoostTree *obj, CvFileStorage* fs, CvFileNode* node, CvBoost* ensemble, CvDTreeTrainData* _data)
{
    obj->read(fs, node, ensemble, _data);
}
CVAPI(void) ml_CvBoostTree_clear(CvBoostTree *obj)
{
    obj->clear();
}

#endif