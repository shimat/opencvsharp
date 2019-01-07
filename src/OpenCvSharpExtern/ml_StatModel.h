#ifndef _CPP_ML_STATMODEL_H_
#define _CPP_ML_STATMODEL_H_

#include "include_opencv.h"


CVAPI(void) ml_StatModel_clear(cv::ml::StatModel *obj)
{
    obj->clear();
}

CVAPI(int) ml_StatModel_getVarCount(cv::ml::StatModel *obj)
{
    return obj->getVarCount();
}

CVAPI(int) ml_StatModel_empty(cv::ml::StatModel *obj)
{
    return obj->empty() ? 1 : 0;
}

CVAPI(int) ml_StatModel_isTrained(cv::ml::StatModel *obj)
{
    return obj->isTrained() ? 1 : 0;
}

CVAPI(int) ml_StatModel_isClassifier(cv::ml::StatModel *obj)
{
    return obj->isClassifier() ? 1 : 0;
}


CVAPI(int) ml_StatModel_train1(
    cv::ml::StatModel *obj, cv::Ptr<cv::ml::TrainData> *trainData, int flags)
{
    return obj->train(*trainData, flags) ? 1 : 0;
}

CVAPI(int) ml_StatModel_train2(
    cv::ml::StatModel *obj, cv::_InputArray *samples, int layout, cv::_InputArray *responses)
{
    return obj->train(*samples, layout, *responses) ? 1 : 0;
}

CVAPI(float) ml_StatModel_calcError(
    cv::ml::StatModel *obj, cv::Ptr<cv::ml::TrainData> *data, int test, cv::_OutputArray *resp)
{
    return obj->calcError(*data, test != 0, *resp);
}

CVAPI(float) ml_StatModel_predict(
    cv::ml::StatModel *obj, cv::_InputArray *samples, cv::_OutputArray *results, int flags)
{
    return obj->predict(entity(samples), entity(results), flags);
}


CVAPI(void) ml_StatModel_save(cv::ml::StatModel *obj, const char *filename)
{
    return obj->save(cv::String(filename));
}

#endif
