#ifndef _CPP_CALIB3D_STEREOSGBM_H_
#define _CPP_CALIB3D_STEREOSGBM_H_

#include "include_opencv.h"

CVAPI(cv::StereoSGBM*) calib3d_Ptr_StereoSGBM_get(
    cv::Ptr<cv::StereoSGBM> *obj)
{
    return obj->get();
}

CVAPI(void) calib3d_Ptr_StereoSGBM_delete(cv::Ptr<cv::StereoSGBM> *obj)
{
    delete obj;
}

CVAPI(cv::Ptr<cv::StereoSGBM>*) calib3d_StereoSGBM_create(
    int minDisparity, int numDisparities, int blockSize,
    int P1, int P2, int disp12MaxDiff,
    int preFilterCap, int uniquenessRatio,
    int speckleWindowSize, int speckleRange, int mode)
{
    cv::Ptr<cv::StereoSGBM> obj = cv::StereoSGBM::create(
        minDisparity, numDisparities, blockSize,
        P1, P2, disp12MaxDiff,
        preFilterCap, uniquenessRatio,
        speckleWindowSize, speckleRange, mode);
    return new cv::Ptr<cv::StereoSGBM>(obj);
}

CVAPI(int) calib3d_StereoSGBM_getPreFilterCap(cv::Ptr<cv::StereoSGBM> *obj)
{
    return (*obj)->getPreFilterCap();
}
CVAPI(void) calib3d_StereoSGBM_setPreFilterCap(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
    (*obj)->setPreFilterCap(value);
}

CVAPI(int) calib3d_StereoSGBM_getUniquenessRatio(cv::Ptr<cv::StereoSGBM> *obj)
{
    return (*obj)->getUniquenessRatio();
}
CVAPI(void) calib3d_StereoSGBM_setUniquenessRatio(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
    (*obj)->setUniquenessRatio(value);
}

CVAPI(int) calib3d_StereoSGBM_getP1(cv::Ptr<cv::StereoSGBM> *obj)
{
    return (*obj)->getP1();
}
CVAPI(void) calib3d_StereoSGBM_setP1(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
    (*obj)->setP1(value);
}

CVAPI(int) calib3d_StereoSGBM_getP2(cv::Ptr<cv::StereoSGBM> *obj)
{
    return (*obj)->getP2();
}
CVAPI(void) calib3d_StereoSGBM_setP2(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
    (*obj)->setP2(value);
}

CVAPI(int) calib3d_StereoSGBM_getMode(cv::Ptr<cv::StereoSGBM> *obj)
{
    return (*obj)->getMode();
}
CVAPI(void) calib3d_StereoSGBM_setMode(cv::Ptr<cv::StereoSGBM> *obj, int value)
{
    (*obj)->setMode(value);
}


#endif