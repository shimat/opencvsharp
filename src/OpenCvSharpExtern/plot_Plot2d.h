#pragma once

#ifndef NO_CONTRIB

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) plot_Ptr_Plot2d_delete(cv::Ptr<cv::plot::Plot2d>* obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) plot_Ptr_Plot2d_get(cv::Ptr<cv::plot::Plot2d>* ptr, cv::plot::Plot2d** returnValue)
{
    return cvTry([&] {
        *returnValue = ptr->get();
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_create1(
    const interop::InputArrayProxy* data,
    cv::Ptr<cv::plot::Plot2d>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::plot::Plot2d::create(InProxy(*data));
        *returnValue = new cv::Ptr<cv::plot::Plot2d>(ptr);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_create2(
    const interop::InputArrayProxy* dataX,
    const interop::InputArrayProxy* dataY,
    cv::Ptr<cv::plot::Plot2d>** returnValue)
{
    return cvTry([&] {
        const auto ptr = cv::plot::Plot2d::create(InProxy(*dataX), InProxy(*dataY));
        *returnValue = new cv::Ptr<cv::plot::Plot2d>(ptr);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setMinX(cv::plot::Plot2d* obj, double value)
{
    return cvTry([&] {
        obj->setMinX(value);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setMinY(cv::plot::Plot2d* obj, double value)
{
    return cvTry([&] {
        obj->setMinY(value);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setMaxX(cv::plot::Plot2d* obj, double value)
{
    return cvTry([&] {
        obj->setMaxX(value);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setMaxY(cv::plot::Plot2d* obj, double value)
{
    return cvTry([&] {
        obj->setMaxY(value);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setPlotLineWidth(cv::plot::Plot2d* obj, int value)
{
    return cvTry([&] {
        obj->setPlotLineWidth(value);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setNeedPlotLine(cv::plot::Plot2d* obj, int value)
{
    return cvTry([&] {
        obj->setNeedPlotLine(value != 0);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setPlotLineColor(cv::plot::Plot2d* obj, interop::Scalar value)
{
    return cvTry([&] {
        obj->setPlotLineColor(cpp(value));
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setPlotBackgroundColor(cv::plot::Plot2d* obj, interop::Scalar value)
{
    return cvTry([&] {
        obj->setPlotBackgroundColor(cpp(value));
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setPlotAxisColor(cv::plot::Plot2d* obj, interop::Scalar value)
{
    return cvTry([&] {
        obj->setPlotAxisColor(cpp(value));
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setPlotGridColor(cv::plot::Plot2d* obj, interop::Scalar value)
{
    return cvTry([&] {
        obj->setPlotGridColor(cpp(value));
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setPlotTextColor(cv::plot::Plot2d* obj, interop::Scalar value)
{
    return cvTry([&] {
        obj->setPlotTextColor(cpp(value));
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setPlotSize(cv::plot::Plot2d* obj, int width, int height)
{
    return cvTry([&] {
        obj->setPlotSize(width, height);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setShowGrid(cv::plot::Plot2d* obj, int value)
{
    return cvTry([&] {
        obj->setShowGrid(value != 0);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setShowText(cv::plot::Plot2d* obj, int value)
{
    return cvTry([&] {
        obj->setShowText(value != 0);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setGridLinesNumber(cv::plot::Plot2d* obj, int value)
{
    return cvTry([&] {
        obj->setGridLinesNumber(value);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setInvertOrientation(cv::plot::Plot2d* obj, int value)
{
    return cvTry([&] {
        obj->setInvertOrientation(value != 0);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_setPointIdxToPrint(cv::plot::Plot2d* obj, int value)
{
    return cvTry([&] {
        obj->setPointIdxToPrint(value);
    });
}

CVAPI(ExceptionStatus) plot_Plot2d_render(cv::plot::Plot2d* obj, const interop::OutputArrayProxy* plotResult)
{
    return cvTry([&] {
        obj->render(OutProxy(*plotResult));
    });
}

#endif // NO_CONTRIB
