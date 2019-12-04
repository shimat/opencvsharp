#ifndef _CPP_CORE_RNG_H_
#define _CPP_CORE_RNG_H_

#include "include_opencv.h"

CVAPI(ExceptionStatus) core_RNG_fill(uint64 *state, cv::_InputOutputArray *mat, int distType, cv::_InputArray *a, cv::_InputArray *b, int saturateRange)
{
    BEGIN_WRAP
    cv::RNG rng(*state);
    rng.fill(*mat, distType, *a, *b, saturateRange != 0);
    *state = rng.state;
    END_WRAP
}

CVAPI(ExceptionStatus) core_RNG_gaussian(uint64 *state, double sigma, double *returnValue)
{
    BEGIN_WRAP
    cv::RNG rng(*state);
    *returnValue = rng.gaussian(sigma);
    *state = rng.state;
    END_WRAP
}

#endif