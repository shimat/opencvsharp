/*CvANN_MLP
  *(C) 2008-2014 shimat
  *This code is licenced under the LGPL.
 */

#ifndef _CPP_ML_ANN_MLP_H_
#define _CPP_ML_ANN_MLP_H_

#include "include_opencv.h"


// CvANN_MLP_TrainParams
CVAPI(cv::ANN_MLP_TrainParams) ml_ANN_MLP_TrainParams_new1()
{
	return cv::ANN_MLP_TrainParams();
}
CVAPI(cv::ANN_MLP_TrainParams) ml_ANN_MLP_TrainParams_new2(
	CvTermCriteria termCrit, int trainMethod, double param1, double param2 )
{
	return cv::ANN_MLP_TrainParams(termCrit, trainMethod, param1, param2);
}


// CvANN_MLP (cv::NeuralNet_MLP)

CVAPI(cv::NeuralNet_MLP*) ml_NeuralNet_MLP_new1()
{
    return new cv::NeuralNet_MLP();
}
CVAPI(cv::NeuralNet_MLP*) ml_NeuralNet_MLP_new2_CvMat(CvMat *layerSizes, int activFunc, double fParam1, double fParam2)
{
    return new cv::NeuralNet_MLP(layerSizes, activFunc, fParam1, fParam2);
}
CVAPI(cv::NeuralNet_MLP*) ml_NeuralNet_MLP_new2_Mat(cv::Mat *layerSizes, int activFunc, double fParam1, double fParam2)
{
    return new cv::NeuralNet_MLP(*layerSizes, activFunc, fParam1, fParam2);
}
CVAPI(void) ml_NeuralNet_MLP_delete(cv::NeuralNet_MLP *obj)
{
	delete obj;
}

CVAPI(void) ml_NeuralNet_MLP_create_CvMat(cv::NeuralNet_MLP *obj, CvMat *layerSizes, int activFunc,
    double fParam1, double fParam2)
{
    obj->create(layerSizes, activFunc, fParam1, fParam2);
}
CVAPI(void) ml_NeuralNet_MLP_create_Mat(cv::NeuralNet_MLP *obj, cv::Mat *layerSizes, int activFunc,
    double fParam1, double fParam2)
{
    obj->create(*layerSizes, activFunc, fParam1, fParam2);
}

CVAPI(int) ml_NeuralNet_MLP_train_CvMat(cv::NeuralNet_MLP *obj, CvMat *inputs, CvMat *outputs,
    CvMat *sampleWeights, CvMat *sampleIdx, cv::ANN_MLP_TrainParams params, int flags )
{
    return obj->train(inputs, outputs, sampleWeights, sampleIdx, params, flags);
}
CVAPI(int) ml_NeuralNet_MLP_train_Mat(cv::NeuralNet_MLP *obj, cv::Mat *inputs, cv::Mat *outputs,
    cv::Mat *sampleWeights, cv::Mat *sampleIdx, cv::ANN_MLP_TrainParams params, int flags)
{
    return obj->train(*inputs, *outputs, entity(sampleWeights), 
        entity(sampleIdx), params, flags);
}

CVAPI(float) ml_NeuralNet_MLP_predict_CvMat(cv::NeuralNet_MLP *obj, CvMat *inputs, CvMat *outputs)
{
	return obj->predict(inputs, outputs);
}
CVAPI(float) ml_NeuralNet_MLP_predict_Mat(cv::NeuralNet_MLP *obj, cv::Mat *inputs, cv::Mat *outputs)
{
    return obj->predict(*inputs, *outputs);
}


CVAPI(void) ml_NeuralNet_MLP_clear(cv::NeuralNet_MLP *obj)
{
	obj->clear();
}

CVAPI(void) ml_NeuralNet_MLP_read(cv::NeuralNet_MLP *obj, CvFileStorage *fs, CvFileNode *node)
{
	obj->read(fs, node);
}
CVAPI(void) ml_NeuralNet_MLP_write(cv::NeuralNet_MLP *obj, CvFileStorage *storage, const char *name)
{
	obj->write(storage, name);
}

CVAPI(int)  ml_NeuralNet_MLP_get_layer_count(cv::NeuralNet_MLP *obj)
{ 
	return obj->get_layer_count();
}
CVAPI(const CvMat*) ml_NeuralNet_MLP_get_layer_sizes(cv::NeuralNet_MLP *obj)
{ 
	return obj->get_layer_sizes();
}
CVAPI(double*) ml_NeuralNet_MLP_get_weights(cv::NeuralNet_MLP *obj, int layer)
{
	return obj->get_weights(layer);
}

#endif
