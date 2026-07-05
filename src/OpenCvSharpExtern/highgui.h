#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

#ifndef NO_HIGHGUI

CVAPI(ExceptionStatus) highgui_namedWindow(const char *winname, int flags)
{
    return cvTry([&] {
        cv::namedWindow(winname, flags);
    });
}

CVAPI(ExceptionStatus) highgui_destroyWindow(const char *winName)
{
    return cvTry([&] {
        cv::destroyWindow(winName);
    });
}

CVAPI(ExceptionStatus) highgui_destroyAllWindows()
{
    return cvTry([&] {
        cv::destroyAllWindows();
    });
}

CVAPI(ExceptionStatus) highgui_startWindowThread(int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::startWindowThread();
    });
}

CVAPI(ExceptionStatus) highgui_waitKeyEx(int delay, int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::waitKeyEx(delay);
    });
}

CVAPI(ExceptionStatus) highgui_waitKey(int delay, int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::waitKey(delay);
    });
}
  

CVAPI(ExceptionStatus) highgui_imshow(const char *winname, cv::Mat *mat)
{
    return cvTry([&] {
        cv::imshow(winname, *mat);
    });
}

CVAPI(ExceptionStatus) highgui_imshow_umat(const char* winname, cv::UMat* mat)
{
    return cvTry([&] {
        cv::imshow(winname, *mat);
    });
}

CVAPI(ExceptionStatus) highgui_resizeWindow(
    const char *winName,
    int width,
    int height)
{
    return cvTry([&] {
        cv::resizeWindow(winName, width, height);
    });
}

CVAPI(ExceptionStatus) highgui_moveWindow(
    const char *winName,
    int x,
    int y)
{
    return cvTry([&] {
        cv::moveWindow(winName, x, y);
    });
}

CVAPI(ExceptionStatus) highgui_setWindowProperty(
    const char *winName,
    int propId,
    double propValue)
{
    return cvTry([&] {
        cv::setWindowProperty(winName, propId, propValue);
    });
}

CVAPI(ExceptionStatus) highgui_setWindowTitle(const char *winname, const char *title)
{
    return cvTry([&] {
        // TODO Resolve:
#ifndef _WINRT_DLL
        cv::setWindowTitle(winname, title);
#endif
    });
}

CVAPI(ExceptionStatus) highgui_getWindowProperty(
    const char *winName,
    int propId,
    double *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::getWindowProperty(winName, propId);
    });
}

CVAPI(ExceptionStatus) highgui_getWindowImageRect(const char *winName, interop::Rect *returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::getWindowImageRect(winName));
    });
}

CVAPI(ExceptionStatus) highgui_setMouseCallback(
    const char *winName,
    cv::MouseCallback onMouse,
    void* userData)
{
    return cvTry([&] {
        cv::setMouseCallback(winName, onMouse, userData);
    });
}

CVAPI(ExceptionStatus) highgui_getMouseWheelDelta(int flags, int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::getMouseWheelDelta(flags);
    });
}

CVAPI(ExceptionStatus) highgui_selectROI1(
    const char *windowName,
    const interop::InputArrayProxy* img,
    int showCrosshair,
    int fromCenter,
    interop::Rect *returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::selectROI(windowName, InProxy(*img), showCrosshair != 0, fromCenter != 0));
    });
}

CVAPI(ExceptionStatus) highgui_selectROI2(
    const interop::InputArrayProxy* img,
    int showCrosshair,
    int fromCenter,
    interop::Rect *returnValue)
{
    return cvTry([&] {
        *returnValue = c(cv::selectROI(InProxy(*img), showCrosshair != 0, fromCenter != 0));
    });
}

CVAPI(ExceptionStatus) highgui_selectROIs(
    const char * windowName,
    const interop::InputArrayProxy* img,
    std::vector<cv::Rect> *boundingBoxes,
    int showCrosshair,
    int fromCenter)
{
    return cvTry([&] {
        cv::selectROIs(windowName, InProxy(*img), *boundingBoxes, showCrosshair != 0, fromCenter != 0);
    });
}

CVAPI(ExceptionStatus) highgui_createTrackbar(
    const char *trackbarName,
    const char *winName,
    int* value,
    int count,
    cv::TrackbarCallback onChange,
    void* userData,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::createTrackbar(trackbarName, winName, value, count, onChange, userData);
    });
}
CVAPI(ExceptionStatus) highgui_getTrackbarPos(
    const char *trackbarName,
    const char *winName,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::getTrackbarPos(trackbarName, winName);
    });  
}
CVAPI(ExceptionStatus) highgui_setTrackbarPos(
    const char *trackbarName,
    const char *winName,
    int pos)
{
    return cvTry([&] {
        cv::setTrackbarPos(trackbarName, winName, pos);
    });
}

CVAPI(ExceptionStatus) highgui_setTrackbarMax(
    const char *trackbarName,
    const char *winName,
    int maxVal)
{
    return cvTry([&] {
        cv::setTrackbarMax(trackbarName, winName, maxVal);
    });
}
CVAPI(ExceptionStatus) highgui_setTrackbarMin(
    const char *trackbarName,
    const char *winName,
    int minVal)
{
    return cvTry([&] {
        cv::setTrackbarMin(trackbarName, winName, minVal);
    });
}

/*CVAPI(ExceptionStatus) highgui_createButton(
    const char *bar_name,
    cv::ButtonCallback on_change,
    void* user_data,
    int type,
    int initial_button_state,
    int *returnValue)
{
    return cvTry([&] {
        *returnValue = cv::createButton(bar_name, on_change, user_data, type, initial_button_state != 0);
    });
}*/

#ifdef _WINRT_DLL
CVAPI(ExceptionStatus) highgui_initContainer(::Windows::UI::Xaml::Controls::Panel^ panel)
{
    return cvTry([&] {
        cv::winrt_initContainer(panel);
    });
}
#endif

#endif // NO_HIGHGUI
