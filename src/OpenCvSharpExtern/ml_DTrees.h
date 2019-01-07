#ifndef _CPP_ML_DTREE_H_
#define _CPP_ML_DTREE_H_

#include "include_opencv.h"


extern "C"
{
    typedef struct DTrees_Node
    {
        double value;
        int classIdx; 
        int parent; 
        int left;
        int right; 
        int defaultDir; 
        int split; 
    } DTrees_Node;

    typedef struct DTrees_Split
    {
        int varIdx; 
        int inversed; // bool
        float quality;
        int next;
        float c;
        int subsetOfs;
    } DTrees_Split;
}

static DTrees_Node c(cv::ml::DTrees::Node obj)
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
static cv::ml::DTrees::Node cpp(DTrees_Node obj)
{
    cv::ml::DTrees::Node ret;
    ret.value = obj.value;
    ret.classIdx = obj.classIdx;
    ret.parent = obj.parent;
    ret.left = obj.left;
    ret.right = obj.right;
    ret.defaultDir = obj.defaultDir;
    ret.split = obj.split;
    return ret;
}

static DTrees_Split c(cv::ml::DTrees::Split obj)
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
static cv::ml::DTrees::Split cpp(DTrees_Split obj)
{
    cv::ml::DTrees::Split ret;
    ret.varIdx = obj.varIdx;
    ret.inversed = obj.inversed != 0;
    ret.quality = obj.quality;
    ret.next = obj.next;
    ret.c = obj.c;
    ret.subsetOfs = obj.subsetOfs;
    return ret;
}


CVAPI(int) ml_DTrees_getMaxCategories(cv::ml::DTrees *obj)
{
    return obj->getMaxCategories();
}
CVAPI(void) ml_DTrees_setMaxCategories(cv::ml::DTrees *obj, int val)
{
    return obj->setMaxCategories(val);
}

CVAPI(int) ml_DTrees_getMaxDepth(cv::ml::DTrees *obj)
{
    return obj->getMaxDepth();
}
CVAPI(void) ml_DTrees_setMaxDepth(cv::ml::DTrees *obj, int val)
{
    return obj->setMaxDepth(val);
}

CVAPI(int) ml_DTrees_getMinSampleCount(cv::ml::DTrees *obj)
{
    return obj->getMinSampleCount();
}
CVAPI(void) ml_DTrees_setMinSampleCount(cv::ml::DTrees *obj, int val)
{
    return obj->setMinSampleCount(val);
}

CVAPI(int) ml_DTrees_getCVFolds(cv::ml::DTrees *obj)
{
    return obj->getCVFolds();
}
CVAPI(void) ml_DTrees_setCVFolds(cv::ml::DTrees *obj, int val)
{
    return obj->setCVFolds(val);
}

CVAPI(int) ml_DTrees_getUseSurrogates(cv::ml::DTrees *obj)
{
    return obj->getUseSurrogates() ? 1 : 0;
}
CVAPI(void) ml_DTrees_setUseSurrogates(cv::ml::DTrees *obj, int val)
{
    return obj->setUseSurrogates(val != 0);
}

CVAPI(int) ml_DTrees_getUse1SERule(cv::ml::DTrees *obj)
{
    return obj->getUse1SERule() ? 1 : 0;
}
CVAPI(void) ml_DTrees_setUse1SERule(cv::ml::DTrees *obj, int val)
{
    return obj->setUse1SERule(val != 0);
}

CVAPI(int) ml_DTrees_getTruncatePrunedTree(cv::ml::DTrees *obj)
{
    return obj->getTruncatePrunedTree() ? 1 : 0;
}
CVAPI(void) ml_DTrees_setTruncatePrunedTree(cv::ml::DTrees *obj, int val)
{
    return obj->setTruncatePrunedTree(val != 0);
}

CVAPI(float) ml_DTrees_getRegressionAccuracy(cv::ml::DTrees *obj)
{
    return obj->getRegressionAccuracy();
}
CVAPI(void) ml_DTrees_setRegressionAccuracy(cv::ml::DTrees *obj, float val)
{
    return obj->setRegressionAccuracy(val);
}

CVAPI(cv::Mat*) ml_DTrees_getPriors(cv::ml::DTrees *obj)
{
    cv::Mat m = obj->getPriors();
    return new cv::Mat(m);
}
CVAPI(void) ml_DTrees_setPriors(cv::ml::DTrees *obj, cv::Mat *val)
{
    obj->setPriors(*val);
}


CVAPI(void) ml_DTrees_getRoots(cv::ml::DTrees *obj, std::vector<int> *result)
{ 
    const std::vector<int> &org = obj->getRoots();

    result->clear();
    for (size_t i = 0; i < org.size(); i++)
    {
        result->push_back(org[i]);
    }
}

CVAPI(void) ml_DTrees_getNodes(cv::ml::DTrees *obj, std::vector<DTrees_Node> *result)
{
    const std::vector<cv::ml::DTrees::Node> &org = obj->getNodes();

    result->clear();
    for (size_t i = 0; i < org.size(); i++)
    {
        result->push_back(c(org[i]));
    }
}

CVAPI(void) ml_DTrees_getSplits(cv::ml::DTrees *obj, std::vector<DTrees_Split> *result)
{
    const std::vector<cv::ml::DTrees::Split> &org = obj->getSplits();

    result->clear();
    for (size_t i = 0; i < org.size(); i++)
    {
        result->push_back(c(org[i]));
    }
}

CVAPI(void) ml_DTrees_getSubsets(cv::ml::DTrees *obj, std::vector<int> *result)
{
    const std::vector<int> &org = obj->getSubsets();

    result->clear();
    for (size_t i = 0; i < org.size(); i++)
    {
        result->push_back(org[i]);
    }
}


CVAPI(cv::Ptr<cv::ml::DTrees>*) ml_DTrees_create()
{
    const auto  ptr = cv::ml::DTrees::create();
    return new cv::Ptr<cv::ml::DTrees>(ptr);
}

CVAPI(void) ml_Ptr_DTrees_delete(cv::Ptr<cv::ml::DTrees> *obj)
{
    delete obj;
}

CVAPI(cv::ml::DTrees*) ml_Ptr_DTrees_get(cv::Ptr<cv::ml::DTrees> *obj)
{
    return obj->get();
}

CVAPI(cv::Ptr<cv::ml::DTrees>*) ml_DTrees_load(const char *filePath)
{
    const auto ptr = cv::Algorithm::load<cv::ml::DTrees>(filePath);
    return new cv::Ptr<cv::ml::DTrees>(ptr);
}

CVAPI(cv::Ptr<cv::ml::DTrees>*) ml_DTrees_loadFromString(const char *strModel)
{
    const auto objname = cv::ml::DTrees::create()->getDefaultName();
    const auto  ptr = cv::Algorithm::loadFromString<cv::ml::DTrees>(strModel, objname);
    return new cv::Ptr<cv::ml::DTrees>(ptr);
}

#endif
