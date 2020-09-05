#ifndef _CPP_IMG_HASH_H_
#define _CPP_IMG_HASH_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) img_hash_ImgHashBase_compute(cv::img_hash::ImgHashBase *obj, cv::_InputArray *inputArr, cv::_OutputArray *outputArr)
{
    BEGIN_WRAP
    obj->compute(*inputArr, *outputArr);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_ImgHashBase_compare(cv::img_hash::ImgHashBase *obj, cv::_InputArray *hashOne, cv::_InputArray *hashTwo, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->compare(*hashOne, *hashTwo);
    END_WRAP
}


// AverageHash

CVAPI(ExceptionStatus) img_hash_AverageHash_create(cv::Ptr<cv::img_hash::AverageHash> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::img_hash::AverageHash::create();
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_AverageHash_delete(cv::Ptr<cv::img_hash::AverageHash> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_AverageHash_get(cv::Ptr<cv::img_hash::AverageHash> *ptr, cv::img_hash::AverageHash **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// BlockMeanHash

CVAPI(ExceptionStatus) img_hash_BlockMeanHash_create(const int mode, cv::Ptr<cv::img_hash::BlockMeanHash> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::img_hash::BlockMeanHash::create(mode);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_BlockMeanHash_delete(cv::Ptr<cv::img_hash::BlockMeanHash> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_BlockMeanHash_get(cv::Ptr<cv::img_hash::BlockMeanHash> *ptr, cv::img_hash::BlockMeanHash **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_BlockMeanHash_setMode(cv::img_hash::BlockMeanHash *obj, const int mode)
{
    BEGIN_WRAP
    obj->setMode(mode);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_BlockMeanHash_getMean(cv::img_hash::BlockMeanHash *obj, std::vector<double> *outVec)
{
    BEGIN_WRAP
    const auto mean = obj->getMean();
    outVec->clear();
    outVec->assign(mean.begin(), mean.end());
    END_WRAP
}


// ColorMomentHash

CVAPI(ExceptionStatus) img_hash_ColorMomentHash_create(cv::Ptr<cv::img_hash::ColorMomentHash> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::img_hash::ColorMomentHash::create();
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_ColorMomentHash_delete(cv::Ptr<cv::img_hash::ColorMomentHash> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_ColorMomentHash_get(cv::Ptr<cv::img_hash::ColorMomentHash> *ptr, cv::img_hash::ColorMomentHash **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// MarrHildrethHash

CVAPI(ExceptionStatus) img_hash_MarrHildrethHash_create(const float alpha, const float scale, cv::Ptr<cv::img_hash::MarrHildrethHash> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::img_hash::MarrHildrethHash::create(alpha, scale);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_MarrHildrethHash_delete(cv::Ptr<cv::img_hash::MarrHildrethHash> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_MarrHildrethHash_get(cv::Ptr<cv::img_hash::MarrHildrethHash> *ptr, cv::img_hash::MarrHildrethHash **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_MarrHildrethHash_setKernelParam(cv::img_hash::MarrHildrethHash *obj, const float alpha, const float scale)
{
    BEGIN_WRAP
    obj->setKernelParam(alpha, scale);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_MarrHildrethHash_getAlpha(cv::img_hash::MarrHildrethHash *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getAlpha();
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_MarrHildrethHash_getScale(cv::img_hash::MarrHildrethHash *obj, float *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getScale();
    END_WRAP
}


// PHash

CVAPI(ExceptionStatus) img_hash_PHash_create(cv::Ptr<cv::img_hash::PHash> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::img_hash::PHash::create();
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_PHash_delete(cv::Ptr<cv::img_hash::PHash> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_PHash_get(cv::Ptr<cv::img_hash::PHash> *ptr, cv::img_hash::PHash **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}


// RadialVarianceHash

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_create(const double sigma, const int numOfAngleLine, cv::Ptr<cv::img_hash::RadialVarianceHash> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::img_hash::RadialVarianceHash::create(sigma, numOfAngleLine);
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_RadialVarianceHash_delete(cv::Ptr<cv::img_hash::RadialVarianceHash> *ptr)
{
    BEGIN_WRAP
    delete ptr;
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_Ptr_RadialVarianceHash_get(cv::Ptr<cv::img_hash::RadialVarianceHash> *ptr, cv::img_hash::RadialVarianceHash **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_setNumOfAngleLine(cv::img_hash::RadialVarianceHash *obj, const int value)
{
    BEGIN_WRAP
    obj->setNumOfAngleLine(value);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_setSigma(cv::img_hash::RadialVarianceHash *obj, const double value)
{
    BEGIN_WRAP
    obj->setSigma(value);
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_getNumOfAngleLine(cv::img_hash::RadialVarianceHash *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNumOfAngleLine();
    END_WRAP
}

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_getSigma(cv::img_hash::RadialVarianceHash *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSigma();
    END_WRAP
}

#endif