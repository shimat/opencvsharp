#pragma once

#ifndef NO_STEREO

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region StereoMatcher

CVAPI(ExceptionStatus) stereo_StereoMatcher_compute(
    cv::StereoMatcher *obj,
    const interop::InputArrayProxy* left,
    const interop::InputArrayProxy* right,
    const interop::OutputArrayProxy* disparity)
{
    return cvTry([&] {
    obj->compute(InProxy(*left), InProxy(*right), OutProxy(*disparity));
    });
}

CVAPI(ExceptionStatus) stereo_StereoMatcher_getMinDisparity(cv::StereoMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMinDisparity();
    });
}
CVAPI(ExceptionStatus) stereo_StereoMatcher_setMinDisparity(cv::StereoMatcher *obj, int value)
{
    return cvTry([&] {
    obj->setMinDisparity(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoMatcher_getNumDisparities(cv::StereoMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getNumDisparities();
    });
}
CVAPI(ExceptionStatus) stereo_StereoMatcher_setNumDisparities(cv::StereoMatcher *obj, int value)
{
    return cvTry([&] {
    obj->setNumDisparities(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoMatcher_getBlockSize(cv::StereoMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getBlockSize();
    });
}
CVAPI(ExceptionStatus) stereo_StereoMatcher_setBlockSize(cv::StereoMatcher *obj, int value)
{
    return cvTry([&] {
    obj->setBlockSize(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoMatcher_getSpeckleWindowSize(cv::StereoMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSpeckleWindowSize();
    });
}
CVAPI(ExceptionStatus) stereo_StereoMatcher_setSpeckleWindowSize(cv::StereoMatcher *obj, int value)
{
    return cvTry([&] {
    obj->setSpeckleWindowSize(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoMatcher_getSpeckleRange(cv::StereoMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSpeckleRange();
    });
}
CVAPI(ExceptionStatus) stereo_StereoMatcher_setSpeckleRange(cv::StereoMatcher *obj, int value)
{
    return cvTry([&] {
    obj->setSpeckleRange(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoMatcher_getDisp12MaxDiff(cv::StereoMatcher *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getDisp12MaxDiff();
    });
}
CVAPI(ExceptionStatus) stereo_StereoMatcher_setDisp12MaxDiff(cv::StereoMatcher *obj, int value)
{
    return cvTry([&] {
    obj->setDisp12MaxDiff(value);
    });
}

#pragma endregion

#pragma region StereoBM

CVAPI(ExceptionStatus) stereo_Ptr_StereoBM_get(cv::Ptr<cv::StereoBM> *obj, cv::StereoBM **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) stereo_Ptr_StereoBM_delete(cv::Ptr<cv::StereoBM> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) stereo_StereoBM_create(
    int numDisparities,
    int blockSize,
    cv::Ptr<cv::StereoBM> **returnValue)
{
    return cvTry([&] {
    const auto obj = cv::StereoBM::create(numDisparities, blockSize);
    *returnValue = clone(obj);
    });
}

CVAPI(ExceptionStatus) stereo_StereoBM_getPreFilterType(cv::StereoBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getPreFilterType();
    });
}
CVAPI(ExceptionStatus) stereo_StereoBM_setPreFilterType(cv::StereoBM *obj, int value)
{
    return cvTry([&] {
    obj->setPreFilterType(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoBM_getPreFilterSize(cv::StereoBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getPreFilterSize();
    });
}
CVAPI(ExceptionStatus) stereo_StereoBM_setPreFilterSize(cv::StereoBM *obj, int value)
{
    return cvTry([&] {
    obj->setPreFilterSize(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoBM_getPreFilterCap(cv::StereoBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getPreFilterCap();
    });
}
CVAPI(ExceptionStatus) stereo_StereoBM_setPreFilterCap(cv::StereoBM *obj, int value)
{
    return cvTry([&] {
    obj->setPreFilterCap(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoBM_getTextureThreshold(cv::StereoBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getTextureThreshold();
    });
}
CVAPI(ExceptionStatus) stereo_StereoBM_setTextureThreshold(cv::StereoBM *obj, int value)
{
    return cvTry([&] {
    obj->setTextureThreshold(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoBM_getUniquenessRatio(cv::StereoBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getUniquenessRatio();
    });
}
CVAPI(ExceptionStatus) stereo_StereoBM_setUniquenessRatio(cv::StereoBM *obj, int value)
{
    return cvTry([&] {
    obj->setUniquenessRatio(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoBM_getSmallerBlockSize(cv::StereoBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getSmallerBlockSize();
    });
}
CVAPI(ExceptionStatus) stereo_StereoBM_setSmallerBlockSize(cv::StereoBM *obj, int value)
{
    return cvTry([&] {
    obj->setSmallerBlockSize(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoBM_getROI1(cv::StereoBM *obj, interop::Rect *returnValue)
{
    return cvTry([&] {
    *returnValue = c(obj->getROI1());
    });
}
CVAPI(ExceptionStatus) stereo_StereoBM_setROI1(cv::StereoBM *obj, interop::Rect value)
{
    return cvTry([&] {
    obj->setROI1(cpp(value));
    });
}

CVAPI(ExceptionStatus) stereo_StereoBM_getROI2(cv::StereoBM *obj, interop::Rect *returnValue)
{
    return cvTry([&] {
    *returnValue = c(obj->getROI2());
    });
}
CVAPI(ExceptionStatus) stereo_StereoBM_setROI2(cv::StereoBM *obj, interop::Rect value)
{
    return cvTry([&] {
    obj->setROI2(cpp(value));
    });
}

#pragma endregion

#pragma region StereoSGBM

CVAPI(ExceptionStatus) stereo_Ptr_StereoSGBM_get(cv::Ptr<cv::StereoSGBM> *obj, cv::StereoSGBM **returnValue)
{
    return cvTry([&] {
    *returnValue = obj->get();
    });
}

CVAPI(ExceptionStatus) stereo_Ptr_StereoSGBM_delete(cv::Ptr<cv::StereoSGBM> *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) stereo_StereoSGBM_create(
    int minDisparity,
    int numDisparities,
    int blockSize,
    int P1,
    int P2,
    int disp12MaxDiff,
    int preFilterCap,
    int uniquenessRatio,
    int speckleWindowSize,
    int speckleRange,
    int mode,
    cv::Ptr<cv::StereoSGBM> **returnValue)
{
    return cvTry([&] {
    const auto obj = cv::StereoSGBM::create(
        minDisparity, numDisparities, blockSize,
        P1, P2, disp12MaxDiff,
        preFilterCap, uniquenessRatio,
        speckleWindowSize, speckleRange, mode);
    *returnValue = new cv::Ptr<cv::StereoSGBM>(obj);
    });
}

CVAPI(ExceptionStatus) stereo_StereoSGBM_getPreFilterCap(cv::StereoSGBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getPreFilterCap();
    });
}
CVAPI(ExceptionStatus) stereo_StereoSGBM_setPreFilterCap(cv::StereoSGBM *obj, int value)
{
    return cvTry([&] {
    obj->setPreFilterCap(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoSGBM_getUniquenessRatio(cv::StereoSGBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getUniquenessRatio();
    });
}
CVAPI(ExceptionStatus) stereo_StereoSGBM_setUniquenessRatio(cv::StereoSGBM *obj, int value)
{
    return cvTry([&] {
    obj->setUniquenessRatio(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoSGBM_getP1(cv::StereoSGBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getP1();
    });
}
CVAPI(ExceptionStatus) stereo_StereoSGBM_setP1(cv::StereoSGBM *obj, int value)
{
    return cvTry([&] {
    obj->setP1(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoSGBM_getP2(cv::StereoSGBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getP2();
    });
}
CVAPI(ExceptionStatus) stereo_StereoSGBM_setP2(cv::StereoSGBM *obj, int value)
{
    return cvTry([&] {
    obj->setP2(value);
    });
}

CVAPI(ExceptionStatus) stereo_StereoSGBM_getMode(cv::StereoSGBM *obj, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getMode();
    });
}
CVAPI(ExceptionStatus) stereo_StereoSGBM_setMode(cv::StereoSGBM *obj, int value)
{
    return cvTry([&] {
    obj->setMode(value);
    });
}

#pragma endregion

#endif // NO_STEREO
