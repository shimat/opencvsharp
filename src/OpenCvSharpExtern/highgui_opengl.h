#pragma once
#ifndef NO_HIGHGUI

#include "include_opencv.h"

CVAPI(ExceptionStatus) highgui_setOpenGlContext(const char* windowName)
{
    return cvTry([&] {
        cv::setOpenGlContext(windowName);
    });
}

CVAPI(ExceptionStatus) highgui_updateWindow(const char* windowName)
{
    return cvTry([&] {
        cv::updateWindow(windowName);
    });
}

CVAPI(ExceptionStatus) highgui_setOpenGlDrawCallback(const char* windowName, cv::OpenGlDrawCallback callback, void* userData)
{
    return cvTry([&] {
        cv::setOpenGlDrawCallback(windowName, callback, userData);
    });
}

CVAPI(ExceptionStatus) highgui_setOpenGlFreeCallback(const char* windowName, cv::OpenGlFreeCallback callback)
{
    return cvTry([&] {
        cv::setOpenGlFreeCallback(windowName, callback);
    });
}

CVAPI(ExceptionStatus) highgui_getOpenGlDrawCallback(const char* windowName, cv::OpenGlDrawCallback* callback)
{
    return cvTry([&] {
        *callback = cv::getOpenGlDrawCallback(windowName);
    });
}

CVAPI(ExceptionStatus) highgui_getOpenGlUserData(const char* windowName, void** userData)
{
    return cvTry([&] {
        *userData = cv::getOpenGlUserData(windowName);
    });
}

#endif
