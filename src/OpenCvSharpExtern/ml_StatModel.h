#ifndef _CPP_ML_STATMODEL_H_
#define _CPP_ML_STATMODEL_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_StatModel_clear(cv::ml::StatModel *obj)
{
    BEGIN_WRAP
    obj->clear();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_StatModel_getVarCount(cv::ml::StatModel *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getVarCount();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_StatModel_empty(cv::ml::StatModel *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->empty() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_StatModel_isTrained(cv::ml::StatModel *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isTrained() ? 1 : 0;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_StatModel_isClassifier(cv::ml::StatModel *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->isClassifier() ? 1 : 0;
    END_WRAP
}

/*CVAPI(ExceptionStatus) ml_StatModel_train1(
    cv::ml::StatModel *obj, cv::Ptr<cv::ml::TrainData> *trainData, int flags, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->train(*trainData, flags) ? 1 : 0;
    END_WRAP
}*/

CVAPI(ExceptionStatus) ml_StatModel_train2(
    cv::ml::StatModel *obj, cv::_InputArray *samples, int layout, cv::_InputArray *responses, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->train(*samples, layout, *responses) ? 1 : 0;
    END_WRAP
}

/*CVAPI(ExceptionStatus) ml_StatModel_calcError(
    cv::ml::StatModel *obj, cv::Ptr<cv::ml::TrainData> *data, int test, cv::_OutputArray *resp, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->calcError(*data, test != 0, *resp);
    END_WRAP
}*/

CVAPI(ExceptionStatus) ml_StatModel_predict(
    cv::ml::StatModel *obj, cv::_InputArray *samples, cv::_OutputArray *results, int flags, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->predict(entity(samples), entity(results), flags);
    END_WRAP
}

#endif
