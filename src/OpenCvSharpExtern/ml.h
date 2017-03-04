#ifndef _CPP_ML_H_
#define _CPP_ML_H_

#include "include_opencv.h"

extern "C"
{
    typedef struct ParamGridStruct
    {
        double minVal;
        double maxVal;
        double logStep;
    } ParamGridStruct;
}

static inline ParamGridStruct c(cv::ml::ParamGrid obj)
{
    ParamGridStruct ret;
    ret.minVal = obj.minVal;
    ret.maxVal = obj.maxVal;
    ret.logStep = obj.logStep;
    return ret;
}
static inline cv::ml::ParamGrid cpp(ParamGridStruct obj)
{
    return cv::ml::ParamGrid(obj.minVal, obj.maxVal, obj.logStep);
}

#endif