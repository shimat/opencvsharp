#ifndef _CPP_XIMGPROC_FASTLINEDETECTOR_H_
#define _CPP_XIMGPROC_FASTLINEDETECTOR_H_

#include "include_opencv.h"

CVAPI(void) ximgproc_FastLineDetector_delete(cv::Ptr<cv::ximgproc::FastLineDetector> *obj)
{
    delete obj;
}

CVAPI(cv::ximgproc::FastLineDetector*) ximgproc_Ptr_FastLineDetector_get(cv::Ptr<cv::ximgproc::FastLineDetector> *ptr)
{
    return ptr->get();
}

CVAPI(void) ximgproc_FastLineDetector_detect_OutputArray(cv::ximgproc::FastLineDetector *obj,
    cv::_InputArray *image, cv::_OutputArray *lines)
{
    obj->detect(*image, *lines);
}

CVAPI(void) ximgproc_FastLineDetector_detect_vector(cv::ximgproc::FastLineDetector *obj,
    cv::_InputArray *image, std::vector<cv::Vec4f> *lines)
{
    obj->detect(*image, *lines);
}

CVAPI(void) ximgproc_FastLineDetector_drawSegments_InputArray(cv::ximgproc::FastLineDetector *obj,
    cv::_InputOutputArray *image, cv::_InputArray *lines, int draw_arrow)
{
    obj->drawSegments(*image, *lines, draw_arrow != 0);
}

CVAPI(void) ximgproc_FastLineDetector_drawSegments_vector(cv::ximgproc::FastLineDetector *obj,
    cv::_InputOutputArray *image, std::vector<cv::Vec4f> *lines, int draw_arrow)
{
    obj->drawSegments(*image, *lines, draw_arrow != 0);
}


CVAPI(cv::Ptr<cv::ximgproc::FastLineDetector>*) ximgproc_createFastLineDetector(
    int length_threshold, float distance_threshold, double canny_th1, double canny_th2, int canny_aperture_size, int do_merge)
{
    cv::Ptr<cv::ximgproc::FastLineDetector> ptr = cv::ximgproc::createFastLineDetector(
        length_threshold, distance_threshold, canny_th1, canny_th2, canny_aperture_size, do_merge != 0);
    return new cv::Ptr<cv::ximgproc::FastLineDetector>(ptr);
}

#endif