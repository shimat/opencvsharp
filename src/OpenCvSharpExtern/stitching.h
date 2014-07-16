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

CVAPI(int) stitching_Stitcher_stitch1_InputArray(
    cv::Stitcher *obj, cv::_InputArray *images, cv::_OutputArray *pano)
{
    cv::Stitcher::Status status = obj->stitch(*images, *pano);
    return static_cast<int>(status);
}
CVAPI(int) stitching_Stitcher_stitch1_array(
    cv::Stitcher *obj, cv::Mat **images, int imagesCount, cv::_OutputArray *pano)
{
    std::vector<cv::Mat> imagesVec(imagesCount);
    for (int i = 0; i < imagesCount; i++)
    {
        imagesVec[i] = *images[i];
    }

    cv::Stitcher::Status status = obj->stitch(imagesVec, *pano);
    return static_cast<int>(status);
}

CVAPI(int) stitching_Stitcher_stitch2(
    cv::Stitcher *obj, cv::_InputArray *images, std::vector<std::vector<cv::Rect> > *rois, cv::_OutputArray *pano)
{
    cv::Stitcher::Status status = obj->stitch(*images, *rois, *pano);
    return static_cast<int>(status);
}


#endif