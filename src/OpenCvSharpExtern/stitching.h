#ifndef _CPP_STITCHING_H_
#define _CPP_STITCHING_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) stitching_Stitcher_create(int mode, cv::Ptr<cv::Stitcher> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::Stitcher::create(static_cast<cv::Stitcher::Mode>(mode));
    *returnValue = clone(ptr);
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Ptr_Stitcher_delete(cv::Ptr<cv::Stitcher> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Ptr_Stitcher_get(cv::Ptr<cv::Stitcher> *obj, cv::Stitcher **returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->get();
    END_WRAP
}

#pragma region getter/setter

CVAPI(ExceptionStatus) stitching_Stitcher_registrationResol(cv::Stitcher *obj, double *returnValue)
{ 
    BEGIN_WRAP
    *returnValue = obj->registrationResol();
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_setRegistrationResol(cv::Stitcher *obj, const double resol_mpx)
{
    BEGIN_WRAP
    obj->setRegistrationResol(resol_mpx);
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_seamEstimationResol(cv::Stitcher *obj, double *returnValue) 
{
    BEGIN_WRAP
    *returnValue = obj->seamEstimationResol();
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_setSeamEstimationResol(cv::Stitcher *obj, const double resol_mpx)
{
    BEGIN_WRAP
    obj->setSeamEstimationResol(resol_mpx); 
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_compositingResol(cv::Stitcher *obj, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->compositingResol();
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_setCompositingResol(cv::Stitcher *obj, const double resol_mpx)
{ 
    BEGIN_WRAP
    obj->setCompositingResol(resol_mpx);
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_panoConfidenceThresh(cv::Stitcher *obj, double *returnValue) 
{ 
    BEGIN_WRAP
    *returnValue = obj->panoConfidenceThresh();
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_setPanoConfidenceThresh(cv::Stitcher *obj, const double conf_thresh)
{
    BEGIN_WRAP
    obj->setPanoConfidenceThresh(conf_thresh);
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_waveCorrection(cv::Stitcher *obj, int *returnValue) 
{ 
    BEGIN_WRAP
    *returnValue = obj->waveCorrection() ? 1 : 0; 
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_setWaveCorrection(cv::Stitcher *obj, const int flag)
{
    BEGIN_WRAP
    obj->setWaveCorrection(flag != 0); 
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_waveCorrectKind(cv::Stitcher *obj, int *returnValue) 
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->waveCorrectKind());
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_setWaveCorrectKind(cv::Stitcher *obj, int kind) 
{ 
    BEGIN_WRAP
    obj->setWaveCorrectKind(static_cast<cv::detail::WaveCorrectKind>(kind)); 
    END_WRAP
}

#pragma endregion

CVAPI(ExceptionStatus) stitching_Stitcher_estimateTransform_InputArray1(
    cv::Stitcher *obj, cv::_InputArray *images, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->estimateTransform(*images));
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_estimateTransform_InputArray2(
    cv::Stitcher *obj, cv::_InputArray *images,
    const CvRect **rois, const int roisSize1, const int *roisSize2, int *returnValue)
{
    BEGIN_WRAP
    std::vector<std::vector<cv::Rect> > roisVec;
    toVec(rois, roisSize1, roisSize2, roisVec);

    *returnValue = static_cast<int>(obj->estimateTransform(*images, roisVec));
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_estimateTransform_MatArray1(
    cv::Stitcher *obj, const cv::Mat **images, const int imagesSize, int *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    *returnValue = static_cast<int>(obj->estimateTransform(imagesVec));
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_estimateTransform_MatArray2(
    cv::Stitcher *obj, const cv::Mat **images, const int imagesSize,
    const CvRect **rois, const int roisSize1, const int *roisSize2, int *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    std::vector<std::vector<cv::Rect> > roisVec;
    toVec(rois, roisSize1, roisSize2, roisVec);

    *returnValue = static_cast<int>(obj->estimateTransform(imagesVec, roisVec));
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_composePanorama1(
    cv::Stitcher *obj, cv::_OutputArray *pano, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->composePanorama(*pano));
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_composePanorama2_InputArray(
    cv::Stitcher *obj, cv::_InputArray *images, cv::_OutputArray *pano, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->composePanorama(*images, *pano));
    END_WRAP
}
CVAPI(ExceptionStatus) stitching_Stitcher_composePanorama2_MatArray(
    cv::Stitcher *obj, const cv::Mat **images, const int imagesSize, 
    cv::_OutputArray *pano, int *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    *returnValue = static_cast<int>(obj->composePanorama(imagesVec, *pano));
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_stitch1_InputArray(
    cv::Stitcher *obj, cv::_InputArray *images, 
    cv::_OutputArray *pano, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = static_cast<int>(obj->stitch(*images, *pano));;
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_stitch1_MatArray(
    cv::Stitcher *obj, const cv::Mat **images, const int imagesSize, 
    cv::_OutputArray *pano, int *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    *returnValue = static_cast<int>(obj->stitch(imagesVec, *pano));
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_stitch2_InputArray(
    cv::Stitcher *obj, cv::_InputArray *images, 
    const CvRect **rois, const int roisSize1, int *roisSize2,
    cv::_OutputArray *pano, int *returnValue)
{
    BEGIN_WRAP
    std::vector<std::vector<cv::Rect> > roisVec;
    toVec(rois, roisSize1, roisSize2, roisVec);

    *returnValue = static_cast<int>(obj->stitch(*images, roisVec, *pano));
    END_WRAP
}

CVAPI(ExceptionStatus) stitching_Stitcher_stitch2_MatArray(
    cv::Stitcher *obj, const cv::Mat **images, const int imagesSize,
    const CvRect **rois, const int roisSize1, int *roisSize2,
    cv::_OutputArray *pano, int *returnValue)
{
    BEGIN_WRAP
    std::vector<cv::Mat> imagesVec;
    toVec(images, imagesSize, imagesVec);

    std::vector<std::vector<cv::Rect> > roisVec;
    toVec(rois, roisSize1, roisSize2, roisVec);

    *returnValue = static_cast<int>(obj->stitch(imagesVec, roisVec, *pano));
    END_WRAP
}



CVAPI(ExceptionStatus) stitching_Stitcher_component(cv::Stitcher *obj, std::vector<int>* returnValue) 
{ 
    BEGIN_WRAP
    const auto component = obj->component();
    std::copy(component.begin(), component.end(), std::back_inserter(*returnValue));
    END_WRAP
}

// std::vector<detail::CameraParams> cameras() const { return cameras_; }

CVAPI(ExceptionStatus) stitching_Stitcher_workScale(cv::Stitcher *obj, double *returnValue) 
{ 
    BEGIN_WRAP
    *returnValue = obj->workScale();
    END_WRAP
}

#endif