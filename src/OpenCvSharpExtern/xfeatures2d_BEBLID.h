#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region BEBLID

CVAPI(ExceptionStatus) xfeatures2d_BEBLID_create(
    float scaleFactor, int nBits, cv::Ptr<cv::xfeatures2d::BEBLID> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::BEBLID::create(scaleFactor, nBits);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_BEBLID_delete(cv::Ptr<cv::xfeatures2d::BEBLID> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_BEBLID_get(cv::Ptr<cv::xfeatures2d::BEBLID> *obj, cv::xfeatures2d::BEBLID **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) xfeatures2d_BEBLID_setScaleFactor(cv::xfeatures2d::BEBLID *obj, float val)
{
    return cvTry([&] {
        obj->setScaleFactor(val);
    });
}
CVAPI(ExceptionStatus) xfeatures2d_BEBLID_getScaleFactor(cv::xfeatures2d::BEBLID *obj, float *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->getScaleFactor();
    });
}

#pragma endregion

#pragma region TEBLID

CVAPI(ExceptionStatus) xfeatures2d_TEBLID_create(
    float scaleFactor, int nBits, cv::Ptr<cv::xfeatures2d::TEBLID> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::xfeatures2d::TEBLID::create(scaleFactor, nBits);
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_TEBLID_delete(cv::Ptr<cv::xfeatures2d::TEBLID> *ptr)
{
    return cvTry([&] {
        delete ptr;
    });
}

CVAPI(ExceptionStatus) xfeatures2d_Ptr_TEBLID_get(cv::Ptr<cv::xfeatures2d::TEBLID> *obj, cv::xfeatures2d::TEBLID **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

#pragma endregion

#endif // NO_CONTRIB
