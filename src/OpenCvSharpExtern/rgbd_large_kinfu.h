#pragma once
#ifndef NO_CONTRIB
#include "include_opencv.h"
#include "rgbd_kinfu.h" // toCv/toInterop Vec3i/Vec3f helpers

// Keep the exported functions compact while using the repository's cvTry exception boundary.
#define BEGIN_WRAP return cvTry([&] {
#define END_WRAP });

using cv::large_kinfu::LargeKinfu;
using LargeKinfuParams = cv::large_kinfu::Params;
using LargeKinfuVolumeParams = cv::large_kinfu::VolumeParams;

/// <summary>
/// Plain-C struct for marshaling the scalar fields of large_kinfu::VolumeParams across the P/Invoke
/// boundary. The Matx44f pose field is marshaled as a separate argument.
/// Layout must stay in sync with OpenCvSharp.Rgbd.LargeKinfuVolumeParams in C#.
/// </summary>
struct CvLargeKinfuVolumeParams
{
    int32_t Kind;
    int32_t ResolutionX;
    int32_t ResolutionY;
    int32_t ResolutionZ;
    int32_t UnitResolution;
    float   VolumeSize;
    float   VoxelSize;
    float   TsdfTruncDist;
    int32_t MaxWeight;
    float   DepthTruncThreshold;
    float   RaycastStepFactor;
};

/// <summary>
/// Plain-C struct for marshaling the scalar/fixed-size fields of large_kinfu::Params (excluding its
/// nested VolumeParams, which is marshaled separately as CvLargeKinfuVolumeParams). The Matx33f
/// fields (intr, rgb_intr) and the icpIterations vector are marshaled as separate arguments.
/// Layout must stay in sync with OpenCvSharp.Rgbd.LargeKinfuParams in C#.
/// </summary>
struct CvLargeKinfuParams
{
    interop::Size FrameSize;
    float         DepthFactor;
    float         BilateralSigmaDepth;
    float         BilateralSigmaSpatial;
    int32_t       BilateralKernelSize;
    int32_t       PyramidLevels;
    float         TsdfMinCameraMovement;
    interop::Vec3f LightPose;
    float         IcpDistThresh;
    float         IcpAngleThresh;
    float         TruncateThreshold;
};

static void ReadLargeKinfuVolumeParams(
    const LargeKinfuVolumeParams &v, CvLargeKinfuVolumeParams *pod, const interop::OutputArrayProxy *pose)
{
    pod->Kind = static_cast<int32_t>(v.kind);
    pod->ResolutionX = v.resolutionX;
    pod->ResolutionY = v.resolutionY;
    pod->ResolutionZ = v.resolutionZ;
    pod->UnitResolution = v.unitResolution;
    pod->VolumeSize = v.volumSize;
    pod->VoxelSize = v.voxelSize;
    pod->TsdfTruncDist = v.tsdfTruncDist;
    pod->MaxWeight = v.maxWeight;
    pod->DepthTruncThreshold = v.depthTruncThreshold;
    pod->RaycastStepFactor = v.raycastStepFactor;
    cv::Mat(v.pose).copyTo(OutProxy(*pose));
}

static LargeKinfuVolumeParams BuildLargeKinfuVolumeParams(
    const CvLargeKinfuVolumeParams *pod, const interop::InputArrayProxy *pose)
{
    LargeKinfuVolumeParams v;
    v.kind = static_cast<cv::VolumeType>(pod->Kind);
    v.resolutionX = pod->ResolutionX;
    v.resolutionY = pod->ResolutionY;
    v.resolutionZ = pod->ResolutionZ;
    v.unitResolution = pod->UnitResolution;
    v.volumSize = pod->VolumeSize;
    v.pose = cv::Matx44f(getMatFromProxy(*pose));
    v.voxelSize = pod->VoxelSize;
    v.tsdfTruncDist = pod->TsdfTruncDist;
    v.maxWeight = pod->MaxWeight;
    v.depthTruncThreshold = pod->DepthTruncThreshold;
    v.raycastStepFactor = pod->RaycastStepFactor;
    return v;
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_VolumeParams_defaultParams(
    int volumeType, CvLargeKinfuVolumeParams *pod, const interop::OutputArrayProxy *pose)
{
    BEGIN_WRAP
    const auto v = LargeKinfuVolumeParams::defaultParams(static_cast<cv::VolumeType>(volumeType));
    ReadLargeKinfuVolumeParams(*v, pod, pose);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_VolumeParams_coarseParams(
    int volumeType, CvLargeKinfuVolumeParams *pod, const interop::OutputArrayProxy *pose)
{
    BEGIN_WRAP
    const auto v = LargeKinfuVolumeParams::coarseParams(static_cast<cv::VolumeType>(volumeType));
    ReadLargeKinfuVolumeParams(*v, pod, pose);
    END_WRAP
}

static LargeKinfuParams BuildLargeKinfuParams(
    const CvLargeKinfuParams *pod, const interop::InputArrayProxy *intr, const interop::InputArrayProxy *rgbIntr,
    const std::vector<int> *icpIterations,
    const CvLargeKinfuVolumeParams *volumePod, const interop::InputArrayProxy *volumePose)
{
    LargeKinfuParams p;
    p.frameSize = cpp(pod->FrameSize);
    p.intr = cv::Matx33f(getMatFromProxy(*intr));
    p.rgb_intr = cv::Matx33f(getMatFromProxy(*rgbIntr));
    p.depthFactor = pod->DepthFactor;
    p.bilateral_sigma_depth = pod->BilateralSigmaDepth;
    p.bilateral_sigma_spatial = pod->BilateralSigmaSpatial;
    p.bilateral_kernel_size = pod->BilateralKernelSize;
    p.pyramidLevels = pod->PyramidLevels;
    p.tsdf_min_camera_movement = pod->TsdfMinCameraMovement;
    p.lightPose = toCv(pod->LightPose);
    p.icpDistThresh = pod->IcpDistThresh;
    p.icpAngleThresh = pod->IcpAngleThresh;
    p.icpIterations = *icpIterations;
    p.truncateThreshold = pod->TruncateThreshold;
    p.volumeParams = BuildLargeKinfuVolumeParams(volumePod, volumePose);
    return p;
}

static void ReadLargeKinfuParams(
    const LargeKinfuParams &p, CvLargeKinfuParams *pod, const interop::OutputArrayProxy *intr,
    const interop::OutputArrayProxy *rgbIntr, std::vector<int> *icpIterations,
    CvLargeKinfuVolumeParams *volumePod, const interop::OutputArrayProxy *volumePose)
{
    pod->FrameSize = c(p.frameSize);
    pod->DepthFactor = p.depthFactor;
    pod->BilateralSigmaDepth = p.bilateral_sigma_depth;
    pod->BilateralSigmaSpatial = p.bilateral_sigma_spatial;
    pod->BilateralKernelSize = p.bilateral_kernel_size;
    pod->PyramidLevels = p.pyramidLevels;
    pod->TsdfMinCameraMovement = p.tsdf_min_camera_movement;
    pod->LightPose = toInterop(p.lightPose);
    pod->IcpDistThresh = p.icpDistThresh;
    pod->IcpAngleThresh = p.icpAngleThresh;
    pod->TruncateThreshold = p.truncateThreshold;
    cv::Mat(p.intr).copyTo(OutProxy(*intr));
    cv::Mat(p.rgb_intr).copyTo(OutProxy(*rgbIntr));
    *icpIterations = p.icpIterations;
    ReadLargeKinfuVolumeParams(p.volumeParams, volumePod, volumePose);
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_Params_defaultParams(
    CvLargeKinfuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    std::vector<int> *icpIterations, CvLargeKinfuVolumeParams *volumePod, const interop::OutputArrayProxy *volumePose)
{
    BEGIN_WRAP
    const auto p = LargeKinfuParams::defaultParams();
    ReadLargeKinfuParams(*p, pod, intr, rgbIntr, icpIterations, volumePod, volumePose);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_Params_coarseParams(
    CvLargeKinfuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    std::vector<int> *icpIterations, CvLargeKinfuVolumeParams *volumePod, const interop::OutputArrayProxy *volumePose)
{
    BEGIN_WRAP
    const auto p = LargeKinfuParams::coarseParams();
    ReadLargeKinfuParams(*p, pod, intr, rgbIntr, icpIterations, volumePod, volumePose);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_Params_hashTSDFParams(
    int isCoarse, CvLargeKinfuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    std::vector<int> *icpIterations, CvLargeKinfuVolumeParams *volumePod, const interop::OutputArrayProxy *volumePose)
{
    BEGIN_WRAP
    const auto p = LargeKinfuParams::hashTSDFParams(isCoarse != 0);
    ReadLargeKinfuParams(*p, pod, intr, rgbIntr, icpIterations, volumePod, volumePose);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_Ptr_LargeKinfu_delete(cv::Ptr<LargeKinfu> *obj)
{ BEGIN_WRAP delete obj; END_WRAP }

CVAPI(ExceptionStatus) rgbd_large_kinfu_Ptr_LargeKinfu_get(cv::Ptr<LargeKinfu> *obj, LargeKinfu **returnValue)
{ BEGIN_WRAP *returnValue = obj->get(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_create(
    const CvLargeKinfuParams *pod, const interop::InputArrayProxy *intr, const interop::InputArrayProxy *rgbIntr,
    const std::vector<int> *icpIterations, const CvLargeKinfuVolumeParams *volumePod,
    const interop::InputArrayProxy *volumePose, cv::Ptr<LargeKinfu> **returnValue)
{
    BEGIN_WRAP
    const auto p = BuildLargeKinfuParams(pod, intr, rgbIntr, icpIterations, volumePod, volumePose);
    *returnValue = new cv::Ptr<LargeKinfu>(LargeKinfu::create(cv::makePtr<LargeKinfuParams>(p)));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_getParams(
    LargeKinfu *obj, CvLargeKinfuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    std::vector<int> *icpIterations, CvLargeKinfuVolumeParams *volumePod, const interop::OutputArrayProxy *volumePose)
{
    BEGIN_WRAP
    ReadLargeKinfuParams(obj->getParams(), pod, intr, rgbIntr, icpIterations, volumePod, volumePose);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_render(LargeKinfu *obj, const interop::OutputArrayProxy *image)
{ BEGIN_WRAP obj->render(OutProxy(*image)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_renderWithPose(
    LargeKinfu *obj, const interop::OutputArrayProxy *image, const interop::InputArrayProxy *cameraPose)
{
    BEGIN_WRAP
    const cv::Matx44f pose(getMatFromProxy(*cameraPose));
    obj->render(OutProxy(*image), pose);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_getCloud(
    LargeKinfu *obj, const interop::OutputArrayProxy *points, const interop::OutputArrayProxy *normals)
{ BEGIN_WRAP obj->getCloud(OutProxy(*points), OutProxy(*normals)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_getPoints(LargeKinfu *obj, const interop::OutputArrayProxy *points)
{ BEGIN_WRAP obj->getPoints(OutProxy(*points)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_getNormals(
    LargeKinfu *obj, const interop::InputArrayProxy *points, const interop::OutputArrayProxy *normals)
{ BEGIN_WRAP obj->getNormals(InProxy(*points), OutProxy(*normals)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_reset(LargeKinfu *obj)
{ BEGIN_WRAP obj->reset(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_getPose(LargeKinfu *obj, const interop::OutputArrayProxy *pose)
{
    BEGIN_WRAP
    const cv::Matx44f m = obj->getPose().matrix;
    cv::Mat(m).copyTo(OutProxy(*pose));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_large_kinfu_LargeKinfu_update(LargeKinfu *obj, const interop::InputArrayProxy *depth, int *returnValue)
{ BEGIN_WRAP *returnValue = obj->update(InProxy(*depth)) ? 1 : 0; END_WRAP }

#undef BEGIN_WRAP
#undef END_WRAP
#endif
