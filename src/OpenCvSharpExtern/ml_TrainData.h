#pragma once

#ifndef NO_ML

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable once CppInconsistentNaming

#include "include_opencv.h"
#include "ml.h"

CVAPI(ExceptionStatus) ml_TrainData_getLayout(cv::ml::TrainData *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getLayout();
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getNSamples(cv::ml::TrainData *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNSamples();
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getNTrainSamples(cv::ml::TrainData *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNTrainSamples();
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getNTestSamples(cv::ml::TrainData *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNTestSamples();
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getNVars(cv::ml::TrainData *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNVars();
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getNAllVars(cv::ml::TrainData *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getNAllVars();
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getSamples(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getSamples());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getMissing(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getMissing());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getTrainSamples(
    cv::ml::TrainData *obj, int layout, int compressSamples, int compressVars, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getTrainSamples(layout, compressSamples != 0, compressVars != 0));
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getTrainResponses(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getTrainResponses());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getTestSamples(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getTestSamples());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getTestResponses(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getTestResponses());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getResponses(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getResponses());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getVarIdx(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getVarIdx());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getVarType(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getVarType());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getClassLabels(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getClassLabels());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getTrainSampleIdx(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getTrainSampleIdx());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_getTestSampleIdx(cv::ml::TrainData *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        *returnValue = new cv::Mat(obj->getTestSampleIdx());
    });
}

CVAPI(ExceptionStatus) ml_TrainData_setTrainTestSplit(cv::ml::TrainData *obj, int count, int shuffle)
{
    return cvTry([&] {
        obj->setTrainTestSplit(count, shuffle != 0);
    });
}

CVAPI(ExceptionStatus) ml_TrainData_setTrainTestSplitRatio(cv::ml::TrainData *obj, double ratio, int shuffle)
{
    return cvTry([&] {
        obj->setTrainTestSplitRatio(ratio, shuffle != 0);
    });
}

CVAPI(ExceptionStatus) ml_TrainData_shuffleTrainTest(cv::ml::TrainData *obj)
{
    return cvTry([&] {
        obj->shuffleTrainTest();
    });
}

// static

CVAPI(ExceptionStatus) ml_TrainData_create(
    const interop::InputArrayProxy *samples,
    int layout,
    const interop::InputArrayProxy *responses,
    const interop::InputArrayProxy *varIdx,
    const interop::InputArrayProxy *sampleIdx,
    const interop::InputArrayProxy *sampleWeights,
    const interop::InputArrayProxy *varType,
    cv::Ptr<cv::ml::TrainData> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ml::TrainData::create(
            InProxy(*samples), layout, InProxy(*responses),
            InProxy(*varIdx), InProxy(*sampleIdx), InProxy(*sampleWeights), InProxy(*varType));
        *returnValue = new cv::Ptr<cv::ml::TrainData>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_TrainData_loadFromCSV(
    const char *filename,
    int headerLineCount,
    int responseStartIdx,
    int responseEndIdx,
    const char *varTypeSpec,
    char delimiter,
    char missch,
    cv::Ptr<cv::ml::TrainData> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::ml::TrainData::loadFromCSV(
            filename, headerLineCount, responseStartIdx, responseEndIdx, varTypeSpec, delimiter, missch);
        *returnValue = new cv::Ptr<cv::ml::TrainData>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_TrainData_delete(cv::Ptr<cv::ml::TrainData> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_TrainData_get(cv::Ptr<cv::ml::TrainData>* obj, cv::ml::TrainData **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

#endif // NO_ML
