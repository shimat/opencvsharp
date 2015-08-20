#ifndef _CPP_STITCHING_H_
#define _CPP_STITCHING_H_

#include "include_opencv.h"

namespace cv
{
    // Hack!
    class MyStitcher
    {
    public:
        MyStitcher() {} // to make public this

        double registr_resol_;
        double seam_est_resol_;
        double compose_resol_;
        double conf_thresh_;
        Ptr<detail::FeaturesFinder> features_finder_;
        Ptr<detail::FeaturesMatcher> features_matcher_;
        Mat matching_mask_;
        Ptr<detail::BundleAdjusterBase> bundle_adjuster_;
        bool do_wave_correct_;
        detail::WaveCorrectKind wave_correct_kind_;
        Ptr<WarperCreator> warper_;
        Ptr<detail::ExposureCompensator> exposure_comp_;
        Ptr<detail::SeamFinder> seam_finder_;
        Ptr<detail::Blender> blender_;

        std::vector<cv::Mat> imgs_;
        std::vector<std::vector<cv::Rect> > rois_;
        std::vector<cv::Size> full_img_sizes_;
        std::vector<detail::ImageFeatures> features_;
        std::vector<detail::MatchesInfo> pairwise_matches_;
        std::vector<cv::Mat> seam_est_imgs_;
        std::vector<int> indices_;
        std::vector<detail::CameraParams> cameras_;
        double work_scale_;
        double seam_scale_;
        double seam_work_aspect_;
        double warped_image_scale_;
    };
}

CVAPI(void) stitching_Stitcher_delete(cv::MyStitcher *obj)
{
	delete obj;
}

CVAPI(cv::Stitcher*) stitching_Stitcher_createDefault(int try_use_gpu)
{
    cv::Stitcher s = cv::Stitcher::createDefault(try_use_gpu != 0);

    cv::MyStitcher *ret = new cv::MyStitcher;
    ret->registr_resol_ = s.registrationResol();
    ret->seam_est_resol_ = s.seamEstimationResol();
    ret->compose_resol_ = s.compositingResol();
    ret->conf_thresh_ = s.panoConfidenceThresh();
    ret->do_wave_correct_ = s.waveCorrection();
    ret->wave_correct_kind_ = s.waveCorrectKind();
    ret->features_matcher_ = s.featuresMatcher();
    ret->bundle_adjuster_ = s.bundleAdjuster();
    ret->features_finder_ = s.featuresFinder();
    ret->warper_ = s.warper();
    ret->seam_finder_ = s.seamFinder();
    ret->exposure_comp_ = s.exposureCompensator();
    ret->blender_ = s.blender();
    
    return reinterpret_cast<cv::Stitcher*>(ret);
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
    std::vector<int> val = obj->component();
    *pointer = &val[0];
    *length = static_cast<int>(val.size());
}

// std::vector<detail::CameraParams> cameras() const { return cameras_; }

CVAPI(double) stitching_Stitcher_workScale(cv::Stitcher *obj) 
{ 
    return obj->workScale(); 
}

#endif
