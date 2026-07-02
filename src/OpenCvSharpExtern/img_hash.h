#pragma once

// OpenCV 5: kept available in every profile (including slim); see include_opencv.h.

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"


CVAPI(ExceptionStatus) img_hash_ImgHashBase_compute(
    cv::img_hash::ImgHashBase *obj,
    const interop::InputArrayProxy* inputArr,
    const interop::OutputArrayProxy* outputArr)
{
    return cvTry([&] {
    obj->compute(InProxy(*inputArr), OutProxy(*outputArr));
    });
}

CVAPI(ExceptionStatus) img_hash_ImgHashBase_compare(
    cv::img_hash::ImgHashBase *obj,
    const interop::InputArrayProxy* hashOne,
    const interop::InputArrayProxy* hashTwo,
    double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->compare(InProxy(*hashOne), InProxy(*hashTwo));
    });
}


// AverageHash

CVAPI(ExceptionStatus) img_hash_AverageHash_create(cv::Ptr<cv::img_hash::AverageHash> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::img_hash::AverageHash::create();
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_AverageHash_delete(cv::Ptr<cv::img_hash::AverageHash> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_AverageHash_get(cv::Ptr<cv::img_hash::AverageHash> *ptr, cv::img_hash::AverageHash **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}


// BlockMeanHash

CVAPI(ExceptionStatus) img_hash_BlockMeanHash_create(const int mode, cv::Ptr<cv::img_hash::BlockMeanHash> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::img_hash::BlockMeanHash::create(mode);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_BlockMeanHash_delete(cv::Ptr<cv::img_hash::BlockMeanHash> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_BlockMeanHash_get(cv::Ptr<cv::img_hash::BlockMeanHash> *ptr, cv::img_hash::BlockMeanHash **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) img_hash_BlockMeanHash_setMode(cv::img_hash::BlockMeanHash *obj, const int mode)
{
    return cvTry([&] {
    obj->setMode(mode);
    });
}

CVAPI(ExceptionStatus) img_hash_BlockMeanHash_getMean(cv::img_hash::BlockMeanHash *obj, std::vector<double> *outVec)
{
    return cvTry([&] {
    const auto mean = obj->getMean();
    outVec->clear();
    outVec->assign(mean.begin(), mean.end());
    });
}


// ColorMomentHash

CVAPI(ExceptionStatus) img_hash_ColorMomentHash_create(cv::Ptr<cv::img_hash::ColorMomentHash> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::img_hash::ColorMomentHash::create();
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_ColorMomentHash_delete(cv::Ptr<cv::img_hash::ColorMomentHash> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_ColorMomentHash_get(cv::Ptr<cv::img_hash::ColorMomentHash> *ptr, cv::img_hash::ColorMomentHash **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}


// MarrHildrethHash

CVAPI(ExceptionStatus) img_hash_MarrHildrethHash_create(
    const float alpha,
    const float scale,
    cv::Ptr<cv::img_hash::MarrHildrethHash> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::img_hash::MarrHildrethHash::create(alpha, scale);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_MarrHildrethHash_delete(cv::Ptr<cv::img_hash::MarrHildrethHash> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_MarrHildrethHash_get(cv::Ptr<cv::img_hash::MarrHildrethHash> *ptr, cv::img_hash::MarrHildrethHash **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) img_hash_MarrHildrethHash_setKernelParam(
    cv::img_hash::MarrHildrethHash *obj,
    const float alpha,
    const float scale)
{
    return cvTry([&] {
    obj->setKernelParam(alpha, scale);
    });
}

CVAPI(ExceptionStatus) img_hash_MarrHildrethHash_getAlpha(cv::img_hash::MarrHildrethHash *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getAlpha();
    });
}

CVAPI(ExceptionStatus) img_hash_MarrHildrethHash_getScale(cv::img_hash::MarrHildrethHash *obj, float *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getScale();
    });
}


// PHash

CVAPI(ExceptionStatus) img_hash_PHash_create(cv::Ptr<cv::img_hash::PHash> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::img_hash::PHash::create();
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_PHash_delete(cv::Ptr<cv::img_hash::PHash> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_PHash_get(cv::Ptr<cv::img_hash::PHash> *ptr, cv::img_hash::PHash **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}


// RadialVarianceHash

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_create(
    const double sigma,
    const int numOfAngleLine,
    cv::Ptr<cv::img_hash::RadialVarianceHash> **returnValue)
{
    return cvTry([&] {
    const auto ptr = cv::img_hash::RadialVarianceHash::create(sigma, numOfAngleLine);
    *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_RadialVarianceHash_delete(cv::Ptr<cv::img_hash::RadialVarianceHash> *ptr)
{
    return cvTry([&] {
    delete ptr;
    });
}

CVAPI(ExceptionStatus) img_hash_Ptr_RadialVarianceHash_get(cv::Ptr<cv::img_hash::RadialVarianceHash> *ptr, cv::img_hash::RadialVarianceHash **returnValue)
{
    return cvTry([&] {
    *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_setNumOfAngleLine(cv::img_hash::RadialVarianceHash *obj, const int value)
{
    return cvTry([&] {
    obj->setNumOfAngleLine(value);
    });
}

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_setSigma(cv::img_hash::RadialVarianceHash *obj, const double value)
{
    return cvTry([&] {
    obj->setSigma(value);
    });
}

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_getNumOfAngleLine(cv::img_hash::RadialVarianceHash *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNumOfAngleLine();
    });
}

CVAPI(ExceptionStatus) img_hash_RadialVarianceHash_getSigma(cv::img_hash::RadialVarianceHash *obj, double *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSigma();
    });
}

// (no NO_CONTRIB guard: kept in every profile for OpenCV 5)
