#pragma once
#ifndef NO_PTCLOUD
#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

static cv::Mat ptcloud_octreeInputRow(const cv::_InputArray& input)
{
    if (input.empty()) return {};
    cv::Mat mat = input.getMat();
    // Octree::fill transposes into the same Mat variable. A column vector can
    // alias its transposed destination and fail on some architectures.
    if (mat.channels() == 3 && mat.cols == 1 && mat.rows > 1)
        return mat.t();
    return mat;
}

CVAPI(ExceptionStatus) ptcloud_Octree_createWithDepthSize(int maxDepth, double size,
    interop::Point3f origin, int withColors, cv::Ptr<cv::Octree>** returnValue)
{
    return cvTry([&] { *returnValue = new cv::Ptr<cv::Octree>(
        cv::Octree::createWithDepth(maxDepth, size, cpp(origin), withColors != 0)); });
}

CVAPI(ExceptionStatus) ptcloud_Octree_createWithDepthCloud(int maxDepth,
    const interop::InputArrayProxy* cloud, const interop::InputArrayProxy* colors,
    cv::Ptr<cv::Octree>** returnValue)
{
    return cvTry([&] {
        const cv::Mat cloudMat = ptcloud_octreeInputRow(InProxy(*cloud));
        const cv::Mat colorsMat = ptcloud_octreeInputRow(InProxy(*colors));
        *returnValue = new cv::Ptr<cv::Octree>(
            cv::Octree::createWithDepth(maxDepth, cloudMat, colorsMat));
    });
}

CVAPI(ExceptionStatus) ptcloud_Octree_createWithResolutionSize(double resolution,
    double size, interop::Point3f origin, int withColors, cv::Ptr<cv::Octree>** returnValue)
{
    return cvTry([&] { *returnValue = new cv::Ptr<cv::Octree>(
        cv::Octree::createWithResolution(resolution, size, cpp(origin), withColors != 0)); });
}

CVAPI(ExceptionStatus) ptcloud_Octree_createWithResolutionCloud(double resolution,
    const interop::InputArrayProxy* cloud, const interop::InputArrayProxy* colors,
    cv::Ptr<cv::Octree>** returnValue)
{
    return cvTry([&] {
        const cv::Mat cloudMat = ptcloud_octreeInputRow(InProxy(*cloud));
        const cv::Mat colorsMat = ptcloud_octreeInputRow(InProxy(*colors));
        *returnValue = new cv::Ptr<cv::Octree>(
            cv::Octree::createWithResolution(resolution, cloudMat, colorsMat));
    });
}

CVAPI(ExceptionStatus) ptcloud_Ptr_Octree_delete(cv::Ptr<cv::Octree>* obj)
{ return cvTry([&] { delete obj; }); }
CVAPI(ExceptionStatus) ptcloud_Ptr_Octree_get(cv::Ptr<cv::Octree>* obj, cv::Octree** returnValue)
{ return cvTry([&] { *returnValue = obj->get(); }); }

CVAPI(ExceptionStatus) ptcloud_Octree_insertPoint(cv::Octree* obj,
    interop::Point3f point, interop::Point3f color, int* returnValue)
{ return cvTry([&] { *returnValue = obj->insertPoint(cpp(point), cpp(color)) ? 1 : 0; }); }
CVAPI(ExceptionStatus) ptcloud_Octree_isPointInBound(cv::Octree* obj,
    interop::Point3f point, int* returnValue)
{ return cvTry([&] { *returnValue = obj->isPointInBound(cpp(point)) ? 1 : 0; }); }
CVAPI(ExceptionStatus) ptcloud_Octree_empty(cv::Octree* obj, int* returnValue)
{ return cvTry([&] { *returnValue = obj->empty() ? 1 : 0; }); }
CVAPI(ExceptionStatus) ptcloud_Octree_clear(cv::Octree* obj)
{ return cvTry([&] { obj->clear(); }); }
CVAPI(ExceptionStatus) ptcloud_Octree_deletePoint(cv::Octree* obj,
    interop::Point3f point, int* returnValue)
{ return cvTry([&] { *returnValue = obj->deletePoint(cpp(point)) ? 1 : 0; }); }

CVAPI(ExceptionStatus) ptcloud_Octree_getPointCloud(cv::Octree* obj,
    const interop::OutputArrayProxy* cloud, const interop::OutputArrayProxy* colors)
{ return cvTry([&] { obj->getPointCloudByOctree(OutProxy(*cloud), OutProxy(*colors)); }); }

CVAPI(ExceptionStatus) ptcloud_Octree_radiusSearch(cv::Octree* obj,
    interop::Point3f query, float radius, const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* squareDists, int* returnValue)
{ return cvTry([&] { *returnValue = obj->radiusNNSearch(
    cpp(query), radius, OutProxy(*points), OutProxy(*squareDists)); }); }

CVAPI(ExceptionStatus) ptcloud_Octree_radiusSearchColor(cv::Octree* obj,
    interop::Point3f query, float radius, const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* colors, const interop::OutputArrayProxy* squareDists,
    int* returnValue)
{ return cvTry([&] { *returnValue = obj->radiusNNSearch(cpp(query), radius,
    OutProxy(*points), OutProxy(*colors), OutProxy(*squareDists)); }); }

CVAPI(ExceptionStatus) ptcloud_Octree_knnSearch(cv::Octree* obj,
    interop::Point3f query, int k, const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* squareDists)
{ return cvTry([&] { obj->KNNSearch(cpp(query), k,
    OutProxy(*points), OutProxy(*squareDists)); }); }

CVAPI(ExceptionStatus) ptcloud_Octree_knnSearchColor(cv::Octree* obj,
    interop::Point3f query, int k, const interop::OutputArrayProxy* points,
    const interop::OutputArrayProxy* colors, const interop::OutputArrayProxy* squareDists)
{ return cvTry([&] { obj->KNNSearch(cpp(query), k,
    OutProxy(*points), OutProxy(*colors), OutProxy(*squareDists)); }); }
#endif
