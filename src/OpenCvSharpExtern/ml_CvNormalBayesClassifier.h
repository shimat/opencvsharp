#ifndef _CPP_ML_CVNORMALBAYESCLASSIFIER_H_
#define _CPP_ML_CVNORMALBAYESCLASSIFIER_H_

#include "include_opencv.h"

CVAPI(CvNormalBayesClassifier*) ml_CvNormalBayesClassifier_new1()
{
	return new CvNormalBayesClassifier();
}
CVAPI(CvNormalBayesClassifier*) ml_CvNormalBayesClassifier_new2_CvMat(
    CvMat *trainData, CvMat *responses, CvMat *varIdx, CvMat *sampleIdx )
{
    return new CvNormalBayesClassifier(trainData, responses, varIdx, sampleIdx);
}
CVAPI(CvNormalBayesClassifier*) ml_CvNormalBayesClassifier_new2_Mat(
    cv::Mat *trainData, cv::Mat *responses, cv::Mat *varIdx, cv::Mat *sampleIdx)
{
    return new CvNormalBayesClassifier(*trainData, *responses, entity(varIdx), entity(sampleIdx));
}
CVAPI(void) ml_CvNormalBayesClassifier_destruct(CvNormalBayesClassifier *obj)
{
	delete obj;
}


CVAPI(int) ml_CvNormalBayesClassifier_train_CvMat(
    CvNormalBayesClassifier *obj, CvMat *trainData, CvMat *responses, CvMat *varIdx, 
    CvMat *sampleIdx, int update)
{
    return obj->train(trainData, responses, varIdx, sampleIdx, update != 0) ? 1 : 0;
}
CVAPI(int) ml_CvNormalBayesClassifier_train_Mat(
    CvNormalBayesClassifier *obj, cv::Mat *trainData, cv::Mat *responses, cv::Mat *varIdx,
    cv::Mat *sampleIdx, int update)
{
    return obj->train(
        *trainData, *responses, entity(varIdx), entity(sampleIdx), update != 0) ? 1 : 0;
}

CVAPI(float) ml_CvNormalBayesClassifier_predict_CvMat(
    CvNormalBayesClassifier *obj, CvMat *samples, CvMat *results)
{
	return obj->predict(samples, results);
}
CVAPI(float) ml_CvNormalBayesClassifier_predict(
    CvNormalBayesClassifier *obj, cv::Mat *samples, cv::Mat *results)
{
    return obj->predict(*samples, results);
}

CVAPI(void) ml_CvNormalBayesClassifier_clear(CvNormalBayesClassifier *obj)
{
	obj->clear();
}
CVAPI(void) ml_CvNormalBayesClassifier_write(CvNormalBayesClassifier *obj, CvFileStorage* storage, const char* name)
{
	obj->write(storage, name);
}
CVAPI(void) ml_CvNormalBayesClassifier_read(CvNormalBayesClassifier *obj, CvFileStorage* storage, CvFileNode* node)
{
	obj->read(storage, node);
}

#endif
