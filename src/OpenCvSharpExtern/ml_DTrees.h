#pragma once

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
    BEGIN_WRAP
    *returnValue = obj->getMaxCategories();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_DTrees_setMaxCategories(cv::ml::DTrees *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxCategories(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getMaxDepth(cv::ml::DTrees *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMaxDepth();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_DTrees_setMaxDepth(cv::ml::DTrees *obj, int val)
{
    BEGIN_WRAP
    obj->setMaxDepth(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getMinSampleCount(cv::ml::DTrees *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinSampleCount();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_DTrees_setMinSampleCount(cv::ml::DTrees *obj, int val)
{
    BEGIN_WRAP
    obj->setMinSampleCount(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getCVFolds(cv::ml::DTrees *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getCVFolds();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_DTrees_setCVFolds(cv::ml::DTrees *obj, int val)
{
    BEGIN_WRAP
    obj->setCVFolds(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getUseSurrogates(cv::ml::DTrees *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getUseSurrogates() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) ml_DTrees_setUseSurrogates(cv::ml::DTrees *obj, int val)
{
    BEGIN_WRAP
    obj->setUseSurrogates(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getUse1SERule(cv::ml::DTrees *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getUse1SERule() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) ml_DTrees_setUse1SERule(cv::ml::DTrees *obj, int val)
{
    BEGIN_WRAP
    obj->setUse1SERule(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getTruncatePrunedTree(cv::ml::DTrees *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getTruncatePrunedTree() ? 1 : 0;
    END_WRAP
}
CVAPI(ExceptionStatus) ml_DTrees_setTruncatePrunedTree(cv::ml::DTrees *obj, int val)
{
    BEGIN_WRAP
    obj->setTruncatePrunedTree(val != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getRegressionAccuracy(cv::ml::DTrees *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getRegressionAccuracy();
    END_WRAP
}
CVAPI(ExceptionStatus) ml_DTrees_setRegressionAccuracy(cv::ml::DTrees *obj, float val)
{
    BEGIN_WRAP
    obj->setRegressionAccuracy(val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getPriors(cv::ml::DTrees *obj, cv::Mat **returnValue)
{
    BEGIN_WRAP
    const auto m = obj->getPriors();
    *returnValue = new cv::Mat(m);
    END_WRAP
}
CVAPI(ExceptionStatus) ml_DTrees_setPriors(cv::ml::DTrees *obj, cv::Mat *val)
{
    BEGIN_WRAP
    obj->setPriors(*val);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getRoots(cv::ml::DTrees *obj, std::vector<int> *result)
{ 
    BEGIN_WRAP
    const auto& org = obj->getRoots();

    result->clear();
    for (auto i : org)
    {
        result->push_back(i);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getNodes(cv::ml::DTrees *obj, std::vector<DTrees_Node> *result)
{
    BEGIN_WRAP
    const auto& org = obj->getNodes();

    result->clear();
    for (const auto& i : org)
    {
        result->push_back(c(i));
    }
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getSplits(cv::ml::DTrees *obj, std::vector<DTrees_Split> *result)
{
    BEGIN_WRAP
    const auto& org = obj->getSplits();

    result->clear();
    for (const auto& i : org)
    {
        result->push_back(c(i));
    }
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_getSubsets(cv::ml::DTrees *obj, std::vector<int> *result)
{
    BEGIN_WRAP
    const auto& org = obj->getSubsets();

    result->clear();
    for (auto i : org)
    {
        result->push_back(i);
    }
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_create(cv::Ptr<cv::ml::DTrees> **returnValue)
{
    BEGIN_WRAP
    const auto  ptr = cv::ml::DTrees::create();
    *returnValue = new cv::Ptr<cv::ml::DTrees>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_DTrees_delete(cv::Ptr<cv::ml::DTrees> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ml_Ptr_DTrees_get(cv::Ptr<cv::ml::DTrees> *obj, cv::ml::DTrees **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_load(const char *filePath, cv::Ptr<cv::ml::DTrees> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::Algorithm::load<cv::ml::DTrees>(filePath);
    *returnValue = new cv::Ptr<cv::ml::DTrees>(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) ml_DTrees_loadFromString(const char *strModel, cv::Ptr<cv::ml::DTrees> **returnValue)
{
    BEGIN_WRAP
    const auto objName = cv::ml::DTrees::create()->getDefaultName();
    const auto  ptr = cv::Algorithm::loadFromString<cv::ml::DTrees>(strModel, objName);
    *returnValue = new cv::Ptr<cv::ml::DTrees>(ptr);
    END_WRAP
}

