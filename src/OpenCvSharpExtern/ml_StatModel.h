#ifndef _CPP_ML_STATMODEL_H_
#define _CPP_ML_STATMODEL_H_

#include "include_opencv.h"
using namespace cv::ml;


CVAPI(void) ml_StatModel_clear(StatModel *obj)
{
    obj->clear();
}

CVAPI(int) ml_StatModel_getVarCount(StatModel *obj)
{
    return obj->getVarCount();
}

CVAPI(int) ml_StatModel_empty(StatModel *obj)
{
    return obj->empty() ? 1 : 0;
}

CVAPI(int) ml_StatModel_isTrained(StatModel *obj)
{
    return obj->isTrained() ? 1 : 0;
}

CVAPI(int) ml_StatModel_isClassifier(StatModel *obj)
{
    return obj->isClassifier() ? 1 : 0;
}


CVAPI(int) ml_StatModel_train1(
    StatModel *obj, cv::Ptr<TrainData> *trainData, int flags)
{
    return obj->train(*trainData, flags) ? 1 : 0;
}

CVAPI(int) ml_StatModel_train2(
    StatModel *obj, cv::_InputArray *samples, int layout, cv::_InputArray *responses)
{
    return obj->train(*samples, layout, *responses) ? 1 : 0;
}

CVAPI(float) ml_StatModel_calcError(
    StatModel *obj, cv::Ptr<TrainData> *data, int test, cv::_OutputArray *resp)
{
    return obj->calcError(*data, test != 0, *resp);
}

CVAPI(float) ml_StatModel_predict(
    StatModel *obj, cv::_InputArray *samples, cv::_OutputArray *results, int flags)
{
    return obj->predict(entity(samples), entity(results), flags);
}


CVAPI(void) ml_StatModel_save(StatModel *obj, const char *filename)
{
    return obj->save(cv::String(filename));
}

#endif
