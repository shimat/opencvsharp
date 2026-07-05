#pragma once

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(void) imgproc_LineSegmentDetector_detect_OutputArray(
    cv::LineSegmentDetector *obj,
    const interop::InputArrayProxy *image,
    const interop::OutputArrayProxy *lines,
    const interop::OutputArrayProxy *width,
    const interop::OutputArrayProxy *prec,
    const interop::OutputArrayProxy *nfa)
{
    obj->detect(InProxy(*image), OutProxy(*lines), OutProxy(*width), OutProxy(*prec), OutProxy(*nfa));
}

CVAPI(void) imgproc_LineSegmentDetector_detect_vector(
    cv::LineSegmentDetector *obj,
    const interop::InputArrayProxy *image,
    std::vector<cv::Vec4f> *lines,
    std::vector<double> *width,
    std::vector<double> *prec,
    std::vector<double> *nfa)
{
    obj->detect(InProxy(*image), *lines, *width, *prec, *nfa);
}

CVAPI(void) imgproc_LineSegmentDetector_drawSegments(
    cv::LineSegmentDetector *obj,
    const interop::InputOutputArrayProxy *image,
    const interop::InputArrayProxy *lines)
{
    obj->drawSegments(IoProxy(*image), InProxy(*lines));
}

CVAPI(int) imgproc_LineSegmentDetector_compareSegments(
    cv::LineSegmentDetector *obj,
    interop::Size size,
    const interop::InputArrayProxy *lines1,
    const interop::InputArrayProxy *lines2,
    const interop::InputOutputArrayProxy *image)
{
    return obj->compareSegments(cpp(size), InProxy(*lines1), InProxy(*lines2), IoProxy(*image));
}


CVAPI(cv::Ptr<cv::LineSegmentDetector>*) imgproc_createLineSegmentDetector(
    int refine, double scale, double sigma_scale, double quant, double ang_th,
    double log_eps, double density_th, int n_bins)
{
    return clone( cv::createLineSegmentDetector(
        static_cast<cv::LineSegmentDetectorModes>(refine), scale, sigma_scale, quant, ang_th, log_eps, density_th, n_bins));
}

CVAPI(ExceptionStatus) imgproc_Ptr_LineSegmentDetector_delete(cv::Ptr<cv::LineSegmentDetector> *obj)
{
    return cvTry([&] {
        delete obj;
    });
}

CVAPI(ExceptionStatus) imgproc_Ptr_LineSegmentDetector_get(cv::Ptr<cv::LineSegmentDetector> *obj, cv::LineSegmentDetector **returnValue)
{
    return cvTry([&] {
        *returnValue = obj->get();
    });
}
