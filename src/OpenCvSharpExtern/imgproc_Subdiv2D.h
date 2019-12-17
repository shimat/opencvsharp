#ifndef _CPP_IMGPROC_SUBDIV2D_H_
#define _CPP_IMGPROC_SUBDIV2D_H_

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) imgproc_Subdiv2D_new1(cv::Subdiv2D **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Subdiv2D;
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_Subdiv2D_new2(MyCvRect rect, cv::Subdiv2D **returnValue)
{
    BEGIN_WRAP
    *returnValue = new cv::Subdiv2D(cpp(rect));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_delete(cv::Subdiv2D *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_initDelaunay(cv::Subdiv2D *obj, CvRect rect)
{
    BEGIN_WRAP
    obj->initDelaunay(rect);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_insert1(cv::Subdiv2D *obj, MyCvPoint2D32f pt, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->insert(cpp(pt));
    END_WRAP
}
CVAPI(ExceptionStatus) imgproc_Subdiv2D_insert2(cv::Subdiv2D *obj, MyCvPoint2D32f *ptArray, int length)
{
    BEGIN_WRAP
    std::vector<cv::Point2f> ptVec(length);
    for (int i = 0; i < length; i++)
    {
        ptVec[i] = cpp(ptArray[i]);
    }
    obj->insert(ptVec);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_locate(
    cv::Subdiv2D *obj, MyCvPoint2D32f pt, int *edge, int *vertex, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->locate(cpp(pt), *edge, *vertex);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_findNearest(
    cv::Subdiv2D *obj, MyCvPoint2D32f pt, MyCvPoint2D32f* nearestPt, int *returnValue)
{
    BEGIN_WRAP
    cv::Point2f nearestPt0;
    *returnValue = obj->findNearest(cpp(pt), &nearestPt0);
    *nearestPt = c(nearestPt0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getEdgeList(cv::Subdiv2D *obj, std::vector<cv::Vec4f> *edgeList)
{
    BEGIN_WRAP
    obj->getEdgeList(*edgeList);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getLeadingEdgeList(cv::Subdiv2D *obj,  std::vector<int> *leadingEdgeList)
{
    BEGIN_WRAP
    obj->getLeadingEdgeList(*leadingEdgeList);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getTriangleList(cv::Subdiv2D *obj, std::vector<cv::Vec6f> *triangleList)
{
    BEGIN_WRAP
    obj->getTriangleList(*triangleList);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getVoronoiFacetList(
    cv::Subdiv2D *obj, int *idx, int idxCount,
    std::vector<std::vector<cv::Point2f> > *facetList, std::vector<cv::Point2f> *facetCenters)
{
    BEGIN_WRAP
    std::vector<int> idxVec;
    if (idx != nullptr)
        idxVec = std::vector<int>(idx, idx + idxCount);
    obj->getVoronoiFacetList(idxVec, *facetList, *facetCenters);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getVertex(cv::Subdiv2D *obj, int vertex, int* firstEdge, MyCvPoint2D32f *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(obj->getVertex(vertex, firstEdge));
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_getEdge(cv::Subdiv2D *obj, int edge, int nextEdgeType, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->getEdge(edge, nextEdgeType);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_nextEdge(cv::Subdiv2D *obj, int edge, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->nextEdge(edge);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_rotateEdge(cv::Subdiv2D *obj, int edge, int rotate, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->rotateEdge(edge, rotate);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_symEdge(cv::Subdiv2D *obj, int edge, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = obj->symEdge(edge);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_edgeOrg(cv::Subdiv2D *obj, int edge, MyCvPoint2D32f *orgPt, int *returnValue)
{
    BEGIN_WRAP
    cv::Point2f orgPt0;
    *returnValue = obj->edgeOrg(edge, &orgPt0);
    *orgPt = c(orgPt0);
    END_WRAP
}

CVAPI(ExceptionStatus) imgproc_Subdiv2D_edgeDst(cv::Subdiv2D *obj, int edge, MyCvPoint2D32f *dstPt, int *returnValue)
{
    BEGIN_WRAP
    cv::Point2f dstPt0;
    *returnValue = obj->edgeDst(edge, &dstPt0);
    *dstPt = c(dstPt0);
    END_WRAP
}

#endif