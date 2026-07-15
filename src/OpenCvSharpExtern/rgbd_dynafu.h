#pragma once
#ifndef NO_CONTRIB
#include "include_opencv.h"
#include "rgbd_kinfu.h" // BuildKinfuParams / ReadKinfuParams (dynafu::Params is an alias of kinfu::Params)

// Keep the exported functions compact while using the repository's cvTry exception boundary.
#define BEGIN_WRAP return cvTry([&] {
#define END_WRAP });

using cv::dynafu::DynaFu;

CVAPI(ExceptionStatus) rgbd_dynafu_Ptr_DynaFu_delete(cv::Ptr<DynaFu> *obj)
{ BEGIN_WRAP delete obj; END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_Ptr_DynaFu_get(cv::Ptr<DynaFu> *obj, DynaFu **returnValue)
{ BEGIN_WRAP *returnValue = obj->get(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_create(
    const CvKinFuParams *pod, const interop::InputArrayProxy *intr, const interop::InputArrayProxy *rgbIntr,
    const interop::InputArrayProxy *volumePose, const std::vector<int> *icpIterations,
    cv::Ptr<DynaFu> **returnValue)
{
    BEGIN_WRAP
    const auto p = BuildKinfuParams(pod, intr, rgbIntr, volumePose, icpIterations);
    *returnValue = new cv::Ptr<DynaFu>(DynaFu::create(cv::makePtr<cv::kinfu::Params>(p)));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_getParams(
    DynaFu *obj, CvKinFuParams *pod, const interop::OutputArrayProxy *intr, const interop::OutputArrayProxy *rgbIntr,
    const interop::OutputArrayProxy *volumePose, std::vector<int> *icpIterations)
{
    BEGIN_WRAP
    ReadKinfuParams(obj->getParams(), pod, intr, rgbIntr, volumePose, icpIterations);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_render(DynaFu *obj, const interop::OutputArrayProxy *image)
{ BEGIN_WRAP obj->render(OutProxy(*image)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_renderWithPose(
    DynaFu *obj, const interop::OutputArrayProxy *image, const interop::InputArrayProxy *cameraPose)
{
    BEGIN_WRAP
    const cv::Matx44f pose(getMatFromProxy(*cameraPose));
    obj->render(OutProxy(*image), pose);
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_getCloud(
    DynaFu *obj, const interop::OutputArrayProxy *points, const interop::OutputArrayProxy *normals)
{ BEGIN_WRAP obj->getCloud(OutProxy(*points), OutProxy(*normals)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_getPoints(DynaFu *obj, const interop::OutputArrayProxy *points)
{ BEGIN_WRAP obj->getPoints(OutProxy(*points)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_getNormals(
    DynaFu *obj, const interop::InputArrayProxy *points, const interop::OutputArrayProxy *normals)
{ BEGIN_WRAP obj->getNormals(InProxy(*points), OutProxy(*normals)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_reset(DynaFu *obj)
{ BEGIN_WRAP obj->reset(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_getPose(DynaFu *obj, const interop::OutputArrayProxy *pose)
{
    BEGIN_WRAP
    const cv::Matx44f m = obj->getPose().matrix;
    cv::Mat(m).copyTo(OutProxy(*pose));
    END_WRAP
}

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_update(DynaFu *obj, const interop::InputArrayProxy *depth, int *returnValue)
{ BEGIN_WRAP *returnValue = obj->update(InProxy(*depth)) ? 1 : 0; END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_getNodesPos(DynaFu *obj, std::vector<cv::Point3f> *returnValue)
{ BEGIN_WRAP *returnValue = obj->getNodesPos(); END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_marchCubes(
    DynaFu *obj, const interop::OutputArrayProxy *vertices, const interop::OutputArrayProxy *edges)
{ BEGIN_WRAP obj->marchCubes(OutProxy(*vertices), OutProxy(*edges)); END_WRAP }

CVAPI(ExceptionStatus) rgbd_dynafu_DynaFu_renderSurface(
    DynaFu *obj, const interop::OutputArrayProxy *depthImage, const interop::OutputArrayProxy *vertImage,
    const interop::OutputArrayProxy *normImage, int warp)
{ BEGIN_WRAP obj->renderSurface(OutProxy(*depthImage), OutProxy(*vertImage), OutProxy(*normImage), warp != 0); END_WRAP }

#undef BEGIN_WRAP
#undef END_WRAP
#endif
