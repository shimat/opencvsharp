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
CVAPI(void) highgui_destroyWindow(const char *winName)
{
	cv::destroyWindow(winName);
}
CVAPI(void) highgui_destroyAllWindows()
{
	cv::destroyAllWindows();
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
CVAPI(int) highgui_startWindowThread()
{
	return cv::startWindowThread();
}
CVAPI(int) highgui_waitKey(int delay)
{
	return cv::waitKey(delay);
}

CVAPI(void) highgui_resizeWindow(const char *winName, int width, int height)
{
	cv::resizeWindow(winName, width, height);
}
CVAPI(void) highgui_moveWindow(const char *winName, int x, int y)
{
	cv::moveWindow(winName, x, y);
}

CVAPI(void) highgui_setWindowProperty(const char *winName, int propId, double propValue)
{
	cv::setWindowProperty(winName, propId, propValue);
}
CVAPI(double) highgui_getWindowProperty(const char *winName, int propId)
{
	return cv::getWindowProperty(winName, propId);
}

CVAPI(void) highgui_setMouseCallback(const char *winName, cv::MouseCallback onMouse, void* userData)
{
	cv::setMouseCallback(winName, onMouse, userData);
}
CVAPI(int) highgui_createTrackbar(const char *trackbarName, const char *winName,
	int* value, int count, cv::TrackbarCallback onChange, void* userData)
{
	return cv::createTrackbar(trackbarName, winName, value, count, onChange, userData);
}
CVAPI(int) highgui_getTrackbarPos(const char *trackbarName, const char *winName)
{
	return cv::getTrackbarPos(trackbarName, winName);
}
CVAPI(void) highgui_setTrackbarPos(const char *trackbarName, const char *winName, int pos)
{
	cv::setTrackbarPos(trackbarName, winName, pos);
}

#pragma region VideoCapture

CVAPI(cv::VideoCapture*) highgui_VideoCapture_new()
{
	return new cv::VideoCapture();
}
CVAPI(cv::VideoCapture*) highgui_VideoCapture_new_fromFile(const char *fileName)
{
	return new cv::VideoCapture(fileName);
}
CVAPI(cv::VideoCapture*) highgui_VideoCapture_new_fromDevice(int device)
{
	return new cv::VideoCapture(device);
}
CVAPI(void) highgui_VideoCapture_delete(cv::VideoCapture *obj)
{
	delete obj;
}

CVAPI(void) highgui_VideoCapture_open_fromFile(cv::VideoCapture *obj, const char *fileName)
{
	obj->open(fileName);
}
CVAPI(void) highgui_VideoCapture_open_fromDevice(cv::VideoCapture *obj, int device)
{
	obj->open(device);
}
CVAPI(int) highgui_VideoCapture_isOpened(cv::VideoCapture *obj)
{
	return obj->isOpened();
}
CVAPI(void) highgui_VideoCapture_release(cv::VideoCapture *obj)
{
	obj->release();
}

CVAPI(int) highgui_VideoCapture_grab(cv::VideoCapture *obj)
{
	return obj->grab() ? 1: 0;
}
CVAPI(int) highgui_VideoCapture_retrieve(cv::VideoCapture *obj, cv::Mat *image, int channel)
{
	return obj->retrieve(*image, channel) ? 1 : 0;
}
CVAPI(int) highgui_VideoCapture_read(cv::VideoCapture *obj, cv::Mat *image)
{
	return obj->read(*image) ? 1 : 0;
}

CVAPI(int) highgui_VideoCapture_set(cv::VideoCapture *obj, int propId, double value)
{
	return obj->set(propId, value) ? 1 : 0;
}
CVAPI(double) highgui_VideoCapture_get(cv::VideoCapture *obj, int propId)
{
	return obj->get(propId);
}

#pragma endregion

#endif