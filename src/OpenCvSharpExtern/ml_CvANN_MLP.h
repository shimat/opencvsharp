#ifndef _CPP_ML_ANN_MLP_H_
#define _CPP_ML_ANN_MLP_H_

#include "include_opencv.h"

// CvANN_MLP_TrainParams
CVAPI(void) ml_ANN_MLP_TrainParams_new1(CvANN_MLP_TrainParams *result)
{
	*result = CvANN_MLP_TrainParams();
}
CVAPI(void) ml_ANN_MLP_TrainParams_new2(
	CvTermCriteria termCrit, int trainMethod, double param1, double param2,
    CvANN_MLP_TrainParams *result)
{
	*result = CvANN_MLP_TrainParams(termCrit, trainMethod, param1, param2);
}

// CvANN_MLP

CVAPI(CvANN_MLP*) ml_CvANN_MLP_new1()
{
    return new CvANN_MLP();
}
CVAPI(CvANN_MLP*) ml_CvANN_MLP_new2_CvMat(CvMat *layerSizes, int activFunc, double fParam1, double fParam2)
{
    return new CvANN_MLP(layerSizes, activFunc, fParam1, fParam2);
}
CVAPI(CvANN_MLP*) ml_CvANN_MLP_new2_Mat(cv::Mat *layerSizes, int activFunc, double fParam1, double fParam2)
{
    return new CvANN_MLP(*layerSizes, activFunc, fParam1, fParam2);
}
CVAPI(void) ml_CvANN_MLP_delete(CvANN_MLP *obj)
{
	delete obj;
}

CVAPI(void) ml_CvANN_MLP_create_CvMat(CvANN_MLP *obj, CvMat *layerSizes, int activFunc,
    double fParam1, double fParam2)
{
    obj->create(layerSizes, activFunc, fParam1, fParam2);
}
CVAPI(void) ml_CvANN_MLP_create_Mat(CvANN_MLP *obj, cv::Mat *layerSizes, int activFunc,
    double fParam1, double fParam2)
{
    obj->create(*layerSizes, activFunc, fParam1, fParam2);
}

CVAPI(int) ml_CvANN_MLP_train_CvMat(CvANN_MLP *obj, CvMat *inputs, CvMat *outputs,
    CvMat *sampleWeights, CvMat *sampleIdx, CvANN_MLP_TrainParams params, int flags )
{
    return obj->train(inputs, outputs, sampleWeights, sampleIdx, params, flags);
}
CVAPI(int) ml_CvANN_MLP_train_Mat(CvANN_MLP *obj, cv::Mat *inputs, cv::Mat *outputs,
    cv::Mat *sampleWeights, cv::Mat *sampleIdx, CvANN_MLP_TrainParams params, int flags)
{
    return obj->train(*inputs, *outputs, entity(sampleWeights), 
        entity(sampleIdx), params, flags);
}

CVAPI(float) ml_CvANN_MLP_predict_CvMat(CvANN_MLP *obj, CvMat *inputs, CvMat *outputs)
{
	return obj->predict(inputs, outputs);
}
CVAPI(float) ml_CvANN_MLP_predict_Mat(CvANN_MLP *obj, cv::Mat *inputs, cv::Mat *outputs)
{
    return obj->predict(*inputs, *outputs);
}


CVAPI(void) ml_CvANN_MLP_clear(CvANN_MLP *obj)
{
	obj->clear();
}

CVAPI(void) ml_CvANN_MLP_read(CvANN_MLP *obj, CvFileStorage *fs, CvFileNode *node)
{
	obj->read(fs, node);
}
CVAPI(void) ml_CvANN_MLP_write(CvANN_MLP *obj, CvFileStorage *storage, const char *name)
{
	obj->write(storage, name);
}

CVAPI(int)  ml_CvANN_MLP_get_layer_count(CvANN_MLP *obj)
{ 
	return obj->get_layer_count();
}
CVAPI(const CvMat*) ml_CvANN_MLP_get_layer_sizes(CvANN_MLP *obj)
{ 
	return obj->get_layer_sizes();
}
CVAPI(double*) ml_CvANN_MLP_get_weights(CvANN_MLP *obj, int layer)
{
	return obj->get_weights(layer);
}

#endif
