#pragma once

#ifndef NO_CALIB3D

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#pragma region StereoMatcher

CVAPI(ExceptionStatus) calib3d_StereoMatcher_compute(
    cv::StereoMatcher *obj, cv::_InputArray *left, cv::_InputArray *right, cv::_OutputArray *disparity)
{
    BEGIN_WRAP
    obj->compute(*left, *right, *disparity);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoMatcher_getMinDisparity(
    cv::StereoMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMinDisparity();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoMatcher_setMinDisparity(
    cv::StereoMatcher *obj, int value)
{
    BEGIN_WRAP
    obj->setMinDisparity(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoMatcher_getNumDisparities(
    cv::StereoMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getNumDisparities();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoMatcher_setNumDisparities(
    cv::StereoMatcher *obj, int value)
{
    BEGIN_WRAP
    obj->setNumDisparities(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoMatcher_getBlockSize(
    cv::StereoMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getBlockSize();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoMatcher_setBlockSize(
    cv::StereoMatcher *obj, int value)
{
    BEGIN_WRAP
    obj->setBlockSize(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoMatcher_getSpeckleWindowSize(
    cv::StereoMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSpeckleWindowSize();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoMatcher_setSpeckleWindowSize(
    cv::StereoMatcher *obj, int value)
{
    BEGIN_WRAP
    obj->setSpeckleWindowSize(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoMatcher_getSpeckleRange(
    cv::StereoMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSpeckleRange();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoMatcher_setSpeckleRange(
    cv::StereoMatcher *obj, int value)
{
    BEGIN_WRAP
    obj->setSpeckleRange(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoMatcher_getDisp12MaxDiff(
    cv::StereoMatcher *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getDisp12MaxDiff();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoMatcher_setDisp12MaxDiff(
    cv::StereoMatcher *obj, int value)
{
    BEGIN_WRAP
    obj->setDisp12MaxDiff(value);
    END_WRAP
}

#pragma endregion

#pragma region StereoBM

CVAPI(ExceptionStatus) calib3d_Ptr_StereoBM_get(
    cv::Ptr<cv::StereoBM> *obj, cv::StereoBM **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_Ptr_StereoBM_delete(
    cv::Ptr<cv::StereoBM> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoBM_create(
    int numDisparities, int blockSize, cv::Ptr<cv::StereoBM> **returnValue)
{
    BEGIN_WRAP
    const auto obj = cv::StereoBM::create(numDisparities, blockSize);
    *returnValue = clone(obj);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoBM_getPreFilterType(
    cv::StereoBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getPreFilterType();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoBM_setPreFilterType(
    cv::StereoBM *obj, int value)
{
    BEGIN_WRAP
    obj->setPreFilterType(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoBM_getPreFilterSize(
    cv::StereoBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getPreFilterSize();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoBM_setPreFilterSize(
    cv::StereoBM *obj, int value)
{
    BEGIN_WRAP
    obj->setPreFilterSize(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoBM_getPreFilterCap(
    cv::StereoBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getPreFilterCap();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoBM_setPreFilterCap(
    cv::StereoBM *obj, int value)
{
    BEGIN_WRAP
    obj->setPreFilterCap(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoBM_getTextureThreshold(
    cv::StereoBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getTextureThreshold();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoBM_setTextureThreshold(
    cv::StereoBM *obj, int value)
{
    BEGIN_WRAP
    obj->setTextureThreshold(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoBM_getUniquenessRatio(
    cv::StereoBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getUniquenessRatio();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoBM_setUniquenessRatio(
    cv::StereoBM *obj, int value)
{
    BEGIN_WRAP
    obj->setUniquenessRatio(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoBM_getSmallerBlockSize(
    cv::StereoBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getSmallerBlockSize();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoBM_setSmallerBlockSize(
    cv::StereoBM *obj, int value)
{
    BEGIN_WRAP
    obj->setSmallerBlockSize(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoBM_getROI1(
    cv::StereoBM *obj, MyCvRect *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getROI1());
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoBM_setROI1(
    cv::StereoBM *obj, MyCvRect value)
{
    BEGIN_WRAP
    obj->setROI1(cpp(value));
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoBM_getROI2(
    cv::StereoBM *obj, MyCvRect *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getROI2());
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoBM_setROI2(
    cv::StereoBM *obj, MyCvRect value)
{
    BEGIN_WRAP
    obj->setROI2(cpp(value));
    END_WRAP
}

#pragma endregion

#pragma region StereoSGBM

CVAPI(ExceptionStatus) calib3d_Ptr_StereoSGBM_get(
    cv::Ptr<cv::StereoSGBM> *obj, cv::StereoSGBM **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_Ptr_StereoSGBM_delete(cv::Ptr<cv::StereoSGBM> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoSGBM_create(
    int minDisparity, int numDisparities, int blockSize,
    int P1, int P2, int disp12MaxDiff,
    int preFilterCap, int uniquenessRatio,
    int speckleWindowSize, int speckleRange, int mode,
    cv::Ptr<cv::StereoSGBM> **returnValue)
{
    BEGIN_WRAP
    const auto obj = cv::StereoSGBM::create(
        minDisparity, numDisparities, blockSize,
        P1, P2, disp12MaxDiff,
        preFilterCap, uniquenessRatio,
        speckleWindowSize, speckleRange, mode);
    *returnValue = new cv::Ptr<cv::StereoSGBM>(obj);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoSGBM_getPreFilterCap(cv::StereoSGBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getPreFilterCap();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoSGBM_setPreFilterCap(cv::StereoSGBM *obj, int value)
{
    BEGIN_WRAP
    obj->setPreFilterCap(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoSGBM_getUniquenessRatio(cv::StereoSGBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getUniquenessRatio();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoSGBM_setUniquenessRatio(cv::StereoSGBM *obj, int value)
{
    BEGIN_WRAP
    obj->setUniquenessRatio(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoSGBM_getP1(cv::StereoSGBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getP1();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoSGBM_setP1(cv::StereoSGBM *obj, int value)
{
    BEGIN_WRAP
    obj->setP1(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoSGBM_getP2(cv::StereoSGBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getP2();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoSGBM_setP2(cv::StereoSGBM *obj, int value)
{
    BEGIN_WRAP
    obj->setP2(value);
    END_WRAP
}

CVAPI(ExceptionStatus) calib3d_StereoSGBM_getMode(cv::StereoSGBM *obj, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getMode();
    END_WRAP
}
CVAPI(ExceptionStatus) calib3d_StereoSGBM_setMode(cv::StereoSGBM *obj, int value)
{
    BEGIN_WRAP
    obj->setMode(value);
    END_WRAP
}

#pragma endregion

#endif // NO_CALIB3D
