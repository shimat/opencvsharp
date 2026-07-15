#pragma once
#ifndef NO_CONTRIB
#include "include_opencv.h"
#include "rgbd_kinfu.h" // toCv/toInterop Vec3i/Vec3f helpers

// Keep the exported functions compact while using the repository's cvTry exception boundary.
#define BEGIN_WRAP return cvTry([&] {
#define END_WRAP });

using cv::colored_kinfu::ColoredKinFu;
using ColoredKinFuParams = cv::colored_kinfu::Params;

/// <summary>
/// Plain-C struct for marshaling the scalar/fixed-size fields of colored_kinfu::Params across the
/// P/Invoke boundary. Matx33f/Matx44f fields (intr, rgb_intr, volumePose) and the icpIterations
/// vector are marshaled as separate arguments alongside this struct, not embedded in it.
/// Layout must stay in sync with OpenCvSharp.Rgbd.ColoredKinFuParams in C#.
/// </summary>
struct CvColoredKinFuParams
{
    interop::Size FrameSize;
    interop::Size RgbFrameSize;
    int32_t       VolumeKind;
    float         DepthFactor;
    float         BilateralSigmaDepth;
    float         BilateralSigmaSpatial;
    int32_t       BilateralKernelSize;
    int32_t       PyramidLevels;
    interop::Vec3i VolumeDims;
    float         VoxelSize;
    float         TsdfMinCameraMovement;
    float         TsdfTruncDist;
    int32_t       TsdfMaxWeight;
    float         RaycastStepFactor;
    interop::Vec3f LightPose;
    float         IcpDistThresh;
    float         IcpAngleThresh;
    float         TruncateThreshold;
};

static cv::colored_kinfu::Params BuildColoredKinfuParams(
    const CvColoredKinFuParams *pod,
    const interop::InputArrayProxy *intr, const interop::InputArrayProxy *rgbIntr,
    const interop::InputArrayProxy *volumePose, const std::vector<int> *icpIterations)
{
    cv::colored_kinfu::Params p;
    p.frameSize = cpp(pod->FrameSize);
    p.rgb_frameSize = cpp(pod->RgbFrameSize);
    p.volumeKind = static_cast<cv::VolumeType>(pod->VolumeKind);
    p.intr = cv::Matx33f(getMatFromProxy(*intr));
    p.rgb_intr = cv::Matx33f(getMatFromProxy(*rgbIntr));
    p.depthFactor = pod->DepthFactor;
    p.bilateral_sigma_depth = pod->BilateralSigmaDepth;
    p.bilateral_sigma_spatial = pod->BilateralSigmaSpatial;
    p.bilateral_kernel_size = pod->BilateralKernelSize;
    p.pyramidLevels = pod->PyramidLevels;
    p.volumeDims = toCv(pod->VolumeDims);
    p.voxelSize = pod->VoxelSize;
    p.tsdf_min_camera_movement = pod->TsdfMinCameraMovement;
    p.volumePose = cv::Matx44f(getMatFromProxy(*volumePose));
    p.tsdf_trunc_dist = pod->TsdfTruncDist;
    p.tsdf_max_weight = pod->TsdfMaxWeight;
    p.raycast_step_factor = pod->RaycastStepFactor;
    p.lightPose = toCv(pod->LightPose);
    p.icpDistThresh = pod->IcpDistThresh;
    p.icpAngleThresh = pod->IcpAngleThresh;
    p.icpIterations = *icpIterations;
    p.truncateThreshold = pod->TruncateThreshold;
    return p;
}

static void ReadColoredKinfuParams(
    const cv::colored_kinfu::Params &p, CvColoredKinFuParams *pod,
    const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    pod->FrameSize = c(p.frameSize);
    pod->RgbFrameSize = c(p.rgb_frameSize);
    pod->VolumeKind = static_cast<int32_t>(p.volumeKind);
    pod->DepthFactor = p.depthFactor;
    pod->BilateralSigmaDepth = p.bilateral_sigma_depth;
    pod->BilateralSigmaSpatial = p.bilateral_sigma_spatial;
    pod->BilateralKernelSize = p.bilateral_kernel_size;
    pod->PyramidLevels = p.pyramidLevels;
    pod->VolumeDims = toInterop(p.volumeDims);
    pod->VoxelSize = p.voxelSize;
    pod->TsdfMinCameraMovement = p.tsdf_min_camera_movement;
    pod->TsdfTruncDist = p.tsdf_trunc_dist;
    pod->TsdfMaxWeight = p.tsdf_max_weight;
    pod->RaycastStepFactor = p.raycast_step_factor;
    pod->LightPose = toInterop(p.lightPose);
    pod->IcpDistThresh = p.icpDistThresh;
    pod->IcpAngleThresh = p.icpAngleThresh;
    pod->TruncateThreshold = p.truncateThreshold;
    cv::Mat(p.intr).copyTo(OutProxy(*intr));
    cv::Mat(p.rgb_intr).copyTo(OutProxy(*rgbIntr));
    cv::Mat(p.volumePose).copyTo(OutProxy(*volumePose));
    *icpIterations = p.icpIterations;
}

CVAPI(ExceptionStatus) rgbd_colored_kinfu_Params_defaultParams(
    CvColoredKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    const auto p = ColoredKinFuParams::defaultParams();
    ReadColoredKinfuParams(*p, pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_colored_kinfu_Params_coarseParams(
    CvColoredKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    const auto p = ColoredKinFuParams::coarseParams();
    ReadColoredKinfuParams(*p, pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_colored_kinfu_Params_hashTSDFParams(
    int isCoarse, CvColoredKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    const auto p = ColoredKinFuParams::hashTSDFParams(isCoarse != 0);
    ReadColoredKinfuParams(*p, pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_colored_kinfu_Params_coloredTSDFParams(
    int isCoarse, CvColoredKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    const auto p = ColoredKinFuParams::coloredTSDFParams(isCoarse != 0);
    ReadColoredKinfuParams(*p, pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_colored_kinfu_Ptr_ColoredKinFu_delete(cv::Ptr<ColoredKinFu> *obj)
{ BEGIN_WRAP delete obj; END_WRAP }

CVAPI(ExceptionStatus) rgbd_colored_kinfu_Ptr_ColoredKinFu_get(cv::Ptr<ColoredKinFu> *obj, ColoredKinFu **returnValue)
{ BEGIN_WRAP *returnValue = obj->get(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_create(
    const CvColoredKinFuParams *pod, const interop::InputArrayProxy *intr, const interop::InputArrayProxy *rgbIntr,
    const interop::InputArrayProxy *volumePose, const std::vector<int> *icpIterations,
    cv::Ptr<ColoredKinFu> **returnValue)
{
    BEGIN_WRAP
    const auto p = BuildColoredKinfuParams(pod, intr, rgbIntr, volumePose, icpIterations);
    *returnValue = new cv::Ptr<ColoredKinFu>(ColoredKinFu::create(cv::makePtr<ColoredKinFuParams>(p)));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_getParams(
    ColoredKinFu *obj, CvColoredKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    ReadColoredKinfuParams(obj->getParams(), pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_render(ColoredKinFu *obj, const interop::OutputArrayProxy *image)
{ BEGIN_WRAP obj->render(OutProxy(*image)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_renderWithPose(
    ColoredKinFu *obj, const interop::OutputArrayProxy *image, const interop::InputArrayProxy *cameraPose)
{
    BEGIN_WRAP
    const cv::Matx44f pose(getMatFromProxy(*cameraPose));
    obj->render(OutProxy(*image), pose);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_getCloud(
    ColoredKinFu *obj, const interop::OutputArrayProxy *points, const interop::OutputArrayProxy *normals)
{ BEGIN_WRAP obj->getCloud(OutProxy(*points), OutProxy(*normals)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_getPoints(ColoredKinFu *obj, const interop::OutputArrayProxy *points)
{ BEGIN_WRAP obj->getPoints(OutProxy(*points)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_getNormals(
    ColoredKinFu *obj, const interop::InputArrayProxy *points, const interop::OutputArrayProxy *normals)
{ BEGIN_WRAP obj->getNormals(InProxy(*points), OutProxy(*normals)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_reset(ColoredKinFu *obj)
{ BEGIN_WRAP obj->reset(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_getPose(ColoredKinFu *obj, const interop::OutputArrayProxy *pose)
{
    BEGIN_WRAP
    const cv::Matx44f m = obj->getPose().matrix;
    cv::Mat(m).copyTo(OutProxy(*pose));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_colored_kinfu_ColoredKinFu_update(
    ColoredKinFu *obj, const interop::InputArrayProxy *depth, const interop::InputArrayProxy *rgb, int *returnValue)
{ BEGIN_WRAP *returnValue = obj->update(InProxy(*depth), InProxy(*rgb)) ? 1 : 0; END_WRAP }

#undef BEGIN_WRAP
#undef END_WRAP
#endif
