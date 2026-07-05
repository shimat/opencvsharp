#pragma once

#ifndef NO_ML

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ml_StatModel_clear(cv::ml::StatModel *obj)
{
    return cvTry([&] {
        obj->clear();
    });
}

CVAPI(ExceptionStatus) ml_StatModel_getVarCount(cv::ml::StatModel *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getVarCount();
    });
}

CVAPI(ExceptionStatus) ml_StatModel_empty(cv::ml::StatModel *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->empty() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ml_StatModel_isTrained(cv::ml::StatModel *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isTrained() ? 1 : 0;
    });
}

CVAPI(ExceptionStatus) ml_StatModel_isClassifier(cv::ml::StatModel *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->isClassifier() ? 1 : 0;
    });
}

/*CVAPI(ExceptionStatus) ml_StatModel_train1(
    cv::ml::StatModel *obj,
    cv::Ptr<cv::ml::TrainData> *trainData,
    int flags,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->train(*trainData, flags) ? 1 : 0;
    });
}*/

CVAPI(ExceptionStatus) ml_StatModel_train2(
    cv::ml::StatModel *obj,
    const interop::InputArrayProxy* samples,
    int layout,
    const interop::InputArrayProxy* responses,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->train(InProxy(*samples), layout, InProxy(*responses)) ? 1 : 0;
    });
}

/*CVAPI(ExceptionStatus) ml_StatModel_calcError(
    cv::ml::StatModel *obj,
    cv::Ptr<cv::ml::TrainData> *data,
    int test,
    const interop::OutputArrayProxy* resp,
    float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->calcError(*data, test != 0, OutProxy(*resp));
    });
}*/

CVAPI(ExceptionStatus) ml_StatModel_predict(
    cv::ml::StatModel *obj,
    const interop::InputArrayProxy* samples,
    const interop::OutputArrayProxy* results,
    int flags,
    float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->predict(InProxy(*samples), OutProxy(*results), flags);
    });
}

#endif // NO_ML
