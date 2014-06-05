#ifndef _CPP_IMGPROC_SUBDIV2D_H_
#define _CPP_IMGPROC_SUBDIV2D_H_

#include "include_opencv.h"

CVAPI(cv::Subdiv2D*) imgproc_Subdiv2D_new1()
{
	return new cv::Subdiv2D();
}
CVAPI(cv::Subdiv2D*) imgproc_Subdiv2D_new2(CvRect rect)
{
	return new cv::Subdiv2D(rect);
}
CVAPI(void) imgproc_Subdiv2D_delete(cv::Subdiv2D *obj)
{
	delete obj;
}

CVAPI(void) imgproc_Subdiv2D_initDelaunay(cv::Subdiv2D *obj, CvRect rect)
{
	obj->initDelaunay(rect);
}
CVAPI(int) imgproc_Subdiv2D_insert1(cv::Subdiv2D *obj, CvPoint2D32f pt)
{
	return obj->insert(pt);
}
CVAPI(void) imgproc_Subdiv2D_insert2(cv::Subdiv2D *obj, CvPoint2D32f *ptArray, int length)
{
	std::vector<cv::Point2f> ptvec(length);
	for (int i = 0; i < length; i++)
	{
		ptvec[i] = ptArray[i];
	}
	obj->insert(ptvec);
}
CVAPI(int) imgproc_Subdiv2D_locate(cv::Subdiv2D *obj, CvPoint2D32f pt, int *edge, int *vertex)
{
	return obj->locate(pt, *edge, *vertex);
}
CVAPI(int) imgproc_Subdiv2D_findNearest(cv::Subdiv2D *obj, CvPoint2D32f pt, CvPoint2D32f* nearestPt)
{
	cv::Point2f nearestPt0;
	int ret = obj->findNearest(pt, &nearestPt0);
	*nearestPt = nearestPt0;
	return ret;
}
CVAPI(void) imgproc_Subdiv2D_getEdgeList(cv::Subdiv2D *obj, std::vector<cv::Vec4f> **edgeList)
{
	*edgeList = new std::vector<cv::Vec4f>();
	obj->getEdgeList(**edgeList);
}
CVAPI(void) imgproc_Subdiv2D_getTriangleList(cv::Subdiv2D *obj, std::vector<cv::Vec6f> **triangleList)
{
	*triangleList = new std::vector<cv::Vec6f>();
	obj->getTriangleList(**triangleList);
}
CVAPI(void) imgproc_Subdiv2D_getVoronoiFacetList(cv::Subdiv2D *obj, int *idx, int idxCount,
	std::vector<std::vector<cv::Point2f> > **facetList, std::vector<cv::Point2f> **facetCenters)
{
	std::vector<int> idxVec;
	if (idx != NULL)
		idxVec = std::vector<int>(idx, idx + idxCount);
	*facetList = new std::vector<std::vector<cv::Point2f> >();
	*facetCenters = new std::vector<cv::Point2f>();
	obj->getVoronoiFacetList(idxVec, **facetList, **facetCenters);
}

CVAPI(CvPoint2D32f) imgproc_Subdiv2D_getVertex(cv::Subdiv2D *obj, int vertex, int* firstEdge)
{
	return obj->getVertex(vertex, firstEdge);
}
CVAPI(int) imgproc_Subdiv2D_getEdge(cv::Subdiv2D *obj, int edge, int nextEdgeType)
{
	return obj->getEdge(edge, nextEdgeType);
}
CVAPI(int) imgproc_Subdiv2D_nextEdge(cv::Subdiv2D *obj, int edge)
{
	return obj->nextEdge(edge);
}
CVAPI(int) imgproc_Subdiv2D_rotateEdge(cv::Subdiv2D *obj, int edge, int rotate)
{
	return obj->rotateEdge(edge, rotate);
}
CVAPI(int) imgproc_Subdiv2D_symEdge(cv::Subdiv2D *obj, int edge)
{
	return obj->symEdge(edge);
}
CVAPI(int) imgproc_Subdiv2D_edgeOrg(cv::Subdiv2D *obj, int edge, CvPoint2D32f *orgpt)
{
	cv::Point2f orgpt0;
	int ret = obj->edgeOrg(edge, &orgpt0);
	*orgpt = orgpt0;
	return ret;
}
CVAPI(int) imgproc_Subdiv2D_edgeDst(cv::Subdiv2D *obj, int edge, CvPoint2D32f *dstpt)
{
	cv::Point2f dstpt0;
	int ret = obj->edgeDst(edge, &dstpt0);
	*dstpt = dstpt0;
	return ret;
}


#endif