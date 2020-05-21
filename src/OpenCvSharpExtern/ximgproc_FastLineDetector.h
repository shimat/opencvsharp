#ifndef _CPP_XIMGPROC_FASTLINEDETECTOR_H_
#define _CPP_XIMGPROC_FASTLINEDETECTOR_H_

// ReSharper disable IdentifierTypo
// ReSharper disable CppInconsistentNaming
// ReSharper disable CppNonInlineFunctionDefinitionInHeaderFile

#include "include_opencv.h"

CVAPI(ExceptionStatus) ximgproc_Ptr_FastLineDetector_delete(
    cv::Ptr<cv::ximgproc::FastLineDetector> *obj)
{
    BEGIN_WRAP
    delete obj;
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_Ptr_FastLineDetector_get(
    cv::Ptr<cv::ximgproc::FastLineDetector> *ptr, cv::ximgproc::FastLineDetector **returnValue)
{
    BEGIN_WRAP
    *returnValue = ptr->get();
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_FastLineDetector_detect_OutputArray(
    cv::ximgproc::FastLineDetector *obj, cv::_InputArray *image, cv::_OutputArray *lines)
{
    BEGIN_WRAP
    obj->detect(*image, *lines);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_FastLineDetector_detect_vector(
    cv::ximgproc::FastLineDetector *obj, cv::_InputArray *image, std::vector<cv::Vec4f> *lines)
{
    BEGIN_WRAP
    obj->detect(*image, *lines);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_FastLineDetector_drawSegments_InputArray(
    cv::ximgproc::FastLineDetector *obj, cv::_InputOutputArray *image, cv::_InputArray *lines, int draw_arrow)
{
    BEGIN_WRAP
    obj->drawSegments(*image, *lines, draw_arrow != 0);
    END_WRAP
}

CVAPI(ExceptionStatus) ximgproc_FastLineDetector_drawSegments_vector(
    cv::ximgproc::FastLineDetector *obj, cv::_InputOutputArray *image, std::vector<cv::Vec4f> *lines, int draw_arrow)
{
    BEGIN_WRAP
    obj->drawSegments(*image, *lines, draw_arrow != 0);
    END_WRAP
}


CVAPI(ExceptionStatus) ximgproc_createFastLineDetector(
    int length_threshold, float distance_threshold, double canny_th1, double canny_th2, int canny_aperture_size, int do_merge,
    cv::Ptr<cv::ximgproc::FastLineDetector> **returnValue)
{
    BEGIN_WRAP
    const auto ptr = cv::ximgproc::createFastLineDetector(
        length_threshold, distance_threshold, canny_th1, canny_th2, canny_aperture_size, do_merge != 0);
    *returnValue = new cv::Ptr<cv::ximgproc::FastLineDetector>(ptr);
    END_WRAP
}

#endif