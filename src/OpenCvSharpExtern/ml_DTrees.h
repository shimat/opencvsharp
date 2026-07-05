#pragma once

#ifndef NO_ML

// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile
// ReSharper disable CppInconsistentNaming

#include "include_opencv.h"

extern "C"
{
    struct DTrees_Node
    {
        double value;
        int classIdx; 
        int parent; 
        int left;
        int right; 
        int defaultDir; 
        int split; 
    };

    struct DTrees_Split
    {
        int varIdx; 
        int inversed; // bool
        float quality;
        int next;
        float c;
        int subsetOfs;
    };
}

static DTrees_Node c(const cv::ml::DTrees::Node obj)
{
    DTrees_Node ret;
    ret.value = obj.value;
    ret.classIdx = obj.classIdx;
    ret.parent = obj.parent;
    ret.left = obj.left;
    ret.right = obj.right;
    ret.defaultDir = obj.defaultDir;
    ret.split = obj.split;
    return ret;
}

DTrees_Split c(const cv::ml::DTrees::Split obj)
{
    DTrees_Split ret;
    ret.varIdx = obj.varIdx;
    ret.inversed = obj.inversed ? 1 : 0;
    ret.quality = obj.quality;
    ret.next = obj.next;
    ret.c = obj.c;
    ret.subsetOfs = obj.subsetOfs;
    return ret;
}

CVAPI(ExceptionStatus) ml_DTrees_getMaxCategories(cv::ml::DTrees *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMaxCategories();
    });
}
CVAPI(ExceptionStatus) ml_DTrees_setMaxCategories(cv::ml::DTrees *obj, int val)
{
    return cvTry([&] {
        obj->setMaxCategories(val);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getMaxDepth(cv::ml::DTrees *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMaxDepth();
    });
}
CVAPI(ExceptionStatus) ml_DTrees_setMaxDepth(cv::ml::DTrees *obj, int val)
{
    return cvTry([&] {
        obj->setMaxDepth(val);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getMinSampleCount(cv::ml::DTrees *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getMinSampleCount();
    });
}
CVAPI(ExceptionStatus) ml_DTrees_setMinSampleCount(cv::ml::DTrees *obj, int val)
{
    return cvTry([&] {
        obj->setMinSampleCount(val);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getCVFolds(cv::ml::DTrees *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getCVFolds();
    });
}
CVAPI(ExceptionStatus) ml_DTrees_setCVFolds(cv::ml::DTrees *obj, int val)
{
    return cvTry([&] {
        obj->setCVFolds(val);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getUseSurrogates(cv::ml::DTrees *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getUseSurrogates() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) ml_DTrees_setUseSurrogates(cv::ml::DTrees *obj, int val)
{
    return cvTry([&] {
        obj->setUseSurrogates(val != 0);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getUse1SERule(cv::ml::DTrees *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getUse1SERule() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) ml_DTrees_setUse1SERule(cv::ml::DTrees *obj, int val)
{
    return cvTry([&] {
        obj->setUse1SERule(val != 0);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getTruncatePrunedTree(cv::ml::DTrees *obj, int *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getTruncatePrunedTree() ? 1 : 0;
    });
}
CVAPI(ExceptionStatus) ml_DTrees_setTruncatePrunedTree(cv::ml::DTrees *obj, int val)
{
    return cvTry([&] {
        obj->setTruncatePrunedTree(val != 0);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getRegressionAccuracy(cv::ml::DTrees *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getRegressionAccuracy();
    });
}
CVAPI(ExceptionStatus) ml_DTrees_setRegressionAccuracy(cv::ml::DTrees *obj, float val)
{
    return cvTry([&] {
        obj->setRegressionAccuracy(val);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getPriors(cv::ml::DTrees *obj, cv::Mat **returnValue)
{
    return cvTry([&] {
        const auto m = obj->getPriors();
        *returnValue = new cv::Mat(m);
    });
}
CVAPI(ExceptionStatus) ml_DTrees_setPriors(cv::ml::DTrees *obj, cv::Mat *val)
{
    return cvTry([&] {
        obj->setPriors(*val);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getRoots(cv::ml::DTrees *obj, std::vector<int> *result)
{ 
    return cvTry([&] {
        const auto& org = obj->getRoots();

        result->clear();
        for (auto i : org)
        {
            result->push_back(i);
        }
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getNodes(cv::ml::DTrees *obj, std::vector<DTrees_Node> *result)
{
    return cvTry([&] {
        const auto& org = obj->getNodes();

        result->clear();
        for (const auto& i : org)
        {
            result->push_back(c(i));
        }
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getSplits(cv::ml::DTrees *obj, std::vector<DTrees_Split> *result)
{
    return cvTry([&] {
        const auto& org = obj->getSplits();

        result->clear();
        for (const auto& i : org)
        {
            result->push_back(c(i));
        }
    });
}

CVAPI(ExceptionStatus) ml_DTrees_getSubsets(cv::ml::DTrees *obj, std::vector<int> *result)
{
    return cvTry([&] {
        const auto& org = obj->getSubsets();

        result->clear();
        for (auto i : org)
        {
            result->push_back(i);
        }
    });
}

CVAPI(ExceptionStatus) ml_DTrees_create(cv::Ptr<cv::ml::DTrees> **returnValue)
{
    return cvTry([&] {
        const auto  ptr = cv::ml::DTrees::create();
        *returnValue = new cv::Ptr<cv::ml::DTrees>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_Ptr_DTrees_delete(cv::Ptr<cv::ml::DTrees> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) ml_Ptr_DTrees_get(cv::Ptr<cv::ml::DTrees> *obj, cv::ml::DTrees **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) ml_DTrees_load(const char *filePath, cv::Ptr<cv::ml::DTrees> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::Algorithm::load<cv::ml::DTrees>(filePath);
        *returnValue = new cv::Ptr<cv::ml::DTrees>(ptr);
    });
}

CVAPI(ExceptionStatus) ml_DTrees_loadFromString(const char *strModel, cv::Ptr<cv::ml::DTrees> **returnValue)
{
    return cvTry([&] {
        const auto objName = cv::ml::DTrees::create()->getDefaultName();
        const auto  ptr = cv::Algorithm::loadFromString<cv::ml::DTrees>(strModel, objName);
        *returnValue = new cv::Ptr<cv::ml::DTrees>(ptr);
    });
}

#endif // NO_ML
