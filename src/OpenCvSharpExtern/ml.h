#ifndef _CPP_ML_H_
#define _CPP_ML_H_

#include "include_opencv.h"

CVAPI(int) ml_initModule_ml()
{
    return cv::initModule_ml() ? 1 : 0;
}

#endif