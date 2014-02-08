/*
* (C) 2008-2014 shimat
* This code is licenced under the LGPL.
*/

#ifndef _CPP_HIGHGUI_H_
#define _CPP_HIGHGUI_H_

#include "include_opencv.h"

CVAPI(void) highgui_namedWindow(const char *winname, int flags)
{
	cv::namedWindow(winname, flags);
}
CVAPI(void) highgui_imshow(const char *winname, cv::Mat *mat)
{
	cv::imshow(winname, *mat);
}
CVAPI(cv::Mat*) highgui_imread(const char *filename, int flags)
{
	cv::Mat ret = cv::imread(filename, flags);
	return new cv::Mat(ret);
}
CVAPI(int) highgui_imwrite(const char *filename, cv::Mat *img, int *params, int paramsLength)
{
	std::vector<int> paramsVec;
	paramsVec.assign(params, params + paramsLength);
	return cv::imwrite(filename, *img, paramsVec) ? 1 : 0;
}
CVAPI(cv::Mat*) highgui_imdecode(cv::Mat *buf, int flags)
{
	cv::Mat ret = cv::imdecode(*buf, flags);
	return new cv::Mat(ret);
}
CVAPI(void) highgui_imencode(const char *ext, cv::Mat *img, CvMat **buf, int *params, int paramsLength)
{
	//std::vector<int> paramsVec;
	//paramsVec.assign(params, params + paramsLength);
	//cv::imencode(ext, *img, paramsVec);
	CvMat imgMat = (CvMat)(*img);
	*buf = cvEncodeImage(ext, &imgMat, params);
}
CVAPI(int) highgui_waitKey(int delay)
{
	return cv::waitKey(delay);
}

CVAPI(void) highgui_destroyWindow(const char *winName)
{
	cv::destroyWindow(winName);
}
CVAPI(void) highgui_destroyAllWindows()
{
	cv::destroyAllWindows();
}

#endif