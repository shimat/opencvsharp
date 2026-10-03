#pragma once
#ifndef NO_PTCLOUD
#include "include_opencv.h"
#include <opencv2/ptcloud.hpp>

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
    return cvTry([&] { *returnValue = new cv::Ptr<cv::Octree>(
        cv::Octree::createWithDepth(maxDepth, InProxy(*cloud), InProxy(*colors))); });
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
    return cvTry([&] { *returnValue = new cv::Ptr<cv::Octree>(
        cv::Octree::createWithResolution(resolution, InProxy(*cloud), InProxy(*colors))); });
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
