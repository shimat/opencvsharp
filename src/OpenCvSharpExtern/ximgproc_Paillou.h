#ifndef _CPP_XIMGPROC_PAILLOU_H_
#define _CPP_XIMGPROC_PAILLOU_H_

#include "include_opencv.h"

CVAPI(void) ximgproc_GradientPaillouY(cv::_InputArray *op, cv::_OutputArray *dst, double alpha, double omega)
{
    cv::ximgproc::GradientPaillouY(*op, *dst, alpha, omega);
}

CVAPI(void) ximgproc_GradientPaillouX(cv::_InputArray *op, cv::_OutputArray *dst, double alpha, double omega)
{
    cv::ximgproc::GradientPaillouX(*op, *dst, alpha, omega);
}

#endif