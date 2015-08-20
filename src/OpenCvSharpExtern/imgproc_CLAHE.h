#ifndef _CPP_IMGPROC_CLAHE_H_
#define _CPP_IMGPROC_CLAHE_H_

#include "include_opencv.h"


CVAPI(cv::Ptr<cv::CLAHE>*) imgproc_createCLAHE(double clipLimit, CvSize tileGridSize)
{
	cv::Ptr<cv::CLAHE> ret = cv::createCLAHE(clipLimit, tileGridSize);
	return clone(ret);
}

CVAPI(void) imgproc_Ptr_CLAHE_delete(cv::Ptr<cv::CLAHE> *obj)
{
	delete obj;
}

CVAPI(cv::CLAHE*) imgproc_Ptr_CLAHE_obj(cv::Ptr<cv::CLAHE> *obj)
{
	return obj->obj;
}

CVAPI(cv::AlgorithmInfo*) imgproc_CLAHE_info(cv::CLAHE *obj)
{
	return obj->info();
}


CVAPI(void) imgproc_CLAHE_apply(cv::CLAHE *obj, cv::_InputArray *src, cv::_OutputArray *dst)
{
	obj->apply(*src, *dst);
}

CVAPI(void) imgproc_CLAHE_setClipLimit(cv::CLAHE *obj, double clipLimit)
{
	obj->setClipLimit(clipLimit);
}

CVAPI(double) imgproc_CLAHE_getClipLimit(cv::CLAHE *obj)
{
	return obj->getClipLimit();
}

CVAPI(void) imgproc_CLAHE_setTilesGridSize(cv::CLAHE *obj, CvSize tileGridSize)
{
	obj->setTilesGridSize(tileGridSize);
}

CVAPI(CvSize) imgproc_CLAHE_getTilesGridSize(cv::CLAHE *obj)
{
	return obj->getTilesGridSize();
}

CVAPI(void) imgproc_CLAHE_collectGarbage(cv::CLAHE *obj)
{
	obj->collectGarbage();
}

#endif