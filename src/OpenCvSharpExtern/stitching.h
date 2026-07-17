#pragma once

#ifndef NO_STITCHING

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) stitching_Stitcher_create(int mode, cv::Ptr<cv::Stitcher> **returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::Stitcher::create(static_cast<cv::Stitcher::Mode>(mode));
        *returnValue = clone(ptr);
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_Stitcher_delete(cv::Ptr<cv::Stitcher> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) stitching_Ptr_Stitcher_get(cv::Ptr<cv::Stitcher> *obj, cv::Stitcher **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}

#pragma region getter/setter

CVAPI(ExceptionStatus) stitching_Stitcher_registrationResol(cv::Stitcher *obj, double *returnValue)
{ 
    return cvTry([&] {
        *returnValue = obj->registrationResol();
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_setRegistrationResol(cv::Stitcher *obj, const double resol_mpx)
{
    return cvTry([&] {
        obj->setRegistrationResol(resol_mpx);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_seamEstimationResol(cv::Stitcher *obj, double *returnValue) 
{
    return cvTry([&] {
        *returnValue = obj->seamEstimationResol();
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_setSeamEstimationResol(cv::Stitcher *obj, const double resol_mpx)
{
    return cvTry([&] {
        obj->setSeamEstimationResol(resol_mpx); 
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_compositingResol(cv::Stitcher *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->compositingResol();
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_setCompositingResol(cv::Stitcher *obj, const double resol_mpx)
{ 
    return cvTry([&] {
        obj->setCompositingResol(resol_mpx);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_panoConfidenceThresh(cv::Stitcher *obj, double *returnValue) 
{ 
    return cvTry([&] {
        *returnValue = obj->panoConfidenceThresh();
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_setPanoConfidenceThresh(cv::Stitcher *obj, const double conf_thresh)
{
    return cvTry([&] {
        obj->setPanoConfidenceThresh(conf_thresh);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_waveCorrection(cv::Stitcher *obj, int *returnValue) 
{ 
    return cvTry([&] {
        *returnValue = obj->waveCorrection() ? 1 : 0; 
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_setWaveCorrection(cv::Stitcher *obj, const int flag)
{
    return cvTry([&] {
        obj->setWaveCorrection(flag != 0); 
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_waveCorrectKind(cv::Stitcher *obj, int *returnValue) 
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->waveCorrectKind());
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_setWaveCorrectKind(cv::Stitcher *obj, int kind) 
{ 
    return cvTry([&] {
        obj->setWaveCorrectKind(static_cast<cv::detail::WaveCorrectKind>(kind)); 
    });
}

#pragma endregion

CVAPI(ExceptionStatus) stitching_Stitcher_estimateTransform_InputArray1(
    cv::Stitcher *obj,
    const interop::InputArrayProxy* images,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->estimateTransform(InProxy(*images)));
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_estimateTransform_InputArray2(
    cv::Stitcher *obj,
    const interop::InputArrayProxy* images,
    const interop::Rect **rois,
    const int roisSize1,
    const int *roisSize2,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<std::vector<cv::Rect> > roisVec;
        toRectVec(rois, roisSize1, roisSize2, roisVec);

        *returnValue = static_cast<int>(obj->estimateTransform(InProxy(*images), roisVec));
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_estimateTransform_MatArray1(
    cv::Stitcher *obj,
    const cv::Mat **images,
    const int imagesSize,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesVec;
        toVec(images, imagesSize, imagesVec);

        *returnValue = static_cast<int>(obj->estimateTransform(imagesVec));
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_estimateTransform_MatArray2(
    cv::Stitcher *obj,
    const cv::Mat **images,
    const int imagesSize,
    const interop::Rect **rois,
    const int roisSize1,
    const int *roisSize2,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesVec;
        toVec(images, imagesSize, imagesVec);

        std::vector<std::vector<cv::Rect> > roisVec;
        toRectVec(rois, roisSize1, roisSize2, roisVec);

        *returnValue = static_cast<int>(obj->estimateTransform(imagesVec, roisVec));
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_composePanorama1(
    cv::Stitcher *obj,
    const interop::OutputArrayProxy* pano,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->composePanorama(OutProxy(*pano)));
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_composePanorama2_InputArray(
    cv::Stitcher *obj,
    const interop::InputArrayProxy* images,
    const interop::OutputArrayProxy* pano,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->composePanorama(InProxy(*images), OutProxy(*pano)));
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_composePanorama2_MatArray(
    cv::Stitcher *obj,
    const cv::Mat **images,
    const int imagesSize,
    const interop::OutputArrayProxy* pano,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesVec;
        toVec(images, imagesSize, imagesVec);

        *returnValue = static_cast<int>(obj->composePanorama(imagesVec, OutProxy(*pano)));
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_stitch1_InputArray(
    cv::Stitcher *obj,
    const interop::InputArrayProxy* images,
    const interop::OutputArrayProxy* pano,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = static_cast<int>(obj->stitch(InProxy(*images), OutProxy(*pano)));
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_stitch1_MatArray(
    cv::Stitcher *obj,
    const cv::Mat **images,
    const int imagesSize,
    const interop::OutputArrayProxy* pano,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesVec;
        toVec(images, imagesSize, imagesVec);

        *returnValue = static_cast<int>(obj->stitch(imagesVec, OutProxy(*pano)));
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_stitch2_InputArray(
    cv::Stitcher *obj,
    const interop::InputArrayProxy* images,
    const interop::Rect **rois,
    const int roisSize1,
    int *roisSize2,
    const interop::OutputArrayProxy* pano,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<std::vector<cv::Rect> > roisVec;
        toRectVec(rois, roisSize1, roisSize2, roisVec);

        *returnValue = static_cast<int>(obj->stitch(InProxy(*images), roisVec, OutProxy(*pano)));
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_stitch2_MatArray(
    cv::Stitcher *obj,
    const cv::Mat **images,
    const int imagesSize,
    const interop::Rect **rois,
    const int roisSize1,
    int *roisSize2,
    const interop::OutputArrayProxy* pano,
    int *returnValue)
{
    return cvTry([&] {
        std::vector<cv::Mat> imagesVec;
        toVec(images, imagesSize, imagesVec);

        std::vector<std::vector<cv::Rect> > roisVec;
        toRectVec(rois, roisSize1, roisSize2, roisVec);

        *returnValue = static_cast<int>(obj->stitch(imagesVec, roisVec, OutProxy(*pano)));
    });
}



CVAPI(ExceptionStatus) stitching_Stitcher_component(cv::Stitcher *obj, std::vector<int>* returnValue) 
{ 
    return cvTry([&] {
        const auto component = obj->component();
        std::copy(component.begin(), component.end(), std::back_inserter(*returnValue));
    });
}

// std::vector<detail::CameraParams> cameras() const { return cameras_; }

CVAPI(ExceptionStatus) stitching_Stitcher_workScale(cv::Stitcher *obj, double *returnValue)
{
    return cvTry([&] {
        *returnValue = obj->workScale();
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_cameras(
    cv::Stitcher *obj,
    std::vector<double> *focals, std::vector<double> *aspects,
    std::vector<double> *ppxs, std::vector<double> *ppys,
    std::vector<cv::Mat> *rs, std::vector<cv::Mat> *ts)
{
    return cvTry([&] {
        const auto cameras = obj->cameras();
        for (const auto &cam : cameras)
        {
            focals->push_back(cam.focal);
            aspects->push_back(cam.aspect);
            ppxs->push_back(cam.ppx);
            ppys->push_back(cam.ppy);
            rs->push_back(cam.R.clone());
            ts->push_back(cam.t.clone());
        }
    });
}

#pragma region pipeline component setters
// Getters are intentionally not exposed: Stitcher stores these as cv::Ptr<T> to a *polymorphic*
// base (FeaturesMatcher/WarperCreator/ExposureCompensator/SeamFinder/Blender/BundleAdjusterBase),
// and there is no RTTI-free way to hand a raw pointer back to C# as the correct concrete managed
// subclass. Callers that need the object back should keep their own reference to what they set.
// Each setter wraps the caller-owned raw pointer in a non-owning cv::Ptr<T> (no-op deleter): the
// managed wrapper object retains true ownership, and Stitcher merely holds a reference to it, so
// the caller must keep that managed object alive for as long as it's attached to the Stitcher.

CVAPI(ExceptionStatus) stitching_Stitcher_setFeaturesFinder(cv::Stitcher *obj, cv::Feature2D *featuresFinder)
{
    return cvTry([&] {
        const cv::Ptr<cv::Feature2D> nonOwning(featuresFinder, [](cv::Feature2D*) {});
        obj->setFeaturesFinder(nonOwning);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_setFeaturesMatcher(cv::Stitcher *obj, cv::detail::FeaturesMatcher *featuresMatcher)
{
    return cvTry([&] {
        const cv::Ptr<cv::detail::FeaturesMatcher> nonOwning(featuresMatcher, [](cv::detail::FeaturesMatcher*) {});
        obj->setFeaturesMatcher(nonOwning);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_matchingMask(cv::Stitcher *obj, cv::Mat *returnValue)
{
    return cvTry([&] {
        obj->matchingMask().copyTo(*returnValue);
    });
}
CVAPI(ExceptionStatus) stitching_Stitcher_setMatchingMask(cv::Stitcher *obj, cv::Mat *mask)
{
    return cvTry([&] {
        cv::UMat maskU;
        mask->copyTo(maskU);
        obj->setMatchingMask(maskU);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_setBundleAdjuster(cv::Stitcher *obj, cv::detail::BundleAdjusterBase *bundleAdjuster)
{
    return cvTry([&] {
        const cv::Ptr<cv::detail::BundleAdjusterBase> nonOwning(bundleAdjuster, [](cv::detail::BundleAdjusterBase*) {});
        obj->setBundleAdjuster(nonOwning);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_setWarper(cv::Stitcher *obj, cv::WarperCreator *warper)
{
    return cvTry([&] {
        const cv::Ptr<cv::WarperCreator> nonOwning(warper, [](cv::WarperCreator*) {});
        obj->setWarper(nonOwning);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_setExposureCompensator(cv::Stitcher *obj, cv::detail::ExposureCompensator *exposureCompensator)
{
    return cvTry([&] {
        const cv::Ptr<cv::detail::ExposureCompensator> nonOwning(exposureCompensator, [](cv::detail::ExposureCompensator*) {});
        obj->setExposureCompensator(nonOwning);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_setSeamFinder(cv::Stitcher *obj, cv::detail::SeamFinder *seamFinder)
{
    return cvTry([&] {
        const cv::Ptr<cv::detail::SeamFinder> nonOwning(seamFinder, [](cv::detail::SeamFinder*) {});
        obj->setSeamFinder(nonOwning);
    });
}

CVAPI(ExceptionStatus) stitching_Stitcher_setBlender(cv::Stitcher *obj, cv::detail::Blender *blender)
{
    return cvTry([&] {
        const cv::Ptr<cv::detail::Blender> nonOwning(blender, [](cv::detail::Blender*) {});
        obj->setBlender(nonOwning);
    });
}

#pragma endregion

#endif // NO_STITCHING
