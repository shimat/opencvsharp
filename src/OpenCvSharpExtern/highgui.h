#ifndef _CPP_HIGHGUI_H_
#define _CPP_HIGHGUI_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) highgui_namedWindow(const char *winname, int flags)
{
    BEGIN_WRAP
    cv::namedWindow(winname, flags);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_destroyWindow(const char *winName)
{
    BEGIN_WRAP
    cv::destroyWindow(winName);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_destroyAllWindows()
{
    BEGIN_WRAP
    cv::destroyAllWindows();
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_startWindowThread(int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::startWindowThread();
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_waitKeyEx(int delay, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::waitKeyEx(delay);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_waitKey(int delay, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::waitKey(delay);
    END_WRAP
}
  

CVAPI(ExceptionStatus) highgui_imshow(const char *winname, cv::Mat *mat)
{
    BEGIN_WRAP
    cv::imshow(winname, *mat);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_resizeWindow(const char *winName, int width, int height)
{
    BEGIN_WRAP
    cv::resizeWindow(winName, width, height);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_moveWindow(const char *winName, int x, int y)
{
    BEGIN_WRAP
    cv::moveWindow(winName, x, y);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_setWindowProperty(const char *winName, int propId, double propValue)
{
    BEGIN_WRAP
    cv::setWindowProperty(winName, propId, propValue);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_setWindowTitle(const char *winname, const char *title)
{
    BEGIN_WRAP
    // TODO Resolve:
#ifndef _WINRT_DLL
    cv::setWindowTitle(winname, title);
#endif
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_getWindowProperty(const char *winName, int propId, double *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getWindowProperty(winName, propId);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_getWindowImageRect(const char *winName, MyCvRect *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::getWindowImageRect(winName));
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_setMouseCallback(const char *winName, cv::MouseCallback onMouse, void* userData)
{
    BEGIN_WRAP
    cv::setMouseCallback(winName, onMouse, userData);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_getMouseWheelDelta(int flags, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getMouseWheelDelta(flags);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_selectROI1(const char *windowName, cv::_InputArray *img, int showCrosshair, int fromCenter, MyCvRect *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::selectROI(windowName, *img, showCrosshair != 0, fromCenter != 0));
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_selectROI2(cv::_InputArray *img, int showCrosshair, int fromCenter, MyCvRect *returnValue)
{
    BEGIN_WRAP
    *returnValue = c(cv::selectROI(*img, showCrosshair != 0, fromCenter != 0));
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_selectROIs(const char * windowName, cv::_InputArray *img,
                             std::vector<cv::Rect> *boundingBoxes, int showCrosshair, int fromCenter)
{
    BEGIN_WRAP
    cv::selectROIs(windowName, *img, *boundingBoxes, showCrosshair != 0, fromCenter != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_createTrackbar(const char *trackbarName, const char *winName,
    int* value, int count, cv::TrackbarCallback onChange, void* userData, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::createTrackbar(trackbarName, winName, value, count, onChange, userData);
    END_WRAP
}
CVAPI(ExceptionStatus) highgui_getTrackbarPos(const char *trackbarName, const char *winName, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::getTrackbarPos(trackbarName, winName);
    END_WRAP  
}
CVAPI(ExceptionStatus) highgui_setTrackbarPos(const char *trackbarName, const char *winName, int pos)
{
    BEGIN_WRAP
    cv::setTrackbarPos(trackbarName, winName, pos);
    END_WRAP
}

CVAPI(ExceptionStatus) highgui_setTrackbarMax(const char *trackbarName, const char *winName, int maxVal)
{
    BEGIN_WRAP
    cv::setTrackbarMax(trackbarName, winName, maxVal);
    END_WRAP
}
CVAPI(ExceptionStatus) highgui_setTrackbarMin(const char *trackbarName, const char *winName, int minVal)
{
    BEGIN_WRAP
    cv::setTrackbarMin(trackbarName, winName, minVal);
    END_WRAP
}

/*CVAPI(ExceptionStatus) highgui_createButton(const char *bar_name, cv::ButtonCallback on_change,
    void* user_data, int type, int initial_button_state, int *returnValue)
{
    BEGIN_WRAP
    *returnValue = cv::createButton(bar_name, on_change, user_data, type, initial_button_state != 0);
    END_WRAP
}*/

#ifdef _WINRT_DLL
CVAPI(ExceptionStatus) highgui_initContainer(::Windows::UI::Xaml::Controls::Panel^ panel)
{
    BEGIN_WRAP
    cv::winrt_initContainer(panel);
    END_WRAP
}
#endif

#endif