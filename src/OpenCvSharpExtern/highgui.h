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

CVAPI(void) highgui_setWindowTitle(const char *winname, const char *title)
{
    cv::setWindowTitle(winname, title);
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

CVAPI(int) highgui_createButton(const char *bar_name, cv::ButtonCallback on_change,
    void* userdata, int type, int initial_button_state)
{
    return cv::createButton(bar_name, on_change, userdata, type, initial_button_state != 0);
}

#endif