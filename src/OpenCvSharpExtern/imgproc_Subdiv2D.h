#pragma once

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) imgproc_Subdiv2D_new1(cv::Subdiv2D **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Subdiv2D;
    });
}
CVAPI(ExceptionStatus) imgproc_Subdiv2D_new2(interop::Rect rect, cv::Subdiv2D **returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Subdiv2D(cpp(rect));
    });
}
CVAPI(ExceptionStatus) imgproc_Subdiv2D_new3(interop::Rect2f rect, cv::Subdiv2D** returnValue)
{
    return cvTry([&] {
    *returnValue = new cv::Subdiv2D(cpp(rect));
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_delete(cv::Subdiv2D *obj)
{
    return cvTry([&] {
    delete obj;
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_initDelaunay1(cv::Subdiv2D *obj, interop::Rect rect)
{
    return cvTry([&] {
    obj->initDelaunay(cpp(rect));
    });
}
CVAPI(ExceptionStatus) imgproc_Subdiv2D_initDelaunay2(cv::Subdiv2D* obj, interop::Rect2f rect)
{
    return cvTry([&] {
    obj->initDelaunay(cpp(rect));
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_insert1(cv::Subdiv2D *obj, interop::Point2f pt, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->insert(cpp(pt));
    });
}
CVAPI(ExceptionStatus) imgproc_Subdiv2D_insert2(cv::Subdiv2D *obj, interop::Point2f *ptArray, int length)
{
    return cvTry([&] {
    std::vector<cv::Point2f> ptVec(length);
    for (int i = 0; i < length; i++)
    {
        ptVec[i] = cpp(ptArray[i]);
    }
    obj->insert(ptVec);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_locate(
    cv::Subdiv2D *obj, interop::Point2f pt, int *edge, int *vertex, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->locate(cpp(pt), *edge, *vertex);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_findNearest(
    cv::Subdiv2D *obj, interop::Point2f pt, interop::Point2f* nearestPt, int *returnValue)
{
    return cvTry([&] {
    cv::Point2f nearestPt0;
    *returnValue = obj->findNearest(cpp(pt), &nearestPt0);
    *nearestPt = c(nearestPt0);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getEdgeList(cv::Subdiv2D *obj, std::vector<cv::Vec4f> *edgeList)
{
    return cvTry([&] {
    obj->getEdgeList(*edgeList);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getLeadingEdgeList(cv::Subdiv2D *obj,  std::vector<int> *leadingEdgeList)
{
    return cvTry([&] {
    obj->getLeadingEdgeList(*leadingEdgeList);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getTriangleList(cv::Subdiv2D *obj, std::vector<cv::Vec6f> *triangleList)
{
    return cvTry([&] {
    obj->getTriangleList(*triangleList);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getVoronoiFacetList(
    cv::Subdiv2D *obj, int *idx, int idxCount,
    std::vector<std::vector<cv::Point2f> > *facetList, std::vector<cv::Point2f> *facetCenters)
{
    return cvTry([&] {
    std::vector<int> idxVec;
    if (idx != nullptr)
        idxVec = std::vector<int>(idx, idx + idxCount);
    obj->getVoronoiFacetList(idxVec, *facetList, *facetCenters);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getVertex(cv::Subdiv2D *obj, int vertex, int* firstEdge, interop::Point2f *returnValue)
{
    return cvTry([&] {
    *returnValue = c(obj->getVertex(vertex, firstEdge));
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getEdge(cv::Subdiv2D *obj, int edge, int nextEdgeType, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->getEdge(edge, nextEdgeType);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_nextEdge(cv::Subdiv2D *obj, int edge, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->nextEdge(edge);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_rotateEdge(cv::Subdiv2D *obj, int edge, int rotate, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->rotateEdge(edge, rotate);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_symEdge(cv::Subdiv2D *obj, int edge, int *returnValue)
{
    return cvTry([&] {
    *returnValue = obj->symEdge(edge);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_edgeOrg(cv::Subdiv2D *obj, int edge, interop::Point2f *orgPt, int *returnValue)
{
    return cvTry([&] {
    cv::Point2f orgPt0;
    *returnValue = obj->edgeOrg(edge, &orgPt0);
    *orgPt = c(orgPt0);
    });
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_edgeDst(cv::Subdiv2D *obj, int edge, interop::Point2f *dstPt, int *returnValue)
{
    return cvTry([&] {
    cv::Point2f dstPt0;
    *returnValue = obj->edgeDst(edge, &dstPt0);
    *dstPt = c(dstPt0);
    });
}
