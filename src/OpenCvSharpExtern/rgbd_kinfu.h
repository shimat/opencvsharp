#pragma once
#ifndef NO_CONTRIB
#include "include_opencv.h"

// Keep the exported functions compact while using the repository's cvTry exception boundary.
#define BEGIN_WRAP return cvTry([&] {
#define END_WRAP });

using cv::kinfu::KinFu;
using KinFuParams = cv::kinfu::Params;

/// <summary>
/// Plain-C struct for marshaling the scalar/fixed-size fields of kinfu::Params (and its
/// dynafu::Params alias) across the P/Invoke boundary. Matx33f/Matx44f fields (intr, rgb_intr,
/// volumePose) and the icpIterations vector are marshaled as separate arguments alongside this
/// struct, not embedded in it.
/// Layout must stay in sync with OpenCvSharp.Rgbd.KinFuParams in C#.
/// </summary>
struct CvKinFuParams
{
    interop::Size FrameSize;
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

// Shared by rgbd_dynafu.h (dynafu::Params is an alias of kinfu::Params).
// cv::Vec3i/Vec3f are Matx-derived (user-provided copy/move ops) and are not trivially
// copyable, so they cannot go through the OCS_INTEROP_BITCAST c()/cpp() helpers; convert
// element-by-element instead (same approach as core_FileNode.h's Vec3x readers).

static cv::Vec3i toCv(const interop::Vec3i &v) { return cv::Vec3i(v.val); }
static cv::Vec3f toCv(const interop::Vec3f &v) { return cv::Vec3f(v.val); }

// InProxy only exposes an implicit conversion to cv::_InputArray, not getMat() directly;
// materialize the Mat through that conversion so Matx33f/Matx44f fields can be built from it.
static cv::Mat getMatFromProxy(const interop::InputArrayProxy &p)
{
    return static_cast<const cv::_InputArray &>(InProxy(p)).getMat();
}

static interop::Vec3i toInterop(const cv::Vec3i &v)
{
    interop::Vec3i ret;
    std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val));
    return ret;
}

static interop::Vec3f toInterop(const cv::Vec3f &v)
{
    interop::Vec3f ret;
    std::copy(std::begin(v.val), std::end(v.val), std::begin(ret.val));
    return ret;
}

static cv::kinfu::Params BuildKinfuParams(
    const CvKinFuParams *pod,
    const interop::InputArrayProxy *intr, const interop::InputArrayProxy *rgbIntr,
    const interop::InputArrayProxy *volumePose, const std::vector<int> *icpIterations)
{
    cv::kinfu::Params p;
    p.frameSize = cpp(pod->FrameSize);
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

static void ReadKinfuParams(
    const cv::kinfu::Params &p, CvKinFuParams *pod,
    const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    pod->FrameSize = c(p.frameSize);
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

CVAPI(ExceptionStatus) rgbd_kinfu_Params_defaultParams(
    CvKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    const auto p = cv::kinfu::Params::defaultParams();
    ReadKinfuParams(*p, pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_kinfu_Params_coarseParams(
    CvKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    const auto p = cv::kinfu::Params::coarseParams();
    ReadKinfuParams(*p, pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_kinfu_Params_hashTSDFParams(
    int isCoarse, CvKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    const auto p = cv::kinfu::Params::hashTSDFParams(isCoarse != 0);
    ReadKinfuParams(*p, pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_kinfu_Params_coloredTSDFParams(
    int isCoarse, CvKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    const auto p = cv::kinfu::Params::coloredTSDFParams(isCoarse != 0);
    ReadKinfuParams(*p, pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_kinfu_Ptr_KinFu_delete(cv::Ptr<KinFu> *obj)
{ BEGIN_WRAP delete obj; END_WRAP }

CVAPI(ExceptionStatus) rgbd_kinfu_Ptr_KinFu_get(cv::Ptr<KinFu> *obj, KinFu **returnValue)
{ BEGIN_WRAP *returnValue = obj->get(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_create(
    const CvKinFuParams *pod, const interop::InputArrayProxy *intr, const interop::InputArrayProxy *rgbIntr,
    const interop::InputArrayProxy *volumePose, const std::vector<int> *icpIterations,
    cv::Ptr<KinFu> **returnValue)
{
    BEGIN_WRAP
    const auto p = BuildKinfuParams(pod, intr, rgbIntr, volumePose, icpIterations);
    *returnValue = new cv::Ptr<KinFu>(KinFu::create(cv::makePtr<KinFuParams>(p)));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_getParams(
    KinFu *obj, CvKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    ReadKinfuParams(obj->getParams(), pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_render(KinFu *obj, const interop::OutputArrayProxy *image)
{ BEGIN_WRAP obj->render(OutProxy(*image)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_renderWithPose(
    KinFu *obj, const interop::OutputArrayProxy *image, const interop::InputArrayProxy *cameraPose)
{
    BEGIN_WRAP
    const cv::Matx44f pose(getMatFromProxy(*cameraPose));
    obj->render(OutProxy(*image), pose);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_getCloud(
    KinFu *obj, const interop::OutputArrayProxy *points, const interop::OutputArrayProxy *normals)
{ BEGIN_WRAP obj->getCloud(OutProxy(*points), OutProxy(*normals)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_getPoints(KinFu *obj, const interop::OutputArrayProxy *points)
{ BEGIN_WRAP obj->getPoints(OutProxy(*points)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_getNormals(
    KinFu *obj, const interop::InputArrayProxy *points, const interop::OutputArrayProxy *normals)
{ BEGIN_WRAP obj->getNormals(InProxy(*points), OutProxy(*normals)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_reset(KinFu *obj)
{ BEGIN_WRAP obj->reset(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_getPose(KinFu *obj, const interop::OutputArrayProxy *pose)
{
    BEGIN_WRAP
    const cv::Matx44f m = obj->getPose().matrix;
    cv::Mat(m).copyTo(OutProxy(*pose));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_kinfu_KinFu_update(KinFu *obj, const interop::InputArrayProxy *depth, int *returnValue)
{ BEGIN_WRAP *returnValue = obj->update(InProxy(*depth)) ? 1 : 0; END_WRAP }

#undef BEGIN_WRAP
#undef END_WRAP
#endif
