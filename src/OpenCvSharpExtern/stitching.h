#ifndef _CPP_STITCHING_H_
#define _CPP_STITCHING_H_

#include "include_opencv.h"

CVAPI(cv::Ptr<cv::Stitcher>*) stitching_createStitcher(int try_use_gpu)
{
    cv::Ptr<cv::Stitcher> ptr = cv::createStitcher(try_use_gpu != 0);
    return new cv::Ptr<cv::Stitcher>(ptr);
}

CVAPI(void) stitching_Ptr_Stitcher_delete(cv::Ptr<cv::Stitcher> *obj)
{
    delete obj;
}

CVAPI(cv::Stitcher*) stitching_Ptr_Stitcher_get(cv::Ptr<cv::Stitcher> *obj)
{
    return obj->get();
}

#pragma region getter/setter
CVAPI(double) stitching_Stitcher_registrationResol(cv::Stitcher *obj)
{ 
    return obj->registrationResol();
}
CVAPI(void) stitching_Stitcher_setRegistrationResol(cv::Stitcher *obj, double resol_mpx) 
{
    obj->setRegistrationResol(resol_mpx);
}

CVAPI(double) stitching_Stitcher_seamEstimationResol(cv::Stitcher *obj) 
{
    return obj->seamEstimationResol();
}
CVAPI(void) stitching_Stitcher_setSeamEstimationResol(cv::Stitcher *obj, double resol_mpx) 
{
    obj->setSeamEstimationResol(resol_mpx); 
}

CVAPI(double) stitching_Stitcher_compositingResol(cv::Stitcher *obj)
{
    return obj->compositingResol();
}
CVAPI(void) stitching_Stitcher_setCompositingResol(cv::Stitcher *obj, double resol_mpx)
{ 
    obj->setCompositingResol(resol_mpx);
}

CVAPI(double) stitching_Stitcher_panoConfidenceThresh(cv::Stitcher *obj) 
{ 
    return obj->panoConfidenceThresh();
}
CVAPI(void) stitching_Stitcher_setPanoConfidenceThresh(cv::Stitcher *obj, double conf_thresh)
{
    obj->setPanoConfidenceThresh(conf_thresh);
}

CVAPI(int) stitching_Stitcher_waveCorrection(cv::Stitcher *obj) 
{ 
    return obj->waveCorrection() ? 1 : 0; 
}
CVAPI(void) stitching_Stitcher_setWaveCorrection(cv::Stitcher *obj, int flag)
{
    obj->setWaveCorrection(flag != 0); 
}

CVAPI(int) stitching_Stitcher_waveCorrectKind(cv::Stitcher *obj) 
{
    return static_cast<int>(obj->waveCorrectKind());
}
CVAPI(void) stitching_Stitcher_setWaveCorrectKind(cv::Stitcher *obj, int kind) 
{ 
    obj->setWaveCorrectKind(static_cast<cv::detail::WaveCorrectKind>(kind)); 
}

#pragma endregion

CVAPI(int) stitching_Stitcher_estimateTransform_InputArray1(
    cv::Stitcher *obj, cv::_InputArray *images)
{
    cv::Stitcher::Status status = obj->estimateTransform(*images);
    return static_cast<int>(status);
}
CVAPI(int) stitching_Stitcher_estimateTransform_InputArray2(
    cv::Stitcher *obj, cv::_InputArray *images,
    CvRect **rois, int roisSize1, int *roisSize2)
{
    std::vector<std::vector<cv::Rect> > roisVec;
    toVec(rois, roisSize1, roisSize2, roisVec);

    cv::Stitcher::Status status = obj->estimateTransform(*images, roisVec);
    return static_cast<int>(status);
}
CVAPI(int) stitching_Stitcher_estimateTransform_MatArray1(
    cv::Stitcher *obj, cv::Mat **images, int imagesSize)
{
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    cv::Stitcher::Status status = obj->estimateTransform(imagesVec);
    return static_cast<int>(status);
}
CVAPI(int) stitching_Stitcher_estimateTransform_MatArray2(
    cv::Stitcher *obj, cv::Mat **images, int imagesSize,
    CvRect **rois, int roisSize1, int *roisSize2)
{
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    std::vector<std::vector<cv::Rect> > roisVec;
    toVec(rois, roisSize1, roisSize2, roisVec);

    cv::Stitcher::Status status = obj->estimateTransform(imagesVec, roisVec);
    return static_cast<int>(status);
}

CVAPI(int) stitching_Stitcher_composePanorama1(
    cv::Stitcher *obj, cv::_OutputArray *pano)
{
    cv::Stitcher::Status status = obj->composePanorama(*pano);
    return static_cast<int>(status);
}
CVAPI(int) stitching_Stitcher_composePanorama2_InputArray(
    cv::Stitcher *obj, cv::_InputArray *images, cv::_OutputArray *pano)
{
    cv::Stitcher::Status status = obj->composePanorama(*images, *pano);
    return static_cast<int>(status);
}
CVAPI(int) stitching_Stitcher_composePanorama2_MatArray(
    cv::Stitcher *obj, cv::Mat **images, int imagesSize, cv::_OutputArray *pano)
{
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    cv::Stitcher::Status status = obj->composePanorama(imagesVec, *pano);
    return static_cast<int>(status);
}

CVAPI(int) stitching_Stitcher_stitch1_InputArray(
    cv::Stitcher *obj, cv::_InputArray *images, cv::_OutputArray *pano)
{
    cv::Stitcher::Status status = obj->stitch(*images, *pano);
    return static_cast<int>(status);
}

CVAPI(int) stitching_Stitcher_stitch1_MatArray(
    cv::Stitcher *obj, cv::Mat **images, int imagesSize, cv::_OutputArray *pano)
{
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    cv::Stitcher::Status status = obj->stitch(imagesVec, *pano);
    return static_cast<int>(status);
}

CVAPI(int) stitching_Stitcher_stitch2_InputArray(
    cv::Stitcher *obj, cv::_InputArray *images, 
    CvRect **rois, int roisSize1, int *roisSize2,
    cv::_OutputArray *pano)
{
    std::vector<std::vector<cv::Rect> > roisVec;
    toVec(rois, roisSize1, roisSize2, roisVec);

    cv::Stitcher::Status status = obj->stitch(*images, roisVec, *pano);
    return static_cast<int>(status);
}

CVAPI(int) stitching_Stitcher_stitch2_MatArray(
    cv::Stitcher *obj, cv::Mat **images, int imagesSize,  
    CvRect **rois, int roisSize1, int *roisSize2,
    cv::_OutputArray *pano)
{
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    std::vector<std::vector<cv::Rect> > roisVec;
    toVec(rois, roisSize1, roisSize2, roisVec);

    cv::Stitcher::Status status = obj->stitch(imagesVec, roisVec, *pano);
    return static_cast<int>(status);
}



CVAPI(void) stitching_Stitcher_component(cv::Stitcher *obj, int **pointer, int *length) 
{ 
    const std::vector<int> &val = obj->component();
    *pointer = const_cast<int*>(&val[0]);
    *length = static_cast<int>(val.size());
}

// std::vector<detail::CameraParams> cameras() const { return cameras_; }

CVAPI(double) stitching_Stitcher_workScale(cv::Stitcher *obj) 
{ 
    return obj->workScale(); 
}

#endif